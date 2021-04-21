﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Shared;
using Azure.Core;
using AutoRest.CSharp.Generation.Writers;
using AutoRest.CSharp.Mgmt.Output;
using Azure.ResourceManager.Core.Resources;
using Azure;
using Azure.ResourceManager.Core;
using Azure.Core.Pipeline;
using System.Threading.Tasks;

namespace AutoRest.CSharp.Mgmt.Generation
{
    /// <summary>
    /// Code writer for resource container.
    /// A resource container should have 3 operations:
    /// 1. CreateOrUpdate (4 variants)
    /// 2. Get (2 variants)
    /// 3. List (4 variants)
    /// and the following builder methods:
    /// 1. Construct
    /// </summary>
    internal class ResourceContainerWriter
    {
        private const string ClientDiagnosticsVariable = "_clientDiagnostics";
        private const string PipelineVariable = "_pipeline";

        public void WriteContainer(CodeWriter writer, ResourceContainer resourceContainer, AutoRest.MgmtOutputLibrary library)
        {
            new StatefulWriter(writer, resourceContainer, library).WriteContainer();
        }

        private class StatefulWriter
        {
            private CodeWriter _writer;
            private ResourceContainer _resourceContainer;
            private ResourceData _resourceData;
            private MgmtRestClient _restClient;
            private Resource _resource;

            public StatefulWriter(CodeWriter writer, ResourceContainer resourceContainer, AutoRest.MgmtOutputLibrary library)
            {
                _writer = writer;
                _resourceContainer = resourceContainer;
                var operationGroup = resourceContainer.OperationGroup;
                _resourceData = library.FindResourceData(operationGroup);
                _restClient = library.FindRestClient(operationGroup);
                _resource = library.FindArmResource(operationGroup);
            }

            public void WriteContainer()
            {
                _writer.UseNamespace(typeof(Task).Namespace!); // Explicitly adding `System.Threading.Tasks` because
                                                               // at build time I don't have the type information inside Task<>

                var cs = _resourceContainer.Type;
                var @namespace = cs.Namespace;
                using (_writer.Namespace(@namespace))
                {
                    _writer.WriteXmlDocumentationSummary(_resourceContainer.Description);
                    using (_writer.Scope($"{_resourceContainer.Declaration.Accessibility} partial class {cs.Name:D} : ResourceContainerBase<{_resourceContainer.ResourceIdentifierType}, {_resource.Type}, {_resourceData.Type}>"))
                    {
                        WriteContainerCtors();
                        WriteFields();
                        WriteIdProperty();
                        // WriteValidResourceType(writer, resourceContainer);
                        WriteContainerProperties();
                        WriteResourceOperations();
                        WriteBuilders();

                    }
                }
            }

            private void WriteContainerCtors()
            {
                _writer.WriteXmlDocumentationSummary($"Initializes a new instance of {_resourceContainer.Type.Name} class.");
                var resourceGroupParameterName = "resourceGroup";
                _writer.WriteXmlDocumentationParameter(resourceGroupParameterName, "The parent resource group.");

                using (_writer.Scope($"internal {_resourceContainer.Type.Name:D}(ResourceGroupOperations {resourceGroupParameterName}) : base({resourceGroupParameterName})"))
                {
                    _writer.Line($"{ClientDiagnosticsVariable} = new {typeof(ClientDiagnostics)}(ClientOptions);");
                    _writer.Line($"{PipelineVariable} = new {typeof(HttpPipeline)}(ClientOptions.Transport);");
                }
            }

            private void WriteFields()
            {
                _writer.Line();
                _writer.Line($"private readonly {typeof(ClientDiagnostics)} {ClientDiagnosticsVariable};");
                _writer.Line($"private readonly {typeof(HttpPipeline)} {PipelineVariable};");

                _writer.Line();
                _writer.WriteXmlDocumentationSummary($"Represents the REST operations.");
                // subscriptionId might not always be needed. For example `RestOperations` does not have it.
                var subscriptionId = _restClient.Parameters.FirstOrDefault()?.Name == "subscriptionId" ? ", Id.SubscriptionId" : "";
                _writer.Line($"private {_resourceContainer.RestOperationsDefaultName} Operations => new {_resourceContainer.RestOperationsDefaultName}({ClientDiagnosticsVariable}, {PipelineVariable}{subscriptionId});");
            }

            private void WriteIdProperty()
            {
                _writer.Line();
                _writer.WriteXmlDocumentationSummary($"Typed Resource Identifier for the container.");
                _writer.LineRaw("// todo: hard coding ResourceGroupResourceIdentifier we don't know the exact ID type but we need it in implementations in CreateOrUpdate() etc.");
                _writer.Line($"public new ResourceGroupResourceIdentifier Id => base.Id as ResourceGroupResourceIdentifier;");
            }

            private void WriteValidResourceType()
            {
                _writer.Line();
                _writer.WriteXmlDocumentationInheritDoc();
                // todo: what if valid resource type is not resource group?
                _writer.Line($"protected override ResourceType ValidResourceType => {"ResourceGroupOperations"}.ResourceType;");
            }

            private void WriteResourceOperations()
            {
                _writer.Line();
                _writer.LineRaw($"// Container level operations.");

                // To generate resource operations, we need to find out the correct REST client methods to call.
                // We can't find CreateOrUpdate method by name cause it may not always be called `CreateOrUpdate`.
                if (FindRestClientMethodByHttpMethod(RequestMethod.Put, out var restClientMethod))
                {
                    WriteCreateOrUpdateVariants(restClientMethod);
                }
                else
                {
                    WriteFakeCreateOrUpdateVariants();
                }

                // We can't find Get method by HTTP method because it may map to List
                if (FindRestClientMethodByHttpMethod(new string[] { "Get" }, out restClientMethod))
                {
                    WriteGetVariants(restClientMethod);
                }

                WriteListAsGenericResource();
                WriteListAsGenericResourceAsync();
                WriteList();
                WriteListAsync();
            }

            private bool FindRestClientMethodByHttpMethod(RequestMethod httpMethod, out RestClientMethod restMethod)
            {
                restMethod = _restClient.Methods.FirstOrDefault(m => m.Request.HttpMethod.Equals(httpMethod));
                return restMethod != null;
            }
            private bool FindRestClientMethodByHttpMethod(IEnumerable<string> nameOptions, out RestClientMethod restMethod)
            {
                restMethod = _restClient.Methods.FirstOrDefault(m => nameOptions.Any(nameOption => string.Equals(m.Name, nameOption, StringComparison.InvariantCultureIgnoreCase)));
                return restMethod != null;
            }

            private void WriteCreateOrUpdateVariants(RestClientMethod restClientMethod)
            {
                // hack: should add a IsLongRunning property to method?
                var isLongRunning = restClientMethod.Responses.All(response => response.ResponseBody == null);
                var parameterMapping = BuildParameterMapping(restClientMethod);

                // CreateOrUpdate()
                _writer.Line();
                _writer.WriteXmlDocumentationInheritDoc();
                foreach (var parameter in parameterMapping.Where(p => p.IsPassThru))
                {
                    _writer.WriteXmlDocumentationParameter(parameter.Parameter.Name, parameter.Parameter.Description);
                }
                _writer.WriteXmlDocumentationParameter("cancellationToken", @"A token to allow the caller to cancel the call to the service. The default value is <see cref=""P:System.Threading.CancellationToken.None"" />.");

                _writer.Append($"public override ArmResponse<{_resource.Type}> CreateOrUpdate(");
                foreach (var parameter in parameterMapping.Where(p => p.IsPassThru))
                {
                    _writer.WriteParameter(parameter.Parameter);
                }
                using (_writer.Scope($"{typeof(CancellationToken)} cancellationToken = default)"))
                {
                    _writer.Append($"return StartCreateOrUpdate(");
                    foreach (var parameter in parameterMapping)
                    {
                        if (parameter.IsPassThru)
                        {
                            _writer.AppendRaw($"{parameter.Parameter.Name}, ");
                        }
                    }
                    _writer.Line($"cancellationToken: cancellationToken).WaitForCompletion() as ArmResponse<{_resource.Type}>;");
                }

                // CreateOrUpdateAsync()
                _writer.Line();
                _writer.WriteXmlDocumentationInheritDoc();
                foreach (var parameter in parameterMapping.Where(p => p.IsPassThru))
                {
                    _writer.WriteXmlDocumentationParameter(parameter.Parameter.Name, parameter.Parameter.Description);
                }
                _writer.WriteXmlDocumentationParameter("cancellationToken", @"A token to allow the caller to cancel the call to the service. The default value is <see cref=""P:System.Threading.CancellationToken.None"" />.");

                _writer.Append($"public async override Task<ArmResponse<{_resource.Type}>> CreateOrUpdateAsync(");
                foreach (var parameter in parameterMapping.Where(p => p.IsPassThru))
                {
                    _writer.WriteParameter(parameter.Parameter);
                }
                using (_writer.Scope($"{typeof(CancellationToken)} cancellationToken = default)"))
                {
                    _writer.Append($"var operation = await StartCreateOrUpdateAsync(");
                    foreach (var parameter in parameterMapping)
                    {
                        if (parameter.IsPassThru)
                        {
                            _writer.AppendRaw($"{parameter.Parameter.Name}, ");
                        }
                    }
                    _writer.Line($"cancellationToken: cancellationToken).ConfigureAwait(false);");
                    _writer.Line($"return operation.WaitForCompletion() as ArmResponse<{_resource.Type}>;");  // no WaitForCompletionAsync()?
                }

                // StartCreateOrUpdate()
                _writer.Line();
                _writer.WriteXmlDocumentationInheritDoc();
                foreach (var parameter in parameterMapping.Where(p => p.IsPassThru))
                {
                    _writer.WriteXmlDocumentationParameter(parameter.Parameter.Name, parameter.Parameter.Description);
                }
                _writer.WriteXmlDocumentationParameter("cancellationToken", @"A token to allow the caller to cancel the call to the service. The default value is <see cref=""P:System.Threading.CancellationToken.None"" />.");

                _writer.Append($"public override ArmOperation<{_resource.Type}> StartCreateOrUpdate(");
                foreach (var parameter in parameterMapping.Where(p => p.IsPassThru))
                {
                    _writer.WriteParameter(parameter.Parameter);
                }
                using (_writer.Scope($"{typeof(CancellationToken)} cancellationToken = default)"))
                {
                    _writer.Append($"var originalResponse = Operations.{restClientMethod.Name}(");
                    foreach (var parameter in parameterMapping)
                    {
                        _writer.AppendRaw(parameter.IsPassThru ? parameter.Parameter.Name : parameter.ValueExpression);
                        _writer.AppendRaw(", ");
                    }
                    _writer.Line($"cancellationToken: cancellationToken);");
                    if (isLongRunning)
                    {
                        _writer.Line($"var operation = new {_resource.Type}{restClientMethod.Name}Operation(");
                        _writer.Line($"{ClientDiagnosticsVariable}, {PipelineVariable}, Operations.Create{restClientMethod.Name}Request(");
                        foreach (var parameter in parameterMapping)
                        {
                            _writer.AppendRaw(parameter.IsPassThru ? parameter.Parameter.Name : parameter.ValueExpression);
                            _writer.AppendRaw(", ");
                        }
                        _writer.RemoveTrailingComma();
                        _writer.Line($").Request,");
                        _writer.Line($"originalResponse);");
                        _writer.Line($"return new PhArmOperation<{_resource.Type}, {_resourceData.Type}>(");
                        _writer.Line($"operation,");
                        _writer.Line($"data => new {_resource.Type}(Parent, data));");
                    }
                    else
                    {
                        _writer.Line($"return new PhArmOperation<{_resource.Type}, {_resourceData.Type}>(");
                        _writer.Line($"originalResponse,");
                        _writer.Line($"data => new {_resource.Type}(Parent, data));");

                    }
                }

                // StartCreateOrUpdateAsync()
                _writer.Line();
                _writer.WriteXmlDocumentationInheritDoc();
                foreach (var parameter in parameterMapping.Where(p => p.IsPassThru))
                {
                    _writer.WriteXmlDocumentationParameter(parameter.Parameter.Name, parameter.Parameter.Description);
                }
                _writer.WriteXmlDocumentationParameter("cancellationToken", @"A token to allow the caller to cancel the call to the service. The default value is <see cref=""P:System.Threading.CancellationToken.None"" />.");

                _writer.Append($"public async override Task<ArmOperation<{_resource.Type}>> StartCreateOrUpdateAsync(");
                foreach (var parameter in parameterMapping.Where(p => p.IsPassThru))
                {
                    _writer.WriteParameter(parameter.Parameter);
                }
                using (_writer.Scope($"{typeof(CancellationToken)} cancellationToken = default)"))
                {
                    _writer.Append($"var originalResponse = await Operations.{restClientMethod.Name}Async(");
                    foreach (var parameter in parameterMapping)
                    {
                        _writer.AppendRaw(parameter.IsPassThru ? parameter.Parameter.Name : parameter.ValueExpression);
                        _writer.AppendRaw(", ");
                    }
                    _writer.Line($"cancellationToken: cancellationToken).ConfigureAwait(false);");
                    if (isLongRunning)
                    {
                        _writer.Line($"var operation = new {_resource.Type}{restClientMethod.Name}Operation(");
                        _writer.Line($"{ClientDiagnosticsVariable}, {PipelineVariable}, Operations.Create{restClientMethod.Name}Request(");
                        foreach (var parameter in parameterMapping)
                        {
                            _writer.AppendRaw(parameter.IsPassThru ? parameter.Parameter.Name : parameter.ValueExpression);
                            _writer.AppendRaw(", ");
                        }
                        _writer.RemoveTrailingComma();
                        _writer.Line($").Request,");
                        _writer.Line($"originalResponse);");
                        _writer.Line($"return new PhArmOperation<{_resource.Type}, {_resourceData.Type}>(");
                        _writer.Line($"operation,");
                        _writer.Line($"data => new {_resource.Type}(Parent, data));");
                    }
                    else
                    {
                        _writer.Line($"return new PhArmOperation<{_resource.Type}, {_resourceData.Type}>(");
                        _writer.Line($"originalResponse,");
                        _writer.Line($"data => new {_resource.Type}(Parent, data));");
                    }
                }
            }

            /// <summary>
            /// Builds the mapping between resource operations in Container class and that in RestOperations class.
            /// </summary>
            /// <param name="method">Represents a method in RestOperations class.</param>
            /// <returns>
            /// A list of tuples containing
            /// - Parameter: the reference to the parameter object in RestClientMethod
            /// - IsPassThru: should the parameter be passed through from the method in container class
            /// - ValueExpression: if not pass-through, this is the value to pass in RestClientMethod
            /// </returns>
            private IEnumerable<(Parameter Parameter, bool IsPassThru, string ValueExpression)> BuildParameterMapping(RestClientMethod method)
            {
                var parameterMapping = new List<(Parameter Parameter, bool IsPassThru, string ValueExpression)>();
                var dotParent = "";

                foreach (var parameter in method.Parameters)
                {
                    bool passThru = true;
                    string valueExpression = string.Empty;
                    if (parameter.Type.Equals(typeof(System.String)))
                    {
                        // todo: how about "location"?
                        if (string.Equals(parameter.Name, "resourceGroupName", StringComparison.InvariantCultureIgnoreCase))
                        {
                            passThru = false;
                            valueExpression = "Id.ResourceGroupName";
                        }
                        else
                        {
                            passThru = false;
                            valueExpression = $"Id{dotParent}.Name";
                            dotParent += ".Parent";
                        }
                    }
                    else
                    {
                        passThru = true;
                    }
                    parameterMapping.Add((parameter, passThru, valueExpression));
                }
                // make last string parameter (typically the resource name) pass-through from container method
                // ignoring optional parameters such as `expand`
                var lastString = parameterMapping.LastOrDefault(parameter => parameter.Parameter.Type.Equals(typeof(System.String)) && parameter.Parameter.DefaultValue is null);
                if (lastString.Parameter != null && !lastString.Parameter.Name.Equals("resourceGroupName", StringComparison.InvariantCultureIgnoreCase))
                {
                    var index = parameterMapping.IndexOf(lastString);
                    parameterMapping[index] = (lastString.Parameter, true, string.Empty);
                    // can't just do `lastString.IsPassThru = true` as it does not affect parameterMapping
                    // lastString is not a ref?
                }
                return parameterMapping;
            }

            /// <summary>
            /// Write 4 variants of CreateOrUpdate that only throw exceptions when the resource does not support PUT,
            /// so that the container class implements the methods overload defined in `ContainerBase`.
            /// </summary>
            /// <param name="_writer"></param>
            private void WriteFakeCreateOrUpdateVariants()
            {
                var nameParameter = new Parameter("name", "The name of the resource.", typeof(string), null, false);
                var resourceDetailsParameter = new Parameter("resourceDetails", "The desired resource configuration.", _resourceContainer.ResourceData.Type, null, false);
                // CreateOrUpdate()
                _writer.Line();
                _writer.WriteXmlDocumentationInheritDoc();
                var parameters = new List<Parameter> { nameParameter, resourceDetailsParameter };
                _writer.Append($"public override ArmResponse<{_resource.Type}> CreateOrUpdate(");
                parameters.ForEach(parameter => _writer.WriteParameter(parameter));
                var doesNotSupportPut = @"This resource does not support PUT HTTP method.";
                using (_writer.Scope($"{typeof(CancellationToken)} cancellationToken = default)"))
                {
                    _writer.Line($"// {doesNotSupportPut}");
                    _writer.Line($"throw new {typeof(NotImplementedException)}();");
                }

                // CreateOrUpdateAsync()
                _writer.Line();
                _writer.WriteXmlDocumentationInheritDoc();
                _writer.Append($"public override Task<ArmResponse<{_resource.Type}>> CreateOrUpdateAsync(");
                parameters.ForEach(parameter => _writer.WriteParameter(parameter));
                using (_writer.Scope($"{typeof(CancellationToken)} cancellationToken = default)"))
                {
                    _writer.Line($"// {doesNotSupportPut}");
                    _writer.Line($"throw new {typeof(NotImplementedException)}();");
                }

                // StartCreateOrUpdate()
                _writer.Line();
                _writer.WriteXmlDocumentationInheritDoc();
                _writer.Append($"public override ArmOperation<{_resource.Type}> StartCreateOrUpdate(");
                parameters.ForEach(parameter => _writer.WriteParameter(parameter));
                using (_writer.Scope($"{typeof(CancellationToken)} cancellationToken = default)"))
                {
                    _writer.Line($"// {doesNotSupportPut}");
                    _writer.Line($"throw new {typeof(NotImplementedException)}();");
                }

                // StartCreateOrUpdateAsync()
                _writer.Line();
                _writer.WriteXmlDocumentationInheritDoc();
                _writer.Append($"public override Task<ArmOperation<{_resource.Type}>> StartCreateOrUpdateAsync(");
                parameters.ForEach(parameter => _writer.WriteParameter(parameter));
                using (_writer.Scope($"{typeof(CancellationToken)} cancellationToken = default)"))
                {
                    _writer.Line($"// {doesNotSupportPut}");
                    _writer.Line($"throw new {typeof(NotImplementedException)}();");
                }
            }

            private void WriteCreateOrUpdateAsync()
            {

                _writer.Line();
                _writer.WriteXmlDocumentationInheritDoc();
                using (_writer.Scope($"public async override Task<ArmResponse<{_resource.Type}>> CreateOrUpdateAsync(string name, {_resourceData.Type} resourceDetails, {typeof(CancellationToken)} cancellationToken = default)"))
                {
                    _writer.Line($"var response = await Operations.CreateOrUpdateAsync(Id.ResourceGroupName, name, resourceDetails).ConfigureAwait(false);");
                    _writer.Line($"return new PhArmResponse<{_resource.Type}, {_resourceData.Type}>(");
                    _writer.Line($"response,");
                    _writer.Line($"data => new {_resource.Type}(Parent, data));");
                }
            }

            private void WriteStartCreateOrUpdate()
            {
                _writer.Line();
                _writer.WriteXmlDocumentationInheritDoc();
                using (_writer.Scope($"public override ArmOperation<{_resource.Type}> StartCreateOrUpdate(string name, {_resourceData.Type} resourceDetails, {typeof(CancellationToken)} cancellationToken = default)"))
                {
                    _writer.Line($"return new PhArmOperation<{_resource.Type}, {_resourceData.Type}>(");
                    _writer.Line($"Operations.CreateOrUpdate(Id.ResourceGroupName, name, resourceDetails, cancellationToken),");
                    _writer.Line($"data => new {_resource.Type}(Parent, data));");
                }
            }

            private void WriteStartCreateOrUpdateAsync()
            {
                _writer.Line();
                _writer.WriteXmlDocumentationInheritDoc();
                using (_writer.Scope($"public async override Task<ArmOperation<{_resource.Type}>> StartCreateOrUpdateAsync(string name, {_resourceData.Type} resourceDetails, {typeof(CancellationToken)} cancellationToken = default)"))
                {
                    _writer.Line($"return new PhArmOperation<{_resource.Type}, {_resourceData.Type}>(");
                    _writer.Line($"await Operations.CreateOrUpdateAsync(Id.ResourceGroupName, name, resourceDetails, cancellationToken).ConfigureAwait(false),");
                    _writer.Line($"data => new {_resource.Type}(Parent, data));");
                }
                _writer.Line();
            }

            private void WriteContainerProperties()
            {
                var resourceType = _resourceContainer.GetValidResourceValue();

                // TODO: Remove this if condition after https://dev.azure.com/azure-mgmt-ex/DotNET%20Management%20SDK/_workitems/edit/5800
                if (!resourceType.Contains(".ResourceType"))
                {
                    resourceType = $"\"{resourceType}\"";
                }

                _writer.WriteXmlDocumentationSummary($"Gets the valid resource type for this object");
                _writer.Line($"protected override {typeof(ResourceType)} ValidResourceType => {resourceType};");
            }

            private void WriteGetVariants(RestClientMethod method)
            {
                var parameterMapping = BuildParameterMapping(method);
                // some Get() contains extra non-name parameters which if added to method signature,
                // would break the inheritance to ResourceContainerBase
                // e.g. `expand` when getting image in compute RP
                parameterMapping = parameterMapping.Where(mapping => mapping.Parameter.DefaultValue is null);

                // Get()
                _writer.Line();
                _writer.WriteXmlDocumentationInheritDoc();
                foreach (var parameter in parameterMapping.Where(p => p.IsPassThru))
                {
                    _writer.WriteXmlDocumentationParameter(parameter.Parameter.Name, parameter.Parameter.Description);
                }
                _writer.WriteXmlDocumentationParameter("cancellationToken", @"A token to allow the caller to cancel the call to the service. The default value is <see cref=""P:System.Threading.CancellationToken.None"" />.");

                _writer.Append($"public override ArmResponse<{_resource.Type}> Get(");
                foreach (var parameter in parameterMapping.Where(p => p.IsPassThru))
                {
                    _writer.WriteParameter(parameter.Parameter);
                }
                using (_writer.Scope($"{typeof(CancellationToken)} cancellationToken = default)"))
                {
                    _writer.Line($"return new PhArmResponse<{_resource.Type}, {_resourceData.Type}>(");
                    _writer.Append($"Operations.Get(");
                    foreach (var parameter in parameterMapping)
                    {
                        _writer.AppendRaw(parameter.IsPassThru ? parameter.Parameter.Name : parameter.ValueExpression);
                        _writer.AppendRaw(", ");
                    }
                    _writer.Line($"cancellationToken: cancellationToken),");
                    _writer.Line($"data => new {_resource.Type}(Parent, data));");
                }

                // GetAsync()
                _writer.Line();
                _writer.WriteXmlDocumentationInheritDoc();
                foreach (var parameter in parameterMapping.Where(p => p.IsPassThru))
                {
                    _writer.WriteXmlDocumentationParameter(parameter.Parameter.Name, parameter.Parameter.Description);
                }
                _writer.WriteXmlDocumentationParameter("cancellationToken", @"A token to allow the caller to cancel the call to the service. The default value is <see cref=""P:System.Threading.CancellationToken.None"" />.");

                _writer.Append($"public async override Task<ArmResponse<{_resource.Type}>> GetAsync(");
                foreach (var parameter in parameterMapping.Where(p => p.IsPassThru))
                {
                    _writer.WriteParameter(parameter.Parameter);
                }
                using (_writer.Scope($"{typeof(CancellationToken)} cancellationToken = default)"))
                {
                    _writer.Line($"return new PhArmResponse<{_resource.Type}, {_resourceData.Type}>(");
                    _writer.Append($"await Operations.GetAsync(");
                    foreach (var parameter in parameterMapping)
                    {
                        _writer.AppendRaw(parameter.IsPassThru ? parameter.Parameter.Name : parameter.ValueExpression);
                        _writer.AppendRaw(", ");
                    }
                    _writer.Line($"cancellationToken: cancellationToken),");
                    _writer.Line($"data => new {_resource.Type}(Parent, data));");
                }
            }

            private void WriteGetAsync(RestClientMethod method)
            {
                _writer.Line();
                _writer.WriteXmlDocumentationInheritDoc();
                using (_writer.Scope($"public async override Task<ArmResponse<{_resource.Type}>> GetAsync(string name, {typeof(CancellationToken)} cancellationToken = default)"))
                {
                    _writer.Line($"return new PhArmResponse<{_resource.Type}, {_resourceData.Type}>(");
                    _writer.Line($"await Operations.GetAsync(Id.ResourceGroupName, name, cancellationToken),");
                    _writer.Line($"data => new {_resource.Type}(Parent, data));");
                }
            }

            private void WriteList()
            {
                _writer.Line();
                // todo: do not hard code resource type
                _writer.WriteXmlDocumentationSummary($"Filters the list of {"todo: availability set"} for this resource group. Makes an additional network call to retrieve the full data model for each resource group.");
                _writer.WriteXmlDocumentationParameter("nameFilter", "The filter used in this operation.");
                _writer.WriteXmlDocumentationParameter("top", "The number of results to return.");
                _writer.WriteXmlDocumentationParameter("cancellationToken", "A token to allow the caller to cancel the call to the service. The default value is <see cref=\"P:System.Threading.CancellationToken.None\" />.");
                // todo: do not hard code resource type
                _writer.WriteXmlDocumentation("returns", $"A collection of {"todo: availability set"} that may take multiple service requests to iterate over.");
                using (_writer.Scope($"public Pageable<{_resource.Type}> List(string nameFilter, int? top = null, {typeof(CancellationToken)} cancellationToken = default)"))
                {
                    _writer.Line($"var results = ListAsGenericResource(nameFilter, top, cancellationToken);");
                    _writer.Line($"return new PhWrappingPageable<GenericResource, {_resource.Type}>(results, genericResource => new {_resourceContainer.OperationsDefaultName}(genericResource).Get().Value);");
                }
            }

            private void WriteListAsync()
            {
                _writer.Line();
                // todo: do not hard code resource type
                _writer.WriteXmlDocumentationSummary($"Filters the list of {"todo: availability set"} for this resource group. Makes an additional network call to retrieve the full data model for each resource group.");
                _writer.WriteXmlDocumentationParameter("nameFilter", "The filter used in this operation.");
                _writer.WriteXmlDocumentationParameter("top", "The number of results to return.");
                _writer.WriteXmlDocumentationParameter("cancellationToken", "A token to allow the caller to cancel the call to the service. The default value is <see cref=\"P:System.Threading.CancellationToken.None\" />.");
                // todo: do not hard code resource type
                _writer.WriteXmlDocumentation("returns", $"An async collection of {"todo: availability set"} that may take multiple service requests to iterate over.");
                using (_writer.Scope($"public AsyncPageable<{_resource.Type}> ListAsync(string nameFilter, int? top = null, {typeof(CancellationToken)} cancellationToken = default)"))
                {
                    _writer.Line($"var results = ListAsGenericResourceAsync(nameFilter, top, cancellationToken);");
                    _writer.Line($"return new PhWrappingAsyncPageable<GenericResource, {_resource.Type}>(results, genericResource => new {_resourceContainer.OperationsDefaultName}(genericResource).Get().Value);");
                }
            }

            private void WriteListAsGenericResource()
            {
                _writer.Line();
                // todo: do not hard code resource type
                _writer.WriteXmlDocumentationSummary($"Filters the list of {"todo: availability set"} for this resource group represented as generic resources.");
                _writer.WriteXmlDocumentationParameter("nameFilter", "The filter used in this operation.");
                _writer.WriteXmlDocumentationParameter("top", "The number of results to return.");
                _writer.WriteXmlDocumentationParameter("cancellationToken", "A token to allow the caller to cancel the call to the service. The default value is <see cref=\"P:System.Threading.CancellationToken.None\" />.");
                _writer.WriteXmlDocumentation("returns", $"A collection of resource that may take multiple service requests to iterate over.");
                using (_writer.Scope($"public {typeof(Pageable<GenericResource>)} ListAsGenericResource(string nameFilter, int? top = null, {typeof(CancellationToken)} cancellationToken = default)"))
                {
                    _writer.Line($"var filters = new {typeof(ResourceFilterCollection)}({_resourceData.Type}.ResourceType);");
                    _writer.Line($"filters.SubstringFilter = nameFilter;");
                    // todo: do not hard code ResourceGroupOperations
                    _writer.Line($"return ResourceListOperations.ListAtContext(Parent as ResourceGroupOperations, filters, top, cancellationToken);");
                }
            }

            private void WriteListAsGenericResourceAsync()
            {
                _writer.Line();
                // todo: do not hard code resource type
                _writer.WriteXmlDocumentationSummary($"Filters the list of {"todo: availability set"} for this resource group represented as generic resources.");
                _writer.WriteXmlDocumentationParameter("nameFilter", "The filter used in this operation.");
                _writer.WriteXmlDocumentationParameter("top", "The number of results to return.");
                _writer.WriteXmlDocumentationParameter("cancellationToken", "A token to allow the caller to cancel the call to the service. The default value is <see cref=\"P:System.Threading.CancellationToken.None\" />.");
                _writer.WriteXmlDocumentation("returns", $"An async collection of resource that may take multiple service requests to iterate over.");
                using (_writer.Scope($"public {typeof(AsyncPageable<GenericResource>)} ListAsGenericResourceAsync(string nameFilter, int? top = null, {typeof(CancellationToken)} cancellationToken = default)"))
                {
                    _writer.Line($"var filters = new {typeof(ResourceFilterCollection)}({_resourceData.Type}.ResourceType);");
                    _writer.Line($"filters.SubstringFilter = nameFilter;");
                    // todo: do not hard code ResourceGroupOperations
                    _writer.Line($"return ResourceListOperations.ListAtContextAsync(Parent as ResourceGroupOperations, filters, top, cancellationToken);");
                }
            }

            private void WriteBuilders()
            {
                _writer.Line();
                _writer.Line($"// Builders.");
                _writer.LineRaw($"// public ArmBuilder<{_resourceContainer.ResourceIdentifierType}, {_resource.Type.Name}, {_resourceData.Type.Name}> Construct() {{ }}");
            }
        }
    }
}
// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using AutoRest.CSharp.Output.Models;
using Azure.Core.Pipeline;

namespace AutoRest.CSharp.Generation.Writers
{
    internal class ResourceContainerWriter
    {
        private const string ClientDiagnosticsVariable = "clientDiagnostics";
        private const string PipelineVariable = "pipeline";

        public void WriteClient(CodeWriter writer, ResourceContainer resourceContainer)
        {
            WriteUsings(writer, resourceContainer);
            var cs = resourceContainer.Type;
            var @namespace = cs.Namespace;
            using (writer.Namespace(@namespace))
            {
                writer.WriteXmlDocumentationSummary(resourceContainer.Description);
                // todo: do not hard code ResourceGroupResourceIdentifier
                var baseClass = $"ResourceContainerBase<{resourceContainer.ResourceDefaultName}, {resourceContainer.DataDefaultName}>";
                using (writer.Scope($"{resourceContainer.Declaration.Accessibility} partial class {cs.Name:D} : {baseClass}"))
                {
                    WriteClientCtors(writer, resourceContainer);
                    WriteOperationsField(writer, resourceContainer);
                    //WriteIdProperty(writer, resourceContainer);
                    WriteValidResourceType(writer, resourceContainer);
                    WriteResourceOperations(writer, resourceContainer);
                    //WriteBuilders(writer, resourceContainer);
                }
            }
        }

        private void WriteUsings(CodeWriter writer, ResourceContainer resourceContainer)
        {
            writer.UseNamespaces(
                "System.Threading",
                "System.Threading.Tasks",
                "Azure.Core.Pipeline",
                "Azure.ResourceManager.Core"
            );
        }

        private void WriteClientCtors(CodeWriter writer, ResourceContainer resourceContainer)
        {
            writer.WriteXmlDocumentationSummary($"Initializes a new instance of {resourceContainer.Type.Name} class.");
            var resourceGroupParameterName = "resourceGroup";
            writer.WriteXmlDocumentationParameter(resourceGroupParameterName, "The parent resource group.");

            using (writer.Scope($"internal {resourceContainer.Type.Name:D}(ResourceGroupOperations {resourceGroupParameterName}) : base({resourceGroupParameterName})"))
            {
            }
        }

        private void WriteOperationsField(CodeWriter writer, ResourceContainer resourceContainer)
        {
            writer.Line();
            writer.WriteXmlDocumentationSummary($"Represents the REST operations.");
            // todo: try inline using
            using (writer.Scope($"private {resourceContainer.RestOperationsDefaultName} Operations"))
            {
                using (writer.Scope($"get"))
                {
                    //using (writer.Scope($"if (Id.TryGetSubscriptionId(out var subscriptionId))"))
                    //{
                        using var _ = writer.Scope($"return new {resourceContainer.RestOperationsDefaultName}", "(", ");");
                        writer.LineRaw($"new Azure.Core.Pipeline.ClientDiagnostics(ClientOptions),");
                        writer.Line($"new HttpPipeline(ClientOptions.Transport),");
                        writer.Line($"Id.Subscription");
                    //}
                    //writer.Line($"throw new System.Exception(\"Todo: no sub id\");");
                }
            }
        }

        private void WriteIdProperty(CodeWriter writer, ResourceContainer resourceContainer)
        {
            writer.Line();
            writer.WriteXmlDocumentationSummary($"Typed Resource Identifier for the container.");
            // todo: do not hard code ResourceGroupResourceIdentifier
            writer.Line($"public new ResourceGroupResourceIdentifier Id => base.Id as ResourceGroupResourceIdentifier;");
        }

        private void WriteValidResourceType(CodeWriter writer, ResourceContainer resourceContainer)
        {
            writer.Line();
            writer.WriteXmlDocumentationInheritDoc();
            // todo: what if valid resource type is not resource group?
            writer.Line($"protected override ResourceType ValidResourceType => {"ResourceGroupOperations"}.ResourceType;");
        }

        private void WriteResourceOperations(CodeWriter writer, ResourceContainer resourceContainer)
        {
            writer.Line();
            writer.LineRaw($"// Container level operations.");
            WriteCreateOrUpdate(writer, resourceContainer);
            WriteCreateOrUpdateAsync(writer, resourceContainer);
            WriteStartCreateOrUpdate(writer, resourceContainer);
            WriteStartCreateOrUpdateAsync(writer, resourceContainer);
            WriteGet(writer, resourceContainer);
            WriteGetAsync(writer, resourceContainer);
            WriteList(writer, resourceContainer);
            WriteListAsync(writer, resourceContainer);
            WriteListAsGenericResource(writer, resourceContainer);
            WriteListAsGenericResourceAsync(writer, resourceContainer);
        }

        private void WriteCreateOrUpdate(CodeWriter writer, ResourceContainer resourceContainer)
        {
            writer.Line();
            writer.WriteXmlDocumentationInheritDoc();
            using (writer.Scope($"public override ArmResponse<{resourceContainer.ResourceDefaultName}> CreateOrUpdate(string name, {resourceContainer.DataDefaultName} resourceDetails, {typeof(CancellationToken)} cancellationToken = default)"))
            {
                writer.Line($"var response = Operations.CreateOrUpdate(Id.ResourceGroup, name, resourceDetails);");
                writer.Line($"return new PhArmResponse<{resourceContainer.ResourceDefaultName}, {resourceContainer.DataDefaultName}>(");
                writer.Line($"response,");
                writer.Line($"data => new {resourceContainer.ResourceDefaultName}(Parent, data));");
            }
        }

        private void WriteCreateOrUpdateAsync(CodeWriter writer, ResourceContainer resourceContainer)
        {
            //var containerId = Id as ResourceGroupResourceIdentifier;
            //var response = await Operations.CreateOrUpdateAsync(Id.ResourceGroupName, name, resourceDetails.Model, cancellationToken).ConfigureAwait(false);
            //return new PhArmResponse<AvailabilitySet, Azure.ResourceManager.Compute.Models.AvailabilitySet>(
            //    response,
            //    a => new AvailabilitySet(Parent, new AvailabilitySetData(a)));
            writer.Line();
            writer.WriteXmlDocumentationInheritDoc();
            using (writer.Scope($"public async override Task<ArmResponse<{resourceContainer.ResourceDefaultName}>> CreateOrUpdateAsync(string name, {resourceContainer.DataDefaultName} resourceDetails, {typeof(CancellationToken)} cancellationToken = default)"))
            {
                //writer.Line($"var response = Operations.CreateOrUpdate(Id.ResourceGroup, name, resourceDetails);");
                //writer.Line($"return new PhArmResponse<{resourceContainer.ResourceDefaultName}, {resourceContainer.DataDefaultName}>(");
                //writer.Line($"response,");
                //writer.Line($"data => new {resourceContainer.ResourceDefaultName}(Parent, data));");
                writer.Line($"throw new System.NotImplementedException();");
            }
        }

        private void WriteStartCreateOrUpdate(CodeWriter writer, ResourceContainer resourceContainer)
        {
            writer.Line();
            writer.WriteXmlDocumentationInheritDoc();
            using (writer.Scope($"public override ArmOperation<{resourceContainer.ResourceDefaultName}> StartCreateOrUpdate(string name, {resourceContainer.DataDefaultName} resourceDetails, {typeof(CancellationToken)} cancellationToken = default)"))
            {
                writer.Line($"throw new System.NotImplementedException();");
            }
        }

        private void WriteStartCreateOrUpdateAsync(CodeWriter writer, ResourceContainer resourceContainer)
        {
            writer.Line();
            writer.WriteXmlDocumentationInheritDoc();
            using (writer.Scope($"public async override Task<ArmOperation<{resourceContainer.ResourceDefaultName}>> StartCreateOrUpdateAsync(string name, {resourceContainer.DataDefaultName} resourceDetails, {typeof(CancellationToken)} cancellationToken = default)"))
            {
                writer.Line($"throw new System.NotImplementedException();");
            }
        }

        private void WriteGet(CodeWriter writer, ResourceContainer resourceContainer)
        {
            writer.Line();
            writer.WriteXmlDocumentationInheritDoc();
            using (writer.Scope($"public override ArmResponse<{resourceContainer.ResourceDefaultName}> Get(string resourceName, {typeof(CancellationToken)} cancellationToken = default)"))
            {
                writer.Line($"throw new System.NotImplementedException();");
            }
        }

        private void WriteGetAsync(CodeWriter writer, ResourceContainer resourceContainer)
        {
            writer.Line();
            writer.WriteXmlDocumentationInheritDoc();
            using (writer.Scope($"public async override Task<ArmResponse<{resourceContainer.ResourceDefaultName}>> GetAsync(string resourceName, {typeof(CancellationToken)} cancellationToken = default)"))
            {
                writer.Line($"throw new System.NotImplementedException();");
            }
        }

        private void WriteList(CodeWriter writer, ResourceContainer resourceContainer)
        {
            writer.Line();
            // todo: do not hard code resource type
            writer.WriteXmlDocumentationSummary($"Filters the list of {"availability set"} for this resource group. Makes an additional network call to retrieve the full data model for each resource group.");
            writer.WriteXmlDocumentationParameter("nameFilter", "The filter used in this operation.");
            writer.WriteXmlDocumentationParameter("top", "The number of results to return.");
            writer.WriteXmlDocumentationParameter("cancellationToken", "A token to allow the caller to cancel the call to the service. The default value is <see cref=\"P:System.Threading.CancellationToken.None\" />.");
            // todo: do not hard code resource type
            writer.WriteXmlDocumentation("returns", $"A collection of {"availability set"} that may take multiple service requests to iterate over.");
            using (writer.Scope($"public Pageable<{resourceContainer.ResourceDefaultName}> List(string nameFilter, int? top = null, {typeof(CancellationToken)} cancellationToken = default)"))
            {
                writer.Line($"throw new System.NotImplementedException();");
            }
        }

        private void WriteListAsync(CodeWriter writer, ResourceContainer resourceContainer)
        {
            writer.Line();
            // todo: do not hard code resource type
            writer.WriteXmlDocumentationSummary($"Filters the list of {"availability set"} for this resource group. Makes an additional network call to retrieve the full data model for each resource group.");
            writer.WriteXmlDocumentationParameter("nameFilter", "The filter used in this operation.");
            writer.WriteXmlDocumentationParameter("top", "The number of results to return.");
            writer.WriteXmlDocumentationParameter("cancellationToken", "A token to allow the caller to cancel the call to the service. The default value is <see cref=\"P:System.Threading.CancellationToken.None\" />.");
            // todo: do not hard code resource type
            writer.WriteXmlDocumentation("returns", $"An async collection of {"availability set"} that may take multiple service requests to iterate over.");
            using (writer.Scope($"public AsyncPageable<{resourceContainer.ResourceDefaultName}> ListAsync(string nameFilter, int? top = null, {typeof(CancellationToken)} cancellationToken = default)"))
            {
                writer.Line($"throw new System.NotImplementedException();");
            }
        }

        private void WriteListAsGenericResource(CodeWriter writer, ResourceContainer resourceContainer)
        {
            writer.Line();
            // todo: do not hard code resource type
            writer.WriteXmlDocumentationSummary($"Filters the list of {"availability set"} for this resource group represented as generic resources.");
            writer.WriteXmlDocumentationParameter("nameFilter", "The filter used in this operation.");
            writer.WriteXmlDocumentationParameter("top", "The number of results to return.");
            writer.WriteXmlDocumentationParameter("cancellationToken", "A token to allow the caller to cancel the call to the service. The default value is <see cref=\"P:System.Threading.CancellationToken.None\" />.");
            writer.WriteXmlDocumentation("returns", $"A collection of resource that may take multiple service requests to iterate over.");
            using (writer.Scope($"public Pageable<GenericResource> ListAsGenericResource(string nameFilter, int? top = null, {typeof(CancellationToken)} cancellationToken = default)"))
            {
                writer.Line($"throw new System.NotImplementedException();");
            }
        }

        private void WriteListAsGenericResourceAsync(CodeWriter writer, ResourceContainer resourceContainer)
        {
            writer.Line();
            // todo: do not hard code resource type
            writer.WriteXmlDocumentationSummary($"Filters the list of {"availability set"} for this resource group represented as generic resources.");
            writer.WriteXmlDocumentationParameter("nameFilter", "The filter used in this operation.");
            writer.WriteXmlDocumentationParameter("top", "The number of results to return.");
            writer.WriteXmlDocumentationParameter("cancellationToken", "A token to allow the caller to cancel the call to the service. The default value is <see cref=\"P:System.Threading.CancellationToken.None\" />.");
            writer.WriteXmlDocumentation("returns", $"An async collection of resource that may take multiple service requests to iterate over.");
            using (writer.Scope($"public AsyncPageable<GenericResource> ListAsGenericResourceAsync(string nameFilter, int? top = null, {typeof(CancellationToken)} cancellationToken = default)"))
            {
                writer.Line($"throw new System.NotImplementedException();");
            }
        }

        private void WriteBuilders(CodeWriter writer, ResourceContainer resourceContainer)
        {
            writer.Line();
            writer.LineRaw($"// Builders.");
            // todo: do not hard code ResourceGroupResourceIdentifier
            using (writer.Scope($"public ArmBuilder<ResourceGroupResourceIdentifier, {resourceContainer.ResourceDefaultName}, {resourceContainer.DataDefaultName}> Construct()"))
            {
                writer.Line($"throw new System.NotImplementedException();");
            }
        }
    }
}

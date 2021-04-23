// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoRest.CSharp.Input;
using AutoRest.CSharp.Mgmt.AutoRest;
using AutoRest.CSharp.Mgmt.Decorator;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models;
using AutoRest.CSharp.Output.Models.Requests;
using AutoRest.CSharp.Output.Models.Types;
using Azure.Core;
using Azure.ResourceManager.Core;

namespace AutoRest.CSharp.Mgmt.Output
{
    internal class ResourceContainer : ResourceOperation
    {
        private const string _suffixValue = "Container";
        private BuildContext<MgmtOutputLibrary> _context;
        private const string ResourceGroupOperationsResourceType = "ResourceGroupOperations.ResourceType";
        private const string SubscriptionOperationsResourceType = "SubscriptionOperations.ResourceType";
        private const string TenantResourceType = "ResourceIdentifier.RootResourceIdentifier.ResourceType";
        private Dictionary<ResourceContainerMethods, ResourceContainerMethod>? _methods;

        public ResourceContainer(OperationGroup operationGroup, BuildContext<MgmtOutputLibrary> context)
            : base(operationGroup, context)
        {
            _operationGroup = operationGroup;
            _context = context;
        }

        protected override string SuffixValue => _suffixValue;

        protected override string CreateDescription(OperationGroup operationGroup, string clientPrefix)
        {
            StringBuilder summary = new StringBuilder();
            return string.IsNullOrWhiteSpace(operationGroup.Language.Default.Description) ?
                $"A class representing collection of {clientPrefix} and their operations over a [ParentResource]. " :
                BuilderHelpers.EscapeXmlDescription(operationGroup.Language.Default.Description);
        }

        public string GetValidResourceValue()
        {
            var parentResourceType = OperationGroup.ParentResourceType(_context.Configuration.MgmtConfiguration);

            switch (parentResourceType)
            {
                case ResourceTypeBuilder.ResourceGroups:
                    return ResourceGroupOperationsResourceType;
                case ResourceTypeBuilder.Subscriptions:
                    return SubscriptionOperationsResourceType;
                case ResourceTypeBuilder.Tenant:
                    return TenantResourceType;
                default:
                    return FindParentFromRp(parentResourceType);
            }
        }

        private string FindParentFromRp(string parentResourceType)
        {
            OperationGroup? parentOperationGroup = null;
            foreach (var operationGroup in _context.CodeModel.OperationGroups)
            {
                if (operationGroup.ResourceType(_context.Configuration.MgmtConfiguration).Equals(parentResourceType))
                {
                    parentOperationGroup = operationGroup;
                    break;
                }
            }

            if (parentOperationGroup is null)
                return parentResourceType;
            // TODO: Throw the below exception after https://dev.azure.com/azure-mgmt-ex/DotNET%20Management%20SDK/_workitems/edit/5800
            // throw new Exception($"Could not find ResourceType for {parentResourceType}. Please update the swagger");

            var parentOperations = _context.Library.GetResourceOperation(parentOperationGroup);
            return $"{parentOperations.Declaration.Name}.ResourceType";
        }

        public ResourceContainerMethod GetMethod(ResourceContainerMethods name) => EnsureContainerMethods()[name];

        private Dictionary<ResourceContainerMethods, ResourceContainerMethod> EnsureContainerMethods()
        {
            if (_methods != null)
            {
                return _methods;
            }
            _methods = new Dictionary<ResourceContainerMethods, ResourceContainerMethod>();


            // To generate resource operations, we need to find out the correct REST client methods to call.
            // We must look for CreateOrUpdate by HTTP method because it may be named differently from `CreateOrUpdate`.
            var restClientMethod = FindRestClientMethodByHttpMethod(RequestMethod.Put);
            _methods[ResourceContainerMethods.CreateOrUpdate] = new ResourceContainerMethod("createOrUpdate", restClientMethod, null, new Diagnostic($"{Type.Name}.{"createOrUpdate"}"), "public", true);
            return _methods;
        }

        private RestClientMethod FindRestClientMethodByHttpMethod(RequestMethod httpMethod) => RestClient.Methods.FirstOrDefault(m => m.Request.HttpMethod.Equals(httpMethod));

        private RestClientMethod FindRestClientMethodByName(IEnumerable<string> nameOptions) => RestClient.Methods.FirstOrDefault(method => nameOptions.Any(option => string.Equals(method.Name, option, StringComparison.InvariantCultureIgnoreCase)));
    }

    /// <summary>
    /// Represents a method inside a ResourceContainer class.
    /// </summary>
    internal class ResourceContainerMethod
    {
        public ResourceContainerMethod(string name, RestClientMethod? restClientMethod, string? description, Diagnostic diagnostics, string accessibility, bool isOverride)
        {
            Name = name;
            RestClientMethod = restClientMethod;
            Description = description;
            Diagnostics = diagnostics;
            Accessibility = accessibility;
            IsOverride = isOverride;
        }

        public string Name { get; }
        public RestClientMethod? RestClientMethod { get; }
        public string? Description { get; }
        public Diagnostic Diagnostics { get; }
        public string Accessibility { get; }
        public bool IsOverride { get; }
    }

    internal enum ResourceContainerMethods
    {
        CreateOrUpdate
    }
}

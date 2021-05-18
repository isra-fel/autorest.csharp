// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Core.Resources;

namespace Azure.ResourceManager.Sample
{
    /// <summary> A class representing collection of DedicatedHostGroup and their operations over a ResourceGroup. </summary>
    public partial class DedicatedHostGroupContainer : ResourceContainerBase<ResourceGroupResourceIdentifier, DedicatedHostGroup, DedicatedHostGroupData>
    {
        /// <summary> Initializes a new instance of the <see cref="DedicatedHostGroupContainer"/> class for mocking. </summary>
        protected DedicatedHostGroupContainer()
        {
        }

        /// <summary> Initializes a new instance of DedicatedHostGroupContainer class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal DedicatedHostGroupContainer(ResourceOperationsBase parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _pipeline = ManagementPipelineBuilder.Build(Credential, BaseUri, ClientOptions);
        }

        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;

        /// <summary> Represents the REST operations. </summary>
        private DedicatedHostGroupsRestOperations _restClient => new DedicatedHostGroupsRestOperations(_clientDiagnostics, _pipeline, Id.SubscriptionId);

        /// <summary> Typed Resource Identifier for the container. </summary>
        public new ResourceGroupResourceIdentifier Id => base.Id as ResourceGroupResourceIdentifier;

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => ResourceGroupOperations.ResourceType;

        // Container level operations.

        /// <summary> The operation to create or update a DedicatedHostGroup. Please note some properties can be set only during creation. </summary>
        /// <param name="hostGroupName"> The name of the dedicated host group. </param>
        /// <param name="parameters"> Parameters supplied to the Create Dedicated Host Group. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public Response<DedicatedHostGroup> CreateOrUpdate(string hostGroupName, DedicatedHostGroupData parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DedicatedHostGroupContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                if (hostGroupName == null)
                {
                    throw new ArgumentNullException(nameof(hostGroupName));
                }
                if (parameters == null)
                {
                    throw new ArgumentNullException(nameof(parameters));
                }

                return StartCreateOrUpdate(hostGroupName, parameters, cancellationToken: cancellationToken).WaitForCompletion();
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> The operation to create or update a DedicatedHostGroup. Please note some properties can be set only during creation. </summary>
        /// <param name="hostGroupName"> The name of the dedicated host group. </param>
        /// <param name="parameters"> Parameters supplied to the Create Dedicated Host Group. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public async Task<Response<DedicatedHostGroup>> CreateOrUpdateAsync(string hostGroupName, DedicatedHostGroupData parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DedicatedHostGroupContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                if (hostGroupName == null)
                {
                    throw new ArgumentNullException(nameof(hostGroupName));
                }
                if (parameters == null)
                {
                    throw new ArgumentNullException(nameof(parameters));
                }

                var operation = await StartCreateOrUpdateAsync(hostGroupName, parameters, cancellationToken: cancellationToken).ConfigureAwait(false);
                return await operation.WaitForCompletionAsync().ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> The operation to create or update a DedicatedHostGroup. Please note some properties can be set only during creation. </summary>
        /// <param name="hostGroupName"> The name of the dedicated host group. </param>
        /// <param name="parameters"> Parameters supplied to the Create Dedicated Host Group. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public DedicatedHostGroupsCreateOrUpdateOperation StartCreateOrUpdate(string hostGroupName, DedicatedHostGroupData parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DedicatedHostGroupContainer.StartCreateOrUpdate");
            scope.Start();
            try
            {
                if (hostGroupName == null)
                {
                    throw new ArgumentNullException(nameof(hostGroupName));
                }
                if (parameters == null)
                {
                    throw new ArgumentNullException(nameof(parameters));
                }

                var originalResponse = _restClient.CreateOrUpdate(Id.ResourceGroupName, hostGroupName, parameters, cancellationToken: cancellationToken);
                return new DedicatedHostGroupsCreateOrUpdateOperation(Parent, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> The operation to create or update a DedicatedHostGroup. Please note some properties can be set only during creation. </summary>
        /// <param name="hostGroupName"> The name of the dedicated host group. </param>
        /// <param name="parameters"> Parameters supplied to the Create Dedicated Host Group. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public async Task<DedicatedHostGroupsCreateOrUpdateOperation> StartCreateOrUpdateAsync(string hostGroupName, DedicatedHostGroupData parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DedicatedHostGroupContainer.StartCreateOrUpdate");
            scope.Start();
            try
            {
                if (hostGroupName == null)
                {
                    throw new ArgumentNullException(nameof(hostGroupName));
                }
                if (parameters == null)
                {
                    throw new ArgumentNullException(nameof(parameters));
                }

                var originalResponse = await _restClient.CreateOrUpdateAsync(Id.ResourceGroupName, hostGroupName, parameters, cancellationToken: cancellationToken).ConfigureAwait(false);
                return new DedicatedHostGroupsCreateOrUpdateOperation(Parent, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        /// <param name="hostGroupName"> The name of the dedicated host group. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public override Response<DedicatedHostGroup> Get(string hostGroupName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DedicatedHostGroupContainer.Get");
            scope.Start();
            try
            {
                if (hostGroupName == null)
                {
                    throw new ArgumentNullException(nameof(hostGroupName));
                }

                var response = _restClient.Get(Id.ResourceGroupName, hostGroupName, cancellationToken: cancellationToken);
                return Response.FromValue(new DedicatedHostGroup(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        /// <param name="hostGroupName"> The name of the dedicated host group. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public async override Task<Response<DedicatedHostGroup>> GetAsync(string hostGroupName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DedicatedHostGroupContainer.Get");
            scope.Start();
            try
            {
                if (hostGroupName == null)
                {
                    throw new ArgumentNullException(nameof(hostGroupName));
                }

                var response = await _restClient.GetAsync(Id.ResourceGroupName, hostGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new DedicatedHostGroup(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="DedicatedHostGroup" /> for this resource group. </summary>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of <see cref="DedicatedHostGroup" /> that may take multiple service requests to iterate over. </returns>
        public Pageable<DedicatedHostGroup> List(int? top = null, CancellationToken cancellationToken = default)
        {
            Page<DedicatedHostGroup> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("DedicatedHostGroupContainer.ListByResourceGroup");
                scope.Start();
                try
                {
                    var response = _restClient.ListByResourceGroup(Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new DedicatedHostGroup(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<DedicatedHostGroup> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("DedicatedHostGroupContainer.ListByResourceGroup");
                scope.Start();
                try
                {
                    var response = _restClient.ListByResourceGroupNextPage(nextLink, Id.ResourceGroupName, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new DedicatedHostGroup(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Filters the list of <see cref="DedicatedHostGroup" /> for this resource group. Makes an additional network call to retrieve the full data model for each resource group. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of <see cref="DedicatedHostGroup" /> that may take multiple service requests to iterate over. </returns>
        public Pageable<DedicatedHostGroup> List(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            var results = ListAsGenericResource(null, top, cancellationToken);
            return new PhWrappingPageable<GenericResource, DedicatedHostGroup>(results, genericResource => new DedicatedHostGroupOperations(genericResource, genericResource.Id as ResourceGroupResourceIdentifier).Get().Value);
        }

        /// <summary> Filters the list of <see cref="DedicatedHostGroup" /> for this resource group. </summary>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of <see cref="DedicatedHostGroup" /> that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<DedicatedHostGroup> ListAsync(int? top = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<DedicatedHostGroup>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("DedicatedHostGroupContainer.ListByResourceGroup");
                scope.Start();
                try
                {
                    var response = await _restClient.ListByResourceGroupAsync(Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new DedicatedHostGroup(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<DedicatedHostGroup>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("DedicatedHostGroupContainer.ListByResourceGroup");
                scope.Start();
                try
                {
                    var response = await _restClient.ListByResourceGroupNextPageAsync(nextLink, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new DedicatedHostGroup(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary> Filters the list of <see cref="DedicatedHostGroup" /> for this resource group. Makes an additional network call to retrieve the full data model for each resource group. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of <see cref="DedicatedHostGroup" /> that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<DedicatedHostGroup> ListAsync(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            var results = ListAsGenericResourceAsync(null, top, cancellationToken);
            return new PhWrappingAsyncPageable<GenericResource, DedicatedHostGroup>(results, genericResource => new DedicatedHostGroupOperations(genericResource, genericResource.Id as ResourceGroupResourceIdentifier).Get().Value);
        }

        /// <summary> Filters the list of DedicatedHostGroup for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public Pageable<GenericResource> ListAsGenericResource(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DedicatedHostGroupContainer.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(DedicatedHostGroupOperations.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.ListAtContext(Parent as ResourceGroupOperations, filters, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of DedicatedHostGroup for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<GenericResource> ListAsGenericResourceAsync(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DedicatedHostGroupContainer.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(DedicatedHostGroupOperations.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.ListAtContextAsync(Parent as ResourceGroupOperations, filters, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // Builders.
        // public ArmBuilder<ResourceGroupResourceIdentifier, DedicatedHostGroup, DedicatedHostGroupData> Construct() { }
    }
}

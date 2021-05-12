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
    /// <summary> A class representing collection of DedicatedHost and their operations over a DedicatedHostGroup. </summary>
    public partial class DedicatedHostContainer : ResourceContainerBase<ResourceGroupResourceIdentifier, DedicatedHost, DedicatedHostData>
    {
        /// <summary> Initializes a new instance of the <see cref="DedicatedHostContainer"/> class for mocking. </summary>
        protected DedicatedHostContainer()
        {
        }

        /// <summary> Initializes a new instance of DedicatedHostContainer class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal DedicatedHostContainer(ResourceOperationsBase parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _pipeline = ManagementPipelineBuilder.Build(Credential, BaseUri, ClientOptions);
        }

        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;

        /// <summary> Represents the REST operations. </summary>
        private DedicatedHostsRestOperations _restClient => new DedicatedHostsRestOperations(_clientDiagnostics, _pipeline, Id.SubscriptionId);

        /// <summary> Typed Resource Identifier for the container. </summary>
        public new ResourceGroupResourceIdentifier Id => base.Id as ResourceGroupResourceIdentifier;

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => DedicatedHostGroupOperations.ResourceType;

        // Container level operations.

        /// <inheritdoc />
        /// <param name="hostName"> The name of the dedicated host . </param>
        /// <param name="parameters"> Parameters supplied to the Create Dedicated Host. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public Response<DedicatedHost> CreateOrUpdate(string hostName, DedicatedHostData parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DedicatedHostContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                if (hostName == null)
                {
                    throw new ArgumentNullException(nameof(hostName));
                }
                if (parameters == null)
                {
                    throw new ArgumentNullException(nameof(parameters));
                }

                return StartCreateOrUpdate(hostName, parameters, cancellationToken: cancellationToken).WaitForCompletion() as Response<DedicatedHost>;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        /// <param name="hostName"> The name of the dedicated host . </param>
        /// <param name="parameters"> Parameters supplied to the Create Dedicated Host. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public async Task<Response<DedicatedHost>> CreateOrUpdateAsync(string hostName, DedicatedHostData parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DedicatedHostContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                if (hostName == null)
                {
                    throw new ArgumentNullException(nameof(hostName));
                }
                if (parameters == null)
                {
                    throw new ArgumentNullException(nameof(parameters));
                }

                var operation = await StartCreateOrUpdateAsync(hostName, parameters, cancellationToken: cancellationToken).ConfigureAwait(false);
                return operation.WaitForCompletion() as Response<DedicatedHost>;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        /// <param name="hostName"> The name of the dedicated host . </param>
        /// <param name="parameters"> Parameters supplied to the Create Dedicated Host. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public Operation<DedicatedHost> StartCreateOrUpdate(string hostName, DedicatedHostData parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DedicatedHostContainer.StartCreateOrUpdate");
            scope.Start();
            try
            {
                if (hostName == null)
                {
                    throw new ArgumentNullException(nameof(hostName));
                }
                if (parameters == null)
                {
                    throw new ArgumentNullException(nameof(parameters));
                }

                var originalResponse = _restClient.CreateOrUpdate(Id.ResourceGroupName, Id.Parent.Name, hostName, parameters, cancellationToken: cancellationToken);
                var operation = new DedicatedHostCreateOrUpdateOperation(
                _clientDiagnostics, _pipeline, _restClient.CreateCreateOrUpdateRequest(
                Id.ResourceGroupName, Id.Parent.Name, hostName, parameters).Request,
                originalResponse);
                return new PhArmOperation<DedicatedHost, DedicatedHostData>(
                operation,
                data => new DedicatedHost(Parent, data));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        /// <param name="hostName"> The name of the dedicated host . </param>
        /// <param name="parameters"> Parameters supplied to the Create Dedicated Host. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public async Task<Operation<DedicatedHost>> StartCreateOrUpdateAsync(string hostName, DedicatedHostData parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DedicatedHostContainer.StartCreateOrUpdate");
            scope.Start();
            try
            {
                if (hostName == null)
                {
                    throw new ArgumentNullException(nameof(hostName));
                }
                if (parameters == null)
                {
                    throw new ArgumentNullException(nameof(parameters));
                }

                var originalResponse = await _restClient.CreateOrUpdateAsync(Id.ResourceGroupName, Id.Parent.Name, hostName, parameters, cancellationToken: cancellationToken).ConfigureAwait(false);
                var operation = new DedicatedHostCreateOrUpdateOperation(
                _clientDiagnostics, _pipeline, _restClient.CreateCreateOrUpdateRequest(
                Id.ResourceGroupName, Id.Parent.Name, hostName, parameters).Request,
                originalResponse);
                return new PhArmOperation<DedicatedHost, DedicatedHostData>(
                operation,
                data => new DedicatedHost(Parent, data));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        /// <param name="hostName"> The name of the dedicated host. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public override Response<DedicatedHost> Get(string hostName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DedicatedHostContainer.Get");
            scope.Start();
            try
            {
                if (hostName == null)
                {
                    throw new ArgumentNullException(nameof(hostName));
                }

                var response = _restClient.Get(Id.ResourceGroupName, Id.Parent.Name, hostName, cancellationToken: cancellationToken);
                return Response.FromValue(new DedicatedHost(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        /// <param name="hostName"> The name of the dedicated host. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public async override Task<Response<DedicatedHost>> GetAsync(string hostName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DedicatedHostContainer.Get");
            scope.Start();
            try
            {
                if (hostName == null)
                {
                    throw new ArgumentNullException(nameof(hostName));
                }

                var response = await _restClient.GetAsync(Id.ResourceGroupName, Id.Parent.Name, hostName, cancellationToken: cancellationToken);
                return Response.FromValue(new DedicatedHost(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of DedicatedHost for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public Pageable<GenericResource> ListAsGenericResource(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DedicatedHostContainer.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(DedicatedHostOperations.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.ListAtContext(Parent as ResourceGroupOperations, filters, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of DedicatedHost for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<GenericResource> ListAsGenericResourceAsync(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("DedicatedHostContainer.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(DedicatedHostOperations.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.ListAtContextAsync(Parent as ResourceGroupOperations, filters, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="DedicatedHost" /> for this resource group. Makes an additional network call to retrieve the full data model for each resource group. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of <see cref="DedicatedHost" /> that may take multiple service requests to iterate over. </returns>
        public Pageable<DedicatedHost> List(string nameFilter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(nameFilter))
            {
                Page<DedicatedHost> FirstPageFunc(int? pageSizeHint)
                {
                    using var scope = _clientDiagnostics.CreateScope("DedicatedHostContainer.ListByHostGroup");
                    scope.Start();
                    try
                    {
                        var response = _restClient.ListByHostGroup(Id.ResourceGroupName, Id.Parent.Name, cancellationToken: cancellationToken);
                        return Page.FromValues(response.Value.Value.Select(value => new DedicatedHost(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                    }
                    catch (Exception e)
                    {
                        scope.Failed(e);
                        throw;
                    }
                }
                Page<DedicatedHost> NextPageFunc(string nextLink, int? pageSizeHint)
                {
                    using var scope = _clientDiagnostics.CreateScope("DedicatedHostContainer.ListByHostGroup");
                    scope.Start();
                    try
                    {
                        var response = _restClient.ListByHostGroupNextPage(nextLink, Id.ResourceGroupName, Id.Parent.Name, cancellationToken: cancellationToken);
                        return Page.FromValues(response.Value.Value.Select(value => new DedicatedHost(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                    }
                    catch (Exception e)
                    {
                        scope.Failed(e);
                        throw;
                    }
                }
                return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
            }
            else
            {
                var results = ListAsGenericResource(nameFilter, top, cancellationToken);
                return new PhWrappingPageable<GenericResource, DedicatedHost>(results, genericResource => new DedicatedHostOperations(genericResource).Get().Value);
            }
        }

        /// <summary> Filters the list of <see cref="DedicatedHost" /> for this resource group. Makes an additional network call to retrieve the full data model for each resource group. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of <see cref="DedicatedHost" /> that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<DedicatedHost> ListAsync(string nameFilter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(nameFilter))
            {
                async Task<Page<DedicatedHost>> FirstPageFunc(int? pageSizeHint)
                {
                    using var scope = _clientDiagnostics.CreateScope("DedicatedHostContainer.ListByHostGroup");
                    scope.Start();
                    try
                    {
                        var response = await _restClient.ListByHostGroupAsync(Id.ResourceGroupName, Id.Parent.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                        return Page.FromValues(response.Value.Value.Select(value => new DedicatedHost(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                    }
                    catch (Exception e)
                    {
                        scope.Failed(e);
                        throw;
                    }
                }
                async Task<Page<DedicatedHost>> NextPageFunc(string nextLink, int? pageSizeHint)
                {
                    using var scope = _clientDiagnostics.CreateScope("DedicatedHostContainer.ListByHostGroup");
                    scope.Start();
                    try
                    {
                        var response = await _restClient.ListByHostGroupNextPageAsync(nextLink, Id.ResourceGroupName, Id.Parent.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                        return Page.FromValues(response.Value.Value.Select(value => new DedicatedHost(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                    }
                    catch (Exception e)
                    {
                        scope.Failed(e);
                        throw;
                    }
                }
                return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
            }
            else
            {
                var results = ListAsGenericResourceAsync(nameFilter, top, cancellationToken);
                return new PhWrappingAsyncPageable<GenericResource, DedicatedHost>(results, genericResource => new DedicatedHostOperations(genericResource).Get().Value);
            }
        }

        // Builders.
        // public ArmBuilder<ResourceGroupResourceIdentifier, DedicatedHost, DedicatedHostData> Construct() { }
    }
}

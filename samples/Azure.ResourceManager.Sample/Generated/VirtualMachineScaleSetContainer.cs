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
    /// <summary> A class representing collection of VirtualMachineScaleSet and their operations over a ResourceGroup. </summary>
    public partial class VirtualMachineScaleSetContainer : ResourceContainerBase<TenantResourceIdentifier, VirtualMachineScaleSet, VirtualMachineScaleSetData>
    {
        /// <summary> Initializes a new instance of the <see cref="VirtualMachineScaleSetContainer"/> class for mocking. </summary>
        protected VirtualMachineScaleSetContainer()
        {
        }

        /// <summary> Initializes a new instance of VirtualMachineScaleSetContainer class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal VirtualMachineScaleSetContainer(ResourceOperationsBase parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _pipeline = ManagementPipelineBuilder.Build(Credential, BaseUri, ClientOptions);
        }

        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;

        /// <summary> Represents the REST operations. </summary>
        private VirtualMachineScaleSetsRestOperations _restClient => new VirtualMachineScaleSetsRestOperations(_clientDiagnostics, _pipeline, Id.SubscriptionId);

        /// <summary> Typed Resource Identifier for the container. </summary>
        // todo: hard coding ResourceGroupResourceIdentifier we don't know the exact ID type but we need it in implementations in CreateOrUpdate() etc.
        public new ResourceGroupResourceIdentifier Id => base.Id as ResourceGroupResourceIdentifier;
        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => ResourceGroupOperations.ResourceType;

        // Container level operations.

        /// <inheritdoc />
        /// <param name="vmScaleSetName"> The name of the VM scale set to create or update. </param>
        /// <param name="parameters"> The scale set object. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public ArmResponse<VirtualMachineScaleSet> CreateOrUpdate(string vmScaleSetName, VirtualMachineScaleSetData parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("VirtualMachineScaleSetContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                if (vmScaleSetName == null)
                {
                    throw new ArgumentNullException(nameof(vmScaleSetName));
                }
                if (parameters == null)
                {
                    throw new ArgumentNullException(nameof(parameters));
                }

                return StartCreateOrUpdate(vmScaleSetName, parameters, cancellationToken: cancellationToken).WaitForCompletion() as ArmResponse<VirtualMachineScaleSet>;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        /// <param name="vmScaleSetName"> The name of the VM scale set to create or update. </param>
        /// <param name="parameters"> The scale set object. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public async Task<ArmResponse<VirtualMachineScaleSet>> CreateOrUpdateAsync(string vmScaleSetName, VirtualMachineScaleSetData parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("VirtualMachineScaleSetContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                if (vmScaleSetName == null)
                {
                    throw new ArgumentNullException(nameof(vmScaleSetName));
                }
                if (parameters == null)
                {
                    throw new ArgumentNullException(nameof(parameters));
                }

                var operation = await StartCreateOrUpdateAsync(vmScaleSetName, parameters, cancellationToken: cancellationToken).ConfigureAwait(false);
                return operation.WaitForCompletion() as ArmResponse<VirtualMachineScaleSet>;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        /// <param name="vmScaleSetName"> The name of the VM scale set to create or update. </param>
        /// <param name="parameters"> The scale set object. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public ArmOperation<VirtualMachineScaleSet> StartCreateOrUpdate(string vmScaleSetName, VirtualMachineScaleSetData parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("VirtualMachineScaleSetContainer.StartCreateOrUpdate");
            scope.Start();
            try
            {
                if (vmScaleSetName == null)
                {
                    throw new ArgumentNullException(nameof(vmScaleSetName));
                }
                if (parameters == null)
                {
                    throw new ArgumentNullException(nameof(parameters));
                }

                var originalResponse = _restClient.CreateOrUpdate(Id.ResourceGroupName, vmScaleSetName, parameters, cancellationToken: cancellationToken);
                var operation = new VirtualMachineScaleSetCreateOrUpdateOperation(
                _clientDiagnostics, _pipeline, _restClient.CreateCreateOrUpdateRequest(
                Id.ResourceGroupName, vmScaleSetName, parameters).Request,
                originalResponse);
                return new PhArmOperation<VirtualMachineScaleSet, VirtualMachineScaleSetData>(
                operation,
                data => new VirtualMachineScaleSet(Parent, data));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        /// <param name="vmScaleSetName"> The name of the VM scale set to create or update. </param>
        /// <param name="parameters"> The scale set object. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public async Task<ArmOperation<VirtualMachineScaleSet>> StartCreateOrUpdateAsync(string vmScaleSetName, VirtualMachineScaleSetData parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("VirtualMachineScaleSetContainer.StartCreateOrUpdate");
            scope.Start();
            try
            {
                if (vmScaleSetName == null)
                {
                    throw new ArgumentNullException(nameof(vmScaleSetName));
                }
                if (parameters == null)
                {
                    throw new ArgumentNullException(nameof(parameters));
                }

                var originalResponse = await _restClient.CreateOrUpdateAsync(Id.ResourceGroupName, vmScaleSetName, parameters, cancellationToken: cancellationToken).ConfigureAwait(false);
                var operation = new VirtualMachineScaleSetCreateOrUpdateOperation(
                _clientDiagnostics, _pipeline, _restClient.CreateCreateOrUpdateRequest(
                Id.ResourceGroupName, vmScaleSetName, parameters).Request,
                originalResponse);
                return new PhArmOperation<VirtualMachineScaleSet, VirtualMachineScaleSetData>(
                operation,
                data => new VirtualMachineScaleSet(Parent, data));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        /// <param name="vmScaleSetName"> The name of the VM scale set. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public override ArmResponse<VirtualMachineScaleSet> Get(string vmScaleSetName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("VirtualMachineScaleSetContainer.Get");
            scope.Start();
            try
            {
                if (vmScaleSetName == null)
                {
                    throw new ArgumentNullException(nameof(vmScaleSetName));
                }

                var response = _restClient.Get(Id.ResourceGroupName, vmScaleSetName, cancellationToken: cancellationToken);
                return ArmResponse.FromValue(new VirtualMachineScaleSet(Parent, response.Value), ArmResponse.FromResponse(response.GetRawResponse()));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        /// <param name="vmScaleSetName"> The name of the VM scale set. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public async override Task<ArmResponse<VirtualMachineScaleSet>> GetAsync(string vmScaleSetName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("VirtualMachineScaleSetContainer.Get");
            scope.Start();
            try
            {
                if (vmScaleSetName == null)
                {
                    throw new ArgumentNullException(nameof(vmScaleSetName));
                }

                var response = await _restClient.GetAsync(Id.ResourceGroupName, vmScaleSetName, cancellationToken: cancellationToken);
                return ArmResponse.FromValue(new VirtualMachineScaleSet(Parent, response.Value), ArmResponse.FromResponse(response.GetRawResponse()));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of VirtualMachineScaleSet for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public Pageable<GenericResource> ListAsGenericResource(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("VirtualMachineScaleSetContainer.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(VirtualMachineScaleSetOperations.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.ListAtContext(Parent as ResourceGroupOperations, filters, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of VirtualMachineScaleSet for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<GenericResource> ListAsGenericResourceAsync(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("VirtualMachineScaleSetContainer.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(VirtualMachineScaleSetOperations.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.ListAtContextAsync(Parent as ResourceGroupOperations, filters, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        // have LIST paging method: List

        /// <summary> Filters the list of <see cref="VirtualMachineScaleSet" /> for this resource group. Makes an additional network call to retrieve the full data model for each resource group. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of <see cref="VirtualMachineScaleSet" /> that may take multiple service requests to iterate over. </returns>
        public Pageable<VirtualMachineScaleSet> List(string nameFilter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(nameFilter))
            {
                Page<VirtualMachineScaleSet> FirstPageFunc(int? pageSizeHint)
                {
                    using var scope = _clientDiagnostics.CreateScope("VirtualMachineScaleSetContainer.List");
                    scope.Start();
                    try
                    {
                        var response = _restClient.List(Id.ResourceGroupName, cancellationToken: cancellationToken);
                        return Page.FromValues(response.Value.Value.Select(value => new VirtualMachineScaleSet(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                    }
                    catch (Exception e)
                    {
                        scope.Failed(e);
                        throw;
                    }
                }
                Page<VirtualMachineScaleSet> NextPageFunc(string nextLink, int? pageSizeHint)
                {
                    using var scope = _clientDiagnostics.CreateScope("VirtualMachineScaleSetContainer.List");
                    scope.Start();
                    try
                    {
                        var response = _restClient.ListNextPage(nextLink, Id.ResourceGroupName, cancellationToken: cancellationToken);
                        return Page.FromValues(response.Value.Value.Select(value => new VirtualMachineScaleSet(Parent, value)), response.Value.NextLink, response.GetRawResponse());
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
                return new PhWrappingPageable<GenericResource, VirtualMachineScaleSet>(results, genericResource => new VirtualMachineScaleSetOperations(genericResource).Get().Value);
            }
        }

        /// <summary> Filters the list of <see cref="VirtualMachineScaleSet" /> for this resource group. Makes an additional network call to retrieve the full data model for each resource group. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of <see cref="VirtualMachineScaleSet" /> that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<VirtualMachineScaleSet> ListAsync(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("VirtualMachineScaleSetContainer.List");
            scope.Start();
            try
            {
                var results = ListAsGenericResourceAsync(nameFilter, top, cancellationToken);
                return new PhWrappingAsyncPageable<GenericResource, VirtualMachineScaleSet>(results, genericResource => new VirtualMachineScaleSetOperations(genericResource).Get().Value);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // Builders.
        // public ArmBuilder<TenantResourceIdentifier, VirtualMachineScaleSet, VirtualMachineScaleSetData> Construct() { }
    }
}

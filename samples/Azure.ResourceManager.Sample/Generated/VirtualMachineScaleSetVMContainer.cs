// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Core.Resources;

namespace Azure.ResourceManager.Sample
{
    /// <summary> A class representing collection of VirtualMachineScaleSetVM and their operations over a [ParentResource]. </summary>
    public partial class VirtualMachineScaleSetVMContainer : ResourceContainerBase<TenantResourceIdentifier, VirtualMachineScaleSetVM, VirtualMachineScaleSetVMData>
    {
        /// <summary> Initializes a new instance of VirtualMachineScaleSetVMContainer class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal VirtualMachineScaleSetVMContainer(ResourceOperationsBase parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _pipeline = new HttpPipeline(ClientOptions.Transport);
        }

        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;

        /// <summary> Represents the REST operations. </summary>
        private VirtualMachineScaleSetVMsRestOperations Operations => new VirtualMachineScaleSetVMsRestOperations(_clientDiagnostics, _pipeline, Id.SubscriptionId);

        /// <summary> Typed Resource Identifier for the container. </summary>
        // todo: hard coding ResourceGroupResourceIdentifier we don't know the exact ID type but we need it in implementations in CreateOrUpdate() etc.
        public new ResourceGroupResourceIdentifier Id => base.Id as ResourceGroupResourceIdentifier;
        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => VirtualMachineScaleSetOperations.ResourceType;

        // Container level operations.

        /// <inheritdoc />
        /// <param name="instanceId"> The instance ID of the virtual machine. </param>
        /// <param name="parameters"> Parameters supplied to the Update Virtual Machine Scale Sets VM operation. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public override ArmResponse<VirtualMachineScaleSetVM> CreateOrUpdate(string instanceId, VirtualMachineScaleSetVMData parameters, CancellationToken cancellationToken = default)
        {
            return StartCreateOrUpdate(instanceId, parameters, cancellationToken: cancellationToken).WaitForCompletion() as ArmResponse<VirtualMachineScaleSetVM>;
        }

        /// <inheritdoc />
        /// <param name="instanceId"> The instance ID of the virtual machine. </param>
        /// <param name="parameters"> Parameters supplied to the Update Virtual Machine Scale Sets VM operation. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public async override Task<ArmResponse<VirtualMachineScaleSetVM>> CreateOrUpdateAsync(string instanceId, VirtualMachineScaleSetVMData parameters, CancellationToken cancellationToken = default)
        {
            var operation = await StartCreateOrUpdateAsync(instanceId, parameters, cancellationToken: cancellationToken).ConfigureAwait(false);
            return operation.WaitForCompletion() as ArmResponse<VirtualMachineScaleSetVM>;
        }

        /// <inheritdoc />
        /// <param name="instanceId"> The instance ID of the virtual machine. </param>
        /// <param name="parameters"> Parameters supplied to the Update Virtual Machine Scale Sets VM operation. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public override ArmOperation<VirtualMachineScaleSetVM> StartCreateOrUpdate(string instanceId, VirtualMachineScaleSetVMData parameters, CancellationToken cancellationToken = default)
        {
            var originalResponse = Operations.Update(Id.ResourceGroupName, Id.Name, instanceId, parameters, cancellationToken: cancellationToken);
            var operation = new VirtualMachineScaleSetVMUpdateOperation(
            _clientDiagnostics, _pipeline, Operations.CreateUpdateRequest(
            Id.ResourceGroupName, Id.Name, instanceId, parameters).Request,
            originalResponse);
            return new PhArmOperation<VirtualMachineScaleSetVM, VirtualMachineScaleSetVMData>(
            operation,
            data => new VirtualMachineScaleSetVM(Parent, data));
        }

        /// <inheritdoc />
        /// <param name="instanceId"> The instance ID of the virtual machine. </param>
        /// <param name="parameters"> Parameters supplied to the Update Virtual Machine Scale Sets VM operation. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public async override Task<ArmOperation<VirtualMachineScaleSetVM>> StartCreateOrUpdateAsync(string instanceId, VirtualMachineScaleSetVMData parameters, CancellationToken cancellationToken = default)
        {
            var originalResponse = await Operations.UpdateAsync(Id.ResourceGroupName, Id.Name, instanceId, parameters, cancellationToken: cancellationToken).ConfigureAwait(false);
            var operation = new VirtualMachineScaleSetVMUpdateOperation(
            _clientDiagnostics, _pipeline, Operations.CreateUpdateRequest(
            Id.ResourceGroupName, Id.Name, instanceId, parameters).Request,
            originalResponse);
            return new PhArmOperation<VirtualMachineScaleSetVM, VirtualMachineScaleSetVMData>(
            operation,
            data => new VirtualMachineScaleSetVM(Parent, data));
        }

        /// <inheritdoc />
        /// <param name="instanceId"> The instance ID of the virtual machine. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public override ArmResponse<VirtualMachineScaleSetVM> Get(string instanceId, CancellationToken cancellationToken = default)
        {
            return new PhArmResponse<VirtualMachineScaleSetVM, VirtualMachineScaleSetVMData>(
            Operations.Get(Id.ResourceGroupName, Id.Name, instanceId, cancellationToken: cancellationToken),
            data => new VirtualMachineScaleSetVM(Parent, data));
        }

        /// <inheritdoc />
        /// <param name="instanceId"> The instance ID of the virtual machine. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public async override Task<ArmResponse<VirtualMachineScaleSetVM>> GetAsync(string instanceId, CancellationToken cancellationToken = default)
        {
            return new PhArmResponse<VirtualMachineScaleSetVM, VirtualMachineScaleSetVMData>(
            await Operations.GetAsync(Id.ResourceGroupName, Id.Name, instanceId, cancellationToken: cancellationToken),
            data => new VirtualMachineScaleSetVM(Parent, data));
        }

        /// <summary> Filters the list of todo: availability set for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public Pageable<GenericResource> ListAsGenericResource(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            var filters = new ResourceFilterCollection(VirtualMachineScaleSetVMData.ResourceType);
            filters.SubstringFilter = nameFilter;
            return ResourceListOperations.ListAtContext(Parent as ResourceGroupOperations, filters, top, cancellationToken);
        }

        /// <summary> Filters the list of todo: availability set for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<GenericResource> ListAsGenericResourceAsync(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            var filters = new ResourceFilterCollection(VirtualMachineScaleSetVMData.ResourceType);
            filters.SubstringFilter = nameFilter;
            return ResourceListOperations.ListAtContextAsync(Parent as ResourceGroupOperations, filters, top, cancellationToken);
        }

        /// <summary> Filters the list of todo: availability set for this resource group. Makes an additional network call to retrieve the full data model for each resource group. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of todo: availability set that may take multiple service requests to iterate over. </returns>
        public Pageable<VirtualMachineScaleSetVM> List(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            var results = ListAsGenericResource(nameFilter, top, cancellationToken);
            return new PhWrappingPageable<GenericResource, VirtualMachineScaleSetVM>(results, genericResource => new VirtualMachineScaleSetVMOperations(genericResource).Get().Value);
        }

        /// <summary> Filters the list of todo: availability set for this resource group. Makes an additional network call to retrieve the full data model for each resource group. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of todo: availability set that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<VirtualMachineScaleSetVM> ListAsync(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            var results = ListAsGenericResourceAsync(nameFilter, top, cancellationToken);
            return new PhWrappingAsyncPageable<GenericResource, VirtualMachineScaleSetVM>(results, genericResource => new VirtualMachineScaleSetVMOperations(genericResource).Get().Value);
        }

        // Builders.
        // public ArmBuilder<TenantResourceIdentifier, VirtualMachineScaleSetVM, VirtualMachineScaleSetVMData> Construct() { }
    }
}

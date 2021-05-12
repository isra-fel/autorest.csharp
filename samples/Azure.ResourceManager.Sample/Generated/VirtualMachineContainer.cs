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
    /// <summary> A class representing collection of VirtualMachine and their operations over a ResourceGroup. </summary>
    public partial class VirtualMachineContainer : ResourceContainerBase<ResourceGroupResourceIdentifier, VirtualMachine, VirtualMachineData>
    {
        /// <summary> Initializes a new instance of the <see cref="VirtualMachineContainer"/> class for mocking. </summary>
        protected VirtualMachineContainer()
        {
        }

        /// <summary> Initializes a new instance of VirtualMachineContainer class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal VirtualMachineContainer(ResourceOperationsBase parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _pipeline = ManagementPipelineBuilder.Build(Credential, BaseUri, ClientOptions);
        }

        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;

        /// <summary> Represents the REST operations. </summary>
        private VirtualMachinesRestOperations _restClient => new VirtualMachinesRestOperations(_clientDiagnostics, _pipeline, Id.SubscriptionId);

        /// <summary> Typed Resource Identifier for the container. </summary>
        public new ResourceGroupResourceIdentifier Id => base.Id as ResourceGroupResourceIdentifier;

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => ResourceGroupOperations.ResourceType;

        // Container level operations.

        /// <inheritdoc />
        /// <param name="vmName"> The name of the virtual machine. </param>
        /// <param name="parameters"> Parameters supplied to the Create Virtual Machine operation. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public Response<VirtualMachine> CreateOrUpdate(string vmName, VirtualMachineData parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("VirtualMachineContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                if (vmName == null)
                {
                    throw new ArgumentNullException(nameof(vmName));
                }
                if (parameters == null)
                {
                    throw new ArgumentNullException(nameof(parameters));
                }

                return StartCreateOrUpdate(vmName, parameters, cancellationToken: cancellationToken).WaitForCompletion() as Response<VirtualMachine>;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        /// <param name="vmName"> The name of the virtual machine. </param>
        /// <param name="parameters"> Parameters supplied to the Create Virtual Machine operation. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public async Task<Response<VirtualMachine>> CreateOrUpdateAsync(string vmName, VirtualMachineData parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("VirtualMachineContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                if (vmName == null)
                {
                    throw new ArgumentNullException(nameof(vmName));
                }
                if (parameters == null)
                {
                    throw new ArgumentNullException(nameof(parameters));
                }

                var operation = await StartCreateOrUpdateAsync(vmName, parameters, cancellationToken: cancellationToken).ConfigureAwait(false);
                return operation.WaitForCompletion() as Response<VirtualMachine>;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        /// <param name="vmName"> The name of the virtual machine. </param>
        /// <param name="parameters"> Parameters supplied to the Create Virtual Machine operation. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public Operation<VirtualMachine> StartCreateOrUpdate(string vmName, VirtualMachineData parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("VirtualMachineContainer.StartCreateOrUpdate");
            scope.Start();
            try
            {
                if (vmName == null)
                {
                    throw new ArgumentNullException(nameof(vmName));
                }
                if (parameters == null)
                {
                    throw new ArgumentNullException(nameof(parameters));
                }

                var originalResponse = _restClient.CreateOrUpdate(Id.ResourceGroupName, vmName, parameters, cancellationToken: cancellationToken);
                var operation = new VirtualMachineCreateOrUpdateOperation(
                _clientDiagnostics, _pipeline, _restClient.CreateCreateOrUpdateRequest(
                Id.ResourceGroupName, vmName, parameters).Request,
                originalResponse);
                return new PhArmOperation<VirtualMachine, VirtualMachineData>(
                operation,
                data => new VirtualMachine(Parent, data));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        /// <param name="vmName"> The name of the virtual machine. </param>
        /// <param name="parameters"> Parameters supplied to the Create Virtual Machine operation. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public async Task<Operation<VirtualMachine>> StartCreateOrUpdateAsync(string vmName, VirtualMachineData parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("VirtualMachineContainer.StartCreateOrUpdate");
            scope.Start();
            try
            {
                if (vmName == null)
                {
                    throw new ArgumentNullException(nameof(vmName));
                }
                if (parameters == null)
                {
                    throw new ArgumentNullException(nameof(parameters));
                }

                var originalResponse = await _restClient.CreateOrUpdateAsync(Id.ResourceGroupName, vmName, parameters, cancellationToken: cancellationToken).ConfigureAwait(false);
                var operation = new VirtualMachineCreateOrUpdateOperation(
                _clientDiagnostics, _pipeline, _restClient.CreateCreateOrUpdateRequest(
                Id.ResourceGroupName, vmName, parameters).Request,
                originalResponse);
                return new PhArmOperation<VirtualMachine, VirtualMachineData>(
                operation,
                data => new VirtualMachine(Parent, data));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        /// <param name="vmName"> The name of the virtual machine. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public override Response<VirtualMachine> Get(string vmName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("VirtualMachineContainer.Get");
            scope.Start();
            try
            {
                if (vmName == null)
                {
                    throw new ArgumentNullException(nameof(vmName));
                }

                var response = _restClient.Get(Id.ResourceGroupName, vmName, cancellationToken: cancellationToken);
                return Response.FromValue(new VirtualMachine(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        /// <param name="vmName"> The name of the virtual machine. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public async override Task<Response<VirtualMachine>> GetAsync(string vmName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("VirtualMachineContainer.Get");
            scope.Start();
            try
            {
                if (vmName == null)
                {
                    throw new ArgumentNullException(nameof(vmName));
                }

                var response = await _restClient.GetAsync(Id.ResourceGroupName, vmName, cancellationToken: cancellationToken);
                return Response.FromValue(new VirtualMachine(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of VirtualMachine for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public Pageable<GenericResource> ListAsGenericResource(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("VirtualMachineContainer.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(VirtualMachineOperations.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.ListAtContext(Parent as ResourceGroupOperations, filters, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of VirtualMachine for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<GenericResource> ListAsGenericResourceAsync(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("VirtualMachineContainer.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(VirtualMachineOperations.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.ListAtContextAsync(Parent as ResourceGroupOperations, filters, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="VirtualMachine" /> for this resource group. Makes an additional network call to retrieve the full data model for each resource group. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of <see cref="VirtualMachine" /> that may take multiple service requests to iterate over. </returns>
        public Pageable<VirtualMachine> List(string nameFilter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(nameFilter))
            {
                Page<VirtualMachine> FirstPageFunc(int? pageSizeHint)
                {
                    using var scope = _clientDiagnostics.CreateScope("VirtualMachineContainer.List");
                    scope.Start();
                    try
                    {
                        var response = _restClient.List(Id.ResourceGroupName, cancellationToken: cancellationToken);
                        return Page.FromValues(response.Value.Value.Select(value => new VirtualMachine(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                    }
                    catch (Exception e)
                    {
                        scope.Failed(e);
                        throw;
                    }
                }
                Page<VirtualMachine> NextPageFunc(string nextLink, int? pageSizeHint)
                {
                    using var scope = _clientDiagnostics.CreateScope("VirtualMachineContainer.List");
                    scope.Start();
                    try
                    {
                        var response = _restClient.ListNextPage(nextLink, Id.ResourceGroupName, cancellationToken: cancellationToken);
                        return Page.FromValues(response.Value.Value.Select(value => new VirtualMachine(Parent, value)), response.Value.NextLink, response.GetRawResponse());
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
                return new PhWrappingPageable<GenericResource, VirtualMachine>(results, genericResource => new VirtualMachineOperations(genericResource).Get().Value);
            }
        }

        /// <summary> Filters the list of <see cref="VirtualMachine" /> for this resource group. Makes an additional network call to retrieve the full data model for each resource group. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of <see cref="VirtualMachine" /> that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<VirtualMachine> ListAsync(string nameFilter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrEmpty(nameFilter))
            {
                async Task<Page<VirtualMachine>> FirstPageFunc(int? pageSizeHint)
                {
                    using var scope = _clientDiagnostics.CreateScope("VirtualMachineContainer.List");
                    scope.Start();
                    try
                    {
                        var response = await _restClient.ListAsync(Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                        return Page.FromValues(response.Value.Value.Select(value => new VirtualMachine(Parent, value)), response.Value.NextLink, response.GetRawResponse());
                    }
                    catch (Exception e)
                    {
                        scope.Failed(e);
                        throw;
                    }
                }
                async Task<Page<VirtualMachine>> NextPageFunc(string nextLink, int? pageSizeHint)
                {
                    using var scope = _clientDiagnostics.CreateScope("VirtualMachineContainer.List");
                    scope.Start();
                    try
                    {
                        var response = await _restClient.ListNextPageAsync(nextLink, Id.ResourceGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                        return Page.FromValues(response.Value.Value.Select(value => new VirtualMachine(Parent, value)), response.Value.NextLink, response.GetRawResponse());
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
                return new PhWrappingAsyncPageable<GenericResource, VirtualMachine>(results, genericResource => new VirtualMachineOperations(genericResource).Get().Value);
            }
        }

        // Builders.
        // public ArmBuilder<ResourceGroupResourceIdentifier, VirtualMachine, VirtualMachineData> Construct() { }
    }
}

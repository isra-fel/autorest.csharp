// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Core.Resources;

namespace MgmtParent
{
    /// <summary> A class representing collection of VirtualMachineExtensionImage and their operations over a Parent. </summary>
    public partial class VirtualMachineExtensionImageContainer : ResourceContainerBase<TenantResourceIdentifier, VirtualMachineExtensionImage, VirtualMachineExtensionImageData>
    {
        /// <summary> Initializes a new instance of the <see cref="VirtualMachineExtensionImageContainer"/> class for mocking. </summary>
        protected VirtualMachineExtensionImageContainer()
        {
        }

        /// <summary> Initializes a new instance of VirtualMachineExtensionImageContainer class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal VirtualMachineExtensionImageContainer(ResourceOperationsBase parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _pipeline = ManagementPipelineBuilder.Build(Credential, BaseUri, ClientOptions);
        }

        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;

        /// <summary> Represents the REST operations. </summary>
        private VirtualMachineExtensionImagesRestOperations _restClient => new VirtualMachineExtensionImagesRestOperations(_clientDiagnostics, _pipeline, Id.SubscriptionId);

        /// <summary> Typed Resource Identifier for the container. </summary>
        // todo: hard coding ResourceGroupResourceIdentifier we don't know the exact ID type but we need it in implementations in CreateOrUpdate() etc.
        public new ResourceGroupResourceIdentifier Id => base.Id as ResourceGroupResourceIdentifier;
        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => "Microsoft.Compute/locations/publishers";

        // Container level operations.

        /// <inheritdoc />
        /// <param name="version"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public override ArmResponse<VirtualMachineExtensionImage> Get(string version, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("VirtualMachineExtensionImageContainer.Get");
            scope.Start();
            try
            {
                if (version == null)
                {
                    throw new ArgumentNullException(nameof(version));
                }

                var response = _restClient.Get(Id.Parent.Parent.Parent.Name, Id.Parent.Parent.Name, Id.Parent.Name, version, cancellationToken: cancellationToken);
                return ArmResponse.FromValue(new VirtualMachineExtensionImage(Parent, response.Value), ArmResponse.FromResponse(response.GetRawResponse()));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        /// <param name="version"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public async override Task<ArmResponse<VirtualMachineExtensionImage>> GetAsync(string version, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("VirtualMachineExtensionImageContainer.Get");
            scope.Start();
            try
            {
                if (version == null)
                {
                    throw new ArgumentNullException(nameof(version));
                }

                var response = await _restClient.GetAsync(Id.Parent.Parent.Parent.Name, Id.Parent.Parent.Name, Id.Parent.Name, version, cancellationToken: cancellationToken);
                return ArmResponse.FromValue(new VirtualMachineExtensionImage(Parent, response.Value), ArmResponse.FromResponse(response.GetRawResponse()));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of VirtualMachineExtensionImage for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public Pageable<GenericResource> ListAsGenericResource(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("VirtualMachineExtensionImageContainer.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(VirtualMachineExtensionImageOperations.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.ListAtContext(Parent as ResourceGroupOperations, filters, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of VirtualMachineExtensionImage for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<GenericResource> ListAsGenericResourceAsync(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("VirtualMachineExtensionImageContainer.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(VirtualMachineExtensionImageOperations.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.ListAtContextAsync(Parent as ResourceGroupOperations, filters, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
        // have not LIST paging method

        /// <summary> Filters the list of <see cref="VirtualMachineExtensionImage" /> for this resource group. Makes an additional network call to retrieve the full data model for each resource group. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of <see cref="VirtualMachineExtensionImage" /> that may take multiple service requests to iterate over. </returns>
        public Pageable<VirtualMachineExtensionImage> List(string nameFilter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            var results = ListAsGenericResource(nameFilter, top, cancellationToken);
            return new PhWrappingPageable<GenericResource, VirtualMachineExtensionImage>(results, genericResource => new VirtualMachineExtensionImageOperations(genericResource).Get().Value);
        }

        /// <summary> Filters the list of <see cref="VirtualMachineExtensionImage" /> for this resource group. Makes an additional network call to retrieve the full data model for each resource group. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of <see cref="VirtualMachineExtensionImage" /> that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<VirtualMachineExtensionImage> ListAsync(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("VirtualMachineExtensionImageContainer.List");
            scope.Start();
            try
            {
                var results = ListAsGenericResourceAsync(nameFilter, top, cancellationToken);
                return new PhWrappingAsyncPageable<GenericResource, VirtualMachineExtensionImage>(results, genericResource => new VirtualMachineExtensionImageOperations(genericResource).Get().Value);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // Builders.
        // public ArmBuilder<TenantResourceIdentifier, VirtualMachineExtensionImage, VirtualMachineExtensionImageData> Construct() { }
    }
}

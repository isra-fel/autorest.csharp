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
    /// <summary> A class representing collection of Image and their operations over a [ParentResource]. </summary>
    public partial class ImageContainer : ResourceContainerBase<TenantResourceIdentifier, Image, ImageData>
    {
        /// <summary> Initializes a new instance of ImageContainer class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal ImageContainer(ResourceOperationsBase parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _pipeline = new HttpPipeline(ClientOptions.Transport);
        }

        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;

        /// <summary> Represents the REST operations. </summary>
        private ImagesRestOperations Operations => new ImagesRestOperations(_clientDiagnostics, _pipeline, Id.SubscriptionId);

        /// <summary> Typed Resource Identifier for the container. </summary>
        // todo: hard coding ResourceGroupResourceIdentifier we don't know the exact ID type but we need it in implementations in CreateOrUpdate() etc.
        public new ResourceGroupResourceIdentifier Id => base.Id as ResourceGroupResourceIdentifier;
        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => ResourceGroupOperations.ResourceType;

        // Container level operations.

        /// <inheritdoc />
        /// <param name="imageName"> The name of the image. </param>
        /// <param name="parameters"> Parameters supplied to the Create Image operation. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public override ArmResponse<Image> CreateOrUpdate(string imageName, ImageData parameters, CancellationToken cancellationToken = default)
        {
            return StartCreateOrUpdate(imageName, parameters, cancellationToken: cancellationToken).WaitForCompletion() as ArmResponse<Image>;
        }

        /// <inheritdoc />
        /// <param name="imageName"> The name of the image. </param>
        /// <param name="parameters"> Parameters supplied to the Create Image operation. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public async override Task<ArmResponse<Image>> CreateOrUpdateAsync(string imageName, ImageData parameters, CancellationToken cancellationToken = default)
        {
            var operation = await StartCreateOrUpdateAsync(imageName, parameters, cancellationToken: cancellationToken).ConfigureAwait(false);
            return operation.WaitForCompletion() as ArmResponse<Image>;
        }

        /// <inheritdoc />
        /// <param name="imageName"> The name of the image. </param>
        /// <param name="parameters"> Parameters supplied to the Create Image operation. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public override ArmOperation<Image> StartCreateOrUpdate(string imageName, ImageData parameters, CancellationToken cancellationToken = default)
        {
            var originalResponse = Operations.CreateOrUpdate(Id.ResourceGroupName, imageName, parameters, cancellationToken: cancellationToken);
            var operation = new ImageCreateOrUpdateOperation(
            _clientDiagnostics, _pipeline, Operations.CreateCreateOrUpdateRequest(
            Id.ResourceGroupName, imageName, parameters).Request,
            originalResponse);
            return new PhArmOperation<Image, ImageData>(
            operation,
            data => new Image(Parent, data));
        }

        /// <inheritdoc />
        /// <param name="imageName"> The name of the image. </param>
        /// <param name="parameters"> Parameters supplied to the Create Image operation. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public async override Task<ArmOperation<Image>> StartCreateOrUpdateAsync(string imageName, ImageData parameters, CancellationToken cancellationToken = default)
        {
            var originalResponse = await Operations.CreateOrUpdateAsync(Id.ResourceGroupName, imageName, parameters, cancellationToken: cancellationToken).ConfigureAwait(false);
            var operation = new ImageCreateOrUpdateOperation(
            _clientDiagnostics, _pipeline, Operations.CreateCreateOrUpdateRequest(
            Id.ResourceGroupName, imageName, parameters).Request,
            originalResponse);
            return new PhArmOperation<Image, ImageData>(
            operation,
            data => new Image(Parent, data));
        }

        /// <inheritdoc />
        /// <param name="imageName"> The name of the image. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public override ArmResponse<Image> Get(string imageName, CancellationToken cancellationToken = default)
        {
            return new PhArmResponse<Image, ImageData>(
            Operations.Get(Id.ResourceGroupName, imageName, cancellationToken: cancellationToken),
            data => new Image(Parent, data));
        }

        /// <inheritdoc />
        /// <param name="imageName"> The name of the image. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public async override Task<ArmResponse<Image>> GetAsync(string imageName, CancellationToken cancellationToken = default)
        {
            return new PhArmResponse<Image, ImageData>(
            await Operations.GetAsync(Id.ResourceGroupName, imageName, cancellationToken: cancellationToken),
            data => new Image(Parent, data));
        }

        /// <summary> Filters the list of Image for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public Pageable<GenericResource> ListAsGenericResource(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            var filters = new ResourceFilterCollection(ImageData.ResourceType);
            filters.SubstringFilter = nameFilter;
            return ResourceListOperations.ListAtContext(Parent as ResourceGroupOperations, filters, top, cancellationToken);
        }

        /// <summary> Filters the list of Image for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<GenericResource> ListAsGenericResourceAsync(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            var filters = new ResourceFilterCollection(ImageData.ResourceType);
            filters.SubstringFilter = nameFilter;
            return ResourceListOperations.ListAtContextAsync(Parent as ResourceGroupOperations, filters, top, cancellationToken);
        }

        /// <summary> Filters the list of <see cref="Image" /> for this resource group. Makes an additional network call to retrieve the full data model for each resource group. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of <see cref="Image" /> that may take multiple service requests to iterate over. </returns>
        public Pageable<Image> List(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            var results = ListAsGenericResource(nameFilter, top, cancellationToken);
            return new PhWrappingPageable<GenericResource, Image>(results, genericResource => new ImageOperations(genericResource).Get().Value);
        }

        /// <summary> Filters the list of <see cref="Image" /> for this resource group. Makes an additional network call to retrieve the full data model for each resource group. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of <see cref="Image" /> that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<Image> ListAsync(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            var results = ListAsGenericResourceAsync(nameFilter, top, cancellationToken);
            return new PhWrappingAsyncPageable<GenericResource, Image>(results, genericResource => new ImageOperations(genericResource).Get().Value);
        }

        // Builders.
        // public ArmBuilder<TenantResourceIdentifier, Image, ImageData> Construct() { }
    }
}

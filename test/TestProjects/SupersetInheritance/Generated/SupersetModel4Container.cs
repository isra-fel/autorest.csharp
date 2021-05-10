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

namespace SupersetInheritance
{
    /// <summary> A class representing collection of SupersetModel4 and their operations over a ResourceGroup. </summary>
    public partial class SupersetModel4Container : ContainerBase<TenantResourceIdentifier, SupersetModel4>
    {
        /// <summary> Initializes a new instance of the <see cref="SupersetModel4Container"/> class for mocking. </summary>
        protected SupersetModel4Container()
        {
        }

        /// <summary> Initializes a new instance of SupersetModel4Container class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal SupersetModel4Container(ResourceOperationsBase parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _pipeline = ManagementPipelineBuilder.Build(Credential, BaseUri, ClientOptions);
        }

        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;

        /// <summary> Represents the REST operations. </summary>
        private SupersetModel4SRestOperations _restClient => new SupersetModel4SRestOperations(_clientDiagnostics, _pipeline, Id.SubscriptionId);

        /// <summary> Typed Resource Identifier for the container. </summary>
        // todo: hard coding ResourceGroupResourceIdentifier we don't know the exact ID type but we need it in implementations in CreateOrUpdate() etc.
        public new ResourceGroupResourceIdentifier Id => base.Id as ResourceGroupResourceIdentifier;
        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => ResourceGroupOperations.ResourceType;

        // Container level operations.

        /// <inheritdoc />
        /// <param name="supersetModel4SName"> The String to use. </param>
        /// <param name="parameters"> The SupersetModel4 to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public ArmResponse<SupersetModel4> CreateOrUpdate(string supersetModel4SName, SupersetModel4Data parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SupersetModel4Container.CreateOrUpdate");
            scope.Start();
            try
            {
                if (supersetModel4SName == null)
                {
                    throw new ArgumentNullException(nameof(supersetModel4SName));
                }
                if (parameters == null)
                {
                    throw new ArgumentNullException(nameof(parameters));
                }

                return StartCreateOrUpdate(supersetModel4SName, parameters, cancellationToken: cancellationToken).WaitForCompletion() as ArmResponse<SupersetModel4>;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        /// <param name="supersetModel4SName"> The String to use. </param>
        /// <param name="parameters"> The SupersetModel4 to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public async Task<ArmResponse<SupersetModel4>> CreateOrUpdateAsync(string supersetModel4SName, SupersetModel4Data parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SupersetModel4Container.CreateOrUpdate");
            scope.Start();
            try
            {
                if (supersetModel4SName == null)
                {
                    throw new ArgumentNullException(nameof(supersetModel4SName));
                }
                if (parameters == null)
                {
                    throw new ArgumentNullException(nameof(parameters));
                }

                var operation = await StartCreateOrUpdateAsync(supersetModel4SName, parameters, cancellationToken: cancellationToken).ConfigureAwait(false);
                return operation.WaitForCompletion() as ArmResponse<SupersetModel4>;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        /// <param name="supersetModel4SName"> The String to use. </param>
        /// <param name="parameters"> The SupersetModel4 to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public ArmOperation<SupersetModel4> StartCreateOrUpdate(string supersetModel4SName, SupersetModel4Data parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SupersetModel4Container.StartCreateOrUpdate");
            scope.Start();
            try
            {
                if (supersetModel4SName == null)
                {
                    throw new ArgumentNullException(nameof(supersetModel4SName));
                }
                if (parameters == null)
                {
                    throw new ArgumentNullException(nameof(parameters));
                }

                var originalResponse = _restClient.Put(Id.ResourceGroupName, supersetModel4SName, parameters, cancellationToken: cancellationToken);
                return new PhArmOperation<SupersetModel4, SupersetModel4Data>(
                originalResponse,
                data => new SupersetModel4(Parent, data));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        /// <param name="supersetModel4SName"> The String to use. </param>
        /// <param name="parameters"> The SupersetModel4 to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public async Task<ArmOperation<SupersetModel4>> StartCreateOrUpdateAsync(string supersetModel4SName, SupersetModel4Data parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SupersetModel4Container.StartCreateOrUpdate");
            scope.Start();
            try
            {
                if (supersetModel4SName == null)
                {
                    throw new ArgumentNullException(nameof(supersetModel4SName));
                }
                if (parameters == null)
                {
                    throw new ArgumentNullException(nameof(parameters));
                }

                var originalResponse = await _restClient.PutAsync(Id.ResourceGroupName, supersetModel4SName, parameters, cancellationToken: cancellationToken).ConfigureAwait(false);
                return new PhArmOperation<SupersetModel4, SupersetModel4Data>(
                originalResponse,
                data => new SupersetModel4(Parent, data));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of SupersetModel4 for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public Pageable<GenericResource> ListAsGenericResource(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SupersetModel4Container.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(SupersetModel4Operations.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.ListAtContext(Parent as ResourceGroupOperations, filters, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of SupersetModel4 for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<GenericResource> ListAsGenericResourceAsync(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SupersetModel4Container.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(SupersetModel4Operations.ResourceType);
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

        /// <summary> Filters the list of <see cref="SupersetModel4" /> for this resource group. Makes an additional network call to retrieve the full data model for each resource group. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of <see cref="SupersetModel4" /> that may take multiple service requests to iterate over. </returns>
        public Pageable<SupersetModel4> List(string nameFilter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            var results = ListAsGenericResource(nameFilter, top, cancellationToken);
            return new PhWrappingPageable<GenericResource, SupersetModel4>(results, genericResource => new SupersetModel4Operations(genericResource).Get().Value);
        }

        /// <summary> Filters the list of <see cref="SupersetModel4" /> for this resource group. Makes an additional network call to retrieve the full data model for each resource group. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of <see cref="SupersetModel4" /> that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<SupersetModel4> ListAsync(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("SupersetModel4Container.List");
            scope.Start();
            try
            {
                var results = ListAsGenericResourceAsync(nameFilter, top, cancellationToken);
                return new PhWrappingAsyncPageable<GenericResource, SupersetModel4>(results, genericResource => new SupersetModel4Operations(genericResource).Get().Value);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // Builders.
        // public ArmBuilder<TenantResourceIdentifier, SupersetModel4, SupersetModel4Data> Construct() { }
    }
}

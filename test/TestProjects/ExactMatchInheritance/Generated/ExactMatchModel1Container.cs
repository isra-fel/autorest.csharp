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

namespace ExactMatchInheritance
{
    /// <summary> A class representing collection of ExactMatchModel1 and their operations over a ResourceGroup. </summary>
    public partial class ExactMatchModel1Container : ContainerBase<TenantResourceIdentifier, ExactMatchModel1>
    {
        /// <summary> Initializes a new instance of the <see cref="ExactMatchModel1Container"/> class for mocking. </summary>
        protected ExactMatchModel1Container()
        {
        }

        /// <summary> Initializes a new instance of ExactMatchModel1Container class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal ExactMatchModel1Container(ResourceOperationsBase parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _pipeline = ManagementPipelineBuilder.Build(Credential, BaseUri, ClientOptions);
        }

        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;

        /// <summary> Represents the REST operations. </summary>
        private ExactMatchModel1SRestOperations _restClient => new ExactMatchModel1SRestOperations(_clientDiagnostics, _pipeline, Id.SubscriptionId);

        /// <summary> Typed Resource Identifier for the container. </summary>
        public new ResourceGroupResourceIdentifier Id => base.Id as ResourceGroupResourceIdentifier;

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => ResourceGroupOperations.ResourceType;

        // Container level operations.

        /// <inheritdoc />
        /// <param name="exactMatchModel1SName"> The String to use. </param>
        /// <param name="parameters"> The ExactMatchModel1 to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public ArmResponse<ExactMatchModel1> CreateOrUpdate(string exactMatchModel1SName, ExactMatchModel1Data parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel1Container.CreateOrUpdate");
            scope.Start();
            try
            {
                if (exactMatchModel1SName == null)
                {
                    throw new ArgumentNullException(nameof(exactMatchModel1SName));
                }
                if (parameters == null)
                {
                    throw new ArgumentNullException(nameof(parameters));
                }

                return StartCreateOrUpdate(exactMatchModel1SName, parameters, cancellationToken: cancellationToken).WaitForCompletion() as ArmResponse<ExactMatchModel1>;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        /// <param name="exactMatchModel1SName"> The String to use. </param>
        /// <param name="parameters"> The ExactMatchModel1 to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public async Task<ArmResponse<ExactMatchModel1>> CreateOrUpdateAsync(string exactMatchModel1SName, ExactMatchModel1Data parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel1Container.CreateOrUpdate");
            scope.Start();
            try
            {
                if (exactMatchModel1SName == null)
                {
                    throw new ArgumentNullException(nameof(exactMatchModel1SName));
                }
                if (parameters == null)
                {
                    throw new ArgumentNullException(nameof(parameters));
                }

                var operation = await StartCreateOrUpdateAsync(exactMatchModel1SName, parameters, cancellationToken: cancellationToken).ConfigureAwait(false);
                return operation.WaitForCompletion() as ArmResponse<ExactMatchModel1>;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        /// <param name="exactMatchModel1SName"> The String to use. </param>
        /// <param name="parameters"> The ExactMatchModel1 to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public ArmOperation<ExactMatchModel1> StartCreateOrUpdate(string exactMatchModel1SName, ExactMatchModel1Data parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel1Container.StartCreateOrUpdate");
            scope.Start();
            try
            {
                if (exactMatchModel1SName == null)
                {
                    throw new ArgumentNullException(nameof(exactMatchModel1SName));
                }
                if (parameters == null)
                {
                    throw new ArgumentNullException(nameof(parameters));
                }

                var originalResponse = _restClient.Put(Id.ResourceGroupName, exactMatchModel1SName, parameters, cancellationToken: cancellationToken);
                return new PhArmOperation<ExactMatchModel1, ExactMatchModel1Data>(
                originalResponse,
                data => new ExactMatchModel1(Parent, data));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        /// <param name="exactMatchModel1SName"> The String to use. </param>
        /// <param name="parameters"> The ExactMatchModel1 to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public async Task<ArmOperation<ExactMatchModel1>> StartCreateOrUpdateAsync(string exactMatchModel1SName, ExactMatchModel1Data parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel1Container.StartCreateOrUpdate");
            scope.Start();
            try
            {
                if (exactMatchModel1SName == null)
                {
                    throw new ArgumentNullException(nameof(exactMatchModel1SName));
                }
                if (parameters == null)
                {
                    throw new ArgumentNullException(nameof(parameters));
                }

                var originalResponse = await _restClient.PutAsync(Id.ResourceGroupName, exactMatchModel1SName, parameters, cancellationToken: cancellationToken).ConfigureAwait(false);
                return new PhArmOperation<ExactMatchModel1, ExactMatchModel1Data>(
                originalResponse,
                data => new ExactMatchModel1(Parent, data));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of ExactMatchModel1 for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public Pageable<GenericResource> ListAsGenericResource(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel1Container.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(ExactMatchModel1Operations.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.ListAtContext(Parent as ResourceGroupOperations, filters, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of ExactMatchModel1 for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<GenericResource> ListAsGenericResourceAsync(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel1Container.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(ExactMatchModel1Operations.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.ListAtContextAsync(Parent as ResourceGroupOperations, filters, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="ExactMatchModel1" /> for this resource group. Makes an additional network call to retrieve the full data model for each resource group. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of <see cref="ExactMatchModel1" /> that may take multiple service requests to iterate over. </returns>
        public Pageable<ExactMatchModel1> List(string nameFilter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            var results = ListAsGenericResource(nameFilter, top, cancellationToken);
            return new PhWrappingPageable<GenericResource, ExactMatchModel1>(results, genericResource => new ExactMatchModel1Operations(genericResource).Get().Value);
        }

        /// <summary> Filters the list of <see cref="ExactMatchModel1" /> for this resource group. Makes an additional network call to retrieve the full data model for each resource group. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of <see cref="ExactMatchModel1" /> that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<ExactMatchModel1> ListAsync(string nameFilter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            var results = ListAsGenericResourceAsync(nameFilter, top, cancellationToken);
            return new PhWrappingAsyncPageable<GenericResource, ExactMatchModel1>(results, genericResource => new ExactMatchModel1Operations(genericResource).Get().Value);
        }

        // Builders.
        // public ArmBuilder<TenantResourceIdentifier, ExactMatchModel1, ExactMatchModel1Data> Construct() { }
    }
}

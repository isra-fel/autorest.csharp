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
    /// <summary> A class representing collection of ExactMatchModel5 and their operations over a ResourceGroup. </summary>
    public partial class ExactMatchModel5Container : ContainerBase<ResourceGroupResourceIdentifier>
    {
        /// <summary> Initializes a new instance of the <see cref="ExactMatchModel5Container"/> class for mocking. </summary>
        protected ExactMatchModel5Container()
        {
        }

        /// <summary> Initializes a new instance of ExactMatchModel5Container class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal ExactMatchModel5Container(ResourceOperationsBase parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _pipeline = ManagementPipelineBuilder.Build(Credential, BaseUri, ClientOptions);
        }

        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;

        /// <summary> Represents the REST operations. </summary>
        private ExactMatchModel5SRestOperations _restClient => new ExactMatchModel5SRestOperations(_clientDiagnostics, _pipeline, Id.SubscriptionId);

        /// <summary> Typed Resource Identifier for the container. </summary>
        public new ResourceGroupResourceIdentifier Id => base.Id as ResourceGroupResourceIdentifier;

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => ResourceGroupOperations.ResourceType;

        // Container level operations.

        /// <summary> The operation to create or update a ExactMatchModel5. Please note some properties can be set only during creation. </summary>
        /// <param name="exactMatchModel5SName"> The String to use. </param>
        /// <param name="parameters"> The ExactMatchModel5 to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public Response<ExactMatchModel5> CreateOrUpdate(string exactMatchModel5SName, ExactMatchModel5Data parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel5Container.CreateOrUpdate");
            scope.Start();
            try
            {
                if (exactMatchModel5SName == null)
                {
                    throw new ArgumentNullException(nameof(exactMatchModel5SName));
                }
                if (parameters == null)
                {
                    throw new ArgumentNullException(nameof(parameters));
                }

                return StartCreateOrUpdate(exactMatchModel5SName, parameters, cancellationToken: cancellationToken).WaitForCompletion() as Response<ExactMatchModel5>;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> The operation to create or update a ExactMatchModel5. Please note some properties can be set only during creation. </summary>
        /// <param name="exactMatchModel5SName"> The String to use. </param>
        /// <param name="parameters"> The ExactMatchModel5 to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public async Task<Response<ExactMatchModel5>> CreateOrUpdateAsync(string exactMatchModel5SName, ExactMatchModel5Data parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel5Container.CreateOrUpdate");
            scope.Start();
            try
            {
                if (exactMatchModel5SName == null)
                {
                    throw new ArgumentNullException(nameof(exactMatchModel5SName));
                }
                if (parameters == null)
                {
                    throw new ArgumentNullException(nameof(parameters));
                }

                var operation = await StartCreateOrUpdateAsync(exactMatchModel5SName, parameters, cancellationToken: cancellationToken).ConfigureAwait(false);
                return operation.WaitForCompletion() as Response<ExactMatchModel5>;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> The operation to create or update a ExactMatchModel5. Please note some properties can be set only during creation. </summary>
        /// <param name="exactMatchModel5SName"> The String to use. </param>
        /// <param name="parameters"> The ExactMatchModel5 to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public Operation<ExactMatchModel5> StartCreateOrUpdate(string exactMatchModel5SName, ExactMatchModel5Data parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel5Container.StartCreateOrUpdate");
            scope.Start();
            try
            {
                if (exactMatchModel5SName == null)
                {
                    throw new ArgumentNullException(nameof(exactMatchModel5SName));
                }
                if (parameters == null)
                {
                    throw new ArgumentNullException(nameof(parameters));
                }

                var originalResponse = _restClient.Put(Id.ResourceGroupName, exactMatchModel5SName, parameters, cancellationToken: cancellationToken);
                return new ExactMatchModel5SPutOperation(Parent, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> The operation to create or update a ExactMatchModel5. Please note some properties can be set only during creation. </summary>
        /// <param name="exactMatchModel5SName"> The String to use. </param>
        /// <param name="parameters"> The ExactMatchModel5 to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public async Task<Operation<ExactMatchModel5>> StartCreateOrUpdateAsync(string exactMatchModel5SName, ExactMatchModel5Data parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel5Container.StartCreateOrUpdate");
            scope.Start();
            try
            {
                if (exactMatchModel5SName == null)
                {
                    throw new ArgumentNullException(nameof(exactMatchModel5SName));
                }
                if (parameters == null)
                {
                    throw new ArgumentNullException(nameof(parameters));
                }

                var originalResponse = await _restClient.PutAsync(Id.ResourceGroupName, exactMatchModel5SName, parameters, cancellationToken: cancellationToken).ConfigureAwait(false);
                return new ExactMatchModel5SPutOperation(Parent, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="ExactMatchModel5" /> for this resource group. </summary>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of <see cref="ExactMatchModel5" /> that may take multiple service requests to iterate over. </returns>
        public Pageable<ExactMatchModel5> List(int? top = null, CancellationToken cancellationToken = default)
        {
            var results = ListAsGenericResource(null, top, cancellationToken);
            return new PhWrappingPageable<GenericResource, ExactMatchModel5>(results, genericResource => new ExactMatchModel5Operations(genericResource).Get().Value);
        }

        /// <summary> Filters the list of <see cref="ExactMatchModel5" /> for this resource group. Makes an additional network call to retrieve the full data model for each resource group. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of <see cref="ExactMatchModel5" /> that may take multiple service requests to iterate over. </returns>
        public Pageable<ExactMatchModel5> List(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            var results = ListAsGenericResource(null, top, cancellationToken);
            return new PhWrappingPageable<GenericResource, ExactMatchModel5>(results, genericResource => new ExactMatchModel5Operations(genericResource).Get().Value);
        }

        /// <summary> Filters the list of <see cref="ExactMatchModel5" /> for this resource group. </summary>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of <see cref="ExactMatchModel5" /> that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<ExactMatchModel5> ListAsync(int? top = null, CancellationToken cancellationToken = default)
        {
            var results = ListAsGenericResourceAsync(null, top, cancellationToken);
            return new PhWrappingAsyncPageable<GenericResource, ExactMatchModel5>(results, genericResource => new ExactMatchModel5Operations(genericResource).Get().Value);
        }

        /// <summary> Filters the list of <see cref="ExactMatchModel5" /> for this resource group. Makes an additional network call to retrieve the full data model for each resource group. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of <see cref="ExactMatchModel5" /> that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<ExactMatchModel5> ListAsync(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            var results = ListAsGenericResourceAsync(null, top, cancellationToken);
            return new PhWrappingAsyncPageable<GenericResource, ExactMatchModel5>(results, genericResource => new ExactMatchModel5Operations(genericResource).Get().Value);
        }

        /// <summary> Filters the list of ExactMatchModel5 for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public Pageable<GenericResource> ListAsGenericResource(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel5Container.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(ExactMatchModel5Operations.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.ListAtContext(Parent as ResourceGroupOperations, filters, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of ExactMatchModel5 for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<GenericResource> ListAsGenericResourceAsync(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ExactMatchModel5Container.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(ExactMatchModel5Operations.ResourceType);
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
        // public ArmBuilder<ResourceGroupResourceIdentifier, ExactMatchModel5, ExactMatchModel5Data> Construct() { }
    }
}

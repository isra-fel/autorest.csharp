// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Core.Resources;

namespace SupersetFlattenInheritance
{
    /// <summary> A class representing collection of TrackedResourceModel2 and their operations over a ResourceGroup. </summary>
    public partial class TrackedResourceModel2Container : ResourceContainerBase<ResourceGroupResourceIdentifier, TrackedResourceModel2, TrackedResourceModel2Data>
    {
        /// <summary> Initializes a new instance of the <see cref="TrackedResourceModel2Container"/> class for mocking. </summary>
        protected TrackedResourceModel2Container()
        {
        }

        /// <summary> Initializes a new instance of TrackedResourceModel2Container class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal TrackedResourceModel2Container(ResourceOperationsBase parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
        }

        private readonly ClientDiagnostics _clientDiagnostics;

        /// <summary> Represents the REST operations. </summary>
        private TrackedResourceModel2SRestOperations _restClient => new TrackedResourceModel2SRestOperations(_clientDiagnostics, Pipeline, Id.SubscriptionId);

        /// <summary> Typed Resource Identifier for the container. </summary>
        public new ResourceGroupResourceIdentifier Id => base.Id as ResourceGroupResourceIdentifier;

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => ResourceGroupOperations.ResourceType;

        // Container level operations.

        /// <summary> The operation to create or update a TrackedResourceModel2. Please note some properties can be set only during creation. </summary>
        /// <param name="trackedResourceModel2SName"> The String to use. </param>
        /// <param name="parameters"> The TrackedResourceModel2 to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public Response<TrackedResourceModel2> CreateOrUpdate(string trackedResourceModel2SName, TrackedResourceModel2Data parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("TrackedResourceModel2Container.CreateOrUpdate");
            scope.Start();
            try
            {
                if (trackedResourceModel2SName == null)
                {
                    throw new ArgumentNullException(nameof(trackedResourceModel2SName));
                }
                if (parameters == null)
                {
                    throw new ArgumentNullException(nameof(parameters));
                }

                return StartCreateOrUpdate(trackedResourceModel2SName, parameters, cancellationToken: cancellationToken).WaitForCompletion(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> The operation to create or update a TrackedResourceModel2. Please note some properties can be set only during creation. </summary>
        /// <param name="trackedResourceModel2SName"> The String to use. </param>
        /// <param name="parameters"> The TrackedResourceModel2 to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async Task<Response<TrackedResourceModel2>> CreateOrUpdateAsync(string trackedResourceModel2SName, TrackedResourceModel2Data parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("TrackedResourceModel2Container.CreateOrUpdate");
            scope.Start();
            try
            {
                if (trackedResourceModel2SName == null)
                {
                    throw new ArgumentNullException(nameof(trackedResourceModel2SName));
                }
                if (parameters == null)
                {
                    throw new ArgumentNullException(nameof(parameters));
                }

                var operation = await StartCreateOrUpdateAsync(trackedResourceModel2SName, parameters, cancellationToken: cancellationToken).ConfigureAwait(false);
                return await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> The operation to create or update a TrackedResourceModel2. Please note some properties can be set only during creation. </summary>
        /// <param name="trackedResourceModel2SName"> The String to use. </param>
        /// <param name="parameters"> The TrackedResourceModel2 to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public TrackedResourceModel2SPutOperation StartCreateOrUpdate(string trackedResourceModel2SName, TrackedResourceModel2Data parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("TrackedResourceModel2Container.StartCreateOrUpdate");
            scope.Start();
            try
            {
                if (trackedResourceModel2SName == null)
                {
                    throw new ArgumentNullException(nameof(trackedResourceModel2SName));
                }
                if (parameters == null)
                {
                    throw new ArgumentNullException(nameof(parameters));
                }

                var originalResponse = _restClient.Put(Id.ResourceGroupName, trackedResourceModel2SName, parameters, cancellationToken: cancellationToken);
                return new TrackedResourceModel2SPutOperation(Parent, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> The operation to create or update a TrackedResourceModel2. Please note some properties can be set only during creation. </summary>
        /// <param name="trackedResourceModel2SName"> The String to use. </param>
        /// <param name="parameters"> The TrackedResourceModel2 to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async Task<TrackedResourceModel2SPutOperation> StartCreateOrUpdateAsync(string trackedResourceModel2SName, TrackedResourceModel2Data parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("TrackedResourceModel2Container.StartCreateOrUpdate");
            scope.Start();
            try
            {
                if (trackedResourceModel2SName == null)
                {
                    throw new ArgumentNullException(nameof(trackedResourceModel2SName));
                }
                if (parameters == null)
                {
                    throw new ArgumentNullException(nameof(parameters));
                }

                var originalResponse = await _restClient.PutAsync(Id.ResourceGroupName, trackedResourceModel2SName, parameters, cancellationToken: cancellationToken).ConfigureAwait(false);
                return new TrackedResourceModel2SPutOperation(Parent, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        /// <param name="trackedResourceModel2SName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public override Response<TrackedResourceModel2> Get(string trackedResourceModel2SName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("TrackedResourceModel2Container.Get");
            scope.Start();
            try
            {
                if (trackedResourceModel2SName == null)
                {
                    throw new ArgumentNullException(nameof(trackedResourceModel2SName));
                }

                var response = _restClient.Get(Id.ResourceGroupName, trackedResourceModel2SName, cancellationToken: cancellationToken);
                return Response.FromValue(new TrackedResourceModel2(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        /// <param name="trackedResourceModel2SName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async override Task<Response<TrackedResourceModel2>> GetAsync(string trackedResourceModel2SName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("TrackedResourceModel2Container.Get");
            scope.Start();
            try
            {
                if (trackedResourceModel2SName == null)
                {
                    throw new ArgumentNullException(nameof(trackedResourceModel2SName));
                }

                var response = await _restClient.GetAsync(Id.ResourceGroupName, trackedResourceModel2SName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new TrackedResourceModel2(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of TrackedResourceModel2 for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public Pageable<GenericResource> ListAsGenericResource(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("TrackedResourceModel2Container.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(TrackedResourceModel2Operations.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.ListAtContext(Parent as ResourceGroupOperations, filters, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of TrackedResourceModel2 for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<GenericResource> ListAsGenericResourceAsync(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("TrackedResourceModel2Container.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(TrackedResourceModel2Operations.ResourceType);
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
        // public ArmBuilder<ResourceGroupResourceIdentifier, TrackedResourceModel2, TrackedResourceModel2Data> Construct() { }
    }
}

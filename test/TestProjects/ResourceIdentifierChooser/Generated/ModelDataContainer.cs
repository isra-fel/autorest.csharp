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

namespace ResourceIdentifierChooser
{
    /// <summary> A class representing collection of ModelData and their operations over a ResourceGroup. </summary>
    public partial class ModelDataContainer : ResourceContainerBase<ResourceGroupResourceIdentifier, ModelData, ModelDataData>
    {
        /// <summary> Initializes a new instance of the <see cref="ModelDataContainer"/> class for mocking. </summary>
        protected ModelDataContainer()
        {
        }

        /// <summary> Initializes a new instance of ModelDataContainer class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal ModelDataContainer(ResourceOperationsBase parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
        }

        private readonly ClientDiagnostics _clientDiagnostics;

        /// <summary> Represents the REST operations. </summary>
        private ModelDatasRestOperations _restClient => new ModelDatasRestOperations(_clientDiagnostics, Pipeline, Id.SubscriptionId);

        /// <summary> Typed Resource Identifier for the container. </summary>
        public new ResourceGroupResourceIdentifier Id => base.Id as ResourceGroupResourceIdentifier;

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => ResourceGroupOperations.ResourceType;

        // Container level operations.

        /// <summary> The operation to create or update a ModelData. Please note some properties can be set only during creation. </summary>
        /// <param name="modelDatasName"> The String to use. </param>
        /// <param name="parameters"> The ModelData to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public Response<ModelData> CreateOrUpdate(string modelDatasName, ModelDataData parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ModelDataContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                if (modelDatasName == null)
                {
                    throw new ArgumentNullException(nameof(modelDatasName));
                }
                if (parameters == null)
                {
                    throw new ArgumentNullException(nameof(parameters));
                }

                return StartCreateOrUpdate(modelDatasName, parameters, cancellationToken: cancellationToken).WaitForCompletion(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> The operation to create or update a ModelData. Please note some properties can be set only during creation. </summary>
        /// <param name="modelDatasName"> The String to use. </param>
        /// <param name="parameters"> The ModelData to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async Task<Response<ModelData>> CreateOrUpdateAsync(string modelDatasName, ModelDataData parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ModelDataContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                if (modelDatasName == null)
                {
                    throw new ArgumentNullException(nameof(modelDatasName));
                }
                if (parameters == null)
                {
                    throw new ArgumentNullException(nameof(parameters));
                }

                var operation = await StartCreateOrUpdateAsync(modelDatasName, parameters, cancellationToken: cancellationToken).ConfigureAwait(false);
                return await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> The operation to create or update a ModelData. Please note some properties can be set only during creation. </summary>
        /// <param name="modelDatasName"> The String to use. </param>
        /// <param name="parameters"> The ModelData to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public ModelDatasPutOperation StartCreateOrUpdate(string modelDatasName, ModelDataData parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ModelDataContainer.StartCreateOrUpdate");
            scope.Start();
            try
            {
                if (modelDatasName == null)
                {
                    throw new ArgumentNullException(nameof(modelDatasName));
                }
                if (parameters == null)
                {
                    throw new ArgumentNullException(nameof(parameters));
                }

                var originalResponse = _restClient.Put(Id.ResourceGroupName, modelDatasName, parameters, cancellationToken: cancellationToken);
                return new ModelDatasPutOperation(Parent, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> The operation to create or update a ModelData. Please note some properties can be set only during creation. </summary>
        /// <param name="modelDatasName"> The String to use. </param>
        /// <param name="parameters"> The ModelData to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async Task<ModelDatasPutOperation> StartCreateOrUpdateAsync(string modelDatasName, ModelDataData parameters, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ModelDataContainer.StartCreateOrUpdate");
            scope.Start();
            try
            {
                if (modelDatasName == null)
                {
                    throw new ArgumentNullException(nameof(modelDatasName));
                }
                if (parameters == null)
                {
                    throw new ArgumentNullException(nameof(parameters));
                }

                var originalResponse = await _restClient.PutAsync(Id.ResourceGroupName, modelDatasName, parameters, cancellationToken: cancellationToken).ConfigureAwait(false);
                return new ModelDatasPutOperation(Parent, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        /// <param name="modelDatasName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public override Response<ModelData> Get(string modelDatasName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ModelDataContainer.Get");
            scope.Start();
            try
            {
                if (modelDatasName == null)
                {
                    throw new ArgumentNullException(nameof(modelDatasName));
                }

                var response = _restClient.Get(Id.ResourceGroupName, modelDatasName, cancellationToken: cancellationToken);
                return Response.FromValue(new ModelData(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        /// <param name="modelDatasName"> The String to use. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async override Task<Response<ModelData>> GetAsync(string modelDatasName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ModelDataContainer.Get");
            scope.Start();
            try
            {
                if (modelDatasName == null)
                {
                    throw new ArgumentNullException(nameof(modelDatasName));
                }

                var response = await _restClient.GetAsync(Id.ResourceGroupName, modelDatasName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new ModelData(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of ModelData for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public Pageable<GenericResource> ListAsGenericResource(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ModelDataContainer.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(ModelDataOperations.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.ListAtContext(Parent as ResourceGroupOperations, filters, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of ModelData for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<GenericResource> ListAsGenericResourceAsync(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ModelDataContainer.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(ModelDataOperations.ResourceType);
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
        // public ArmBuilder<ResourceGroupResourceIdentifier, ModelData, ModelDataData> Construct() { }
    }
}

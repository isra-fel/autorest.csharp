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
using Azure.Management.Storage.Models;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Core.Resources;

namespace Azure.Management.Storage
{
    /// <summary> A class representing collection of ObjectReplicationPolicy and their operations over a StorageAccount. </summary>
    public partial class ObjectReplicationPolicyContainer : ResourceContainerBase<ResourceGroupResourceIdentifier, ObjectReplicationPolicy, ObjectReplicationPolicyData>
    {
        /// <summary> Initializes a new instance of the <see cref="ObjectReplicationPolicyContainer"/> class for mocking. </summary>
        protected ObjectReplicationPolicyContainer()
        {
        }

        /// <summary> Initializes a new instance of ObjectReplicationPolicyContainer class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal ObjectReplicationPolicyContainer(ResourceOperationsBase parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
        }

        private readonly ClientDiagnostics _clientDiagnostics;

        /// <summary> Represents the REST operations. </summary>
        private ObjectReplicationPoliciesRestOperations _restClient => new ObjectReplicationPoliciesRestOperations(_clientDiagnostics, Pipeline, Id.SubscriptionId);

        /// <summary> Typed Resource Identifier for the container. </summary>
        public new ResourceGroupResourceIdentifier Id => base.Id as ResourceGroupResourceIdentifier;

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => StorageAccountOperations.ResourceType;

        // Container level operations.

        /// <summary> The operation to create or update a ObjectReplicationPolicy. Please note some properties can be set only during creation. </summary>
        /// <param name="objectReplicationPolicyId"> The ID of object replication policy or &apos;default&apos; if the policy ID is unknown. </param>
        /// <param name="properties"> The object replication policy set to a storage account. A unique policy ID will be created if absent. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public Response<ObjectReplicationPolicy> CreateOrUpdate(string objectReplicationPolicyId, ObjectReplicationPolicyData properties, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ObjectReplicationPolicyContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                if (objectReplicationPolicyId == null)
                {
                    throw new ArgumentNullException(nameof(objectReplicationPolicyId));
                }
                if (properties == null)
                {
                    throw new ArgumentNullException(nameof(properties));
                }

                return StartCreateOrUpdate(objectReplicationPolicyId, properties, cancellationToken: cancellationToken).WaitForCompletion(cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> The operation to create or update a ObjectReplicationPolicy. Please note some properties can be set only during creation. </summary>
        /// <param name="objectReplicationPolicyId"> The ID of object replication policy or &apos;default&apos; if the policy ID is unknown. </param>
        /// <param name="properties"> The object replication policy set to a storage account. A unique policy ID will be created if absent. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async Task<Response<ObjectReplicationPolicy>> CreateOrUpdateAsync(string objectReplicationPolicyId, ObjectReplicationPolicyData properties, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ObjectReplicationPolicyContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                if (objectReplicationPolicyId == null)
                {
                    throw new ArgumentNullException(nameof(objectReplicationPolicyId));
                }
                if (properties == null)
                {
                    throw new ArgumentNullException(nameof(properties));
                }

                var operation = await StartCreateOrUpdateAsync(objectReplicationPolicyId, properties, cancellationToken: cancellationToken).ConfigureAwait(false);
                return await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> The operation to create or update a ObjectReplicationPolicy. Please note some properties can be set only during creation. </summary>
        /// <param name="objectReplicationPolicyId"> The ID of object replication policy or &apos;default&apos; if the policy ID is unknown. </param>
        /// <param name="properties"> The object replication policy set to a storage account. A unique policy ID will be created if absent. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public ObjectReplicationPoliciesCreateOrUpdateOperation StartCreateOrUpdate(string objectReplicationPolicyId, ObjectReplicationPolicyData properties, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ObjectReplicationPolicyContainer.StartCreateOrUpdate");
            scope.Start();
            try
            {
                if (objectReplicationPolicyId == null)
                {
                    throw new ArgumentNullException(nameof(objectReplicationPolicyId));
                }
                if (properties == null)
                {
                    throw new ArgumentNullException(nameof(properties));
                }

                var originalResponse = _restClient.CreateOrUpdate(Id.ResourceGroupName, Id.Name, objectReplicationPolicyId, properties, cancellationToken: cancellationToken);
                return new ObjectReplicationPoliciesCreateOrUpdateOperation(Parent, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> The operation to create or update a ObjectReplicationPolicy. Please note some properties can be set only during creation. </summary>
        /// <param name="objectReplicationPolicyId"> The ID of object replication policy or &apos;default&apos; if the policy ID is unknown. </param>
        /// <param name="properties"> The object replication policy set to a storage account. A unique policy ID will be created if absent. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async Task<ObjectReplicationPoliciesCreateOrUpdateOperation> StartCreateOrUpdateAsync(string objectReplicationPolicyId, ObjectReplicationPolicyData properties, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ObjectReplicationPolicyContainer.StartCreateOrUpdate");
            scope.Start();
            try
            {
                if (objectReplicationPolicyId == null)
                {
                    throw new ArgumentNullException(nameof(objectReplicationPolicyId));
                }
                if (properties == null)
                {
                    throw new ArgumentNullException(nameof(properties));
                }

                var originalResponse = await _restClient.CreateOrUpdateAsync(Id.ResourceGroupName, Id.Name, objectReplicationPolicyId, properties, cancellationToken: cancellationToken).ConfigureAwait(false);
                return new ObjectReplicationPoliciesCreateOrUpdateOperation(Parent, originalResponse);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        /// <param name="objectReplicationPolicyId"> The ID of object replication policy or &apos;default&apos; if the policy ID is unknown. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public override Response<ObjectReplicationPolicy> Get(string objectReplicationPolicyId, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ObjectReplicationPolicyContainer.Get");
            scope.Start();
            try
            {
                if (objectReplicationPolicyId == null)
                {
                    throw new ArgumentNullException(nameof(objectReplicationPolicyId));
                }

                var response = _restClient.Get(Id.ResourceGroupName, Id.Name, objectReplicationPolicyId, cancellationToken: cancellationToken);
                return Response.FromValue(new ObjectReplicationPolicy(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        /// <param name="objectReplicationPolicyId"> The ID of object replication policy or &apos;default&apos; if the policy ID is unknown. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        public async override Task<Response<ObjectReplicationPolicy>> GetAsync(string objectReplicationPolicyId, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ObjectReplicationPolicyContainer.Get");
            scope.Start();
            try
            {
                if (objectReplicationPolicyId == null)
                {
                    throw new ArgumentNullException(nameof(objectReplicationPolicyId));
                }

                var response = await _restClient.GetAsync(Id.ResourceGroupName, Id.Name, objectReplicationPolicyId, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(new ObjectReplicationPolicy(Parent, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> List the object replication policies associated with the storage account. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="ObjectReplicationPolicy" /> that may take multiple service requests to iterate over. </returns>
        public Pageable<ObjectReplicationPolicy> List(CancellationToken cancellationToken = default)
        {
            Page<ObjectReplicationPolicy> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("ObjectReplicationPolicyContainer.List");
                scope.Start();
                try
                {
                    var response = _restClient.List(Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new ObjectReplicationPolicy(Parent, value)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, null);
        }

        /// <summary> List the object replication policies associated with the storage account. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="ObjectReplicationPolicy" /> that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<ObjectReplicationPolicy> ListAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<ObjectReplicationPolicy>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("ObjectReplicationPolicyContainer.List");
                scope.Start();
                try
                {
                    var response = await _restClient.ListAsync(Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new ObjectReplicationPolicy(Parent, value)), null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, null);
        }

        /// <summary> Filters the list of ObjectReplicationPolicy for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public Pageable<GenericResource> ListAsGenericResource(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ObjectReplicationPolicyContainer.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(ObjectReplicationPolicyOperations.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.ListAtContext(Parent as ResourceGroupOperations, filters, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of ObjectReplicationPolicy for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<GenericResource> ListAsGenericResourceAsync(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ObjectReplicationPolicyContainer.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(ObjectReplicationPolicyOperations.ResourceType);
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
        // public ArmBuilder<ResourceGroupResourceIdentifier, ObjectReplicationPolicy, ObjectReplicationPolicyData> Construct() { }
    }
}

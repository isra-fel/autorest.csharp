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
using Azure.Management.Storage.Models;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Core.Resources;

namespace Azure.Management.Storage
{
    /// <summary> A class representing collection of ObjectReplicationPolicy and their operations over a [ParentResource]. </summary>
    public partial class ObjectReplicationPolicyContainer : ResourceContainerBase<TenantResourceIdentifier, ObjectReplicationPolicy, ObjectReplicationPolicyData>
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
            _pipeline = ManagementPipelineBuilder.Build(Credential, BaseUri, ClientOptions);
        }

        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;

        /// <summary> Represents the REST operations. </summary>
        private ObjectReplicationPoliciesRestOperations Operations => new ObjectReplicationPoliciesRestOperations(_clientDiagnostics, _pipeline, Id.SubscriptionId);

        /// <summary> Typed Resource Identifier for the container. </summary>
        // todo: hard coding ResourceGroupResourceIdentifier we don't know the exact ID type but we need it in implementations in CreateOrUpdate() etc.
        public new ResourceGroupResourceIdentifier Id => base.Id as ResourceGroupResourceIdentifier;
        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => StorageAccountOperations.ResourceType;

        // Container level operations.

        /// <inheritdoc />
        /// <param name="objectReplicationPolicyId"> The ID of object replication policy or &apos;default&apos; if the policy ID is unknown. </param>
        /// <param name="properties"> The object replication policy set to a storage account. A unique policy ID will be created if absent. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public ArmResponse<ObjectReplicationPolicy> CreateOrUpdate(string objectReplicationPolicyId, ObjectReplicationPolicyData properties, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ObjectReplicationPolicyContainer.CreateOrUpdate");
            scope.Start();
            try
            {
                return StartCreateOrUpdate(objectReplicationPolicyId, properties, cancellationToken: cancellationToken).WaitForCompletion() as ArmResponse<ObjectReplicationPolicy>;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        /// <param name="objectReplicationPolicyId"> The ID of object replication policy or &apos;default&apos; if the policy ID is unknown. </param>
        /// <param name="properties"> The object replication policy set to a storage account. A unique policy ID will be created if absent. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public async Task<ArmResponse<ObjectReplicationPolicy>> CreateOrUpdateAsync(string objectReplicationPolicyId, ObjectReplicationPolicyData properties, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ObjectReplicationPolicyContainer.CreateOrUpdateAsync");
            scope.Start();
            try
            {
                var operation = await StartCreateOrUpdateAsync(objectReplicationPolicyId, properties, cancellationToken: cancellationToken).ConfigureAwait(false);
                return operation.WaitForCompletion() as ArmResponse<ObjectReplicationPolicy>;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        /// <param name="objectReplicationPolicyId"> The ID of object replication policy or &apos;default&apos; if the policy ID is unknown. </param>
        /// <param name="properties"> The object replication policy set to a storage account. A unique policy ID will be created if absent. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public ArmOperation<ObjectReplicationPolicy> StartCreateOrUpdate(string objectReplicationPolicyId, ObjectReplicationPolicyData properties, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ObjectReplicationPolicyContainer.StartCreateOrUpdate");
            scope.Start();
            try
            {
                var originalResponse = Operations.CreateOrUpdate(Id.ResourceGroupName, Id.Name, objectReplicationPolicyId, properties, cancellationToken: cancellationToken);
                return new PhArmOperation<ObjectReplicationPolicy, ObjectReplicationPolicyData>(
                originalResponse,
                data => new ObjectReplicationPolicy(Parent, data));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        /// <param name="objectReplicationPolicyId"> The ID of object replication policy or &apos;default&apos; if the policy ID is unknown. </param>
        /// <param name="properties"> The object replication policy set to a storage account. A unique policy ID will be created if absent. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public async Task<ArmOperation<ObjectReplicationPolicy>> StartCreateOrUpdateAsync(string objectReplicationPolicyId, ObjectReplicationPolicyData properties, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ObjectReplicationPolicyContainer.StartCreateOrUpdateAsync");
            scope.Start();
            try
            {
                var originalResponse = await Operations.CreateOrUpdateAsync(Id.ResourceGroupName, Id.Name, objectReplicationPolicyId, properties, cancellationToken: cancellationToken).ConfigureAwait(false);
                return new PhArmOperation<ObjectReplicationPolicy, ObjectReplicationPolicyData>(
                originalResponse,
                data => new ObjectReplicationPolicy(Parent, data));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        /// <param name="objectReplicationPolicyId"> The ID of object replication policy or &apos;default&apos; if the policy ID is unknown. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public override ArmResponse<ObjectReplicationPolicy> Get(string objectReplicationPolicyId, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ObjectReplicationPolicyContainer.Get");
            scope.Start();
            try
            {
                return new PhArmResponse<ObjectReplicationPolicy, ObjectReplicationPolicyData>(
                Operations.Get(Id.ResourceGroupName, Id.Name, objectReplicationPolicyId, cancellationToken: cancellationToken),
                data => new ObjectReplicationPolicy(Parent, data));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        /// <param name="objectReplicationPolicyId"> The ID of object replication policy or &apos;default&apos; if the policy ID is unknown. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public async override Task<ArmResponse<ObjectReplicationPolicy>> GetAsync(string objectReplicationPolicyId, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ObjectReplicationPolicyContainer.GetAsync");
            scope.Start();
            try
            {
                return new PhArmResponse<ObjectReplicationPolicy, ObjectReplicationPolicyData>(
                await Operations.GetAsync(Id.ResourceGroupName, Id.Name, objectReplicationPolicyId, cancellationToken: cancellationToken),
                data => new ObjectReplicationPolicy(Parent, data));
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
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
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
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<GenericResource> ListAsGenericResourceAsync(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ObjectReplicationPolicyContainer.ListAsGenericResourceAsync");
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

        /// <summary> Filters the list of <see cref="ObjectReplicationPolicy" /> for this resource group. Makes an additional network call to retrieve the full data model for each resource group. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of <see cref="ObjectReplicationPolicy" /> that may take multiple service requests to iterate over. </returns>
        public Pageable<ObjectReplicationPolicy> List(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ObjectReplicationPolicyContainer.List");
            scope.Start();
            try
            {
                var results = ListAsGenericResource(nameFilter, top, cancellationToken);
                return new PhWrappingPageable<GenericResource, ObjectReplicationPolicy>(results, genericResource => new ObjectReplicationPolicyOperations(genericResource).Get().Value);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="ObjectReplicationPolicy" /> for this resource group. Makes an additional network call to retrieve the full data model for each resource group. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of <see cref="ObjectReplicationPolicy" /> that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<ObjectReplicationPolicy> ListAsync(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("ObjectReplicationPolicyContainer.ListAsync");
            scope.Start();
            try
            {
                var results = ListAsGenericResourceAsync(nameFilter, top, cancellationToken);
                return new PhWrappingAsyncPageable<GenericResource, ObjectReplicationPolicy>(results, genericResource => new ObjectReplicationPolicyOperations(genericResource).Get().Value);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        // Builders.
        // public ArmBuilder<TenantResourceIdentifier, ObjectReplicationPolicy, ObjectReplicationPolicyData> Construct() { }
    }
}

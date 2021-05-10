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

namespace TenantOnly
{
    /// <summary> A class representing collection of Agreement and their operations over a BillingAccount. </summary>
    public partial class AgreementContainer : ResourceContainerBase<TenantResourceIdentifier, Agreement, AgreementData>
    {
        /// <summary> Initializes a new instance of the <see cref="AgreementContainer"/> class for mocking. </summary>
        protected AgreementContainer()
        {
        }

        /// <summary> Initializes a new instance of AgreementContainer class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal AgreementContainer(ResourceOperationsBase parent) : base(parent)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
            _pipeline = ManagementPipelineBuilder.Build(Credential, BaseUri, ClientOptions);
        }

        private readonly ClientDiagnostics _clientDiagnostics;
        private readonly HttpPipeline _pipeline;

        /// <summary> Represents the REST operations. </summary>
        private AgreementsRestOperations _restClient => new AgreementsRestOperations(_clientDiagnostics, _pipeline);

        /// <summary> Typed Resource Identifier for the container. </summary>
        public new ResourceGroupResourceIdentifier Id => base.Id as ResourceGroupResourceIdentifier;

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => BillingAccountOperations.ResourceType;

        // Container level operations.

        /// <inheritdoc />
        /// <param name="agreementName"> The ID that uniquely identifies an agreement. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public override ArmResponse<Agreement> Get(string agreementName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("AgreementContainer.Get");
            scope.Start();
            try
            {
                if (agreementName == null)
                {
                    throw new ArgumentNullException(nameof(agreementName));
                }

                var response = _restClient.Get(Id.Parent.Name, agreementName, cancellationToken: cancellationToken);
                return ArmResponse.FromValue(new Agreement(Parent, response.Value), ArmResponse.FromResponse(response.GetRawResponse()));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <inheritdoc />
        /// <param name="agreementName"> The ID that uniquely identifies an agreement. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        public async override Task<ArmResponse<Agreement>> GetAsync(string agreementName, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("AgreementContainer.Get");
            scope.Start();
            try
            {
                if (agreementName == null)
                {
                    throw new ArgumentNullException(nameof(agreementName));
                }

                var response = await _restClient.GetAsync(Id.Parent.Name, agreementName, cancellationToken: cancellationToken);
                return ArmResponse.FromValue(new Agreement(Parent, response.Value), ArmResponse.FromResponse(response.GetRawResponse()));
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of Agreement for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of resource that may take multiple service requests to iterate over. </returns>
        public Pageable<GenericResource> ListAsGenericResource(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("AgreementContainer.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(AgreementOperations.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.ListAtContext(Parent as ResourceGroupOperations, filters, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of Agreement for this resource group represented as generic resources. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of resource that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<GenericResource> ListAsGenericResourceAsync(string nameFilter, int? top = null, CancellationToken cancellationToken = default)
        {
            using var scope = _clientDiagnostics.CreateScope("AgreementContainer.ListAsGenericResource");
            scope.Start();
            try
            {
                var filters = new ResourceFilterCollection(AgreementOperations.ResourceType);
                filters.SubstringFilter = nameFilter;
                return ResourceListOperations.ListAtContextAsync(Parent as ResourceGroupOperations, filters, top, cancellationToken);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Filters the list of <see cref="Agreement" /> for this resource group. Makes an additional network call to retrieve the full data model for each resource group. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of <see cref="Agreement" /> that may take multiple service requests to iterate over. </returns>
        public Pageable<Agreement> List(string nameFilter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            var results = ListAsGenericResource(nameFilter, top, cancellationToken);
            return new PhWrappingPageable<GenericResource, Agreement>(results, genericResource => new AgreementOperations(genericResource).Get().Value);
        }

        /// <summary> Filters the list of <see cref="Agreement" /> for this resource group. Makes an additional network call to retrieve the full data model for each resource group. </summary>
        /// <param name="nameFilter"> The filter used in this operation. </param>
        /// <param name="top"> The number of results to return. </param>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P:System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of <see cref="Agreement" /> that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<Agreement> ListAsync(string nameFilter = null, int? top = null, CancellationToken cancellationToken = default)
        {
            var results = ListAsGenericResourceAsync(nameFilter, top, cancellationToken);
            return new PhWrappingAsyncPageable<GenericResource, Agreement>(results, genericResource => new AgreementOperations(genericResource).Get().Value);
        }

        // Builders.
        // public ArmBuilder<TenantResourceIdentifier, Agreement, AgreementData> Construct() { }
    }
}

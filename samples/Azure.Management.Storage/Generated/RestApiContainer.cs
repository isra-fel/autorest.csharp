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

namespace Azure.Management.Storage
{
    public partial class RestApiContainer : ContainerBase
    {
        private readonly ClientDiagnostics _clientDiagnostics;

        /// <summary> Represents the REST operations. </summary>
        private RestOperations _restClient => new RestOperations(_clientDiagnostics, Pipeline);

        /// <summary> Initializes a new instance of the <see cref="RestApiContainer"/> class for mocking. </summary>
        protected RestApiContainer()
        {
        }

        /// <summary> Initializes a new instance of RestApiContainer class. </summary>
        /// <param name="parent"> The resource representing the parent resource. </param>
        internal RestApiContainer(ClientContext parent) : base(parent.ClientOptions, parent.Credential, parent.BaseUri, parent.Pipeline)
        {
            _clientDiagnostics = new ClientDiagnostics(ClientOptions);
        }

        /// <summary> Gets the valid resource type for this object. </summary>
        protected override ResourceType ValidResourceType => ResourceIdentifier.RootResourceIdentifier.ResourceType;

        /// <summary> Lists all of the available Storage Rest API operations. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="RestApi" /> that may take multiple service requests to iterate over. </returns>
        public Pageable<RestApi> List(CancellationToken cancellationToken = default)
        {
            Page<RestApi> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("RestApi.List");
                scope.Start();
                try
                {
                    var response = _restClient.List(cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, null);
        }

        /// <summary> Lists all of the available Storage Rest API operations. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="RestApi" /> that may take multiple service requests to iterate over. </returns>
        public AsyncPageable<RestApi> ListAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<RestApi>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _clientDiagnostics.CreateScope("RestApi.List");
                scope.Start();
                try
                {
                    var response = await _restClient.ListAsync(cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, null, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, null);
        }
    }
}

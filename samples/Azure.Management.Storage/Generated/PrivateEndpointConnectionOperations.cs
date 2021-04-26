// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.Core;

namespace Azure.Management.Storage
{
    /// <summary> A class representing the operations that can be performed over a specific PrivateEndpointConnection. </summary>
    public partial class PrivateEndpointConnectionOperations : ResourceOperationsBase<TenantResourceIdentifier, PrivateEndpointConnection>
    {
        /// <summary> Initializes a new instance of the <see cref="PrivateEndpointConnectionOperations"/> class. </summary>
        /// <param name="genericOperations"> An instance of <see cref="GenericResourceOperations"/> that has an id for a {todo: availability set}. </param>
        internal PrivateEndpointConnectionOperations(GenericResourceOperations genericOperations) : base(genericOperations, genericOperations.Id)
        {
        }

        /// <summary> Initializes a new instance of the <see cref="PrivateEndpointConnectionOperations"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        protected PrivateEndpointConnectionOperations(ResourceOperationsBase options, ResourceIdentifier id) : base(options, id)
        {
        }

        /// <summary> Initializes a new instance of the <see cref="PrivateEndpointConnectionOperations"/> class. </summary>
        internal PrivateEndpointConnectionOperations()
        {
        }

        public static readonly ResourceType ResourceType = "Microsoft.Storage/storageAccounts/privateEndpointConnections";
        protected override ResourceType ValidResourceType => ResourceType;

        /// <inheritdoc />
        public override ArmResponse<PrivateEndpointConnection> Get(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <inheritdoc />
        public override Task<ArmResponse<PrivateEndpointConnection>> GetAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        /// <summary> Lists all available geo-locations. </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P: System.Threading.CancellationToken.None" />. </param>
        /// <returns> A collection of location that may take multiple service requests to iterate over. </returns>
        public IEnumerable<LocationData> ListAvailableLocations(CancellationToken cancellationToken = default)
        {
            return ListAvailableLocations(ResourceType);
        }

        /// <summary> Lists all available geo-locations. </summary>
        /// <param name="cancellationToken"> A token to allow the caller to cancel the call to the service. The default value is <see cref="P: System.Threading.CancellationToken.None" />. </param>
        /// <returns> An async collection of location that may take multiple service requests to iterate over. </returns>
        /// <exception cref="InvalidOperationException"> The default subscription id is null. </exception>
        public async Task<IEnumerable<LocationData>> ListAvailableLocationsAsync(CancellationToken cancellationToken = default)
        {
            return await ListAvailableLocationsAsync(ResourceType, cancellationToken);
        }
    }
}

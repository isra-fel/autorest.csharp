// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Threading;
using System.Threading.Tasks;
using Azure.ResourceManager.Core;

namespace SupersetInheritance
{
    /// <summary> A Class representing a SupersetModel4 along with the instance operations that can be performed on it. </summary>
    public class SupersetModel4 : SupersetModel4Operations
    {
        /// <summary> Initializes a new instance of the <see cref = "SupersetModel4"/> class. </summary>
        /// <param name="options"> The client parameters to use in these operations. </param>
        /// <param name="resource"> The resource that is the target of operations. </param>
        internal SupersetModel4(ResourceOperationsBase options, SupersetModel4Data resource) : base(options, resource.Id)
        {
            Data = resource;
        }

        /// <summary> Gets or sets the SupersetModel4Data. </summary>
        public SupersetModel4Data Data { get; private set; }

        /// <inheritdoc />
        protected override SupersetModel4 GetResource(CancellationToken cancellation = default)
        {
            return this;
        }

        /// <inheritdoc />
        protected override Task<SupersetModel4> GetResourceAsync(CancellationToken cancellation = default)
        {
            return Task.FromResult(this);
        }
    }
}

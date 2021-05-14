// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Management.Storage.Models;
using Azure.ResourceManager.Core;

namespace Azure.Management.Storage
{
    /// <summary> Sets the properties of file services in storage accounts, including CORS (Cross-Origin Resource Sharing) rules. </summary>
    public partial class FileServicesSetServicePropertiesOperation : Operation<FileService>
    {
        private readonly OperationOrResponseInternals<FileService> _operation;

        /// <summary> Initializes a new instance of FileServicesSetServicePropertiesOperation for mocking. </summary>
        protected FileServicesSetServicePropertiesOperation()
        {
        }

        internal FileServicesSetServicePropertiesOperation(ResourceOperationsBase operationsBase, Response<FileServiceData> response)
        {
            _operation = new OperationOrResponseInternals<FileService>(Response.FromValue(new FileService(operationsBase, response.Value), response.GetRawResponse()));
        }
        /// <inheritdoc />
        public override string Id => _operation.Id;

        /// <inheritdoc />
        public override FileService Value => _operation.Value;

        /// <inheritdoc />
        public override bool HasCompleted => _operation.HasCompleted;

        /// <inheritdoc />
        public override bool HasValue => _operation.HasValue;

        /// <inheritdoc />
        public override Response GetRawResponse() => _operation.GetRawResponse();

        /// <inheritdoc />
        public override Response UpdateStatus(CancellationToken cancellationToken = default) => _operation.UpdateStatus(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) => _operation.UpdateStatusAsync(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<FileService>> WaitForCompletionAsync(CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<FileService>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(pollingInterval, cancellationToken);
    }
}

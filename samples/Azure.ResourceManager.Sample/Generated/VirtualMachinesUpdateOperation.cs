// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Core;

namespace Azure.ResourceManager.Sample
{
    /// <summary> The operation to update a virtual machine. </summary>
    public partial class VirtualMachinesUpdateOperation : Operation<VirtualMachine>, IOperationSource<VirtualMachine>
    {
        private readonly OperationInternals<VirtualMachine> _operation;

        private readonly ResourceOperationsBase _operationBase;

        /// <summary> Initializes a new instance of VirtualMachinesUpdateOperation for mocking. </summary>
        protected VirtualMachinesUpdateOperation()
        {
        }

        internal VirtualMachinesUpdateOperation(ResourceOperationsBase operationsBase, ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Request request, Response response)
        {
            _operation = new OperationInternals<VirtualMachine>(this, clientDiagnostics, pipeline, request, response, OperationFinalStateVia.Location, "VirtualMachinesUpdateOperation");
            _operationBase = operationsBase;
        }

        /// <inheritdoc />
        public override string Id => _operation.Id;

        /// <inheritdoc />
        public override VirtualMachine Value => _operation.Value;

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
        public override ValueTask<Response<VirtualMachine>> WaitForCompletionAsync(CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<VirtualMachine>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(pollingInterval, cancellationToken);

        VirtualMachine IOperationSource<VirtualMachine>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            return new VirtualMachine(_operationBase, VirtualMachineData.DeserializeVirtualMachineData(document.RootElement));
        }

        async ValueTask<VirtualMachine> IOperationSource<VirtualMachine>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            return new VirtualMachine(_operationBase, VirtualMachineData.DeserializeVirtualMachineData(document.RootElement));
        }
    }
}

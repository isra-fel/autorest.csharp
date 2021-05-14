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

namespace Azure.ResourceManager.Sample
{
    /// <summary> The operation to update the VMSS VM extension. </summary>
    public partial class VirtualMachineScaleSetVMExtensionsUpdateOperation : Operation<VirtualMachineExtensionData>, IOperationSource<VirtualMachineExtensionData>
    {
        private readonly OperationInternals<VirtualMachineExtensionData> _operation;

        /// <summary> Initializes a new instance of VirtualMachineScaleSetVMExtensionsUpdateOperation for mocking. </summary>
        protected VirtualMachineScaleSetVMExtensionsUpdateOperation()
        {
        }

        internal VirtualMachineScaleSetVMExtensionsUpdateOperation(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Request request, Response response)
        {
            _operation = new OperationInternals<VirtualMachineExtensionData>(this, clientDiagnostics, pipeline, request, response, OperationFinalStateVia.Location, "VirtualMachineScaleSetVMExtensionsUpdateOperation");
        }
        /// <inheritdoc />
        public override string Id => _operation.Id;

        /// <inheritdoc />
        public override VirtualMachineExtensionData Value => _operation.Value;

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
        public override ValueTask<Response<VirtualMachineExtensionData>> WaitForCompletionAsync(CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(cancellationToken);

        /// <inheritdoc />
        public override ValueTask<Response<VirtualMachineExtensionData>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(pollingInterval, cancellationToken);

        VirtualMachineExtensionData IOperationSource<VirtualMachineExtensionData>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            return VirtualMachineExtensionData.DeserializeVirtualMachineExtensionData(document.RootElement);
        }

        async ValueTask<VirtualMachineExtensionData> IOperationSource<VirtualMachineExtensionData>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            return VirtualMachineExtensionData.DeserializeVirtualMachineExtensionData(document.RootElement);
        }
    }
}

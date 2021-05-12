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
    public partial class VirtualMachineDeallocateOperation : Operation<VirtualMachineData>, IOperationSource<VirtualMachineData>
    {
        private readonly OperationInternals<VirtualMachineData> _operation;
        protected VirtualMachineDeallocateOperation()
        {
        }
        internal VirtualMachineDeallocateOperation(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, Request request, Response response)
        {
            _operation = new OperationInternals<VirtualMachineData>(this, clientDiagnostics, pipeline, request, response, OperationFinalStateVia.Location, "VirtualMachineDeallocateOperation");
        }
        public override string Id => _operation.Id;
        public override VirtualMachineData Value => _operation.Value;
        public override bool HasCompleted => _operation.HasCompleted;
        public override bool HasValue => _operation.HasValue;
        public override Response GetRawResponse() => _operation.GetRawResponse();
        public override Response UpdateStatus(CancellationToken cancellationToken = default) => _operation.UpdateStatus(cancellationToken);
        public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) => _operation.UpdateStatusAsync(cancellationToken);
        public override ValueTask<Response<VirtualMachineData>> WaitForCompletionAsync(CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(cancellationToken);
        public override ValueTask<Response<VirtualMachineData>> WaitForCompletionAsync(TimeSpan pollingInterval, CancellationToken cancellationToken = default) => _operation.WaitForCompletionAsync(pollingInterval, cancellationToken);
        VirtualMachineData IOperationSource<VirtualMachineData>.CreateResult(Response response, CancellationToken cancellationToken)
        {
            using var document = JsonDocument.Parse(response.ContentStream);
            return VirtualMachineData.DeserializeVirtualMachineData(document.RootElement);
        }
        async ValueTask<VirtualMachineData> IOperationSource<VirtualMachineData>.CreateResultAsync(Response response, CancellationToken cancellationToken)
        {
            using var document = await JsonDocument.ParseAsync(response.ContentStream, default, cancellationToken).ConfigureAwait(false);
            return VirtualMachineData.DeserializeVirtualMachineData(document.RootElement);
        }
    }
}

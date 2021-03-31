// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text;
using AutoRest.CSharp.Output.Models;
using Azure.Core.Pipeline;

namespace AutoRest.CSharp.Generation.Writers
{
    internal class ResourceOperationWriter
    {
        private const string ClientDiagnosticsVariable = "clientDiagnostics";
        private const string PipelineVariable = "pipeline";

        public void WriteClient(CodeWriter writer, ResourceOperation resourceOperation)
        {
            writer.UseNamespaces(new string[]
            {
                "System.Threading",
                "System.Threading.Tasks",
                "Azure.ResourceManager.Core"
            });
            var cs = resourceOperation.Type;
            var @namespace = cs.Namespace;
            using (writer.Namespace(@namespace))
            {
                writer.WriteXmlDocumentationSummary(resourceOperation.Description);
                // todo: do not hard code ResourceGroupResourceIdentifier
                using (writer.Scope($"{resourceOperation.Declaration.Accessibility} partial class {cs.Name} : ResourceOperationsBase<ResourceGroupResourceIdentifier, {resourceOperation.ResourceDefaultName}>"))
                {
                    WriteClientCtors(writer, resourceOperation);
                    WriteValidResourceType(writer, resourceOperation);
                    WriteOperations(writer, resourceOperation);
                }
            }
        }

        private void WriteClientCtors(CodeWriter writer, ResourceOperation resourceOperation)
        {
            writer.WriteXmlDocumentationSummary($"Initializes a new instance of the <see cref=\"{resourceOperation.Type.Name:D}\"/> class.");
            writer.WriteXmlDocumentationParameter("options", "The client parameters to use in these operations.");
            writer.WriteXmlDocumentationParameter("id", "The identifier of the resource that is the target of operations.");
            // todo: do not hard code ResourceGroupResourceIdentifier
            using (writer.Scope($"protected {resourceOperation.Type.Name:D}(ResourceOperationsBase options, ResourceGroupResourceIdentifier id) : base(options, id)"))
            {
            }
        }

        private void WriteValidResourceType(CodeWriter writer, ResourceOperation resourceOperation)
        {
            writer.Line();
            writer.WriteXmlDocumentationInheritDoc();
            // todo: do not throw
            writer.Line($"protected override ResourceType ValidResourceType => throw new System.NotImplementedException();");
        }

        private void WriteOperations(CodeWriter writer, ResourceOperation resourceOperation)
        {
            writeGet(writer, resourceOperation);
            writeGetAsync(writer, resourceOperation);
        }

        private void writeGet(CodeWriter writer, ResourceOperation resourceOperation)
        {
            writer.Line();
            writer.WriteXmlDocumentationInheritDoc();
            using (writer.Scope($"public override ArmResponse<{resourceOperation.ResourceDefaultName}> Get(CancellationToken cancellationToken = default)"))
            {
                // todo: do not throw
                writer.Line($"throw new System.NotImplementedException();");
            }
        }

        private void writeGetAsync(CodeWriter writer, ResourceOperation resourceOperation)
        {
            writer.Line();
            writer.WriteXmlDocumentationInheritDoc();
            using (writer.Scope($"public async override Task<ArmResponse<{resourceOperation.ResourceDefaultName}>> GetAsync(CancellationToken cancellationToken = default)"))
            {
                // todo: do not throw
                writer.Line($"throw new System.NotImplementedException();");
            }
        }
    }
}

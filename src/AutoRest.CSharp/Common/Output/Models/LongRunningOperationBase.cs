// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.Common.Output.Models;
using AutoRest.CSharp.Generation.Types;
using AutoRest.CSharp.Output.Builders;
using AutoRest.CSharp.Output.Models.Types;

namespace AutoRest.CSharp.Output.Models.Requests
{
    internal class LongRunningOperationBase : TypeProvider
    {
        public LongRunningOperationBase(Input.Operation operation, BuildContext context, LongRunningOperationInfo lroInfo) : base(context)
        {
            DefaultName = lroInfo.ClientPrefix + operation.CSharpName() + "Operation";
            Description = BuilderHelpers.EscapeXmlDescription(operation.Language.Default.Description);
            DefaultAccessibility = lroInfo.Accessibility;
        }

        protected override string DefaultName { get; }

        protected override string DefaultAccessibility { get; }


        public string Description { get; }

        /// <summary>
        /// Type of the result of the operation.
        /// </summary>
        /// <value></value>
        public CSharpType? ResultType { get; protected set; }
    }
}
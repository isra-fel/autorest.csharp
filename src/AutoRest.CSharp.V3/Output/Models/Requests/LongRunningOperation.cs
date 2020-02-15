﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using AutoRest.CSharp.V3.Output.Models.Responses;
using AutoRest.CSharp.V3.Output.Models.Shared;
using Azure.Core;

namespace AutoRest.CSharp.V3.Output.Models.Requests
{
    internal class LongRunningOperation
    {
        public LongRunningOperation(Method originalMethod, Response originalResponse, string name, Parameter[] createParameters, FinalStateVia finalStateVia)
        {
            OriginalMethod = originalMethod;
            OriginalResponse = originalResponse;
            Name = name;
            CreateParameters = createParameters;
            FinalStateVia = finalStateVia;
        }

        public string Name { get; }
        public Method OriginalMethod { get; }
        public Response OriginalResponse { get; }
        public Parameter[] CreateParameters { get; }
        public FinalStateVia FinalStateVia { get; }
    }
}

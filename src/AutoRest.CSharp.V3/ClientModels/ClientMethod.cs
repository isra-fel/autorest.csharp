﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace AutoRest.CSharp.V3.ClientModels
{
    internal class ClientMethod
    {
        public ClientMethod(string name, string? description, ClientMethodRequest request, ServiceClientParameter[] parameters, ClientMethodResponse responseType, ClientMethodDiagnostics diagnostics, ClientMethodPaging? paging)
        {
            Name = name;
            Request = request;
            Parameters = parameters;
            Response = responseType;
            Description = description;
            Diagnostics = diagnostics;
            Paging = paging;
        }

        public string Name { get; }
        public string? Description { get; }
        public ClientMethodRequest Request { get; }
        public ServiceClientParameter[] Parameters { get; }
        public ClientMethodResponse Response { get; }
        public ClientMethodDiagnostics Diagnostics { get; }
        public ClientMethodPaging? Paging { get; }
    }
}

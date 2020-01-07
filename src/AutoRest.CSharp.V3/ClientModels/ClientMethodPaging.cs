﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace AutoRest.CSharp.V3.ClientModels
{
    internal class ClientMethodPaging
    {
        public ClientMethodPaging(string? nextLinkName, string? itemName, string? operationName)
        {
            NextLinkName = nextLinkName;
            ItemName = itemName;
            OperationName = operationName;
        }

        public string? NextLinkName { get; }
        public string? ItemName { get; }
        public string? OperationName { get; }
    }
}

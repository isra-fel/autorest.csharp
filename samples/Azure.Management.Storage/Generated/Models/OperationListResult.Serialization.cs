// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.Management.Storage.Models
{
    internal partial class OperationListResult
    {
        internal static OperationListResult DeserializeOperationListResult(JsonElement element)
        {
            Optional<IReadOnlyList<RestApi>> value = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("value"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    List<RestApi> array = new List<RestApi>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(RestApi.DeserializeRestApi(item));
                    }
                    value = array;
                    continue;
                }
            }
            return new OperationListResult(Optional.ToList(value));
        }
    }
}

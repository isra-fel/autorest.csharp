// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Core;

namespace Azure.ResourceManager.Sample
{
    public partial class ImageReference : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Publisher))
            {
                writer.WritePropertyName("publisher");
                writer.WriteStringValue(Publisher);
            }
            if (Optional.IsDefined(Offer))
            {
                writer.WritePropertyName("offer");
                writer.WriteStringValue(Offer);
            }
            if (Optional.IsDefined(Sku))
            {
                writer.WritePropertyName("sku");
                writer.WriteStringValue(Sku);
            }
            if (Optional.IsDefined(Version))
            {
                writer.WritePropertyName("version");
                writer.WriteStringValue(Version);
            }
            writer.WriteEndObject();
        }

        internal static ImageReference DeserializeImageReference(JsonElement element)
        {
            Optional<string> publisher = default;
            Optional<string> offer = default;
            Optional<string> sku = default;
            Optional<string> version = default;
            Optional<string> exactVersion = default;
            ResourceIdentifier id = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("publisher"))
                {
                    publisher = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("offer"))
                {
                    offer = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("sku"))
                {
                    sku = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("version"))
                {
                    version = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("exactVersion"))
                {
                    exactVersion = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("id"))
                {
                    id = property.Value.GetString();
                    continue;
                }
            }
            return new ImageReference(id, publisher.Value, offer.Value, sku.Value, version.Value, exactVersion.Value);
        }
    }
}

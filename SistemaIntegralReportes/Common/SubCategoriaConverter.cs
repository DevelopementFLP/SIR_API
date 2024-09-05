using Newtonsoft.Json;
using SistemaIntegralReportes.Models;

namespace SistemaIntegralReportes.Common
{

    public class SubCategoriaConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(SubCategoria);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.String)
            {
                string subCategoriaString = (string)reader.Value;

                // Aplica la conversión aquí
                switch (subCategoriaString)
                {
                    case "Novillito d.i.                                    ":
                        return SubCategoria.NovillitoDI;
                    case "Novillito Joven 24 D                              ":
                        return SubCategoria.NovillitoJoven24D;
                    case "Novillo                                           ":
                        return SubCategoria.Novillo;
                    case "Novillo 6 Dientes                                 ":
                        return SubCategoria.Novillo6Dientes;
                    case "Vaca                                              ":
                        return SubCategoria.Vaca;
                    case "Vaca 6 Dientes                                    ":
                        return SubCategoria.Vaca6Dientes;
                    case "Vaquillona 0-24 D                                 ":
                        return SubCategoria.Vaquillona024D;
                }
            }

            // Si no se puede convertir, se lanza una excepción
            throw new JsonSerializationException($"Valor de subcategoria desconocido: {reader.Value}");
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            // No es necesario implementar la escritura en este caso.
        }
    }

}

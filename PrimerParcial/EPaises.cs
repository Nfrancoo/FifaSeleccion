using System.Text.Json.Serialization;

/// <summary>
/// Enumeración que representa los paises de los jugadores.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum EPaises
{
    Francia,
    Argentina,
    Brasil ,
    Alemania,
    Italia
}
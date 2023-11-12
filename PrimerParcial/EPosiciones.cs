
using System.Text.Json.Serialization;

/// <summary>
/// Enumeración que representa las posiciones de los jugadores.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum EPosicion
{
    Arquero,
    Defensa,
    Mediocentro,
    Delantero
}
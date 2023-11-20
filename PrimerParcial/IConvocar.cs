using SegundoParcial;
/// <summary>
/// Interfaz utilizada para la convocatoria de personal del equipo de selección.
/// </summary>
public interface IConvocar
{
    /// <summary>
    /// Verifica si el texto contiene solo caracteres alfabéticos.
    /// </summary>
    /// <param name="texto">El texto a verificar.</param>
    /// <returns><c>true</c> si el texto contiene solo caracteres alfabéticos; de lo contrario, <c>false</c>.</returns>
    bool EsTextoValido(string texto);

    /// <summary>
    /// Modifica los campos del formulario con los datos del personal existente.
    /// </summary>
    /// <typeparam name="T">Tipo de personal que debe derivar de la interfaz PersonalEquipoSeleccion.</typeparam>
    /// <param name="personal">El personal a modificar.</param>
    void Modificador<T>(T personal) where T : PersonalEquipoSeleccion;

    /// <summary>
    /// Convierte la primera letra del texto en mayúscula y el resto en minúscula.
    /// </summary>
    /// <param name="input">El texto de entrada.</param>
    /// <returns>El texto con la primera letra en mayúscula y el resto en minúscula.</returns>
    string Capitalize(string input);
}

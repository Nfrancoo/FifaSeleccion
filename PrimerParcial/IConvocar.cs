using SegundoParcial;
/// <summary>
/// Interfaz utilizada para la convocatoria de personal del equipo de selección.
/// </summary>
public interface IConvocar
{

    bool EsTextoValido(string texto);

    void Modificador<T>(T personal) where T : PersonalEquipoSeleccion;

    string Capitalize(string input);
}

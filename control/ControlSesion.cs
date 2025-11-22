using System.Text;
using System.Security.Cryptography;

/// <summary>
/// Controlador para la gestión de sesiones de usuario
/// Maneja la autenticación y seguridad de las credenciales
/// </summary>
class ControlSesion
{
    /// <summary>
    /// Controla el proceso de login de un usuario
    /// Verifica credenciales y autentica al usuario en el sistema
    /// </summary>
    /// usuario: Nombre de usuario
    /// pass: Contraseña en texto plano
    /// Retorna Mensaje indicando el resultado del login
    public static string CtrlLogin(String usuario, String pass)
    {
        ModeloSesion modelo = new();
        string rta;

        if ((string.IsNullOrEmpty(usuario)) || string.IsNullOrEmpty(pass))
            rta = "Datos incompletos";
        else
        {
            Usuario? userResult = modelo.MiUsuario(usuario);
            if (userResult != null)
            {
                if (userResult.Contrasena == GenerarSHA1(pass))
                    rta = "¡Bienvenido!";
                else
                    rta = "Clave incorrecta";
            }
            else
                rta = "Usuario no existe";
        }
        return rta;
    }

    /// <summary>
    /// Genera un hash SHA1 de una cadena de texto
    /// </summary>
    /// cadena: Texto a convertir en hash
    /// Retorna Hash SHA1 en formato hexadecimal
    public static string GenerarSHA1(string cadena)
    {
        byte[] data = Encoding.UTF8.GetBytes(cadena);
        byte[] hash = SHA1.HashData(data);

        StringBuilder sb = new();
        foreach (byte b in hash)
        {
            sb.Append(b.ToString("x2"));
        }
        return sb.ToString();
    }
}
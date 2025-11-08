using System.Text;
using System.Security.Cryptography;

class ControlSesion
{
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
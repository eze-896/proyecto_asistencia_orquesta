using System.Text;
using System.Security.Cryptography;

class ControlSesion
{
    public string ctrlLogin(String usuario, String pass)
    {
        ModeloSesion modelo = new ModeloSesion();
        string rta = "";

        if ((string.IsNullOrEmpty(usuario)) || string.IsNullOrEmpty(pass))
            rta = "Datos incompletos";
        else
        {
            Usuario userResult = modelo.miUsuario(usuario);
            if (userResult != null)
            {
                if (userResult.Contrasena == generarSHA1(pass))
                    rta = "¡Bienvenido!";
                else
                    rta = "Clave incorrecta";
            }
            else
                rta = "Usuario no existe";
        }
        return rta;
    }

    public string generarSHA1(string cadena)
    {
        using (SHA1 sha1 = SHA1.Create())
        {
            byte[] data = Encoding.UTF8.GetBytes(cadena);
            byte[] hash = sha1.ComputeHash(data);

            StringBuilder sb = new StringBuilder();
            foreach (byte b in hash)
            {
                sb.Append(b.ToString("x2")); 
            }
            return sb.ToString();
        }
    }
}
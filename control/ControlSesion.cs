using GUI_Login.modelo;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GUI_Login.control
{
    public static class ControlSesion
    {
        // ==================== AUTENTICACIÓN ====================

        public static string CtrlLogin(string usuario, string pass)
        {
            ModeloSesion modelo = new();
            string respuesta;

            if (!ValidarCredenciales(usuario, pass))
            {
                respuesta = "Datos incompletos";
            }
            else
            {
                try
                {
                    // CORREGIDO: Usar nuevo nombre del método
                    Usuario? userResult = modelo.ObtenerUsuarioPorNombre(usuario);
                    respuesta = ProcesarResultadoAutenticacion(userResult, pass);
                }
                catch (Exception ex)
                {
                    // CORREGIDO: Ahora captura excepciones del Modelo
                    respuesta = $"Error al autenticar: {ex.Message}";
                }
            }

            return respuesta;
        }

        private static bool ValidarCredenciales(string usuario, string pass)
        {
            return !string.IsNullOrEmpty(usuario) && !string.IsNullOrEmpty(pass);
        }

        private static string ProcesarResultadoAutenticacion(Usuario? usuario, string pass)
        {
            if (usuario == null)
            {
                return "Usuario no existe";
            }

            string hashContrasena = GenerarSHA1(pass);
            if (usuario.Contrasena == hashContrasena)
            {
                return "¡Bienvenido!";
            }
            else
            {
                return "Clave incorrecta";
            }
        }

        // ==================== SEGURIDAD Y CRIPTOGRAFÍA ====================

        public static string GenerarSHA1(string cadena)
        {
            if (string.IsNullOrEmpty(cadena))
                return string.Empty;

            try
            {
                byte[] data = Encoding.UTF8.GetBytes(cadena);
                byte[] hash = SHA1.HashData(data);

                StringBuilder sb = new StringBuilder();
                foreach (byte b in hash)
                {
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString();
            }
            catch (Exception ex)
            {
                // CORREGIDO: Lanzar excepción en lugar de MessageBox
                throw new Exception($"Error al generar hash: {ex.Message}");
            }
        }

        // ==================== VALIDACIONES DE FORTALEZA DE CONTRASEÑA ====================

        public static (bool EsValida, string Mensaje) ValidarFortalezaContrasena(string password)
        {
            if (string.IsNullOrEmpty(password))
                return (false, "La contraseña no puede estar vacía");

            // CORREGIDO: Validaciones simplificadas usando LINQ
            if (password.Length < 8)
                return (false, "La contraseña debe tener al menos 8 caracteres");

            if (password.Length > 50)
                return (false, "La contraseña no puede tener más de 50 caracteres");

            // CORREGIDO: Usar métodos de char para mejor legibilidad
            if (!password.Any(char.IsUpper))
                return (false, "La contraseña debe contener al menos una letra mayúscula");

            if (!password.Any(char.IsLower))
                return (false, "La contraseña debe contener al menos una letra minúscula");

            if (!password.Any(char.IsDigit))
                return (false, "La contraseña debe contener al menos un número");

            // CORREGIDO: Regex simplificado para caracteres especiales
            if (!Regex.IsMatch(password, @"[\p{P}\p{S}]")) // Caracteres de puntuación y símbolos
                return (false, "La contraseña debe contener al menos un carácter especial (!@#$%^&* etc.)");

            if (password.Contains(" "))
                return (false, "La contraseña no puede contener espacios en blanco");

            if (EsSecuenciaSimple(password))
                return (false, "La contraseña es demasiado simple o común");

            return (true, "Contraseña válida");
        }

        private static bool EsSecuenciaSimple(string password)
        {
            string[] contraseñasComunes = {
                "12345678", "password", "qwertyui", "abcdefgh",
                "11111111", "00000000", "admin123", "contraseña"
            };

            if (Array.Exists(contraseñasComunes, common => password.ToLower() == common))
                return true;

            if (Regex.IsMatch(password, "^12345678$|^87654321$"))
                return true;

            string[] secuenciasTeclado = { "qwerty", "asdfgh", "zxcvbn", "poiuyt" };
            if (Array.Exists(secuenciasTeclado, seq => password.ToLower().Contains(seq)))
                return true;

            if (Regex.IsMatch(password, @"(.)\1{3,}"))
                return true;

            return false;
        }

        // CORREGIDO: Método simplificado usando switch expression
        public static string EvaluarNivelFortaleza(string password)
        {
            if (string.IsNullOrEmpty(password))
                return "Débil";

            int score = 0;

            // Longitud
            if (password.Length >= 8) score++;
            if (password.Length >= 12) score++;
            if (password.Length >= 16) score++;

            // Complejidad
            if (password.Any(char.IsLower)) score++;
            if (password.Any(char.IsUpper)) score++;
            if (password.Any(char.IsDigit)) score++;
            if (Regex.IsMatch(password, @"[\p{P}\p{S}]")) score++;

            return score switch
            {
                <= 3 => "Débil",
                <= 5 => "Media",
                <= 7 => "Fuerte",
                _ => "Muy Fuerte"
            };
        }
    }
}
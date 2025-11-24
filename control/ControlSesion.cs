using GUI_Login.modelo;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GUI_Login.control
{
    /// <summary>
    /// Controlador para gestionar la autenticación, registro y seguridad de usuarios
    /// </summary>
    public class ControlSesion
    {
        private ModeloSesion _modelo;

        /// <summary>
        /// Constructor que inicializa el modelo de sesión
        /// </summary>
        public ControlSesion()
        {
            _modelo = new ModeloSesion();
        }

        // ==================== AUTENTICACIÓN ====================

        /// <summary>
        /// Controla el proceso de login validando usuario y contraseña
        /// </summary>
        public string CtrlLogin(string usuario, string pass)
        {
            // Validar que los campos no estén vacíos
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(pass))
            {
                return "Datos incompletos";
            }

            try
            {
                // Buscar usuario en la base de datos
                Usuario? userResult = _modelo.ObtenerUsuarioPorNombre(usuario);

                if (userResult == null)
                {
                    return "Usuario no existe";
                }

                // Verificar contraseña comparando hashes SHA1
                string hashContrasena = GenerarSHA1(pass);
                if (userResult.Contrasena == hashContrasena)
                {
                    return "¡Bienvenido!";
                }
                else
                {
                    return "Clave incorrecta";
                }
            }
            catch (Exception ex)
            {
                return $"Error al autenticar: {ex.Message}";
            }
        }

        // ==================== REGISTRO ====================

        /// <summary>
        /// Registra un nuevo usuario en el sistema con contraseña hasheada
        /// </summary>
        public bool RegistrarUsuario(string usuario, string password)
        {
            try
            {
                string hashContrasena = GenerarSHA1(password);

                Usuario nuevoUser = new Usuario
                {
                    Nombre = usuario,
                    Contrasena = hashContrasena
                };

                return _modelo.RegistrarUsuario(nuevoUser);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error en el registro: {ex.Message}");
            }
        }

        // ==================== SEGURIDAD Y CRIPTOGRAFÍA ====================

        /// <summary>
        /// Genera un hash SHA1 de una cadena de texto
        /// </summary>
        public string GenerarSHA1(string cadena)
        {
            if (string.IsNullOrEmpty(cadena))
                return string.Empty;

            try
            {
                // Generar hash SHA1 de la cadena
                byte[] data = Encoding.UTF8.GetBytes(cadena);
                byte[] hash = SHA1.HashData(data);

                // Convertir hash a string hexadecimal
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hash)
                {
                    sb.Append(b.ToString("x2"));
                }
                return sb.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al generar hash: {ex.Message}");
            }
        }

        // ==================== VALIDACIONES DE CONTRASEÑA ====================

        /// <summary>
        /// Valida la fortaleza de una contraseña
        /// </summary>
        public (bool EsValida, string Mensaje) ValidarFortalezaContrasena(string password)
        {
            if (string.IsNullOrEmpty(password))
                return (false, "La contraseña no puede estar vacía");

            // Validaciones básicas de longitud
            if (password.Length < 8)
                return (false, "La contraseña debe tener al menos 8 caracteres");
            if (password.Length > 50)
                return (false, "La contraseña no puede tener más de 50 caracteres");

            // Validaciones de complejidad
            if (!password.Any(char.IsUpper))
                return (false, "La contraseña debe contener al menos una letra mayúscula");
            if (!password.Any(char.IsLower))
                return (false, "La contraseña debe contener al menos una letra minúscula");
            if (!password.Any(char.IsDigit))
                return (false, "La contraseña debe contener al menos un número");
            if (!Regex.IsMatch(password, @"[\p{P}\p{S}]"))
                return (false, "La contraseña debe contener al menos un carácter especial (!@#$%^&* etc.)");
            if (password.Contains(" "))
                return (false, "La contraseña no puede contener espacios en blanco");

            // Verificar si es una contraseña común o secuencia simple
            if (EsSecuenciaSimple(password))
                return (false, "La contraseña es demasiado simple o común");

            return (true, "Contraseña válida");
        }

        /// <summary>
        /// Evalúa el nivel de fortaleza de una contraseña
        /// </summary>
        public string EvaluarNivelFortaleza(string password)
        {
            if (string.IsNullOrEmpty(password))
                return "Débil";

            // Calcular puntaje basado en longitud y complejidad
            int score = 0;

            // Puntos por longitud
            if (password.Length >= 8) score++;
            if (password.Length >= 12) score++;
            if (password.Length >= 16) score++;

            // Puntos por complejidad
            if (password.Any(char.IsLower)) score++;
            if (password.Any(char.IsUpper)) score++;
            if (password.Any(char.IsDigit)) score++;
            if (Regex.IsMatch(password, @"[\p{P}\p{S}]")) score++;

            // Clasificar según el puntaje obtenido
            return score switch
            {
                <= 3 => "Débil",
                <= 5 => "Media",
                <= 7 => "Fuerte",
                _ => "Muy Fuerte"
            };
        }

        /// <summary>
        /// Verifica si una contraseña es demasiado simple o común
        /// </summary>
        private bool EsSecuenciaSimple(string password)
        {
            // Lista de contraseñas comunes a evitar
            string[] contraseñasComunes = {
                "12345678", "password", "qwertyui", "abcdefgh",
                "11111111", "00000000", "admin123", "contraseña"
            };

            // Verificar contra contraseñas comunes
            if (Array.Exists(contraseñasComunes, common => password.ToLower() == common))
                return true;

            // Verificar secuencias numéricas
            if (Regex.IsMatch(password, "^12345678$|^87654321$"))
                return true;

            // Verificar secuencias de teclado
            string[] secuenciasTeclado = { "qwerty", "asdfgh", "zxcvbn", "poiuyt" };
            if (Array.Exists(secuenciasTeclado, seq => password.ToLower().Contains(seq)))
                return true;

            // Verificar caracteres repetidos (ej: aaaa, 1111)
            if (Regex.IsMatch(password, @"(.)\1{3,}"))
                return true;

            return false;
        }
    }
}
using System.Security.Cryptography;
using System.Text;

namespace TecnoFix.Clases
{
    public static class Seguridad
    {
        //SHA-256 en hexadecimal MAYUSCULA: debe dar lo mismo que el script SQL
        //CONVERT(VARCHAR(64), HASHBYTES('SHA2_256', 'clave'), 2)
        public static string CalcularHash(string texto)
        {
            using (SHA256 sha = SHA256.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(texto ?? ""));
                StringBuilder sb = new StringBuilder();
                foreach (byte b in bytes) sb.Append(b.ToString("X2"));
                return sb.ToString();
            }
        }
    }
}

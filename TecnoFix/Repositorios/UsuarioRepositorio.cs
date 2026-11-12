using System.Linq;
using TecnoFix.Clases;
using RepoDb;

namespace TecnoFix.Repositorios
{
    public class UsuarioRepositorio : RepositorioBase<Usuario>
    {
        //Devuelve el usuario si el nombre y la clave son correctos; si no, null
        public Usuario Validar(string nombreUser, string clave)
        {
            string hash = Seguridad.CalcularHash(clave);
            using (var cn = ConexionBD.ObtenerConexion())
            {
                return cn.Query<Usuario>(x => x.NombreUser == nombreUser && x.Clave == hash)
                         .FirstOrDefault();
            }
        }

        public bool ExisteUsuario(string nombreUser, int idExcluir = 0)
        {
            using (var cn = ConexionBD.ObtenerConexion())
            {
                return cn.Count<Usuario>(x => x.NombreUser == nombreUser && x.Id != idExcluir) > 0;
            }
        }
    }
}

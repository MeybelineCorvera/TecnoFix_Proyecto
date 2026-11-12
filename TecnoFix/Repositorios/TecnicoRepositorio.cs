using System.Linq;
using TecnoFix.Clases;
using RepoDb;

namespace TecnoFix.Repositorios
{
    public class TecnicoRepositorio : RepositorioBase<Tecnico>
    {
        public Tecnico ObtenerPorId(int id)
        {
            using (var cn = ConexionBD.ObtenerConexion())
            {
                return cn.Query<Tecnico>(x => x.Id == id).FirstOrDefault();
            }
        }
        //Tecnico ligado a una cuenta de usuario (null si ese usuario no es un tecnico)
        public Tecnico ObtenerPorUsuario(int idUsuario)
        {
            using (var cn = ConexionBD.ObtenerConexion())
            {
                return cn.Query<Tecnico>(x => x.IdUsuario == idUsuario).FirstOrDefault();
            }
        }
    }
}

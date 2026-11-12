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
    }
}

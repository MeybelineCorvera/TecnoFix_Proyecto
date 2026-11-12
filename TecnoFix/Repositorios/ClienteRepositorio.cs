using System.Linq;
using TecnoFix.Clases;
using RepoDb;

namespace TecnoFix.Repositorios
{
    public class ClienteRepositorio : RepositorioBase<Cliente>
    {
        public Cliente ObtenerPorId(int id)
        {
            using (var cn = ConexionBD.ObtenerConexion())
            {
                return cn.Query<Cliente>(x => x.Id == id).FirstOrDefault();
            }
        }

        //idExcluir sirve al editar: no compara el registro contra si mismo
        public bool ExisteTelefono(string telefono, int idExcluir = 0)
        {
            using (var cn = ConexionBD.ObtenerConexion())
            {
                return cn.Count<Cliente>(x => x.Telefono == telefono && x.Id != idExcluir) > 0;
            }
        }
    }
}

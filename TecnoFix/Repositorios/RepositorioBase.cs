using System.Collections.Generic;
using System.Linq;
using TecnoFix.Clases;
using RepoDb;

namespace TecnoFix.Repositorios
{
    // Repositorio generico con los metodos genericos de RepoDB. Cada tabla hereda de aqui: RepositorioBase<Cliente>, RepositorioBase<Equipo>
    public abstract class RepositorioBase<T> where T : class
    {
        public List<T> ObtenerTodos()
        {
            using (var cn = ConexionBD.ObtenerConexion())
            {
                return cn.QueryAll<T>().ToList();
            }
        }

        public void Insertar(T entidad)
        {
            using (var cn = ConexionBD.ObtenerConexion())
            {
                cn.Insert<T>(entidad);
            }
            Notificador.Avisar();
        }

        public void Actualizar(T entidad)
        {
            using (var cn = ConexionBD.ObtenerConexion())
            {
                cn.Update<T>(entidad);
            }
            Notificador.Avisar();
        }

        public void Eliminar(T entidad)
        {
            using (var cn = ConexionBD.ObtenerConexion())
            {
                cn.Delete<T>(entidad);
            }
            Notificador.Avisar();
        }
    }
}

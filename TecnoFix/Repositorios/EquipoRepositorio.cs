using System.Collections.Generic;
using System.Linq;
using TecnoFix.Clases;
using RepoDb;

namespace TecnoFix.Repositorios
{
    public class EquipoRepositorio : RepositorioBase<Equipo>
    {
        public Equipo ObtenerPorId(int id)
        {
            using (var cn = ConexionBD.ObtenerConexion())
            {
                return cn.Query<Equipo>(x => x.Id == id).FirstOrDefault();
            }
        }

        //Este une Equipo + Cliente para mostrar en la grilla
        public List<EquipoDetalle> ObtenerDetalle()
        {
            List<Equipo> equipos = ObtenerTodos();
            List<Cliente> clientes = new ClienteRepositorio().ObtenerTodos();

            return (from e in equipos
                    join c in clientes on e.IdCliente equals c.Id
                    orderby e.Id descending
                    select new EquipoDetalle
                    {
                        Id = e.Id,
                        IdCliente = c.Id,
                        Cliente = c.Nombre + " " + c.Apellido,
                        Tipo = e.Tipo,
                        Marca = e.Marca,
                        Modelo = e.Modelo,
                        Serie = e.Serie
                    }).ToList();
        }

        //Equipos de un cliente (para llenar el combo al crear una orden)
        public List<Equipo> ObtenerPorCliente(int idCliente)
        {
            using (var cn = ConexionBD.ObtenerConexion())
            {
                return cn.Query<Equipo>(x => x.IdCliente == idCliente).ToList();
            }
        }

        //La serie es opcional: si viene vacia no se considera repetida
        public bool ExisteSerie(string serie, int idExcluir = 0)
        {
            if (string.IsNullOrWhiteSpace(serie)) return false;
            using (var cn = ConexionBD.ObtenerConexion())
            {
                return cn.Count<Equipo>(x => x.Serie == serie && x.Id != idExcluir) > 0;
            }
        }
    }
}

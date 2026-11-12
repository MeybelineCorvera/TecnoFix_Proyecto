using System;
using System.Collections.Generic;
using System.Linq;
using TecnoFix.Clases;
using RepoDb;

namespace TecnoFix.Repositorios
{
    public class OrdenServicioRepositorio : RepositorioBase<OrdenServicio>
    {
        public OrdenServicio ObtenerPorId(int id)
        {
            using (var cn = ConexionBD.ObtenerConexion())
            {
                return cn.Query<OrdenServicio>(x => x.Id == id).FirstOrDefault();
            }
        }

        //Une Orden + Equipo + Cliente + Estado + Tecnico para mostrar en la grilla
        public List<OrdenDetalle> ObtenerDetalle()
        {
            List<OrdenServicio> ordenes = ObtenerTodos();
            List<Equipo> equipos = new EquipoRepositorio().ObtenerTodos();
            List<Cliente> clientes = new ClienteRepositorio().ObtenerTodos();
            List<Estado> estados = new EstadoRepositorio().ObtenerTodos();
            List<Tecnico> tecnicos = new TecnicoRepositorio().ObtenerTodos();

            return (from o in ordenes
                    join e in equipos on o.IdEquipo equals e.Id
                    join c in clientes on e.IdCliente equals c.Id
                    join s in estados on o.IdEstado equals s.Id
                    join t in tecnicos on o.IdTecnico equals t.Id into gt
                    from t in gt.DefaultIfEmpty()
                    orderby o.Id descending
                    select new OrdenDetalle
                    {
                        Id = o.Id,
                        IdEquipo = o.IdEquipo,
                        IdCliente = c.Id,
                        IdTecnico = o.IdTecnico,
                        IdEstado = o.IdEstado,
                        Cliente = c.Nombre + " " + c.Apellido,
                        Telefono = c.Telefono,
                        Equipo = e.Tipo + " " + e.Marca + " " + e.Modelo,
                        Serie = e.Serie,
                        Falla = o.Falla,
                        Diagnostico = o.Diagnostico,
                        Estado = s.Nombre,
                        Tecnico = t == null ? "Sin asignar" : t.Nombre,
                        FechaIngreso = o.FechaIngreso,
                        FechaEntrega = o.FechaEntrega
                    }).ToList();
        }

        //Cambia el estado de una orden. Si pasa a "Entregado" guarda la fecha de entrega.
        public void CambiarEstado(int idOrden, int idEstado)
        {
            OrdenServicio orden = ObtenerPorId(idOrden);
            if (orden == null) return;

            orden.IdEstado = idEstado;
            if (idEstado == EstadoOrden.Entregado && orden.FechaEntrega == null)
                orden.FechaEntrega = DateTime.Now;

            Actualizar(orden);
        }
    }
}

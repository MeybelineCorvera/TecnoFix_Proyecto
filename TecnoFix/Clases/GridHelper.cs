using System.Windows.Forms;

namespace TecnoFix.Clases
{
    //se configura el datagrid de ordenes de servicio (se usa en el Panel y en los formularios de ordenes)
    public static class GridHelper
    {
        public static void ConfigurarOrdenes(DataGridView dgv)
        {
            foreach (string col in new[] { "Id", "IdEquipo", "IdCliente", "IdTecnico", "IdEstado" })
                dgv.Columns[col].Visible = false;

            dgv.Columns["Cliente"].HeaderText = "Cliente";
            dgv.Columns["Telefono"].HeaderText = "Telefono";
            dgv.Columns["Equipo"].HeaderText = "Equipo";
            dgv.Columns["Serie"].HeaderText = "Serie";
            dgv.Columns["Falla"].HeaderText = "Falla reportada";
            dgv.Columns["Diagnostico"].HeaderText = "Diagnostico";
            dgv.Columns["Estado"].HeaderText = "Estado";
            dgv.Columns["Tecnico"].HeaderText = "Tecnico";
            dgv.Columns["RegistradoPor"].HeaderText = "Registrado por";
            dgv.Columns["FechaIngreso"].HeaderText = "Ingreso";
            dgv.Columns["FechaEntrega"].HeaderText = "Entrega";

            dgv.Columns["FechaIngreso"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            dgv.Columns["FechaEntrega"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";

            dgv.ReadOnly = true;
            dgv.AllowUserToAddRows = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}

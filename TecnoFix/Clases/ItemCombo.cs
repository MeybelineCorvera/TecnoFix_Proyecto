namespace TecnoFix.Clases
{
    //Elemento para llenar los ComboBox (Id oculto + texto visible)
    //Uso: cbo.DisplayMember = "Texto"; cbo.ValueMember = "Id";
    public class ItemCombo
    {
        public int Id { get; set; }
        public string Texto { get; set; }
    }
}

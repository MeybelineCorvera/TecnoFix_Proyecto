using System;

namespace TecnoFix.Clases
{
    //Aviso global q los repositorios avisa cuando se guarda algo en la BD y el Panel lo escucha para actualizar el datagrid al instante.
    public static class Notificador
    {
        public static event Action DatosCambiaron;

        public static void Avisar()
        {
            Action handler = DatosCambiaron;
            if (handler != null) handler();
        }
    }
}

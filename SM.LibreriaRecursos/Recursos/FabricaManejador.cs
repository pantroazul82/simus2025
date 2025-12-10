using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SM.LibreriaRecursos.Recursos
{
    public class FabricaManejador
    {
        private static ManejadorRecursos currentManejador = null;

        public FabricaManejador()
        {
        }

        public ManejadorRecursos getInstance()
        {
            if (currentManejador == null)
            {
                currentManejador = new ManejadorRecursos();
            }
           
            return currentManejador;
        }
    }
}

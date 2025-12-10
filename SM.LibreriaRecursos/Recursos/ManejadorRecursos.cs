using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace SM.LibreriaRecursos.Recursos
{
    public class ManejadorRecursos
    {
        ResourceManager resourceReaderWeb = new ResourceManager(Constantes.ConstantesRecursos.ARCHIVO_RECURSOS_WEB, Assembly.GetExecutingAssembly());
      

        public ManejadorRecursos()
        {
            
        }

        public String obtenerValor(String name)
        {
            return resourceReaderWeb.GetString(name);
           
        }
    }
}

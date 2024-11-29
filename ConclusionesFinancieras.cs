using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazonesFinancieras
{
    public static class ConclusionesFinancieras
    {
        public static List<string> Conclusiones { get; private set; } = new List<string>();

        // Método para agregar una conclusión
        public static void AgregarConclusion(string conclusion)
        {
            if (!string.IsNullOrWhiteSpace(conclusion))
            {
                Conclusiones.Add(conclusion);
            }
        }

        // Método para obtener todas las conclusiones
        public static List<string> ObtenerConclusiones()
        {
            return new List<string>(Conclusiones);
        }
    }
}

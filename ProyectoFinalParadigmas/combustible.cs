using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalParadigmas
{
    [Serializable]
    public class combustible
    {
        string nombre;
        double precio_km;

        //inicializa el combustible como "Nafta" y precio "0,59"
        public combustible()
        {
            nombre = "Nafta";
            precio_km = 0.59;
        }

        //devuelve el precio del combustible
        public double devolver_precio()
        {
            return precio_km;
        }
    }

}

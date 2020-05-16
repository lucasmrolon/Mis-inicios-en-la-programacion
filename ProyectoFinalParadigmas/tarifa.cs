using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalParadigmas
{
    class tarifa
    {
        double[] precios;
        double basico;

        //establece un precio base de tarifas dependiendo de la distancia del viaje
        public tarifa()
        {
            precios = new double[6];
            basico = 10.00;
            precios[0] = basico;
            for (int i = 1; i < 6; i++)
                precios[i] = precios[i-1] * 1.20;
        }

        //devuelve la tabla de precios
        public double[] devolver_tabla()
        {
            return precios;
        }
    }
}

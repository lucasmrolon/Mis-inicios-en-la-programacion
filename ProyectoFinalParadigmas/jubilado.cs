using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalParadigmas
{
    //la clase jubilado hereda de pasaje_general
    class jubilado : pasaje_general
    {
        int num_carnet;

        //constructor
        public jubilado(int carnet)
        {
            tipo = "Jubilado";
            num_carnet = carnet;
            descuento = 0.30;
        }

        //devuelve los datos del tipo de pasaje
        public new string devolver_datos()
        {
            return tipo + " - N° de carnet: " + num_carnet;
        }
    }
}

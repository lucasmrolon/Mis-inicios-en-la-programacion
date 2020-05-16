using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalParadigmas
{
    [Serializable]
    class categoria
    {
        public string tipo;

        //constructor que asigna el tipo de categoria
        public categoria(string tipo)
        {
            this.tipo = tipo;
        }
        
        //modifica el precio del viaje de acuerdo a la categoría
        public double det_precio(double importe)
        {
            switch (tipo)
            {
                case "Simple":
                    importe *= 1;
                    break;
                case "Premium":
                    importe *= 1.20;
                    break;
                case "Ejecutivo":
                    importe *= 1.30;
                    break;
            }
            return importe;
            
        }
    }
}

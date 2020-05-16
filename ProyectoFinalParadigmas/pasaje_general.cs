using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalParadigmas
{
    class pasaje_general
    {
        protected double descuento;
        protected string tipo;
        
        //constructor que guarda el tipo y establece el descuento al 0 %
        public pasaje_general()
        {
            tipo = "General";
            descuento = 0; 
        }
              
        //aplica el descuento al precio original
        public double aplicar_descuento(double precio)
        {
            return precio - precio * descuento;
        }

        //devuelve el tipo de pasaje
        public string devolver_datos()
        {
            return tipo;
        }
    }
}

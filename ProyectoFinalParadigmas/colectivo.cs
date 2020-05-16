using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalParadigmas
{
    [Serializable]
    public class colectivo
    {
        public string patente;
        bool estado;
        combustible combustible;


        //permite mostrar la matricula cuando se carga a un combobox
        public override string ToString()
        {
            return patente;
        }

        //constructor que inicializa el colectivo como disponible
        public colectivo()
        {
            estado = true;
        }

        //devuelve un objeto de tipo combustible
        public combustible devolver_combustible()
        {
            combustible = new combustible();
            return combustible;
        }

        //muestra si el colectivo esta o no disponible
        public bool devolver_estado()
        {
            return estado;
        }

        //modifica el estado del colectivo
        public void modificar_estado(bool estado)
        {
            this.estado = estado;
        }
    }
}

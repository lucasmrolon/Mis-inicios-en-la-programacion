using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalParadigmas
{
    [Serializable]
    public class ciudad
    {
        string nombre;
        int[] coord = new int[2];

        //constructor que carga nombre y coordenadas
        public ciudad (string nombre, int[] coordenadas)
        {
            this.nombre = nombre;
            this.coord = coordenadas;
        }

        //constructor auxiliar
        public ciudad()
        {

        }

        //permite mostrar el nombre cuando se carga la ciudad a un combobox
        public override string ToString()
        {
            return nombre;
        }

        //devuelve el nombre de la ciudad
        public string devolver_nombre ()
        {
            return nombre;
        }

        //devuelve las coordenadas de la ciudad
        public int[] devolver_coordenadas()
        {
            return coord;
        }

        //permite modificar el nombre de la ciudad
        public void modif_nombre(string nuevo_nombre)
        {
            nombre = nuevo_nombre;
        }
    }
}

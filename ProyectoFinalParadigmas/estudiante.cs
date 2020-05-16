using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalParadigmas
{
    //la clase estudiante hereda de pasaje_general
    class estudiante : pasaje_general
    {
        int num_libreta;
        string carrera;
        string universidad;

        //constructor
        public estudiante(string universidad,string carrera,int libreta)
        {
            tipo = "Estudiante";
            this.universidad = universidad;
            this.carrera = carrera;
            num_libreta = libreta;
            descuento = 0.20;
        }

        //devuelve los datos del tipo de pasaje
        public new string devolver_datos()
        {
            return tipo + " - N° de libreta: " + num_libreta + " - " + carrera + " - " +
                universidad; 
        }

    }
}

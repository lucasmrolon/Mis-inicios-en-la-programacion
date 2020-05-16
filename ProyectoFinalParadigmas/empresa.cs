using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalParadigmas
{
    [Serializable]
    public class Empresa
    {
        public string nombre;
        public string email;
        public string cuit;
        public string direccion;
        public string sede;
        public List<colectivo> colectivos;
        public string sitio_web;

        //constructor
        public Empresa(string name, string mail, string cuit, string direcc, string sede, string sitioweb)
        {
            nombre = name;
            email = mail;
            this.cuit = cuit;
            direccion = direcc;
            this.sede = sede;
            sitio_web = sitioweb;
            colectivos = new List<colectivo>();
        }

        //permite mostrar el nombre de la empresa en el combobox
        public override string ToString()
        {
            return nombre;
        }

        //devuelve el nombre de la empresa
        public string mostrar_empresa()
        {
            return nombre;
        }

        //devuelve info de la empresa
        public string info_empresa()
        {
            return email + "\n\r" + sede + "\n\r" + sitio_web + "\n\r" + direccion;
        }
    }
}

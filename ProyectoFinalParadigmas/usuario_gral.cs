using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalParadigmas
{
    [Serializable]
    public class usuario_gral
    {

        public string nombre, domicilio;       
        public int dni;
        public long telefono;
        public string nacimiento;
        public List<viaje> viajes;
        public int i = 0;
        public string email;
        public string usuario, contraseña;

        //constructor
        public usuario_gral(string name, string dom, int documento, long tel, string nac, string mail,
            string user, string pass)
        {
            nombre = name;
            dni = documento;
            telefono = tel;
            domicilio = dom;
            nacimiento = nac;
            email = mail;
            usuario = user;
            contraseña = pass;
            viajes = new List<viaje>();
        }

        //constructor auxiliar
        public usuario_gral()
        {
        }

        //permite ver el nombre del usuario cuando se carga el objeto a un combobox
        public override string ToString()
        {
            return nombre;
        }

        //muestra los datos del usuario
        public string mostrar_datos()
        {
            return nombre + " - " + dni + " - " + telefono + " - " + email;
        }

        //permite modificar el teléfono
        public void modificar_tel(long nuevo_tel)
        {
            telefono = nuevo_tel;
        }

        //permite modificar el email
        public void modificar_email(string mail)
        {
            email = mail;
        }

        //añade un viaje a la lista de viajes comprados
        public void nuevo_viaje(viaje via)
        {
            viajes.Add(via);
        }

        //elimina un viaje de la lista de viajes comprados
        public void eliminar_viaje(viaje via)
        {
            viajes.Remove(via);
        }
    }
}

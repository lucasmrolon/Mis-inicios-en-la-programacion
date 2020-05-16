using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace ProyectoFinalParadigmas
{
    [Serializable]
    public class Basededatos
    {
        public List<usuario_gral> usuarios;
        public List<Empresa> empresas;
        public List<ciudad> ciudades;
        public usuario_gral usuario_activo;
        public List<colectivo> colectivo;
        public List<viaje> viajes;

        //instancia todos los objetos
        public Basededatos()
        {
            usuarios = new List<usuario_gral>();
            empresas = new List<Empresa>();
            ciudades = new List<ciudad>();
            colectivo = new List<colectivo>();
            viajes = new List<viaje>();
        }
        
        //guarda la base de datos en el archivo       
        public void Save()
        {
            Archivo.Save(this);
        }

    }
}

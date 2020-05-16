using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ProyectoFinalParadigmas
{
    class Archivo
    {
        //abre el archivo guardado y lo carga en una clase de tipo Basededatos
        public static Basededatos Open()
        {
            FileStream file = new FileStream(Properties.Settings.Default.pathdb, FileMode.OpenOrCreate);
            BinaryFormatter formater = new BinaryFormatter();
            Basededatos resultado = formater.Deserialize(file) as Basededatos;
            file.Close();
            return resultado;
        }

        //binariza la base de datos y guarda en el archivo
        public static void Save(Basededatos bd)
        {
            FileStream file = new FileStream(Properties.Settings.Default.pathdb, FileMode.OpenOrCreate);
            BinaryFormatter formater = new BinaryFormatter();
            formater.Serialize(file, bd);
            file.Close();
        }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoFinalParadigmas
{
    public partial class nueva_ciudad : Form
    {
        Basededatos bd;

        //inicializo la ventana abriendo la base de datos
        public nueva_ciudad()
        {
            InitializeComponent();
            bd = Archivo.Open();
        }

        //agrega una ciudad a la base de datos
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //recoge los datos de los textbox
                string nombre_ciudad = textBox1.Text;
                int x = int.Parse(textBox2.Text);
                int y = int.Parse(textBox3.Text);

                //carga en un array las coordenadas y crea el objeto ciudad
                int[] coordenadas = { x, y };
                ciudad nueva = new ciudad(nombre_ciudad, coordenadas);

                //esta variable indica si se puede crear la ciudad o no
                bool disponible = true;

                //verifica que ya no exista una ciudad con el mismo nombre
                foreach (var item in bd.ciudades)
                {
                    if (item.devolver_nombre() == nombre_ciudad)
                        disponible = false;
                }

                //si no existe una ciudad con el mismo nombre, la crea
                if (disponible == true)
                {
                    //añade la ciudad a la base de datos y cierra el archivo
                    bd.ciudades.Add(nueva);
                    bd.Save();
                    this.Close();
                }
            }

            //si se ingresaron datos incorrectos, se muestra mensaje de error
            catch
            {
                MessageBox.Show("Datos incorrectos", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

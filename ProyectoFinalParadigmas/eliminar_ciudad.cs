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
    public partial class eliminar_ciudad : Form
    {
        Basededatos bd;
        public eliminar_ciudad()
        {
            InitializeComponent();

            //abre el archivo
            bd = Archivo.Open();

            //carga en el combobox la lista de ciudades
            foreach (var item in bd.ciudades)
            {
                comboBox1.Items.Add(item);
                comboBox1.Sorted = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //controla que se haya seleccionado una ciudad
            if (comboBox1.Text != "")
            {
                //se elimina la ciudad de la lista
                ciudad nueva = comboBox1.SelectedItem as ciudad;
                bd.ciudades.Remove(nueva);

                //se actualiza la lista del combobox
                comboBox1.Text = "";
                comboBox1.Items.Clear();
                foreach (var item in bd.ciudades)
                    comboBox1.Items.Add(item);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            //se guardan los cambios y se cierra la ventana
            bd.Save();
            this.Close();
        }
    }
}

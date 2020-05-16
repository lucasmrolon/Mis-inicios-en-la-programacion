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
    public partial class modificar_viaje : Form
    {
        Basededatos bd;
        public modificar_viaje()
        {
            InitializeComponent();

            //abre el archivo y carga el combobox con los viajes existentes
            bd = Archivo.Open();
            foreach (var item in bd.viajes)
                comboBox1.Items.Add(item);

        }

        //cierra la ventana y muestra la anterior
        private void button1_Click(object sender, EventArgs e)
        {
            this.Owner.Show();
            this.Close();
        }

        //muestra en pantalla los datos del viaje seleccionado
        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                viaje viaje = comboBox1.SelectedItem as viaje;
                ORIGENtextBox1.Text = viaje.dev_origen();               //ORIGEN
                DESTINOtextBox1.Text = viaje.dev_destino();             //DESTINO
                textBox1.Text = viaje.dev_fecha();                      //FECHA
                textBox2.Text = viaje.dev_hora();                       //HORA
                CATEGORIAtextBox2.Text = viaje.dev_categoria();         //CATEGORÍA
                EPRESAtextBox3.Text = viaje.dev_empresa();              //EMPRESA
                textBox3.Text = viaje.dev_colectivo();                  //COLECTIVO ASIGNADO
                textBox4.Text = (viaje.devolver_km()).ToString("N2") + " Km.";      //DISTANCIA
            }
        }

        //elimina un viaje de la base de datos
        private void button3_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                //borra el viaje de la base de datos
                viaje a_borrar = comboBox1.SelectedItem as viaje;
                bd = a_borrar.liberar_colectivo(bd);
                bd.viajes.Remove(a_borrar);

                //vacia los campos
                ORIGENtextBox1.Text = DESTINOtextBox1.Text = textBox4.Text = textBox1.Text = textBox2.Text = "";
                CATEGORIAtextBox2.Text = textBox3.Text = "";

                //actualiza el combobox de viajes y cierra la base de datos
                comboBox1.Items.Clear();
                foreach (var item in bd.viajes)
                {
                    comboBox1.Items.Add(item);
                }
                bd.Save();
                comboBox1.Text = " ";
            }
        }
    }
}
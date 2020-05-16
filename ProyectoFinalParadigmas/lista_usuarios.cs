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
    public partial class lista_usuarios : Form
    {
        Basededatos bd;
        public lista_usuarios()
        {
            //inicializa cargando el comboBox con los datos almacenados en el archivo
            InitializeComponent();
            bd = Archivo.Open();
            foreach (var item in bd.usuarios)
            {
                comboBox1.Items.Add(item);
            }
 
        }

        //muestro usuario y contraseña del usuario seleccionado
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            usuario_gral nuevo = comboBox1.SelectedItem as usuario_gral;
            textBox1.Text = "Usuario: " + nuevo.usuario +  "\r\nContraseña: "+ nuevo.contraseña;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //elimina el usuario seleccionado
            usuario_gral nuevo = comboBox1.SelectedItem as usuario_gral;
            bd.usuarios.Remove(nuevo);

            //actualiza los items del combobox
            comboBox1.Items.Clear();
            foreach (var item in bd.usuarios)
            {
                comboBox1.Items.Add(item);
            }
            comboBox1.Text = "";
            
            //guarda el archivo
            bd.Save();

        }

        //cierra la ventana
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

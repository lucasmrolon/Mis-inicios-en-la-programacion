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
    public partial class crear_empresa : Form
    {
        //borra los colectivos sin asignar a empresa de la base de datos
        public crear_empresa()
        {
            InitializeComponent();
            Basededatos bd = Archivo.Open();
            bd.colectivo.Clear();
            bd.Save();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                //crea un objeto empresa usando el constructor
                Empresa nueva = new Empresa(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text,
                    textBox5.Text, textBox7.Text);

                //esta variable se usa para ver si el nombre de la empresa esta disponible
                bool disponible=true;

                //abre la base de datos
                Basededatos bd = Archivo.Open();

                //revisa que no exista una empresa con el mismo nombre
                foreach (var item in bd.empresas)
                    if (item.nombre == textBox1.Text)
                        disponible = false;

                //si no existe la empresa, le asigna los colectivos y la guarda en el archivo
                if (disponible == true)
                {
                    //asigna los colectivos a la empresa
                    foreach (var item in bd.colectivo)
                        nueva.colectivos.Add(item);

                    //agrega la empresa a la lista de empresas
                    bd.empresas.Add(nueva);
                    bd.Save();

                    this.Close();
                }
                //si ya existe la empresa, muestra un mensaje de error
                else
                    MessageBox.Show("Ya existe una empresa con ese nombre.", "¡Error!",
                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            //si no se asigna un nombre a la empresa, no se puede crear la misma
            else
                MessageBox.Show("La empresa debe tener al menos un nombre", "¡Error!",
                    MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        //abre la ventana para cargar colectivos
        private void button2_Click(object sender, EventArgs e)
        {
            patentes nuevo = new patentes();
            nuevo.Show(this);
        }
    }
}

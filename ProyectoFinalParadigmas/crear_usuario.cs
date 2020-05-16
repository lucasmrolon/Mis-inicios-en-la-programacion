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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //verifica que los campos obligatorios no estén vacíos
                if (textBox1.Text != "" && textBox2.Text != "" && textBox7.Text != "" && textBox8.Text != ""
                    && textBox4.Text!="")
                {
                    // crea un objeto usuario usando el constructor
                    usuario_gral nuevo = new usuario_gral(textBox1.Text, textBox3.Text, int.Parse(textBox2.Text),
                        Convert.ToInt64(textBox4.Text), textBox6.Text, textBox5.Text, textBox7.Text, textBox8.Text);

                    //abre la base de datos
                    Basededatos bd = Archivo.Open();

                    //esta variable es para controlar que no exista el usuario
                    bool disponible = true;

                    //se busca coincidencias de usuarios en la lista de usuarios guardada
                    foreach (var item in bd.usuarios)
                        if (item.usuario == textBox7.Text)
                            disponible = false;

                    //si no existe el usuario, se añade a la base de datos
                    if (disponible == true)
                    {
                        bd.usuarios.Add(nuevo);
                        bd.Save();
                        this.Close();
                    }
                    //si ya existe el usuario, se solicita cambiar el mismo
                    else
                        MessageBox.Show("Nombre de Usuario no disponible. Seleccione otro.", "¡Advertencia!", MessageBoxButtons.OK,
                            MessageBoxIcon.Exclamation);
                }
                //si falta rellenar campos obligatorios, se muestra mensaje de error
                else
                    MessageBox.Show("Los campos marcados con * son obligatorios.", "¡Error!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch
            //si se ingresó un telefono o dni de formato incorrecto, se muestra mensaje de error
            {
                MessageBox.Show("Ha ingresado un DNI y/o Teléfono incorrectos", "¡Error!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);        
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

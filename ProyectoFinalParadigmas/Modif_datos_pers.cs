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
    public partial class Modif_datos_pers : Form
    {
        public Modif_datos_pers()
        {
            InitializeComponent();
            
            //abre la base de datos y carga el usuario activo
            Basededatos bd = Archivo.Open();
            usuario_gral us = bd.usuario_activo;

            //muestra en pantalla los datos del usuario activo
            textBox1.Text = us.nombre;
            textBox5.Text = us.nacimiento;
            textBox8.Text = us.email;
            textBox6.Text = us.usuario;
            textBox2.Text = (us.dni).ToString();
            textBox3.Text = us.domicilio;
            textBox4.Text = (us.telefono).ToString();
            textBox7.Text = us.contraseña;

            //cierra la base de datos
            bd.Save();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Basededatos bd;

                //verifica que los campos obligatorios no estén vacíos
                if (textBox1.Text != "" && textBox2.Text != "" && textBox4.Text != "" && textBox6.Text != "" && textBox7.Text != "")
                {
                    //abre el archivo
                    bd = Archivo.Open();

                    //carga usuario activo
                    usuario_gral us = bd.usuario_activo;

                    bool disponible = true;

                    foreach (var item in bd.usuarios)
                        if (item.usuario == textBox6.Text)
                            disponible = false;

                    if (disponible == true)
                    {
                        //guarda los cambios en los datos del usuario activo
                        us.nombre = textBox1.Text;
                        us.nacimiento = textBox5.Text;
                        us.email = textBox8.Text;
                        us.usuario = textBox6.Text;
                        us.dni = int.Parse(textBox2.Text);
                        us.domicilio = textBox3.Text;
                        us.telefono = Convert.ToInt64(textBox4.Text);
                        us.contraseña = textBox7.Text;

                        //guarda la base de datos y cierra la ventana
                        bd.Save();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Ya existe el usuario ingresado.", "¡Error!",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox6.Text = us.usuario;
                    }
                }

                //si falta completar campos obligatorios, muestra mensaje de error
                else
                    MessageBox.Show("Los campados marcados con * son obligatorios.", "¡Error!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //si ingresa un DNI o teléfono de formato incorrecto, muestra un mensaje de error
            catch
            {
                MessageBox.Show("Ha ingresado un DNI y/o Teléfono incorrectos", "¡Error!",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }
    }
}

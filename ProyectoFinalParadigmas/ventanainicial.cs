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
    public partial class ventanainicial : Form
    {
        public ventanainicial()
        {
            InitializeComponent();
        }

        //muestra los campos a completar para iniciar sesión
        private void button1_Click(object sender, EventArgs e)
        {
            button1.Visible = false;
            label1.Visible = label2.Visible = textBox1.Visible = textBox2.Visible = true;
            button2.Visible = button3.Visible = true;
        }

        //inicia sesión
        private void button2_Click(object sender, EventArgs e)
        {
            bool valido=false;
            menuadmin admin;
            menuusuario nuevo;
            
            //verifica si es el administrador
            if (textBox1.Text == "admin" && textBox2.Text == "pass")
            {
                admin = new menuadmin();
                admin.Show();
            }
     
            else
            {
                //busca coincidencias de usuario y contraseña
                Basededatos bd = Archivo.Open();
                foreach (var item in bd.usuarios)
                    if (item.contraseña == textBox2.Text && item.usuario == textBox1.Text)
                    {
                        valido = true;
                        bd.usuario_activo = item;
                    }

                //si encuentra coincidencia, abre ventana de usuario
                if (valido == true)
                {
                    nuevo = new menuusuario();
                    nuevo.Show();
                }

                // si no, muestra mensaje de error
                else
                {
                    MessageBox.Show("Usuario o contraseña inválidos", "¡Error!", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                }
                bd.Save();
            }
            textBox1.Text = textBox2.Text = "";

        }

        //abre ventana de creación de usuario
        private void button3_Click(object sender, EventArgs e)
        {
            Form1 nuevo = new Form1();
            nuevo.Show();
        }
    }
}

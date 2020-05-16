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
    public partial class menuadmin : Form
    {
        public menuadmin()
        {
            InitializeComponent();

            //muestra la fecha y hora actual en la ventana de administrador
            DateTime dt = DateTime.Now;
            label4.Text = dt.ToLongTimeString();
            timer1.Enabled = true;
        }

        //muestra en el label la hora
        private void timer1_Tick(object sender, EventArgs e)
        {
            label4.Text = DateTime.Now.ToString();
        }

        //abre ventana de crear viaje
        private void button1_Click(object sender, EventArgs e)
        {
            crear_viaje nuevo = new crear_viaje();
            nuevo.Show(this);
        }

        //abre ventana de modificar viaje
        private void button3_Click(object sender, EventArgs e)
        {
            modificar_viaje nuevo = new modificar_viaje();
            nuevo.Show(this);
        }

        //abre ventana de crear empresa
        private void button2_Click(object sender, EventArgs e)
        {
            crear_empresa nuevo = new crear_empresa();
            nuevo.Show(this);
        }

        //abre ventana de modificar empresa
        private void button4_Click(object sender, EventArgs e)
        {
            modif_empresa nuevo = new modif_empresa();
            nuevo.Show(this);
        }

        //abre lista de usuarios registrados
        private void button5_Click(object sender, EventArgs e)
        {
            lista_usuarios nueva = new lista_usuarios();
            nueva.Show(this);
        }

        //cierra la sesion
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        //abre ventana de agregar ciudad
        private void button6_Click(object sender, EventArgs e)
        {
            nueva_ciudad nueva = new nueva_ciudad();
            nueva.Show(this);
        }

        //abre ventana para eliminar ciudades
        private void button7_Click(object sender, EventArgs e)
        {
            eliminar_ciudad nueva = new eliminar_ciudad();
            nueva.Show(this);
        }
    }
}

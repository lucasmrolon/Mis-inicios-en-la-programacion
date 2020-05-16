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
    public partial class menuusuario : Form
    {
        public menuusuario()
        {
            InitializeComponent();

            //inicializa la ventana poniendo en pantalla la fecha y hora actual y el usuario activo
            DateTime dt = DateTime.Now;
            label3.Text = dt.ToLongTimeString();
            timer1.Enabled = true;
        }

        //abre ventana de modificar datos personales
        private void button1_Click(object sender, EventArgs e)
        {
            Modif_datos_pers nuevo = new Modif_datos_pers();
            nuevo.Show(this);
        }

        //abre ventana para ver viajes comprados
        private void button2_Click(object sender, EventArgs e)
        {
            ver_viajes nuevo = new ver_viajes();
            nuevo.Show(this);
        }

        //abre ventana para seleccionar nuevo viaje
        private void button3_Click(object sender, EventArgs e)
        {
            seleccionar_viaje nuevo = new seleccionar_viaje();
            nuevo.Show(this);
        }

        //cierra la sesión
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        //para actualizar la hora cada segundo
        private void timer1_Tick(object sender, EventArgs e)
        {
            label3.Text = DateTime.Now.ToString();
        }

        private void menuusuario_Load(object sender, EventArgs e)
        {

        }
    }

}

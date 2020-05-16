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
    public partial class ver_viajes : Form
    {
        Basededatos bd;
        public ver_viajes()
        {
            InitializeComponent();

            //abre el archivo y carga en el combobox la lista de viajes comprados por el usuario
            bd = Archivo.Open();
            List<viaje> viajes = bd.usuario_activo.viajes;
            foreach (var item in viajes)
                comboBox1.Items.Add(item);
        }

        //carga en los campos la información del viaje seleccionado
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            button2.Enabled = true;

            viaje selec = comboBox1.SelectedItem as viaje;

            textBox1.Text = selec.dev_origen();         //ORIGEN
            textBox2.Text = selec.dev_destino();        //DESTINO
            textBox3.Text = selec.dev_categoria();      //CATEGORIA
            textBox4.Text = selec.dev_empresa();        //EMPRESA
            textBox5.Text = selec.dev_fecha();          //FECHA
            textBox6.Text = selec.dev_hora();           //HORA
            textBox7.Text = (selec.asientos_libres().Last()).ToString();    //ASIENTO COMPRADO
            textBox8.Text = selec.devolver_tipo();      //TIPO DE PASAJE
        }

        //cancela el viaje seleccionado
        private void button2_Click(object sender, EventArgs e)
        {
            //vacia los campos
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = "";
            textBox5.Text = textBox6.Text = textBox7.Text = "";
            textBox8.Text = comboBox1.Text = "";
            
            viaje selec = comboBox1.SelectedItem as viaje;

            string empresa = selec.dev_empresa();         
            
            //recoge el asiento devuelto...
            int asiento_devuelto = selec.asientos_libres().Last();

            //elimina el viaje
            bd.usuario_activo.viajes.Remove(selec);

            //devuelve el asiento al viaje
            foreach (var item in bd.viajes)
                if (item.dev_colectivo() == selec.dev_colectivo())
                {
                    item.cargar_asiento(asiento_devuelto);
                }

            //y actualiza los viajes disponibles en el combobox
            comboBox1.Items.Clear();
            foreach (var item in bd.usuario_activo.viajes)
                comboBox1.Items.Add(item);
            bd.Save();
        }

        //cierra ventana y abre ventana de "Seleccionar nuevo viaje"
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            seleccionar_viaje nuevo = new seleccionar_viaje();
            nuevo.Show();
        }

        //cierra la ventana
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

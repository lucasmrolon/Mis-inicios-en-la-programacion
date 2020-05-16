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
    public partial class crear_viaje : Form
    {
        Basededatos bd = Archivo.Open();
        public crear_viaje()
        {
            InitializeComponent();

            //carga los combobox de origen y destino
            foreach (var item in bd.ciudades)
            {
                comboBox3.Items.Add(item);
                comboBox3.Sorted = true;
                comboBox4.Items.Add(item);
                comboBox4.Sorted = true;
            }

            //carga el combobox de empresas
            foreach(var item in bd.empresas)
            {
                comboBox5.Items.Add(item);
                comboBox5.Sorted = true;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //instancia las ciudades, empresa y colectivo seleccionados
                ciudad origen = comboBox3.SelectedItem as ciudad;
                ciudad destino = comboBox4.SelectedItem as ciudad;
                Empresa empresa = comboBox5.SelectedItem as Empresa;
                colectivo colectivo = comboBox6.SelectedItem as colectivo;

                //se crea strings de fecha y hora de viaje
                DateTime dt = dateTimePicker1.Value;
                string fecha = dt.ToShortDateString();
                string hora = comboBox1.Text;

                //se crea string de categoría
                string categoria = comboBox2.Text;

                //se crea el viaje usando el constructor
                viaje nuevo = new viaje(origen, destino, fecha, hora, empresa, colectivo, categoria);

                bd = nuevo.reservar_colectivo(bd, empresa.nombre, colectivo.patente);

                //se crean los 30 asientos que tiene un colectivo
                nuevo.crear_asientos();

                //se calcula la distancia del viaje
                nuevo.calcular_km();

                //se calcula el precio por distancia
                nuevo.calcular_precio();

                //se añade el precio por categoría establecida
                nuevo.establecer_categoria(categoria);
                nuevo.sumar_categoria();

                //se añade a la lista de viajes y se guarda
                bd.viajes.Add(nuevo);
                bd.Save();

                //regresa a la ventana anterior
                this.Owner.Show();
                this.Close();
            }
            catch
            {
                MessageBox.Show("Falta rellenar campos", "¡Error!", MessageBoxButtons.OK,
                           MessageBoxIcon.Warning);
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            //carga los colectivos disponibles que posee la empresa
            Empresa empresa = comboBox5.SelectedItem as Empresa;
            comboBox6.Items.Clear();
            foreach (var item in empresa.colectivos)
                if (item.devolver_estado() == true)
                    comboBox6.Items.Add(item);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //cancela y vuelve a la ventana anterior
            bd.Save();
            this.Close();
        }
    }
}

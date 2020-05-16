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
    public partial class modif_empresa : Form
    {
        Basededatos bd;
        Empresa empresa;

        public modif_empresa()
        {
            InitializeComponent();

            //abre la base de datos y carga en el combobox las empresas existentes
            bd = Archivo.Open();

            foreach(var item in bd.empresas)
            {
                comboBox1.Items.Add(item);
                comboBox1.Sorted = true;
            }
            comboBox1.Text = "";
            bd.Save();

        }
        
        //vuelve a la ventana anterior y guarda los cambios
        private void button2_Click(object sender, EventArgs e)
        {
            //verifica que se haya seleccionado una empresa
            if (comboBox1.Text != "")
            {
                //guarda los cambios realizados a la empresa
                empresa.email = textBox2.Text;
                empresa.cuit = textBox3.Text;
                empresa.direccion = textBox4.Text;
                empresa.sede = textBox5.Text;
                empresa.sitio_web = textBox7.Text;

                //guarda los colectivos pertenecientes a la empresa
                foreach (var item in bd.empresas)
                    if (item.nombre == empresa.nombre)
                        item.colectivos = empresa.colectivos;

                //guarda la base de datos
                bd.Save();
            }
            this.Close();
        }
        //lee el elemento del combobox
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "")
            {
                //muestra en pantalla los datos de la empresa seleccionada
                empresa = comboBox1.SelectedItem as Empresa;

                textBox1.Text = empresa.nombre;
                textBox2.Text = empresa.email;
                textBox3.Text = empresa.cuit;
                textBox4.Text = empresa.direccion;
                textBox5.Text = empresa.sede;
                textBox7.Text = empresa.sitio_web;

                //actualiza el contenido del combobox de colectivos
                comboBox2.Items.Clear();
                foreach (var item in empresa.colectivos)
                    comboBox2.Items.Add(item);
            }
        }

        //elimina empresa
        private void button3_Click(object sender, EventArgs e)
        {
            //borra la empresa de la base de datos
            bd.empresas.Remove(empresa);

            List<viaje> a_eliminar = null;
            
            //actualiza el combobox de empresas
            comboBox1.Items.Clear();
            foreach (var item in bd.empresas)
                comboBox1.Items.Add(item);
            
            //elimina los viajes de la empresa de la base de datos y guarda el archivo
            foreach (var item in bd.viajes)
                if (item.recibir_empresa() == empresa)
                    a_eliminar.Add(item);
            comboBox2.Items.Clear();
            foreach (var item in a_eliminar)
                bd.viajes.Remove(item);
            bd.Save();

            //deja todos los campos en blanco
            comboBox1.Text = comboBox2.Text = "";
            textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox7.Text = " ";

        }

        //para borrar colectivos de la lista
        private void button4_Click(object sender, EventArgs e)
        {

            colectivo colectivo = comboBox2.SelectedItem as colectivo;

            //si libre=true, el colectivo no tiene un viaje asignado
            bool libre = true;

            //verifica que el colectivo no este asignado a un viaje. Si lo está, muestra mensaje de error
            foreach (var item in bd.viajes)
                if (item.recibir_colectivo() == colectivo)
                {
                    MessageBox.Show("No se puede eliminar un colectivo asignado a un viaje. Debe cancelar el viaje primero.", "¡Invalido!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    libre = false;
                }

            //si el colectivo esta libre, lo quita de la lista
            if (libre == true)
            {
                comboBox2.Items.Remove(colectivo);
                empresa.colectivos.Remove(colectivo);
            }
            comboBox2.Text = "";
        }

        //hace visible el textbox para añadir un colectivo
        private void button5_Click(object sender, EventArgs e)
        {
            textBox6.Visible = button7.Visible = true;
        }


        private void button6_Click(object sender, EventArgs e)
        {

        }

        //añade el colectivo y actualiza el combobox de colectivos
        private void button7_Click(object sender, EventArgs e)
        {
            //añade al combobox la nueva matrícula
            string nueva_matricula = textBox6.Text;
            comboBox2.Items.Add(nueva_matricula);

            //añade el colectivo a la empresa
            colectivo nuevo = new colectivo();
            nuevo.patente = textBox6.Text;
            empresa.colectivos.Add(nuevo);

            //oculta el textbox de añadir colectivo
            textBox6.Text = "";
            textBox6.Visible = button7.Visible = false;
        }
    }
}

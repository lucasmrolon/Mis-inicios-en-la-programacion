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
    public partial class patentes : Form
    {
        public patentes()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            //verifica que se haya ingresado una matrícula válida
            if (textBox1.Text != "" && textBox1.Text != " " && textBox1.Text != "  " && textBox1.Text != "   ")
            {
                //crea el colectivo con la matrícula indicada 
                colectivo nuevo = new colectivo();
                nuevo.patente = textBox1.Text;

                //abre la base de datos y guarda el colectivo creado para poder añadirlo a la empresa más adelante
                Basededatos bd = new Basededatos();
                bd = Archivo.Open();
                bd.colectivo.Add(nuevo);

                //guarda la base de datos
                bd.Save();
            }

            //cierra la ventana
            this.Close();
        }
    }
}

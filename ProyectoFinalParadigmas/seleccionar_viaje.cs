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
    public partial class seleccionar_viaje : Form
    {
        Basededatos bd;
        pasaje_general general;
        estudiante estudiante;
        jubilado jubilado;

        //inicializa la ventana abriendo la base de datos y cargando los combobox de origen y destino
        public seleccionar_viaje()
        {
            InitializeComponent();
            bd = Archivo.Open();

            //carga los combobox de origen y destino con las ciudades disponibles
            foreach (var item in bd.ciudades)
            {
                comboBox2.Items.Add(item);
                comboBox2.Sorted = true;
                comboBox3.Items.Add(item);
                comboBox3.Sorted = true;
            }
        }

        //muestra en pantalla los datos del viaje seleccionado
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            viaje nuevo = comboBox1.SelectedItem as viaje;

            textBox1.Text = nuevo.dev_fecha();                  //FECHA
            textBox2.Text = nuevo.dev_hora();                   //HORA
            CATEGORIAtextBox2.Text = nuevo.dev_categoria();     //CATEGORIA
            EPRESAtextBox3.Text = nuevo.dev_empresa();          //EMPRESA

            label10.Text=(nuevo.numero_de_asientos()).ToString();   //N° DE ASIENTOS LIBRES

            //carga en el combobox la lista de asientos disponibles
            comboBox4.Items.Clear();
            foreach (var item in nuevo.asientos_libres())
                comboBox4.Items.Add(item);
        }


        //busca en la base de datos coincidencias de origen y destino
        private void button3_Click(object sender, EventArgs e)
        {
            ciudad origen = comboBox2.SelectedItem as ciudad;
            
            ciudad destino = comboBox3.SelectedItem as ciudad;

            //carga en el combobox la lista de viajes que satisfagan la busqueda realizada
            comboBox1.Items.Clear();
            label16.Text = "";
            bool encontro = false;
            foreach (var item in bd.viajes)
                if (item.dev_origen()==origen.devolver_nombre() 
                    && item.dev_destino()==destino.devolver_nombre())
                {
                    comboBox1.Items.Add(item);
                    encontro = true;
                }
            if (encontro == false)
                label16.Text = "No se encontraron viajes.";
        }

        //cancela y regresa a la ventana anterior
        private void button2_Click(object sender, EventArgs e)
        {
            bd.Save();
            this.Close();
        }

        //crea el viaje y lo guarda en la lista de viajes comprados
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //variable que indica el tipo de pasaje seleccionado
                string tipo;

                //variable que indica que se ingresaron todos los campos requeridos
                bool correcto = false;

                //controla que se hayan completado los campos correspondientes de acuerdo al tipo de pasaje
                if (comboBox2.Text != "" && comboBox3.Text != "" && comboBox1.Text != "" && comboBox5.Text != "")
                {
                    if (comboBox5.Text == "General")
                        correcto = true;
                    else
                    {
                        if (comboBox5.Text == "Estudiante")
                        {
                            if (textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "")
                                correcto = true;
                        }
                        else
                        {
                            if (textBox3.Text != "")
                                correcto = true;
                        }
                    }

                    //si los campos están completos, crea el viaje para el usuario
                    if (correcto == true)
                    {
                        ciudad o = comboBox2.SelectedItem as ciudad;
                        ciudad d = comboBox3.SelectedItem as ciudad;
                        viaje elegido = comboBox1.SelectedItem as viaje;
                        tipo = comboBox5.Text;

                        //crea objeto viaje recogiendo datos del viaje elegido
                        viaje nuevo = new viaje(o, d, elegido.dev_fecha(), elegido.dev_hora(), elegido.recibir_empresa(),
                            elegido.recibir_colectivo(), elegido.dev_categoria());

                        //guarda categoria del viaje comprado
                        nuevo.establecer_categoria(CATEGORIAtextBox2.Text);

                        //guarda precio del viaje comprado
                        nuevo.asignar_precio(elegido.devolver_precio());

                        //guarda el tipo de pasaje elegido
                        if (comboBox5.Text == "Estudiante")
                            nuevo.asignar_tipo(estudiante.devolver_datos());
                        else
                        {
                            if (comboBox5.Text == "Jubilado")
                                nuevo.asignar_tipo(jubilado.devolver_datos());
                            else
                                nuevo.asignar_tipo(general.devolver_datos());
                        } 

                        string tipo_pasaje = comboBox5.Text;

                        double precio_descontado;

                        //recibe el precio del viaje
                        double precio_viaje = nuevo.devolver_precio();

                        //realiza el descuento correspondiente dependiendo del tipo de pasaje
                        if (tipo_pasaje == "General")
                            precio_descontado = general.aplicar_descuento(precio_viaje);
                        else
                        {
                            if (tipo_pasaje == "Estudiante")
                                precio_descontado = estudiante.aplicar_descuento(precio_viaje);
                            else
                                precio_descontado = jubilado.aplicar_descuento(precio_viaje);
                        }
                        nuevo.modificar_precio(precio_descontado);


                        //guarda el asiento elegido en el viaje del usuario, y lo quita de la lista de disponibles
                        int asiento_elegido = int.Parse(comboBox4.Text);
                        elegido.selec_asiento(asiento_elegido);
                        nuevo.cargar_asiento(asiento_elegido);

                        //agrega el viaje a la lista de viajes del usuario activo
                        usuario_gral usuario_activo = bd.usuario_activo;
                        bd.usuario_activo.viajes.Add(nuevo);

                        //guarda y cierra
                        bd.Save();
                        this.Close();
                    }
                    //si se ingresaron datos incorrectos, muestra mensaje de error
                    else
                        MessageBox.Show("Datos incorrectos", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            //si se ingresaron datos incorrectos, muestra mensaje de error
            catch
            {
                MessageBox.Show("Datos incorrectos", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //muestra los campos a completar dependiendo del tipo de pasaje elegido
        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            //si eligio estudiante...
            if (comboBox5.Text == "Estudiante")
            {
                label12.Visible = label13.Visible = label14.Visible = true;
                textBox4.Visible = textBox5.Visible = textBox6.Visible = true;
                label15.Visible = textBox3.Visible = false;
                button4.Visible = true;
            }
            else
            {
                //si eligio jubilado...
                if (comboBox5.Text == "Jubilado")
                {
                    label15.Visible = textBox3.Visible = button4.Visible = true;
                    label12.Visible = label13.Visible = label14.Visible = false;
                    textBox4.Visible = textBox5.Visible = textBox6.Visible = false;
                }
                //si eligio general...
                else
                {
                    label15.Visible = textBox3.Visible = false;
                    label12.Visible = label13.Visible = label14.Visible = false;
                    textBox4.Visible = textBox5.Visible = textBox6.Visible = false;
                }

            }
        }

        //guarda los datos ingresados correspondientes al tipo de pasaje
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {

                //si eligio estudiante...
                if (comboBox5.Text == "Estudiante")
                {
                    int libreta = int.Parse(textBox4.Text);
                    string carrera = textBox5.Text;
                    string universidad = textBox6.Text;
                    label12.Visible = label13.Visible = label14.Visible = false;
                    textBox4.Visible = textBox5.Visible = textBox6.Visible = false;
                    button4.Visible = false;

                    //crea objeto "tipo de pasaje estudiante"
                    estudiante = new estudiante(universidad, carrera, libreta);
                }
                else
                {

                    //si eligio jubilado...
                    if (comboBox5.Text == "Jubilado")
                    {
                        int carnet = int.Parse(textBox3.Text);
                        label15.Visible = textBox3.Visible = button4.Visible = false;

                        //crea objeto "tipo de pasaje jubilado"
                        jubilado = new jubilado(carnet);
                    }

                    //si eligio general...
                    else

                        //crea objeto "tipo de pasaje general"
                        general = new pasaje_general();
                }
            }

            //si se ingresaron datos incorrectos, muestra mensaje de error
            catch
            {
                MessageBox.Show("Datos incorrectos", "¡Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}


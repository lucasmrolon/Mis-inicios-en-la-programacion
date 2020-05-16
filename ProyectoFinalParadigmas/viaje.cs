using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalParadigmas
{
    [Serializable]
    public class viaje
    {
        ciudad origen;
        ciudad destino;
        string fecha;
        string hora;
        double km;
        double precio;
        List<int> asientos;
        colectivo colectivo = new colectivo();
        categoria categoria;
        Empresa empresa;
        string tipo;

        //permite ver la información del viaje cuando se carga en un combobox
        public override string ToString()
        {
            return origen.devolver_nombre() + " - " + destino.devolver_nombre() + " - " +
                fecha + " - " + hora + " - (" + categoria.tipo + ") " + " - $ " + (precio).ToString("N2");
        }

        //constructor
        public viaje (ciudad origen, ciudad destino,string fecha, string hora, Empresa empresa, colectivo colectivo,string categoria)
        {
            this.empresa = empresa;
            this.origen = origen;
            this.destino = destino;
            this.fecha = fecha;
            this.hora = hora;
            this.colectivo = colectivo;
            asientos = new List<int>();
        }

        //crea los asientos del colectivo
        public void crear_asientos()
        {
            for (int i = 1; i <= 30; i++)
                asientos.Add(i);
        }

        //calcula la distancia a recorrer
        public void calcular_km()
        {
            int[] o = this.origen.devolver_coordenadas();
            int[] d = this.destino.devolver_coordenadas();

            //calcula distancia vertical
            int vertical = Math.Abs(o[0] - d[0]);

            //calcula distancia horizontal
            int horizontal = Math.Abs(o[1] - d[1]);

            //calcula la distancia real
            this.km = Math.Sqrt(vertical * vertical + horizontal * horizontal);
        }

        //devuelve la distancia del viaje
        public double devolver_km()
        {
            return km;
        }

        //calcula el precio del viaje
        public void calcular_precio()
        {
            //obtiene el precio del combustible por cada km
            combustible combustible = colectivo.devolver_combustible();
            double pre_combustible = combustible.devolver_precio();

            //crea objeto tarifa para enviar a calculadora de precio
            tarifa nueva = new tarifa();
            double[] tablaprecios = nueva.devolver_tabla();

            //llama a calculadora de precio
            calculo_de_precio nuevo = new calculo_de_precio();
            this.precio = nuevo.calcular_precio(this.km, pre_combustible, tablaprecios);
        }

        //establece la categoria
        public void establecer_categoria(string cate)
        {
            categoria nueva = new categoria(cate);
            this.categoria = nueva;
        }

        //suma el precio por categoría
        public void sumar_categoria()
        {
            this.precio = categoria.det_precio(precio);
        }

        //devuelve el precio
        public double mostrar_precio()
        {
            return precio;
        }

        //devuelve el origem
        public string dev_origen()
        {
            return origen.devolver_nombre();
        }

        //devuelve el destino
        public string dev_destino()
        {
            return destino.devolver_nombre();
        }

        //devuelve la fecha del viaje
        public string dev_fecha()
        {
            return fecha;
        }

        //devuelve la hora del viaje
        public string dev_hora()
        {
            return hora;
        }

        //devuelve la categoría del viaje
        public string dev_categoria()
        {
            return categoria.tipo;
        }

        //devuelve la empresa del viaje
        public string dev_empresa()
        {
            return empresa.nombre;
        }

        //devuelve la matrícula del colectivo asignado
        public string dev_colectivo()
        {
            return colectivo.patente;
        }

        //devuelve la lista de asientos libres
        public List<int> asientos_libres()
        {
            return asientos;
        }

        //quita un asiento de la lista de asientos libres
        public void selec_asiento(int asiento)
        {
            asientos.Remove(asiento);
        }

        //carga a la lista el asiento devuelto
        public void cargar_asiento(int asiento)
        {
            asientos.Add(asiento);
            asientos.Sort();
        }

        //devuelve el número de asientos libres
        public int numero_de_asientos()
        {
            return asientos.Count();            
        }

        //devuelve el objeto empresa asociado
        public Empresa recibir_empresa()
        {
            return empresa;
        }

        //devuelve el objeto colectivo asociado
        public colectivo recibir_colectivo()
        {
            return colectivo;
        } 

        //asigna un precio arbitrario
        public void asignar_precio(double precio)
        {
            this.precio = precio;
        }

        //devuelve el precio del viaje
        public double devolver_precio()
        {
            return precio;
        }

        //modifica el precio del viaje
        public void modificar_precio(double nuevo_precio)
        {
            precio = nuevo_precio;
        }

        //devuelve el tipo de pasaje comprado
        public string devolver_tipo()
        {
            return tipo;
        }

        //asigna tipo de pasaje comprado
        public void asignar_tipo(string tipo)
        {
            this.tipo = tipo;
        }

        //reserva el colectivo asignado e impide que se pueda usar para otros viajes
        public Basededatos reservar_colectivo(Basededatos bd, string empresa, string patente_colectivo)
        {

            //busca coimcidencias de empresa
            foreach (var item in bd.empresas)
                if (item.nombre == empresa)
                    
                    //busca coincidencias de colectivo
                    foreach (var item2 in item.colectivos)
                        if (item2.patente == patente_colectivo)
                        {

                            //le asigna el estado "NO DISPONIBLE"
                            colectivo = item2;
                            item2.modificar_estado(false);
                        }
            return bd;

        }

        //si el viaje se cancela, se libera el colectivo para ser usado por otros viajes
        public Basededatos liberar_colectivo(Basededatos bd)
        {

            //busca coincidencias de empresa
            foreach (var item in bd.empresas)
                if (item.nombre == empresa.nombre)
                    
                    //si encuentra, busca coincidencias de colectivo
                    foreach (var item2 in item.colectivos)
                        if (item2.patente == colectivo.patente)
                        {

                            //le asigna el estado DISPONIBLE
                            item2.modificar_estado(true);
                        }
            return bd;
        }
    }
}

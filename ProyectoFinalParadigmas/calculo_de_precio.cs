using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoFinalParadigmas
{
    class calculo_de_precio
    {
        public double calcular_precio(double km,double precio_combustible,double[] tablaprecios)
        {
            //calcula precio por combustible
            double preciobase,preciocombustible;
            preciocombustible = km * precio_combustible;

            //calcula precio por distancia
            if (km < 100)
            {
                preciobase = tablaprecios[0];
            }
            else
            {
                if (km < 250)
                {
                    preciobase = tablaprecios[1];
                }
                else
                {
                    if (km < 400)
                    {
                        preciobase = tablaprecios[2];
                    }
                    else
                    {
                        if (km < 650)
                        {
                            preciobase = tablaprecios[3];
                        }
                        else
                        {
                            if (km < 900)
                            {
                                preciobase = tablaprecios[4];
                            }
                            else
                            {
                                preciobase = tablaprecios[5];
                            }
                        }
                    }
                }
            }

            //suma los precios
            return preciobase + preciocombustible;

        }
    }
}

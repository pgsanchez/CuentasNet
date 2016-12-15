using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CuentasNet
{
    public class Categoria
    {
        private String nombre;
        private bool gasto; // True: se utiliza para la lista de gastos. False: no se utiliza.
        private bool ingreso; // True: se utiliza para la lista de ingresos. False: no se utiliza.

        public String Nombre
        {
            set
            {
                nombre = value;
            }
            get
            {
                return nombre;
            }
        }

        public bool Gasto
        {
            set
            {
                gasto = value;
            }
            get
            {
                return gasto;
            }
        }

        public bool Ingreso
        {
            set
            {
                ingreso = value;
            }
            get
            {
                return ingreso;
            }
        }

        public Categoria()
        {
            nombre = "";
            gasto = true;
            ingreso = false;
        }
    }
}

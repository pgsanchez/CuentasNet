using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CuentasNet
{
    public class Ingreso
    {
        private int id;
        private float cantidad;
        private String concepto;
        private DateTime fecha;
        private String categoria;

        public Ingreso()
        {
            id = 0;
            cantidad = 0;
            concepto = "";
            fecha = System.DateTime.Today;
            categoria = "";
        }

        public int Id
        {
            set
            {
                id = value;
            }
            get
            {
                return id;
            }
        }

        public float Cantidad
        {
            set
            {
                cantidad = value;
            }
            get
            {
                return cantidad;
            }
        }

        public String Concepto
        {
            set
            {
                concepto = value;
            }
            get
            {
                return concepto;
            }
        }

        public DateTime Fecha
        {
            set
            {
                fecha = value;
            }
            get
            {
                return fecha;
            }
        }

        public String Categoria
        {
            set
            {
                categoria = value;
            }
            get
            {
                return categoria;
            }
        }
    }
}

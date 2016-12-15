using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CuentasNet
{
    public class Gasto
    {
        private int id;
        private float cantidad;
        private String concepto;
        private DateTime fecha;
        private String categoria;
        private int formaPago = 0;
        private String etiqueta1;

        public Gasto()
        {
            id = 0;
            cantidad = 0;
            concepto = "";
            fecha = System.DateTime.Today;
            categoria = "";
            etiqueta1 = "";
            // Añadir, para el futuro: Modo de pago: efectivo/tarjeta/transferencia
            //                         Etiquetas
        }

        public void Clear()
        {
            id = 0;
            cantidad = 0;
            concepto = "";
            fecha = System.DateTime.Today;
            categoria = "";
            etiqueta1 = "";
            formaPago = 0;
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
        public int FormaPago
        {
            set
            {
                formaPago = value;
            }
            get
            {
                return formaPago;
            }
        }
        public String Etiqueta1
        {
            set
            {
                etiqueta1 = value;
            }
            get
            {
                return etiqueta1;
            }
        }
    }
}

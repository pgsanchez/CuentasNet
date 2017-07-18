using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CuentasNet
{
    public class Mes
    {
        private String[] meses = {"Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"};
        private String nombre;
        private int anno;
        private DateTime fechaInicio = new DateTime(3000,1,1);
        private DateTime fechaFin = new DateTime(3000, 1, 1);

        public String GetFechaInicioSqlPlus()
        {
            return fechaInicio.Year.ToString() + "/" + fechaInicio.Month.ToString() + "/" + fechaInicio.Day.ToString();
        }

        public String GetFechaFinSqlPlus()
        {
            return fechaFin.Year.ToString() + "/" + fechaFin.Month.ToString() + "/" + fechaFin.Day.ToString();
        }

        public String GetMesFromNumero(int numMes)
        {
            if (numMes == 0)
                return meses[numMes];
            else
                return meses[numMes - 1];
        }

        public Mes()
        {
            nombre = "";
            anno = 3000;
        }

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
        public int Anno
        {
            set
            {
                anno = value;
            }
            get
            {
                return anno;
            }
        }
        public DateTime Inicio
        {
            set
            {
                fechaInicio = value;
            }
            get
            {
                return fechaInicio;
            }
        }
        public DateTime Fin
        {
            set
            {
                fechaFin = value;
            }
            get
            {
                return fechaFin;
            }
        }

        public String mesSiguiente()
        {
            String valor ="";
            for (int i=0; i<12; i++)
            {
                if ((meses[i].ToString() == nombre)&&(i<11))
                {
                    valor = meses[i+1].ToString();
                    break;
                }
                else
                {
                    valor = "Enero";
                }
            }
            return valor;
        }
    }
}

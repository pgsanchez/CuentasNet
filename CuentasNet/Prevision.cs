using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CuentasNet
{
    public class Prevision : Gasto
    {
        String mes = "";
        int anno = 3000;

        public Prevision()
        {
        }

        public String Mes
        {
            set
            {
                mes = value;
            }
            get
            {
                return mes;
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
    }
}

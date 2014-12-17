/*
 
 * Metodo de Biseccion V0.1
 * Naffer Reyes
 * 30/11/2014
 * 
 * Librerias
 * 
 * Oxyplot - Software Libre
 * Mathos - Derechos reservados / Uso solo con mencion

 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Biseccion
{
    public class Iteracion 
    {
     
        private int i;

        public int I
        {
            get { return i; }
            set { i = value; }
        }

        private double a;

        public double A
        {
            get { return a; }
            set { a = value; }
        }

        private double b;

        public double B
        {
            get { return b; }
            set { b = value; }
        }

        private double c;

        public double C
        {
            get { return c; }
            set { c = value; }
        }

        private double fc;

        public double Fc
        {
            get { return fc; }
            set { fc = value; }
        }

        private double error;

        public double Error
        {
            get { return error; }
            set { error = value; }
        }
    }
}

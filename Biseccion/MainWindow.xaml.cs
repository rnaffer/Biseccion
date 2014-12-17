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
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Biseccion
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        GraficaPrincipal PlanoCarteciano;
        List<Iteracion> Resultados;
        Stack<string> Funcion;

        public MainWindow()
        {
            InitializeComponent();
            PlanoCarteciano = new GraficaPrincipal();
            Resultados = new List<Iteracion>();
            Funcion = new Stack<string>();

            this.DataContext = PlanoCarteciano;
        }

        private void main_load(object sender, RoutedEventArgs e)
        {
        }

        #region Click en botones

        private void boton_1_Click_1(object sender, RoutedEventArgs e)
        {
            txt_funcion.Text += "1";
            Funcion.Push("1");
        }

        private void boton_2_Click_1(object sender, RoutedEventArgs e)
        {
            txt_funcion.Text += "2";
            Funcion.Push("2");
        }

        private void boton_3_Click_1(object sender, RoutedEventArgs e)
        {
            txt_funcion.Text += "3";
            Funcion.Push("3");
        }

        private void boton_4_Click_1(object sender, RoutedEventArgs e)
        {
            txt_funcion.Text += "4";
            Funcion.Push("4");
        }

        private void boton_5_Click_1(object sender, RoutedEventArgs e)
        {
            txt_funcion.Text += "5";
            Funcion.Push("5");
        }

        private void boton_6_Click_1(object sender, RoutedEventArgs e)
        {
            txt_funcion.Text += "6";
            Funcion.Push("6");
        }

        private void boton_7_Click_1(object sender, RoutedEventArgs e)
        {
            txt_funcion.Text += "7";
            Funcion.Push("7");
        }

        private void boton_8_Click_1(object sender, RoutedEventArgs e)
        {
            txt_funcion.Text += "8";
            Funcion.Push("8");
        }

        private void boton_9_Click_1(object sender, RoutedEventArgs e)
        {
            txt_funcion.Text += "9";
            Funcion.Push("9");
        }

        private void boton_mas_Click_1(object sender, RoutedEventArgs e)
        {
            txt_funcion.Text += " + ";
            Funcion.Push(" + ");
        }

        private void boton_menos_Click_1(object sender, RoutedEventArgs e)
        {
            txt_funcion.Text += " - ";
            Funcion.Push(" - ");
        }

        private void boton_0_Click_1(object sender, RoutedEventArgs e)
        {
            txt_funcion.Text += "0";
            Funcion.Push("0");
        }

        private void boton_multi_Click_1(object sender, RoutedEventArgs e)
        {
            txt_funcion.Text += " * ";
            Funcion.Push(" * ");
        }

        private void boton_div_Click_1(object sender, RoutedEventArgs e)
        {
            txt_funcion.Text += " / ";
            Funcion.Push(" / ");
        }

        private void boton_pot_Click_1(object sender, RoutedEventArgs e)
        {
            txt_funcion.Text += "^";
            Funcion.Push("^");
        }

        private void boton_sen_Click_1(object sender, RoutedEventArgs e)
        {
            txt_funcion.Text += "Sen(";
            Funcion.Push("Sen(");
        }

        private void boton_cos_Click_1(object sender, RoutedEventArgs e)
        {
            txt_funcion.Text += "Cos(";
            Funcion.Push("Cos(");
        }

        private void boton_tan_Click_1(object sender, RoutedEventArgs e)
        {
            txt_funcion.Text += "Tan(";
            Funcion.Push("Tan(");
        }

        private void boton_atan_Click_1(object sender, RoutedEventArgs e)
        {
            txt_funcion.Text += "Atan(";
            Funcion.Push("Atan(");
        }

        private void boton_Sqrt_Click_1(object sender, RoutedEventArgs e)
        {
            txt_funcion.Text += "Sqrt(";
            Funcion.Push("Sqrt(");
        }

        private void boton_log_Click_1(object sender, RoutedEventArgs e)
        {
            txt_funcion.Text += "Log(";
            Funcion.Push("Log(");
        }

        private void boton_ln_Click_1(object sender, RoutedEventArgs e)
        {
            txt_funcion.Text += "Ln(";
            Funcion.Push("Ln(");
        }

        private void boton_punto_Click_1(object sender, RoutedEventArgs e)
        {
            txt_funcion.Text += ".";
            Funcion.Push(".");
        }

        private void boton_x_Click_1(object sender, RoutedEventArgs e)
        {
            txt_funcion.Text += "x";
            Funcion.Push("x");
        }

        private void boton_abre_Click_1(object sender, RoutedEventArgs e)
        {
            txt_funcion.Text += "(";
            Funcion.Push("(");
        }

        private void boton_cierra_Click_1(object sender, RoutedEventArgs e)
        {
            txt_funcion.Text += ")";
            Funcion.Push(")");
        }

        private void boton_e_Click_1(object sender, RoutedEventArgs e)
        {
            txt_funcion.Text += "e";
            Funcion.Push("e");
        }

        #endregion

        private void boton_c_Click_1(object sender, RoutedEventArgs e)
        {
            if (Funcion.Count != 0)
            {
                var delete = txt_funcion.Text.LastIndexOf(Funcion.Pop());
                txt_funcion.Text = txt_funcion.Text.Remove(delete);
            }
        }

        private void boton_clr_Click_1(object sender, RoutedEventArgs e)
        {
            if (Funcion.Count != 0)
            {
                Funcion.Clear();
                txt_funcion.Text = "";
            }
        }

        private void boton_calcular_Click_1(object sender, RoutedEventArgs e)
        {
            bool tieneRaiz = true;

            try
            {
                ValidarFuncion();

                PlanoCarteciano.Funcion = txt_funcion.Text;

                if (!verificarSiTieneRaiz())
                {
                    tieneRaiz = false;
                    throw new Exception();
                }

                if (biseccion())
                {
                    PlanoCarteciano.GraficarFuncion(A()-5,B()+5, 0.1);
                    CrearAnotaciones();
                }

                plano.InvalidatePlot(true);
            }
            catch (Exception)
            {
                if (tieneRaiz == false)
                {
                    MessageBox.Show("La funcion evaluada en los puntos indicados no pasa por la raiz!");
                    PlanoCarteciano.GraficarFuncion(A()-5, B()+5, 0.1);
                    CrearAnotaciones();
                    plano.InvalidatePlot(true);
                }
                else
                {
                    MessageBox.Show("Funcion Invalida, sintaxis incorrecta - Para mas informacion revise la ayuda");
                }
            }
        }

        private void CrearAnotaciones()
        {
            PlanoCarteciano.HacerAnotacion1(A(), "A");
            PlanoCarteciano.HacerAnotacion2(B(), "B");
        }

        private bool verificarSiTieneRaiz()
        {
            try
            {
                double a = A();
                double b = B();
                double fa = PlanoCarteciano.EvaluarLambda(a);
                double fb = PlanoCarteciano.EvaluarLambda(b);

                if ((fa > 0 && fb > 0) || (fa < 0 && fb < 0))
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("Error en los datos de iteracion");
                return true;
            }
        }

        private bool biseccion()
        {
            Resultados.Clear();
            DT_resultado.ItemsSource = null;

            try
            {
                double a = A();
                double b = B();
                int iteraciones = Convert.ToInt32(txt_i.Text);
                double c = (a + b) / 2;
                double fc = PlanoCarteciano.EvaluarLambda(c);
                double cAnterior = 0;
                double error = 100;

                for (int i = 0; i < iteraciones; i++)
                {
                    if (i == 0)
                    {
                        Resultados.Add(new Iteracion { A = a, B = b, C = c, Fc = fc, I = i+1, Error = error });
                    }
                    else
                    {
                        if (fc * PlanoCarteciano.EvaluarLambda(a) > 0)
                        {
                            a = Math.Round(c, 9);
                        }
                        else
                        {
                            b = Math.Round(c, 9);
                        }
                        cAnterior = c;
                        c = Math.Round((a + b) / 2, 9);
                        fc = Math.Round(PlanoCarteciano.EvaluarLambda(c),9);
                        error = Math.Abs(Math.Round((c - cAnterior) / c, 6));

                        Resultados.Add(new Iteracion { A = a, B = b, C = c, Fc = fc, I = i+1, Error = error });
                    }
                }

                DT_resultado.ItemsSource = Resultados;
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("Error en los datos de iteracion");
                return false;
            }
        }

        public void ValidarFuncion()
        {
            bool estaAbiertoParentesis = false;

            for (int i = Funcion.Count - 1; i >= 0; i--)
            {
                if (i == Funcion.Count - 1)
                {
                    if (Funcion.ElementAt(i) == " + " || Funcion.ElementAt(i) == " * " ||
                        Funcion.ElementAt(i) == " / " || Funcion.ElementAt(i) == "^" || Funcion.ElementAt(i) == ")"
                        || Funcion.ElementAt(i) == ".")
                    {
                        throw new Exception();
                    }
                }

                if (i != 0)
                {
                    if (Funcion.ElementAt(i) == " + " || Funcion.ElementAt(i) == " - " || Funcion.ElementAt(i) == " * " ||
                        Funcion.ElementAt(i) == " / ")
                    {
                        if (Funcion.ElementAt(i - 1) == " + " || Funcion.ElementAt(i - 1) == " - " ||
                            Funcion.ElementAt(i - 1) == " * " || Funcion.ElementAt(i - 1) == " / " ||
                            Funcion.ElementAt(i - 1) == "^" || Funcion.ElementAt(i - 1) == ")" || 
                            Funcion.ElementAt(i-1) == ".")
                        {
                            throw new Exception();
                        }
                    }

                    if (Funcion.ElementAt(i) == ")" || Funcion.ElementAt(i) == "x")
                    {
                        if (Funcion.ElementAt(i) != "x")
                        {
                            estaAbiertoParentesis = !estaAbiertoParentesis;
                        }

                        if (Funcion.ElementAt(i - 1) == "(" || Funcion.ElementAt(i - 1) == "1" ||
                            Funcion.ElementAt(i - 1) == "2" || Funcion.ElementAt(i - 1) == "3" ||
                            Funcion.ElementAt(i - 1) == "4" || Funcion.ElementAt(i - 1) == "5" ||
                            Funcion.ElementAt(i - 1) == "6" || Funcion.ElementAt(i - 1) == "7" ||
                            Funcion.ElementAt(i - 1) == "8" || Funcion.ElementAt(i - 1) == "9" ||
                            Funcion.ElementAt(i - 1) == "0" || Funcion.ElementAt(i - 1) == "e" || 
                            Funcion.ElementAt(i - 1) == "Sen(" || Funcion.ElementAt(i - 1) == "Cos(" ||
                            Funcion.ElementAt(i - 1) == "Log(" || Funcion.ElementAt(i - 1) == "Ln(" ||
                            Funcion.ElementAt(i - 1) == "Tan(" || Funcion.ElementAt(i - 1) == "x" ||
                            Funcion.ElementAt(i - 1) == "Atan(" || Funcion.ElementAt(i - 1) == ".")
                        {
                            throw new Exception();
                        }

                    }

                    if ((Funcion.ElementAt(i) == "^" || Funcion.ElementAt(i) == ".") && 
                        (Funcion.ElementAt(i - 1) == " + " || Funcion.ElementAt(i - 1) == " * " ||
                        Funcion.ElementAt(i - 1) == " / " || Funcion.ElementAt(i - 1) == "^" || 
                        Funcion.ElementAt(i - 1) == ")" || Funcion.ElementAt(i - 1) == "."))
                    {
                        throw new Exception();
                    }


                    if (Funcion.ElementAt(i) == "Sen(" || Funcion.ElementAt(i) == "Cos(" ||
                        Funcion.ElementAt(i) == "Log(" || Funcion.ElementAt(i) == "Ln(" ||
                        Funcion.ElementAt(i) == "Tan(" || Funcion.ElementAt(i) == "Sqrt(" ||
                        Funcion.ElementAt(i) == "Atan(" || Funcion.ElementAt(i) == "(")
                    {

                        estaAbiertoParentesis = !estaAbiertoParentesis;

                        if (Funcion.ElementAt(i - 1) == " + " || Funcion.ElementAt(i - 1) == ")" ||
                            Funcion.ElementAt(i - 1) == " * " || Funcion.ElementAt(i - 1) == " / " ||
                            Funcion.ElementAt(i - 1) == " ^ " || Funcion.ElementAt(i - 1) == "Cos(" ||
                            Funcion.ElementAt(i - 1) == "(" || Funcion.ElementAt(i - 1) == "Sqrt(" ||
                            Funcion.ElementAt(i - 1) == "Sen(" || Funcion.ElementAt(i - 1) == "Tan(" ||
                            Funcion.ElementAt(i - 1) == "Log(" || Funcion.ElementAt(i - 1) == "Ln(" ||
                            Funcion.ElementAt(i - 1) == "Atan(" || Funcion.ElementAt(i - 1) == ".")
                        {
                            throw new Exception();
                        }
                    }
                }

                if (i == 0)
                {
                    if (Funcion.ElementAt(i) == " + " || Funcion.ElementAt(i) == " - " || Funcion.ElementAt(i) == " * " ||
                        Funcion.ElementAt(i) == " / " || Funcion.ElementAt(i) == "^" || Funcion.ElementAt(i) == "(" || 
                        Funcion.ElementAt(i) == ".")
                    {
                        throw new Exception();
                    }

                    if (Funcion.ElementAt(i) == ")")
                    {

                        estaAbiertoParentesis = !estaAbiertoParentesis;

                    }
                }
            }

            if (estaAbiertoParentesis == true)
            {
                throw new Exception();
            }
        }

        private double A()
        {
            return Convert.ToDouble(txt_xa.Text.Replace(',', '.'), CultureInfo.InvariantCulture);
        }

        private double B()
        {
            return Convert.ToDouble(txt_xb.Text.Replace(',', '.'), CultureInfo.InvariantCulture);
        }
    }
}

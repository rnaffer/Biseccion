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
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.Axes;
using Mathos.Parser;
using OxyPlot.Annotations;


namespace Biseccion
{
    public class GraficaPrincipal
    {
        MathParser parser = new MathParser();

        public string Funcion { get; set; }
        public PlotModel MyModel { get; private set; }


        public GraficaPrincipal()
        {
            this.MyModel = new PlotModel();
            var linearAxis1 = new LinearAxis();
            linearAxis1.TextColor = OxyColor.FromRgb(245, 245, 245);
            linearAxis1.MajorGridlineStyle = LineStyle.Solid;
            linearAxis1.MinorGridlineStyle = LineStyle.Dot;
            this.MyModel.Axes.Add(linearAxis1);
            var linearAxis2 = new LinearAxis();
            linearAxis2.TextColor = OxyColor.FromRgb(245, 245, 245);
            linearAxis2.MajorGridlineStyle = LineStyle.Solid;
            linearAxis2.MinorGridlineStyle = LineStyle.Dot;
            linearAxis2.Position = AxisPosition.Bottom;
            linearAxis2.PositionAtZeroCrossing = true;
            this.MyModel.Axes.Add(linearAxis2);
            this.MyModel.LegendTitleFont = "Segoe Ui";
            this.MyModel.TitleColor = OxyColor.FromRgb(245,245,245);
            this.MyModel.LegendTextColor = OxyColor.FromRgb(245, 245, 245);
            this.MyModel.PlotAreaBorderColor = OxyColor.FromRgb(245, 245, 245);
        }

        public double EvaluarLambda(double x)
        {
            string s = Funcion;

            MathParser parser = new MathParser();

            parser.LocalVariables["x"] = (decimal)x;
            parser.LocalVariables["e"] = (decimal)Math.E;

            parser.LocalFunctions.Add("Cos", delegate(decimal[] n)
            {
                return (decimal)Math.Cos((double)n[0]);
            });

            parser.LocalFunctions.Add("Sen", delegate(decimal[] n)
            {
                return (decimal)Math.Sin((double)n[0]);
            });

            parser.LocalFunctions.Add("Tan", delegate(decimal[] n)
            {
                return (decimal)Math.Tan((double)n[0]);
            });

            parser.LocalFunctions.Add("Sqrt", delegate(decimal[] n)
            {
                return (decimal)Math.Sqrt((double)n[0]);
            });

            parser.LocalFunctions.Add("Ln", delegate(decimal[] n)
            {
                return (decimal)Math.Log((double)n[0]);
            });

            parser.LocalFunctions.Add("Log", delegate(decimal[] n)
            {
                return (decimal)Math.Log10((double)n[0]);
            });
            
            parser.LocalFunctions.Add("Atan", delegate(decimal[] n)
            {
                return (decimal)Math.Atan((double)n[0]);
            });

            try
            {
                return (double)parser.ProgrammaticallyParse(s);

            }
            catch (Exception)
            {
                return 0.0;
            }
        }

        public void GraficarFuncion(double xmin, double xmax, double escala = 5)
        {
            this.MyModel.Series.Clear();
            this.MyModel.Annotations.Clear();
            this.MyModel.Title = "Evaluando " + Funcion ;
            this.MyModel.ResetAllAxes();
            this.MyModel.Series.Add(new FunctionSeries(EvaluarLambda, xmin, xmax, escala, Funcion));
        }

        public void HacerAnotacion1(double x, string mensaje)
        {
            var arrowAnnotation1 = new ArrowAnnotation();
            arrowAnnotation1.Color = OxyColors.Green;
            arrowAnnotation1.TextColor = OxyColors.White;
            arrowAnnotation1.StartPoint = new DataPoint(x-1, 0.5);
            arrowAnnotation1.EndPoint = new DataPoint(x, 0);
            arrowAnnotation1.Text = mensaje;
            this.MyModel.Annotations.Add(arrowAnnotation1);
        }

        public void HacerAnotacion2(double x, string mensaje)
        {
            var arrowAnnotation2 = new ArrowAnnotation();
            arrowAnnotation2.Color = OxyColors.Green;
            arrowAnnotation2.TextColor = OxyColors.White;
            arrowAnnotation2.StartPoint = new DataPoint(x+1, 0.5);
            arrowAnnotation2.EndPoint = new DataPoint(x, 0);
            arrowAnnotation2.Text = mensaje;
            this.MyModel.Annotations.Add(arrowAnnotation2);
        }

    }
}

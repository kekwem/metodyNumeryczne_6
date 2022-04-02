using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace rozniczkowanie
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        double funkcja(double x)
        {
            //x^4 + x^3 + x^2 + x + var
            return Convert.ToDouble(text1.Text) * Math.Pow(x, 4) + Convert.ToDouble(text2.Text) * Math.Pow(x, 3) +
                Convert.ToDouble(text3.Text) * Math.Pow(x, 2) + Convert.ToDouble(text4.Text) * x + Convert.ToDouble(text5.Text);
            //return Math.Round(Math.Pow(x, 2) + 4 * x - 5, 2);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label4.Text += "\nDwupunktowe roznice zwykle\nTrzypunktowe roznice zwykle\nDwupunktowe roznice wsteczne" +
                "\nTrzypunktowe roznice wsteczne\nDwupunktowe roznice centralne\nCzteropunktowe roznice zwykle";
            label5.Text += "\nTrzypunktowe roznice zwykle\nTrzypunktowe roznice wsteczne\nTrzypunktowe roznice centralne" +
                "\nPieciopunktowe roznice centralne";


            double x = Convert.ToDouble(textBox1.Text);
            double h = Convert.ToDouble(textBox2.Text);

            double[] tablica_x = new double[5];
            double liczba_testowa = x - 2 * h;
            for (int j = 0; j < tablica_x.Length; j++)
            {
                tablica_x[j] = Math.Round(liczba_testowa + j * h, 1);
            }

            double[] f_x = new double[5];
            for (int j = 0; j < f_x.Length; j++)
            {
                f_x[j] = funkcja(tablica_x[j]);
            }

            int i = 2;
            double[] pierwsz = new double[6];
            pierwsz[0] = (f_x[i + 1] - f_x[i]) / h;
            pierwsz[1] = (-3 * f_x[i] + 4 * f_x[i + 1] - f_x[i + 2]) / (2 * h);
            pierwsz[2] = (f_x[i] - f_x[i - 1]) / h;
            pierwsz[3] = (f_x[i - 2] - 4 * f_x[i - 1] + 3 * f_x[i]) / (2 * h);
            pierwsz[4] = (f_x[i + 1] - f_x[i - 1]) / (2 * h);
            pierwsz[5] = (f_x[i - 2] - 8 * f_x[i - 1] + 8 * f_x[i + 1] - f_x[i + 2]) /( 12 * h);

            double[] druga = new double[4];
            druga[0] = (f_x[i] - 2 * f_x[i + 1] + f_x[i + 2]) / (Math.Pow(h, 2));
            druga[1] = (f_x[i - 2] - 2 * f_x[i - 1] + f_x[i]) / (Math.Pow(h, 2));
            druga[2] = (f_x[i - 1] - 2 * f_x[i] + f_x[i + 1]) / (Math.Pow(h, 2));
            druga[3] = (-f_x[i-2] + 16 * f_x[i-1] - 30 * f_x[i] + 16 * f_x[i+1] - f_x[i+2]) / (12 * Math.Pow(h, 2));

            for (int j = 0; j< pierwsz.Length; j++)
            {
                labelTest.Text += "\n" + pierwsz[j];
            }

            for (int j = 0; j < druga.Length; j++)
            {
                label3.Text += "\n" + druga[j];
            }
        }
    }
}

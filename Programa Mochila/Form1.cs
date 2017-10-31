using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Programa_Mochila
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int a, cont = 0;
        double z, l;
        double[,] valores = new double [50, 3];
        string[] nomes = new string[50];
        int[] qroub = new int[50];
        
        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader SR = new StreamReader(@"C:\Users\Mateus\Desktop\Itens da Casa.txt");
            
            while (SR.EndOfStream == false)
            {
                string[] temp = SR.ReadLine().Split(';');
                nomes[cont] = temp[0];
                valores[cont, 0] = Convert.ToDouble(temp[1]);
                valores[cont, 1] = Convert.ToDouble(temp[2]);
                valores[cont, 2] = Convert.ToDouble(temp[3]);
                comboBox1.Items.Add(temp[0]);
                qroub[cont] = 0;
                cont++;
                

            }

            for (int i = 0; i < cont; i++)
            {
                listBox1.Items.Add("Nome  " + nomes[i] + "  Peso  " + valores[i, 0] + "  Quantidade  " + valores[i, 1] + "  Valor  " + valores[i, 2] );
            }



        }


        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Console.Beep();
            Console.Beep();
            Console.Beep();

        }

        private double lucro(double[,] valores, int[] qroub, int a)
        {
            z = 0;
            l = 0;
            for (int i = 0; i < cont; i++)
            {
                z = z + (valores[i, 0] * qroub[i]);
                l = l + (valores[i, 2] * qroub[i]);
            }

            if (z > a)
                return 0;
            else
                return l;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            a = Convert.ToInt32(textBox2.Text);

            l = lucro(valores, qroub, a);
            textBox1.Text = Convert.ToString(l);
            if (z == 0)
            {
                MessageBox.Show("Mochila Arrebentou, Meliante Rodou", "IHHH DEU RUIM",
                                 MessageBoxButtons.OK,
                                 MessageBoxIcon.Exclamation);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            qroub[comboBox1.SelectedIndex] = Convert.ToInt32(numericUpDown1.Value);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            numericUpDown1.Maximum = Convert.ToInt32(valores[comboBox1.SelectedIndex, 1]);
            numericUpDown1.Value = qroub[comboBox1.SelectedIndex];
          
            
            

            

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

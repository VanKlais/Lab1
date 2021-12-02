using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label2.Text = "";
            label3.Text = "";
            int size = Convert.ToInt32(textBox1.Text);
            char[] alphabet = new char[size];
            double[] countLet = new double[size];
            string[] codeCom = new string[size];
            dataGridView1.RowCount = size;
            Random rnd = new Random();

            char sup;
            int t = -1;
            while (true)
            {
                if (t == size - 1)
                {
                    break;
                }
                sup = Convert.ToChar(rnd.Next(95, 127));
                if (!alphabet.Contains(sup))
                {
                    t++;
                    alphabet[t] = sup;
                    label2.Text += $"{t + 1})\t" + alphabet[t] + Environment.NewLine;
                }
            }

            double rndUser = Convert.ToInt32(textBox2.Text);

            double prop = 100.0 / rndUser;
            for (double con = 100.0 / size; con < 100 + prop; con += prop)
            {

                countLet[rnd.Next(0, size)] += Math.Round(prop, 2);
            }

            for (int i = 0; i < size; i++)
            {
                label3.Text += $"{i + 1})\t" + countLet[i] + Environment.NewLine;
            }

            double sucountLet;
            char sup2;
            for (int i = 0; i < size - 1; i++)
            {
                for (int j = i + 1; j < size; j++)
                {
                    if (countLet[i] < countLet[j])
                    {
                        sucountLet = countLet[i];
                        countLet[i] = countLet[j];
                        countLet[j] = sucountLet;

                        sup2 = alphabet[i];
                        alphabet[i] = alphabet[j];
                        alphabet[j] = sup2;
                    }
                }
            }
            int length=0;
            for (int i = 0; i < size-1; i++)
            {
                if (countLet[i] > 0)
                    length++;
                else break;
            }
                Fano(0, size - 1);
            
            for (int j = 0; j < size; j++)
            {
                dataGridView1.Rows[j].Cells[0].Value = alphabet[j];
                dataGridView1.Rows[j].Cells[1].Value = countLet[j];
                dataGridView1.Rows[j].Cells[2].Value = codeCom[j];
            }

            void Fano(int L, int R)
            {
                int n = L;
                double sum = 0;
                if (L < R)
                {
                    for (int j = L; j < R + 1; j++)
                    {
                        sum += countLet[j];
                    }
                    double mid = sum / 2;

                    for (int i = L; i <= R; i++)
                    {
                        if ((countLet[i] == 0)) break;
                        if (R - L == 1)
                        {
                            n++;
                            codeCom[L] += "0";
                            codeCom[R] += "1";
                            break;
                        }
                        else if (countLet[i] <= mid)
                        {
                            n++;
                            mid -= countLet[i];
                            codeCom[i] += "0";
                        }
                        else
                        {
                            mid = 0;
                            codeCom[i] += "1";
                        }
                    }
                    Fano1(L, n - 1);
                    Fano(n, R);
                }
            }
            void Fano1(int L, int R)
            {
                int n = L;
                double sum = 0;
                if (L < R)
                {
                    for (int j = L; j < R + 1; j++)
                    {
                        sum += countLet[j];
                    }
                    double mid = sum / 2;

                    for (int i = L; i <= R; i++)
                    {
                        if ((countLet[i] == 0)) break;
                        if (R - L == 1)
                        {
                            n++;
                            codeCom[L] += "0";
                            codeCom[R] += "1";
                            break;
                        }
                        else if (countLet[i] <= mid)
                        {
                            n++;
                            mid -= countLet[i];
                            codeCom[i] += "0";
                        }
                        else
                        {
                            mid = 0;
                            codeCom[i] += "1";
                        }
                    }
                    Fano(L, n - 1);
                    Fano1(n, R);
                }
            }
        }
    }
}

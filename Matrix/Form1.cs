using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Matrix
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        const int SIZE = 3;
        int[,,] Matrix = new int[100, SIZE, SIZE];
        int count = 0;
        //int[,] Total = new int[SIZE, SIZE];

        private void btn_add_Click(object sender, EventArgs e)
        {
            int n = 0;
            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    string val = (tlp_2.Controls[n] as TextBox).Text;

                    int.TryParse(val, out Matrix[count, i, j]);
                    // Matrix[count, i, j] = int.Parse(val);
                    (tlp_2.Controls[n] as TextBox).Text = "";
                    n++;
                }
            }
            count++;
            txt_1.Focus();
        }

        private void btn_cal_Click(object sender, EventArgs e)
        {
            btn_add_Click(null, null);
            int[,] temp;
            int p = 0;
            for (int n = 1; n < count; n++)
            {
                temp = Multiply(0, n);

                for (int i = 0; i < SIZE; i++)
                {
                    for (int j = 0; j < SIZE; j++)
                    {
                        Matrix[0, i, j] = temp[i, j];                        
                    }
                }
            }
            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {                   
                    (tlp_2.Controls[p++] as TextBox).Text = Matrix[0,i,j].ToString() ;
                 
                }
            }
        }
        private int[,] Multiply(int a, int b)
        {
            int[,] temp = new int[SIZE, SIZE];
            
            for (int k = 0; k < SIZE; k++)
            {
                for (int i = 0; i < SIZE; i++)
                {
                    for (int j = 0; j < SIZE; j++)
                    {
                        temp[k, i] += Matrix[a, k, j] * Matrix[b, j, i];
                    }
                }
            } 
            return temp;
        } 
 
        private void btn_clear_Click(object sender, EventArgs e)
        {
            int p = 0;
            Array.Clear(Matrix, 0, Matrix.Length);
            for (int i = 0; i < SIZE; i++)
            {
                for (int j = 0; j < SIZE; j++)
                {
                    (tlp_2.Controls[p++] as TextBox).Text = "";

                }
            }
        }
    }
}

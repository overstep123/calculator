using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace calculator
{
    public partial class Form1 : Form
    {
        private double first;
        private double second;
        private char op;
        private int resultpresent;
        private double result;
        private int oppresent;
        
        public Form1()
        {
            InitializeComponent();
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            first = 0;
            second = 0;
            result = 0;
            resultpresent = 0;
            oppresent = 0;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {
            cleardata();
        }
        private void cleardata()
        {
            first = second = 0;
            op = '0';
            textBox1.Clear();
            textBox2.Clear();
            resultpresent = 0;
            result = 0;
            oppresent = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textch(1);
        }

        private void textch(int a)
        {
            if (resultpresent == 1)
                cleardata();
            textBox1.Text += a.ToString();
        }
        private void number1(int a)
        {
              
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textch(7);
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textch(8);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textch(9);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textch(6);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textch(5);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textch(4);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textch(3);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textch(2);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if(textBox1.Text.Length!=0)
            {
                textch(0);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < textBox1.Text.Length; i++)
                if (textBox1.Text[i] == '.') return;
            if (resultpresent == 0 && textBox1.Text.Length > 0)
                textBox1.Text += ".";
            else
            {
                cleardata();
                textBox1.Text = "0.";
            }
        }

        private bool opchange(char c)
        {
            int i = textBox2.Text.Length;
            if (resultpresent == 1) return false;
            if (i > 0)
            {
                char a = textBox2.Text[i - 1];
                if (a == '+' || a == '-' || a == '*' || a == '/')
                {
                    op = c;
                    textBox2.Text = first + c.ToString();
                    return true;
                }
                else return false;
            }
            else return false;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (opchange('/')) return;
            if (oppresent!=0)
                calculate();
            textBox2.Text = textBox1.Text + "/";
            op = '/';
            first = Convert.ToDouble(textBox1.Text);
            textBox1.Clear();
            oppresent = 1;
            if (resultpresent == 1)
                resultpresent = 0;

        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (opchange('*')) return;
            if (oppresent!=0)
                calculate();
            textBox2.Text = textBox1.Text + "*";
            op = '*';
            first = Convert.ToDouble(textBox1.Text);
            textBox1.Clear();
            if (resultpresent == 1)
                resultpresent = 0;
            oppresent = 1;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (opchange('-')) return;
            if (oppresent!=0)
                calculate();
            textBox2.Text = textBox1.Text + "-";
            op = '-';
            first = Convert.ToDouble(textBox1.Text);
            textBox1.Clear();
            if (resultpresent == 1)
                resultpresent = 0;
            oppresent = 1;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (opchange('+')) return;
            if (oppresent!=0)
                calculate();
            textBox2.Text = textBox1.Text + "+";
            op = '+';
            first = Convert.ToDouble(textBox1.Text);
            textBox1.Clear();
            if (resultpresent == 1)
                resultpresent = 0;
            oppresent = 1;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            calculate();
            oppresent = 0;
        }
        private void calculate()
        {
            if (textBox1.Text.Length == 0 || op == '0') MessageBox.Show("input incomplete");
            else
            {
                if (resultpresent == 0)
                    second = Convert.ToDouble(textBox1.Text);
                if (op == '/' && second == 0)
                    MessageBox.Show("error");
                else
                {
                    switch (op)
                    {
                        case '+':
                            result = first + second;
                            break;
                        case '-':
                            result = first - second;
                            break;
                        case '*':
                            result = first * second;
                            break;
                        case '/':
                            result = first / second;
                            break;
                    }
                    textBox1.Text = result.ToString();
                    resultpresent = 1;
                    first = result;
                }
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length > 0)
            {
                double a = Convert.ToDouble(textBox1.Text);
                textBox1.Text = (a * first / 100).ToString();
                if (textBox1.Text == "0")
                    resultpresent = 1;
            }
            else MessageBox.Show("input incomplete");
        }
    }
}

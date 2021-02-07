using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Numerics;

namespace Elipticheskaya_kriptographia
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private BigInteger keri_element(BigInteger qqq, BigInteger ppp)
        {
            BigInteger x, y = 0;
            for (x = 1; x < ppp; x++)
            {
                if ((x * qqq) % ppp == 1)
                {
                    y = x;
                }
            }
            return y;
        }

        private bool tekseru()
        {
            bool tekseriu = true;
            if (textBox1.Text.Equals("") || textBox2.Text.Equals("") || textBox3.Text.Equals(""))
            {
                tekseriu = false;
            }
            return tekseriu;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (tekseru())
            {
                textBox4.Text = Convert.ToString((BigInteger.Parse(textBox1.Text) + BigInteger.Parse(textBox2.Text)) % BigInteger.Parse(textBox3.Text));
            }
            else MessageBox.Show("Кейбір ұяшықтар толтырылмаған");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (tekseru())
            {
                textBox4.Text = Convert.ToString((BigInteger.Parse(textBox1.Text) - BigInteger.Parse(textBox2.Text)) % BigInteger.Parse(textBox3.Text));        
            }
            else MessageBox.Show("Кейбір ұяшықтар толтырылмаған");
        }            

        private void button3_Click(object sender, EventArgs e)
        {
            if (tekseru())
            {
                textBox4.Text = Convert.ToString((BigInteger.Parse(textBox1.Text) * BigInteger.Parse(textBox2.Text)) % BigInteger.Parse(textBox3.Text));
            }
            else MessageBox.Show("Кейбір ұяшықтар толтырылмаған");        
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (tekseru())
            {
                textBox4.Text = Convert.ToString(BigInteger.ModPow(BigInteger.Parse(textBox1.Text), BigInteger.Parse(textBox2.Text), BigInteger.Parse(textBox3.Text)));
            }
            else MessageBox.Show("Кейбір ұяшықтар толтырылмаған");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("") || textBox3.Text.Equals(""))
            {
                MessageBox.Show("Кейбір ұяшықтар толтырылмаған");
            }
            else
            textBox4.Text = Convert.ToString(BigInteger.Parse(textBox1.Text) % BigInteger.Parse(textBox3.Text));
        }
        private void button6_Click(object sender, EventArgs e)
        {
            textBox4.Text = keri_element_tcepnoi(BigInteger.Parse(textBox3.Text),BigInteger.Parse(textBox1.Text)).ToString();
        }

        public BigInteger keri_element_tcepnoi(BigInteger phi, BigInteger d)
        {
            BigInteger e_ = 1;
            BigInteger q = 1, kaldik = 1, pi = 1, pi_1 = 1, pi_2 = 0;
            BigInteger phi_buffer = phi;
            BigInteger d_buffer = d;
            while (kaldik != 0)
            {
                q = phi_buffer / d_buffer;
                kaldik = phi_buffer % d_buffer;
                pi = pi_1 * q + pi_2;
                phi_buffer = d_buffer;
                d_buffer = kaldik;
                pi_2 = pi_1;
                pi_1 = pi;

            } //MessageBox.Show("ең соңы: phi = " + phi.ToString() + " d = " + d.ToString() + " pi_2 = " + pi_2.ToString() + " pi1" + pi_1.ToString());
            if ((pi_2 * d) % phi == 1)
            {
                e_ = pi_2;
            }
            else
            {
                e_ = phi - pi_2;
            }
            return e_;
        }

    }
}

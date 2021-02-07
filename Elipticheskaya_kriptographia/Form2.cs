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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            if (!textBox1_tb1.Text.Equals("") && !textBox2_tb1.Text.Equals("") && !textBox3_tb1.Text.Equals(""))
            {
                button3_tb1.Enabled = true;
                P__ = BigInteger.Parse(textBox1_tb1.Text);
                a__ = BigInteger.Parse(textBox2_tb1.Text);
                b__ = BigInteger.Parse(textBox3_tb1.Text);
            }
            else button3_tb1.Enabled = false;
        }
        BigInteger P__ ;
        BigInteger a__ ;
        BigInteger b__ ;
        public void jikteu(BigInteger n)
        {
            
        }

        private bool pc(BigInteger x)
        {
            bool q = false;
            if (BigInteger.ModPow(5, x - 1, x) == 1)
            {
                q = true;
            }
            return q;
        }
                
        BigInteger x, y, y1, y2, z, chislo_tochek = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (pc(BigInteger.Parse(textBox1_tb1.Text)))
                {
                    for (x = 0; x < BigInteger.Parse(textBox1_tb1.Text) + 1; x++)
                    {
                        listBox1.Items.Add("x = " + x.ToString() + " => y^2 = " + (BigInteger.Pow(x, 3) + BigInteger.Parse(textBox3.Text) * x + BigInteger.Parse(textBox1.Text)) % BigInteger.Parse(textBox2.Text)).ToString();
                        for (y = 1; y < BigInteger.Parse(textBox1_tb1.Text); y++)
                        {
                            if ((y * y) % BigInteger.Parse(textBox1_tb1.Text) == (BigInteger.Pow(x, 3) + BigInteger.Parse(textBox2_tb1.Text) * x + BigInteger.Parse(textBox3_tb1.Text)) % BigInteger.Parse(textBox1_tb1.Text))
                            {
                                chislo_tochek += 1;
                                y1 = y;
                                //listBox2.Items.Add("y1 = " + y1.ToString() + " при x = " + x.ToString());
                                listBox4_tb1.Items.Add(chislo_tochek + ")  (" + x.ToString() + " , " + y1.ToString() + ")");
                                break;
                            }
                        }
                       /* if (chislo_tochek != 0)
                        {
                            break;
                        }*/
                        for (z = y1 + 1; z < BigInteger.Parse(textBox1_tb1.Text); z++)
                        {
                            if ((z * z) % BigInteger.Parse(textBox1_tb1.Text) == (BigInteger.Pow(x, 3) + BigInteger.Parse(textBox2_tb1.Text) * x + BigInteger.Parse(textBox3_tb1.Text)) % BigInteger.Parse(textBox1_tb1.Text))
                            {
                                chislo_tochek += 1;
                                y2 = z;
                                listBox4_tb1.Items.Add(chislo_tochek + ")  (" + x.ToString() + " , " + y2.ToString() + ")");
                                break;
                            }
                        }
                        
                    }
                }
                else
                {
                    MessageBox.Show("P - жай сан болуы қажет!!!");
                }
            }
            catch
            {
                MessageBox.Show("Что-то не так!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (!pc(BigInteger.Parse(textBox1_tb1.Text)))
            {
                this.textBox1_tb1.ForeColor = System.Drawing.Color.Red;
            }
            else this.textBox1_tb1.ForeColor = System.Drawing.Color.Black;
            tekseru();
            P__ = BigInteger.Parse(textBox1_tb1.Text); 
        }
        private void tekseru()
        {
            bool b1, b2 = false;
            if (tekseru2())
            {
                if (pc(BigInteger.Parse(textBox1_tb1.Text)))
                {
                    richTextBox1_tb1.Text = "Шарт бойынша тексеру: P = жай сан \n  Шарт орындалды\n";
                    if (BigInteger.Parse(textBox2_tb1.Text) % BigInteger.Parse(textBox1_tb1.Text) != 0)
                    {
                        b1 = true;
                        richTextBox1_tb1.Text += "Шарт бойынша тексеру: a mod P <> 0\n  Шарт орындалды:\n  ";
                        richTextBox1_tb1.Text += textBox2_tb1.Text + " mod " + textBox1_tb1.Text + " = " + (BigInteger.Parse(textBox2_tb1.Text) % BigInteger.Parse(textBox1_tb1.Text)).ToString() + "\n";
                    }
                    else
                    {
                        b1 = false;
                        richTextBox1_tb1.Text += "Шарт бойынша тексеру: a mod P <> 0\n  Шарт орындалмады\n";
                        button3_tb1.Enabled = false;
                        button1_tb1.Enabled = false;
                    }
                    //---------------------------------------------------------------------------------
                    if (BigInteger.Parse(textBox3_tb1.Text) % BigInteger.Parse(textBox1_tb1.Text) != 0)
                    {
                        b2 = true;
                        richTextBox1_tb1.Text += "Шарт бойынша тексеру: b mod P <> 0\n  Шарт орындалды:\n  ";
                        richTextBox1_tb1.Text += textBox3_tb1.Text + " mod " + textBox1_tb1.Text + " = " + (BigInteger.Parse(textBox3_tb1.Text) % BigInteger.Parse(textBox1_tb1.Text)).ToString() + "\n";
                    }
                    else
                    {
                        b2 = false;
                        richTextBox1_tb1.Text += "Шарт бойынша тексеру: b mod P <> 0\n  Шарт орындалмады\n";
                        button3_tb1.Enabled = false;
                        button1_tb1.Enabled = false;
                    }

                    if (b1 && b2)
                    {
                        BigInteger d_tekseru = (4 * BigInteger.Pow(BigInteger.Parse(textBox2_tb1.Text), 3) + 27 * BigInteger.Pow(BigInteger.Parse(textBox3_tb1.Text), 2)) % BigInteger.Parse(textBox1_tb1.Text);
                        richTextBox1_tb1.Text += "Шарт бойынша тексеру: 4*a^3 + 27*b^2 <> 0 (mod p)\n";
                        richTextBox1_tb1.Text += "  " + "4 * " + textBox2_tb1.Text + " ^ 3 + 27 * " + textBox3_tb1.Text + " ^ 2 = " + d_tekseru + " (mod " + textBox1_tb1.Text + ")\n  ";
                        if (d_tekseru != 0)
                        {
                            richTextBox1_tb1.Text += "Шарт орындалды!";
                            button3_tb1.Enabled = true;
                            button1_tb1.Enabled = true;
                        }
                        else
                        {
                            richTextBox1_tb1.Text += "Шарт орындалмады!";
                            button3_tb1.Enabled = false;
                            button1_tb1.Enabled = false;
                        }
                    }
                    if (!textBox6_tb1.Text.Equals(""))
                    {
                        richTextBox1_tb1.Text += "\nШарт бойынша тексеру: q = жай сан\n  ";
                        if (pc(BigInteger.Parse(textBox6_tb1.Text)))
                        {
                            richTextBox1_tb1.Text += "Шарт орындалды!";
                        }
                        else
                        {
                            richTextBox1_tb1.Text += "Шарт орындалмады!";
                        }


                        richTextBox1_tb1.Text += "\nШарт бойынша тексеру: q <> p\n  ";
                        if (!textBox6_tb1.Text.Equals(textBox1_tb1.Text))
                        {
                            richTextBox1_tb1.Text += "Шарт орындалды!";                            
                        }
                        else
                        {
                            richTextBox1_tb1.Text += "Шарт орындалмады!";
                        }
                    }
                    
                }
                else
                {
                    richTextBox1_tb1.Text = "Шарт бойынша тексеру: P = жай сан \n  Шарт орындалмады\n";
                    button3_tb1.Enabled = false;
                    button1_tb1.Enabled = false;
                }
            }
            if (!tekseru2())
            {
                richTextBox1_tb1.Text = "";
                button3_tb1.Enabled = false;
                button1_tb1.Enabled = false;
            }
        }
        private bool tekseru2()
        {
            bool ainymali = false;
            if (!textBox3_tb1.Text.Equals("") && !textBox1_tb1.Text.Equals("") && !textBox2_tb1.Text.Equals(""))
            {
                ainymali = true;
            }
            return ainymali;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (BigInteger.Parse(textBox1_tb1.Text) == BigInteger.Parse(textBox2_tb1.Text))
            {
                this.textBox2_tb1.ForeColor = System.Drawing.Color.Red;
            }
            else this.textBox2_tb1.ForeColor = System.Drawing.Color.Black;
            tekseru();
            a__ = BigInteger.Parse(textBox2_tb1.Text);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (BigInteger.Parse(textBox1_tb1.Text) == BigInteger.Parse(textBox3_tb1.Text))
            {
                this.textBox3_tb1.ForeColor = System.Drawing.Color.Red;
            }
            else this.textBox3_tb1.ForeColor = System.Drawing.Color.Black;
            tekseru();
            b__ = BigInteger.Parse(textBox3_tb1.Text);
        }
        private void kezdeisok()
        {
tcikl:      Random random = new Random();
            int k_x, k_y;
            BigInteger xx, yy, yy1, kkk = 0;
            k_x = random.Next(0, Int32.Parse(textBox1_tb1.Text));
            k_y = random.Next(1, Int32.Parse(textBox1_tb1.Text));
            xx = BigInteger.Parse(k_x.ToString());
            yy = BigInteger.Parse(k_y.ToString());
            for (; xx < BigInteger.Parse(textBox1_tb1.Text) + 1; xx++)
            {
                for (; yy < BigInteger.Parse(textBox1_tb1.Text); yy++)
                {
                    if (nukte(xx,yy))
                    {
                        yy1 = yy;
                        textBox4_tb1.Text = xx.ToString();
                        textBox5_tb1.Text = yy1.ToString();
                        kkk++; 
                        break;
                    }
                }
                if (kkk != 0)
                {
                    break;
                }
            }
        }
        private bool nukte(BigInteger x__, BigInteger y__)
        {
            bool nukte_ = false;
            if ((y__ * y__) % BigInteger.Parse(textBox1_tb1.Text) == (BigInteger.Pow(x__, 3) + BigInteger.Parse(textBox2_tb1.Text) * x__ + BigInteger.Parse(textBox3_tb1.Text)) % BigInteger.Parse(textBox1_tb1.Text))
            {
                nukte_ = true;
            }
            return nukte_;
        }
        private void button3_Click_1(object sender, EventArgs e)
        {
            textBox4_tb1.Text = "";
            textBox5_tb1.Text = "";
            kezdeisok();
            while (textBox5_tb1.Text.Equals(""))
            {
                kezdeisok();
            }
            textBox3.Text = textBox4_tb1.Text;
            textBox4.Text = textBox5_tb1.Text;
            listBox5.Items.Clear(); kk = 3;
            nukteni_kisykka_tekseru = false;
        }
        
        private void button4_Click_1(object sender, EventArgs e)
        {
            
        }
        private void button4_Click(object sender, EventArgs e)
        {
            ayirma = false;
            eki_eseleu();
            for (int i = 1; i < BigInteger.Parse(textBox1_tb1.Text) * 2; i++)
            {
                compute_but();
                if (ayirma)
                {
                    textBox6_tb1.Text = (i + 2).ToString();
                    break;
                }
            }
            tekseru();
           /* richTextBox1_tb1.Text += "\nШарт бойынша тексеру: q - жай сан\n  ";
            if ()
            {

            }*/
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            eki_eseleu(); kk = 3;
            for (int i = 1; i < numericUpDown1.Value - 1; i++)
            {
                compute_but();
            }
        }
        BigInteger z1, z2, x3, y3, astingi_Y, ustingi_bolik, astingi_bolik, P;
        private void eki_eseleu()
        {
            Form1 f1 = this.Owner as Form1;
            P = BigInteger.Parse(textBox1_tb1.Text);

            z1 = BigInteger.Parse(textBox3.Text);
            z2 = BigInteger.Parse(textBox4.Text);
            ustingi_bolik = (3 * z1 * z1 + BigInteger.Parse(textBox2_tb1.Text)) % P;
            astingi_bolik = keri_element_tcepnoi(P,(2 * z2));
            x3 = (BigInteger.Pow(ustingi_bolik * astingi_bolik, 2) - 2 * z1) % P;

            while (x3 < 0)
            {
                x3 += P;
            }
            y3 = (ustingi_bolik * astingi_bolik * (z1 - x3) - z2) % P;
            if (y3 % P < 0)
            {
                y3 = (y3 % P);
                while (y3 < 0)
                {
                    y3 += P;
                }
            }
            listBox5.Items.Add("G1 = ( " + z1.ToString() + " , " + z2.ToString() + " ) ");
            listBox5.Items.Add("G2 = ( " + x3.ToString() + " , " + (y3).ToString() + " ) ");
            textBox5.Text = textBox3.Text;
            textBox6.Text = textBox4.Text;
            textBox7.Text = x3.ToString();
            textBox8.Text = y3.ToString();
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
        BigInteger kk = 3; 
        bool nukteni_kisykka_tekseru = false;
        bool ayirma = false;
        public void compute_but()
        {
            BigInteger xx1, yy1, xx2, yy2, xx3, yy3, bol_usti, bol_asti, airma;
            xx1 = BigInteger.Parse(textBox5.Text);
            yy1 = BigInteger.Parse(textBox6.Text);
            xx2 = BigInteger.Parse(textBox7.Text);
            yy2 = BigInteger.Parse(textBox8.Text);

            bol_usti = yy2 - yy1;

            while (bol_usti < 0)
            {
                bol_usti += P;
            }

            airma = xx2 - xx1;
            while (airma < 0)
            {
                airma += P;
            }
            if (airma == 0)
            {
                ayirma = true;
            }
            bol_asti = keri_element_tcepnoi(P,airma);
            xx3 = (BigInteger.Pow((bol_usti * bol_asti), 2) % P - xx1 - xx2) % P;
            while (xx3 < 0)
            {
                xx3 += P;
            }
            yy3 = ((bol_usti * bol_asti) * (xx1 - xx3) - yy1) % P;
            while (yy3 < 0)
            {
                yy3 += P;
            }
            if (!nukte(xx3,yy3))
            {
                nukteni_kisykka_tekseru = true;
            }
            listBox5.Items.Add("G" + kk.ToString() + " = ( " + xx3.ToString() + " , " + yy3.ToString() + " )");
            textBox7.Text = xx3.ToString();
            textBox8.Text = yy3.ToString();
            kk++;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            listBox5.Items.Clear();
        }

        private void textBox4_tb1_TextChanged(object sender, EventArgs e)
        {
            textBox3.Text = textBox4_tb1.Text; textBox10.Text = textBox4_tb1.Text;
            tekseru();
            if (!textBox4_tb1.Text.Equals("") && !textBox5_tb1.Text.Equals(""))
            {
                bool Nnukte;
                Nnukte = nukte(BigInteger.Parse(textBox4_tb1.Text), BigInteger.Parse(textBox5_tb1.Text));
                if (Nnukte)
                {
                    richTextBox1_tb1.Text += "\n ( " + textBox4_tb1.Text + "," + textBox5_tb1.Text + ") - нүкте ЭҚ-ға тиісті" ;
                }
                else
                    richTextBox1_tb1.Text += "\n ( " + textBox4_tb1.Text + "," + textBox5_tb1.Text + ") - нүкте ЭҚ-ға тиісті емес!";
            }
            
        }

        private void textBox5_tb1_TextChanged(object sender, EventArgs e)
        {
            textBox4.Text = textBox5_tb1.Text; textBox11.Text = textBox5_tb1.Text;
            tekseru();
            if (!textBox4_tb1.Text.Equals("") && !textBox5_tb1.Text.Equals(""))
            {
                bool Nnukte;
                Nnukte = nukte(BigInteger.Parse(textBox4_tb1.Text), BigInteger.Parse(textBox5_tb1.Text));
                if (Nnukte)
                {
                    richTextBox1_tb1.Text += "\n ( " + textBox4_tb1.Text + "," + textBox5_tb1.Text + ") - нүкте ЭҚ-ға тиісті";
                }
                else
                    richTextBox1_tb1.Text += "\n ( " + textBox4_tb1.Text + "," + textBox5_tb1.Text + ") - нүкте ЭҚ-ға тиісті емес!";
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void калькуляторToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form5 _Form5 = new Form5();
            _Form5.Visible = true;
        }

        private void эльГамальШифріToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6();
            f6.Owner = this;
            f6.Visible = true;
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            BigInteger kor_x1 = BigInteger.Parse(txt_x1.Text);
            BigInteger kor_y1 = BigInteger.Parse(txt_y1.Text);
            BigInteger kor_x2 = BigInteger.Parse(txt_x2.Text);
            BigInteger kor_y2 = BigInteger.Parse(txt_y2.Text);
            BigInteger jai_p = BigInteger.Parse(textBox1_tb1.Text);
            BigInteger koef_a = BigInteger.Parse(textBox2_tb1.Text);
            BigInteger koef_b = BigInteger.Parse(textBox3_tb1.Text);
            El_tochka eki_nukte = new El_tochka(kor_x1,kor_y1,jai_p,koef_a,koef_b,kor_x2,kor_y2,0);
            listBox4.Items.Add("(" + txt_x1.Text + "," + txt_y1.Text + ")+(" + txt_x2.Text + "," + txt_y2.Text + ") = " + eki_nukte.compute_but());
        }

        private void listBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            string strlist = "";
            strlist = listBox5.Text; MessageBox.Show(strlist);
            if (radioButton1.Checked)
            {
                strlist = strlist.Remove(0 , strlist.IndexOf("(") + 1);
                txt_x1.Text = strlist.Substring(0 , strlist.IndexOf(","));
                strlist = strlist.Remove(0, strlist.IndexOf(",") + 1);
                txt_y1.Text = strlist.Substring(0, strlist.IndexOf(")"));
            }
            if (radioButton2.Checked)
            {
                strlist = strlist.Remove(0, strlist.IndexOf("(") + 1);
                txt_x2.Text = strlist.Substring(0, strlist.IndexOf(","));
                strlist = strlist.Remove(0, strlist.IndexOf(",") + 1);
                txt_y2.Text = strlist.Substring(0, strlist.IndexOf(")"));
            }
        }

        private void button4_Click_2(object sender, EventArgs e)
        {
            listBox4.Items.Clear();
        }

        private void бағдарламаЖайлыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 _Form3 = new Form3();
            _Form3.Visible = true;
        }
        public BigInteger keri_element_tcepnoi(BigInteger phi, BigInteger d)
        {
            if (d == 0)
            {
                d = 1;
            }
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
            } 
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

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {
            textBox1.Text = textBox3.Text;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            textBox2.Text = textBox4.Text;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            k = 1;
        }
        BigInteger k = 1;
        private void button6_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {           
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show(listBox2.Text);
        }

        private void listBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show(listBox4.Text);
        }

        private void G1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("G = " + "(" + txt_x1.Text + " , " + txt_y1.Text + ")");
        }

        private void G2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("G = " + "(" + txt_x2.Text + " , " + txt_y2.Text + ")");
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            for (BigInteger i = 0; i < BigInteger.Parse(textBox9.Text); i++)
            {
                if (k == 1)
                {
                    listBox2.Items.Add("G1 = " + textBox1.Text + " , " + textBox2.Text + ")");
                }
                string strlist = ""; k *= 2;
                El_tochka ekiEseleu = new El_tochka(BigInteger.Parse(textBox1.Text), BigInteger.Parse(textBox2.Text), P__, a__, b__, 0, 0, 0);
                strlist = ekiEseleu.eki_eseleu();
                listBox2.Items.Add("G" + k.ToString() + " = " + strlist);

                strlist = strlist.Remove(0, strlist.IndexOf("(") + 1);
                textBox1.Text = strlist.Substring(0, strlist.IndexOf(","));
                strlist = strlist.Remove(0, strlist.IndexOf(",") + 1);
                textBox2.Text = strlist.Substring(0, strlist.IndexOf(")"));
            }
        }

        
        private void button9_Click(object sender, EventArgs e)
        {
        }
        BigInteger _k_ = 1;
        BigInteger kN = 0;
        BigInteger summaX = 0;
        BigInteger summaY = 0;
        BigInteger kazirgiX = 0;
        BigInteger kazirgiY = 0;
        BigInteger summa = 0;
        BigInteger gigasan;
        string jauap = "";
        private void button10_Click(object sender, EventArgs e)
        {
            fun_kadam1();
        }

        private void fun_kadam1()
        {
            if (textBox13.Text.Equals("1"))
            {
                El_tochka jauap = new El_tochka(kazirgiX, kazirgiY, P__, a__, b__, BigInteger.Parse(textBox1.Text), BigInteger.Parse(textBox2.Text), 0);
                MessageBox.Show(jauap.compute_but());
            }
            if (textBox13.Text.Equals("0"))
            {
                //El_tochka jauap = new El_tochka(kazirgiX, kazirgiY, P__, a__, b__, BigInteger.Parse(textBox1.Text), BigInteger.Parse(textBox2.Text), 0);
                MessageBox.Show(kazirgiX.ToString() + " " + kazirgiY.ToString());
            }
            k *= 2; kN++;
            gigasan = BigInteger.Parse(textBox13.Text);
            if (gigasan != 1)
            {
                if (k > gigasan / 2)
                {
                    summa += k;
                    textBox9.Text = kN.ToString();
                    textBox13.Text = (gigasan - k).ToString();
                    k = 1;
                    textBox12.Text = summa.ToString();
                    fun_kadam2();
                }
            }
        }

        private void fun_kadam2()
        {
            if (!basilu)
            {
                BigInteger bastapkiX = BigInteger.Parse(textBox1.Text);
                BigInteger bastapkiY = BigInteger.Parse(textBox2.Text);
                for (BigInteger i = 0; i < BigInteger.Parse(textBox9.Text); i++)
                {
                    if (k == 1)
                    {
                        listBox6.Items.Add("G1 = " + textBox1.Text + " , " + textBox2.Text + ")");
                    }
                    string strlist = ""; k *= 2;
                    El_tochka ekiEseleu = new El_tochka(BigInteger.Parse(textBox1.Text), BigInteger.Parse(textBox2.Text), P__, a__, b__, 0, 0, 0);
                    strlist = ekiEseleu.eki_eseleu();
                    listBox6.Items.Add("G" + k.ToString() + " = " + strlist);

                    strlist = strlist.Remove(0, strlist.IndexOf("(") + 1);
                    textBox1.Text = strlist.Substring(0, strlist.IndexOf(","));
                    kazirgiX = BigInteger.Parse(textBox1.Text);

                    strlist = strlist.Remove(0, strlist.IndexOf(",") + 1);
                    textBox2.Text = strlist.Substring(0, strlist.IndexOf(")"));
                    kazirgiY = BigInteger.Parse(textBox2.Text);
                }
                k = 1;
                textBox1.Text = bastapkiX.ToString();
                textBox2.Text = bastapkiY.ToString();
                basilu = true;
            }
            else
            {
                BigInteger bastapkiX = BigInteger.Parse(textBox1.Text);
                BigInteger bastapkiY = BigInteger.Parse(textBox2.Text);
                for (BigInteger i = 0; i < BigInteger.Parse(textBox9.Text); i++)
                {
                    if (k == 1)
                    {
                        listBox6.Items.Add("G1 = " + textBox1.Text + " , " + textBox2.Text + ")");
                    }
                    string strlist = ""; k *= 2;
                    El_tochka ekiEseleu = new El_tochka(BigInteger.Parse(textBox1.Text), BigInteger.Parse(textBox2.Text), P__, a__, b__, 0, 0, 0);
                    strlist = ekiEseleu.eki_eseleu();
                    listBox6.Items.Add("G" + k.ToString() + " = " + strlist);

                    strlist = strlist.Remove(0, strlist.IndexOf("(") + 1);
                    textBox1.Text = strlist.Substring(0, strlist.IndexOf(","));
                    summaX = BigInteger.Parse(textBox1.Text);

                    strlist = strlist.Remove(0, strlist.IndexOf(",") + 1);
                    textBox2.Text = strlist.Substring(0, strlist.IndexOf(")"));
                    summaY = BigInteger.Parse(textBox2.Text);
                }
                El_tochka kosu = new El_tochka(kazirgiX, kazirgiY, P__, a__, b__, summaX, summaY, 0);
                strlist2 = kosu.compute_but();

                strlist2 = strlist2.Remove(0, strlist2.IndexOf("(") + 1);
                textBox1.Text = strlist2.Substring(0, strlist2.IndexOf(","));
                kazirgiX = BigInteger.Parse(textBox1.Text);

                strlist2 = strlist2.Remove(0, strlist2.IndexOf(",") + 1);
                textBox2.Text = strlist2.Substring(0, strlist2.IndexOf(")"));
                kazirgiY = BigInteger.Parse(textBox2.Text);
                k = 1;
                textBox1.Text = bastapkiX.ToString();
                textBox2.Text = bastapkiY.ToString();
                basilu = true;
            }
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
            textBox9.Text = kN.ToString();
            kN = 0;
        }
        bool basilu = false;
        string strlist2 = "";
        private void button11_Click(object sender, EventArgs e)
        {
            fun_kadam2();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            MessageBox.Show(kazirgiX.ToString() + " " + kazirgiY.ToString());
            
        }

        private void button12_Click(object sender, EventArgs e)
        {
            while (!textBox13.Text.Equals("1"))
            {
                fun_kadam1();
                if (textBox13.Text.Equals("0"))
                {
                    fun_kadam1();
                    break;
                }

            }
            if (textBox13.Text.Equals("1"))
            {
                fun_kadam1();
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {
        }

        private void button8_Click(object sender, EventArgs e)
        {
            listBox6.Items.Clear();
            _k_ = 1;
            kN = 0;
            summaX = 0;
            summaY = 0;
            kazirgiX = 0;
            kazirgiY = 0;
            summa = 0;
           // gigasan = ;
            jauap = "";
        }

        private void listBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            MessageBox.Show(listBox6.Text);
        }

        private void listBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            MessageBox.Show(listBox2.Text);
        }

        private void электрондыҚолтаңбаToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void файлғаҚолҚоюToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Visible = true;
        }

        private void қолтаңбаныңҚойылымынТексеруToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7();
            form7.Visible = true;
        }        
    }
}

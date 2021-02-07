using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
using System.Numerics;

namespace Elipticheskaya_kriptographia
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            MessageBox.Show("Хэштелетін файлды таңдаңыз!", "Хабарлама", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            openFile();
            hashSha1();
        }
        BigInteger p_ = new BigInteger();
        BigInteger a_ = new BigInteger();
        BigInteger b_ = new BigInteger();
        BigInteger q_ = new BigInteger();
        BigInteger x_ = new BigInteger();
        BigInteger y_ = new BigInteger();
        BigInteger random;
        public BigInteger getRandom(int length)
        {
            Random random = new Random();
            byte[] data = new byte[length];
            random.NextBytes(data);
            return new BigInteger(data);
        }
        private static string mhs(byte[] hashbytes)
        {
            StringBuilder hash = new StringBuilder();
            foreach (byte b in hashbytes)
                hash.Append(b.ToString("D").ToLower());
            return hash.ToString();
        }
        public void hashSha1()
        {
            string filepath = textBox1.Text;
            byte[] bufer;
            int bytesread;
            using (Stream file = File.OpenRead(filepath))
            {
                using (HashAlgorithm hasher = SHA1.Create())
                {
                    do
                    {
                        bufer = new byte[4096];
                        bytesread = file.Read(bufer, 0, bufer.Length);
                        hasher.TransformBlock(bufer, 0, bytesread, null, 0);
                    } while (bytesread != 0);
                    hasher.TransformFinalBlock(bufer, 0, 0);
                    textBox2.Text = mhs(hasher.Hash).ToString();
                    MessageBox.Show("ХЭШ = " + textBox2.Text, "Хэштеу", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }
        private void openFile()
        {
            try
            {
                if (openFileDialog1.ShowDialog() != DialogResult.OK)
                    return;

                string path = openFileDialog1.FileName;
                string s = Path.GetExtension(path);

                textBox1.Text = path;
            }
            catch
            {
                MessageBox.Show("Файл табылмады!", "Қате!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public BigInteger keri_element_tcepnoi(BigInteger phi, BigInteger d)
        {
            BigInteger e_ = 1;
            BigInteger q = 1, kaldik = 1, pi = 1, pi_1 = 1, pi_2 = 0;
            BigInteger phi_buffer = phi;
            BigInteger d_buffer = d;
            try
            {
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
            }
            catch
            {
                MessageBox.Show("Санның нөлге бөліну қауіпі бар!", "Хабарлама", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return e_;
        }
        int curveCount;
        bool choose_curve = false;
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            switch (curveCount)
            {
                case 0:
                    random = getRandom(24);
                    if (random < 0)
                    {
                        random *= (-1);
                    }
                    textBox3.Text = random.ToString();
                    textBox4.Text = (random / 31).ToString();
                    break;
                case 1: textBox3.Text = getRandom(1).ToString();
                    random = getRandom(28);
                    if (random < 0)
                    {
                        random *= (-1);
                    }
                    textBox3.Text = random.ToString();
                    textBox4.Text = (random / 31).ToString();
                    break;
                case 2: textBox3.Text = getRandom(1).ToString();
                    random = getRandom(32);
                    if (random < 0)
                    {
                        random *= (-1);
                    }
                    textBox3.Text = random.ToString();
                    textBox4.Text = (random / 31).ToString();
                    break;
                case 3: textBox3.Text = getRandom(1).ToString();
                    random = getRandom(45);
                    if (random < 0)
                    {
                        random *= (-1);
                    }
                    textBox3.Text = random.ToString();
                    textBox4.Text = (random / 31).ToString();
                    break;
                case 4: textBox3.Text = getRandom(1).ToString();
                    random = getRandom(63);
                    if (random < 0)
                    {
                        random *= (-1);
                    }
                    textBox3.Text = random.ToString();
                    textBox4.Text = (random / 31).ToString();
                    break;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                p_ = BigInteger.Parse("6277101735386680763835789423207666416083908700390324961279");
                a_ = BigInteger.Parse("6277101735386680763835789423207666416083908700390324961276");
                b_ = BigInteger.Parse("2455155546008943817740293915197451784769108058161191238065");
                q_ = BigInteger.Parse("6277101735386680763835789423176059013767194773182842284081");
                x_ = BigInteger.Parse("602046282375688656758213480587526111916698976636884684818");
                y_ = BigInteger.Parse("174050332293622031404857552280219410364023488927386650641");
                curveCount = 0;
            }
            if (comboBox1.SelectedIndex == 1)
            {
                p_ = BigInteger.Parse("26959946667150639794667015087019630673557916260026308143510066298881");
                a_ = BigInteger.Parse("26959946667150639794667015087019630673557916260026308143510066298878");
                b_ = BigInteger.Parse("18958286285566608000408668544493926415504680968679321075787234672564");
                q_ = BigInteger.Parse("26959946667150639794667015087019625940457807714424391721682722368061");
                x_ = BigInteger.Parse("19277929113566293071110308034699488026831934219452440156649784352033");
                y_ = BigInteger.Parse("19926808758034470970197974370888749184205991990603949537637343198772");
                curveCount = 1;
            }
            if (comboBox1.SelectedIndex == 2)
            {
                p_ = BigInteger.Parse("115792089210356248762697446949407573530086143415290314195533631308867097853951");
                a_ = BigInteger.Parse("115792089210356248762697446949407573530086143415290314195533631308867097853948");
                b_ = BigInteger.Parse("41058363725152142129326129780047268409114441015993725554835256314039467401291");
                q_ = BigInteger.Parse("115792089210356248762697446949407573529996955224135760342422259061068512044369");
                x_ = BigInteger.Parse("48439561293906451759052585252797914202762949526041747995844080717082404635286");
                y_ = BigInteger.Parse("36134250956749795798585127919587881956611106672985015071877198253568414405109");
                curveCount = 2;
            }
            if (comboBox1.SelectedIndex == 3)
            {
                p_ = BigInteger.Parse("39402006196394479212279040100143613805079739270465446667948293404245721771496870329047266088258938001861606973112319");
                a_ = BigInteger.Parse("39402006196394479212279040100143613805079739270465446667948293404245721771496870329047266088258938001861606973112316");
                b_ = BigInteger.Parse("27580193559959705877849011840389048093056905856361568521428707301988689241309860865136260764883745107765439761230575");
                q_ = BigInteger.Parse("39402006196394479212279040100143613805079739270465446667946905279627659399113263569398956308152294913554433653942643");
                x_ = BigInteger.Parse("26247035095799689268623156744566981891852923491109213387815615900925518854738050089022388053975719786650872476732087");
                y_ = BigInteger.Parse("8325710961489029985546751289520108179287853048861315594709205902480503199884419224438643760392947333078086511627871");
                curveCount = 3;
            }
            if (comboBox1.SelectedIndex == 4)
            {
                p_ = BigInteger.Parse("6864797660130609714981900799081393217269435300143305409394463459185543183397656052122559640661454554977296311391480858037121987999716643812574028291115057151");
                a_ = BigInteger.Parse("6864797660130609714981900799081393217269435300143305409394463459185543183397656052122559640661454554977296311391480858037121987999716643812574028291115057148");
                b_ = BigInteger.Parse("1093849038073734274511112390766805569936207598951683748994586394495953116150735016013708737573759623248592132296706313309438452531591012912142327488478985984");
                q_ = BigInteger.Parse("6864797660130609714981900799081393217269435300143305409394463459185543183397655394245057746333217197532963996371363321113864768612440380340372808892707005449");
                x_ = BigInteger.Parse("2661740802050217063228768716723360960729859168756973147706671368418802944996427808491545080627771902352094241225065558662157113545570916814161637315895999846");
                y_ = BigInteger.Parse("3757180025770020463545507224491183603594455134769762486694567779615544477440556316691234405012945539562144444537289428522585666729196580810124344277578376784");
                curveCount = 4;
            }
            choose_curve = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                BigInteger Xa = BigInteger.Parse(textBox3.Text);
                BigInteger H = BigInteger.Parse(textBox2.Text);
                BigInteger k = BigInteger.Parse(textBox4.Text);
                BigInteger r, s;

                ECPoint G = new ECPoint(x_, y_, a_, b_, p_);
                ECPoint Ya = new ECPoint();
                ECPoint F = new ECPoint();
                ECPoint Y = new ECPoint();

                Ya = ECPoint.multiply(Xa, G);
                F = ECPoint.multiply(k, G);

                richTextBox1.Text += "Хаттама:\nE = " + comboBox1.Text + ";\np = " + p_.ToString() + ";\nq = " + q_.ToString() + ";\na = " + a_.ToString() + ";\nb = " + b_.ToString() + ";\n";
                richTextBox1.Text += "G = (x , y):\n(" + x_.ToString() + " ,\n" + y_.ToString() + ");\n\n";
                richTextBox1.Text += "Point Ya = [Xa] * G: \n(" + Ya.x.ToString() + " , " + Ya.y.ToString() + ")\n\n";
                richTextBox1.Text += "Point P = [k] * G: \n(" + F.x.ToString() + " , " + F.y.ToString() + ")\n\n";

                r = F.x % q_;
                s = (k * H + r * Xa) % q_;
                richTextBox1.Text += "Қолтаңба:\n";
                richTextBox1.Text += "r = " + r.ToString() + "\n\ns = " + s.ToString();
                Saving_file.Text += curveCount.ToString() + "\n" + r.ToString() + ",\n" + s.ToString() + ",\n" + Ya.x.ToString() + ",\n" + Ya.y.ToString();
            }
            catch
            {
                MessageBox.Show("Қате!", "Хабарлама", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            try
            {
                if (saveFileDialog1.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    return;

                string r = Path.GetExtension(saveFileDialog1.FileName);

                if (r == ".txt")
                    Saving_file.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                else
                    Saving_file.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.RichText);

                string s = Path.GetFileName(saveFileDialog1.FileName);

                this.Saving_file.Modified = false;
            }
            catch
            {
                MessageBox.Show("Файл сақталынбады!", "Ескерту!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (choose_curve)
                {
                    if (BigInteger.Parse(textBox3.Text) > q_ || BigInteger.Parse(textBox3.Text) < 0)
                    {
                        this.textBox3.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        this.textBox3.ForeColor = System.Drawing.Color.Black;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Қате!", "Хабарлама", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (choose_curve)
                {
                    if (BigInteger.Parse(textBox4.Text) > q_ || BigInteger.Parse(textBox4.Text) < 0)
                    {
                        this.textBox4.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        this.textBox4.ForeColor = System.Drawing.Color.Black;
                    }
                }
            }
            catch
            {
                MessageBox.Show("Қате!", "Хабарлама", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

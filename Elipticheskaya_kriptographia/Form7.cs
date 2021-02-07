using System;
using System.Text;
using System.Windows.Forms;
using System.Numerics;
using System.IO;
using System.Security.Cryptography;
using Word = Microsoft.Office.Interop.Word;

namespace Elipticheskaya_kriptographia
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
            MessageBox.Show("Хэштелетін файлды таңдаңыз", "Назар аударыңыз!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            openFile();
            hashSha1();
            MessageBox.Show("Ашық кілтпен қолтаңбаны таңдаңыз (r, s)", "Назар аударыңыз!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            openKeys();
            curveCount = Int32.Parse(richTextBox.Text.Substring(0, 1));
            richTextBox.Text = richTextBox.Text.Remove(0, 1);
            r = BigInteger.Parse(richTextBox.Text.Substring(0, richTextBox.Text.IndexOf(',')));
            richTextBox.Text = richTextBox.Text.Remove(0, richTextBox.Text.IndexOf(',') + 1);
            s = BigInteger.Parse(richTextBox.Text.Substring(0, richTextBox.Text.IndexOf(',')));
            richTextBox.Text = richTextBox.Text.Remove(0, richTextBox.Text.IndexOf(',') + 1);
            yX = BigInteger.Parse(richTextBox.Text.Substring(0, richTextBox.Text.IndexOf(',')));
            richTextBox.Text = richTextBox.Text.Remove(0, richTextBox.Text.IndexOf(',') + 1);
            yY = BigInteger.Parse(richTextBox.Text);
            if (curveCount == 0)
            {
                p_ = BigInteger.Parse("6277101735386680763835789423207666416083908700390324961279");
                a_ = BigInteger.Parse("6277101735386680763835789423207666416083908700390324961276");
                b_ = BigInteger.Parse("2455155546008943817740293915197451784769108058161191238065");
                q_ = BigInteger.Parse("6277101735386680763835789423176059013767194773182842284081");
                x_ = BigInteger.Parse("602046282375688656758213480587526111916698976636884684818");
                y_ = BigInteger.Parse("174050332293622031404857552280219410364023488927386650641");
            }
            else if (curveCount == 1)
            {
                p_ = BigInteger.Parse("26959946667150639794667015087019630673557916260026308143510066298881");
                a_ = BigInteger.Parse("26959946667150639794667015087019630673557916260026308143510066298878");
                b_ = BigInteger.Parse("18958286285566608000408668544493926415504680968679321075787234672564");
                q_ = BigInteger.Parse("26959946667150639794667015087019625940457807714424391721682722368061");
                x_ = BigInteger.Parse("19277929113566293071110308034699488026831934219452440156649784352033");
                y_ = BigInteger.Parse("19926808758034470970197974370888749184205991990603949537637343198772");
            }
            else if (curveCount == 2)
            {
                p_ = BigInteger.Parse("115792089210356248762697446949407573530086143415290314195533631308867097853951");
                a_ = BigInteger.Parse("115792089210356248762697446949407573530086143415290314195533631308867097853948");
                b_ = BigInteger.Parse("41058363725152142129326129780047268409114441015993725554835256314039467401291");
                q_ = BigInteger.Parse("115792089210356248762697446949407573529996955224135760342422259061068512044369");
                x_ = BigInteger.Parse("48439561293906451759052585252797914202762949526041747995844080717082404635286");
                y_ = BigInteger.Parse("36134250956749795798585127919587881956611106672985015071877198253568414405109");
            }
            else if (curveCount == 3)
            {
                p_ = BigInteger.Parse("39402006196394479212279040100143613805079739270465446667948293404245721771496870329047266088258938001861606973112319");
                a_ = BigInteger.Parse("39402006196394479212279040100143613805079739270465446667948293404245721771496870329047266088258938001861606973112316");
                b_ = BigInteger.Parse("27580193559959705877849011840389048093056905856361568521428707301988689241309860865136260764883745107765439761230575");
                q_ = BigInteger.Parse("39402006196394479212279040100143613805079739270465446667946905279627659399113263569398956308152294913554433653942643");
                x_ = BigInteger.Parse("26247035095799689268623156744566981891852923491109213387815615900925518854738050089022388053975719786650872476732087");
                y_ = BigInteger.Parse("8325710961489029985546751289520108179287853048861315594709205902480503199884419224438643760392947333078086511627871");
            }
            else if (curveCount == 4)
            {
                p_ = BigInteger.Parse("6864797660130609714981900799081393217269435300143305409394463459185543183397656052122559640661454554977296311391480858037121987999716643812574028291115057151");
                a_ = BigInteger.Parse("6864797660130609714981900799081393217269435300143305409394463459185543183397656052122559640661454554977296311391480858037121987999716643812574028291115057148");
                b_ = BigInteger.Parse("1093849038073734274511112390766805569936207598951683748994586394495953116150735016013708737573759623248592132296706313309438452531591012912142327488478985984");
                q_ = BigInteger.Parse("6864797660130609714981900799081393217269435300143305409394463459185543183397655394245057746333217197532963996371363321113864768612440380340372808892707005449");
                x_ = BigInteger.Parse("2661740802050217063228768716723360960729859168756973147706671368418802944996427808491545080627771902352094241225065558662157113545570916814161637315895999846");
                y_ = BigInteger.Parse("3757180025770020463545507224491183603594455134769762486694567779615544477440556316691234405012945539562144444537289428522585666729196580810124344277578376784");
            }
            BigInteger H = BigInteger.Parse(textBox2.Text);
            h_1 = keri_element_tcepnoi(q_, H);
            u1 = (s * h_1) % q_;
            u2 = (-r * h_1) % q_;
            u2 += q_;
            ECPoint G = new ECPoint(x_, y_, a_, b_, p_);
            ECPoint Ya = new ECPoint(yX, yY, a_, b_, p_);
            ECPoint F1 = ECPoint.multiply(u1, G);
            ECPoint F2 = ECPoint.multiply(u2, Ya);
            ECPoint P3 = new ECPoint();
            P3 = F1 + F2;
            bool proverka = false;
            if (r == P3.x % q_)
            {
                MessageBox.Show("Қолтаңба дұрыс қойылған!", "Назар аударыңыз!", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                proverka = true;
            }
            else
            {
                MessageBox.Show("Қолтаңба дұрыс қойылмаған!", "Қате!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                proverka = false;
            }
            string curve = "";
            switch (curveCount)
            {
                case 0:
                    curve = "Curve P-192";
                    break;
                case 1:
                    curve = "Curve P-224";
                    break;
                case 2:
                    curve = "Curve P-256";
                    break;
                case 3:
                    curve = "Curve P-384";
                    break;
                case 4:
                    curve = "Curve P-521";
                    break;
            }
            richTextBox1.Text += "Нәтиже:\nE = " + curve + ";\np = " + p_.ToString() + ";\nq = " + q_.ToString() + ";\na = " + a_.ToString() + ";\nb = " + b_.ToString();
            richTextBox1.Text += ";\nG = (x , y):\n(" + x_.ToString() + " ,\n" + y_.ToString() + ");\n\n";
            richTextBox1.Text += "Ашық кілт Ya = (x , y):\n(" + yX.ToString() + " ,\n" + yY.ToString() + ");\n\n";
            richTextBox1.Text += "r = " + r.ToString() + ";\n";
            richTextBox1.Text += "s = " + s.ToString() + ";\n";
            richTextBox1.Text += "h = " + H.ToString() + ";\n";
            richTextBox1.Text += "h^(-1) = " + h_1.ToString() + ";\n";
            richTextBox1.Text += "u1 = s*h^(-1) mod q = " + u1.ToString() + ";\n";
            richTextBox1.Text += "u2 = -r*h^(-1) mod q = " + u2.ToString() + ";\n\n";
            richTextBox1.Text += "P = [u1]G + [u2]Ya: \n(" + P3.x.ToString() + " ,\n" + P3.y.ToString() + ");\n\n";
            richTextBox1.Text += "Тексеру: r =? P(x) mod q :\n";
            if (proverka)
            {
                richTextBox1.Text += "r = P(x) mod q = " + r.ToString() + "\nҚолтаңба қабылданды!";
            }
            else
            {
                richTextBox1.Text += "r <> P(x) mod q : " + r.ToString() + " <> " + (P3.x % q_).ToString() + "\nЖалған қолтаңба!";
            }
        }
        int curveCount;
        BigInteger r, s, u1, u2, h_1, yX, yY;
        BigInteger p_ = new BigInteger();
        BigInteger a_ = new BigInteger();
        BigInteger b_ = new BigInteger();
        BigInteger q_ = new BigInteger();
        BigInteger x_ = new BigInteger();
        BigInteger y_ = new BigInteger();
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
                    MessageBox.Show("ХЭШ = " + textBox2.Text, "", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                }
            }
        }
        private void openFile()
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
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
        private void openKeys()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Word.Application app = new Microsoft.Office.Interop.Word.Application();
                Object docxFileName = openFileDialog.FileName;
                Object missing = Type.Missing;

                app.Documents.Open(ref docxFileName, ref missing,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing);

                string temp = System.IO.Path.GetTempPath();

                Object lookComments = false;
                Object password = String.Empty;
                Object AddToRecentFiles = true;
                Object WritePassword = String.Empty;
                Object ReadOnlyRecommended = false;
                Object EmbedTrueTypeFonts = false;
                Object SaveFormsData = false;
                Object SaveAsAOCELetter = false;

                Object rtfFileName = openFileDialog.SafeFileName.Substring(0, openFileDialog.SafeFileName.Length - ".docx".Length);

                Random random = new Random();

                while (System.IO.File.Exists(rtfFileName + ".rtf"))

                    rtfFileName += random.Next(0, 9).ToString();

                Object wdFormatRTF = Word.WdSaveFormat.wdFormatRTF;

                rtfFileName += ".rtf";

                rtfFileName = temp + rtfFileName;

                app.ActiveDocument.SaveAs(ref rtfFileName,
                    ref wdFormatRTF, ref lookComments, ref password, ref AddToRecentFiles, ref WritePassword, ref ReadOnlyRecommended,
                    ref EmbedTrueTypeFonts, ref missing, ref SaveFormsData, ref SaveAsAOCELetter, ref missing,
                    ref missing, ref missing, ref missing, ref missing);

                Object @false = false;

                app.ActiveDocument.Close(ref @false, ref missing, ref missing);

                app.Quit(ref @false, ref missing, ref missing);

                richTextBox.LoadFile((String)rtfFileName);
            }
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

        private void шығуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void сохранитьТекстToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            try
            {
                if (saveFileDialog1.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    return;

                string r = Path.GetExtension(saveFileDialog1.FileName);

                if (r == ".txt")
                    richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                else
                    richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.RichText);

                string s = Path.GetFileName(saveFileDialog1.FileName);

                this.richTextBox1.Modified = false;
            }
            catch
            {
                MessageBox.Show("Файл сақталынбады!", "Хабарлама!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

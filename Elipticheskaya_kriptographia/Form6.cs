using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Numerics;
using System.IO;
using System.Security.Cryptography;
using Word = Microsoft.Office.Interop.Word;

namespace Elipticheskaya_kriptographia
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
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
            }
            catch
            {
                MessageBox.Show("Файл не найден!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BasicOperation BO = new BasicOperation();
            BO.text = richTextBox1.Text;
            BO.computeShifr();
            richTextBox2.Text = BO.ShifrText;
            BO.unloc();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BasicOperation BO = new BasicOperation();
            BO.ShifrText = richTextBox2.Text;
            BO.computeDeShifr();
            richTextBox1.Text = BO.deShifrText;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Word.Application app = new Microsoft.Office.Interop.Word.Application();//процесс ворда
                Object docxFileName = openFileDialog.FileName;//имя файла
                Object missing = Type.Missing;
                //открыли дркумент
                app.Documents.Open(ref docxFileName, ref missing,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing);
                //путь к папке с временными файлами
                string temp = System.IO.Path.GetTempPath();
                //для передачи параметров при пересохранении
                Object lookComments = false;
                Object password = String.Empty;
                Object AddToRecentFiles = true;
                Object WritePassword = String.Empty;
                Object ReadOnlyRecommended = false;
                Object EmbedTrueTypeFonts = false;
                Object SaveFormsData = false;
                Object SaveAsAOCELetter = false;
                //имя файла без расширения
                Object rtfFileName = openFileDialog.SafeFileName.Substring(0, openFileDialog.SafeFileName.Length - ".docx".Length);
                //создали рандом
                Random random = new Random();
                //проверяем есть ли файл с таким именем
                while (System.IO.File.Exists(rtfFileName + ".rtf"))
                    //генерируем случайное имя файла
                    rtfFileName += random.Next(0, 9).ToString();
                //формат RTF
                Object wdFormatRTF = Word.WdSaveFormat.wdFormatRTF;
                //приписали расширение
                rtfFileName += ".rtf";
                //приписали путь к временным файлам
                rtfFileName = temp + rtfFileName;
                //пересохранили
                app.ActiveDocument.SaveAs(ref rtfFileName,
                    ref wdFormatRTF, ref lookComments, ref password, ref AddToRecentFiles, ref WritePassword, ref ReadOnlyRecommended,
                    ref EmbedTrueTypeFonts, ref missing, ref SaveFormsData, ref SaveAsAOCELetter, ref missing,
                    ref missing, ref missing, ref missing, ref missing);
                //переменная
                Object @false = false;
                //закрыли текущий документ
                app.ActiveDocument.Close(ref @false, ref missing, ref missing);
                //вышли из ворда
                app.Quit(ref @false, ref missing, ref missing);
                //прочли файл
                richTextBox1.LoadFile((String)rtfFileName);
            }
        }

        private void button6_Click(object sender, EventArgs e)
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
                MessageBox.Show("Невозможно сохранить файл!", "Сообщение!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Word.Application app = new Microsoft.Office.Interop.Word.Application();//процесс ворда
                Object docxFileName = openFileDialog.FileName;//имя файла
                Object missing = Type.Missing;
                //открыли дркумент
                app.Documents.Open(ref docxFileName, ref missing,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing);
                //путь к папке с временными файлами
                string temp = System.IO.Path.GetTempPath();
                //для передачи параметров при пересохранении
                Object lookComments = false;
                Object password = String.Empty;
                Object AddToRecentFiles = true;
                Object WritePassword = String.Empty;
                Object ReadOnlyRecommended = false;
                Object EmbedTrueTypeFonts = false;
                Object SaveFormsData = false;
                Object SaveAsAOCELetter = false;
                //имя файла без расширения
                Object rtfFileName = openFileDialog.SafeFileName.Substring(0, openFileDialog.SafeFileName.Length - ".docx".Length);
                //создали рандом
                Random random = new Random();
                //проверяем есть ли файл с таким именем
                while (System.IO.File.Exists(rtfFileName + ".rtf"))
                    //генерируем случайное имя файла
                    rtfFileName += random.Next(0, 9).ToString();
                //формат RTF
                Object wdFormatRTF = Word.WdSaveFormat.wdFormatRTF;
                //приписали расширение
                rtfFileName += ".rtf";
                //приписали путь к временным файлам
                rtfFileName = temp + rtfFileName;
                //пересохранили
                app.ActiveDocument.SaveAs(ref rtfFileName,
                    ref wdFormatRTF, ref lookComments, ref password, ref AddToRecentFiles, ref WritePassword, ref ReadOnlyRecommended,
                    ref EmbedTrueTypeFonts, ref missing, ref SaveFormsData, ref SaveAsAOCELetter, ref missing,
                    ref missing, ref missing, ref missing, ref missing);
                //переменная
                Object @false = false;
                //закрыли текущий документ
                app.ActiveDocument.Close(ref @false, ref missing, ref missing);
                //вышли из ворда
                app.Quit(ref @false, ref missing, ref missing);
                //прочли файл
                richTextBox2.LoadFile((String)rtfFileName);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            try // Сохраняем файл.
            {
                if (saveFileDialog1.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                    return;

                string r = Path.GetExtension(saveFileDialog1.FileName);

                if (r == ".txt")
                    richTextBox2.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                else
                    richTextBox2.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.RichText);

                string s = Path.GetFileName(saveFileDialog1.FileName);

                this.richTextBox2.Modified = false;
            }
            catch // Если невозможно сохранить файл - выводим сообщение об ошибке.
            {
                MessageBox.Show("Невозможно сохранить файл!", "Сообщение!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            richTextBox2.Text = "";
        }
    }

    class BasicOperation
    {
        public string text;
        public string ShifrText;
        public string deShifrText;
        #region parametters
        BigInteger p_ = new BigInteger();
        BigInteger a_ = new BigInteger();
        BigInteger b_ = new BigInteger();
        BigInteger q_ = new BigInteger();
        BigInteger x_ = new BigInteger();
        BigInteger y_ = new BigInteger();
        ECPoint misal = new ECPoint();
        EGCrypt shifr = new EGCrypt();
        #endregion
        #region ainymaly

        string s, str = "", strlen = "";
        int intStrlen = 0;
        bool bl = false;
        public void unloc()
        {
            s = str = strlen = "";
            intStrlen = 0;
            bl = false;
        }
        BigInteger eForDeShifr = new BigInteger();
        BigInteger xForDeShifr = new BigInteger();
        BigInteger yForDeShifr = new BigInteger();
        string keyMemory = "";

        #endregion
        private void setData()
        {
            p_ = BigInteger.Parse("39402006196394479212279040100143613805079739270465446667948293404245721771496870329047266088258938001861606973112319");
            a_ = BigInteger.Parse("39402006196394479212279040100143613805079739270465446667948293404245721771496870329047266088258938001861606973112316");
            b_ = BigInteger.Parse("27580193559959705877849011840389048093056905856361568521428707301988689241309860865136260764883745107765439761230575");
            q_ = BigInteger.Parse("39402006196394479212279040100143613805079739270465446667946905279627659399113263569398956308152294913554433653942643");
            x_ = BigInteger.Parse("26247035095799689268623156744566981891852923491109213387815615900925518854738050089022388053975719786650872476732087");
            y_ = BigInteger.Parse("8325710961489029985546751289520108179287853048861315594709205902480503199884419224438643760392947333078086511627871");
            misal.FieldChar = p_;
            misal.a = a_;
            misal.b = b_;
            misal.x = x_;
            misal.y = y_;
            shifr.point = misal;
            shifr.randomKeyBob = 1569453213545974137;
            shifr.secretKeyAlice = 5468453213545974137;
        }
        private void vizovVirezaniy()
        {
            while (intStrlen + 6 < p_.ToString().Length && !bl)
            {
                virezatDannih();
            }
        }
        private void virezatDannih()
        {
            try
            {
                s = text.Substring(0, 1);
                System.Text.UTF8Encoding enc = new System.Text.UTF8Encoding();
                byte[] strBytes = enc.GetBytes(s);
                foreach (byte k1 in strBytes)
                {
                    str += k1.ToString();
                    /* if (k1.ToString().Length == 3)
                     { strlen += 3; intStrlen += 3; }
                     else if (k1.ToString().Length == 2)
                     { strlen += 2; intStrlen += 2; }
                     else { strlen += 1; intStrlen += 1; }*/
                    if (k1.ToString().Length == 3)
                    { strlen += 3; intStrlen += 3; }
                    if (k1.ToString().Length == 2)
                    { strlen += 2; intStrlen += 2; }
                    if (k1.ToString().Length == 1)
                    { strlen += 1; intStrlen += 1; }
                } text = text.Remove(0, 1);
            }
            catch
            {
                bl = true;
            }
        }
        public void computeShifr()
        {
            setData();
            while (!bl)
            {
                try
                {
                    vizovVirezaniy();
                    shifr.Encrypt(BigInteger.Parse(str));
                    ShifrText += shifr.eText + "|" + strlen + "|";
                    str = "";
                    strlen = "";
                    intStrlen = 0;
                }
                catch
                {
                    //MessageBox.Show("что-то не так!***");
                }
            }
        }
        public void computeDeShifr()
        {
            deShifrator();
            try
            {
                while (ShifrText.Length != 0)
                {
                    deShifrator();
                }
            }
            catch
            {
                //MessageBox.Show(",kf");
            }
        }
        private void deShifrator()
        {
            eForDeShifr = BigInteger.Parse(ShifrText.Substring(0, ShifrText.IndexOf('|')));
            ShifrText = ShifrText.Remove(0, ShifrText.IndexOf('|') + 1);
            xForDeShifr = BigInteger.Parse(ShifrText.Substring(0, ShifrText.IndexOf('|')));
            ShifrText = ShifrText.Remove(0, ShifrText.IndexOf('|') + 1);
            yForDeShifr = BigInteger.Parse(ShifrText.Substring(0, ShifrText.IndexOf('|')));
            ShifrText = ShifrText.Remove(0, ShifrText.IndexOf('|') + 1);
            keyMemory = ShifrText.Substring(0, ShifrText.IndexOf('|'));
            ShifrText = ShifrText.Remove(0, ShifrText.IndexOf('|') + 1);
            Razdelitel razd = new Razdelitel();
            setData();
            shifr.R.x = xForDeShifr;
            shifr.R.y = yForDeShifr;
            shifr.Decrypt(eForDeShifr);
            razd.razdelit(shifr.deCod.ToString(), keyMemory);
            deShifrText += razd.razdelit(shifr.deCod.ToString(), keyMemory);
        }
    }
    class ECPoint
    {
        public BigInteger x;
        public BigInteger y;
        public BigInteger a;
        public BigInteger b;
        public BigInteger FieldChar;

        public ECPoint(ECPoint p)
        {
            x = p.x;
            y = p.y;
            a = p.a;
            b = p.b;
            FieldChar = p.FieldChar;
        }
        public ECPoint()
        {
            x = new BigInteger();
            y = new BigInteger();
            a = new BigInteger();
            b = new BigInteger();
            FieldChar = new BigInteger();
        }
        public ECPoint(BigInteger newX, BigInteger newY, BigInteger newA, BigInteger newB, BigInteger newP)
        {
            x = newX; y = newY; a = newA; b = newB; FieldChar = newP;
        }

        public static ECPoint operator +(ECPoint p1, ECPoint p2)
        {
            ECPoint p3 = new ECPoint();
            p3.a = p1.a;
            p3.b = p1.b;
            p3.FieldChar = p1.FieldChar;

            BigInteger dy = p2.y - p1.y;
            BigInteger dx = p2.x - p1.x;

            if (dx < 0)
                dx += p1.FieldChar;
            if (dy < 0)
                dy += p1.FieldChar;

            //
            BigInteger i = p1.FieldChar, v = 0, d = 1;
            while (dx > 0)
            {
                BigInteger t = i / dx, x = dx;
                dx = i % x;
                i = x;
                x = d;
                d = v - t * x;
                v = x;
            }
            v %= p1.FieldChar;
            if (v < 0) v = (v + p1.FieldChar) % p1.FieldChar;
            //

            BigInteger m = (dy * v) % p1.FieldChar;
            if (m < 0)
                m += p1.FieldChar;
            p3.x = (m * m - p1.x - p2.x) % p1.FieldChar;
            p3.y = (m * (p1.x - p3.x) - p1.y) % p1.FieldChar;
            if (p3.x < 0)
                p3.x += p1.FieldChar;
            if (p3.y < 0)
                p3.y += p1.FieldChar;
            return p3;

        }
        public static ECPoint Double(ECPoint p)
        {
            ECPoint p2 = new ECPoint();
            p2.a = p.a;
            p2.b = p.b;
            p2.FieldChar = p.FieldChar;

            BigInteger dy = 3 * p.x * p.x + p.a;
            BigInteger dx = 2 * p.y;

            if (dx < 0)
                dx += p.FieldChar;
            if (dy < 0)
                dy += p.FieldChar;
            //
            BigInteger i = p.FieldChar, v = 0, d = 1;
            while (dx > 0)
            {
                BigInteger t = i / dx, x = dx;
                dx = i % x;
                i = x;
                x = d;
                d = v - t * x;
                v = x;
            }
            v %= p.FieldChar;
            if (v < 0) v = (v + p.FieldChar) % p.FieldChar;
            //

            BigInteger m = (dy * v) % p.FieldChar;
            p2.x = (m * m - p.x - p.x) % p.FieldChar;
            p2.y = (m * (p.x - p2.x) - p.y) % p.FieldChar;
            if (p2.x < 0)
                p2.x += p.FieldChar;
            if (p2.y < 0)
                p2.y += p.FieldChar;

            return p2;
        }
        public static ECPoint multiply(BigInteger x, ECPoint p)
        {
            ECPoint temp = p;
            x = x - 1;
            while (x != 0)
            {

                if ((x % 2) != 0)
                {
                    if ((temp.x == p.x) || (temp.y == p.y))
                        temp = Double(temp);
                    else
                        temp = temp + p;
                    x = x - 1;
                }
                x = x / 2;
                p = Double(p);
            }
            return temp;
        }
    }
    class EGCrypt
    {
        // public BigInteger incod;
        // public BigInteger outcod;
        public ECPoint R;
        public BigInteger eCod;
        public BigInteger deCod;
        public BigInteger secretKeyAlice;
        public BigInteger randomKeyBob;
        public ECPoint point;
        public string eText;

        public EGCrypt()
        {
            R = new ECPoint();
            eCod = new BigInteger();
            deCod = new BigInteger();
            secretKeyAlice = new BigInteger();
            randomKeyBob = new BigInteger();
            point = new ECPoint();
        }
        public void Encrypt(BigInteger nincod)
        {
            ECPoint D = ECPoint.multiply(secretKeyAlice, point);
            R = ECPoint.multiply(randomKeyBob, point); // open key
            ECPoint P = ECPoint.multiply(randomKeyBob, D);
            eCod = (nincod * P.x) % D.FieldChar; // open key
            eText = eCod.ToString() + "|" + R.x.ToString() + "|" + R.y.ToString();
        }
        public void Decrypt(BigInteger noutcod)
        {
            R = ECPoint.multiply(randomKeyBob, point);
            ECPoint D = ECPoint.multiply(secretKeyAlice, point);
            ECPoint Q = ECPoint.multiply(secretKeyAlice, R);
            deCod = (noutcod * keri_element_tcepnoi(Q.FieldChar, Q.x)) % Q.FieldChar;
        }
        public void Decrypter(BigInteger noutcod, ECPoint T)
        {
            T = ECPoint.multiply(randomKeyBob, point);
            ECPoint D = ECPoint.multiply(secretKeyAlice, point);
            ECPoint Q = ECPoint.multiply(secretKeyAlice, T);
            deCod = (noutcod * keri_element_tcepnoi(Q.FieldChar, Q.x)) % Q.FieldChar;
        }
        #region modInvers
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
        #endregion
    }
    class Razdelitel
    {
        public Byte[] soobshenieMassive;
        public void Cclear()
        {
            soobshenieMassive = null;
        }
        public string soobshenie()
        {
            string Hat = "";
            System.Text.UTF8Encoding enc = new System.Text.UTF8Encoding();
            Hat += enc.GetString(soobshenieMassive);
            return Hat;
        }
        public string razdelit(string razdeliaemaia, string razdelitel)
        {
            string Hat = "";
            System.Text.UTF8Encoding enc = new System.Text.UTF8Encoding();
            Byte[] massive = new Byte[razdelitel.Length]; int j = -1;
            int Count;
            while (razdelitel.Length != 0)
            {
                j++;
                Count = Byte.Parse(razdelitel.Substring(0, 1));
                razdelitel = razdelitel.Remove(0, 1);
                if (Count == 1)
                {
                    massive[j] = Byte.Parse(razdeliaemaia.Substring(0, 1));
                    razdeliaemaia = razdeliaemaia.Remove(0, 1);
                }
                if (Count == 2)
                {
                    massive[j] = Byte.Parse(razdeliaemaia.Substring(0, 2));
                    razdeliaemaia = razdeliaemaia.Remove(0, 2);
                }
                if (Count == 3)
                {
                    massive[j] = Byte.Parse(razdeliaemaia.Substring(0, 3));
                    razdeliaemaia = razdeliaemaia.Remove(0, 3);
                }
            }
            soobshenieMassive = massive;
            Hat += enc.GetString(soobshenieMassive);
            return Hat;
        }
    }
}

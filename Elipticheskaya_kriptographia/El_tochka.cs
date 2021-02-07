using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;

namespace Elipticheskaya_kriptographia
{
    class El_tochka
    {
        public BigInteger koordinata_x;
        public BigInteger koordinata_y;
        public BigInteger prostoe_chislo_p;
        public BigInteger koeficient_a;
        public BigInteger koeficient_b;
        public BigInteger koordinata_x2;
        public BigInteger koordinata_y2;
        public BigInteger n;

        public El_tochka(BigInteger newKoordinata_x, BigInteger newKoordinata_y, BigInteger newProstoechislo_p, BigInteger newKoeficient_a, BigInteger newKoeficient_b, BigInteger newKoordinata_x2, BigInteger newKoordinata_y2, BigInteger newN)
        {
            koordinata_x = newKoordinata_x;
            koordinata_y = newKoordinata_y;
            prostoe_chislo_p = newProstoechislo_p;
            koeficient_a = newKoeficient_a;
            koeficient_b = newKoeficient_b;
            koordinata_x2 = newKoordinata_x2;
            koordinata_y2 = newKoordinata_y2;
            n = newN;
        }

        public bool pc(BigInteger x)
        {
            bool q = false;
            if (BigInteger.ModPow(5, x - 1, x) == 1)
            {
                q = true;
            }
            return q;
        }

        public bool nukte()
        {
            bool nukte_ = false;
            if ((koordinata_y * koordinata_y) % prostoe_chislo_p == (BigInteger.Pow(koordinata_x, 3) + koeficient_a * koordinata_x + koeficient_b) % prostoe_chislo_p)
            {
                nukte_ = true;
            }
            return nukte_;
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

        public string eki_eseleu()
        {
            string str = "";
            BigInteger z1, z2, ustingi_bolik, astingi_bolik, P, x3, y3;
            z1 = koordinata_x;
            z2 = koordinata_y;
            P = prostoe_chislo_p;

            ustingi_bolik = (3 * z1 * z1 + koeficient_a) % P;
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
            str = "(" + x3.ToString() + "," + y3.ToString() + ")";
            return str;
        }

        BigInteger kk = 3;

        public string compute_but()
        {
            string strc = "";
            BigInteger xx1, yy1, xx2, yy2, xx3, yy3, bol_usti, bol_asti, airma, P;
            xx1 = koordinata_x;
            yy1 = koordinata_y;
            xx2 = koordinata_x2;
            yy2 = koordinata_y2;
            P = prostoe_chislo_p;
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
            kk++;
            strc = "(" + xx3.ToString() + "," + yy3.ToString() + ")";
            return strc;
        }

        public string N_kratnost()
        {
            string strn = "";
            //********************************************************************************
            BigInteger z1, z2, ustingi_bolik, astingi_bolik, P, x3, y3;
            z1 = koordinata_x;
            z2 = koordinata_y;
            P = prostoe_chislo_p;

            ustingi_bolik = (3 * z1 * z1 + koeficient_a) % P;
            astingi_bolik = keri_element_tcepnoi(P,(2 * z2));
            x3 = (BigInteger.Pow(ustingi_bolik * astingi_bolik, 2) - 2 * z1) % P;
            y3 = (ustingi_bolik * astingi_bolik * (z1 - x3) - z2) % P;
            if (y3 % P < 0)
            {
                y3 = (y3 % P);
                while (y3 < 0)
                {
                    y3 += P;
                }
            }
            //********************************************************************************


            //********************************************************************************
            BigInteger xx1, yy1, xx2, yy2, xx3, yy3, bol_usti, bol_asti, airma;
            xx2 = x3;
            yy2 = y3;
            xx1 = koordinata_x;
            yy1 = koordinata_y;
            for (int i = 0; i < n - 2; i++)
            {

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
                xx2 = xx3;
                yy2 = yy3;
                kk++;
            }
            strn = "(" + xx2.ToString() + "," + yy2.ToString() + ")";
            //********************************************************************************
            return strn;
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

    }
}

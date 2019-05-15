using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelApp
{
    class Methods
    {

        public void SetR(int[] tab, int k, string[] s1, string[] s2, long[] s3, ref string s4, ref string s5, ref long s6) // ustawianie z dowolnego na k(,1,2) zajecie lub rezerwacje ;
        {
            for (int i = 0; i < tab.Length; i++)
            {
                if (tab[i] == 0)
                {
                    tab[i] = k;
                    s1[i] = s4;
                    s2[i] = s5;
                    s3[i] = s6;
                    break;
                }
            }
        }

        public void SetZ(int z, int[] tab, string[] z1, string[] z2, string[] z3, long[] z4, string[] z5, string[] z6)// ustawianie na 0 z 1 (rezerwacji) lub zajecia 2(zajecia)
        {
            tab[z] = 0;
            z1[z] = "wolny";
            z2[z] = "";
            z3[z] = "";
            z4[z] = 0;
            z5[z] = "";
            z6[z] = "";
        }

        public void Sum(int[] tab, ref int l1, ref int l2, ref int l3)// zliczanie liczby danych pokoi
        {
            for (int i = 0; i < tab.Length; i++)
            {
                if (tab[i] == 0)
                    l1++;
                if (tab[i] == 1)
                    l2++;
                if (tab[i] == 2)
                    l3++;
            }
        }

        public void Attribution(int[] tab1, string[] tab2)
        {
            for (int i = 0; i < tab1.Length; i++)
            {
                if (tab1[i] == 0)
                {
                    tab2[i] = "wolny";
                }
                if (tab1[i] == 1)
                {
                    tab2[i] = "zarezerwowany";
                }
                if (tab1[i] == 2)
                {
                    tab2[i] = "zajęty";
                }
            }
        }

        public void date(int[] n, string[] d1, string[] d2, ref string d3, ref string d4)
        {
            for (int i = 0; i < n.Length; i++)
            {
                if (n[i] == 0)
                {
                    d1[i] = d3;
                    d2[i] = d4;
                    break;
                }
            }
        }
    }
}

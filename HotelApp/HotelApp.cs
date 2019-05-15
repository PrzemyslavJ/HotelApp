using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelApp
{

    public partial class HotelApp : Form
    {

        public HotelApp()
        {
            InitializeComponent();
        }
      
        int[] one_room = new int[10];// tablice pokoi, przypisanie wartosci do danego pokoju (elementu tablicy): 0 - wolny, 1 - zarezerwowany, 2 - zajęty
        int[] two_room = new int[12];
        int[] three_room = new int[8];
        int[] four_room = new int[7];

        string[] Sone_room = new string[10]; //tablice ustawionych stanow (wolny,zarezerwowany,zajety)
        string[] Stwo_room = new string[12];
        string[] Sthree_room = new string[8];
        string[] Sfour_room = new string[7];

        string[] None_room = new string[10]; // tablice ustawionych nazwisk
        string[] Ntwo_room = new string[12];
        string[] Nthree_room = new string[8];
        string[] Nfour_room = new string[7];

        string[] Nrone_room = new string[10]; // tablice ustawionych numerow dowodow
        string[] Nrtwo_room = new string[12];
        string[] Nrthree_room = new string[8];
        string[] Nrfour_room = new string[7];

        long[] Pone_room = new long[10];// tablice ustawionych peseli
        long[] Ptwo_room = new long[12];
        long[] Pthree_room = new long[8];
        long[] Pfour_room = new long[7];

        string[] D1one_room = new string[10]; // tablice ustawionych dat początkowych
        string[] D1two_room = new string[12];
        string[] D1three_room = new string[8];
        string[] D1four_room = new string[7];

        string[] D2one_room = new string[10]; // tablice ustawionych dat końcowych
        string[] D2two_room = new string[12];
        string[] D2three_room = new string[8];
        string[] D2four_room = new string[7];

        Methods p = new Methods();

        int room, operation, operationS, confR, confZ;
        long P;
        string N, Nr;
        string dateS, dateE;
        bool setD = false;

        date_setting date1 = new date_setting();

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id2 = comboBox2.SelectedIndex;
            if (id2 == 0) { room = 1; }//wybór pokoju 1 - osobowego
            if (id2 == 1) { room = 2; }//wybór pokoju 2 - osobowego
            if (id2 == 2) { room = 3; }//wybór pokoju 3 - osobowego
            if (id2 == 3) { room = 4; }//wybór pokoju 4 - osobowego
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = comboBox1.SelectedIndex;
            if (id == 0) { operation = 1; }//rezerwacja
            if (id == 1) { operation = 2; }//zajecie

        }
        
        private void button16_Click(object sender, EventArgs e)
        {
            setD = true;
            date1.ShowDialog();

        }
        private void button2_Click(object sender, EventArgs e)
        {

           dateS = ""; dateE = "";

            if (setD == true)
            {
                dateS = date1.dateset1;
                dateE = date1.dateset2;
            }
            try
            {
                N = textBox16.Text;
                Nr = textBox17.Text;
                P = Convert.ToInt64(textBox18.Text);
                
            }
            catch
            {
                textBox49.Text = "Wprowadź poprawne dane !!!";
            }
            string Ps = Convert.ToString(P);

            if (Ps.Length > 0 && N.Length > 0 && Nr.Length > 0 && dateS.Length > 0 && dateE.Length > 0)
            {
                if (confR == 1)
                {
                    if (operation == 1)
                    {
                        switch (room)
                        {
                            case 1:
                                p.date(one_room, D1one_room, D2one_room, ref dateS, ref dateE);
                                p.SetR(one_room, 1, None_room, Nrone_room, Pone_room, ref N, ref Nr, ref P);
                                break;
                            case 2:
                                p.date(two_room, D1two_room, D2two_room, ref dateS, ref dateE);
                                p.SetR(two_room, 1, Ntwo_room, Nrtwo_room, Ptwo_room, ref N, ref Nr, ref P);
                                break;
                            case 3:
                                p.date(three_room, D1three_room, D2three_room, ref dateS, ref dateE);
                                p.SetR(three_room, 1, Nthree_room, Nrthree_room, Pthree_room, ref N, ref Nr, ref P);
                                break;
                            case 4:
                                p.date(four_room, D1four_room, D2four_room, ref dateS, ref dateE);
                                p.SetR(four_room, 1, Nfour_room, Nrfour_room, Pfour_room, ref N, ref Nr, ref P);
                                break;
                            default:
                                break;
                        }
                    }
                    if (operation == 2)
                    {
                        switch (room)
                        {
                            case 1:
                                p.date(one_room, D1one_room, D2one_room, ref dateS, ref dateE);
                                p.SetR(one_room, 2, None_room, Nrone_room, Pone_room, ref N, ref Nr, ref P);
                                break;
                            case 2:
                                p.date(two_room, D1two_room, D2two_room, ref dateS, ref dateE);
                                p.SetR(two_room, 2, Ntwo_room, Nrtwo_room, Ptwo_room, ref N, ref Nr, ref P);
                                break;
                            case 3:
                                p.date(three_room, D1three_room, D2three_room, ref dateS, ref dateE);
                                p.SetR(three_room, 2, Nthree_room, Nrthree_room, Pthree_room, ref N, ref Nr, ref P);
                                break;
                            case 4:
                                p.date(four_room, D1four_room, D2four_room, ref dateS, ref dateE);
                                p.SetR(four_room, 2, Nfour_room, Nrfour_room, Pfour_room, ref N, ref Nr, ref P);
                                break;
                            default:
                                break;
                        }
                    }

                    CountRooms();
                    
                    textBox16.Text = "";
                    textBox17.Text = "";
                    textBox18.Text = "";
                    radioButton1.Checked = true;
                    date1.dateset1 = ""; // eksperymentalne
                    date1.dateset2 = ""; //
                    setD = false;

                    ShowRoomConditions(operationS); 
                    
                }
                else
                {
                    textBox49.Text = "Potwierdź operacje !";
                }

            }
            else
            {
                textBox49.Text = "Wypełnij wszystkie dane ! ";
            }

        }
       
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id3 = comboBox3.SelectedIndex;
            ShowRoomConditions(id3);
        }

        private void ShowRoomConditions(int a)
        {
            
            if (a == 0)
            {
                operationS = 1;
                textBox19.Text = ""; textBox20.Text = ""; textBox21.Text = ""; textBox22.Text = ""; textBox23.Text = "";
                textBox24.Text = ""; textBox25.Text = ""; textBox26.Text = ""; textBox27.Text = ""; textBox28.Text = "";
                textBox45.Text = ""; textBox47.Text = "";
                textBox38.Text = ""; textBox37.Text = ""; textBox36.Text = ""; textBox35.Text = ""; textBox34.Text = ""; textBox33.Text = "";
                textBox32.Text = ""; textBox31.Text = ""; textBox30.Text = ""; textBox29.Text = ""; textBox46.Text = ""; textBox48.Text = "";

                textBox38.Text = Convert.ToString(Sone_room[0]);
                textBox37.Text = Convert.ToString(Sone_room[1]);
                textBox36.Text = Convert.ToString(Sone_room[2]);
                textBox35.Text = Convert.ToString(Sone_room[3]);
                textBox34.Text = Convert.ToString(Sone_room[4]);
                textBox33.Text = Convert.ToString(Sone_room[5]);
                textBox32.Text = Convert.ToString(Sone_room[6]);
                textBox31.Text = Convert.ToString(Sone_room[7]);
                textBox30.Text = Convert.ToString(Sone_room[8]);
                textBox29.Text = Convert.ToString(Sone_room[9]);

                textBox19.Text = "1."; textBox20.Text = "2."; textBox21.Text = "3."; textBox22.Text = "4."; textBox23.Text = "5.";
                textBox24.Text = "6."; textBox25.Text = "7."; textBox26.Text = "8."; textBox27.Text = "9."; textBox28.Text = "10.";
            }
            if (a == 1)
            {
                operationS = 2;
                textBox38.Text = Convert.ToString(Stwo_room[0]);
                textBox37.Text = Convert.ToString(Stwo_room[1]);
                textBox36.Text = Convert.ToString(Stwo_room[2]);
                textBox35.Text = Convert.ToString(Stwo_room[3]);
                textBox34.Text = Convert.ToString(Stwo_room[4]);
                textBox33.Text = Convert.ToString(Stwo_room[5]);
                textBox32.Text = Convert.ToString(Stwo_room[6]);
                textBox31.Text = Convert.ToString(Stwo_room[7]);
                textBox30.Text = Convert.ToString(Stwo_room[8]);
                textBox29.Text = Convert.ToString(Stwo_room[9]);
                textBox46.Text = Convert.ToString(Stwo_room[10]);
                textBox48.Text = Convert.ToString(Stwo_room[11]);
                textBox19.Text = "1."; textBox20.Text = "2."; textBox21.Text = "3."; textBox22.Text = "4."; textBox23.Text = "5.";
                textBox24.Text = "6."; textBox25.Text = "7."; textBox26.Text = "8."; textBox27.Text = "9."; textBox28.Text = "10.";
                textBox45.Text = "11."; textBox47.Text = "12.";
            }
            if (a == 2)
            {
                textBox19.Text = ""; textBox20.Text = ""; textBox21.Text = ""; textBox22.Text = ""; textBox23.Text = "";
                textBox24.Text = ""; textBox25.Text = ""; textBox26.Text = ""; textBox27.Text = ""; textBox28.Text = "";
                textBox45.Text = ""; textBox47.Text = "";
                textBox38.Text = ""; textBox37.Text = ""; textBox36.Text = ""; textBox35.Text = ""; textBox34.Text = ""; textBox33.Text = "";
                textBox32.Text = ""; textBox31.Text = ""; textBox30.Text = ""; textBox29.Text = ""; textBox46.Text = ""; textBox48.Text = "";

                operationS = 3;
                textBox38.Text = Convert.ToString(Sthree_room[0]);
                textBox37.Text = Convert.ToString(Sthree_room[1]);
                textBox36.Text = Convert.ToString(Sthree_room[2]);
                textBox35.Text = Convert.ToString(Sthree_room[3]);
                textBox34.Text = Convert.ToString(Sthree_room[4]);
                textBox33.Text = Convert.ToString(Sthree_room[5]);
                textBox32.Text = Convert.ToString(Sthree_room[6]);
                textBox31.Text = Convert.ToString(Sthree_room[7]);
                textBox19.Text = "1."; textBox20.Text = "2."; textBox21.Text = "3."; textBox22.Text = "4."; textBox23.Text = "5.";
                textBox24.Text = "6."; textBox25.Text = "7."; textBox26.Text = "8.";
            }
            if (a == 3)
            {
                textBox19.Text = ""; textBox20.Text = ""; textBox21.Text = ""; textBox22.Text = ""; textBox23.Text = "";
                textBox24.Text = ""; textBox25.Text = ""; textBox26.Text = ""; textBox27.Text = ""; textBox28.Text = "";
                textBox45.Text = ""; textBox47.Text = "";
                textBox38.Text = ""; textBox37.Text = ""; textBox36.Text = ""; textBox35.Text = ""; textBox34.Text = ""; textBox33.Text = "";
                textBox32.Text = ""; textBox31.Text = ""; textBox30.Text = ""; textBox29.Text = ""; textBox46.Text = ""; textBox48.Text = "";

                operationS = 4;
                textBox38.Text = Convert.ToString(Sfour_room[0]);
                textBox37.Text = Convert.ToString(Sfour_room[1]);
                textBox36.Text = Convert.ToString(Sfour_room[2]);
                textBox35.Text = Convert.ToString(Sfour_room[3]);
                textBox34.Text = Convert.ToString(Sfour_room[4]);
                textBox33.Text = Convert.ToString(Sfour_room[5]);
                textBox32.Text = Convert.ToString(Sfour_room[6]);
                textBox19.Text = "1."; textBox20.Text = "2."; textBox21.Text = "3."; textBox22.Text = "4."; textBox23.Text = "5.";
                textBox24.Text = "6."; textBox25.Text = "7.";

            }
        }
        
        private void DisplayConditionOne(int a)
        {
            int str = a + 1;
            if (operationS == 1)
            {
                textBox43.Text = "Pokój jednoosobowy";
                textBox42.Text = "nr." + str;
                textBox41.Text = Sone_room[a];
                textBox44.Text = None_room[a];
                textBox40.Text = Nrone_room[a];
                textBox39.Text = Convert.ToString(Pone_room[a]);
                textBox50.Text = D1one_room[a];
                textBox51.Text = D2one_room[a];
            }
        }

        private void DisplayConditionTwo(int a)
        {
            int str = a + 1;
            if (operationS == 2)
            {
                textBox43.Text = "Pokój dwuosobowy";
                textBox42.Text = "nr." + str;
                textBox41.Text = Stwo_room[a];
                textBox44.Text = Ntwo_room[a];
                textBox40.Text = Nrtwo_room[a];
                textBox39.Text = Convert.ToString(Ptwo_room[a]);
                textBox50.Text = D1two_room[a];
                textBox51.Text = D2two_room[a];
            }
        }
        private void DisplayConditionThree(int a)
        {
            int str = a + 1;
            if (operationS == 3)
            {
                textBox43.Text = "Pokój trzyosobowy";
                textBox42.Text = "nr." + str;
                textBox41.Text = Sthree_room[a];
                textBox44.Text = Nthree_room[a];
                textBox40.Text = Nrthree_room[a];
                textBox39.Text = Convert.ToString(Pthree_room[a]);
                textBox50.Text = D1three_room[a];
                textBox51.Text = D2three_room[a];
            }
        }
        private void DisplayConditionFour(int a)
        {
            int str = a + 1;
            if (operationS == 4)
            {
                textBox43.Text = "Pokój czteroosobowy";
                textBox42.Text = "nr." + str;
                textBox41.Text = Sfour_room[a];
                textBox44.Text = Nfour_room[a];
                textBox40.Text = Nrfour_room[a];
                textBox39.Text = Convert.ToString(Pfour_room[a]);
                textBox50.Text = D1four_room[a];
                textBox51.Text = D2four_room[a];
            }
        }

        private void DisplayCondition(int a)
        {
            DisplayConditionOne(a);
            DisplayConditionTwo(a);
            DisplayConditionThree(a);
            DisplayConditionFour(a);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DisplayCondition(0);
            
        }
      
        private void button5_Click(object sender, EventArgs e)
        {
            DisplayCondition(1);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DisplayCondition(2);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            DisplayCondition(3); 
        }

        private void button8_Click(object sender, EventArgs e)
        {
            DisplayCondition(4);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            DisplayCondition(5);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            DisplayCondition(6);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            DisplayConditionOne(7);
            DisplayConditionTwo(7);
            DisplayConditionThree(7);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            DisplayConditionOne(8);
            DisplayConditionTwo(8);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            DisplayConditionOne(9);
            DisplayConditionTwo(9);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DisplayConditionTwo(10);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DisplayConditionTwo(11);
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            confZ = 1;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            confR = 0;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            confR = 1;
        }
        
        private void zamknjiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void informacjeOAplikacjiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            App_information inform = new App_information();
            inform.ShowDialog();
        }

        private void informacjeOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Hotel_information hotel = new Hotel_information();
            hotel.ShowDialog();
        }
        
        protected void Przycisk_Click(object sender, EventArgs e)
        {
            Button przycisk = sender as Button;
            MessageBox.Show("elo");
        }
        
        private void ZFormuleOneRoom(int z)
        {
            p.SetZ(z, one_room, Sone_room, None_room, Nrone_room, Pone_room, D1one_room, D2one_room);
            textBox41.Text = Sone_room[z];
            textBox44.Text = None_room[z];
            textBox40.Text = Nrone_room[z];
            textBox39.Text = Convert.ToString(Pone_room[z]);
            textBox50.Text = D1one_room[z];
            textBox51.Text = D2one_room[z];
            if (operationS == 1) { textBox38.Text = Convert.ToString(Sone_room[z]); }
            radioButton3.Checked = true;
            CountRooms();
        }

        private void ZFormuleTwoRoom(int z)
        {
            p.SetZ(z, two_room, Stwo_room, Ntwo_room, Nrtwo_room, Ptwo_room, D1two_room, D2two_room);
            textBox41.Text = Stwo_room[z];
            textBox44.Text = Ntwo_room[z];
            textBox40.Text = Nrtwo_room[z];
            textBox39.Text = Convert.ToString(Ptwo_room[z]);
            textBox50.Text = D1two_room[z];
            textBox51.Text = D2two_room[z];
            if (operationS == 2) { textBox38.Text = Convert.ToString(Stwo_room[z]); }
            radioButton3.Checked = true;
            CountRooms();
        }

        private void ZFormuleThreeRoom(int z)
        {
            p.SetZ(z, three_room, Sthree_room, Nthree_room, Nrthree_room, Pthree_room, D1three_room, D2three_room);
            textBox41.Text = Sthree_room[z];
            textBox44.Text = Nthree_room[z];
            textBox40.Text = Nrthree_room[z];
            textBox39.Text = Convert.ToString(Pthree_room[z]);
            textBox50.Text = D1three_room[z];
            textBox51.Text = D2three_room[z];
            if (operationS == 3) { textBox38.Text = Convert.ToString(Sthree_room[z]); }
            radioButton3.Checked = true;
            CountRooms();
        }

        private void ZFormuleFourRoom(int z)
        {
            p.SetZ(z, four_room, Sfour_room, Nfour_room, Nrfour_room, Pfour_room, D1four_room, D2four_room);
            textBox41.Text = Sfour_room[z];
            textBox44.Text = Nfour_room[z];
            textBox40.Text = Nrfour_room[z];
            textBox39.Text = Convert.ToString(Pfour_room[z]);
            textBox50.Text = D1four_room[z];
            textBox51.Text = D2four_room[z];
            if (operationS == 4) { textBox38.Text = Convert.ToString(Sfour_room[z]); }
            radioButton3.Checked = true;
            CountRooms();
        }
        
        private void button14_Click(object sender, EventArgs e)
        {
            if (confZ == 1)
            {
                if (operationS == 1)
                {
                    switch(textBox42.Text)
                    {
                        case "nr.1": ZFormuleOneRoom(0);  break;
                        case "nr.2": ZFormuleOneRoom(1); break;
                        case "nr.3": ZFormuleOneRoom(2); break;
                        case "nr.4": ZFormuleOneRoom(3); break;
                        case "nr.5": ZFormuleOneRoom(4); break;
                        case "nr.6": ZFormuleOneRoom(5); break;
                        case "nr.7": ZFormuleOneRoom(6); break;
                        case "nr.8": ZFormuleOneRoom(7); break;
                        case "nr.9": ZFormuleOneRoom(8); break;
                        case "nr.10": ZFormuleOneRoom(9); break;
                        default: break;
                    }
                }
                else if (operationS == 2)
                {
                    switch (textBox42.Text)
                    {
                        case "nr.1": ZFormuleTwoRoom(0); break;
                        case "nr.2": ZFormuleTwoRoom(1); break;
                        case "nr.3": ZFormuleTwoRoom(2); break;
                        case "nr.4": ZFormuleTwoRoom(3); break;
                        case "nr.5": ZFormuleTwoRoom(4); break;
                        case "nr.6": ZFormuleTwoRoom(5); break;
                        case "nr.7": ZFormuleTwoRoom(6); break;
                        case "nr.8": ZFormuleTwoRoom(7); break;
                        case "nr.9": ZFormuleTwoRoom(8); break;
                        case "nr.10": ZFormuleTwoRoom(9); break;
                        case "nr.11": ZFormuleTwoRoom(10); break;
                        case "nr.12": ZFormuleTwoRoom(11); break;
                        default: break;
                    }  
                }
                else if (operationS == 3)
                {
                    switch (textBox42.Text)
                    {
                        case "nr.1": ZFormuleThreeRoom(0); break;
                        case "nr.2": ZFormuleThreeRoom(1); break;
                        case "nr.3": ZFormuleThreeRoom(2); break;
                        case "nr.4": ZFormuleThreeRoom(3); break;
                        case "nr.5": ZFormuleThreeRoom(4); break;
                        case "nr.6": ZFormuleThreeRoom(5); break;
                        case "nr.7": ZFormuleThreeRoom(6); break;
                        case "nr.8": ZFormuleThreeRoom(7); break;
                        default: break;
                    }
                }
                else if(operationS == 4)
                {
                    switch (textBox42.Text)
                    {
                        case "nr.1": ZFormuleFourRoom(0); break;
                        case "nr.2": ZFormuleFourRoom(1); break;
                        case "nr.3": ZFormuleFourRoom(2); break;
                        case "nr.4": ZFormuleFourRoom(3); break;
                        case "nr.5": ZFormuleFourRoom(4); break;
                        case "nr.6": ZFormuleFourRoom(5); break;
                        case "nr.7": ZFormuleFourRoom(6); break;
                        default: break;
                    } 
                }
            }
            else
            {
                textBox49.Text = "Potwierdź zwolnienie !";
            }
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            confZ = 0;
        }

        private void CountRooms()
        {
            int sum10 = 0, sum11 = 0, sum12 = 0, sum20 = 0, sum21 = 0, sum22 = 0,
                sum30 = 0, sum31 = 0, sum32 = 0, sum40 = 0, sum41 = 0, sum42 = 0;

            p.Sum(one_room, ref sum10, ref sum11, ref sum12);
            p.Sum(two_room, ref sum20, ref sum21, ref sum22);
            p.Sum(three_room, ref sum30, ref sum31, ref sum32);
            p.Sum(four_room, ref sum40, ref sum41, ref sum42);

            p.Attribution(one_room, Sone_room);
            p.Attribution(two_room, Stwo_room);
            p.Attribution(three_room, Sthree_room);
            p.Attribution(four_room, Sfour_room);

            textBox1.Text = Convert.ToString(sum10);
            textBox2.Text = Convert.ToString(sum11);
            textBox3.Text = Convert.ToString(sum12);
            textBox4.Text = Convert.ToString(sum20);
            textBox5.Text = Convert.ToString(sum21);
            textBox6.Text = Convert.ToString(sum22);
            textBox7.Text = Convert.ToString(sum30);
            textBox8.Text = Convert.ToString(sum31);
            textBox9.Text = Convert.ToString(sum32);
            textBox10.Text = Convert.ToString(sum40);
            textBox11.Text = Convert.ToString(sum41);
            textBox12.Text = Convert.ToString(sum42);

            textBox13.Text = Convert.ToString((sum10 + sum20 + sum30 + sum40));
            textBox14.Text = Convert.ToString((sum11 + sum21 + sum31 + sum41));
            textBox15.Text = Convert.ToString((sum12 + sum22 + sum32 + sum42));
        }
    }
}

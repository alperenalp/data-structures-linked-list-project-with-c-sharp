using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace odev1_link_list_V2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public class Dugum
        {
            public int no;
            public string isim;
            public Dugum sonraki;
            public Dugum onceki;
        }
        Dugum bas = null;
        Dugum son = null;
        public Boolean doluMu()
        {
            if (bas != null) // Liste doluysa true
                return true;
            else
                return false;
        }

        private void button1_Click(object sender, EventArgs e) //Başa Ekleme
        {
            Dugum yeniDugum = new Dugum();
            yeniDugum.no = Convert.ToInt32(textBox1.Text);
            yeniDugum.isim = textBox4.Text;
            if (doluMu()) //liste dolu
            {
                yeniDugum.sonraki = bas;
                bas = yeniDugum;
            }
            else //liste boş
            {
                bas = yeniDugum;
                son = yeniDugum;
            }
        }

        private void button2_Click(object sender, EventArgs e) // Sona Ekleme
        {
            Dugum yeniDugum = new Dugum();
            yeniDugum.no = Convert.ToInt32(textBox1.Text);
            yeniDugum.isim = textBox4.Text;
            if (doluMu()) //liste dolu
            {
                son.sonraki = yeniDugum;
                son = yeniDugum;
            }
            else //liste boş
            {
                bas = yeniDugum;
                son = yeniDugum;
            }
        }
        public void listeyiYazdir()
        {
            Dugum isaretci = bas;
            int DugumSayisi = 0;
            richTextBox1.Text = null;
            while (isaretci != null)
            {
                richTextBox1.Text += isaretci.isim + ":"+ isaretci.no + " ---> ";
                isaretci = isaretci.sonraki;
                DugumSayisi++;
            }
            int indeks = DugumSayisi - 1;
            richTextBox1.Text += "null" + "\n" + "Dugum Sayısı: " + DugumSayisi + "\n" + "En son indeks: " + indeks;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            listeyiYazdir();
        }

        private void button4_Click(object sender, EventArgs e)  // Araya Ekleme
        {
            Dugum yeniDugum = new Dugum();
            yeniDugum.no = Convert.ToInt32(textBox1.Text);
            yeniDugum.isim = textBox4.Text;
            int indeks = Convert.ToInt32(textBox2.Text);
            if (doluMu() && indeks >= 0) //liste dolu
            {
                if (indeks == 0) // Başa ekleme
                {
                    yeniDugum.sonraki = bas;
                    bas = yeniDugum;
                }
                else // Ortalara ekleme
                {
                    Dugum isaretci1 = null;
                    Dugum isaretci2 = bas;
                    int mevcutIndeks = 0;
                    while (isaretci2 != null && mevcutIndeks<indeks)
                    {
                        isaretci1 = isaretci2;
                        isaretci2 = isaretci2.sonraki;
                        mevcutIndeks++;
                    }
                    if (isaretci2 == null) // Sona ekleme
                    {
                        son.sonraki = yeniDugum;
                        son = yeniDugum;
                    }
                    else  //Ortaya şimdi eklenecek
                    {
                        yeniDugum.sonraki = isaretci2;
                        isaretci1.sonraki = yeniDugum;
                    }
                }
            }
            else //liste boş
            {
                bas = yeniDugum;
                son = yeniDugum;
            }
        }

        private void button5_Click(object sender, EventArgs e)  // Baştan Silme
        {
            if (doluMu())
            {
                if (bas == son)  // listede tek Dugum var
                {
                    bas = null;
                    son = null;
                }
                else {  // ikiden fazla Dugum varsa
                    Dugum yeniBas = bas.sonraki;
                    bas.sonraki = null;
                    bas = yeniBas;
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)  // Sondan Silme
        {
            if (doluMu())
            {
                if (bas == son)  // listede tek Dugum var
                {
                    bas = null;
                    son = null;
                }
                else // ikiden fazla Dugum varsa
                {
                    Dugum isaretci = bas;
                    while (isaretci.sonraki != son)
                    {
                        isaretci = isaretci.sonraki;
                    }
                    isaretci.sonraki = null;
                    son = isaretci; 
                }
            }
        }

        private void button7_Click(object sender, EventArgs e)  //Aradan Silme
        {
            int indeks = Convert.ToInt32(textBox3.Text);
            if (doluMu() && indeks>=0 )
            {
                if (bas == son)  // tek Dugum varsa
                {
                    bas = null;
                    son = null;
                }
                else  // en az iki Dugum varsa 
                {
                    if (indeks == 0) // sildiğimiz baştaysa
                    {
                        Dugum yeniBas = bas.sonraki;
                        bas.sonraki = null;
                        bas = yeniBas;
                    }
                    else // sildiğimiz başta değilse
                    {
                        Dugum isaretci1 = null;
                        Dugum isaretci2 = bas;
                        int mevcutIndeks = 0;
                        while (isaretci2!=null && mevcutIndeks<indeks)
                        {
                            isaretci1 = isaretci2;
                            isaretci2 = isaretci2.sonraki;
                            mevcutIndeks++;
                        }
                        if (isaretci2!=null)
                        {
                            if (isaretci2== son)  //sondan silme
                            {
                                son = isaretci1;
                                isaretci1.sonraki = null;
                            }
                            else  // ortadan silme
                            {
                                Dugum isaretci3 = isaretci2.sonraki;
                                isaretci2.sonraki = null;
                                isaretci1.sonraki = isaretci3;
                            }
                        }
                    }
                }
            }
        }
    }
}

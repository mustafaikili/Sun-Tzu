using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace sunTzu
{

    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        static int seviye ;
        int butonSayisi = 0, satir = 0, sutun = 0;
        int hamleSayisi = 1,seviyeEski =0,starSeviye=0 , degisken =0;
        String konum = "";
        Button[] butonDizi = new Button[seviye * seviye];
        
        SqlConnection baglanti = new SqlConnection();
        SqlCommand komut = new SqlCommand();
        SqlCommand komut2 = new SqlCommand();
        SqlCommand komut3 = new SqlCommand();

        private void Form1_Load(object sender, EventArgs e)
        {
                        
            baglanti.ConnectionString = "Data Source=.;Initial Catalog=SunTzu;Integrated Security=True";
            baglanti.Open();
            komut = new SqlCommand("select seviye from [dbo].[Table] as seviye", baglanti);  
            SqlDataReader reader = komut.ExecuteReader();
            reader.Read();
            seviye = Convert.ToInt32(reader["seviye"].ToString());
            label1.Text = System.Convert.ToString(seviye - 4);
            baglanti.Close();
            buton_olustur();
            starAktifYap();  
        }

        void buton_Click(object sender, EventArgs e)
        {
            
            Button tiklanan = sender as Button;
           
            if (tiklanan.Text =="")
            {
                if (hamleSayisi == 1)
                {
                    this.hamleyiYaz(tiklanan);
                }
                
                if (Convert.ToInt32(konum) % 10 + 3 == Convert.ToInt32(tiklanan.Tag.ToString()) % 10 && konum.ToString().Substring(0, 1) == tiklanan.Tag.ToString().Substring(0, 1) )
                {//sağa giden
                    this.hamleyiYaz(tiklanan);
                }
                if (Convert.ToInt32(konum) % 10 - 3 == (Convert.ToInt32(tiklanan.Tag)) % 10 && konum.ToString().Substring(0, 1) == tiklanan.Tag.ToString().Substring(0, 1))
                {//sola giden 
                    this.hamleyiYaz(tiklanan);
                }
                if (Convert.ToInt32(konum) + 30 == Convert.ToInt32(tiklanan.Tag) && Convert.ToInt32(konum) % 10 == Convert.ToInt32(tiklanan.Tag) % 10)
                {//aşağı giden
                    this.hamleyiYaz(tiklanan);
                }
                if (Convert.ToInt32(konum) + 22 == Convert.ToInt32(tiklanan.Tag))
                {//aşağı sağ çapraza giden
                    this.hamleyiYaz(tiklanan);
                }
                if (Convert.ToInt32(konum) + 18 == Convert.ToInt32(tiklanan.Tag))
                {//aşağı sol çapraza giden
                    this.hamleyiYaz(tiklanan);
                }
                if (Convert.ToInt32(konum) - 30 == (Convert.ToInt32(tiklanan.Tag)) && Convert.ToInt32(konum) % 10 == Convert.ToInt32(tiklanan.Tag) % 10)
                {//yukarı giden
                    this.hamleyiYaz(tiklanan);
                }
                if (Convert.ToInt32(konum) - 18 == (Convert.ToInt32(tiklanan.Tag)))
                {//yukarı sağ çapraza giden
                    this.hamleyiYaz(tiklanan);
                }
                if (Convert.ToInt32(konum) - 22 == (Convert.ToInt32(tiklanan.Tag)))
                {//yukarı sol çapraza giden
                    this.hamleyiYaz(tiklanan);
                }
            }   
            
        }

        private void btnTekrarOyna_Click(object sender, EventArgs e)
        {
            tekrarOyna();
        }
        private void btnSeviye1_Click(object sender, EventArgs e)
        {
            seviyeEski = seviye;
            seviye = 5;
            seviyeOlustur();
            
            
        }
        private void btnSeviye2_Click(object sender, EventArgs e)
        {
            seviyeEski = seviye;
            seviye = 6;
            seviyeOlustur();     
            
        }

        private void btnSeviye3_Click(object sender, EventArgs e)
        {
            seviyeEski = seviye;
            seviye = 7;
            seviyeOlustur();
        }

        private void btnSeviye4_Click(object sender, EventArgs e)
        {
            seviyeEski = seviye;
            seviye = 8;
            seviyeOlustur();
        }

        private void btnSeviye5_Click(object sender, EventArgs e)
        {
            seviyeEski = seviye;
            seviye = 9;
            seviyeOlustur();
        }

        private void btnSeviye6_Click(object sender, EventArgs e)
        {
            seviyeEski = seviye;
            seviye = 10;
            seviyeOlustur();
        }
        public void buton_olustur()
        {
            satir = 40;
            sutun = 100;
            butonSayisi = seviye * seviye;
            butonDizi = new Button[butonSayisi];
            int indis = -1;
            for (int i = 0; i < seviye; i++)
            {
                for (int j = 0; j < seviye; j++)
                {
                    indis = i * seviye + j;

                    butonDizi[indis] = new Button();
                    butonDizi[indis].FlatStyle = FlatStyle.Flat;
                    butonDizi[indis].BackColor = System.Drawing.ColorTranslator.FromHtml("#EDE4D9");//33CCFF    -- #D5CDC3
                    butonDizi[indis].FlatAppearance.BorderColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
                    butonDizi[indis].FlatAppearance.BorderSize = 2;
                    //butonDizi[indis].BackColor = Color.Transparent;
                    //butonDizi[indis].ForeColor = System.Drawing.ColorTranslator.FromHtml("#FFFFFF");
                    butonDizi[indis].Tag = i.ToString() + j.ToString();
                    butonDizi[indis].Text = "";
                    butonDizi[indis].Size = new Size(400 / seviye, 400 / seviye);
                    butonDizi[indis].Location = new System.Drawing.Point(satir, sutun);
                    satir += (400 / seviye);

                    butonDizi[indis].Click += new System.EventHandler(this.buton_Click);

                    if (j % 10 == seviye - 1)
                    {
                        satir = 40;
                        sutun += (400 / seviye);
                    }
                    this.Controls.Add(butonDizi[indis]);
                }

            }
        }
        public void hamleyiYaz(Button tiklanan)
        {
            for (int i = 0; i < seviye * seviye; i++)
            {
                if (butonDizi[i].Text == "")
                {
                    butonDizi[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#EDE4D9");//33CCFF//#
                }
            }
            tiklanan.BackColor = ColorTranslator.FromHtml("#F79663");//OrangeRed       E1B7A1
            tiklanan.Text = hamleSayisi.ToString();
            puan.Text = hamleSayisi.ToString();
            hamleSayisi++;
            konum = tiklanan.Tag.ToString();
            hamleVarmi();
            
            
        }
        public void hamleVarmi() 
        {
            int i,j,sayac = 0;
            i= Convert.ToInt32(konum.Substring(0,1));
            j= Convert.ToInt32(konum.Substring(1,1));

            
            
                if (j + 3 < seviye && butonDizi[(i * seviye + j) + 3].Text == "")
                {//sağ
                    butonDizi[(i * seviye + j) + 3].BackColor = ColorTranslator.FromHtml("#EEC642");//DarkOrange
                }
                else
                {
                    sayac++;
                }
                if (j > 2 && butonDizi[(i * seviye + j) - 3].Text == "")
                {//sol
                    butonDizi[(i * seviye + j) - 3].BackColor = ColorTranslator.FromHtml("#EEC642");
                }
                else 
                {
                    sayac++;
                }
                if (i + 3 < seviye && butonDizi[(i * seviye + j) + seviye * 3].Text == "")
                {//aşağı
                    butonDizi[(i * seviye + j) + seviye * 3].BackColor = ColorTranslator.FromHtml("#EEC642");
                }
                else
                {
                    sayac++;
                }
                if (j < seviye - 2 && i < seviye - 2 && butonDizi[(i * seviye + j) + seviye * 2 + 2].Text == "")
                {//aşağı sağ çapraz
                    butonDizi[(i * seviye + j) + seviye * 2 + 2].BackColor = ColorTranslator.FromHtml("#EEC642");
                }
                else
                {
                    sayac++;
                }
                if (j > 1 && i < seviye - 2 && butonDizi[(i * seviye + j) + seviye * 2 - 2].Text == "")
                {//aşağı sol çapraz
                    butonDizi[(i * seviye + j) + seviye * 2 - 2].BackColor = ColorTranslator.FromHtml("#EEC642");
                }
                else
                {
                    sayac++;
                }
                if (i > 2 && butonDizi[(i * seviye + j) - seviye * 3].Text == "")
                {//yukarı
                    butonDizi[(i * seviye + j) - seviye * 3].BackColor = ColorTranslator.FromHtml("#EEC642");

                }
                else
                {
                    sayac++;
                }
                if (i > 1 && j < seviye - 2 && butonDizi[(i * seviye + j) - seviye * 2 + 2].Text == "")
                {//yukarı sağ çağraz
                    butonDizi[(i * seviye + j) - seviye * 2 + 2].BackColor = ColorTranslator.FromHtml("#EEC642");

                }
                else
                {
                    sayac++;
                }
                if (j > 1 && i > 1 && butonDizi[(i * seviye + j) - seviye * 2 - 2].Text == "")
                {//yukarı sol çapraz
                    butonDizi[(i * seviye + j) - seviye * 2 - 2].BackColor = ColorTranslator.FromHtml("#EEC642");

                }
                else
                {
                    sayac++;
                }
                if (sayac ==8 && hamleSayisi -1 != seviye*seviye)
                {
                    MessageBox.Show("Oyun Bitti Puanınız :  " +(hamleSayisi-1));
                    tekrarOyna();
                }

                seviyeGectiyse();
        }
        public void seviyeGuncelle() 
        {
            baglanti.Open();
            komut2 = new SqlCommand("update [dbo].[Table] set seviye =@seviye", baglanti);
            komut2.Parameters.AddWithValue("@seviye", seviye);
            komut2.ExecuteNonQuery();
            SqlDataReader reader2 = komut.ExecuteReader();
            reader2.Read();
            seviye = Convert.ToInt32(reader2["seviye"].ToString());
            baglanti.Close();
        }
        public void tekrarOyna() 
        {
            hamleSayisi = 1;
            for (int i = 0; i < seviye * seviye; i++)
            {
                butonDizi[i].Text = "";
                butonDizi[i].BackColor = System.Drawing.ColorTranslator.FromHtml("#EDE4D9");//33CCFF
                puan.Text = "0";
            }
        }
        public void starAktifYap()
        {
            if (starSeviye < seviye)
            {
                starSeviye = seviye;
            }
            if (starSeviye == 6)
            {
                btnSeviye2.Enabled = true;
            }
            if (starSeviye == 7)
            {
                btnSeviye2.Enabled = true;
                btnSeviye3.Enabled = true;

            }
            if (starSeviye == 8)
            {
                btnSeviye2.Enabled = true;
                btnSeviye3.Enabled = true;
                btnSeviye4.Enabled = true;

            }
            if (starSeviye == 9)
            {
                btnSeviye2.Enabled = true;
                btnSeviye3.Enabled = true;
                btnSeviye4.Enabled = true;
                btnSeviye5.Enabled = true;

            }
            if (starSeviye == 10)
            {
                btnSeviye2.Enabled = true;
                btnSeviye3.Enabled = true;
                btnSeviye4.Enabled = true;
                btnSeviye5.Enabled = true;
                btnSeviye6.Enabled = true;
            }
        }
        public void seviyeDegisecekmi()
        {
            baglanti.Open();
            komut = new SqlCommand("select seviye from [dbo].[Table] as seviye", baglanti);
            SqlDataReader reader = komut.ExecuteReader();
            reader.Read();
            degisken = Convert.ToInt32(reader["seviye"].ToString());
            baglanti.Close();
        }
        public void seviyeGectiyse()
        {
            if (hamleSayisi - 1 == 25 && seviye == 5)
            {
                seviyeEski = seviye;
                seviyeDegisecekmi();
                seviye = 6;
                if (degisken < seviye)
                {
                    seviyeGuncelle();
                }
                MessageBox.Show("Tebrikler " + seviye + ". Seviyeye Geçtiniz");
                seviyeOlustur();
                btnSeviye2.Enabled = true;
                puan.Text = "0";

            }
            if (hamleSayisi - 1 == 36 && seviye == 6)
            {
                seviyeEski = seviye;
                seviyeDegisecekmi();
                seviye = 7;
                if (degisken < seviye)
                {
                    seviyeGuncelle();
                }
                MessageBox.Show("Tebrikler " + seviye + ". Seviyeye Geçtiniz");
                seviyeGuncelle();
                seviyeOlustur();
                btnSeviye3.Enabled = true;
                puan.Text = "0";
            }
            if (hamleSayisi - 1 == 49 && seviye == 7)
            {
                seviyeEski = seviye;
                seviyeDegisecekmi();
                seviye = 8;
                if (degisken < seviye)
                {
                    seviyeGuncelle();
                }
                MessageBox.Show("Tebrikler " + seviye + ". Seviyeye Geçtiniz");
                seviyeGuncelle();
                seviyeOlustur();
                btnSeviye4.Enabled = true;
                puan.Text = "0";
            }
            if (hamleSayisi - 1 == 64 && seviye == 8)
            {
                seviyeEski = seviye;
                seviyeDegisecekmi();
                seviye = 9;
                if (degisken < seviye)
                {
                    seviyeGuncelle();
                }
                MessageBox.Show("Tebrikler " + seviye + ". Seviyeye Geçtiniz");
                seviyeGuncelle();
                seviyeOlustur();
                btnSeviye5.Enabled = true;
                puan.Text = "0";
            }
            if (hamleSayisi - 1 == 81 && seviye == 9)
            {
                seviyeEski = seviye;
                seviye = 10;
                MessageBox.Show("Tebrikler " + seviye + ". Seviyeye Geçtiniz");
                seviyeGuncelle();
                seviyeOlustur();
                btnSeviye6.Enabled = true;
                puan.Text = "0";
            }
            if (hamleSayisi - 1 == 100 && seviye == 10)
            {
                MessageBox.Show("Tebrikler Sun Tzu Oyununu Bitirdiniz :)");
                puan.Text = "0";
                tekrarOyna();
            }
        }
        public void seviyeOlustur() 
        {
            puan.Text = "0";            
            for (int i = 0; i < seviyeEski * seviyeEski; i++)
            {
                this.Controls.Remove(butonDizi[i]);
            }
            hamleSayisi = 1;
            
            label1.Text = System.Convert.ToString(seviye - 4);
            buton_olustur();
        }

    }
}

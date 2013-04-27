using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.IO;

using AForge.Video;
using AForge.Video.DirectShow;
using AForge.Imaging;
using AForge.Imaging.Filters;
using AForge.Imaging.Textures;
using AForge.Imaging.ComplexFilters;
using AForge.Math;

using System.Threading;

namespace Snapshot_Maker
{
    public partial class RecognizeForm : Form
    {
        private Bitmap oryginal_obrazu;
        private Bitmap obraz_w_grayscale;
        private Bitmap obraz_po_progowaniu;
        private Point[] bolce = new Point[6];
        
        // do rysowania po obrazie :
        Pen pioro;
        Graphics g;
        Bitmap obraz;
        
        // odczytane :
        private Point[] kostki = new Point[5];

        public RecognizeForm()
        {
            InitializeComponent();
        }

        private void RecognizeForm_Load(object sender, EventArgs e)
        {
            FileStream plik = new FileStream("bolce.txt", FileMode.Open, FileAccess.Read);
            StreamReader czytaj = new StreamReader(plik);

            for (int i = 0; i < 6; ++i)
            {

                bolce[i].X = Convert.ToInt32(czytaj.ReadLine().ToString());
                bolce[i].Y = Convert.ToInt32(czytaj.ReadLine().ToString());
            }
            plik.Close();
            textBox1.Clear();
            for (int i = 0; i < 6; ++i) textBox1.Text += bolce[i].X + " " + bolce[i].Y + Environment.NewLine;
        }

        public void SetImage(Bitmap obrazek)
        {
            oryginal_obrazu = obrazek;
            pictureBox1.Image = oryginal_obrazu;
            pictureBox1.Update();

            //AForge.Imaging.Filters.CannyEdgeDetector krawedzie = new CannyEdgeDetector();
            Grayscale czarno_bialy = new Grayscale(0.2125, 0.7154, 0.0721);
            obraz_w_grayscale = czarno_bialy.Apply(oryginal_obrazu);

            pictureBox1.Image = obraz_w_grayscale;
            pictureBox1.Update();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Threshold binearyzacja = new Threshold(100);
            binearyzacja.ApplyInPlace(obraz_w_grayscale);

            CannyEdgeDetector krawedzie = new CannyEdgeDetector();
            krawedzie.ApplyInPlace(obraz_w_grayscale);
            pictureBox1.Image = obraz_w_grayscale;
            pictureBox1.Update();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Bitmap obraz = new Bitmap("obraz.bmp");
            oryginal_obrazu = obraz;
            pictureBox1.Image = oryginal_obrazu;
            pictureBox1.Update();
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            oryginal_obrazu.Save("obraz.bmp");
        }

        private void button_gray_Click(object sender, EventArgs e)
        {
            Grayscale szarowanie = new Grayscale(0.2125, 0.7154, 0.0721);
            obraz_w_grayscale = szarowanie.Apply(oryginal_obrazu);
            pictureBox1.Image = obraz_w_grayscale;
            pictureBox1.Update();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button_threshold_Click(object sender, EventArgs e)
        {
            Threshold progowanie = new Threshold(Convert.ToInt32(numericUpDown1.Value.ToString()));
            obraz_po_progowaniu = progowanie.Apply(obraz_w_grayscale);
            pictureBox1.Image = obraz_po_progowaniu;
            pictureBox1.Update();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            Threshold progowanie = new Threshold(Convert.ToInt32(numericUpDown1.Value.ToString()));
            obraz_po_progowaniu = progowanie.Apply((Bitmap)pictureBox1.Image);
            pictureBox1.Image = obraz_po_progowaniu;
            pictureBox1.Update();
        }

        private void button_canny_Click(object sender, EventArgs e)
        {
            CannyEdgeDetector krawedzie = new CannyEdgeDetector();
            obraz_po_progowaniu = krawedzie.Apply(obraz_po_progowaniu);
            pictureBox1.Image = obraz_po_progowaniu;
            pictureBox1.Update();
        }

        private void button_filter_Click(object sender, EventArgs e)
        {
            // detekcja krawedzi :
            AForge.Imaging.Filters.SobelEdgeDetector sobelek = new SobelEdgeDetector();
            obraz_po_progowaniu = sobelek.Apply(obraz_w_grayscale);
            
            // progowanie :
            Threshold progowanie = new Threshold(40);
            obraz_po_progowaniu = progowanie.Apply(obraz_po_progowaniu);

            // otwieranie 
            Opening otwieranie = new Opening();
            otwieranie.ApplyInPlace(obraz_po_progowaniu);

            // dylatacja
            AForge.Imaging.Filters.Dilatation erozja = new Dilatation();
            erozja.ApplyInPlace(obraz_po_progowaniu);
            
            // najwiekszy obszar :
            BlobsFiltering obszar = new BlobsFiltering();
            obszar.MinHeight = 40;
            obszar.ApplyInPlace(obraz_po_progowaniu);

            FillHoles dziurki = new FillHoles();
            dziurki.MaxHoleHeight = 70;
            dziurki.MaxHoleWidth = 70;
            dziurki.CoupledSizeFiltering = false;
            dziurki.ApplyInPlace(obraz_po_progowaniu);

            pictureBox1.Image = obraz_po_progowaniu;
            pictureBox1.Update();

            obraz_po_progowaniu.Save("mierzenie.bmp", ImageFormat.Jpeg);

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Opening otwieranie = new Opening();
            otwieranie.ApplyInPlace(obraz_po_progowaniu);
            pictureBox1.Image = obraz_po_progowaniu;
            pictureBox1.Update();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AForge.Imaging.Filters.Closing zamykanie = new Closing();
            zamykanie.ApplyInPlace(obraz_po_progowaniu);
            pictureBox1.Image = obraz_po_progowaniu;
            pictureBox1.Update();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Invert odwroc = new Invert();
            odwroc.ApplyInPlace(obraz_po_progowaniu);
            pictureBox1.Image = obraz_po_progowaniu;
            pictureBox1.Update();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AForge.Imaging.Filters.Erosion erozja = new Erosion();
            erozja.ApplyInPlace(obraz_po_progowaniu);
            pictureBox1.Image = obraz_po_progowaniu;
            pictureBox1.Update();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AForge.Imaging.Filters.Dilatation dylatacja = new Dilatation();
            dylatacja.ApplyInPlace(obraz_po_progowaniu);
            pictureBox1.Image = obraz_po_progowaniu;
            pictureBox1.Update();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            BlobsFiltering obszar = new BlobsFiltering();
            obszar.MinHeight = 100;
            obszar.MinWidth = bolce[0].X - bolce[1].X;
            obszar.ApplyInPlace(obraz_po_progowaniu);
            pictureBox1.Image = obraz_po_progowaniu;
            pictureBox1.Update();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            obraz = new Bitmap("mierzenie.bmp");
            pioro = new Pen(Color.Red);
            g = Graphics.FromImage(obraz);
            for (int i=0; i<6; ++i)
                g.FillEllipse(pioro.Brush , bolce[i].X-10, bolce[i].Y-10, 20, 20);
            
            pictureBox1.Image = obraz;
            pictureBox1.Update();
        }

        // oblicza szerokosc dłoni i polożenie kostek
        private int SzerokoscDloni()
        {
            List<Point> punkty = new List<Point>();
            int min_szerokosc = 0;
            float x1 = bolce[4].X;
            float y1 = bolce[4].Y;
            float x2 = bolce[1].X;
            float y2 = bolce[1].Y;
            int temp_x = (int)Math.Min(x1, x2);
            int temp_x_2 = (int)Math.Max(x1, x2);

            Point a = new Point();
            Point b = new Point();
            // dodac obliczanie wspolczynnika kierunkowego : 

            for (int wys = -20; wys < 20; ++wys)
            {
                punkty = new List<Point>();
                for (int i = temp_x; i < temp_x_2; ++i)
                {
                    if ((0.3 * i) - wys -2 < 0) continue; // gdy poza ekranem

                    if (obraz.GetPixel(i, (int)(0.3 * i) - wys).ToArgb() == Color.White.ToArgb() ||
                        obraz.GetPixel(i+1, (int)(0.3 * i) - wys).ToArgb() == Color.White.ToArgb() ||
                        obraz.GetPixel(i+1, (int)(0.3 * i) - wys+1).ToArgb() == Color.White.ToArgb() ||
                        obraz.GetPixel(i+1, (int)(0.3 * i) - wys-1).ToArgb() == Color.White.ToArgb() ||
                        obraz.GetPixel(i, (int)(0.3 * i) - wys+1).ToArgb() == Color.White.ToArgb() ||
                        obraz.GetPixel(i, (int)(0.3 * i) - wys-1).ToArgb() == Color.White.ToArgb() ||
                        obraz.GetPixel(i, (int)(0.3 * i) - wys).ToArgb() == Color.White.ToArgb() || 
                        obraz.GetPixel(i-1, (int)(0.3 * i) - wys+1).ToArgb() == Color.White.ToArgb() ||
                        obraz.GetPixel(i-1, (int)(0.3 * i) - wys-1).ToArgb() == Color.White.ToArgb()
                        )
                    {
                        //g.FillEllipse(pioro.Brush, i - 5, (int)(0.3 * i - 5) - 30, 10, 10);
                        punkty.Add(new Point(i, (int)(0.3 * i) - wys));
                        i = temp_x_2;
                    }
                }
                for (int i = temp_x_2; i >= temp_x; --i)
                {
                    if ((0.3 * i) - wys - 2 < 0) continue; // gdy poza ekranem

                    if (obraz.GetPixel(i, (int)(0.3 * i) - wys).ToArgb() == Color.White.ToArgb() ||
                        obraz.GetPixel(i+1, (int)(0.3 * i) - wys).ToArgb() == Color.White.ToArgb() ||
                        obraz.GetPixel(i+1, (int)(0.3 * i) - wys+1).ToArgb() == Color.White.ToArgb() ||
                        obraz.GetPixel(i+1, (int)(0.3 * i) - wys-1).ToArgb() == Color.White.ToArgb() ||
                        obraz.GetPixel(i, (int)(0.3 * i) - wys+1).ToArgb() == Color.White.ToArgb() ||
                        obraz.GetPixel(i, (int)(0.3 * i) - wys-1).ToArgb() == Color.White.ToArgb() ||
                        obraz.GetPixel(i, (int)(0.3 * i) - wys).ToArgb() == Color.White.ToArgb() || 
                        obraz.GetPixel(i-1, (int)(0.3 * i) - wys+1).ToArgb() == Color.White.ToArgb() ||
                        obraz.GetPixel(i-1, (int)(0.3 * i) - wys-1).ToArgb() == Color.White.ToArgb()
                       )
                    {
                        punkty.Add(new Point(i, (int)(0.3 * i) - wys));
                        i = temp_x-1;
                    }
                }

                if (punkty.Count == 0) continue; // zabezpieczenie ;]

                if (wys == 10) // 1. cykl :
                {
                    min_szerokosc = (int)Math.Sqrt(Math.Pow((double)(punkty[punkty.Count-1].X - punkty[0].X), 2.0) + Math.Pow((double)(punkty[punkty.Count-1].Y - punkty[0].Y), 2.0));
                    a = punkty[0];
                    b = punkty[punkty.Count - 1];
                }
                else
                {
                    int temp = (int)Math.Sqrt(Math.Pow((double)(punkty[punkty.Count-1].X - punkty[0].X), 2.0) + Math.Pow((double)(punkty[punkty.Count-1].Y - punkty[0].Y), 2.0));
                    if (temp < min_szerokosc)
                    {
                        min_szerokosc = temp;
                        a = punkty[0];
                        b = punkty[punkty.Count - 1];
                    }
                }

            }
            
            pioro.Color = Color.Blue;
            pioro.StartCap = System.Drawing.Drawing2D.LineCap.RoundAnchor;
            g.DrawLine(pioro, a, b);
            /*  // rozwnomierne rozmieszczenie :
            kostki[0] = new Point(a.X + (b.X - a.X) / 5, a.Y + (b.Y - a.Y) / 5);
            kostki[1] = new Point(a.X + 2*(b.X - a.X) / 5, a.Y + 2*(b.Y - a.Y) / 5);
            kostki[2] = new Point(a.X + 3*(b.X - a.X) / 5, a.Y + 3*(b.Y - a.Y) / 5);
            kostki[3] = new Point(a.X + 4*(b.X - a.X) / 5, a.Y + 4*(b.Y - a.Y) / 5);
            */
            // rozmieszczenie ~ naturalne
            kostki[0] = new Point(a.X + 20 * (b.X - a.X) / 100, a.Y + 20 * (b.Y - a.Y) / 100);
            kostki[1] = new Point(a.X + 35 * (b.X - a.X) / 100, a.Y + 35 * (b.Y - a.Y) / 100);
            kostki[2] = new Point(a.X + 50 * (b.X - a.X) / 100, a.Y + 50 * (b.Y - a.Y) / 100);
            kostki[3] = new Point(a.X + 80 * (b.X - a.X) / 100, a.Y + 80 * (b.Y - a.Y) / 100);
            
            g.FillEllipse(pioro.Brush, kostki[0].X -10 , kostki[0].Y - 10 , 20, 20);
            g.FillEllipse(pioro.Brush, kostki[1].X - 10, kostki[1].Y - 10, 20, 20);
            g.FillEllipse(pioro.Brush, kostki[2].X - 10, kostki[2].Y - 10, 20, 20);
            g.FillEllipse(pioro.Brush, kostki[3].X - 10, kostki[3].Y - 10, 20, 20);

            pictureBox1.Image = obraz;
            pictureBox1.Update();

            return min_szerokosc;
        }

        private void button_cecha_1_Click(object sender, EventArgs e)
        {
            textBox3.Text = SzerokoscDloni().ToString();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Point punkt = new Point();
            double max_dlugosc = 0;
            
            for (int x = kostki[3].X; x < bolce[4].X; ++x)
            {
                for (int y = kostki[3].Y + 370; y > kostki[3].Y+200; --y)
                {
                    if (obraz.GetPixel(x, y).ToArgb() == Color.White.ToArgb() || obraz.GetPixel(x + 1, y - 1).ToArgb() == Color.White.ToArgb() || obraz.GetPixel(x - 1, y - 1).ToArgb() == Color.White.ToArgb())
                    {
                        if ((int)max_dlugosc == 0)
                        {
                            punkt.X = x;
                            punkt.Y = y;
                            max_dlugosc = Math.Sqrt(Math.Pow((double)(x - kostki[3].X), 2.0) + Math.Pow((double)(y - kostki[3].Y), 2.0));
                            y = kostki[3].Y;
                        }
                        else
                        {
                            double temp = Math.Sqrt(Math.Pow((double)(x - kostki[3].X), 2.0) + Math.Pow((double)(y - kostki[3].Y), 2.0));
                            if (temp > max_dlugosc)
                            {
                                punkt.X = x;
                                punkt.Y = y;
                                max_dlugosc = temp;
                                y = kostki[3].Y;
                            }
                            else
                            {
                                y = kostki[3].Y;
                            }
                        }
                    }
                    else obraz.SetPixel(x, y, Color.Coral);
                }
            }

            textBox2.Text = max_dlugosc.ToString();
            g.DrawLine(pioro, kostki[3], punkt);
                                
            pictureBox1.Image = obraz;
            pictureBox1.Update();
        }

        private void button_cecha_3_Click(object sender, EventArgs e)
        {
            //for (int i = 30; i < 130; i += 2)
            //    g.DrawLine(pioro, kostki[2], new Point(kostki[2].X - i, kostki[2].Y + 380));
            //pictureBox1.Image = obraz;
            //pictureBox1.Update();


            Point punkt = new Point();
            double max_dlugosc = 0;
            
            for (int x = bolce[5].X; x > bolce[3].X; --x)
            {
                for (int y = kostki[2].Y +400 ; y > kostki[2].Y+200; --y)
                {
                    if (obraz.GetPixel(x, y).ToArgb() == Color.White.ToArgb() || obraz.GetPixel(x + 1, y - 1).ToArgb() == Color.White.ToArgb() || obraz.GetPixel(x - 1, y - 1).ToArgb() == Color.White.ToArgb())
                    {
                        if ((int)max_dlugosc == 0) // 1. cykl pracy rozpoznawania :
                        {
                            punkt.X = x;
                            punkt.Y = y;
                            max_dlugosc = Math.Sqrt(Math.Pow((double)(punkt.X - kostki[2].X), 2.0) + Math.Pow((double)(punkt.Y - kostki[2].Y), 2.0));
                            y = kostki[2].Y;
                        }
                        else
                        {
                            double temp = Math.Sqrt(Math.Pow((double)(x - kostki[2].X), 2.0) + Math.Pow((double)(y - kostki[2].Y), 2.0));
                            if (temp > max_dlugosc)
                            {
                                punkt.X = x;
                                punkt.Y = y;
                                max_dlugosc = temp;
                                y = kostki[2].Y;
                            }
                            else
                            {
                                y = kostki[2].Y;
                            }
                        }
                    }
                    else obraz.SetPixel(x, y, Color.Coral);
                }
            }

            textBox4.Text = max_dlugosc.ToString();
            g.DrawLine(pioro, kostki[2], punkt);

            pictureBox1.Image = obraz;
            pictureBox1.Update();
        }

        private void button_cecha_4_Click(object sender, EventArgs e)
        {
            //for (int i = 130; i < 220; i += 2)
            //    g.DrawLine(pioro, kostki[1], new Point(kostki[1].X - i, kostki[1].Y + 350));

            Point punkt = new Point();
            double max_dlugosc = 0;
            
            for (int x = bolce[3].X - 20; x > bolce[3].X - 120; --x)
            {
                for (int y = bolce[3].Y + 150; y > bolce[3].Y - 20; --y)
                {
                    if (obraz.GetPixel(x, y).ToArgb() == Color.White.ToArgb() || obraz.GetPixel(x + 1, y - 1).ToArgb() == Color.White.ToArgb() || obraz.GetPixel(x - 1, y - 1).ToArgb() == Color.White.ToArgb())
                    {
                        if ((int)max_dlugosc == 0)
                        {
                            punkt.X = x;
                            punkt.Y = y;
                            max_dlugosc = Math.Sqrt(Math.Pow((double)(punkt.X - kostki[1].X), 2.0) + Math.Pow((double)(punkt.Y - kostki[1].Y), 2.0));
                            y = bolce[3].Y-50;
                        }
                        else
                        {
                            double temp = Math.Sqrt(Math.Pow((double)(x - kostki[1].X), 2.0) + Math.Pow((double)(y - kostki[1].Y), 2.0));
                            if (temp > max_dlugosc)
                            {
                                punkt.X = x;
                                punkt.Y = y;
                                max_dlugosc = temp;
                                y = bolce[3].Y-50;
                            }
                            else
                            {
                                y = bolce[3].Y-50;
                            }
                        }
                    }
                    else obraz.SetPixel(x, y, Color.Coral);
                }
            }


            textBox5.Text = max_dlugosc.ToString();
            g.DrawLine(pioro, kostki[1], punkt);


            pictureBox1.Image = obraz;
            pictureBox1.Update();
        }

        private void button_cecha_5_Click(object sender, EventArgs e)
        {
            Point punkt = new Point();
            double max_dlugosc = 0;
            
            for (int y = bolce[1].Y+20; y < bolce[1].Y+100 ; y++)
            {
                for (int x = 1; x < bolce[1].X -20; ++x)
                {
                    if (obraz.GetPixel(x, y).ToArgb() == Color.White.ToArgb() || obraz.GetPixel(x + 1, y - 1).ToArgb() == Color.White.ToArgb() || obraz.GetPixel(x - 1, y - 1).ToArgb() == Color.White.ToArgb())
                    {
                        if ((int)max_dlugosc == 0)
                        {
                            punkt.X = x;
                            punkt.Y = y;
                            max_dlugosc = Math.Sqrt(Math.Pow((double)(punkt.X - kostki[0].X), 2.0) + Math.Pow((double)(punkt.Y - kostki[0].Y), 2.0));
                            x = bolce[1].X+50;
                        }
                        else
                        {
                            double temp = Math.Sqrt(Math.Pow((double)(x - kostki[0].X), 2.0) + Math.Pow((double)(y - kostki[0].Y), 2.0));
                            if (temp > max_dlugosc)
                            {
                                punkt.X = x;
                                punkt.Y = y;
                                max_dlugosc = temp;
                                x = bolce[1].X + 50;
                            }
                            else
                            {
                                x = bolce[1].X + 50;
                            }
                        }
                    }
                    else obraz.SetPixel(x, y, Color.Coral);
                }
            }

            textBox6.Text = max_dlugosc.ToString();
            g.DrawLine(pioro, kostki[0], punkt);
            

            pictureBox1.Image = obraz;
            pictureBox1.Update();
        }

        private void button_show_off_Click(object sender, EventArgs e)
        {
            
            button_cecha_1_Click(null, null);
            if (Convert.ToDouble(textBox3.Text) < 300 || Convert.ToDouble(textBox3.Text) > 200) ; else goto blad;
            button2_Click_1(null, null);
            if (Convert.ToDouble(textBox2.Text) < 400 || Convert.ToDouble(textBox2.Text) > 100) ; else goto blad;
            button_cecha_3_Click(null, null);
            if (Convert.ToDouble(textBox4.Text) < 450 || Convert.ToDouble(textBox4.Text) > 200) ; else goto blad;
            button_cecha_4_Click(null, null);
            if (Convert.ToDouble(textBox5.Text) < 400 || Convert.ToDouble(textBox5.Text) > 200) ; else goto blad;
            button_cecha_5_Click(null, null);
            if (Convert.ToDouble(textBox6.Text) < 300 || Convert.ToDouble(textBox6.Text) > 200) ; else goto blad;
            button_cecha_6_Click(null, null);
            if (Convert.ToDouble(textBox7.Text) < 100 || Convert.ToDouble(textBox7.Text) > 30) ; else goto blad;
            button_cecha_7_Click(null, null);
            if (Convert.ToDouble(textBox8.Text) < 150 || Convert.ToDouble(textBox8.Text) > 30) ; else goto blad;
            button_cecha_8_Click(null, null);
            if (Convert.ToDouble(textBox9.Text) < 100 || Convert.ToDouble(textBox9.Text) > 30) ; else goto blad;
            button_cecha_9_Click(null, null);
            if (Convert.ToDouble(textBox10.Text) < 100 || Convert.ToDouble(textBox10.Text) > 0) ; else goto blad;
            button_cecha_10_Click(null, null);
            if (Convert.ToDouble(textBox11.Text) < 150 || Convert.ToDouble(textBox11.Text) > 0) ; else goto blad;
            button_cecha_11_Click(null, null);
            if (Convert.ToDouble(textBox12.Text) < 120 || Convert.ToDouble(textBox12.Text) > 0) ; else goto blad;
            button_cecha_12_Click(null, null);
            if (Convert.ToDouble(textBox13.Text) < 100 || Convert.ToDouble(textBox13.Text) > 30) ; else goto blad;
            button_cecha_13_Click(null, null);
            if (Convert.ToDouble(textBox14.Text) < 140 || Convert.ToDouble(textBox14.Text) > 50) ; else goto blad;
            button_cecha_14_Click(null, null);
            if (Convert.ToDouble(textBox15.Text) < 250 || Convert.ToDouble(textBox15.Text) > 250) ; else goto blad;
            button_cecha_15_Click(null, null);
            if (Convert.ToDouble(textBox16.Text) < 100 || Convert.ToDouble(textBox16.Text) > 0) ; else goto blad;
            button_cecha_16_Click(null, null);
            if (Convert.ToDouble(textBox17.Text) < 500 || Convert.ToDouble(textBox17.Text) > 200) ; else goto blad;
            
            return;
        blad: 
            {
                if (MessageBox.Show("Błąd pomiaru !!") == DialogResult.OK)
                {
                    Close();
                    return;
                }   
            }
        }

        private void button_cecha_6_Click(object sender, EventArgs e)
        {
            Point punkt = new Point();
            double max_dlugosc = 0;
            
            for (int x = bolce[0].X+20 ; x < 620; x++)
            {
                for (int y = bolce[0].Y-70; y < bolce[0].Y-10; y++)
                {
                    if (obraz.GetPixel(x, y).ToArgb() == Color.White.ToArgb() || obraz.GetPixel(x, y + 1).ToArgb() == Color.White.ToArgb() || obraz.GetPixel(x + 1, y + 1).ToArgb() == Color.White.ToArgb() || obraz.GetPixel(x - 1, y + 1).ToArgb() == Color.White.ToArgb())
                    {
                        if (x == bolce[0].X + 20 || y == bolce[0].Y - 70) continue; // unikniecie wtopienia sie w dlon

                        if ((int)max_dlugosc == 0) // 1. pomiar
                        {
                            punkt.X = x;
                            punkt.Y = y;
                            max_dlugosc = Math.Sqrt(Math.Pow((double)(x - bolce[0].X), 2.0) + Math.Pow((double)(y - bolce[0].Y), 2.0));
                            obraz.SetPixel(x, y, Color.Red);
                            y = bolce[0].Y + 50;
                        }
                        else
                        {
                            double temp = Math.Sqrt(Math.Pow((double)(x - bolce[0].X), 2.0) + Math.Pow((double)(y - bolce[0].Y), 2.0));
                            if (temp < max_dlugosc)
                            {
                                punkt.X = x;
                                punkt.Y = y;
                                max_dlugosc = temp;
                                obraz.SetPixel(x, y, Color.Red);
                                y = bolce[0].Y + 50;
                            }
                            else
                            {
                                y = bolce[0].Y + 50;
                            }
                        }
                    }
                    else obraz.SetPixel(x, y, Color.Coral);
                }
            }
            pioro.Color = Color.Blue;
            textBox7.Text = max_dlugosc.ToString();
            g.DrawLine(pioro, bolce[0], punkt);

            pictureBox1.Image = obraz;
            pictureBox1.Update();
        }

        private void button_cecha_7_Click(object sender, EventArgs e)
        {
            Point punkt = new Point();
            double max_dlugosc = 0;
            for (int y = bolce[2].Y - 40; y < bolce[2].Y + 20; y++)
            {
                for (int x = bolce[2].X + 120; x > bolce[2].X; x--)                
                {
                    if (obraz.GetPixel(x, y).ToArgb() == Color.White.ToArgb() || obraz.GetPixel(x, y + 1).ToArgb() == Color.White.ToArgb() || obraz.GetPixel(x + 1, y + 1).ToArgb() == Color.White.ToArgb() || obraz.GetPixel(x - 1, y + 1).ToArgb() == Color.White.ToArgb())
                    {
                        if ((int)max_dlugosc == 0)
                        {
                            punkt.X = x;
                            punkt.Y = y;
                            max_dlugosc = Math.Sqrt(Math.Pow((double)(x - bolce[2].X), 2.0) + Math.Pow((double)(y - bolce[2].Y), 2.0));
                            obraz.SetPixel(x, y, Color.Red);
                            x = bolce[2].X;
                        }
                        else
                        {
                            double temp = Math.Sqrt(Math.Pow((double)(x - bolce[2].X), 2.0) + Math.Pow((double)(y - bolce[2].Y), 2.0));
                            if (temp < max_dlugosc)
                            {
                                punkt.X = x;
                                punkt.Y = y;
                                max_dlugosc = temp;
                                obraz.SetPixel(x, y, Color.Red);
                                x = bolce[2].X;
                            }
                            else
                            {
                                x = bolce[2].X;
                            }
                        }
                    }
                    else obraz.SetPixel(x, y, Color.Coral);
                }
            }
            pioro.Color = Color.Blue;
            textBox8.Text = max_dlugosc.ToString();
            g.DrawLine(pioro, bolce[2], punkt);

            pictureBox1.Image = obraz;
            pictureBox1.Update();
        }

        private void button_cecha_8_Click(object sender, EventArgs e)
        {
            Point punkt = new Point();
            double max_dlugosc = 0;
            for (int x = bolce[1].X -40; x < bolce[1].X-30; x++)
            {
                for (int y = bolce[1].Y - 90; y < bolce[1].Y - 20; y++)
                {
                    if (obraz.GetPixel(x, y).ToArgb() == Color.White.ToArgb() || obraz.GetPixel(x, y + 1).ToArgb() == Color.White.ToArgb() || obraz.GetPixel(x + 1, y + 1).ToArgb() == Color.White.ToArgb() || obraz.GetPixel(x - 1, y + 1).ToArgb() == Color.White.ToArgb())
                    {
                        if ((int)max_dlugosc == 0)
                        {
                            punkt.X = x;
                            punkt.Y = y;
                            max_dlugosc = Math.Sqrt(Math.Pow((double)(x - bolce[1].X), 2.0) + Math.Pow((double)(y - bolce[1].Y), 2.0));
                            obraz.SetPixel(x, y, Color.Red);
                            y = bolce[1].Y;
                        }
                        else
                        {
                            double temp = Math.Sqrt(Math.Pow((double)(x - bolce[1].X), 2.0) + Math.Pow((double)(y - bolce[1].Y), 2.0));
                            if (temp < max_dlugosc)
                            {
                                punkt.X = x;
                                punkt.Y = y;
                                max_dlugosc = temp;
                                obraz.SetPixel(x, y, Color.Red);
                                y = bolce[1].Y;
                            }
                            else
                            {
                                y = bolce[1].Y;
                            }
                        }
                    }
                    else obraz.SetPixel(x, y, Color.Coral);
                }
            }
            pioro.Color = Color.Blue;
            textBox9.Text = max_dlugosc.ToString();
            g.DrawLine(pioro, bolce[1], punkt);

            pictureBox1.Image = obraz;
            pictureBox1.Update();
        }

        private void button_cecha_9_Click(object sender, EventArgs e)
        {
            Point punkt = new Point();
            double max_dlugosc = 0;
            for (int y = bolce[3].Y-15 ; y > bolce[3].Y - 45; y--)
            {
                for (int x = bolce[3].X - 100; x < bolce[3].X - 10; x++)
                {
                    if (obraz.GetPixel(x, y).ToArgb() == Color.White.ToArgb() || obraz.GetPixel(x, y + 1).ToArgb() == Color.White.ToArgb() || obraz.GetPixel(x + 1, y + 1).ToArgb() == Color.White.ToArgb() || obraz.GetPixel(x - 1, y + 1).ToArgb() == Color.White.ToArgb())
                    {
                        if ((int)max_dlugosc == 0)
                        {
                            punkt.X = x;
                            punkt.Y = y;
                            max_dlugosc = Math.Sqrt(Math.Pow((double)(x - bolce[3].X), 2.0) + Math.Pow((double)(y - bolce[3].Y), 2.0));
                            obraz.SetPixel(x, y, Color.Red);
                            x = bolce[3].X;
                        }
                        else
                        {
                            double temp = Math.Sqrt(Math.Pow((double)(x - bolce[3].X), 2.0) + Math.Pow((double)(y - bolce[3].Y), 2.0));
                            if (temp < max_dlugosc)
                            {
                                punkt.X = x;
                                punkt.Y = y;
                                max_dlugosc = temp;
                                obraz.SetPixel(x, y, Color.Red);
                                x = bolce[3].X;
                            }
                            else
                            {
                                x = bolce[3].X;
                            }
                        }
                    }
                    else obraz.SetPixel(x, y, Color.Coral);
                }
            }
            pioro.Color = Color.Blue;
            textBox10.Text = max_dlugosc.ToString();
            g.DrawLine(pioro, bolce[3], punkt);

            pictureBox1.Image = obraz;
            pictureBox1.Update();
        }

        private void button_cecha_10_Click(object sender, EventArgs e)
        {
            Point punkt = new Point();
            double max_dlugosc = 0;
            for (int x = bolce[3].X; x > bolce[3].X - 15; x--)
            {
                for (int y = bolce[3].Y+60; y > bolce[3].Y +30; y--)
                {
                    if (obraz.GetPixel(x, y).ToArgb() == Color.White.ToArgb() || obraz.GetPixel(x, y + 1).ToArgb() == Color.White.ToArgb() || obraz.GetPixel(x + 1, y + 1).ToArgb() == Color.White.ToArgb() || obraz.GetPixel(x - 1, y + 1).ToArgb() == Color.White.ToArgb())
                    {
                        if ((int)max_dlugosc == 0)
                        {
                            punkt.X = x;
                            punkt.Y = y;
                            max_dlugosc = Math.Sqrt(Math.Pow((double)(x - bolce[3].X), 2.0) + Math.Pow((double)(y - bolce[3].Y), 2.0));
                            obraz.SetPixel(x, y, Color.Red);
                            y = bolce[3].Y;
                        }
                        else
                        {
                            double temp = Math.Sqrt(Math.Pow((double)(x - bolce[3].X), 2.0) + Math.Pow((double)(y - bolce[3].Y), 2.0));
                            if (temp < max_dlugosc)
                            {
                                punkt.X = x;
                                punkt.Y = y;
                                max_dlugosc = temp;
                                obraz.SetPixel(x, y, Color.Red);
                                y = bolce[3].Y;
                            }
                            else
                            {
                                y = bolce[3].Y;
                            }
                        }
                    }
                    else obraz.SetPixel(x, y, Color.Coral);
                }
            }

            // 2. punkt :

            Point punkt2 = punkt;
            max_dlugosc = 0;
            for (int y = punkt2.Y -20; y > punkt2.Y - 60; y--) 
            {
                for (int x = punkt2.X - 100; x < punkt2.X ; x++)
                {
                    if (obraz.GetPixel(x, y).ToArgb() == Color.White.ToArgb() || obraz.GetPixel(x, y + 1).ToArgb() == Color.White.ToArgb() || obraz.GetPixel(x + 1, y + 1).ToArgb() == Color.White.ToArgb() || obraz.GetPixel(x - 1, y + 1).ToArgb() == Color.White.ToArgb())
                    {
                        if ((int)max_dlugosc == 0)
                        {
                            punkt.X = x;
                            punkt.Y = y;
                            max_dlugosc = Math.Sqrt(Math.Pow((double)(x - punkt2.X), 2.0) + Math.Pow((double)(y - punkt2.Y), 2.0));
                            obraz.SetPixel(x, y, Color.Red);
                            x = punkt2.X;
                        }
                        else
                        {
                            double temp = Math.Sqrt(Math.Pow((double)(x - punkt2.X), 2.0) + Math.Pow((double)(y - punkt2.Y), 2.0));
                            if (temp < max_dlugosc)
                            {
                                punkt.X = x;
                                punkt.Y = y;
                                max_dlugosc = temp;
                                obraz.SetPixel(x, y, Color.Red);
                                x = punkt2.X;
                            }
                            else
                            {
                                x = punkt2.X;
                            }
                        }
                    }
                    else obraz.SetPixel(x, y, Color.Coral);
                }
            }
            pioro.Color = Color.Blue;
            textBox11.Text = max_dlugosc.ToString();
            g.DrawLine(pioro, punkt, punkt2);

            pictureBox1.Image = obraz;
            pictureBox1.Update();
        }

        private void button_cecha_11_Click(object sender, EventArgs e)
        {
            Point punkt = new Point();
            double max_dlugosc = 0;
            for (int x = bolce[5].X - 10; x > bolce[5].X - 15; x--)
            {
                for (int y = bolce[5].Y + 60; y > bolce[5].Y + 30; y--)
                {
                    if (obraz.GetPixel(x, y).ToArgb() == Color.White.ToArgb() || obraz.GetPixel(x, y + 1).ToArgb() == Color.White.ToArgb() || obraz.GetPixel(x + 1, y + 1).ToArgb() == Color.White.ToArgb() || obraz.GetPixel(x - 1, y + 1).ToArgb() == Color.White.ToArgb())
                    {
                        if ((int)max_dlugosc == 0)
                        {
                            punkt.X = x;
                            punkt.Y = y;
                            max_dlugosc = Math.Sqrt(Math.Pow((double)(x - bolce[5].X), 2.0) + Math.Pow((double)(y - bolce[5].Y), 2.0));
                            obraz.SetPixel(x, y, Color.Red);
                            y = bolce[5].Y;
                        }
                        else
                        {
                            double temp = Math.Sqrt(Math.Pow((double)(x - bolce[5].X), 2.0) + Math.Pow((double)(y - bolce[5].Y), 2.0));
                            if (temp < max_dlugosc)
                            {
                                punkt.X = x;
                                punkt.Y = y;
                                max_dlugosc = temp;
                                obraz.SetPixel(x, y, Color.Red);
                                y = bolce[5].Y;
                            }
                            else
                            {
                                y = bolce[5].Y;
                            }
                        }
                    }
                    else obraz.SetPixel(x, y, Color.Coral);
                }
            }

            // 2. punkt :

            Point punkt2 = punkt;
            max_dlugosc = 0;
            for (int y = punkt2.Y - 10; y > punkt2.Y - 50; y--)
            {
                for (int x = punkt2.X - 100; x < punkt2.X; x++)
                {
                    if (obraz.GetPixel(x, y).ToArgb() == Color.White.ToArgb() || obraz.GetPixel(x, y + 1).ToArgb() == Color.White.ToArgb() || obraz.GetPixel(x + 1, y + 1).ToArgb() == Color.White.ToArgb() || obraz.GetPixel(x - 1, y + 1).ToArgb() == Color.White.ToArgb())
                    {
                        if ((int)max_dlugosc == 0)
                        {
                            punkt.X = x;
                            punkt.Y = y;
                            max_dlugosc = Math.Sqrt(Math.Pow((double)(x - punkt2.X), 2.0) + Math.Pow((double)(y - punkt2.Y), 2.0));
                            obraz.SetPixel(x, y, Color.Red);
                            x = punkt2.X;
                        }
                        else
                        {
                            double temp = Math.Sqrt(Math.Pow((double)(x - punkt2.X), 2.0) + Math.Pow((double)(y - punkt2.Y), 2.0));
                            if (temp < max_dlugosc)
                            {
                                punkt.X = x;
                                punkt.Y = y;
                                max_dlugosc = temp;
                                obraz.SetPixel(x, y, Color.Red);
                                x = punkt2.X;
                            }
                            else
                            {
                                x = punkt2.X;
                            }
                        }
                    }
                    else obraz.SetPixel(x, y, Color.Coral);
                }
            }
            pioro.Color = Color.Blue;
            textBox12.Text = max_dlugosc.ToString();
            g.DrawLine(pioro, punkt, punkt2);

            pictureBox1.Image = obraz;
            pictureBox1.Update();
        }

        private void button_cecha_12_Click(object sender, EventArgs e)
        {
            Point punkt = new Point();
            double max_dlugosc = 0;
            for (int y = bolce[4].Y + 70; y > bolce[4].Y + 50; y--)
            {
                for (int x = bolce[4].X - 10; x > bolce[4].X - 50; x--)
                {
                    if (obraz.GetPixel(x, y).ToArgb() == Color.White.ToArgb() || obraz.GetPixel(x, y + 1).ToArgb() == Color.White.ToArgb() || obraz.GetPixel(x + 1, y + 1).ToArgb() == Color.White.ToArgb() || obraz.GetPixel(x - 1, y + 1).ToArgb() == Color.White.ToArgb())
                    {
                        if ((int)max_dlugosc == 0)
                        {
                            punkt.X = x;
                            punkt.Y = y;
                            max_dlugosc = Math.Sqrt(Math.Pow((double)(x - bolce[4].X), 2.0) + Math.Pow((double)(y - bolce[4].Y), 2.0));
                            obraz.SetPixel(x, y, Color.Red);
                            x = bolce[4].X - 50;
                        }
                        else
                        {
                            double temp = Math.Sqrt(Math.Pow((double)(x - bolce[4].X), 2.0) + Math.Pow((double)(y - bolce[4].Y), 2.0));
                            if (temp < max_dlugosc)
                            {
                                punkt.X = x;
                                punkt.Y = y;
                                max_dlugosc = temp;
                                obraz.SetPixel(x, y, Color.Red);
                                x = bolce[4].X - 50;
                            }
                            else
                            {
                                x = bolce[4].X - 50;
                            }
                        }
                    }
                    else obraz.SetPixel(x, y, Color.Coral);
                }
            }

            // 2. punkt :

            Point punkt2 = punkt;
            max_dlugosc = 0;
            for (int y = punkt2.Y - 10 ; y < punkt2.Y + 20; y++)
            {
                for (int x = punkt2.X - 80; x < punkt2.X; x++)
                {
                    if (obraz.GetPixel(x, y).ToArgb() == Color.White.ToArgb() || obraz.GetPixel(x, y + 1).ToArgb() == Color.White.ToArgb() || obraz.GetPixel(x + 1, y + 1).ToArgb() == Color.White.ToArgb() || obraz.GetPixel(x - 1, y + 1).ToArgb() == Color.White.ToArgb())
                    {
                        if ((int)max_dlugosc == 0)
                        {
                            punkt.X = x;
                            punkt.Y = y;
                            max_dlugosc = Math.Sqrt(Math.Pow((double)(x - punkt2.X), 2.0) + Math.Pow((double)(y - punkt2.Y), 2.0));
                            obraz.SetPixel(x, y, Color.Red);
                            x = punkt2.X;
                        }
                        else
                        {
                            double temp = Math.Sqrt(Math.Pow((double)(x - punkt2.X), 2.0) + Math.Pow((double)(y - punkt2.Y), 2.0));
                            if (temp < max_dlugosc)
                            {
                                punkt.X = x;
                                punkt.Y = y;
                                max_dlugosc = temp;
                                obraz.SetPixel(x, y, Color.Red);
                                x = punkt2.X;
                            }
                            else
                            {
                                x = punkt2.X;
                            }
                        }
                    }
                    else obraz.SetPixel(x, y, Color.Coral);
                }
            }
            pioro.Color = Color.Blue;
            textBox13.Text = max_dlugosc.ToString();
            g.DrawLine(pioro, punkt, punkt2);

            pictureBox1.Image = obraz;
            pictureBox1.Update();
        }

        private void button_cecha_13_Click(object sender, EventArgs e)
        {
            Point punkt = new Point();
            double max_dlugosc = 0;
            for (int x = bolce[4].X + 20; x > bolce[4].X-20; x--)
            {
                for (int y = bolce[2].Y; y > 50; y--)
                {
                    if (obraz.GetPixel(x, y).ToArgb() == Color.White.ToArgb() || obraz.GetPixel(x, y + 1).ToArgb() == Color.White.ToArgb() || obraz.GetPixel(x + 1, y + 1).ToArgb() == Color.White.ToArgb() || obraz.GetPixel(x - 1, y + 1).ToArgb() == Color.White.ToArgb())
                    {
                        if ((int)max_dlugosc == 0)
                        {
                            punkt.X = x;
                            punkt.Y = y;
                            max_dlugosc = y;
                            obraz.SetPixel(x, y, Color.Red);
                            y = 50;
                        }
                        else
                        {
                            double temp = y;
                            if (temp < max_dlugosc)
                            {
                                punkt.X = x;
                                punkt.Y = y;
                                max_dlugosc = temp;
                                obraz.SetPixel(x, y, Color.Red);
                                y = 50;
                            }
                            else
                            {
                                y = 50;
                            }
                        }
                    }
                    else obraz.SetPixel(x, y, Color.Coral);
                }
            }

            // 2. punkt :

            Point punkt2 = punkt;
            max_dlugosc = 0;
            for (int y = 20; y < 50; y++)
            {
                for (int x = 600; x > punkt2.X; x--)
                {
                    if (obraz.GetPixel(x, y).ToArgb() == Color.White.ToArgb() || obraz.GetPixel(x, y + 1).ToArgb() == Color.White.ToArgb() || obraz.GetPixel(x + 1, y + 1).ToArgb() == Color.White.ToArgb() || obraz.GetPixel(x - 1, y + 1).ToArgb() == Color.White.ToArgb())
                    {
                        if ((int)max_dlugosc == 0)
                        {
                            punkt.X = x;
                            punkt.Y = y;
                            max_dlugosc = Math.Sqrt(Math.Pow((double)(x - punkt2.X), 2.0) + Math.Pow((double)(y - punkt2.Y), 2.0));
                            obraz.SetPixel(x, y, Color.Red);
                            x = punkt2.X;
                        }
                        else
                        {
                            double temp = Math.Sqrt(Math.Pow((double)(x - punkt2.X), 2.0) + Math.Pow((double)(y - punkt2.Y), 2.0));
                            if (temp < max_dlugosc)
                            {
                                punkt.X = x;
                                punkt.Y = y;
                                max_dlugosc = temp;
                                obraz.SetPixel(x, y, Color.Red);
                                x = punkt2.X;
                            }
                            else
                            {
                                x = punkt2.X;
                            }
                        }
                    }
                    else obraz.SetPixel(x, y, Color.Coral);
                }
            }
            pioro.Color = Color.Blue;
            textBox14.Text = max_dlugosc.ToString();
            g.DrawLine(pioro, punkt, punkt2);

            // ustalenie kostek :
            kostki[4].X = (punkt.X + punkt2.X) / 2; 
            kostki[4].Y = (punkt.Y + punkt2.Y) / 2;

            g.FillEllipse(pioro.Brush, kostki[4].X - 10, kostki[4].Y - 10, 20, 20);

            pictureBox1.Image = obraz;
            pictureBox1.Update();
        }

        private void button_cecha_14_Click(object sender, EventArgs e)
        {
            Point punkt = new Point();
            double max_dlugosc = 0;
            for (int x = 638; x > bolce[0].X; --x)
            {
                for (int y = bolce[0].Y+80; y > bolce[0].Y+10 ; y--)
                {
                    if (obraz.GetPixel(x, y).ToArgb() == Color.White.ToArgb() || obraz.GetPixel(x + 1, y - 1).ToArgb() == Color.White.ToArgb() || obraz.GetPixel(x - 1, y - 1).ToArgb() == Color.White.ToArgb())
                    {
                        if ((int)max_dlugosc == 0)
                        {
                            punkt.X = x;
                            punkt.Y = y;
                            max_dlugosc = Math.Sqrt(Math.Pow((double)(punkt.X - kostki[4].X), 2.0) + Math.Pow((double)(punkt.Y - kostki[4].Y), 2.0));
                            y = 0;
                        }
                        else
                        {
                            double temp = Math.Sqrt(Math.Pow((double)(x - kostki[4].X), 2.0) + Math.Pow((double)(y - kostki[4].Y), 2.0));
                            if (temp > max_dlugosc)
                            {
                                punkt.X = x;
                                punkt.Y = y;
                                max_dlugosc = temp;
                                y = 0;
                            }
                            else
                            {
                                y = 0;
                            }
                        }
                    }
                    else obraz.SetPixel(x, y, Color.Coral);
                }
            }

            textBox15.Text = max_dlugosc.ToString();
            g.DrawLine(pioro, kostki[4], punkt);


            pictureBox1.Image = obraz;
            pictureBox1.Update();
        }

        private void button_cecha_15_Click(object sender, EventArgs e)
        {
            Point punkt = new Point();
            double max_dlugosc = 0;
            for (int x = bolce[1].X ; x > bolce[1].X - 25 ; x--)
            {
                for (int y = bolce[1].Y + 70; y > bolce[1].Y + 30; y--)
                {
                    if (obraz.GetPixel(x, y).ToArgb() == Color.White.ToArgb() || obraz.GetPixel(x, y + 1).ToArgb() == Color.White.ToArgb() || obraz.GetPixel(x + 1, y + 1).ToArgb() == Color.White.ToArgb() || obraz.GetPixel(x - 1, y + 1).ToArgb() == Color.White.ToArgb())
                    {
                        if ((int)max_dlugosc == 0)
                        {
                            punkt.X = x;
                            punkt.Y = y;
                            max_dlugosc = Math.Sqrt(Math.Pow((double)(x - bolce[1].X), 2.0) + Math.Pow((double)(y - bolce[1].Y), 2.0));
                            obraz.SetPixel(x, y, Color.Red);
                            y = bolce[1].Y;
                        }
                        else
                        {
                            double temp = Math.Sqrt(Math.Pow((double)(x - bolce[1].X), 2.0) + Math.Pow((double)(y - bolce[1].Y), 2.0));
                            if (temp > max_dlugosc)
                            {
                                punkt.X = x;
                                punkt.Y = y;
                                max_dlugosc = temp;
                                obraz.SetPixel(x, y, Color.Red);
                                y = bolce[1].Y;
                            }
                            else
                            {
                                y = bolce[1].Y;
                            }
                        }
                    }
                    else obraz.SetPixel(x, y, Color.Coral);
                }
            }

            // 2. punkt :

            Point punkt2 = punkt;
            max_dlugosc = 0;
            for (int y = punkt2.Y - 33; y > punkt2.Y - 50; y--)
            {
                for (int x = 1; x < punkt2.X; x++)
                {
                    if (obraz.GetPixel(x, y).ToArgb() == Color.White.ToArgb() || obraz.GetPixel(x, y + 1).ToArgb() == Color.White.ToArgb() || obraz.GetPixel(x + 1, y + 1).ToArgb() == Color.White.ToArgb() || obraz.GetPixel(x - 1, y + 1).ToArgb() == Color.White.ToArgb())
                    {
                        if ((int)max_dlugosc == 0)
                        {
                            punkt.X = x;
                            punkt.Y = y;
                            max_dlugosc = Math.Sqrt(Math.Pow((double)(x - punkt2.X), 2.0) + Math.Pow((double)(y - punkt2.Y), 2.0));
                            obraz.SetPixel(x, y, Color.Red);
                            x = punkt2.X;
                        }
                        else
                        {
                            double temp = Math.Sqrt(Math.Pow((double)(x - punkt2.X), 2.0) + Math.Pow((double)(y - punkt2.Y), 2.0));
                            if (temp < max_dlugosc)
                            {
                                punkt.X = x;
                                punkt.Y = y;
                                max_dlugosc = temp;
                                obraz.SetPixel(x, y, Color.Red);
                                x = punkt2.X;
                            }
                            else
                            {
                                x = punkt2.X;
                            }
                        }
                    }
                    else obraz.SetPixel(x, y, Color.Coral);
                }
            }
            pioro.Color = Color.Blue;
            textBox16.Text = max_dlugosc.ToString();
            g.DrawLine(pioro, punkt, punkt2);

            pictureBox1.Image = obraz;
            pictureBox1.Update();
        }

        private void button_cecha_16_Click(object sender, EventArgs e)
        {
            Point punkt = new Point();
            double max_dlugosc = 0;

            for (int y = kostki[4].Y - 30; y < kostki[4].Y + 30; y++)
            {
                for (int x = 1; x < 320; x++)
                {
                    if (obraz.GetPixel(x, y).ToArgb() == Color.White.ToArgb() || obraz.GetPixel(x, y + 1).ToArgb() == Color.White.ToArgb() || obraz.GetPixel(x + 1, y + 1).ToArgb() == Color.White.ToArgb() || obraz.GetPixel(x - 1, y + 1).ToArgb() == Color.White.ToArgb())
                    {
                        if ((int)max_dlugosc == 0) // 1. pomiar
                        {
                            punkt.X = x;
                            punkt.Y = y;
                            max_dlugosc = Math.Sqrt(Math.Pow((double)(x - kostki[4].X), 2.0) + Math.Pow((double)(y - kostki[4].Y), 2.0));
                            obraz.SetPixel(x, y, Color.Red);
                            x = 450;
                        }
                        else
                        {
                            double temp = Math.Sqrt(Math.Pow((double)(x - kostki[4].X), 2.0) + Math.Pow((double)(y - kostki[4].Y), 2.0));
                            if (temp < max_dlugosc)
                            {
                                punkt.X = x;
                                punkt.Y = y;
                                max_dlugosc = temp;
                                obraz.SetPixel(x, y, Color.Red);
                                x = 450;
                            }
                            else
                            {
                                x = 450;
                            }
                        }
                    }
                    else obraz.SetPixel(x, y, Color.Coral);
                }
            }
            pioro.Color = Color.Blue;
            textBox17.Text = max_dlugosc.ToString();
            g.DrawLine(pioro, kostki[4], punkt);

            pictureBox1.Image = obraz;
            pictureBox1.Update();
        }
    }
    // zmiana 8!

}


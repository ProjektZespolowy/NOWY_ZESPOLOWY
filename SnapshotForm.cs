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

namespace Snapshot_Maker
{
    public partial class SnapshotForm : Form
    {
        static Bitmap obraz_oryginal;
        static Bitmap obraz_w_greyscale;
        static Bitmap obraz_po_progowaniu;

        static List<PointF> wsporzedne_punktow;
        public SnapshotForm( )
        {
            InitializeComponent( );
            textBox1.Text = "100";
            textBox2.Text = "600";
            wsporzedne_punktow = new List<PointF>();
        }

        public void SetImage( Bitmap bitmap )
        {
            Bitmap old = (Bitmap) pictureBox.Image;
            
            obraz_oryginal = bitmap;
            Grayscale filtr_szarosci = new Grayscale(0.2125, 0.7154, 0.0721);
            obraz_w_greyscale = (Bitmap)filtr_szarosci.Apply(obraz_oryginal);

            pictureBox.Image = obraz_w_greyscale;

            if ( old != null )
            {
                old.Dispose( );
            }

            button_threshold_Click(null, null);
        }

        private void button_threshold_Click(object sender, EventArgs e)
        {
            if (obraz_w_greyscale != null)
            {
                if (textBox1.TextLength != 0)
                {
                    int prog = Convert.ToInt32(textBox1.Text);
                    Threshold binearyzacja = new Threshold(prog);
                    obraz_po_progowaniu = (Bitmap)binearyzacja.Apply(obraz_w_greyscale);

                    Invert odwracanie = new Invert();
                    obraz_po_progowaniu = odwracanie.Apply(obraz_po_progowaniu);


                    AForge.Imaging.Filters.Closing zamykanie = new AForge.Imaging.Filters.Closing();
                    obraz_po_progowaniu = zamykanie.Apply(obraz_po_progowaniu);

                    pictureBox1.Image = obraz_po_progowaniu;
                    pictureBox1.Update();
                }

                button_area_Click(null, null);
            }
        }

        private void button_area_Click(object sender, EventArgs e)
        {
            if (obraz_po_progowaniu != null)
            {
                if (textBox2.TextLength != 0)
                {
                    BlobCounter znajdywanie = new BlobCounter();
                    
                    znajdywanie.ProcessImage(obraz_po_progowaniu);
                    Blob[] objekty = znajdywanie.GetObjectsInformation();

                    foreach (Blob objekt in objekty)
                    {
                        
                        PointF punkt = new Point();
                        Pen pioro = new Pen(Color.Red);
                        Graphics g = Graphics.FromImage(obraz_oryginal);
                        int r = (int)Math.Sqrt((double)(objekt.Area / 3.14));
                        if (objekt.Area > Convert.ToInt32(textBox2.Text))
                        {
                            g.FillEllipse(pioro.Brush, objekt.CenterOfGravity.X, objekt.CenterOfGravity.Y, 20, 20);
                            punkt.X = objekt.CenterOfGravity.X;
                            punkt.Y = objekt.CenterOfGravity.Y;
                            wsporzedne_punktow.Add(punkt);
                        }
                    }
                    pictureBox2.Image = obraz_oryginal;
                    pictureBox2.Update();

                    button1_Click(null, null);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // SPRAWDZENIE POPRAWNOŚCI KALIBRACJI :
            if (wsporzedne_punktow.Count != 6 || 
                wsporzedne_punktow[0].X <400 ||
                wsporzedne_punktow[4].X < wsporzedne_punktow[5].X ||
                wsporzedne_punktow[3].X > wsporzedne_punktow[4].X ||
                wsporzedne_punktow[1].X > wsporzedne_punktow[2].X
               )
            {
                if (MessageBox.Show("Kalibracja nie przebiegła prawidłowo :( ") == DialogResult.OK)
                {
                    obraz_oryginal.Dispose();
                    obraz_po_progowaniu.Dispose();
                    obraz_w_greyscale.Dispose();
                    Close();
                    return;
                }
            }
            /// koniec sprawdzania
            
            FileStream plik = new FileStream("bolce.txt", FileMode.Create, FileAccess.Write);
            StringReader czytacz = new StringReader(plik.ToString());

            StreamWriter zapisuj = new StreamWriter(plik);
            foreach(PointF dana in wsporzedne_punktow)
            {
                zapisuj.Write(((int)dana.X).ToString()+ Environment.NewLine);
                zapisuj.Write(((int)dana.Y).ToString() + Environment.NewLine);
            }
            zapisuj.Close();
            plik.Close();

            

            if (MessageBox.Show("Kalibracja przebiegła prawidłowo !") == DialogResult.OK)
            {
                obraz_oryginal.Dispose();
                obraz_po_progowaniu.Dispose();
                obraz_w_greyscale.Dispose();
                Close();
            }
        }
    }
}

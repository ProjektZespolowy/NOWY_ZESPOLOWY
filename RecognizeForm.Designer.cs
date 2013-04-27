namespace Snapshot_Maker
{
    partial class RecognizeForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button_save = new System.Windows.Forms.Button();
            this.button_load = new System.Windows.Forms.Button();
            this.button_canny = new System.Windows.Forms.Button();
            this.button_gray = new System.Windows.Forms.Button();
            this.button_threshold = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.button_filter = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.button10 = new System.Windows.Forms.Button();
            this.button_cecha_1 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.button_cecha_2 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button_cecha_3 = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.button_cecha_4 = new System.Windows.Forms.Button();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.button_cecha_5 = new System.Windows.Forms.Button();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.button_calculate = new System.Windows.Forms.Button();
            this.button_cecha_6 = new System.Windows.Forms.Button();
            this.button_cecha_7 = new System.Windows.Forms.Button();
            this.button_cecha_8 = new System.Windows.Forms.Button();
            this.button_cecha_9 = new System.Windows.Forms.Button();
            this.button_cecha_10 = new System.Windows.Forms.Button();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.button_cecha_11 = new System.Windows.Forms.Button();
            this.button_cecha_12 = new System.Windows.Forms.Button();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.button_cecha_13 = new System.Windows.Forms.Button();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.button_cecha_14 = new System.Windows.Forms.Button();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.button_cecha_15 = new System.Windows.Forms.Button();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.button_cecha_16 = new System.Windows.Forms.Button();
            this.textBox17 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 102);
            this.textBox1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(119, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(640, 480);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // button_save
            // 
            this.button_save.Location = new System.Drawing.Point(14, 469);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(99, 23);
            this.button_save.TabIndex = 6;
            this.button_save.Text = "&Zapisz";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // button_load
            // 
            this.button_load.Location = new System.Drawing.Point(14, 440);
            this.button_load.Name = "button_load";
            this.button_load.Size = new System.Drawing.Size(99, 23);
            this.button_load.TabIndex = 7;
            this.button_load.Text = "&Wczytaj";
            this.button_load.UseVisualStyleBackColor = true;
            this.button_load.Click += new System.EventHandler(this.button4_Click);
            // 
            // button_canny
            // 
            this.button_canny.Location = new System.Drawing.Point(765, 91);
            this.button_canny.Name = "button_canny";
            this.button_canny.Size = new System.Drawing.Size(243, 23);
            this.button_canny.TabIndex = 8;
            this.button_canny.Text = "&Krawędzie";
            this.button_canny.UseVisualStyleBackColor = true;
            this.button_canny.Click += new System.EventHandler(this.button_canny_Click);
            // 
            // button_gray
            // 
            this.button_gray.Location = new System.Drawing.Point(765, 12);
            this.button_gray.Name = "button_gray";
            this.button_gray.Size = new System.Drawing.Size(243, 23);
            this.button_gray.TabIndex = 9;
            this.button_gray.Text = "&Grayscale";
            this.button_gray.UseVisualStyleBackColor = true;
            this.button_gray.Click += new System.EventHandler(this.button_gray_Click);
            // 
            // button_threshold
            // 
            this.button_threshold.Location = new System.Drawing.Point(765, 67);
            this.button_threshold.Name = "button_threshold";
            this.button_threshold.Size = new System.Drawing.Size(243, 23);
            this.button_threshold.TabIndex = 11;
            this.button_threshold.Text = "&Progowanie";
            this.button_threshold.UseVisualStyleBackColor = true;
            this.button_threshold.Click += new System.EventHandler(this.button_threshold_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(765, 41);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(243, 20);
            this.numericUpDown1.TabIndex = 12;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // button_filter
            // 
            this.button_filter.Location = new System.Drawing.Point(766, 121);
            this.button_filter.Name = "button_filter";
            this.button_filter.Size = new System.Drawing.Size(242, 23);
            this.button_filter.TabIndex = 15;
            this.button_filter.Text = "Filtr koloru";
            this.button_filter.UseVisualStyleBackColor = true;
            this.button_filter.Click += new System.EventHandler(this.button_filter_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(766, 150);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 19;
            this.button4.Text = "Otwieranie";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click_1);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(847, 150);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 20;
            this.button5.Text = "Zamykanie";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(928, 150);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 21;
            this.button6.Text = "Invert";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(766, 179);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(75, 23);
            this.button7.TabIndex = 22;
            this.button7.Text = "Erozja";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(847, 179);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(75, 23);
            this.button8.TabIndex = 23;
            this.button8.Text = "Dylatacja";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(928, 179);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(75, 23);
            this.button9.TabIndex = 24;
            this.button9.Text = "male obiekty";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // button10
            // 
            this.button10.Location = new System.Drawing.Point(766, 242);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(75, 23);
            this.button10.TabIndex = 25;
            this.button10.Text = "wczytanie";
            this.button10.UseVisualStyleBackColor = true;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // button_cecha_1
            // 
            this.button_cecha_1.Location = new System.Drawing.Point(766, 270);
            this.button_cecha_1.Name = "button_cecha_1";
            this.button_cecha_1.Size = new System.Drawing.Size(75, 23);
            this.button_cecha_1.TabIndex = 26;
            this.button_cecha_1.Text = "Cecha 1";
            this.button_cecha_1.UseVisualStyleBackColor = true;
            this.button_cecha_1.Click += new System.EventHandler(this.button_cecha_1_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(847, 275);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(156, 20);
            this.textBox3.TabIndex = 27;
            // 
            // button_cecha_2
            // 
            this.button_cecha_2.Location = new System.Drawing.Point(765, 298);
            this.button_cecha_2.Name = "button_cecha_2";
            this.button_cecha_2.Size = new System.Drawing.Size(75, 23);
            this.button_cecha_2.TabIndex = 28;
            this.button_cecha_2.Text = "Cecha 2";
            this.button_cecha_2.UseVisualStyleBackColor = true;
            this.button_cecha_2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(847, 302);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(156, 20);
            this.textBox2.TabIndex = 29;
            // 
            // button_cecha_3
            // 
            this.button_cecha_3.Location = new System.Drawing.Point(766, 326);
            this.button_cecha_3.Name = "button_cecha_3";
            this.button_cecha_3.Size = new System.Drawing.Size(75, 23);
            this.button_cecha_3.TabIndex = 30;
            this.button_cecha_3.Text = "Cecha 3";
            this.button_cecha_3.UseVisualStyleBackColor = true;
            this.button_cecha_3.Click += new System.EventHandler(this.button_cecha_3_Click);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(847, 329);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(156, 20);
            this.textBox4.TabIndex = 31;
            // 
            // button_cecha_4
            // 
            this.button_cecha_4.Location = new System.Drawing.Point(766, 354);
            this.button_cecha_4.Name = "button_cecha_4";
            this.button_cecha_4.Size = new System.Drawing.Size(75, 23);
            this.button_cecha_4.TabIndex = 32;
            this.button_cecha_4.Text = "Cecha 4";
            this.button_cecha_4.UseVisualStyleBackColor = true;
            this.button_cecha_4.Click += new System.EventHandler(this.button_cecha_4_Click);
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(847, 356);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(156, 20);
            this.textBox5.TabIndex = 33;
            // 
            // button_cecha_5
            // 
            this.button_cecha_5.Location = new System.Drawing.Point(765, 382);
            this.button_cecha_5.Name = "button_cecha_5";
            this.button_cecha_5.Size = new System.Drawing.Size(75, 23);
            this.button_cecha_5.TabIndex = 34;
            this.button_cecha_5.Text = "Cecha 5";
            this.button_cecha_5.UseVisualStyleBackColor = true;
            this.button_cecha_5.Click += new System.EventHandler(this.button_cecha_5_Click);
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(847, 385);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(156, 20);
            this.textBox6.TabIndex = 35;
            // 
            // button_calculate
            // 
            this.button_calculate.Location = new System.Drawing.Point(847, 242);
            this.button_calculate.Name = "button_calculate";
            this.button_calculate.Size = new System.Drawing.Size(398, 23);
            this.button_calculate.TabIndex = 36;
            this.button_calculate.Text = "&Oblicz";
            this.button_calculate.UseVisualStyleBackColor = true;
            this.button_calculate.Click += new System.EventHandler(this.button_show_off_Click);
            // 
            // button_cecha_6
            // 
            this.button_cecha_6.Location = new System.Drawing.Point(764, 409);
            this.button_cecha_6.Name = "button_cecha_6";
            this.button_cecha_6.Size = new System.Drawing.Size(75, 23);
            this.button_cecha_6.TabIndex = 37;
            this.button_cecha_6.Text = "Cecha 6";
            this.button_cecha_6.UseVisualStyleBackColor = true;
            this.button_cecha_6.Click += new System.EventHandler(this.button_cecha_6_Click);
            // 
            // button_cecha_7
            // 
            this.button_cecha_7.Location = new System.Drawing.Point(764, 438);
            this.button_cecha_7.Name = "button_cecha_7";
            this.button_cecha_7.Size = new System.Drawing.Size(75, 23);
            this.button_cecha_7.TabIndex = 38;
            this.button_cecha_7.Text = "Cecha 7";
            this.button_cecha_7.UseVisualStyleBackColor = true;
            this.button_cecha_7.Click += new System.EventHandler(this.button_cecha_7_Click);
            // 
            // button_cecha_8
            // 
            this.button_cecha_8.Location = new System.Drawing.Point(764, 464);
            this.button_cecha_8.Name = "button_cecha_8";
            this.button_cecha_8.Size = new System.Drawing.Size(75, 23);
            this.button_cecha_8.TabIndex = 39;
            this.button_cecha_8.Text = "Cecha 8";
            this.button_cecha_8.UseVisualStyleBackColor = true;
            this.button_cecha_8.Click += new System.EventHandler(this.button_cecha_8_Click);
            // 
            // button_cecha_9
            // 
            this.button_cecha_9.Location = new System.Drawing.Point(1009, 273);
            this.button_cecha_9.Name = "button_cecha_9";
            this.button_cecha_9.Size = new System.Drawing.Size(75, 23);
            this.button_cecha_9.TabIndex = 40;
            this.button_cecha_9.Text = "Cecha 9";
            this.button_cecha_9.UseVisualStyleBackColor = true;
            this.button_cecha_9.Click += new System.EventHandler(this.button_cecha_9_Click);
            // 
            // button_cecha_10
            // 
            this.button_cecha_10.Location = new System.Drawing.Point(1009, 299);
            this.button_cecha_10.Name = "button_cecha_10";
            this.button_cecha_10.Size = new System.Drawing.Size(75, 23);
            this.button_cecha_10.TabIndex = 41;
            this.button_cecha_10.Text = "Cecha 10";
            this.button_cecha_10.UseVisualStyleBackColor = true;
            this.button_cecha_10.Click += new System.EventHandler(this.button_cecha_10_Click);
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(846, 411);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(156, 20);
            this.textBox7.TabIndex = 42;
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(846, 438);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(156, 20);
            this.textBox8.TabIndex = 43;
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(846, 465);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(156, 20);
            this.textBox9.TabIndex = 44;
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(1091, 275);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(156, 20);
            this.textBox10.TabIndex = 45;
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(1091, 302);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(156, 20);
            this.textBox11.TabIndex = 46;
            // 
            // button_cecha_11
            // 
            this.button_cecha_11.Location = new System.Drawing.Point(1009, 325);
            this.button_cecha_11.Name = "button_cecha_11";
            this.button_cecha_11.Size = new System.Drawing.Size(75, 23);
            this.button_cecha_11.TabIndex = 47;
            this.button_cecha_11.Text = "Cecha 11";
            this.button_cecha_11.UseVisualStyleBackColor = true;
            this.button_cecha_11.Click += new System.EventHandler(this.button_cecha_11_Click);
            // 
            // button_cecha_12
            // 
            this.button_cecha_12.Location = new System.Drawing.Point(1009, 351);
            this.button_cecha_12.Name = "button_cecha_12";
            this.button_cecha_12.Size = new System.Drawing.Size(75, 23);
            this.button_cecha_12.TabIndex = 48;
            this.button_cecha_12.Text = "Cecha 12";
            this.button_cecha_12.UseVisualStyleBackColor = true;
            this.button_cecha_12.Click += new System.EventHandler(this.button_cecha_12_Click);
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(1091, 329);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(156, 20);
            this.textBox12.TabIndex = 49;
            // 
            // textBox13
            // 
            this.textBox13.Location = new System.Drawing.Point(1091, 356);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(156, 20);
            this.textBox13.TabIndex = 50;
            // 
            // button_cecha_13
            // 
            this.button_cecha_13.Location = new System.Drawing.Point(1009, 377);
            this.button_cecha_13.Name = "button_cecha_13";
            this.button_cecha_13.Size = new System.Drawing.Size(75, 23);
            this.button_cecha_13.TabIndex = 51;
            this.button_cecha_13.Text = "Cecha 13";
            this.button_cecha_13.UseVisualStyleBackColor = true;
            this.button_cecha_13.Click += new System.EventHandler(this.button_cecha_13_Click);
            // 
            // textBox14
            // 
            this.textBox14.Location = new System.Drawing.Point(1091, 380);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(156, 20);
            this.textBox14.TabIndex = 52;
            // 
            // button_cecha_14
            // 
            this.button_cecha_14.Location = new System.Drawing.Point(1008, 406);
            this.button_cecha_14.Name = "button_cecha_14";
            this.button_cecha_14.Size = new System.Drawing.Size(75, 23);
            this.button_cecha_14.TabIndex = 53;
            this.button_cecha_14.Text = "Cecha 14";
            this.button_cecha_14.UseVisualStyleBackColor = true;
            this.button_cecha_14.Click += new System.EventHandler(this.button_cecha_14_Click);
            // 
            // textBox15
            // 
            this.textBox15.Location = new System.Drawing.Point(1091, 406);
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new System.Drawing.Size(156, 20);
            this.textBox15.TabIndex = 54;
            // 
            // button_cecha_15
            // 
            this.button_cecha_15.Location = new System.Drawing.Point(1008, 435);
            this.button_cecha_15.Name = "button_cecha_15";
            this.button_cecha_15.Size = new System.Drawing.Size(75, 23);
            this.button_cecha_15.TabIndex = 55;
            this.button_cecha_15.Text = "Cecha 15";
            this.button_cecha_15.UseVisualStyleBackColor = true;
            this.button_cecha_15.Click += new System.EventHandler(this.button_cecha_15_Click);
            // 
            // textBox16
            // 
            this.textBox16.Location = new System.Drawing.Point(1089, 437);
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new System.Drawing.Size(156, 20);
            this.textBox16.TabIndex = 56;
            // 
            // button_cecha_16
            // 
            this.button_cecha_16.Location = new System.Drawing.Point(1008, 463);
            this.button_cecha_16.Name = "button_cecha_16";
            this.button_cecha_16.Size = new System.Drawing.Size(75, 23);
            this.button_cecha_16.TabIndex = 57;
            this.button_cecha_16.Text = "Cecha 16";
            this.button_cecha_16.UseVisualStyleBackColor = true;
            this.button_cecha_16.Click += new System.EventHandler(this.button_cecha_16_Click);
            // 
            // textBox17
            // 
            this.textBox17.Location = new System.Drawing.Point(1089, 465);
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new System.Drawing.Size(156, 20);
            this.textBox17.TabIndex = 58;
            // 
            // RecognizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1259, 504);
            this.Controls.Add(this.textBox17);
            this.Controls.Add(this.button_cecha_16);
            this.Controls.Add(this.textBox16);
            this.Controls.Add(this.button_cecha_15);
            this.Controls.Add(this.textBox15);
            this.Controls.Add(this.button_cecha_14);
            this.Controls.Add(this.textBox14);
            this.Controls.Add(this.button_cecha_13);
            this.Controls.Add(this.textBox13);
            this.Controls.Add(this.textBox12);
            this.Controls.Add(this.button_cecha_12);
            this.Controls.Add(this.button_cecha_11);
            this.Controls.Add(this.textBox11);
            this.Controls.Add(this.textBox10);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.button_cecha_10);
            this.Controls.Add(this.button_cecha_9);
            this.Controls.Add(this.button_cecha_8);
            this.Controls.Add(this.button_cecha_7);
            this.Controls.Add(this.button_cecha_6);
            this.Controls.Add(this.button_calculate);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.button_cecha_5);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.button_cecha_4);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.button_cecha_3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.button_cecha_2);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.button_cecha_1);
            this.Controls.Add(this.button10);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button_filter);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.button_threshold);
            this.Controls.Add(this.button_gray);
            this.Controls.Add(this.button_canny);
            this.Controls.Add(this.button_load);
            this.Controls.Add(this.button_save);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.textBox1);
            this.Name = "RecognizeForm";
            this.Text = "RecognizeForm";
            this.Load += new System.EventHandler(this.RecognizeForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.Button button_load;
        private System.Windows.Forms.Button button_canny;
        private System.Windows.Forms.Button button_gray;
        private System.Windows.Forms.Button button_threshold;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button button_filter;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.Button button_cecha_1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button button_cecha_2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button_cecha_3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button button_cecha_4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Button button_cecha_5;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.Button button_calculate;
        private System.Windows.Forms.Button button_cecha_6;
        private System.Windows.Forms.Button button_cecha_7;
        private System.Windows.Forms.Button button_cecha_8;
        private System.Windows.Forms.Button button_cecha_9;
        private System.Windows.Forms.Button button_cecha_10;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.Button button_cecha_11;
        private System.Windows.Forms.Button button_cecha_12;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.TextBox textBox13;
        private System.Windows.Forms.Button button_cecha_13;
        private System.Windows.Forms.TextBox textBox14;
        private System.Windows.Forms.Button button_cecha_14;
        private System.Windows.Forms.TextBox textBox15;
        private System.Windows.Forms.Button button_cecha_15;
        private System.Windows.Forms.TextBox textBox16;
        private System.Windows.Forms.Button button_cecha_16;
        private System.Windows.Forms.TextBox textBox17;
    }
}
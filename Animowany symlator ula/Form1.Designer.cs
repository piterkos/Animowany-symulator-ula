namespace Animowany_symlator_ula
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Wymagana metoda obsługi projektanta — nie należy modyfikować 
        /// zawartość tej metody z edytorem kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.otwórzToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.zapiszToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.drukujToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_iloscPszczol = new System.Windows.Forms.Label();
            this.lbl_iloscKwiatkow = new System.Windows.Forms.Label();
            this.lbl_iloscMioduWulu = new System.Windows.Forms.Label();
            this.lbl_nektarNaKwiatkach = new System.Windows.Forms.Label();
            this.lbl_iloscKlatek = new System.Windows.Forms.Label();
            this.lbl_iloscKlatekNaSek = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripSeparator,
            this.otwórzToolStripButton,
            this.zapiszToolStripButton,
            this.drukujToolStripButton,
            this.toolStripSeparator1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(329, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(124, 22);
            this.toolStripButton1.Text = "Rozpocznij symulację";
            this.toolStripButton1.Click += new System.EventHandler(this.ToolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(47, 22);
            this.toolStripButton2.Text = "Restart";
            this.toolStripButton2.Click += new System.EventHandler(this.ToolStripButton2_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // otwórzToolStripButton
            // 
            this.otwórzToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.otwórzToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("otwórzToolStripButton.Image")));
            this.otwórzToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.otwórzToolStripButton.Name = "otwórzToolStripButton";
            this.otwórzToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.otwórzToolStripButton.Text = "&Otwórz";
            this.otwórzToolStripButton.Click += new System.EventHandler(this.OtwórzToolStripButton_Click);
            // 
            // zapiszToolStripButton
            // 
            this.zapiszToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.zapiszToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("zapiszToolStripButton.Image")));
            this.zapiszToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.zapiszToolStripButton.Name = "zapiszToolStripButton";
            this.zapiszToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.zapiszToolStripButton.Text = "&Zapisz";
            this.zapiszToolStripButton.Click += new System.EventHandler(this.ZapiszToolStripButton_Click);
            // 
            // drukujToolStripButton
            // 
            this.drukujToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.drukujToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("drukujToolStripButton.Image")));
            this.drukujToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.drukujToolStripButton.Name = "drukujToolStripButton";
            this.drukujToolStripButton.Size = new System.Drawing.Size(23, 22);
            this.drukujToolStripButton.Text = "&Drukuj";
            this.drukujToolStripButton.Click += new System.EventHandler(this.drukujToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 379);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(329, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(124, 17);
            this.toolStripStatusLabel1.Text = "Symulacja zatrzymana";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.lbl_iloscPszczol, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbl_iloscKwiatkow, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbl_iloscMioduWulu, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbl_nektarNaKwiatkach, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lbl_iloscKlatek, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lbl_iloscKlatekNaSek, 1, 5);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 39);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(288, 122);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Ilość pszczół";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Ilość kwiatków";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 40);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Całkowita ilość miodu";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Całkowita ilość nektaru";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(132, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Ilość wyświetlonych klatek";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "Ilość klatek na sekundę";
            // 
            // lbl_iloscPszczol
            // 
            this.lbl_iloscPszczol.AutoSize = true;
            this.lbl_iloscPszczol.Location = new System.Drawing.Point(147, 0);
            this.lbl_iloscPszczol.Name = "lbl_iloscPszczol";
            this.lbl_iloscPszczol.Size = new System.Drawing.Size(53, 13);
            this.lbl_iloscPszczol.TabIndex = 6;
            this.lbl_iloscPszczol.Text = "pszczół...";
            // 
            // lbl_iloscKwiatkow
            // 
            this.lbl_iloscKwiatkow.AutoSize = true;
            this.lbl_iloscKwiatkow.Location = new System.Drawing.Point(147, 20);
            this.lbl_iloscKwiatkow.Name = "lbl_iloscKwiatkow";
            this.lbl_iloscKwiatkow.Size = new System.Drawing.Size(52, 13);
            this.lbl_iloscKwiatkow.TabIndex = 7;
            this.lbl_iloscKwiatkow.Text = "kwiatków";
            // 
            // lbl_iloscMioduWulu
            // 
            this.lbl_iloscMioduWulu.AutoSize = true;
            this.lbl_iloscMioduWulu.Location = new System.Drawing.Point(147, 40);
            this.lbl_iloscMioduWulu.Name = "lbl_iloscMioduWulu";
            this.lbl_iloscMioduWulu.Size = new System.Drawing.Size(63, 13);
            this.lbl_iloscMioduWulu.TabIndex = 8;
            this.lbl_iloscMioduWulu.Text = "miodu w ulu";
            // 
            // lbl_nektarNaKwiatkach
            // 
            this.lbl_nektarNaKwiatkach.AutoSize = true;
            this.lbl_nektarNaKwiatkach.Location = new System.Drawing.Point(147, 60);
            this.lbl_nektarNaKwiatkach.Name = "lbl_nektarNaKwiatkach";
            this.lbl_nektarNaKwiatkach.Size = new System.Drawing.Size(104, 13);
            this.lbl_nektarNaKwiatkach.TabIndex = 9;
            this.lbl_nektarNaKwiatkach.Text = "nektar na kwiatkach";
            // 
            // lbl_iloscKlatek
            // 
            this.lbl_iloscKlatek.AutoSize = true;
            this.lbl_iloscKlatek.Location = new System.Drawing.Point(147, 80);
            this.lbl_iloscKlatek.Name = "lbl_iloscKlatek";
            this.lbl_iloscKlatek.Size = new System.Drawing.Size(36, 13);
            this.lbl_iloscKlatek.TabIndex = 10;
            this.lbl_iloscKlatek.Text = "klatek";
            // 
            // lbl_iloscKlatekNaSek
            // 
            this.lbl_iloscKlatekNaSek.AutoSize = true;
            this.lbl_iloscKlatekNaSek.Location = new System.Drawing.Point(147, 100);
            this.lbl_iloscKlatekNaSek.Name = "lbl_iloscKlatekNaSek";
            this.lbl_iloscKlatekNaSek.Size = new System.Drawing.Size(71, 13);
            this.lbl_iloscKlatekNaSek.TabIndex = 11;
            this.lbl_iloscKlatekNaSek.Text = "klatek na sek";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 177);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(288, 186);
            this.listBox1.TabIndex = 3;
            // 
            // timer2
            // 
            this.timer2.Enabled = true;
            this.timer2.Interval = 150;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(329, 401);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.Text = "Symulator ula";
            this.Move += new System.EventHandler(this.Form1_Move);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbl_iloscPszczol;
        private System.Windows.Forms.Label lbl_iloscKwiatkow;
        private System.Windows.Forms.Label lbl_iloscMioduWulu;
        private System.Windows.Forms.Label lbl_nektarNaKwiatkach;
        private System.Windows.Forms.Label lbl_iloscKlatek;
        private System.Windows.Forms.Label lbl_iloscKlatekNaSek;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton otwórzToolStripButton;
        private System.Windows.Forms.ToolStripButton zapiszToolStripButton;
        private System.Windows.Forms.ToolStripButton drukujToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Timer timer2;
    }
}


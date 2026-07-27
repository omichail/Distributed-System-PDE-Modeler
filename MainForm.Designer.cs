namespace InterfaceMatMod
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label_L = new System.Windows.Forms.Label();
            this.label_G = new System.Windows.Forms.Label();
            this.label_a = new System.Windows.Forms.Label();
            this.label_b = new System.Windows.Forms.Label();
            this.label_c = new System.Windows.Forms.Label();
            this.label_T = new System.Windows.Forms.Label();
            this.label_init = new System.Windows.Forms.Label();
            this.numericUpDown_a = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_b = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_c = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_T = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown_init = new System.Windows.Forms.NumericUpDown();
            this.label_bound = new System.Windows.Forms.Label();
            this.flowLayoutPanel_init = new System.Windows.Forms.FlowLayoutPanel();
            this.numericUpDown_bound = new System.Windows.Forms.NumericUpDown();
            this.flowLayoutPanel_bound = new System.Windows.Forms.FlowLayoutPanel();
            this.comboBoxu = new System.Windows.Forms.ComboBox();
            this.label_u = new System.Windows.Forms.Label();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.textBoxY = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.textBoxL = new System.Windows.Forms.TextBox();
            this.textBoxG = new System.Windows.Forms.TextBox();
            this.textBoxEps = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_a)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_b)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_c)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_T)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_init)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_bound)).BeginInit();
            this.SuspendLayout();
            // 
            // label_L
            // 
            this.label_L.AutoSize = true;
            this.label_L.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_L.Location = new System.Drawing.Point(45, 18);
            this.label_L.Name = "label_L";
            this.label_L.Size = new System.Drawing.Size(74, 24);
            this.label_L.TabIndex = 0;
            this.label_L.Text = "L(∂_s):";
            // 
            // label_G
            // 
            this.label_G.AutoSize = true;
            this.label_G.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_G.Location = new System.Drawing.Point(497, 21);
            this.label_G.Name = "label_G";
            this.label_G.Size = new System.Drawing.Size(55, 24);
            this.label_G.TabIndex = 2;
            this.label_G.Text = "G(s):";
            // 
            // label_a
            // 
            this.label_a.AutoSize = true;
            this.label_a.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold);
            this.label_a.Location = new System.Drawing.Point(59, 122);
            this.label_a.Name = "label_a";
            this.label_a.Size = new System.Drawing.Size(28, 24);
            this.label_a.TabIndex = 4;
            this.label_a.Text = "a:";
            // 
            // label_b
            // 
            this.label_b.AutoSize = true;
            this.label_b.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold);
            this.label_b.Location = new System.Drawing.Point(169, 122);
            this.label_b.Name = "label_b";
            this.label_b.Size = new System.Drawing.Size(28, 24);
            this.label_b.TabIndex = 5;
            this.label_b.Text = "b:";
            // 
            // label_c
            // 
            this.label_c.AutoSize = true;
            this.label_c.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold);
            this.label_c.Location = new System.Drawing.Point(293, 122);
            this.label_c.Name = "label_c";
            this.label_c.Size = new System.Drawing.Size(27, 24);
            this.label_c.TabIndex = 6;
            this.label_c.Text = "c:";
            // 
            // label_T
            // 
            this.label_T.AutoSize = true;
            this.label_T.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold);
            this.label_T.Location = new System.Drawing.Point(413, 122);
            this.label_T.Name = "label_T";
            this.label_T.Size = new System.Drawing.Size(28, 24);
            this.label_T.TabIndex = 7;
            this.label_T.Text = "T:";
            // 
            // label_init
            // 
            this.label_init.AutoSize = true;
            this.label_init.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_init.Location = new System.Drawing.Point(184, 183);
            this.label_init.Name = "label_init";
            this.label_init.Size = new System.Drawing.Size(116, 24);
            this.label_init.TabIndex = 12;
            this.label_init.Text = "Initial cond:";
            // 
            // numericUpDown_a
            // 
            this.numericUpDown_a.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.numericUpDown_a.Location = new System.Drawing.Point(45, 145);
            this.numericUpDown_a.Name = "numericUpDown_a";
            this.numericUpDown_a.Size = new System.Drawing.Size(50, 29);
            this.numericUpDown_a.TabIndex = 14;
            this.numericUpDown_a.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numericUpDown_b
            // 
            this.numericUpDown_b.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.numericUpDown_b.Location = new System.Drawing.Point(152, 145);
            this.numericUpDown_b.Name = "numericUpDown_b";
            this.numericUpDown_b.Size = new System.Drawing.Size(50, 29);
            this.numericUpDown_b.TabIndex = 15;
            this.numericUpDown_b.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numericUpDown_c
            // 
            this.numericUpDown_c.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.numericUpDown_c.Location = new System.Drawing.Point(276, 145);
            this.numericUpDown_c.Name = "numericUpDown_c";
            this.numericUpDown_c.Size = new System.Drawing.Size(50, 29);
            this.numericUpDown_c.TabIndex = 16;
            this.numericUpDown_c.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numericUpDown_T
            // 
            this.numericUpDown_T.Font = new System.Drawing.Font("Times New Roman", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.numericUpDown_T.Location = new System.Drawing.Point(396, 145);
            this.numericUpDown_T.Name = "numericUpDown_T";
            this.numericUpDown_T.Size = new System.Drawing.Size(50, 29);
            this.numericUpDown_T.TabIndex = 17;
            this.numericUpDown_T.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numericUpDown_init
            // 
            this.numericUpDown_init.Font = new System.Drawing.Font("Times New Roman", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDown_init.Location = new System.Drawing.Point(214, 210);
            this.numericUpDown_init.Name = "numericUpDown_init";
            this.numericUpDown_init.Size = new System.Drawing.Size(49, 22);
            this.numericUpDown_init.TabIndex = 18;
            this.numericUpDown_init.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown_init.ValueChanged += new System.EventHandler(this.numericUpDown_init_ValueChanged);
            // 
            // label_bound
            // 
            this.label_bound.AutoSize = true;
            this.label_bound.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_bound.Location = new System.Drawing.Point(616, 183);
            this.label_bound.Name = "label_bound";
            this.label_bound.Size = new System.Drawing.Size(153, 24);
            this.label_bound.TabIndex = 19;
            this.label_bound.Text = "Boundary cond:";
            // 
            // flowLayoutPanel_init
            // 
            this.flowLayoutPanel_init.AutoScroll = true;
            this.flowLayoutPanel_init.Location = new System.Drawing.Point(93, 238);
            this.flowLayoutPanel_init.Name = "flowLayoutPanel_init";
            this.flowLayoutPanel_init.Size = new System.Drawing.Size(300, 146);
            this.flowLayoutPanel_init.TabIndex = 21;
            // 
            // numericUpDown_bound
            // 
            this.numericUpDown_bound.Font = new System.Drawing.Font("Times New Roman", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.numericUpDown_bound.Location = new System.Drawing.Point(665, 210);
            this.numericUpDown_bound.Name = "numericUpDown_bound";
            this.numericUpDown_bound.Size = new System.Drawing.Size(49, 22);
            this.numericUpDown_bound.TabIndex = 22;
            this.numericUpDown_bound.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numericUpDown_bound.ValueChanged += new System.EventHandler(this.numericUpDown_bound_ValueChanged);
            // 
            // flowLayoutPanel_bound
            // 
            this.flowLayoutPanel_bound.AutoScroll = true;
            this.flowLayoutPanel_bound.Location = new System.Drawing.Point(538, 238);
            this.flowLayoutPanel_bound.Name = "flowLayoutPanel_bound";
            this.flowLayoutPanel_bound.Size = new System.Drawing.Size(300, 148);
            this.flowLayoutPanel_bound.TabIndex = 23;
            // 
            // comboBoxu
            // 
            this.comboBoxu.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBoxu.FormattingEnabled = true;
            this.comboBoxu.Location = new System.Drawing.Point(491, 144);
            this.comboBoxu.Name = "comboBoxu";
            this.comboBoxu.Size = new System.Drawing.Size(407, 27);
            this.comboBoxu.TabIndex = 24;
            // 
            // label_u
            // 
            this.label_u.AutoSize = true;
            this.label_u.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_u.Location = new System.Drawing.Point(497, 108);
            this.label_u.Name = "label_u";
            this.label_u.Size = new System.Drawing.Size(50, 24);
            this.label_u.TabIndex = 25;
            this.label_u.Text = "u(s):";
            // 
            // btnCalculate
            // 
            this.btnCalculate.BackColor = System.Drawing.Color.Snow;
            this.btnCalculate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCalculate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCalculate.Font = new System.Drawing.Font("Times New Roman", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnCalculate.Location = new System.Drawing.Point(39, 523);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(314, 85);
            this.btnCalculate.TabIndex = 26;
            this.btnCalculate.Text = "Okaaay, Let\'s go!!!";
            this.btnCalculate.UseVisualStyleBackColor = false;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // textBoxY
            // 
            this.textBoxY.Font = new System.Drawing.Font("Times New Roman", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxY.Location = new System.Drawing.Point(112, 400);
            this.textBoxY.Multiline = true;
            this.textBoxY.Name = "textBoxY";
            this.textBoxY.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxY.Size = new System.Drawing.Size(786, 88);
            this.textBoxY.TabIndex = 27;
            this.textBoxY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(39, 429);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 24);
            this.label1.TabIndex = 28;
            this.label1.Text = "y(s):";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(39, 649);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(859, 46);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 29;
            // 
            // textBoxL
            // 
            this.textBoxL.Font = new System.Drawing.Font("Times New Roman", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxL.Location = new System.Drawing.Point(39, 45);
            this.textBoxL.Name = "textBoxL";
            this.textBoxL.Size = new System.Drawing.Size(407, 44);
            this.textBoxL.TabIndex = 31;
            this.textBoxL.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxG
            // 
            this.textBoxG.Font = new System.Drawing.Font("Times New Roman", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxG.Location = new System.Drawing.Point(491, 45);
            this.textBoxG.Name = "textBoxG";
            this.textBoxG.Size = new System.Drawing.Size(407, 44);
            this.textBoxG.TabIndex = 32;
            this.textBoxG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxEps
            // 
            this.textBoxEps.Font = new System.Drawing.Font("Times New Roman", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxEps.Location = new System.Drawing.Point(455, 536);
            this.textBoxEps.Multiline = true;
            this.textBoxEps.Name = "textBoxEps";
            this.textBoxEps.Size = new System.Drawing.Size(443, 50);
            this.textBoxEps.TabIndex = 33;
            this.textBoxEps.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(399, 549);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 24);
            this.label2.TabIndex = 34;
            this.label2.Text = "Eps:";
            // 
            // MainForm
            // 
            this.AutoScroll = true;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(951, 720);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxEps);
            this.Controls.Add(this.textBoxG);
            this.Controls.Add(this.textBoxL);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxY);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.label_u);
            this.Controls.Add(this.comboBoxu);
            this.Controls.Add(this.flowLayoutPanel_bound);
            this.Controls.Add(this.numericUpDown_bound);
            this.Controls.Add(this.flowLayoutPanel_init);
            this.Controls.Add(this.label_bound);
            this.Controls.Add(this.numericUpDown_init);
            this.Controls.Add(this.numericUpDown_T);
            this.Controls.Add(this.numericUpDown_c);
            this.Controls.Add(this.numericUpDown_b);
            this.Controls.Add(this.numericUpDown_a);
            this.Controls.Add(this.label_init);
            this.Controls.Add(this.label_T);
            this.Controls.Add(this.label_c);
            this.Controls.Add(this.label_b);
            this.Controls.Add(this.label_a);
            this.Controls.Add(this.label_G);
            this.Controls.Add(this.label_L);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_a)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_b)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_c)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_T)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_init)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_bound)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_L;
        private System.Windows.Forms.Label label_G;
        private System.Windows.Forms.Label label_a;
        private System.Windows.Forms.Label label_b;
        private System.Windows.Forms.Label label_c;
        private System.Windows.Forms.Label label_T;
        private System.Windows.Forms.Label label_init;
        private System.Windows.Forms.NumericUpDown numericUpDown_a;
        private System.Windows.Forms.NumericUpDown numericUpDown_b;
        private System.Windows.Forms.NumericUpDown numericUpDown_c;
        private System.Windows.Forms.NumericUpDown numericUpDown_T;
        private System.Windows.Forms.NumericUpDown numericUpDown_init;
        private System.Windows.Forms.Label label_bound;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_init;
        private System.Windows.Forms.NumericUpDown numericUpDown_bound;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_bound;
        private System.Windows.Forms.ComboBox comboBoxu;
        private System.Windows.Forms.Label label_u;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.TextBox textBoxY;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox textBoxL;
        private System.Windows.Forms.TextBox textBoxG;
        private System.Windows.Forms.TextBox textBoxEps;
        private System.Windows.Forms.Label label2;
    }
}
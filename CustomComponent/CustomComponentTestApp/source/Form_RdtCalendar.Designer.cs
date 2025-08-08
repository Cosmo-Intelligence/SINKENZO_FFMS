namespace RADISTA.CustomComponentTestApp
{
    partial class Form_RdtCalendar
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
                this.DisposeCustomSetting();
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
            components = new System.ComponentModel.Container();
            rdtCalendar_Default = new RADISTA.SPREAD.CustomControl.RdtCalendar(components);
            button_Date_Default = new Button();
            label_CountMashing = new Label();
            label6 = new Label();
            label8 = new Label();
            label_Count = new Label();
            label_33 = new Label();
            button_New_Delete = new Button();
            label26 = new Label();
            label1 = new Label();
            label2 = new Label();
            label14 = new Label();
            label3 = new Label();
            label4 = new Label();
            rdtCalendar_IsDisplayYearMonthList_true = new RADISTA.SPREAD.CustomControl.RdtCalendar(components);
            rdtCalendar_IsDisplayYearMonthList_false = new RADISTA.SPREAD.CustomControl.RdtCalendar(components);
            label5 = new Label();
            button_IsDisplayYearMonthList_true = new Button();
            button_IsDisplayYearMonthList_false = new Button();
            label7 = new Label();
            label9 = new Label();
            label10 = new Label();
            button_IsStartMonday_true = new Button();
            rdtCalendar_IsStartMonday_true = new RADISTA.SPREAD.CustomControl.RdtCalendar(components);
            button_IsStartMonday_false = new Button();
            rdtCalendar_IsStartMonday_false = new RADISTA.SPREAD.CustomControl.RdtCalendar(components);
            label_BackColor = new Label();
            label11 = new Label();
            label_FontColor = new Label();
            label12 = new Label();
            label13 = new Label();
            label15 = new Label();
            label16 = new Label();
            label_TitleForeColor = new Label();
            label_TitleBackColor = new Label();
            label_TrailingForeColor = new Label();
            SuspendLayout();
            // 
            // rdtCalendar_Default
            // 
            rdtCalendar_Default.BackColor = Color.FromArgb(25, 25, 25);
            rdtCalendar_Default.ForeColor = Color.FromArgb(196, 196, 196);
            rdtCalendar_Default.IsDisplayYearMonthList = false;
            rdtCalendar_Default.IsStartMonday = false;
            rdtCalendar_Default.Location = new Point(52, 63);
            rdtCalendar_Default.Name = "rdtCalendar_Default";
            rdtCalendar_Default.TabIndex = 0;
            rdtCalendar_Default.TitleBackColor = Color.FromArgb(58, 58, 58);
            rdtCalendar_Default.TitleForeColor = Color.FromArgb(196, 196, 196);
            rdtCalendar_Default.TrailingForeColor = Color.FromArgb(85, 85, 85);
            // 
            // button_Date_Default
            // 
            button_Date_Default.Location = new Point(52, 298);
            button_Date_Default.Name = "button_Date_Default";
            button_Date_Default.Size = new Size(182, 29);
            button_Date_Default.TabIndex = 2;
            button_Date_Default.Text = "button1";
            button_Date_Default.UseVisualStyleBackColor = true;
            button_Date_Default.Click += button_Date_DefaultClick;
            // 
            // label_CountMashing
            // 
            label_CountMashing.AutoSize = true;
            label_CountMashing.Location = new Point(1098, 74);
            label_CountMashing.Name = "label_CountMashing";
            label_CountMashing.Size = new Size(17, 20);
            label_CountMashing.TabIndex = 197;
            label_CountMashing.Text = "0";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(1043, 74);
            label6.Name = "label6";
            label6.Size = new Size(49, 20);
            label6.TabIndex = 196;
            label6.Text = "回数=";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(1043, 46);
            label8.Name = "label8";
            label8.Size = new Size(39, 20);
            label8.TabIndex = 195;
            label8.Text = "連打";
            // 
            // label_Count
            // 
            label_Count.AutoSize = true;
            label_Count.Location = new Point(958, 78);
            label_Count.Name = "label_Count";
            label_Count.Size = new Size(17, 20);
            label_Count.TabIndex = 194;
            label_Count.Text = "0";
            // 
            // label_33
            // 
            label_33.AutoSize = true;
            label_33.Location = new Point(903, 78);
            label_33.Name = "label_33";
            label_33.Size = new Size(49, 20);
            label_33.TabIndex = 193;
            label_33.Text = "回数=";
            // 
            // button_New_Delete
            // 
            button_New_Delete.Location = new Point(903, 46);
            button_New_Delete.Name = "button_New_Delete";
            button_New_Delete.Size = new Size(94, 29);
            button_New_Delete.TabIndex = 192;
            button_New_Delete.Text = "生成⇒破棄";
            button_New_Delete.UseVisualStyleBackColor = true;
            button_New_Delete.Click += button_New_Delete_Click;
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Location = new Point(883, 18);
            label26.Name = "label26";
            label26.Size = new Size(122, 20);
            label26.TabIndex = 191;
            label26.Text = "【メモリリークテスト】";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(32, 34);
            label1.Name = "label1";
            label1.Size = new Size(63, 20);
            label1.TabIndex = 198;
            label1.Text = "デフォルト";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(109, 20);
            label2.TabIndex = 199;
            label2.Text = "【デフォルト表示】";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(13, 353);
            label14.Name = "label14";
            label14.Size = new Size(108, 20);
            label14.TabIndex = 200;
            label14.Text = "【拡張プロパティ】";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(33, 378);
            label3.Name = "label3";
            label3.Size = new Size(140, 20);
            label3.TabIndex = 201;
            label3.Text = "年月組み合わせリスト";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(53, 403);
            label4.Name = "label4";
            label4.Size = new Size(197, 20);
            label4.TabIndex = 202;
            label4.Text = "IsDisplayYearMonthList=true";
            // 
            // rdtCalendar_IsDisplayYearMonthList_true
            // 
            rdtCalendar_IsDisplayYearMonthList_true.BackColor = Color.FromArgb(25, 25, 25);
            rdtCalendar_IsDisplayYearMonthList_true.ForeColor = Color.FromArgb(196, 196, 196);
            rdtCalendar_IsDisplayYearMonthList_true.IsDisplayYearMonthList = true;
            rdtCalendar_IsDisplayYearMonthList_true.IsStartMonday = false;
            rdtCalendar_IsDisplayYearMonthList_true.Location = new Point(73, 432);
            rdtCalendar_IsDisplayYearMonthList_true.Name = "rdtCalendar_IsDisplayYearMonthList_true";
            rdtCalendar_IsDisplayYearMonthList_true.TabIndex = 203;
            rdtCalendar_IsDisplayYearMonthList_true.TitleBackColor = Color.FromArgb(58, 58, 58);
            rdtCalendar_IsDisplayYearMonthList_true.TitleForeColor = Color.FromArgb(196, 196, 196);
            rdtCalendar_IsDisplayYearMonthList_true.TrailingForeColor = Color.FromArgb(85, 85, 85);
            // 
            // rdtCalendar_IsDisplayYearMonthList_false
            // 
            rdtCalendar_IsDisplayYearMonthList_false.BackColor = Color.FromArgb(25, 25, 25);
            rdtCalendar_IsDisplayYearMonthList_false.ForeColor = Color.FromArgb(196, 196, 196);
            rdtCalendar_IsDisplayYearMonthList_false.IsDisplayYearMonthList = false;
            rdtCalendar_IsDisplayYearMonthList_false.IsStartMonday = false;
            rdtCalendar_IsDisplayYearMonthList_false.Location = new Point(434, 432);
            rdtCalendar_IsDisplayYearMonthList_false.Name = "rdtCalendar_IsDisplayYearMonthList_false";
            rdtCalendar_IsDisplayYearMonthList_false.TabIndex = 204;
            rdtCalendar_IsDisplayYearMonthList_false.TitleBackColor = Color.FromArgb(58, 58, 58);
            rdtCalendar_IsDisplayYearMonthList_false.TitleForeColor = Color.FromArgb(196, 196, 196);
            rdtCalendar_IsDisplayYearMonthList_false.TrailingForeColor = Color.FromArgb(85, 85, 85);
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(414, 403);
            label5.Name = "label5";
            label5.Size = new Size(202, 20);
            label5.TabIndex = 205;
            label5.Text = "IsDisplayYearMonthList=false";
            // 
            // button_IsDisplayYearMonthList_true
            // 
            button_IsDisplayYearMonthList_true.Location = new Point(73, 667);
            button_IsDisplayYearMonthList_true.Name = "button_IsDisplayYearMonthList_true";
            button_IsDisplayYearMonthList_true.Size = new Size(182, 29);
            button_IsDisplayYearMonthList_true.TabIndex = 206;
            button_IsDisplayYearMonthList_true.Text = "button1";
            button_IsDisplayYearMonthList_true.UseVisualStyleBackColor = true;
            button_IsDisplayYearMonthList_true.Click += button_IsDisplayYearMonthList_true_Click;
            // 
            // button_IsDisplayYearMonthList_false
            // 
            button_IsDisplayYearMonthList_false.Location = new Point(434, 667);
            button_IsDisplayYearMonthList_false.Name = "button_IsDisplayYearMonthList_false";
            button_IsDisplayYearMonthList_false.Size = new Size(182, 29);
            button_IsDisplayYearMonthList_false.TabIndex = 207;
            button_IsDisplayYearMonthList_false.Text = "button2";
            button_IsDisplayYearMonthList_false.UseVisualStyleBackColor = true;
            button_IsDisplayYearMonthList_false.Click += button_IsDisplayYearMonthList_false_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(812, 378);
            label7.Name = "label7";
            label7.Size = new Size(75, 20);
            label7.TabIndex = 208;
            label7.Text = "月曜始まり";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(832, 403);
            label9.Name = "label9";
            label9.Size = new Size(140, 20);
            label9.TabIndex = 209;
            label9.Text = "IsStartMonday=true";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(1172, 403);
            label10.Name = "label10";
            label10.Size = new Size(145, 20);
            label10.TabIndex = 210;
            label10.Text = "IsStartMonday=false";
            // 
            // button_IsStartMonday_true
            // 
            button_IsStartMonday_true.Location = new Point(852, 667);
            button_IsStartMonday_true.Name = "button_IsStartMonday_true";
            button_IsStartMonday_true.Size = new Size(182, 29);
            button_IsStartMonday_true.TabIndex = 212;
            button_IsStartMonday_true.Text = "button3";
            button_IsStartMonday_true.UseVisualStyleBackColor = true;
            button_IsStartMonday_true.Click += button_IsStartMonday_true_Click;
            // 
            // rdtCalendar_IsStartMonday_true
            // 
            rdtCalendar_IsStartMonday_true.BackColor = Color.FromArgb(25, 25, 25);
            rdtCalendar_IsStartMonday_true.ForeColor = Color.FromArgb(196, 196, 196);
            rdtCalendar_IsStartMonday_true.IsDisplayYearMonthList = false;
            rdtCalendar_IsStartMonday_true.IsStartMonday = true;
            rdtCalendar_IsStartMonday_true.Location = new Point(852, 432);
            rdtCalendar_IsStartMonday_true.Name = "rdtCalendar_IsStartMonday_true";
            rdtCalendar_IsStartMonday_true.TabIndex = 211;
            rdtCalendar_IsStartMonday_true.TitleBackColor = Color.FromArgb(58, 58, 58);
            rdtCalendar_IsStartMonday_true.TitleForeColor = Color.FromArgb(196, 196, 196);
            rdtCalendar_IsStartMonday_true.TrailingForeColor = Color.FromArgb(85, 85, 85);
            // 
            // button_IsStartMonday_false
            // 
            button_IsStartMonday_false.Location = new Point(1192, 667);
            button_IsStartMonday_false.Name = "button_IsStartMonday_false";
            button_IsStartMonday_false.Size = new Size(182, 29);
            button_IsStartMonday_false.TabIndex = 214;
            button_IsStartMonday_false.Text = "button4";
            button_IsStartMonday_false.UseVisualStyleBackColor = true;
            button_IsStartMonday_false.Click += button_IsStartMonday_false_Click;
            // 
            // rdtCalendar_IsStartMonday_false
            // 
            rdtCalendar_IsStartMonday_false.BackColor = Color.FromArgb(25, 25, 25);
            rdtCalendar_IsStartMonday_false.ForeColor = Color.FromArgb(196, 196, 196);
            rdtCalendar_IsStartMonday_false.IsDisplayYearMonthList = false;
            rdtCalendar_IsStartMonday_false.IsStartMonday = false;
            rdtCalendar_IsStartMonday_false.Location = new Point(1192, 432);
            rdtCalendar_IsStartMonday_false.Name = "rdtCalendar_IsStartMonday_false";
            rdtCalendar_IsStartMonday_false.TabIndex = 213;
            rdtCalendar_IsStartMonday_false.TitleBackColor = Color.FromArgb(58, 58, 58);
            rdtCalendar_IsStartMonday_false.TitleForeColor = Color.FromArgb(196, 196, 196);
            rdtCalendar_IsStartMonday_false.TrailingForeColor = Color.FromArgb(85, 85, 85);
            // 
            // label_BackColor
            // 
            label_BackColor.AutoSize = true;
            label_BackColor.Location = new Point(464, 88);
            label_BackColor.Name = "label_BackColor";
            label_BackColor.Size = new Size(86, 20);
            label_BackColor.TabIndex = 223;
            label_BackColor.Text = "BackColor=";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(372, 88);
            label11.Name = "label11";
            label11.Size = new Size(86, 20);
            label11.TabIndex = 222;
            label11.Text = "BackColor=";
            // 
            // label_FontColor
            // 
            label_FontColor.AutoSize = true;
            label_FontColor.Location = new Point(464, 63);
            label_FontColor.Name = "label_FontColor";
            label_FontColor.Size = new Size(83, 20);
            label_FontColor.TabIndex = 221;
            label_FontColor.Text = "FontColor=";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(372, 63);
            label12.Name = "label12";
            label12.Size = new Size(83, 20);
            label12.TabIndex = 220;
            label12.Text = "FontColor=";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(372, 113);
            label13.Name = "label13";
            label13.Size = new Size(112, 20);
            label13.TabIndex = 224;
            label13.Text = "TitleForeColor=";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(372, 138);
            label15.Name = "label15";
            label15.Size = new Size(115, 20);
            label15.TabIndex = 225;
            label15.Text = "TitleBackColor=";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(372, 163);
            label16.Name = "label16";
            label16.Size = new Size(131, 20);
            label16.TabIndex = 226;
            label16.Text = "TrailingForeColor=";
            // 
            // label_TitleForeColor
            // 
            label_TitleForeColor.AutoSize = true;
            label_TitleForeColor.Location = new Point(490, 113);
            label_TitleForeColor.Name = "label_TitleForeColor";
            label_TitleForeColor.Size = new Size(112, 20);
            label_TitleForeColor.TabIndex = 227;
            label_TitleForeColor.Text = "TitleForeColor=";
            // 
            // label_TitleBackColor
            // 
            label_TitleBackColor.AutoSize = true;
            label_TitleBackColor.Location = new Point(493, 138);
            label_TitleBackColor.Name = "label_TitleBackColor";
            label_TitleBackColor.Size = new Size(115, 20);
            label_TitleBackColor.TabIndex = 228;
            label_TitleBackColor.Text = "TitleBackColor=";
            // 
            // label_TrailingForeColor
            // 
            label_TrailingForeColor.AutoSize = true;
            label_TrailingForeColor.Location = new Point(509, 163);
            label_TrailingForeColor.Name = "label_TrailingForeColor";
            label_TrailingForeColor.Size = new Size(131, 20);
            label_TrailingForeColor.TabIndex = 229;
            label_TrailingForeColor.Text = "TrailingForeColor=";
            // 
            // Form_RdtCalendar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1534, 791);
            Controls.Add(label_TrailingForeColor);
            Controls.Add(label_TitleBackColor);
            Controls.Add(label_TitleForeColor);
            Controls.Add(label16);
            Controls.Add(label15);
            Controls.Add(label13);
            Controls.Add(label_BackColor);
            Controls.Add(label11);
            Controls.Add(label_FontColor);
            Controls.Add(label12);
            Controls.Add(button_IsStartMonday_false);
            Controls.Add(rdtCalendar_IsStartMonday_false);
            Controls.Add(button_IsStartMonday_true);
            Controls.Add(rdtCalendar_IsStartMonday_true);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label7);
            Controls.Add(button_IsDisplayYearMonthList_false);
            Controls.Add(button_IsDisplayYearMonthList_true);
            Controls.Add(label5);
            Controls.Add(rdtCalendar_IsDisplayYearMonthList_false);
            Controls.Add(rdtCalendar_IsDisplayYearMonthList_true);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label14);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(label_CountMashing);
            Controls.Add(label6);
            Controls.Add(label8);
            Controls.Add(label_Count);
            Controls.Add(label_33);
            Controls.Add(button_New_Delete);
            Controls.Add(label26);
            Controls.Add(button_Date_Default);
            Controls.Add(rdtCalendar_Default);
            Name = "Form_RdtCalendar";
            Text = "Form_RdtCalendar";
            Load += Form_RdtCalendar_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RADISTA.SPREAD.CustomControl.RdtCalendar rdtCalendar_Default;
        private Button button_Date_Default;
        private Label label_CountMashing;
        private Label label6;
        private Label label8;
        private Label label_Count;
        private Label label_33;
        private Button button_New_Delete;
        private Label label26;
        private Label label1;
        private Label label2;
        private Label label14;
        private Label label3;
        private Label label4;
        private SPREAD.CustomControl.RdtCalendar rdtCalendar_IsDisplayYearMonthList_true;
        private SPREAD.CustomControl.RdtCalendar rdtCalendar_IsDisplayYearMonthList_false;
        private Label label5;
        private Button button_IsDisplayYearMonthList_true;
        private Button button_IsDisplayYearMonthList_false;
        private Label label7;
        private Label label9;
        private Label label10;
        private Button button_IsStartMonday_true;
        private SPREAD.CustomControl.RdtCalendar rdtCalendar_IsStartMonday_true;
        private Button button_IsStartMonday_false;
        private SPREAD.CustomControl.RdtCalendar rdtCalendar_IsStartMonday_false;
        private Label label_BackColor;
        private Label label11;
        private Label label_FontColor;
        private Label label12;
        private Label label13;
        private Label label15;
        private Label label16;
        private Label label_TitleForeColor;
        private Label label_TitleBackColor;
        private Label label_TrailingForeColor;
    }
}
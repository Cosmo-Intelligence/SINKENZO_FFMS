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
            rdtCalendar1 = new RADISTA.SPREAD.CustomControl.RdtCalendar(components);
            button_Date = new Button();
            label_CountMashing = new Label();
            label6 = new Label();
            label8 = new Label();
            label_Count = new Label();
            label_33 = new Label();
            button_New_Delete = new Button();
            label26 = new Label();
            SuspendLayout();
            // 
            // rdtCalendar1
            // 
            rdtCalendar1.BackColor = Color.FromArgb(25, 25, 25);
            rdtCalendar1.ForeColor = Color.FromArgb(196, 196, 196);
            rdtCalendar1.Location = new Point(18, 18);
            rdtCalendar1.Name = "rdtCalendar1";
            rdtCalendar1.TabIndex = 0;
            rdtCalendar1.TitleBackColor = Color.FromArgb(58, 58, 58);
            rdtCalendar1.TitleForeColor = Color.FromArgb(196, 196, 196);
            rdtCalendar1.TrailingForeColor = Color.FromArgb(85, 85, 85);
            // 
            // button_Date
            // 
            button_Date.Location = new Point(18, 253);
            button_Date.Name = "button_Date";
            button_Date.Size = new Size(182, 29);
            button_Date.TabIndex = 2;
            button_Date.Text = "button1";
            button_Date.UseVisualStyleBackColor = true;
            button_Date.Click += button_Date_Click;
            // 
            // label_CountMashing
            // 
            label_CountMashing.AutoSize = true;
            label_CountMashing.Location = new Point(563, 74);
            label_CountMashing.Name = "label_CountMashing";
            label_CountMashing.Size = new Size(17, 20);
            label_CountMashing.TabIndex = 197;
            label_CountMashing.Text = "0";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(508, 74);
            label6.Name = "label6";
            label6.Size = new Size(49, 20);
            label6.TabIndex = 196;
            label6.Text = "回数=";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(508, 46);
            label8.Name = "label8";
            label8.Size = new Size(39, 20);
            label8.TabIndex = 195;
            label8.Text = "連打";
            // 
            // label_Count
            // 
            label_Count.AutoSize = true;
            label_Count.Location = new Point(423, 78);
            label_Count.Name = "label_Count";
            label_Count.Size = new Size(17, 20);
            label_Count.TabIndex = 194;
            label_Count.Text = "0";
            // 
            // label_33
            // 
            label_33.AutoSize = true;
            label_33.Location = new Point(368, 78);
            label_33.Name = "label_33";
            label_33.Size = new Size(49, 20);
            label_33.TabIndex = 193;
            label_33.Text = "回数=";
            // 
            // button_New_Delete
            // 
            button_New_Delete.Location = new Point(368, 46);
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
            label26.Location = new Point(348, 18);
            label26.Name = "label26";
            label26.Size = new Size(122, 20);
            label26.TabIndex = 191;
            label26.Text = "【メモリリークテスト】";
            // 
            // Form_RdtCalendar
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label_CountMashing);
            Controls.Add(label6);
            Controls.Add(label8);
            Controls.Add(label_Count);
            Controls.Add(label_33);
            Controls.Add(button_New_Delete);
            Controls.Add(label26);
            Controls.Add(button_Date);
            Controls.Add(rdtCalendar1);
            Name = "Form_RdtCalendar";
            Text = "Form_RdtCalendar";
            Load += Form_RdtCalendar_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RADISTA.SPREAD.CustomControl.RdtCalendar rdtCalendar1;
        private Button button_Date;
        private Label label_CountMashing;
        private Label label6;
        private Label label8;
        private Label label_Count;
        private Label label_33;
        private Button button_New_Delete;
        private Label label26;
    }
}
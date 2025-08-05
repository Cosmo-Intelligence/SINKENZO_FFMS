namespace RADISTA.CustomComponentTestApp
{
    partial class Form_RdtMenuStrip
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
            rdtMenuStrip1 = new RADISTA.UIComponent.CustomControl.RdtMenuStrip(components);
            menu1ToolStripMenuItem = new ToolStripMenuItem();
            menu11ToolStripMenuItem = new ToolStripMenuItem();
            menu111ToolStripMenuItem = new ToolStripMenuItem();
            menu12ToolStripMenuItem = new ToolStripMenuItem();
            menu2ToolStripMenuItem = new ToolStripMenuItem();
            menu21ToolStripMenuItem = new ToolStripMenuItem();
            menu3ToolStripMenuItem = new ToolStripMenuItem();
            menu4ToolStripMenuItem = new ToolStripMenuItem();
            label2 = new Label();
            label_Count = new Label();
            label_33 = new Label();
            button_New_Delete = new Button();
            label26 = new Label();
            label_BackColor = new Label();
            label9 = new Label();
            label_FontColor = new Label();
            label7 = new Label();
            label_FontSize = new Label();
            label5 = new Label();
            label_FontType = new Label();
            label3 = new Label();
            label_CountMashing = new Label();
            label6 = new Label();
            label8 = new Label();
            label_DisableBackColor = new Label();
            label_DisableForeColor = new Label();
            label_HoverBackColor = new Label();
            label_HoverForeColor = new Label();
            label11 = new Label();
            label10 = new Label();
            label1 = new Label();
            label4 = new Label();
            rdtMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // rdtMenuStrip1
            // 
            rdtMenuStrip1.Font = new Font("Meiryo UI", 12F);
            rdtMenuStrip1.ImageScalingSize = new Size(20, 20);
            rdtMenuStrip1.Items.AddRange(new ToolStripItem[] { menu1ToolStripMenuItem, menu2ToolStripMenuItem, menu3ToolStripMenuItem, menu4ToolStripMenuItem });
            rdtMenuStrip1.Location = new Point(0, 0);
            rdtMenuStrip1.Name = "rdtMenuStrip1";
            rdtMenuStrip1.Size = new Size(800, 33);
            rdtMenuStrip1.TabIndex = 0;
            rdtMenuStrip1.Text = "rdtMenuStrip1";
            // 
            // menu1ToolStripMenuItem
            // 
            menu1ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { menu11ToolStripMenuItem, menu12ToolStripMenuItem });
            menu1ToolStripMenuItem.Name = "menu1ToolStripMenuItem";
            menu1ToolStripMenuItem.Size = new Size(91, 29);
            menu1ToolStripMenuItem.Text = "Menu1";
            // 
            // menu11ToolStripMenuItem
            // 
            menu11ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { menu111ToolStripMenuItem });
            menu11ToolStripMenuItem.Name = "menu11ToolStripMenuItem";
            menu11ToolStripMenuItem.Size = new Size(184, 30);
            menu11ToolStripMenuItem.Text = "Menu1-1";
            // 
            // menu111ToolStripMenuItem
            // 
            menu111ToolStripMenuItem.Name = "menu111ToolStripMenuItem";
            menu111ToolStripMenuItem.Size = new Size(205, 30);
            menu111ToolStripMenuItem.Text = "Menu1-1-1";
            // 
            // menu12ToolStripMenuItem
            // 
            menu12ToolStripMenuItem.Name = "menu12ToolStripMenuItem";
            menu12ToolStripMenuItem.Size = new Size(184, 30);
            menu12ToolStripMenuItem.Text = "Menu1-2";
            menu12ToolStripMenuItem.Click += menu12ToolStripMenuItem_Click;
            // 
            // menu2ToolStripMenuItem
            // 
            menu2ToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { menu21ToolStripMenuItem });
            menu2ToolStripMenuItem.Name = "menu2ToolStripMenuItem";
            menu2ToolStripMenuItem.Size = new Size(91, 29);
            menu2ToolStripMenuItem.Text = "Menu2";
            // 
            // menu21ToolStripMenuItem
            // 
            menu21ToolStripMenuItem.Name = "menu21ToolStripMenuItem";
            menu21ToolStripMenuItem.Size = new Size(184, 30);
            menu21ToolStripMenuItem.Text = "Menu2-1";
            // 
            // menu3ToolStripMenuItem
            // 
            menu3ToolStripMenuItem.Name = "menu3ToolStripMenuItem";
            menu3ToolStripMenuItem.Size = new Size(91, 29);
            menu3ToolStripMenuItem.Text = "Menu3";
            // 
            // menu4ToolStripMenuItem
            // 
            menu4ToolStripMenuItem.Enabled = false;
            menu4ToolStripMenuItem.Name = "menu4ToolStripMenuItem";
            menu4ToolStripMenuItem.Size = new Size(91, 29);
            menu4ToolStripMenuItem.Text = "Menu4";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 48);
            label2.Name = "label2";
            label2.Size = new Size(109, 20);
            label2.TabIndex = 157;
            label2.Text = "【デフォルト表示】";
            // 
            // label_Count
            // 
            label_Count.AutoSize = true;
            label_Count.Location = new Point(442, 108);
            label_Count.Name = "label_Count";
            label_Count.Size = new Size(17, 20);
            label_Count.TabIndex = 163;
            label_Count.Text = "0";
            // 
            // label_33
            // 
            label_33.AutoSize = true;
            label_33.Location = new Point(387, 108);
            label_33.Name = "label_33";
            label_33.Size = new Size(49, 20);
            label_33.TabIndex = 162;
            label_33.Text = "回数=";
            // 
            // button_New_Delete
            // 
            button_New_Delete.Location = new Point(387, 76);
            button_New_Delete.Name = "button_New_Delete";
            button_New_Delete.Size = new Size(94, 29);
            button_New_Delete.TabIndex = 161;
            button_New_Delete.Text = "生成⇒破棄";
            button_New_Delete.UseVisualStyleBackColor = true;
            button_New_Delete.Click += button_New_Delete_Click;
            // 
            // label26
            // 
            label26.AutoSize = true;
            label26.Location = new Point(367, 48);
            label26.Name = "label26";
            label26.Size = new Size(122, 20);
            label26.TabIndex = 160;
            label26.Text = "【メモリリークテスト】";
            // 
            // label_BackColor
            // 
            label_BackColor.AutoSize = true;
            label_BackColor.Location = new Point(124, 148);
            label_BackColor.Name = "label_BackColor";
            label_BackColor.Size = new Size(86, 20);
            label_BackColor.TabIndex = 171;
            label_BackColor.Text = "BackColor=";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(32, 148);
            label9.Name = "label9";
            label9.Size = new Size(86, 20);
            label9.TabIndex = 170;
            label9.Text = "BackColor=";
            // 
            // label_FontColor
            // 
            label_FontColor.AutoSize = true;
            label_FontColor.Location = new Point(124, 123);
            label_FontColor.Name = "label_FontColor";
            label_FontColor.Size = new Size(83, 20);
            label_FontColor.TabIndex = 169;
            label_FontColor.Text = "FontColor=";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(32, 123);
            label7.Name = "label7";
            label7.Size = new Size(83, 20);
            label7.TabIndex = 168;
            label7.Text = "FontColor=";
            // 
            // label_FontSize
            // 
            label_FontSize.AutoSize = true;
            label_FontSize.Location = new Point(124, 98);
            label_FontSize.Name = "label_FontSize";
            label_FontSize.Size = new Size(74, 20);
            label_FontSize.TabIndex = 167;
            label_FontSize.Text = "FontSize=";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(32, 98);
            label5.Name = "label5";
            label5.Size = new Size(74, 20);
            label5.TabIndex = 166;
            label5.Text = "FontSize=";
            // 
            // label_FontType
            // 
            label_FontType.AutoSize = true;
            label_FontType.Location = new Point(124, 73);
            label_FontType.Name = "label_FontType";
            label_FontType.Size = new Size(78, 20);
            label_FontType.TabIndex = 165;
            label_FontType.Text = "FontType=";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(32, 73);
            label3.Name = "label3";
            label3.Size = new Size(78, 20);
            label3.TabIndex = 164;
            label3.Text = "FontType=";
            // 
            // label_CountMashing
            // 
            label_CountMashing.AutoSize = true;
            label_CountMashing.Location = new Point(582, 104);
            label_CountMashing.Name = "label_CountMashing";
            label_CountMashing.Size = new Size(17, 20);
            label_CountMashing.TabIndex = 190;
            label_CountMashing.Text = "0";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(527, 104);
            label6.Name = "label6";
            label6.Size = new Size(49, 20);
            label6.TabIndex = 189;
            label6.Text = "回数=";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(527, 76);
            label8.Name = "label8";
            label8.Size = new Size(39, 20);
            label8.TabIndex = 188;
            label8.Text = "連打";
            // 
            // label_DisableBackColor
            // 
            label_DisableBackColor.AutoSize = true;
            label_DisableBackColor.Location = new Point(174, 248);
            label_DisableBackColor.Name = "label_DisableBackColor";
            label_DisableBackColor.Size = new Size(136, 20);
            label_DisableBackColor.TabIndex = 203;
            label_DisableBackColor.Text = "DisableBackColor=";
            // 
            // label_DisableForeColor
            // 
            label_DisableForeColor.AutoSize = true;
            label_DisableForeColor.Location = new Point(171, 223);
            label_DisableForeColor.Name = "label_DisableForeColor";
            label_DisableForeColor.Size = new Size(133, 20);
            label_DisableForeColor.TabIndex = 202;
            label_DisableForeColor.Text = "DisableForeColor=";
            // 
            // label_HoverBackColor
            // 
            label_HoverBackColor.AutoSize = true;
            label_HoverBackColor.Location = new Point(164, 198);
            label_HoverBackColor.Name = "label_HoverBackColor";
            label_HoverBackColor.Size = new Size(126, 20);
            label_HoverBackColor.TabIndex = 201;
            label_HoverBackColor.Text = "HoverBackColor=";
            // 
            // label_HoverForeColor
            // 
            label_HoverForeColor.AutoSize = true;
            label_HoverForeColor.Location = new Point(161, 173);
            label_HoverForeColor.Name = "label_HoverForeColor";
            label_HoverForeColor.Size = new Size(123, 20);
            label_HoverForeColor.TabIndex = 200;
            label_HoverForeColor.Text = "HoverForeColor=";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(32, 248);
            label11.Name = "label11";
            label11.Size = new Size(136, 20);
            label11.TabIndex = 199;
            label11.Text = "DisableBackColor=";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(32, 223);
            label10.Name = "label10";
            label10.Size = new Size(133, 20);
            label10.TabIndex = 198;
            label10.Text = "DisableForeColor=";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(32, 198);
            label1.Name = "label1";
            label1.Size = new Size(126, 20);
            label1.TabIndex = 197;
            label1.Text = "HoverBackColor=";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(32, 173);
            label4.Name = "label4";
            label4.Size = new Size(123, 20);
            label4.TabIndex = 196;
            label4.Text = "HoverForeColor=";
            // 
            // Form_RdtMenuStrip
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label_DisableBackColor);
            Controls.Add(label_DisableForeColor);
            Controls.Add(label_HoverBackColor);
            Controls.Add(label_HoverForeColor);
            Controls.Add(label11);
            Controls.Add(label10);
            Controls.Add(label1);
            Controls.Add(label4);
            Controls.Add(label_CountMashing);
            Controls.Add(label6);
            Controls.Add(label8);
            Controls.Add(label_BackColor);
            Controls.Add(label9);
            Controls.Add(label_FontColor);
            Controls.Add(label7);
            Controls.Add(label_FontSize);
            Controls.Add(label5);
            Controls.Add(label_FontType);
            Controls.Add(label3);
            Controls.Add(label_Count);
            Controls.Add(label_33);
            Controls.Add(button_New_Delete);
            Controls.Add(label26);
            Controls.Add(label2);
            Controls.Add(rdtMenuStrip1);
            MainMenuStrip = rdtMenuStrip1;
            Name = "Form_RdtMenuStrip";
            Text = "Form_RdtMenuStrip";
            Load += Form_RdtMenuStrip_Load;
            rdtMenuStrip1.ResumeLayout(false);
            rdtMenuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RADISTA.UIComponent.CustomControl.RdtMenuStrip rdtMenuStrip1;
        private ToolStripMenuItem menu1ToolStripMenuItem;
        private ToolStripMenuItem menu11ToolStripMenuItem;
        private ToolStripMenuItem menu111ToolStripMenuItem;
        private ToolStripMenuItem menu12ToolStripMenuItem;
        private ToolStripMenuItem menu2ToolStripMenuItem;
        private ToolStripMenuItem menu3ToolStripMenuItem;
        private ToolStripMenuItem menu21ToolStripMenuItem;
        private Label label2;
        private Label label_Count;
        private Label label_33;
        private Button button_New_Delete;
        private Label label26;
        private Label label_BackColor;
        private Label label9;
        private Label label_FontColor;
        private Label label7;
        private Label label_FontSize;
        private Label label5;
        private Label label_FontType;
        private Label label3;
        private Label label_CountMashing;
        private Label label6;
        private Label label8;
        private ToolStripMenuItem menu4ToolStripMenuItem;
        private Label label_DisableBackColor;
        private Label label_DisableForeColor;
        private Label label_HoverBackColor;
        private Label label_HoverForeColor;
        private Label label11;
        private Label label10;
        private Label label1;
        private Label label4;
    }
}
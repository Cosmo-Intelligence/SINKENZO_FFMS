namespace RADISTA.CustomComponentTestApp
{
    partial class Form_RdtRadioButton
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
            Label_DefaultTitle = new Label();
            Label_Default = new Label();
            Radio_Default = new RADISTA.UIComponent.CustomControl.RdtRadioButton(components);
            Radio_Inactive = new RADISTA.UIComponent.CustomControl.RdtRadioButton(components);
            Label_Inactive = new Label();
            Label_ExpansionTitle = new Label();
            Label_CustomImage = new Label();
            Label_InactiveColor = new Label();
            Label_BackColor = new Label();
            Label_FontColor = new Label();
            Label_FontSize = new Label();
            Label_FontType = new Label();
            Radio_UseCustomImage_true = new RADISTA.UIComponent.CustomControl.RdtRadioButton(components);
            Radio_UseCustomImage_false = new RADISTA.UIComponent.CustomControl.RdtRadioButton(components);
            Label_UseCustomImage_true = new Label();
            Label_UseCustomImage_false = new Label();
            Label_TestCount = new Label();
            Button_Test = new Button();
            Label_MemoryLeak = new Label();
            SuspendLayout();
            // 
            // Label_DefaultTitle
            // 
            Label_DefaultTitle.AutoSize = true;
            Label_DefaultTitle.Location = new Point(12, 9);
            Label_DefaultTitle.Name = "Label_DefaultTitle";
            Label_DefaultTitle.Size = new Size(109, 20);
            Label_DefaultTitle.TabIndex = 0;
            Label_DefaultTitle.Text = "【デフォルト表示】";
            // 
            // Label_Default
            // 
            Label_Default.AutoSize = true;
            Label_Default.Location = new Point(12, 38);
            Label_Default.Name = "Label_Default";
            Label_Default.Size = new Size(63, 20);
            Label_Default.TabIndex = 1;
            Label_Default.Text = "デフォルト";
            // 
            // Radio_Default
            // 
            Radio_Default.AutoSize = true;
            Radio_Default.BackColor = Color.FromArgb(57, 57, 57);
            Radio_Default.CheckedImagePath = "";
            Radio_Default.Font = new Font("Meiryo UI", 12F);
            Radio_Default.ForeColor = Color.FromArgb(195, 195, 195);
            Radio_Default.Location = new Point(12, 61);
            Radio_Default.MouseClickColor = "#00FF00";
            Radio_Default.MouseHoverColor = "#FF0000";
            Radio_Default.Name = "Radio_Default";
            Radio_Default.Size = new Size(104, 29);
            Radio_Default.TabIndex = 2;
            Radio_Default.TabStop = true;
            Radio_Default.Text = "Default";
            Radio_Default.UncheckedImagePath = "";
            Radio_Default.UseCustomImage = false;
            Radio_Default.UseVisualStyleBackColor = false;
            // 
            // Radio_Inactive
            // 
            Radio_Inactive.AutoSize = true;
            Radio_Inactive.BackColor = Color.FromArgb(57, 57, 57);
            Radio_Inactive.CheckedImagePath = "";
            Radio_Inactive.Enabled = false;
            Radio_Inactive.Font = new Font("Meiryo UI", 12F);
            Radio_Inactive.ForeColor = Color.FromArgb(195, 195, 195);
            Radio_Inactive.Location = new Point(207, 61);
            Radio_Inactive.MouseClickColor = "#00FF00";
            Radio_Inactive.MouseHoverColor = "#FF0000";
            Radio_Inactive.Name = "Radio_Inactive";
            Radio_Inactive.Size = new Size(111, 29);
            Radio_Inactive.TabIndex = 3;
            Radio_Inactive.TabStop = true;
            Radio_Inactive.Text = "Inactive";
            Radio_Inactive.UncheckedImagePath = "";
            Radio_Inactive.UseCustomImage = false;
            Radio_Inactive.UseVisualStyleBackColor = false;
            // 
            // Label_Inactive
            // 
            Label_Inactive.AutoSize = true;
            Label_Inactive.Location = new Point(207, 38);
            Label_Inactive.Name = "Label_Inactive";
            Label_Inactive.Size = new Size(60, 20);
            Label_Inactive.TabIndex = 4;
            Label_Inactive.Text = "Inactive";
            // 
            // Label_ExpansionTitle
            // 
            Label_ExpansionTitle.AutoSize = true;
            Label_ExpansionTitle.Location = new Point(12, 200);
            Label_ExpansionTitle.Name = "Label_ExpansionTitle";
            Label_ExpansionTitle.Size = new Size(92, 20);
            Label_ExpansionTitle.TabIndex = 5;
            Label_ExpansionTitle.Text = "拡張プロパティ";
            // 
            // Label_CustomImage
            // 
            Label_CustomImage.AutoSize = true;
            Label_CustomImage.Location = new Point(12, 230);
            Label_CustomImage.Name = "Label_CustomImage";
            Label_CustomImage.Size = new Size(125, 20);
            Label_CustomImage.TabIndex = 6;
            Label_CustomImage.Text = "UseCustomImage";
            // 
            // Label_InactiveColor
            // 
            Label_InactiveColor.AutoSize = true;
            Label_InactiveColor.Location = new Point(207, 103);
            Label_InactiveColor.Name = "Label_InactiveColor";
            Label_InactiveColor.Size = new Size(114, 20);
            Label_InactiveColor.TabIndex = 14;
            Label_InactiveColor.Text = "InactiveColor = ";
            // 
            // Label_BackColor
            // 
            Label_BackColor.AutoSize = true;
            Label_BackColor.Location = new Point(12, 163);
            Label_BackColor.Name = "Label_BackColor";
            Label_BackColor.Size = new Size(94, 20);
            Label_BackColor.TabIndex = 13;
            Label_BackColor.Text = "BackColor = ";
            // 
            // Label_FontColor
            // 
            Label_FontColor.AutoSize = true;
            Label_FontColor.Location = new Point(12, 143);
            Label_FontColor.Name = "Label_FontColor";
            Label_FontColor.Size = new Size(91, 20);
            Label_FontColor.TabIndex = 12;
            Label_FontColor.Text = "FontColor = ";
            // 
            // Label_FontSize
            // 
            Label_FontSize.AutoSize = true;
            Label_FontSize.Location = new Point(12, 123);
            Label_FontSize.Name = "Label_FontSize";
            Label_FontSize.Size = new Size(82, 20);
            Label_FontSize.TabIndex = 11;
            Label_FontSize.Text = "FontSize = ";
            // 
            // Label_FontType
            // 
            Label_FontType.AutoSize = true;
            Label_FontType.Location = new Point(12, 103);
            Label_FontType.Name = "Label_FontType";
            Label_FontType.Size = new Size(86, 20);
            Label_FontType.TabIndex = 10;
            Label_FontType.Text = "FontType = ";
            // 
            // Radio_UseCustomImage_true
            // 
            Radio_UseCustomImage_true.AutoSize = true;
            Radio_UseCustomImage_true.BackColor = Color.FromArgb(57, 57, 57);
            Radio_UseCustomImage_true.CheckedImagePath = "..\\..\\..\\..\\Image\\Checked.png";
            Radio_UseCustomImage_true.Font = new Font("Meiryo UI", 12F);
            Radio_UseCustomImage_true.ForeColor = Color.FromArgb(195, 195, 195);
            Radio_UseCustomImage_true.Location = new Point(27, 253);
            Radio_UseCustomImage_true.MouseClickColor = "#00FF00";
            Radio_UseCustomImage_true.MouseHoverColor = "#FF0000";
            Radio_UseCustomImage_true.Name = "Radio_UseCustomImage_true";
            Radio_UseCustomImage_true.Size = new Size(76, 29);
            Radio_UseCustomImage_true.TabIndex = 15;
            Radio_UseCustomImage_true.TabStop = true;
            Radio_UseCustomImage_true.Text = "True";
            Radio_UseCustomImage_true.UncheckedImagePath = "..\\..\\..\\..\\Image\\UnChecked.png";
            Radio_UseCustomImage_true.UseCustomImage = true;
            Radio_UseCustomImage_true.UseVisualStyleBackColor = false;
            // 
            // Radio_UseCustomImage_false
            // 
            Radio_UseCustomImage_false.AutoSize = true;
            Radio_UseCustomImage_false.BackColor = Color.FromArgb(57, 57, 57);
            Radio_UseCustomImage_false.CheckedImagePath = "C:\\Users\\n_uehara\\Downloads\\CustomComponentTestApp\\CustomComponentTestApp\\Image\\Checked.png";
            Radio_UseCustomImage_false.Font = new Font("Meiryo UI", 12F);
            Radio_UseCustomImage_false.ForeColor = Color.FromArgb(195, 195, 195);
            Radio_UseCustomImage_false.Location = new Point(268, 253);
            Radio_UseCustomImage_false.MouseClickColor = "#00FF00";
            Radio_UseCustomImage_false.MouseHoverColor = "#FF0000";
            Radio_UseCustomImage_false.Name = "Radio_UseCustomImage_false";
            Radio_UseCustomImage_false.Size = new Size(82, 29);
            Radio_UseCustomImage_false.TabIndex = 16;
            Radio_UseCustomImage_false.TabStop = true;
            Radio_UseCustomImage_false.Text = "False";
            Radio_UseCustomImage_false.UncheckedImagePath = "C:\\Users\\n_uehara\\Downloads\\CustomComponentTestApp\\CustomComponentTestApp\\Image\\UnChecked.png";
            Radio_UseCustomImage_false.UseCustomImage = false;
            Radio_UseCustomImage_false.UseVisualStyleBackColor = false;
            // 
            // Label_UseCustomImage_true
            // 
            Label_UseCustomImage_true.AutoSize = true;
            Label_UseCustomImage_true.Location = new Point(27, 285);
            Label_UseCustomImage_true.Name = "Label_UseCustomImage_true";
            Label_UseCustomImage_true.Size = new Size(143, 20);
            Label_UseCustomImage_true.TabIndex = 17;
            Label_UseCustomImage_true.Text = "UseCustomImage = ";
            // 
            // Label_UseCustomImage_false
            // 
            Label_UseCustomImage_false.AutoSize = true;
            Label_UseCustomImage_false.Location = new Point(268, 285);
            Label_UseCustomImage_false.Name = "Label_UseCustomImage_false";
            Label_UseCustomImage_false.Size = new Size(143, 20);
            Label_UseCustomImage_false.TabIndex = 18;
            Label_UseCustomImage_false.Text = "UseCustomImage = ";
            // 
            // Label_TestCount
            // 
            Label_TestCount.AutoSize = true;
            Label_TestCount.Location = new Point(1598, 108);
            Label_TestCount.Name = "Label_TestCount";
            Label_TestCount.Size = new Size(65, 20);
            Label_TestCount.TabIndex = 101;
            Label_TestCount.Text = "回数 = 0";
            // 
            // Button_Test
            // 
            Button_Test.Location = new Point(1598, 67);
            Button_Test.Name = "Button_Test";
            Button_Test.Size = new Size(94, 29);
            Button_Test.TabIndex = 100;
            Button_Test.Text = "生成->破棄";
            Button_Test.UseVisualStyleBackColor = true;
            Button_Test.Click += Button_Test_Click;
            // 
            // Label_MemoryLeak
            // 
            Label_MemoryLeak.AutoSize = true;
            Label_MemoryLeak.Location = new Point(1598, 38);
            Label_MemoryLeak.Name = "Label_MemoryLeak";
            Label_MemoryLeak.Size = new Size(122, 20);
            Label_MemoryLeak.TabIndex = 99;
            Label_MemoryLeak.Text = "【メモリリークテスト】";
            // 
            // Form_RdtRadioButton
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1924, 1055);
            Controls.Add(Label_TestCount);
            Controls.Add(Button_Test);
            Controls.Add(Label_MemoryLeak);
            Controls.Add(Label_UseCustomImage_false);
            Controls.Add(Label_UseCustomImage_true);
            Controls.Add(Radio_UseCustomImage_false);
            Controls.Add(Radio_UseCustomImage_true);
            Controls.Add(Label_InactiveColor);
            Controls.Add(Label_BackColor);
            Controls.Add(Label_FontColor);
            Controls.Add(Label_FontSize);
            Controls.Add(Label_FontType);
            Controls.Add(Label_CustomImage);
            Controls.Add(Label_ExpansionTitle);
            Controls.Add(Label_Inactive);
            Controls.Add(Radio_Inactive);
            Controls.Add(Radio_Default);
            Controls.Add(Label_Default);
            Controls.Add(Label_DefaultTitle);
            Name = "Form_RdtRadioButton";
            Text = "Form_RdtRadioButton";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Label_DefaultTitle;
        private Label Label_Default;
        private RADISTA.UIComponent.CustomControl.RdtRadioButton Radio_Default;
        private RADISTA.UIComponent.CustomControl.RdtRadioButton Radio_Inactive;
        private Label Label_Inactive;
        private Label Label_ExpansionTitle;
        private Label Label_CustomImage;
        private Label Label_InactiveColor;
        private Label Label_BackColor;
        private Label Label_FontColor;
        private Label Label_FontSize;
        private Label Label_FontType;
        private RADISTA.UIComponent.CustomControl.RdtRadioButton Radio_UseCustomImage_true;
        private RADISTA.UIComponent.CustomControl.RdtRadioButton Radio_UseCustomImage_false;
        private Label Label_UseCustomImage_true;
        private Label Label_UseCustomImage_false;
        private Label Label_TestCount;
        private Button Button_Test;
        private Label Label_MemoryLeak;
    }
}
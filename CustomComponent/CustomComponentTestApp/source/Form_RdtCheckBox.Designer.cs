namespace RADISTA.CustomComponentTestApp
{
    partial class Form_RdtCheckBox
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
            Check_Default = new RADISTA.UIComponent.CustomControl.RdtCheckBox(components);
            Check_Inactive = new RADISTA.UIComponent.CustomControl.RdtCheckBox(components);
            Label_Inactive = new Label();
            Label_ExpansionTitle = new Label();
            Label_CustomImage = new Label();
            Label_InactiveColor = new Label();
            Label_BackColor = new Label();
            Label_FontColor = new Label();
            Label_FontSize = new Label();
            Label_FontType = new Label();
            Check_UseCustomImage_true = new RADISTA.UIComponent.CustomControl.RdtCheckBox(components);
            Check_UseCustomImage_false = new RADISTA.UIComponent.CustomControl.RdtCheckBox(components);
            Label_UseCustomImage_true = new Label();
            Label_UseCustomImage_false = new Label();
            Label_TestCount = new Label();
            Button_Test = new Button();
            Label_MemoryLeak = new Label();
            Label_ImageFilePath = new Label();
            Check_ImageFilePath_Found = new RADISTA.UIComponent.CustomControl.RdtCheckBox(components);
            Check_ImageFilePath_NotFound = new RADISTA.UIComponent.CustomControl.RdtCheckBox(components);
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
            // Check_Default
            // 
            Check_Default.AutoSize = true;
            Check_Default.BackColor = Color.FromArgb(57, 57, 57);
            Check_Default.CheckedImagePath = "";
            Check_Default.Font = new Font("Meiryo UI", 12F);
            Check_Default.ForeColor = Color.FromArgb(195, 195, 195);
            Check_Default.IndeterminateImagePath = "";
            Check_Default.Location = new Point(12, 61);
            Check_Default.MouseClickColor = "#00FF00";
            Check_Default.MouseHoverColor = "#FF0000";
            Check_Default.Name = "Check_Default";
            Check_Default.Size = new Size(105, 29);
            Check_Default.TabIndex = 2;
            Check_Default.Text = "Default";
            Check_Default.UncheckedImagePath = "";
            Check_Default.UseCustomImage = false;
            Check_Default.UseVisualStyleBackColor = false;
            // 
            // Check_Inactive
            // 
            Check_Inactive.AutoSize = true;
            Check_Inactive.BackColor = Color.FromArgb(57, 57, 57);
            Check_Inactive.CheckedImagePath = "";
            Check_Inactive.Enabled = false;
            Check_Inactive.Font = new Font("Meiryo UI", 12F);
            Check_Inactive.ForeColor = Color.FromArgb(195, 195, 195);
            Check_Inactive.IndeterminateImagePath = "";
            Check_Inactive.Location = new Point(207, 61);
            Check_Inactive.MouseClickColor = "#00FF00";
            Check_Inactive.MouseHoverColor = "#FF0000";
            Check_Inactive.Name = "Check_Inactive";
            Check_Inactive.Size = new Size(112, 29);
            Check_Inactive.TabIndex = 3;
            Check_Inactive.Text = "Inactive";
            Check_Inactive.UncheckedImagePath = "";
            Check_Inactive.UseCustomImage = false;
            Check_Inactive.UseVisualStyleBackColor = false;
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
            // Check_UseCustomImage_true
            // 
            Check_UseCustomImage_true.AutoSize = true;
            Check_UseCustomImage_true.BackColor = Color.FromArgb(57, 57, 57);
            Check_UseCustomImage_true.CheckedImagePath = "..\\..\\..\\..\\Image\\Checked.png";
            Check_UseCustomImage_true.Font = new Font("Meiryo UI", 12F);
            Check_UseCustomImage_true.ForeColor = Color.FromArgb(195, 195, 195);
            Check_UseCustomImage_true.IndeterminateImagePath = "..\\..\\..\\..\\Image\\Indeterminate.png";
            Check_UseCustomImage_true.Location = new Point(27, 253);
            Check_UseCustomImage_true.MouseClickColor = "#00FF00";
            Check_UseCustomImage_true.MouseHoverColor = "#FF0000";
            Check_UseCustomImage_true.Name = "Check_UseCustomImage_true";
            Check_UseCustomImage_true.Size = new Size(77, 29);
            Check_UseCustomImage_true.TabIndex = 15;
            Check_UseCustomImage_true.Text = "True";
            Check_UseCustomImage_true.UncheckedImagePath = "..\\..\\..\\..\\Image\\UnChecked.png";
            Check_UseCustomImage_true.UseCustomImage = true;
            Check_UseCustomImage_true.UseVisualStyleBackColor = false;
            // 
            // Check_UseCustomImage_false
            // 
            Check_UseCustomImage_false.AutoSize = true;
            Check_UseCustomImage_false.BackColor = Color.FromArgb(57, 57, 57);
            Check_UseCustomImage_false.CheckedImagePath = "..\\..\\..\\..\\Image\\Checked.png";
            Check_UseCustomImage_false.Font = new Font("Meiryo UI", 12F);
            Check_UseCustomImage_false.ForeColor = Color.FromArgb(195, 195, 195);
            Check_UseCustomImage_false.IndeterminateImagePath = "..\\..\\..\\..\\Image\\Indeterminate.png";
            Check_UseCustomImage_false.Location = new Point(207, 253);
            Check_UseCustomImage_false.MouseClickColor = "#00FF00";
            Check_UseCustomImage_false.MouseHoverColor = "#FF0000";
            Check_UseCustomImage_false.Name = "Check_UseCustomImage_false";
            Check_UseCustomImage_false.Size = new Size(83, 29);
            Check_UseCustomImage_false.TabIndex = 16;
            Check_UseCustomImage_false.Text = "False";
            Check_UseCustomImage_false.UncheckedImagePath = "..\\..\\..\\..\\Image\\UnChecked.png";
            Check_UseCustomImage_false.UseCustomImage = false;
            Check_UseCustomImage_false.UseVisualStyleBackColor = false;
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
            Label_UseCustomImage_false.Location = new Point(207, 285);
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
            // Label_ImageFilePath
            // 
            Label_ImageFilePath.AutoSize = true;
            Label_ImageFilePath.ImageAlign = ContentAlignment.BottomCenter;
            Label_ImageFilePath.Location = new Point(12, 318);
            Label_ImageFilePath.Name = "Label_ImageFilePath";
            Label_ImageFilePath.Size = new Size(103, 20);
            Label_ImageFilePath.TabIndex = 102;
            Label_ImageFilePath.Text = "ImageFilePath";
            // 
            // Check_ImageFilePath_Found
            // 
            Check_ImageFilePath_Found.AutoSize = true;
            Check_ImageFilePath_Found.BackColor = Color.FromArgb(57, 57, 57);
            Check_ImageFilePath_Found.CheckedImagePath = "..\\..\\..\\..\\Image\\Checked.png";
            Check_ImageFilePath_Found.Font = new Font("Meiryo UI", 12F);
            Check_ImageFilePath_Found.ForeColor = Color.FromArgb(195, 195, 195);
            Check_ImageFilePath_Found.IndeterminateImagePath = "..\\..\\..\\..\\Image\\Indeterminate.png";
            Check_ImageFilePath_Found.Location = new Point(25, 341);
            Check_ImageFilePath_Found.MouseClickColor = "#00FF00";
            Check_ImageFilePath_Found.MouseHoverColor = "#FF0000";
            Check_ImageFilePath_Found.Name = "Check_ImageFilePath_Found";
            Check_ImageFilePath_Found.Size = new Size(93, 29);
            Check_ImageFilePath_Found.TabIndex = 103;
            Check_ImageFilePath_Found.Text = "Found";
            Check_ImageFilePath_Found.ThreeState = true;
            Check_ImageFilePath_Found.UncheckedImagePath = "..\\..\\..\\..\\Image\\UnChecked.png";
            Check_ImageFilePath_Found.UseCustomImage = true;
            Check_ImageFilePath_Found.UseVisualStyleBackColor = false;
            // 
            // Check_ImageFilePath_NotFound
            // 
            Check_ImageFilePath_NotFound.AutoSize = true;
            Check_ImageFilePath_NotFound.BackColor = Color.FromArgb(57, 57, 57);
            Check_ImageFilePath_NotFound.CheckedImagePath = "..\\..\\..\\..\\Image\\Checked.png";
            Check_ImageFilePath_NotFound.Font = new Font("Meiryo UI", 12F);
            Check_ImageFilePath_NotFound.ForeColor = Color.FromArgb(195, 195, 195);
            Check_ImageFilePath_NotFound.IndeterminateImagePath = "..\\..\\..\\..\\Image\\Indeterminate.png";
            Check_ImageFilePath_NotFound.Location = new Point(220, 341);
            Check_ImageFilePath_NotFound.MouseClickColor = "#00FF00";
            Check_ImageFilePath_NotFound.MouseHoverColor = "#FF0000";
            Check_ImageFilePath_NotFound.Name = "Check_ImageFilePath_NotFound";
            Check_ImageFilePath_NotFound.Size = new Size(128, 29);
            Check_ImageFilePath_NotFound.TabIndex = 104;
            Check_ImageFilePath_NotFound.Text = "NotFound";
            Check_ImageFilePath_NotFound.ThreeState = true;
            Check_ImageFilePath_NotFound.UncheckedImagePath = "NotFoundImagePath";
            Check_ImageFilePath_NotFound.UseCustomImage = true;
            Check_ImageFilePath_NotFound.UseVisualStyleBackColor = false;
            // 
            // Form_RdtCheckBox
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1924, 1055);
            Controls.Add(Check_ImageFilePath_NotFound);
            Controls.Add(Check_ImageFilePath_Found);
            Controls.Add(Label_ImageFilePath);
            Controls.Add(Label_TestCount);
            Controls.Add(Button_Test);
            Controls.Add(Label_MemoryLeak);
            Controls.Add(Label_UseCustomImage_false);
            Controls.Add(Label_UseCustomImage_true);
            Controls.Add(Check_UseCustomImage_false);
            Controls.Add(Check_UseCustomImage_true);
            Controls.Add(Label_InactiveColor);
            Controls.Add(Label_BackColor);
            Controls.Add(Label_FontColor);
            Controls.Add(Label_FontSize);
            Controls.Add(Label_FontType);
            Controls.Add(Label_CustomImage);
            Controls.Add(Label_ExpansionTitle);
            Controls.Add(Label_Inactive);
            Controls.Add(Check_Inactive);
            Controls.Add(Check_Default);
            Controls.Add(Label_Default);
            Controls.Add(Label_DefaultTitle);
            Name = "Form_RdtCheckBox";
            Text = "Form_RdtCheckBox";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Label_DefaultTitle;
        private Label Label_Default;
        private RADISTA.UIComponent.CustomControl.RdtCheckBox Check_Default;
        private RADISTA.UIComponent.CustomControl.RdtCheckBox Check_Inactive;
        private Label Label_Inactive;
        private Label Label_ExpansionTitle;
        private Label Label_CustomImage;
        private Label Label_InactiveColor;
        private Label Label_BackColor;
        private Label Label_FontColor;
        private Label Label_FontSize;
        private Label Label_FontType;
        private RADISTA.UIComponent.CustomControl.RdtCheckBox Check_UseCustomImage_true;
        private RADISTA.UIComponent.CustomControl.RdtCheckBox Check_UseCustomImage_false;
        private Label Label_UseCustomImage_true;
        private Label Label_UseCustomImage_false;
        private Label Label_TestCount;
        private Button Button_Test;
        private Label Label_MemoryLeak;
        private Label Label_ImageFilePath;
        private RADISTA.UIComponent.CustomControl.RdtCheckBox Check_ImageFilePath_Found;
        private RADISTA.UIComponent.CustomControl.RdtCheckBox Check_ImageFilePath_NotFound;
    }
}
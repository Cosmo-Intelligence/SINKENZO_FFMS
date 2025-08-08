namespace CustomComponentTestApp.source
{
    partial class Form_RdtListButton
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
            List_Under = new RADISTA.SPREAD.CustomControl.RdtListButton(components);
            Label_UnderOpen = new Label();
            List_Upper = new RADISTA.SPREAD.CustomControl.RdtListButton(components);
            Label_Upper = new Label();
            Label_TestCount = new Label();
            Button_Test = new Button();
            Label_MemoryLeak = new Label();
            SuspendLayout();
            // 
            // List_Under
            // 
            List_Under.BorderThick = 1;
            List_Under.ButtonText = "下へ開く";
            List_Under.CornerRadius = 8;
            List_Under.DrawStyle = RADISTA.SPREAD.CustomControl.RdtListButton.DrawStyleT.Standard;
            List_Under.DropdownHeight = 150;
            List_Under.ImageFilePath = "";
            List_Under.InnerBorderColor = "#808080";
            List_Under.IsUpperDrop = false;
            List_Under.ListAlternateColor = "#123456";
            List_Under.ListBorderColor = "#262626";
            List_Under.ListBorderThick = 1;
            List_Under.ListCellBackColor = "#363636";
            List_Under.ListDisableBackColor = "#262626";
            List_Under.ListDisableForeColor = "#555555";
            List_Under.ListDrawStyle = RADISTA.SPREAD.CustomControl.RdtListButton.DrawStyleT.Standard;
            List_Under.ListFlatBackColor = "#262626";
            List_Under.ListFontColor = "#C4C4C4";
            List_Under.ListHoverBackColor = "#464646";
            List_Under.ListHoverBorderColor = "#5A5A5A";
            List_Under.ListLeftBottomCornerRadius = 8;
            List_Under.ListLeftTopCornerRadius = 8;
            List_Under.ListRightBottomCornerRadius = 8;
            List_Under.ListRightTopCornerRadius = 8;
            List_Under.ListUseAlternateColor = false;
            List_Under.Location = new Point(12, 32);
            List_Under.MouseClickColor = "#00FF00";
            List_Under.MouseHoverColor = "#FF0000";
            List_Under.Name = "List_Under";
            List_Under.OuterBorderColor = "#C3C3C3";
            List_Under.SelectedIndex = -1;
            List_Under.Size = new Size(188, 38);
            List_Under.TabIndex = 0;
            List_Under.TextJustify = RADISTA.UIComponent.CustomControl.RdtButton.TextJustifyT.NONE;
            List_Under.TextOrientation = RADISTA.UIComponent.CustomControl.RdtButton.TextOrientationT.HORIZONTAL;
            // 
            // Label_UnderOpen
            // 
            Label_UnderOpen.AutoSize = true;
            Label_UnderOpen.Location = new Point(12, 9);
            Label_UnderOpen.Name = "Label_UnderOpen";
            Label_UnderOpen.Size = new Size(60, 20);
            Label_UnderOpen.TabIndex = 1;
            Label_UnderOpen.Text = "下へ開く";
            // 
            // List_Upper
            // 
            List_Upper.BorderThick = 1;
            List_Upper.ButtonText = "上へ開く";
            List_Upper.CornerRadius = 8;
            List_Upper.DrawStyle = RADISTA.SPREAD.CustomControl.RdtListButton.DrawStyleT.Standard;
            List_Upper.DropdownHeight = 150;
            List_Upper.ImageFilePath = "";
            List_Upper.InnerBorderColor = "#808080";
            List_Upper.IsUpperDrop = false;
            List_Upper.ListAlternateColor = "#123456";
            List_Upper.ListBorderColor = "#262626";
            List_Upper.ListBorderThick = 1;
            List_Upper.ListCellBackColor = "#363636";
            List_Upper.ListDisableBackColor = "#262626";
            List_Upper.ListDisableForeColor = "#555555";
            List_Upper.ListDrawStyle = RADISTA.SPREAD.CustomControl.RdtListButton.DrawStyleT.Standard;
            List_Upper.ListFlatBackColor = "#262626";
            List_Upper.ListFontColor = "#C4C4C4";
            List_Upper.ListHoverBackColor = "#464646";
            List_Upper.ListHoverBorderColor = "#5A5A5A";
            List_Upper.ListLeftBottomCornerRadius = 8;
            List_Upper.ListLeftTopCornerRadius = 8;
            List_Upper.ListRightBottomCornerRadius = 8;
            List_Upper.ListRightTopCornerRadius = 8;
            List_Upper.ListUseAlternateColor = false;
            List_Upper.Location = new Point(12, 400);
            List_Upper.MouseClickColor = "#00FF00";
            List_Upper.MouseHoverColor = "#FF0000";
            List_Upper.Name = "List_Upper";
            List_Upper.OuterBorderColor = "#C3C3C3";
            List_Upper.SelectedIndex = -1;
            List_Upper.Size = new Size(188, 38);
            List_Upper.TabIndex = 2;
            List_Upper.TextJustify = RADISTA.UIComponent.CustomControl.RdtButton.TextJustifyT.NONE;
            List_Upper.TextOrientation = RADISTA.UIComponent.CustomControl.RdtButton.TextOrientationT.HORIZONTAL;
            // 
            // Label_Upper
            // 
            Label_Upper.AutoSize = true;
            Label_Upper.Location = new Point(12, 377);
            Label_Upper.Name = "Label_Upper";
            Label_Upper.Size = new Size(60, 20);
            Label_Upper.TabIndex = 3;
            Label_Upper.Text = "上へ開く";
            // 
            // Label_TestCount
            // 
            Label_TestCount.AutoSize = true;
            Label_TestCount.Location = new Point(657, 102);
            Label_TestCount.Name = "Label_TestCount";
            Label_TestCount.Size = new Size(65, 20);
            Label_TestCount.TabIndex = 104;
            Label_TestCount.Text = "回数 = 0";
            // 
            // Button_Test
            // 
            Button_Test.Location = new Point(657, 61);
            Button_Test.Name = "Button_Test";
            Button_Test.Size = new Size(94, 29);
            Button_Test.TabIndex = 103;
            Button_Test.Text = "生成->破棄";
            Button_Test.UseVisualStyleBackColor = true;
            Button_Test.Click += this.Button_Test_Click;
            // 
            // Label_MemoryLeak
            // 
            Label_MemoryLeak.AutoSize = true;
            Label_MemoryLeak.Location = new Point(657, 32);
            Label_MemoryLeak.Name = "Label_MemoryLeak";
            Label_MemoryLeak.Size = new Size(122, 20);
            Label_MemoryLeak.TabIndex = 102;
            Label_MemoryLeak.Text = "【メモリリークテスト】";
            // 
            // Form_ListButton
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(Label_TestCount);
            Controls.Add(Button_Test);
            Controls.Add(Label_MemoryLeak);
            Controls.Add(Label_Upper);
            Controls.Add(List_Upper);
            Controls.Add(List_Under);
            Controls.Add(Label_UnderOpen);
            Name = "Form_ListButton";
            Text = "Form_ListButton";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RADISTA.SPREAD.CustomControl.RdtListButton List_Under;
        private Label Label_UnderOpen;
        private RADISTA.SPREAD.CustomControl.RdtListButton List_Upper;
        private Label Label_Upper;
        private Label Label_TestCount;
        private Button Button_Test;
        private Label Label_MemoryLeak;
    }
}
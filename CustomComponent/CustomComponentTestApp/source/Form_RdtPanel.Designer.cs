﻿namespace RADISTA.CustomComponentTestApp
{
    partial class Form_RdtPanel
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
            label2 = new Label();
            label_BackColor = new Label();
            label3 = new Label();
            label_Count = new Label();
            label_2 = new Label();
            button_New_Delete = new Button();
            label1 = new Label();
            rdtPanel1 = new RADISTA.UIComponent.CustomControl.RdtPanel(components);
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(359, 9);
            label2.Name = "label2";
            label2.Size = new Size(109, 20);
            label2.TabIndex = 163;
            label2.Text = "【デフォルト表示】";
            // 
            // label_BackColor
            // 
            label_BackColor.AutoSize = true;
            label_BackColor.Location = new Point(471, 37);
            label_BackColor.Name = "label_BackColor";
            label_BackColor.Size = new Size(86, 20);
            label_BackColor.TabIndex = 162;
            label_BackColor.Text = "BackColor=";
            label_BackColor.TextAlign = ContentAlignment.TopCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(379, 37);
            label3.Name = "label3";
            label3.Size = new Size(86, 20);
            label3.TabIndex = 159;
            label3.Text = "BackColor=";
            label3.TextAlign = ContentAlignment.TopCenter;
            // 
            // label_Count
            // 
            label_Count.AutoSize = true;
            label_Count.Location = new Point(434, 160);
            label_Count.Name = "label_Count";
            label_Count.Size = new Size(17, 20);
            label_Count.TabIndex = 158;
            label_Count.Text = "0";
            // 
            // label_2
            // 
            label_2.AutoSize = true;
            label_2.Location = new Point(379, 160);
            label_2.Name = "label_2";
            label_2.Size = new Size(49, 20);
            label_2.TabIndex = 157;
            label_2.Text = "回数=";
            // 
            // button_New_Delete
            // 
            button_New_Delete.Location = new Point(379, 128);
            button_New_Delete.Name = "button_New_Delete";
            button_New_Delete.Size = new Size(94, 29);
            button_New_Delete.TabIndex = 156;
            button_New_Delete.Text = "生成⇒破棄";
            button_New_Delete.UseVisualStyleBackColor = true;
            button_New_Delete.Click += button_New_Delete_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(359, 100);
            label1.Name = "label1";
            label1.Size = new Size(122, 20);
            label1.TabIndex = 155;
            label1.Text = "【メモリリークテスト】";
            // 
            // rdtPanel1
            // 
            rdtPanel1.Location = new Point(12, 12);
            rdtPanel1.Name = "rdtPanel1";
            rdtPanel1.Size = new Size(250, 262);
            rdtPanel1.TabIndex = 164;
            // 
            // Form_RdtPanel
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(rdtPanel1);
            Controls.Add(label2);
            Controls.Add(label_BackColor);
            Controls.Add(label3);
            Controls.Add(label_Count);
            Controls.Add(label_2);
            Controls.Add(button_New_Delete);
            Controls.Add(label1);
            Name = "Form_RdtPanel";
            Text = "Form_RdtPanel";
            Load += Form_RdtPanel_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private Label label_BackColor;
        private Label label3;
        private Label label_Count;
        private Label label_2;
        private Button button_New_Delete;
        private Label label1;
        private RADISTA.UIComponent.CustomControl.RdtPanel rdtPanel1;
    }
}
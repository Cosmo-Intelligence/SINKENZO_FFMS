namespace RADISTA.CustomComponentTestApp
{
    partial class Form_RdtSplitter
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
            label2 = new Label();
            label_Count = new Label();
            label_2 = new Label();
            button_New_Delete = new Button();
            label1 = new Label();
            label_ComponentEdgeColor = new Label();
            label5 = new Label();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(476, 9);
            label2.Name = "label2";
            label2.Size = new Size(109, 20);
            label2.TabIndex = 170;
            label2.Text = "【デフォルト表示】";
            // 
            // label_Count
            // 
            label_Count.AutoSize = true;
            label_Count.Location = new Point(551, 160);
            label_Count.Name = "label_Count";
            label_Count.Size = new Size(17, 20);
            label_Count.TabIndex = 167;
            label_Count.Text = "0";
            // 
            // label_2
            // 
            label_2.AutoSize = true;
            label_2.Location = new Point(496, 160);
            label_2.Name = "label_2";
            label_2.Size = new Size(49, 20);
            label_2.TabIndex = 166;
            label_2.Text = "回数=";
            // 
            // button_New_Delete
            // 
            button_New_Delete.Location = new Point(496, 128);
            button_New_Delete.Name = "button_New_Delete";
            button_New_Delete.Size = new Size(94, 29);
            button_New_Delete.TabIndex = 165;
            button_New_Delete.Text = "生成⇒破棄";
            button_New_Delete.UseVisualStyleBackColor = true;
            button_New_Delete.Click += button_New_Delete_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(476, 100);
            label1.Name = "label1";
            label1.Size = new Size(122, 20);
            label1.TabIndex = 164;
            label1.Text = "【メモリリークテスト】";
            // 
            // label_ComponentEdgeColor
            // 
            label_ComponentEdgeColor.AutoSize = true;
            label_ComponentEdgeColor.Location = new Point(669, 34);
            label_ComponentEdgeColor.Name = "label_ComponentEdgeColor";
            label_ComponentEdgeColor.Size = new Size(167, 20);
            label_ComponentEdgeColor.TabIndex = 172;
            label_ComponentEdgeColor.Text = "ComponentEdgeColor=";
            label_ComponentEdgeColor.TextAlign = ContentAlignment.TopCenter;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(496, 34);
            label5.Name = "label5";
            label5.Size = new Size(167, 20);
            label5.TabIndex = 171;
            label5.Text = "ComponentEdgeColor=";
            label5.TextAlign = ContentAlignment.TopCenter;
            // 
            // Form_RdtSplitter
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(945, 450);
            Controls.Add(label_ComponentEdgeColor);
            Controls.Add(label5);
            Controls.Add(label2);
            Controls.Add(label_Count);
            Controls.Add(label_2);
            Controls.Add(button_New_Delete);
            Controls.Add(label1);
            Name = "Form_RdtSplitter";
            Text = "Form_RdtSplitter";
            Load += Form_RdtSplitter_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private Label label_Count;
        private Label label_2;
        private Button button_New_Delete;
        private Label label1;
        private Label label_ComponentEdgeColor;
        private Label label5;
    }
}
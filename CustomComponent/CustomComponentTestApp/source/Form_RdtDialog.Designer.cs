namespace RADISTA.CustomComponentTestApp
{
    partial class Form_RdtDialog
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
            label_Count = new Label();
            label_33 = new Label();
            button_New_Delete = new Button();
            label25 = new Label();
            SuspendLayout();
            // 
            // label_Count
            // 
            label_Count.AutoSize = true;
            label_Count.Location = new Point(733, 103);
            label_Count.Name = "label_Count";
            label_Count.Size = new Size(19, 20);
            label_Count.TabIndex = 196;
            label_Count.Text = "0";
            // 
            // label_33
            // 
            label_33.AutoSize = true;
            label_33.Location = new Point(680, 103);
            label_33.Name = "label_33";
            label_33.Size = new Size(54, 20);
            label_33.TabIndex = 195;
            label_33.Text = "回数=";
            // 
            // button_New_Delete
            // 
            button_New_Delete.ForeColor = Color.FromArgb(64, 64, 64);
            button_New_Delete.Location = new Point(680, 67);
            button_New_Delete.Margin = new Padding(3, 2, 3, 2);
            button_New_Delete.Name = "button_New_Delete";
            button_New_Delete.Size = new Size(108, 34);
            button_New_Delete.TabIndex = 194;
            button_New_Delete.Text = "生成⇒破棄";
            button_New_Delete.UseVisualStyleBackColor = true;
            button_New_Delete.Click += button_New_Delete_Click;
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Location = new Point(663, 46);
            label25.Name = "label25";
            label25.Size = new Size(125, 20);
            label25.TabIndex = 193;
            label25.Text = "【メモリリークテスト】";
            // 
            // Form_RdtDialog
            // 
            AutoScaleDimensions = new SizeF(10F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label_Count);
            Controls.Add(label_33);
            Controls.Add(button_New_Delete);
            Controls.Add(label25);
            Name = "Form_RdtDialog";
            Text = "Form_RdtDialog";
            Controls.SetChildIndex(label25, 0);
            Controls.SetChildIndex(button_New_Delete, 0);
            Controls.SetChildIndex(label_33, 0);
            Controls.SetChildIndex(label_Count, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_Count;
        private Label label_33;
        private Button button_New_Delete;
        private Label label25;
    }
}
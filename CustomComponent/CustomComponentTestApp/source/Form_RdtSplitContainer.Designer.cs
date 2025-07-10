namespace RADISTA.CustomComponentTestApp
{
    partial class Form_RdtSplitContainer
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
            rdtSplitContainer1 = new RADISTA.UIComponent.CustomControl.RdtSplitContainer(components);
            label_Count = new Label();
            label_2 = new Label();
            button_New_Delete = new Button();
            label1 = new Label();
            label_BackColor = new Label();
            label_ComponentEdgeColor = new Label();
            label5 = new Label();
            label3 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)rdtSplitContainer1).BeginInit();
            rdtSplitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // rdtSplitContainer1
            // 
            rdtSplitContainer1.Location = new Point(0, 0);
            rdtSplitContainer1.Name = "rdtSplitContainer1";
            rdtSplitContainer1.Size = new Size(594, 585);
            rdtSplitContainer1.SplitterDistance = 274;
            rdtSplitContainer1.TabIndex = 0;
            // 
            // label_Count
            // 
            label_Count.AutoSize = true;
            label_Count.Location = new Point(685, 160);
            label_Count.Name = "label_Count";
            label_Count.Size = new Size(17, 20);
            label_Count.TabIndex = 145;
            label_Count.Text = "0";
            // 
            // label_2
            // 
            label_2.AutoSize = true;
            label_2.Location = new Point(630, 160);
            label_2.Name = "label_2";
            label_2.Size = new Size(49, 20);
            label_2.TabIndex = 144;
            label_2.Text = "回数=";
            // 
            // button_New_Delete
            // 
            button_New_Delete.Location = new Point(630, 128);
            button_New_Delete.Name = "button_New_Delete";
            button_New_Delete.Size = new Size(94, 29);
            button_New_Delete.TabIndex = 143;
            button_New_Delete.Text = "生成⇒破棄";
            button_New_Delete.UseVisualStyleBackColor = true;
            button_New_Delete.Click += button_New_Delete_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(610, 100);
            label1.Name = "label1";
            label1.Size = new Size(122, 20);
            label1.TabIndex = 142;
            label1.Text = "【メモリリークテスト】";
            // 
            // label_BackColor
            // 
            label_BackColor.AutoSize = true;
            label_BackColor.Location = new Point(722, 37);
            label_BackColor.Name = "label_BackColor";
            label_BackColor.Size = new Size(86, 20);
            label_BackColor.TabIndex = 153;
            label_BackColor.Text = "BackColor=";
            label_BackColor.TextAlign = ContentAlignment.TopCenter;
            // 
            // label_ComponentEdgeColor
            // 
            label_ComponentEdgeColor.AutoSize = true;
            label_ComponentEdgeColor.Location = new Point(803, 62);
            label_ComponentEdgeColor.Name = "label_ComponentEdgeColor";
            label_ComponentEdgeColor.Size = new Size(167, 20);
            label_ComponentEdgeColor.TabIndex = 149;
            label_ComponentEdgeColor.Text = "ComponentEdgeColor=";
            label_ComponentEdgeColor.TextAlign = ContentAlignment.TopCenter;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(630, 62);
            label5.Name = "label5";
            label5.Size = new Size(167, 20);
            label5.TabIndex = 148;
            label5.Text = "ComponentEdgeColor=";
            label5.TextAlign = ContentAlignment.TopCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(630, 37);
            label3.Name = "label3";
            label3.Size = new Size(86, 20);
            label3.TabIndex = 146;
            label3.Text = "BackColor=";
            label3.TextAlign = ContentAlignment.TopCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(610, 9);
            label2.Name = "label2";
            label2.Size = new Size(109, 20);
            label2.TabIndex = 154;
            label2.Text = "【デフォルト表示】";
            // 
            // Form_RdtSplitContainer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1099, 586);
            Controls.Add(label2);
            Controls.Add(label_BackColor);
            Controls.Add(label_ComponentEdgeColor);
            Controls.Add(label5);
            Controls.Add(label3);
            Controls.Add(label_Count);
            Controls.Add(label_2);
            Controls.Add(button_New_Delete);
            Controls.Add(label1);
            Controls.Add(rdtSplitContainer1);
            Name = "Form_RdtSplitContainer";
            Text = "Form_RdtSplitContainer";
            Load += Form_RdtSplitContainer_Load;
            ((System.ComponentModel.ISupportInitialize)rdtSplitContainer1).EndInit();
            rdtSplitContainer1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RADISTA.UIComponent.CustomControl.RdtSplitContainer rdtSplitContainer1;
        private Label label_Count;
        private Label label_2;
        private Button button_New_Delete;
        private Label label1;
        private Label label_BackColor;
        private Label label_ComponentEdgeColor;
        private Label label5;
        private Label label3;
        private Label label2;
    }
}
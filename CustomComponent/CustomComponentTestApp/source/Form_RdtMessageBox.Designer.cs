namespace RADISTA.CustomComponentTestApp.source
{
    partial class Form_RdtMessageBox
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
            button_Info = new Button();
            button_Question = new Button();
            button_Warn = new Button();
            button_Error = new Button();
            button_None = new Button();
            button_Ok = new Button();
            button_OC = new Button();
            button_YNC = new Button();
            label1 = new Label();
            label2 = new Label();
            label_AutoCloseMs = new Label();
            label5 = new Label();
            label3 = new Label();
            label4 = new Label();
            label6 = new Label();
            label_closetime = new Label();
            button_left_x = new Button();
            button_center_x = new Button();
            button_right_x = new Button();
            button_buttom_y = new Button();
            button_center_y = new Button();
            button_top_y = new Button();
            label7 = new Label();
            label_33 = new Label();
            button_New_Delete = new Button();
            label25 = new Label();
            label_Count = new Label();
            label_PositionMode = new Label();
            label8 = new Label();
            label_Location = new Label();
            label9 = new Label();
            SuspendLayout();
            // 
            // button_Info
            // 
            button_Info.Font = new Font("Meiryo UI", 11F);
            button_Info.ForeColor = Color.FromArgb(64, 64, 64);
            button_Info.Location = new Point(52, 147);
            button_Info.Name = "button_Info";
            button_Info.Size = new Size(82, 28);
            button_Info.TabIndex = 1;
            button_Info.Text = "情報";
            button_Info.UseVisualStyleBackColor = true;
            button_Info.Click += button1_Click;
            // 
            // button_Question
            // 
            button_Question.Font = new Font("Meiryo UI", 11F);
            button_Question.ForeColor = Color.FromArgb(64, 64, 64);
            button_Question.Location = new Point(140, 147);
            button_Question.Name = "button_Question";
            button_Question.Size = new Size(82, 28);
            button_Question.TabIndex = 2;
            button_Question.Text = "質問";
            button_Question.UseVisualStyleBackColor = true;
            button_Question.Click += button_Question_Click;
            // 
            // button_Warn
            // 
            button_Warn.Font = new Font("Meiryo UI", 11F);
            button_Warn.ForeColor = Color.FromArgb(64, 64, 64);
            button_Warn.Location = new Point(228, 147);
            button_Warn.Name = "button_Warn";
            button_Warn.Size = new Size(82, 28);
            button_Warn.TabIndex = 3;
            button_Warn.Text = "注意";
            button_Warn.UseVisualStyleBackColor = true;
            button_Warn.Click += button_Warn_Click;
            // 
            // button_Error
            // 
            button_Error.Font = new Font("Meiryo UI", 11F);
            button_Error.ForeColor = Color.FromArgb(64, 64, 64);
            button_Error.Location = new Point(316, 147);
            button_Error.Name = "button_Error";
            button_Error.Size = new Size(82, 28);
            button_Error.TabIndex = 4;
            button_Error.Text = "警告";
            button_Error.UseVisualStyleBackColor = true;
            button_Error.Click += button_Error_Click;
            // 
            // button_None
            // 
            button_None.Font = new Font("Meiryo UI", 10F);
            button_None.ForeColor = Color.FromArgb(64, 64, 64);
            button_None.Location = new Point(52, 226);
            button_None.Name = "button_None";
            button_None.Size = new Size(105, 25);
            button_None.TabIndex = 5;
            button_None.Text = "None";
            button_None.UseVisualStyleBackColor = true;
            button_None.Click += button_None_Click;
            // 
            // button_Ok
            // 
            button_Ok.Font = new Font("Meiryo UI", 10F);
            button_Ok.ForeColor = Color.FromArgb(64, 64, 64);
            button_Ok.Location = new Point(163, 226);
            button_Ok.Name = "button_Ok";
            button_Ok.Size = new Size(105, 25);
            button_Ok.TabIndex = 6;
            button_Ok.Text = "OK";
            button_Ok.UseVisualStyleBackColor = true;
            button_Ok.Click += button_Ok_Click;
            // 
            // button_OC
            // 
            button_OC.Font = new Font("Meiryo UI", 10F);
            button_OC.ForeColor = Color.FromArgb(64, 64, 64);
            button_OC.Location = new Point(274, 226);
            button_OC.Name = "button_OC";
            button_OC.Size = new Size(105, 25);
            button_OC.TabIndex = 7;
            button_OC.Text = "OKCancel";
            button_OC.UseVisualStyleBackColor = true;
            button_OC.Click += button_OC_Click;
            // 
            // button_YNC
            // 
            button_YNC.Font = new Font("Meiryo UI", 10F);
            button_YNC.ForeColor = Color.FromArgb(64, 64, 64);
            button_YNC.Location = new Point(385, 226);
            button_YNC.Name = "button_YNC";
            button_YNC.Size = new Size(105, 25);
            button_YNC.TabIndex = 8;
            button_YNC.Text = "YesNoCancel";
            button_YNC.UseVisualStyleBackColor = true;
            button_YNC.Click += button_YNC_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Meiryo UI", 10F);
            label1.ForeColor = Color.White;
            label1.Location = new Point(20, 123);
            label1.Name = "label1";
            label1.Size = new Size(101, 18);
            label1.TabIndex = 9;
            label1.Text = "メッセージアイコン";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Meiryo UI", 10F);
            label2.ForeColor = Color.White;
            label2.Location = new Point(20, 204);
            label2.Name = "label2";
            label2.Size = new Size(81, 18);
            label2.TabIndex = 10;
            label2.Text = "ボタンスタイル";
            // 
            // label_AutoCloseMs
            // 
            label_AutoCloseMs.AutoSize = true;
            label_AutoCloseMs.Font = new Font("Meiryo UI", 10F);
            label_AutoCloseMs.ForeColor = Color.White;
            label_AutoCloseMs.Location = new Point(128, 407);
            label_AutoCloseMs.Name = "label_AutoCloseMs";
            label_AutoCloseMs.Size = new Size(94, 18);
            label_AutoCloseMs.TabIndex = 14;
            label_AutoCloseMs.Text = "AutoCloseMs";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Meiryo UI", 10F);
            label5.ForeColor = Color.White;
            label5.Location = new Point(28, 294);
            label5.Name = "label5";
            label5.Size = new Size(109, 18);
            label5.TabIndex = 15;
            label5.Text = "PositionMode=";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Meiryo UI", 10F);
            label3.ForeColor = Color.White;
            label3.Location = new Point(20, 407);
            label3.Name = "label3";
            label3.Size = new Size(105, 18);
            label3.TabIndex = 16;
            label3.Text = "AutoCloseMs=";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Meiryo UI", 10F);
            label4.ForeColor = Color.White;
            label4.Location = new Point(269, 297);
            label4.Name = "label4";
            label4.Size = new Size(28, 18);
            label4.TabIndex = 18;
            label4.Text = "X=";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Meiryo UI", 10F);
            label6.ForeColor = Color.White;
            label6.Location = new Point(411, 297);
            label6.Name = "label6";
            label6.Size = new Size(28, 18);
            label6.TabIndex = 19;
            label6.Text = "Y=";
            // 
            // label_closetime
            // 
            label_closetime.AutoSize = true;
            label_closetime.Font = new Font("Meiryo UI", 10F);
            label_closetime.ForeColor = Color.White;
            label_closetime.Location = new Point(268, 407);
            label_closetime.Name = "label_closetime";
            label_closetime.Size = new Size(78, 18);
            label_closetime.TabIndex = 20;
            label_closetime.Text = "自動クローズ";
            // 
            // button_left_x
            // 
            button_left_x.Font = new Font("Meiryo UI", 10F);
            button_left_x.ForeColor = Color.FromArgb(64, 64, 64);
            button_left_x.Location = new Point(305, 297);
            button_left_x.Name = "button_left_x";
            button_left_x.Size = new Size(90, 25);
            button_left_x.TabIndex = 22;
            button_left_x.Text = "Left";
            button_left_x.UseVisualStyleBackColor = true;
            button_left_x.Click += button_left_x_Click;
            // 
            // button_center_x
            // 
            button_center_x.Font = new Font("Meiryo UI", 10F);
            button_center_x.ForeColor = Color.FromArgb(64, 64, 64);
            button_center_x.Location = new Point(305, 330);
            button_center_x.Name = "button_center_x";
            button_center_x.Size = new Size(90, 25);
            button_center_x.TabIndex = 23;
            button_center_x.Text = "Center";
            button_center_x.UseVisualStyleBackColor = true;
            button_center_x.Click += button_center_x_Click;
            // 
            // button_right_x
            // 
            button_right_x.Font = new Font("Meiryo UI", 10F);
            button_right_x.ForeColor = Color.FromArgb(64, 64, 64);
            button_right_x.Location = new Point(305, 361);
            button_right_x.Name = "button_right_x";
            button_right_x.Size = new Size(90, 25);
            button_right_x.TabIndex = 24;
            button_right_x.Text = "Right";
            button_right_x.UseVisualStyleBackColor = true;
            button_right_x.Click += button_right_x_Click;
            // 
            // button_buttom_y
            // 
            button_buttom_y.Font = new Font("Meiryo UI", 10F);
            button_buttom_y.ForeColor = Color.FromArgb(64, 64, 64);
            button_buttom_y.Location = new Point(446, 357);
            button_buttom_y.Name = "button_buttom_y";
            button_buttom_y.Size = new Size(90, 25);
            button_buttom_y.TabIndex = 27;
            button_buttom_y.Text = "Bottom";
            button_buttom_y.UseVisualStyleBackColor = true;
            button_buttom_y.Click += button_buttom_y_Click;
            // 
            // button_center_y
            // 
            button_center_y.Font = new Font("Meiryo UI", 10F);
            button_center_y.ForeColor = Color.FromArgb(64, 64, 64);
            button_center_y.Location = new Point(446, 326);
            button_center_y.Name = "button_center_y";
            button_center_y.Size = new Size(90, 25);
            button_center_y.TabIndex = 26;
            button_center_y.Text = "Center";
            button_center_y.UseVisualStyleBackColor = true;
            button_center_y.Click += button_center_y_Click;
            // 
            // button_top_y
            // 
            button_top_y.Font = new Font("Meiryo UI", 10F);
            button_top_y.ForeColor = Color.FromArgb(64, 64, 64);
            button_top_y.Location = new Point(446, 293);
            button_top_y.Name = "button_top_y";
            button_top_y.Size = new Size(90, 25);
            button_top_y.TabIndex = 25;
            button_top_y.Text = "Top";
            button_top_y.UseVisualStyleBackColor = true;
            button_top_y.Click += button_top_y_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Meiryo UI", 10F);
            label7.ForeColor = Color.White;
            label7.Location = new Point(20, 274);
            label7.Name = "label7";
            label7.Size = new Size(64, 18);
            label7.TabIndex = 28;
            label7.Text = "表示位置";
            // 
            // label_33
            // 
            label_33.AutoSize = true;
            label_33.Location = new Point(626, 99);
            label_33.Name = "label_33";
            label_33.Size = new Size(54, 20);
            label_33.TabIndex = 191;
            label_33.Text = "回数=";
            // 
            // button_New_Delete
            // 
            button_New_Delete.ForeColor = Color.FromArgb(64, 64, 64);
            button_New_Delete.Location = new Point(626, 63);
            button_New_Delete.Margin = new Padding(3, 2, 3, 2);
            button_New_Delete.Name = "button_New_Delete";
            button_New_Delete.Size = new Size(108, 34);
            button_New_Delete.TabIndex = 190;
            button_New_Delete.Text = "生成⇒破棄";
            button_New_Delete.UseVisualStyleBackColor = true;
            button_New_Delete.Click += button_New_Delete_Click;
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.Location = new Point(609, 42);
            label25.Name = "label25";
            label25.Size = new Size(125, 20);
            label25.TabIndex = 189;
            label25.Text = "【メモリリークテスト】";
            // 
            // label_Count
            // 
            label_Count.AutoSize = true;
            label_Count.Location = new Point(679, 99);
            label_Count.Name = "label_Count";
            label_Count.Size = new Size(19, 20);
            label_Count.TabIndex = 192;
            label_Count.Text = "0";
            // 
            // label_PositionMode
            // 
            label_PositionMode.AutoSize = true;
            label_PositionMode.Font = new Font("Meiryo UI", 10F);
            label_PositionMode.ForeColor = Color.White;
            label_PositionMode.Location = new Point(133, 293);
            label_PositionMode.Name = "label_PositionMode";
            label_PositionMode.Size = new Size(98, 18);
            label_PositionMode.TabIndex = 193;
            label_PositionMode.Text = "PositionMode";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Meiryo UI", 10F);
            label8.ForeColor = Color.White;
            label8.Location = new Point(28, 326);
            label8.Name = "label8";
            label8.Size = new Size(76, 18);
            label8.TabIndex = 194;
            label8.Text = "Location=";
            // 
            // label_Location
            // 
            label_Location.AutoSize = true;
            label_Location.Font = new Font("Meiryo UI", 10F);
            label_Location.ForeColor = Color.White;
            label_Location.Location = new Point(110, 326);
            label_Location.Name = "label_Location";
            label_Location.Size = new Size(65, 18);
            label_Location.TabIndex = 195;
            label_Location.Text = "Location";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Meiryo UI", 10F);
            label9.ForeColor = Color.White;
            label9.Location = new Point(257, 274);
            label9.Name = "label9";
            label9.Size = new Size(147, 18);
            label9.TabIndex = 196;
            label9.Text = "※Combinationの場合";
            // 
            // Form_RdtMessageBox
            // 
            ButtonType = ButtonTypeT.YesNoCancel;
            ClientSize = new Size(742, 444);
            Controls.Add(label9);
            Controls.Add(label_Location);
            Controls.Add(label8);
            Controls.Add(label_PositionMode);
            Controls.Add(label_Count);
            Controls.Add(label_33);
            Controls.Add(button_New_Delete);
            Controls.Add(label25);
            Controls.Add(label7);
            Controls.Add(button_buttom_y);
            Controls.Add(button_center_y);
            Controls.Add(button_top_y);
            Controls.Add(button_right_x);
            Controls.Add(button_center_x);
            Controls.Add(button_left_x);
            Controls.Add(label_closetime);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label5);
            Controls.Add(label_AutoCloseMs);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(button_YNC);
            Controls.Add(button_OC);
            Controls.Add(button_Ok);
            Controls.Add(button_None);
            Controls.Add(button_Error);
            Controls.Add(button_Warn);
            Controls.Add(button_Question);
            Controls.Add(button_Info);
            Message = "表示メッセージを指定してください。\\n改行します";
            Name = "Form_RdtMessageBox";
            PositionMode = PositionModeT.Absolute;
            StartPosition = FormStartPosition.Manual;
            Text = "Form_MessageBox";
            Load += Form_RdtMessageBox_Load;
            Controls.SetChildIndex(button_Info, 0);
            Controls.SetChildIndex(button_Question, 0);
            Controls.SetChildIndex(button_Warn, 0);
            Controls.SetChildIndex(button_Error, 0);
            Controls.SetChildIndex(button_None, 0);
            Controls.SetChildIndex(button_Ok, 0);
            Controls.SetChildIndex(button_OC, 0);
            Controls.SetChildIndex(button_YNC, 0);
            Controls.SetChildIndex(label1, 0);
            Controls.SetChildIndex(label2, 0);
            Controls.SetChildIndex(label_AutoCloseMs, 0);
            Controls.SetChildIndex(label5, 0);
            Controls.SetChildIndex(label3, 0);
            Controls.SetChildIndex(label4, 0);
            Controls.SetChildIndex(label6, 0);
            Controls.SetChildIndex(label_closetime, 0);
            Controls.SetChildIndex(button_left_x, 0);
            Controls.SetChildIndex(button_center_x, 0);
            Controls.SetChildIndex(button_right_x, 0);
            Controls.SetChildIndex(button_top_y, 0);
            Controls.SetChildIndex(button_center_y, 0);
            Controls.SetChildIndex(button_buttom_y, 0);
            Controls.SetChildIndex(label7, 0);
            Controls.SetChildIndex(label25, 0);
            Controls.SetChildIndex(button_New_Delete, 0);
            Controls.SetChildIndex(label_33, 0);
            Controls.SetChildIndex(label_Count, 0);
            Controls.SetChildIndex(label_PositionMode, 0);
            Controls.SetChildIndex(label8, 0);
            Controls.SetChildIndex(label_Location, 0);
            Controls.SetChildIndex(label9, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button_Info;
        private Button button_Question;
        private Button button_Warn;
        private Button button_Error;
        private Button button_None;
        private Button button_Ok;
        private Button button_OC;
        private Button button_YNC;
        private Label label1;
        private Label label2;
        private Label label_AutoCloseMs;
        private Label label5;
        private Label label3;
        private Label label4;
        private Label label6;
        private Label label_closetime;
        private Button button_left_x;
        private Button button_center_x;
        private Button button_right_x;
        private Button button_buttom_y;
        private Button button_center_y;
        private Button button_top_y;
        private Label label7;
        private Label label_33;
        private Button button_New_Delete;
        private Label label25;
        private Label label_Count;
        private Label label_PositionMode;
        private Label label8;
        private Label label_Location;
        private Label label9;
    }
}
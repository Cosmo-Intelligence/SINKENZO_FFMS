namespace CustomComponentTestApp.source
{
    partial class Form_RdtThumbnailView
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
            Label_SmallIcon_Title = new Label();
            Thumbnail_SmallIcon = new RADISTA.UIComponent.CustomControl.RdtThumbnailView(components);
            Button_ShowDelete = new Button();
            Button_ShowMultiFrame = new Button();
            Button_RemoveDelete = new Button();
            Button_RemoveMulti = new Button();
            Button_DeleteMove = new Button();
            Button_MultiMove = new Button();
            Label_SmallIcon_Delete = new Label();
            Label_SmallIcon_Multi = new Label();
            Thumbnail_LargeIcon = new RADISTA.UIComponent.CustomControl.RdtThumbnailView(components);
            Label_LargeIcon_Title = new Label();
            Label_MultiMove_L = new Label();
            Label_DeleteMove_L = new Label();
            Button_MoveMulti_L = new Button();
            Button_MoveDelete_L = new Button();
            Button_RemoveMulti_L = new Button();
            Button_RemoveDelete_L = new Button();
            Button_ShowMulti_L = new Button();
            Button_ShowDelete_L = new Button();
            Label_ImageMargin_Title = new Label();
            Thumbnail_ImageMargin = new RADISTA.UIComponent.CustomControl.RdtThumbnailView(components);
            Label_ImageMargin = new Label();
            Thumbnail_Resize_True = new RADISTA.UIComponent.CustomControl.RdtThumbnailView(components);
            Label_Resize = new Label();
            Button_MoveMulti_Resize_True = new Button();
            Button_MoveDelete_Resize_True = new Button();
            Button_RemoveMulti_Resize_True = new Button();
            Button_RemoveDelete_Resize_True = new Button();
            Button_ShowMulti_Resize_True = new Button();
            Button_ShowDelete_Resize_True = new Button();
            Label_Resize_IsResize_True = new Label();
            Label_Resize_OverlayResize_True = new Label();
            Label_Resize_BaseImageSize_True = new Label();
            Label_Resize_OverlaySize_True = new Label();
            Thumbnail_Resize_False = new RADISTA.UIComponent.CustomControl.RdtThumbnailView(components);
            Label_Resize_OverlaySize_False = new Label();
            Label_Resize_BaseImageSize_False = new Label();
            Label_Resize_OverlayResize_False = new Label();
            Label_Resize_IsResize_False = new Label();
            Button_MoveMulti_Resize_False = new Button();
            Button_MoveDelete_Resize_False = new Button();
            Button_RemoveMulti_Resize_False = new Button();
            Button_RemoveDelete_Resize_False = new Button();
            Button_ShowMulti_Resize_false = new Button();
            Button_ShowDelete_Resize_False = new Button();
            Label_TestCount = new Label();
            Button_Test = new Button();
            Label_MemoryLeak = new Label();
            SuspendLayout();
            // 
            // Label_SmallIcon_Title
            // 
            Label_SmallIcon_Title.AutoSize = true;
            Label_SmallIcon_Title.Location = new Point(10, 4);
            Label_SmallIcon_Title.Name = "Label_SmallIcon_Title";
            Label_SmallIcon_Title.Size = new Size(74, 20);
            Label_SmallIcon_Title.TabIndex = 0;
            Label_SmallIcon_Title.Text = "SmallIcon";
            // 
            // Thumbnail_SmallIcon
            // 
            Thumbnail_SmallIcon.AutoScroll = true;
            Thumbnail_SmallIcon.BaseImageSize = new Size(0, 0);
            Thumbnail_SmallIcon.DeleteIconPlacement = RADISTA.UIComponent.CustomControl.RdtThumbnailView.IconPlacementT.LEFT_TOP;
            Thumbnail_SmallIcon.DeleteImageFilePath = "..\\..\\..\\..\\Image\\ThumbnailView\\Delete.png";
            Thumbnail_SmallIcon.ImageMargin = new Point(0, 0);
            Thumbnail_SmallIcon.IsOverlayResize = false;
            Thumbnail_SmallIcon.IsResize = false;
            Thumbnail_SmallIcon.LargeDeleteImageFilePath = "";
            Thumbnail_SmallIcon.LargeMultiFrameFilePath = "";
            Thumbnail_SmallIcon.Location = new Point(12, 27);
            Thumbnail_SmallIcon.MultiFrameFilePath = "..\\..\\..\\..\\Image\\ThumbnailView\\MultiFrame.png";
            Thumbnail_SmallIcon.MultiIconPlacement = RADISTA.UIComponent.CustomControl.RdtThumbnailView.IconPlacementT.LEFT_TOP;
            Thumbnail_SmallIcon.Name = "Thumbnail_SmallIcon";
            Thumbnail_SmallIcon.OverlayImageSize = new Size(0, 0);
            Thumbnail_SmallIcon.Padding = new Padding(10);
            Thumbnail_SmallIcon.Size = new Size(296, 218);
            Thumbnail_SmallIcon.TabIndex = 1;
            Thumbnail_SmallIcon.UseLargeIcon = false;
            // 
            // Button_ShowDelete
            // 
            Button_ShowDelete.Location = new Point(314, 27);
            Button_ShowDelete.Name = "Button_ShowDelete";
            Button_ShowDelete.Size = new Size(128, 29);
            Button_ShowDelete.TabIndex = 2;
            Button_ShowDelete.Text = "削除アイコン追加";
            Button_ShowDelete.UseVisualStyleBackColor = true;
            Button_ShowDelete.Click += Button_ShowDelete_Click;
            // 
            // Button_ShowMultiFrame
            // 
            Button_ShowMultiFrame.Location = new Point(314, 62);
            Button_ShowMultiFrame.Name = "Button_ShowMultiFrame";
            Button_ShowMultiFrame.Size = new Size(128, 29);
            Button_ShowMultiFrame.TabIndex = 3;
            Button_ShowMultiFrame.Text = "マルチアイコン追加";
            Button_ShowMultiFrame.UseVisualStyleBackColor = true;
            Button_ShowMultiFrame.Click += Button_ShowMultiFrame_Click;
            // 
            // Button_RemoveDelete
            // 
            Button_RemoveDelete.Location = new Point(314, 97);
            Button_RemoveDelete.Name = "Button_RemoveDelete";
            Button_RemoveDelete.Size = new Size(128, 29);
            Button_RemoveDelete.TabIndex = 4;
            Button_RemoveDelete.Text = "削除アイコン削除";
            Button_RemoveDelete.UseVisualStyleBackColor = true;
            Button_RemoveDelete.Click += Button_RemoveDelete_Click;
            // 
            // Button_RemoveMulti
            // 
            Button_RemoveMulti.Location = new Point(314, 132);
            Button_RemoveMulti.Name = "Button_RemoveMulti";
            Button_RemoveMulti.Size = new Size(128, 29);
            Button_RemoveMulti.TabIndex = 5;
            Button_RemoveMulti.Text = "マルチアイコン削除";
            Button_RemoveMulti.UseVisualStyleBackColor = true;
            Button_RemoveMulti.Click += Button_RemoveMulti_Click;
            // 
            // Button_DeleteMove
            // 
            Button_DeleteMove.Location = new Point(315, 167);
            Button_DeleteMove.Name = "Button_DeleteMove";
            Button_DeleteMove.Size = new Size(127, 29);
            Button_DeleteMove.TabIndex = 6;
            Button_DeleteMove.Text = "削除アイコン移動";
            Button_DeleteMove.UseVisualStyleBackColor = true;
            Button_DeleteMove.Click += Button_DeleteMove_Click;
            // 
            // Button_MultiMove
            // 
            Button_MultiMove.Location = new Point(315, 202);
            Button_MultiMove.Name = "Button_MultiMove";
            Button_MultiMove.Size = new Size(127, 29);
            Button_MultiMove.TabIndex = 7;
            Button_MultiMove.Text = "マルチアイコン移動";
            Button_MultiMove.UseVisualStyleBackColor = true;
            Button_MultiMove.Click += Button_MultiMove_Click;
            // 
            // Label_SmallIcon_Delete
            // 
            Label_SmallIcon_Delete.AutoSize = true;
            Label_SmallIcon_Delete.Location = new Point(12, 248);
            Label_SmallIcon_Delete.Name = "Label_SmallIcon_Delete";
            Label_SmallIcon_Delete.Size = new Size(168, 20);
            Label_SmallIcon_Delete.TabIndex = 8;
            Label_SmallIcon_Delete.Text = "DeleteIconPlacement = ";
            // 
            // Label_SmallIcon_Multi
            // 
            Label_SmallIcon_Multi.AutoSize = true;
            Label_SmallIcon_Multi.Location = new Point(12, 268);
            Label_SmallIcon_Multi.Name = "Label_SmallIcon_Multi";
            Label_SmallIcon_Multi.Size = new Size(158, 20);
            Label_SmallIcon_Multi.TabIndex = 9;
            Label_SmallIcon_Multi.Text = "MultiIconPlacement = ";
            // 
            // Thumbnail_LargeIcon
            // 
            Thumbnail_LargeIcon.AutoScroll = true;
            Thumbnail_LargeIcon.BaseImageSize = new Size(0, 0);
            Thumbnail_LargeIcon.DeleteIconPlacement = RADISTA.UIComponent.CustomControl.RdtThumbnailView.IconPlacementT.LEFT_TOP;
            Thumbnail_LargeIcon.DeleteImageFilePath = "";
            Thumbnail_LargeIcon.ImageMargin = new Point(0, 0);
            Thumbnail_LargeIcon.IsOverlayResize = false;
            Thumbnail_LargeIcon.IsResize = false;
            Thumbnail_LargeIcon.LargeDeleteImageFilePath = "..\\..\\..\\..\\Image\\ThumbnailView\\LargeDelete.png";
            Thumbnail_LargeIcon.LargeMultiFrameFilePath = "..\\..\\..\\..\\Image\\ThumbnailView\\LargeMultiFrame.png";
            Thumbnail_LargeIcon.Location = new Point(10, 341);
            Thumbnail_LargeIcon.MultiFrameFilePath = "";
            Thumbnail_LargeIcon.MultiIconPlacement = RADISTA.UIComponent.CustomControl.RdtThumbnailView.IconPlacementT.LEFT_TOP;
            Thumbnail_LargeIcon.Name = "Thumbnail_LargeIcon";
            Thumbnail_LargeIcon.OverlayImageSize = new Size(0, 0);
            Thumbnail_LargeIcon.Padding = new Padding(10);
            Thumbnail_LargeIcon.Size = new Size(298, 218);
            Thumbnail_LargeIcon.TabIndex = 2;
            Thumbnail_LargeIcon.UseLargeIcon = true;
            // 
            // Label_LargeIcon_Title
            // 
            Label_LargeIcon_Title.AutoSize = true;
            Label_LargeIcon_Title.Location = new Point(10, 318);
            Label_LargeIcon_Title.Name = "Label_LargeIcon_Title";
            Label_LargeIcon_Title.Size = new Size(74, 20);
            Label_LargeIcon_Title.TabIndex = 10;
            Label_LargeIcon_Title.Text = "LargeIcon";
            // 
            // Label_MultiMove_L
            // 
            Label_MultiMove_L.AutoSize = true;
            Label_MultiMove_L.Location = new Point(12, 582);
            Label_MultiMove_L.Name = "Label_MultiMove_L";
            Label_MultiMove_L.Size = new Size(158, 20);
            Label_MultiMove_L.TabIndex = 12;
            Label_MultiMove_L.Text = "MultiIconPlacement = ";
            // 
            // Label_DeleteMove_L
            // 
            Label_DeleteMove_L.AutoSize = true;
            Label_DeleteMove_L.Location = new Point(12, 562);
            Label_DeleteMove_L.Name = "Label_DeleteMove_L";
            Label_DeleteMove_L.Size = new Size(168, 20);
            Label_DeleteMove_L.TabIndex = 11;
            Label_DeleteMove_L.Text = "DeleteIconPlacement = ";
            // 
            // Button_MoveMulti_L
            // 
            Button_MoveMulti_L.Location = new Point(318, 516);
            Button_MoveMulti_L.Name = "Button_MoveMulti_L";
            Button_MoveMulti_L.Size = new Size(127, 29);
            Button_MoveMulti_L.TabIndex = 18;
            Button_MoveMulti_L.Text = "マルチアイコン移動";
            Button_MoveMulti_L.UseVisualStyleBackColor = true;
            Button_MoveMulti_L.Click += Button_MoveMulti_L_Click;
            // 
            // Button_MoveDelete_L
            // 
            Button_MoveDelete_L.Location = new Point(318, 481);
            Button_MoveDelete_L.Name = "Button_MoveDelete_L";
            Button_MoveDelete_L.Size = new Size(127, 29);
            Button_MoveDelete_L.TabIndex = 17;
            Button_MoveDelete_L.Text = "削除アイコン移動";
            Button_MoveDelete_L.UseVisualStyleBackColor = true;
            Button_MoveDelete_L.Click += Button_MoveDelete_L_Click;
            // 
            // Button_RemoveMulti_L
            // 
            Button_RemoveMulti_L.Location = new Point(317, 446);
            Button_RemoveMulti_L.Name = "Button_RemoveMulti_L";
            Button_RemoveMulti_L.Size = new Size(128, 29);
            Button_RemoveMulti_L.TabIndex = 16;
            Button_RemoveMulti_L.Text = "マルチアイコン削除";
            Button_RemoveMulti_L.UseVisualStyleBackColor = true;
            Button_RemoveMulti_L.Click += Button_RemoveMulti_L_Click;
            // 
            // Button_RemoveDelete_L
            // 
            Button_RemoveDelete_L.Location = new Point(317, 411);
            Button_RemoveDelete_L.Name = "Button_RemoveDelete_L";
            Button_RemoveDelete_L.Size = new Size(128, 29);
            Button_RemoveDelete_L.TabIndex = 15;
            Button_RemoveDelete_L.Text = "削除アイコン削除";
            Button_RemoveDelete_L.UseVisualStyleBackColor = true;
            Button_RemoveDelete_L.Click += Button_RemoveDelete_L_Click;
            // 
            // Button_ShowMulti_L
            // 
            Button_ShowMulti_L.Location = new Point(317, 376);
            Button_ShowMulti_L.Name = "Button_ShowMulti_L";
            Button_ShowMulti_L.Size = new Size(128, 29);
            Button_ShowMulti_L.TabIndex = 14;
            Button_ShowMulti_L.Text = "マルチアイコン追加";
            Button_ShowMulti_L.UseVisualStyleBackColor = true;
            Button_ShowMulti_L.Click += Button_ShowMulti_L_Click;
            // 
            // Button_ShowDelete_L
            // 
            Button_ShowDelete_L.Location = new Point(317, 341);
            Button_ShowDelete_L.Name = "Button_ShowDelete_L";
            Button_ShowDelete_L.Size = new Size(128, 29);
            Button_ShowDelete_L.TabIndex = 13;
            Button_ShowDelete_L.Text = "削除アイコン追加";
            Button_ShowDelete_L.UseVisualStyleBackColor = true;
            Button_ShowDelete_L.Click += Button_ShowDelete_L_Click;
            // 
            // Label_ImageMargin_Title
            // 
            Label_ImageMargin_Title.AutoSize = true;
            Label_ImageMargin_Title.Location = new Point(10, 614);
            Label_ImageMargin_Title.Name = "Label_ImageMargin_Title";
            Label_ImageMargin_Title.Size = new Size(98, 20);
            Label_ImageMargin_Title.TabIndex = 19;
            Label_ImageMargin_Title.Text = "ImageMargin";
            // 
            // Thumbnail_ImageMargin
            // 
            Thumbnail_ImageMargin.AutoScroll = true;
            Thumbnail_ImageMargin.BaseImageSize = new Size(0, 0);
            Thumbnail_ImageMargin.DeleteIconPlacement = RADISTA.UIComponent.CustomControl.RdtThumbnailView.IconPlacementT.LEFT_TOP;
            Thumbnail_ImageMargin.DeleteImageFilePath = "";
            Thumbnail_ImageMargin.ImageMargin = new Point(8, 8);
            Thumbnail_ImageMargin.IsOverlayResize = false;
            Thumbnail_ImageMargin.IsResize = false;
            Thumbnail_ImageMargin.LargeDeleteImageFilePath = "";
            Thumbnail_ImageMargin.LargeMultiFrameFilePath = "";
            Thumbnail_ImageMargin.Location = new Point(12, 637);
            Thumbnail_ImageMargin.MultiFrameFilePath = "";
            Thumbnail_ImageMargin.MultiIconPlacement = RADISTA.UIComponent.CustomControl.RdtThumbnailView.IconPlacementT.LEFT_TOP;
            Thumbnail_ImageMargin.Name = "Thumbnail_ImageMargin";
            Thumbnail_ImageMargin.OverlayImageSize = new Size(0, 0);
            Thumbnail_ImageMargin.Padding = new Padding(10);
            Thumbnail_ImageMargin.Size = new Size(296, 218);
            Thumbnail_ImageMargin.TabIndex = 20;
            Thumbnail_ImageMargin.UseLargeIcon = false;
            // 
            // Label_ImageMargin
            // 
            Label_ImageMargin.AutoSize = true;
            Label_ImageMargin.Location = new Point(12, 867);
            Label_ImageMargin.Name = "Label_ImageMargin";
            Label_ImageMargin.Size = new Size(116, 20);
            Label_ImageMargin.TabIndex = 21;
            Label_ImageMargin.Text = "ImageMargin = ";
            // 
            // Thumbnail_Resize_True
            // 
            Thumbnail_Resize_True.AutoScroll = true;
            Thumbnail_Resize_True.BaseImageSize = new Size(48, 48);
            Thumbnail_Resize_True.DeleteIconPlacement = RADISTA.UIComponent.CustomControl.RdtThumbnailView.IconPlacementT.LEFT_TOP;
            Thumbnail_Resize_True.DeleteImageFilePath = "..\\..\\..\\..\\Image\\ThumbnailView\\Delete.png";
            Thumbnail_Resize_True.ImageMargin = new Point(0, 0);
            Thumbnail_Resize_True.IsOverlayResize = true;
            Thumbnail_Resize_True.IsResize = true;
            Thumbnail_Resize_True.LargeDeleteImageFilePath = "";
            Thumbnail_Resize_True.LargeMultiFrameFilePath = "";
            Thumbnail_Resize_True.Location = new Point(468, 27);
            Thumbnail_Resize_True.MultiFrameFilePath = "..\\..\\..\\..\\Image\\ThumbnailView\\MultiFrame.png";
            Thumbnail_Resize_True.MultiIconPlacement = RADISTA.UIComponent.CustomControl.RdtThumbnailView.IconPlacementT.LEFT_TOP;
            Thumbnail_Resize_True.Name = "Thumbnail_Resize_True";
            Thumbnail_Resize_True.OverlayImageSize = new Size(8, 8);
            Thumbnail_Resize_True.Padding = new Padding(10);
            Thumbnail_Resize_True.Size = new Size(300, 218);
            Thumbnail_Resize_True.TabIndex = 22;
            Thumbnail_Resize_True.UseLargeIcon = false;
            // 
            // Label_Resize
            // 
            Label_Resize.AutoSize = true;
            Label_Resize.Location = new Point(468, 4);
            Label_Resize.Name = "Label_Resize";
            Label_Resize.Size = new Size(51, 20);
            Label_Resize.TabIndex = 23;
            Label_Resize.Text = "Resize";
            // 
            // Button_MoveMulti_Resize_True
            // 
            Button_MoveMulti_Resize_True.Location = new Point(775, 202);
            Button_MoveMulti_Resize_True.Name = "Button_MoveMulti_Resize_True";
            Button_MoveMulti_Resize_True.Size = new Size(127, 29);
            Button_MoveMulti_Resize_True.TabIndex = 29;
            Button_MoveMulti_Resize_True.Text = "マルチアイコン移動";
            Button_MoveMulti_Resize_True.UseVisualStyleBackColor = true;
            Button_MoveMulti_Resize_True.Click += Button_MoveMulti_Resize_True_Click;
            // 
            // Button_MoveDelete_Resize_True
            // 
            Button_MoveDelete_Resize_True.Location = new Point(775, 167);
            Button_MoveDelete_Resize_True.Name = "Button_MoveDelete_Resize_True";
            Button_MoveDelete_Resize_True.Size = new Size(127, 29);
            Button_MoveDelete_Resize_True.TabIndex = 28;
            Button_MoveDelete_Resize_True.Text = "削除アイコン移動";
            Button_MoveDelete_Resize_True.UseVisualStyleBackColor = true;
            Button_MoveDelete_Resize_True.Click += Button_MoveDelete_Resize_True_Click;
            // 
            // Button_RemoveMulti_Resize_True
            // 
            Button_RemoveMulti_Resize_True.Location = new Point(774, 132);
            Button_RemoveMulti_Resize_True.Name = "Button_RemoveMulti_Resize_True";
            Button_RemoveMulti_Resize_True.Size = new Size(128, 29);
            Button_RemoveMulti_Resize_True.TabIndex = 27;
            Button_RemoveMulti_Resize_True.Text = "マルチアイコン削除";
            Button_RemoveMulti_Resize_True.UseVisualStyleBackColor = true;
            Button_RemoveMulti_Resize_True.Click += Button_RemoveMulti_Resize_True_Click;
            // 
            // Button_RemoveDelete_Resize_True
            // 
            Button_RemoveDelete_Resize_True.Location = new Point(774, 97);
            Button_RemoveDelete_Resize_True.Name = "Button_RemoveDelete_Resize_True";
            Button_RemoveDelete_Resize_True.Size = new Size(128, 29);
            Button_RemoveDelete_Resize_True.TabIndex = 26;
            Button_RemoveDelete_Resize_True.Text = "削除アイコン削除";
            Button_RemoveDelete_Resize_True.UseVisualStyleBackColor = true;
            Button_RemoveDelete_Resize_True.Click += Button_RemoveDelete_Resize_True_Click;
            // 
            // Button_ShowMulti_Resize_True
            // 
            Button_ShowMulti_Resize_True.Location = new Point(774, 62);
            Button_ShowMulti_Resize_True.Name = "Button_ShowMulti_Resize_True";
            Button_ShowMulti_Resize_True.Size = new Size(128, 29);
            Button_ShowMulti_Resize_True.TabIndex = 25;
            Button_ShowMulti_Resize_True.Text = "マルチアイコン追加";
            Button_ShowMulti_Resize_True.UseVisualStyleBackColor = true;
            Button_ShowMulti_Resize_True.Click += Button_ShowMulti_Resize_True_Click;
            // 
            // Button_ShowDelete_Resize_True
            // 
            Button_ShowDelete_Resize_True.Location = new Point(774, 27);
            Button_ShowDelete_Resize_True.Name = "Button_ShowDelete_Resize_True";
            Button_ShowDelete_Resize_True.Size = new Size(128, 29);
            Button_ShowDelete_Resize_True.TabIndex = 24;
            Button_ShowDelete_Resize_True.Text = "削除アイコン追加";
            Button_ShowDelete_Resize_True.UseVisualStyleBackColor = true;
            Button_ShowDelete_Resize_True.Click += Button_ShowDelete_Resize_True_Click;
            // 
            // Label_Resize_IsResize_True
            // 
            Label_Resize_IsResize_True.AutoSize = true;
            Label_Resize_IsResize_True.Location = new Point(469, 248);
            Label_Resize_IsResize_True.Name = "Label_Resize_IsResize_True";
            Label_Resize_IsResize_True.Size = new Size(79, 20);
            Label_Resize_IsResize_True.TabIndex = 30;
            Label_Resize_IsResize_True.Text = "IsResize = ";
            // 
            // Label_Resize_OverlayResize_True
            // 
            Label_Resize_OverlayResize_True.AutoSize = true;
            Label_Resize_OverlayResize_True.Location = new Point(469, 268);
            Label_Resize_OverlayResize_True.Name = "Label_Resize_OverlayResize_True";
            Label_Resize_OverlayResize_True.Size = new Size(129, 20);
            Label_Resize_OverlayResize_True.TabIndex = 31;
            Label_Resize_OverlayResize_True.Text = "IsOverlayResize = ";
            // 
            // Label_Resize_BaseImageSize_True
            // 
            Label_Resize_BaseImageSize_True.AutoSize = true;
            Label_Resize_BaseImageSize_True.Location = new Point(665, 248);
            Label_Resize_BaseImageSize_True.Name = "Label_Resize_BaseImageSize_True";
            Label_Resize_BaseImageSize_True.Size = new Size(127, 20);
            Label_Resize_BaseImageSize_True.TabIndex = 32;
            Label_Resize_BaseImageSize_True.Text = "BaseImageSize = ";
            // 
            // Label_Resize_OverlaySize_True
            // 
            Label_Resize_OverlaySize_True.AutoSize = true;
            Label_Resize_OverlaySize_True.Location = new Point(665, 268);
            Label_Resize_OverlaySize_True.Name = "Label_Resize_OverlaySize_True";
            Label_Resize_OverlaySize_True.Size = new Size(142, 20);
            Label_Resize_OverlaySize_True.TabIndex = 33;
            Label_Resize_OverlaySize_True.Text = "OverlayImageSize =";
            // 
            // Thumbnail_Resize_False
            // 
            Thumbnail_Resize_False.AutoScroll = true;
            Thumbnail_Resize_False.BaseImageSize = new Size(48, 48);
            Thumbnail_Resize_False.DeleteIconPlacement = RADISTA.UIComponent.CustomControl.RdtThumbnailView.IconPlacementT.LEFT_TOP;
            Thumbnail_Resize_False.DeleteImageFilePath = "..\\..\\..\\..\\Image\\ThumbnailView\\Delete.png";
            Thumbnail_Resize_False.ImageMargin = new Point(0, 0);
            Thumbnail_Resize_False.IsOverlayResize = false;
            Thumbnail_Resize_False.IsResize = false;
            Thumbnail_Resize_False.LargeDeleteImageFilePath = "";
            Thumbnail_Resize_False.LargeMultiFrameFilePath = "";
            Thumbnail_Resize_False.Location = new Point(469, 341);
            Thumbnail_Resize_False.MultiFrameFilePath = "..\\..\\..\\..\\Image\\ThumbnailView\\MultiFrame.png";
            Thumbnail_Resize_False.MultiIconPlacement = RADISTA.UIComponent.CustomControl.RdtThumbnailView.IconPlacementT.LEFT_TOP;
            Thumbnail_Resize_False.Name = "Thumbnail_Resize_False";
            Thumbnail_Resize_False.OverlayImageSize = new Size(8, 8);
            Thumbnail_Resize_False.Padding = new Padding(10);
            Thumbnail_Resize_False.Size = new Size(299, 218);
            Thumbnail_Resize_False.TabIndex = 34;
            Thumbnail_Resize_False.UseLargeIcon = false;
            // 
            // Label_Resize_OverlaySize_False
            // 
            Label_Resize_OverlaySize_False.AutoSize = true;
            Label_Resize_OverlaySize_False.Location = new Point(664, 582);
            Label_Resize_OverlaySize_False.Name = "Label_Resize_OverlaySize_False";
            Label_Resize_OverlaySize_False.Size = new Size(142, 20);
            Label_Resize_OverlaySize_False.TabIndex = 38;
            Label_Resize_OverlaySize_False.Text = "OverlayImageSize =";
            // 
            // Label_Resize_BaseImageSize_False
            // 
            Label_Resize_BaseImageSize_False.AutoSize = true;
            Label_Resize_BaseImageSize_False.Location = new Point(664, 562);
            Label_Resize_BaseImageSize_False.Name = "Label_Resize_BaseImageSize_False";
            Label_Resize_BaseImageSize_False.Size = new Size(127, 20);
            Label_Resize_BaseImageSize_False.TabIndex = 37;
            Label_Resize_BaseImageSize_False.Text = "BaseImageSize = ";
            // 
            // Label_Resize_OverlayResize_False
            // 
            Label_Resize_OverlayResize_False.AutoSize = true;
            Label_Resize_OverlayResize_False.Location = new Point(468, 582);
            Label_Resize_OverlayResize_False.Name = "Label_Resize_OverlayResize_False";
            Label_Resize_OverlayResize_False.Size = new Size(129, 20);
            Label_Resize_OverlayResize_False.TabIndex = 36;
            Label_Resize_OverlayResize_False.Text = "IsOverlayResize = ";
            // 
            // Label_Resize_IsResize_False
            // 
            Label_Resize_IsResize_False.AutoSize = true;
            Label_Resize_IsResize_False.Location = new Point(468, 562);
            Label_Resize_IsResize_False.Name = "Label_Resize_IsResize_False";
            Label_Resize_IsResize_False.Size = new Size(79, 20);
            Label_Resize_IsResize_False.TabIndex = 35;
            Label_Resize_IsResize_False.Text = "IsResize = ";
            // 
            // Button_MoveMulti_Resize_False
            // 
            Button_MoveMulti_Resize_False.Location = new Point(776, 516);
            Button_MoveMulti_Resize_False.Name = "Button_MoveMulti_Resize_False";
            Button_MoveMulti_Resize_False.Size = new Size(127, 29);
            Button_MoveMulti_Resize_False.TabIndex = 44;
            Button_MoveMulti_Resize_False.Text = "マルチアイコン移動";
            Button_MoveMulti_Resize_False.UseVisualStyleBackColor = true;
            // 
            // Button_MoveDelete_Resize_False
            // 
            Button_MoveDelete_Resize_False.Location = new Point(776, 481);
            Button_MoveDelete_Resize_False.Name = "Button_MoveDelete_Resize_False";
            Button_MoveDelete_Resize_False.Size = new Size(127, 29);
            Button_MoveDelete_Resize_False.TabIndex = 43;
            Button_MoveDelete_Resize_False.Text = "削除アイコン移動";
            Button_MoveDelete_Resize_False.UseVisualStyleBackColor = true;
            Button_MoveDelete_Resize_False.Click += Button_MoveDelete_Resize_False_Click;
            // 
            // Button_RemoveMulti_Resize_False
            // 
            Button_RemoveMulti_Resize_False.Location = new Point(775, 446);
            Button_RemoveMulti_Resize_False.Name = "Button_RemoveMulti_Resize_False";
            Button_RemoveMulti_Resize_False.Size = new Size(128, 29);
            Button_RemoveMulti_Resize_False.TabIndex = 42;
            Button_RemoveMulti_Resize_False.Text = "マルチアイコン削除";
            Button_RemoveMulti_Resize_False.UseVisualStyleBackColor = true;
            Button_RemoveMulti_Resize_False.Click += Button_RemoveMulti_Resize_False_Click;
            // 
            // Button_RemoveDelete_Resize_False
            // 
            Button_RemoveDelete_Resize_False.Location = new Point(775, 411);
            Button_RemoveDelete_Resize_False.Name = "Button_RemoveDelete_Resize_False";
            Button_RemoveDelete_Resize_False.Size = new Size(128, 29);
            Button_RemoveDelete_Resize_False.TabIndex = 41;
            Button_RemoveDelete_Resize_False.Text = "削除アイコン削除";
            Button_RemoveDelete_Resize_False.UseVisualStyleBackColor = true;
            Button_RemoveDelete_Resize_False.Click += Button_RemoveDelete_Resize_False_Click;
            // 
            // Button_ShowMulti_Resize_false
            // 
            Button_ShowMulti_Resize_false.Location = new Point(775, 376);
            Button_ShowMulti_Resize_false.Name = "Button_ShowMulti_Resize_false";
            Button_ShowMulti_Resize_false.Size = new Size(128, 29);
            Button_ShowMulti_Resize_false.TabIndex = 40;
            Button_ShowMulti_Resize_false.Text = "マルチアイコン追加";
            Button_ShowMulti_Resize_false.UseVisualStyleBackColor = true;
            Button_ShowMulti_Resize_false.Click += Button_ShowMulti_Resize_false_Click;
            // 
            // Button_ShowDelete_Resize_False
            // 
            Button_ShowDelete_Resize_False.Location = new Point(775, 341);
            Button_ShowDelete_Resize_False.Name = "Button_ShowDelete_Resize_False";
            Button_ShowDelete_Resize_False.Size = new Size(128, 29);
            Button_ShowDelete_Resize_False.TabIndex = 39;
            Button_ShowDelete_Resize_False.Text = "削除アイコン追加";
            Button_ShowDelete_Resize_False.UseVisualStyleBackColor = true;
            Button_ShowDelete_Resize_False.Click += Button_ShowDelete_Resize_False_Click;
            // 
            // Label_TestCount
            // 
            Label_TestCount.AutoSize = true;
            Label_TestCount.Location = new Point(1648, 97);
            Label_TestCount.Name = "Label_TestCount";
            Label_TestCount.Size = new Size(65, 20);
            Label_TestCount.TabIndex = 101;
            Label_TestCount.Text = "回数 = 0";
            // 
            // Button_Test
            // 
            Button_Test.Location = new Point(1648, 56);
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
            Label_MemoryLeak.Location = new Point(1648, 27);
            Label_MemoryLeak.Name = "Label_MemoryLeak";
            Label_MemoryLeak.Size = new Size(122, 20);
            Label_MemoryLeak.TabIndex = 99;
            Label_MemoryLeak.Text = "【メモリリークテスト】";
            // 
            // Form_RdtThumbnailView
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1902, 1033);
            Controls.Add(Label_TestCount);
            Controls.Add(Button_Test);
            Controls.Add(Label_MemoryLeak);
            Controls.Add(Button_MoveMulti_Resize_False);
            Controls.Add(Button_MoveDelete_Resize_False);
            Controls.Add(Button_RemoveMulti_Resize_False);
            Controls.Add(Button_RemoveDelete_Resize_False);
            Controls.Add(Button_ShowMulti_Resize_false);
            Controls.Add(Button_ShowDelete_Resize_False);
            Controls.Add(Label_Resize_OverlaySize_False);
            Controls.Add(Label_Resize_BaseImageSize_False);
            Controls.Add(Label_Resize_OverlayResize_False);
            Controls.Add(Label_Resize_IsResize_False);
            Controls.Add(Thumbnail_Resize_False);
            Controls.Add(Label_Resize_OverlaySize_True);
            Controls.Add(Label_Resize_BaseImageSize_True);
            Controls.Add(Label_Resize_OverlayResize_True);
            Controls.Add(Label_Resize_IsResize_True);
            Controls.Add(Button_MoveMulti_Resize_True);
            Controls.Add(Button_MoveDelete_Resize_True);
            Controls.Add(Button_RemoveMulti_Resize_True);
            Controls.Add(Button_RemoveDelete_Resize_True);
            Controls.Add(Button_ShowMulti_Resize_True);
            Controls.Add(Button_ShowDelete_Resize_True);
            Controls.Add(Label_Resize);
            Controls.Add(Thumbnail_Resize_True);
            Controls.Add(Label_ImageMargin);
            Controls.Add(Thumbnail_ImageMargin);
            Controls.Add(Label_ImageMargin_Title);
            Controls.Add(Button_MoveMulti_L);
            Controls.Add(Button_MoveDelete_L);
            Controls.Add(Button_RemoveMulti_L);
            Controls.Add(Button_RemoveDelete_L);
            Controls.Add(Button_ShowMulti_L);
            Controls.Add(Button_ShowDelete_L);
            Controls.Add(Label_MultiMove_L);
            Controls.Add(Label_DeleteMove_L);
            Controls.Add(Label_LargeIcon_Title);
            Controls.Add(Thumbnail_LargeIcon);
            Controls.Add(Label_SmallIcon_Multi);
            Controls.Add(Label_SmallIcon_Delete);
            Controls.Add(Button_MultiMove);
            Controls.Add(Button_DeleteMove);
            Controls.Add(Button_RemoveMulti);
            Controls.Add(Button_RemoveDelete);
            Controls.Add(Button_ShowMultiFrame);
            Controls.Add(Button_ShowDelete);
            Controls.Add(Thumbnail_SmallIcon);
            Controls.Add(Label_SmallIcon_Title);
            Name = "Form_RdtThumbnailView";
            Text = "Form_RdtThumbnailView";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label Label_SmallIcon_Title;
        private RADISTA.UIComponent.CustomControl.RdtThumbnailView Thumbnail_SmallIcon;
        private Button Button_ShowDelete;
        private Button Button_ShowMultiFrame;
        private Button Button_RemoveDelete;
        private Button Button_RemoveMulti;
        private Button Button_DeleteMove;
        private Button Button_MultiMove;
        private Label Label_SmallIcon_Delete;
        private Label Label_SmallIcon_Multi;
        private RADISTA.UIComponent.CustomControl.RdtThumbnailView Thumbnail_LargeIcon;
        private Label Label_LargeIcon_Title;
        private Label Label_MultiMove_L;
        private Label Label_DeleteMove_L;
        private Button Button_MoveMulti_L;
        private Button Button_MoveDelete_L;
        private Button Button_RemoveMulti_L;
        private Button Button_RemoveDelete_L;
        private Button Button_ShowMulti_L;
        private Button Button_ShowDelete_L;
        private Label Label_ImageMargin_Title;
        private RADISTA.UIComponent.CustomControl.RdtThumbnailView Thumbnail_ImageMargin;
        private Label Label_ImageMargin;
        private RADISTA.UIComponent.CustomControl.RdtThumbnailView Thumbnail_Resize_True;
        private Label Label_Resize;
        private Button Button_MoveMulti_Resize_True;
        private Button Button_MoveDelete_Resize_True;
        private Button Button_RemoveMulti_Resize_True;
        private Button Button_RemoveDelete_Resize_True;
        private Button Button_ShowMulti_Resize_True;
        private Button Button_ShowDelete_Resize_True;
        private Label Label_Resize_IsResize_True;
        private Label Label_Resize_OverlayResize_True;
        private Label Label_Resize_BaseImageSize_True;
        private Label Label_Resize_OverlaySize_True;
        private RADISTA.UIComponent.CustomControl.RdtThumbnailView Thumbnail_Resize_False;
        private Label Label_Resize_OverlaySize_False;
        private Label Label_Resize_BaseImageSize_False;
        private Label Label_Resize_OverlayResize_False;
        private Label Label_Resize_IsResize_False;
        private Button Button_MoveMulti_Resize_False;
        private Button Button_MoveDelete_Resize_False;
        private Button Button_RemoveMulti_Resize_False;
        private Button Button_RemoveDelete_Resize_False;
        private Button Button_ShowMulti_Resize_false;
        private Button Button_ShowDelete_Resize_False;
        private Label Label_TestCount;
        private Button Button_Test;
        private Label Label_MemoryLeak;
    }
}
using RADISTA.UIComponent.CustomControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomComponentTestApp.source
{
    public partial class Form_RdtThumbnailView : Form
    {
        List<string> imageFilePaths = new List<string>();
        int mCounter = 0;

        public Form_RdtThumbnailView()
        {
            InitializeComponent();

            this.imageFilePaths = new List<string>
            {
                "..\\..\\..\\..\\Image\\ThumbnailView\\image1.png",
                "..\\..\\..\\..\\Image\\ThumbnailView\\image2.png",
                "..\\..\\..\\..\\Image\\ThumbnailView\\image3.png",
                "..\\..\\..\\..\\Image\\ThumbnailView\\image4.png",
                "..\\..\\..\\..\\Image\\ThumbnailView\\image5.png",
                "..\\..\\..\\..\\Image\\ThumbnailView\\image6.png",
                "..\\..\\..\\..\\Image\\ThumbnailView\\image7.png",
                "..\\..\\..\\..\\Image\\ThumbnailView\\image8.png",
                "..\\..\\..\\..\\Image\\ThumbnailView\\image9.png",
                "..\\..\\..\\..\\Image\\ThumbnailView\\image10.png",
            };

            this.Initialize();
        }

        private void Initialize()
        {
            //smallIcon
            this.Thumbnail_SmallIcon.AddImagePaths(this.imageFilePaths);
            this.Label_SmallIcon_Delete.Text = "DeleteIconPlacement = " + this.Thumbnail_SmallIcon.DeleteIconPlacement.ToString();
            this.Label_SmallIcon_Multi.Text = "MultiIconPlacement = " + this.Thumbnail_SmallIcon.MultiIconPlacement.ToString();

            //LargeIcon
            this.Thumbnail_LargeIcon.AddImagePaths(this.imageFilePaths);
            this.Label_DeleteMove_L.Text = "DeleteIconPlacement = " + this.Thumbnail_LargeIcon.DeleteIconPlacement.ToString();
            this.Label_MultiMove_L.Text = "MultiIconPlacement = " + this.Thumbnail_LargeIcon.MultiIconPlacement.ToString();

            //ImageMargin
            this.Thumbnail_ImageMargin.AddImagePaths(this.imageFilePaths);
            this.Label_ImageMargin.Text += this.Thumbnail_ImageMargin.ImageMargin.ToString();

            //Resize
            this.Thumbnail_Resize_True.AddImagePaths(this.imageFilePaths);
            this.Label_Resize_IsResize_True.Text += this.Thumbnail_Resize_True.IsResize.ToString();
            this.Label_Resize_BaseImageSize_True.Text += this.Thumbnail_Resize_True.BaseImageSize.ToString();
            this.Label_Resize_OverlayResize_True.Text += this.Thumbnail_Resize_True.IsOverlayResize.ToString();
            this.Label_Resize_OverlaySize_True.Text += this.Thumbnail_Resize_True.OverlayImageSize.ToString();

            this.Thumbnail_Resize_False.AddImagePaths(this.imageFilePaths);
            this.Label_Resize_IsResize_False.Text += this.Thumbnail_Resize_False.IsResize.ToString();
            this.Label_Resize_BaseImageSize_False.Text += this.Thumbnail_Resize_False.BaseImageSize.ToString();
            this.Label_Resize_OverlayResize_False.Text += this.Thumbnail_Resize_False.IsOverlayResize.ToString();
            this.Label_Resize_OverlaySize_False.Text += this.Thumbnail_Resize_False.OverlayImageSize.ToString();
        }

        private void Button_ShowDelete_Click(object sender, EventArgs e)
        {
            this.Thumbnail_SmallIcon.ShowDeleteOverlay();
        }

        private void Button_ShowMultiFrame_Click(object sender, EventArgs e)
        {
            this.Thumbnail_SmallIcon.ShowMultiFrameOverlay();
        }

        private void Button_RemoveDelete_Click(object sender, EventArgs e)
        {
            this.Thumbnail_SmallIcon.RemoveDeleteOverlay();
        }

        private void Button_RemoveMulti_Click(object sender, EventArgs e)
        {
            this.Thumbnail_SmallIcon.RemoveMultiFrameOverlay();
        }

        private void Button_DeleteMove_Click(object sender, EventArgs e)
        {
            int placement = (int)this.Thumbnail_SmallIcon.DeleteIconPlacement;
            placement = placement % 5;
            placement++;
            this.Thumbnail_SmallIcon.DeleteIconPlacement = (RdtThumbnailView.IconPlacementT)placement;
            this.Label_SmallIcon_Delete.Text = "DeleteIconPlacement = " + this.Thumbnail_SmallIcon.DeleteIconPlacement.ToString();
        }

        private void Button_MultiMove_Click(object sender, EventArgs e)
        {
            int placement = (int)this.Thumbnail_SmallIcon.MultiIconPlacement;
            placement = placement % 5;
            placement++;
            this.Thumbnail_SmallIcon.MultiIconPlacement = (RdtThumbnailView.IconPlacementT)placement;
            this.Label_SmallIcon_Multi.Text = "MultiIconPlacement = " + this.Thumbnail_SmallIcon.MultiIconPlacement.ToString();
        }

        private void Button_ShowDelete_L_Click(object sender, EventArgs e)
        {
            this.Thumbnail_LargeIcon.ShowDeleteOverlay();
        }

        private void Button_ShowMulti_L_Click(object sender, EventArgs e)
        {
            this.Thumbnail_LargeIcon.ShowMultiFrameOverlay();
        }

        private void Button_RemoveDelete_L_Click(object sender, EventArgs e)
        {
            this.Thumbnail_LargeIcon.RemoveDeleteOverlay();
        }

        private void Button_RemoveMulti_L_Click(object sender, EventArgs e)
        {
            this.Thumbnail_LargeIcon.RemoveMultiFrameOverlay();
        }

        private void Button_MoveDelete_L_Click(object sender, EventArgs e)
        {
            int placement = (int)this.Thumbnail_LargeIcon.DeleteIconPlacement;
            placement = placement % 5;
            placement++;
            this.Thumbnail_LargeIcon.DeleteIconPlacement = (RdtThumbnailView.IconPlacementT)placement;
            this.Label_DeleteMove_L.Text = "DeleteIconPlacement = " + this.Thumbnail_LargeIcon.DeleteIconPlacement.ToString();
        }

        private void Button_MoveMulti_L_Click(object sender, EventArgs e)
        {
            int placement = (int)this.Thumbnail_LargeIcon.MultiIconPlacement;
            placement = placement % 5;
            placement++;
            this.Thumbnail_LargeIcon.MultiIconPlacement = (RdtThumbnailView.IconPlacementT)placement;
            this.Label_MultiMove_L.Text = "MultiIconPlacement = " + this.Thumbnail_LargeIcon.MultiIconPlacement.ToString();
        }

        private void Button_ShowDelete_Resize_True_Click(object sender, EventArgs e)
        {
            this.Thumbnail_Resize_True.ShowDeleteOverlay();
        }

        private void Button_ShowMulti_Resize_True_Click(object sender, EventArgs e)
        {
            this.Thumbnail_Resize_True.ShowMultiFrameOverlay();
        }

        private void Button_RemoveDelete_Resize_True_Click(object sender, EventArgs e)
        {
            this.Thumbnail_Resize_True.RemoveDeleteOverlay();
        }

        private void Button_RemoveMulti_Resize_True_Click(object sender, EventArgs e)
        {
            this.Thumbnail_Resize_True.RemoveMultiFrameOverlay();
        }

        private void Button_MoveDelete_Resize_True_Click(object sender, EventArgs e)
        {
            int placement = (int)this.Thumbnail_Resize_True.DeleteIconPlacement;
            placement = placement % 5;
            placement++;
            this.Thumbnail_Resize_True.DeleteIconPlacement = (RdtThumbnailView.IconPlacementT)placement;
        }

        private void Button_MoveMulti_Resize_True_Click(object sender, EventArgs e)
        {
            int placement = (int)this.Thumbnail_Resize_True.MultiIconPlacement;
            placement = placement % 5;
            placement++;
            this.Thumbnail_Resize_True.MultiIconPlacement = (RdtThumbnailView.IconPlacementT)placement;
        }

        private void Button_ShowDelete_Resize_False_Click(object sender, EventArgs e)
        {
            this.Thumbnail_Resize_False.ShowDeleteOverlay();
        }

        private void Button_ShowMulti_Resize_false_Click(object sender, EventArgs e)
        {
            this.Thumbnail_Resize_False.ShowMultiFrameOverlay();
        }

        private void Button_RemoveDelete_Resize_False_Click(object sender, EventArgs e)
        {
            this.Thumbnail_Resize_False.RemoveDeleteOverlay();
        }

        private void Button_RemoveMulti_Resize_False_Click(object sender, EventArgs e)
        {
            this.Thumbnail_Resize_False.RemoveMultiFrameOverlay();
        }

        private void Button_MoveDelete_Resize_False_Click(object sender, EventArgs e)
        {
            int placement = (int)this.Thumbnail_Resize_False.DeleteIconPlacement;
            placement = placement % 5;
            placement++;
            this.Thumbnail_Resize_False.DeleteIconPlacement = (RdtThumbnailView.IconPlacementT)placement;
        }

        private void Button_MoveMulti_Resize_False_Click(object sender, EventArgs e)
        {
            int placement = (int)this.Thumbnail_Resize_False.MultiIconPlacement;
            placement = placement % 5;
            placement++;
            this.Thumbnail_Resize_False.MultiIconPlacement = (RdtThumbnailView.IconPlacementT)placement;
        }

        private void Button_Test_Click(object sender, EventArgs e)
        {
            RdtThumbnailView? component = new RdtThumbnailView();

            this.Controls.Add(component);

            component.Dispose();
            component = null;

            mCounter++;
            this.Label_TestCount.Text = "回数 = " + mCounter.ToString();
        }
    }
}

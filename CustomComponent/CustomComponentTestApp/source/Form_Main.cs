using log4net;
using log4net.Config;
using RADISTA.UIComponent.CustomControl;
using System.Diagnostics.Metrics;
using System.Drawing;
using CustomComponentTestApp.source;

namespace RADISTA.CustomComponentTestApp
{
    public partial class Form_Main : Form
    {
        private static readonly ILog mLog = LogManager.GetLogger(typeof(Form_Main));
        private Image? mImage1 = null;
        private Image? mImage2 = null;
        private Image? mImage3 = null;

        public Form_Main()
        {
            //XmlConfigurator.Configure(new FileInfo("log4net.config"));
            InitializeComponent();
        }

        private void Form_Main_Load(object sender, EventArgs e)
        {
            #region XML
            label_FontType.Text = ComponentCommon.GetFontType();
            label_FontSize.Text = ComponentCommon.GetFontSize().ToString();
            label_FontColor.Text = ComponentCommon.GetFontColor();
            label_BackColor.Text = ComponentCommon.GetBackColor();
            label_InactiveColor.Text = ComponentCommon.GetInactiveColor();
            label_InputBackColor.Text = ComponentCommon.GetInputBackColor();
            label_InputEdgeColor.Text = ComponentCommon.GetInputEdgeColor();
            label_ComponentEdgeColor.Text = ComponentCommon.GetComponentEdgeColor();
            #endregion
        }

        private void DisposeCustomSetting()
        {
            if (mImage1 != null)
            {
                mImage1.Dispose();
            }
            if (mImage2 != null)
            {
                mImage2.Dispose();
            }
            if (mImage3 != null)
            {
                mImage3.Dispose();
            }
        }

        private void button_Rdtlabel_Click(object sender, EventArgs e)
        {
            Form_Rdtlabel form = new Form_Rdtlabel();
            form.Show();
        }

        private void button_RdtButton_Click(object sender, EventArgs e)
        {
            Form_RdtButton form = new Form_RdtButton();
            form.Show();
        }

        private void button_RdtListButton_Click(object sender, EventArgs e)
        {

        }

        private void button_RdtTextBox_Click(object sender, EventArgs e)
        {
            Form_RdtTextBox form = new Form_RdtTextBox();
            form.Show();
        }

        private void button_RdtMaskTextBox_Click(object sender, EventArgs e)
        {
            Form_RdtMaskTextBox form = new Form_RdtMaskTextBox();
            form.Show();
        }

        private void button_RdtRichTextBox_Click(object sender, EventArgs e)
        {
            Form_RdtRichTextBox form = new Form_RdtRichTextBox();
            form.Show();
        }

        private void button_RdtRadioButton_Click(object sender, EventArgs e)
        {
            Form_RdtRadioButton form = new Form_RdtRadioButton();
            form.Show();
        }

        private void button_RdtCheckBox_Click(object sender, EventArgs e)
        {
            Form_RdtCheckBox form = new Form_RdtCheckBox();
            form.Show();
        }

        private void button_RdtToggleButton_Click(object sender, EventArgs e)
        {
            Form_RdtToggleButton form = new Form_RdtToggleButton();
            form.Show();
        }

        private void button_RdtCalendar_Click(object sender, EventArgs e)
        {

        }

        private void button_RdtTrackBar_Click(object sender, EventArgs e)
        {
            Form_RdtTrackBar form = new Form_RdtTrackBar();
            form.Show();
        }

        private void button_RdtProgressBar_Click(object sender, EventArgs e)
        {
            Form_RdtProgressBar form = new Form_RdtProgressBar();
            form.Show();
        }

        private void button_RdtSpinBox_Click(object sender, EventArgs e)
        {
            Form_RdtSpinBox form = new Form_RdtSpinBox();
            form.Show();
        }

        private void button_RdtThumbnailView_Click(object sender, EventArgs e)
        {
            Form_RdtThumbnailView form = new Form_RdtThumbnailView();
            form.Show();
        }

        private void button_RdtContextMenuStrip_Click(object sender, EventArgs e)
        {
            Form_RdtContextMenuStrip form = new Form_RdtContextMenuStrip();
            form.Show();
        }

        private void button_RdtDataGridView_Click(object sender, EventArgs e)
        {

        }

        private void button_RdtListView_Click(object sender, EventArgs e)
        {
            Form_RdtListView form = new Form_RdtListView();
            form.Show();
        }

        private void button_RdtTabControl_Click(object sender, EventArgs e)
        {

        }

        private void button_RdtMenuStrip_Click(object sender, EventArgs e)
        {
            Form_RdtMenuStrip form = new Form_RdtMenuStrip();
            form.Show();
        }

        private void button_RdtForm_Click(object sender, EventArgs e)
        {
            Form_RdtForm form = new Form_RdtForm();
            form.Show();
        }

        private void button_RdtGadget_Click(object sender, EventArgs e)
        {
            //Form_RdtGadget form = new Form_RdtGadget();
            //form.Show();
        }

        private void button_RdtDialog_Click(object sender, EventArgs e)
        {
            Form_RdtDialog form = new Form_RdtDialog();
            form.Show();
        }

        private void button_RdtMessageBox_Click(object sender, EventArgs e)
        {
            Form_RdtMessageBox form = new Form_RdtMessageBox();
            form.Show();
        }

        private void button_RdtPanel_Click(object sender, EventArgs e)
        {
            Form_RdtPanel form = new Form_RdtPanel();
            form.Show();
        }

        private void button_RdtSplitter_Click(object sender, EventArgs e)
        {
            Form_RdtSplitter form = new Form_RdtSplitter();
            form.Show();
        }

        private void button_RdtSplitContainer_Click(object sender, EventArgs e)
        {
            Form_RdtSplitContainer form = new Form_RdtSplitContainer();
            form.Show();
        }

        private void button_image1_Click(object sender, EventArgs e)
        {
            try
            {
                mImage1 = ComponentCommon.GetImageFromPath("image\\common_image1.jpg");
            }
            catch (Exception ex)
            {
                mLog.Error(ex);
            }
        }

        private void button_image2_Click(object sender, EventArgs e)
        {
            try
            {
                mImage2 = ComponentCommon.GetImageFromPath("image\\common_image2.jpg");
            }
            catch (Exception ex)
            {
                mLog.Error(ex);
            }
        }

        private void button_image3_Click(object sender, EventArgs e)
        {
            try
            {
                mImage3 = ComponentCommon.GetImageFromPath("image\\common_image3.jpg");
            }
            catch (Exception ex)
            {
                mLog.Error(ex);
            }
        }

        private void button_RdtListBox_Click(object sender, EventArgs e)
        {
            Form_RdtListBox form = new Form_RdtListBox();
            form.Show();
        }
    }
}

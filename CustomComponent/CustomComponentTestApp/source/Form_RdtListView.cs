using log4net;
using RADISTA.UIComponent.CustomControl;

namespace RADISTA.CustomComponentTestApp
{
    public partial class Form_RdtListView : Form
    {
        private static readonly ILog mLog = LogManager.GetLogger(typeof(Form_RdtListView));
        private int mCounter = 0;
        public Form_RdtListView()
        {
            InitializeComponent();
        }

        private void Form_RdtListView_Load(object sender, EventArgs e)
        {
            label_FontType.Text = rdtListView_Default.Font.Name;
            label_FontSize.Text = rdtListView_Default.Font.Size.ToString();
            label_FontColor.Text = $"#{rdtListView_Default.ForeColor.R:X2}{rdtListView_Default.ForeColor.G:X2}{rdtListView_Default.ForeColor.B:X2}";
            label_BackColor.Text = $"#{rdtListView_Default.BackColor.R:X2}{rdtListView_Default.BackColor.G:X2}{rdtListView_Default.BackColor.B:X2}";
            label_IsBackgroundRowColor.Text = rdtListView_Default.IsBackgroundColor.ToString();
            label_IsShowIcon.Text = rdtListView_Default.IsShowIcon.ToString();
            label_IsShowCheckBox.Text = rdtListView_Default.IsShowCheckBox.ToString();

            label_IsBackgroundRowColor_true.Text = rdtListView_IsBackgroundRowColor.IsBackgroundColor.ToString();
            label_BackgroundRowColor.Text = rdtListView_IsBackgroundRowColor.BackgroundRowColor.ToString();
            label_IsShowIcon_true.Text = rdtListView_IsShowIcon.IsShowIcon.ToString();
            label_IsShowCheckBox_true.Text = rdtListView_IsShowCheckBox.IsShowCheckBox.ToString();

            label_IconError.Text = rdtListView_IconError.IsShowIcon.ToString();
            label_IconPathList_Count.Text = (rdtListView_IconError.IconPathList?.Length ?? 0).ToString();
            label_ListViewItem_Count.Text = (rdtListView_IconError.Items?.Count ?? 0).ToString();
            label_CheckBoxError.Text = rdtListView_CheckBoxError.IsShowCheckBox.ToString();

            label_AdjustPosition_CheckBox.Text = rdtListView_AdjustPosition.IsShowCheckBox.ToString();
            label_AdjustPositionIcon.Text = rdtListView_AdjustPosition.IsShowIcon.ToString();

        }

        private void button_New_Delete_Click(object sender, EventArgs e)
        {
            RdtListView? component = new RdtListView();
            this.Controls.Add(component);

            this.Controls.Remove(component);
            component.Dispose();
            component = null;

            mCounter++;
            label_Count.Text = mCounter.ToString();
        }
    }
}

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
            #region XMLì«Ç›çûÇ›
            #region ÉtÉHÉìÉg
            label_FontType.Text = ComponentCommon.GetFontType();
            label_FontSize.Text = ComponentCommon.GetFontSize().ToString();
            label_FontColor.Text = ComponentCommon.GetFontColor();
            label_FontDisableColor.Text = ComponentCommon.GetFontDisableColor();
            label_FontFocusColor.Text = ComponentCommon.GetFontFocusColor();
            label_FontReadOnlyColor.Text = ComponentCommon.GetFontReadOnlyColor();
            #endregion
            #region  Form, Dialog 
            label_FormDefaultFontColor.Text = ComponentCommon.GetFormDefaultFontColor();
            label_FormDefaultBackColor.Text = ComponentCommon.GetFormDefaultBackColor();
            label_FormTitlebarFontColor.Text = ComponentCommon.GetFormTitlebarFontColor();
            label_FormTitlebarBackColor.Text = ComponentCommon.GetFormTitlebarBackColor();
            #endregion
            #region Label
            label_LabelDefaultFontColor.Text = ComponentCommon.GetLabelDefaultFontColor();
            label_LabelDefaultBackColor.Text = ComponentCommon.GetLabelDefaultBackColor();
            label_LabelDefaultEdgeColor.Text = ComponentCommon.GetLabelDefaultEdgeColor();
            #endregion
            #region TextBox
            label_TextDefaultFontColor.Text = ComponentCommon.GetTextDefaultFontColor();
            label_TextDefaultBackColor.Text = ComponentCommon.GetTextDefaultBackColor();
            label_TextDefaultEdgeColor.Text = ComponentCommon.GetTextDefaultEdgeColor();
            label_TextHoverFontColor.Text = ComponentCommon.GetTextHoverFontColor();
            label_TextHoverBackColor.Text = ComponentCommon.GetTextHoverBackColor();
            label_TextHoverEdgeColor.Text = ComponentCommon.GetTextHoverEdgeColor();
            label_TextFocusFontColor.Text = ComponentCommon.GetTextFocusFontColor();
            label_TextFocusBackColor.Text = ComponentCommon.GetTextFocusBackColor();
            label_TextFocusEdgeColor.Text = ComponentCommon.GetTextFocusEdgeColor();
            label_TextInputFontColor.Text = ComponentCommon.GetTextInputFontColor();
            label_TextInputBackColor.Text = ComponentCommon.GetTextInputBackColor();
            label_TextInputEdgeColor.Text = ComponentCommon.GetTextInputEdgeColor();
            label_TextDisableFontColor.Text = ComponentCommon.GetTextDisableFontColor();
            label_TextDisableBackColor.Text = ComponentCommon.GetTextDisableBackColor();
            label_TextDisableEdgeColor.Text = ComponentCommon.GetTextDisableEdgeColor();
            label_TextReadOnlyFontColor.Text = ComponentCommon.GetTextReadOnlyFontColor();
            label_TextReadOnlyBackColor.Text = ComponentCommon.GetTextReadOnlyBackColor();
            label_TextReadOnlyEdgeColor.Text = ComponentCommon.GetTextReadOnlyEdgeColor();
            label_TextWaterMarkFontColor.Text = ComponentCommon.GetTextWaterMarkFontColor();
            #endregion
            #region ComboBox
            label_ComboDefaultFontColor.Text = ComponentCommon.GetComboDefaultFontColor();
            label_ComboDefaultBackColor.Text = ComponentCommon.GetComboDefaultBackColor();
            label_ComboDefaultEdgeColor.Text = ComponentCommon.GetComboDefaultEdgeColor();
            label_ComboHoverFontColor.Text = ComponentCommon.GetComboHoverFontColor();
            label_ComboHoverBackColor.Text = ComponentCommon.GetComboHoverBackColor();
            label_ComboHoverEdgeColor.Text = ComponentCommon.GetComboHoverEdgeColor();
            label_ComboFocusFontColor.Text = ComponentCommon.GetComboFocusFontColor();
            label_ComboFocusBackColor.Text = ComponentCommon.GetComboFocusBackColor();
            label_ComboFocusEdgeColor.Text = ComponentCommon.GetComboFocusEdgeColor();
            label_ComboDisableFontColor.Text = ComponentCommon.GetComboDisableFontColor();
            label_ComboDisableBackColor.Text = ComponentCommon.GetComboDisableBackColor();
            label_ComboDisableEdgeColor.Text = ComponentCommon.GetComboDisableEdgeColor();
            #endregion
            #region ListView, ListBox
            label_ListDefaultStandardFontColor.Text = ComponentCommon.GetListDefaultStandardFontColor();
            label_ListDefaultStandardBackColor.Text = ComponentCommon.GetListDefaultStandardBackColor();
            label_ListDefaultStandardEdgeColor.Text = ComponentCommon.GetListDefaultStandardEdgeColor();
            label_ListDefaultFlatFontColor.Text = ComponentCommon.GetListDefaultFlatFontColor();
            label_ListDefaultFlatBackColor.Text = ComponentCommon.GetListDefaultFlatBackColor();
            label_ListDefaultFlatEdgeColor.Text = ComponentCommon.GetListDefaultFlatEdgeColor();
            label_ListHoverStandardFontColor.Text = ComponentCommon.GetListHoverStandardFontColor();
            label_ListHoverStandardBackColor.Text = ComponentCommon.GetListHoverStandardBackColor();
            label_ListHoverStandardEdgeColor.Text = ComponentCommon.GetListHoverStandardEdgeColor();
            label_ListHoverFlatFontColor.Text = ComponentCommon.GetListHoverFlatFontColor();
            label_ListHoverFlatBackColor.Text = ComponentCommon.GetListHoverFlatBackColor();
            label_ListHoverFlatEdgeColor.Text = ComponentCommon.GetListHoverFlatEdgeColor();
            label_ListDisableStandardFontColor.Text = ComponentCommon.GetListDisableStandardFontColor();
            label_ListDisableStandardBackColor.Text = ComponentCommon.GetListDisableStandardBackColor();
            label_ListDisableStandardEdgeColor.Text = ComponentCommon.GetListDisableStandardEdgeColor();
            label_ListDisableFlatFontColor.Text = ComponentCommon.GetListDisableFlatFontColor();
            label_ListDisableFlatBackColor.Text = ComponentCommon.GetListDisableFlatBackColor();
            label_ListDisableFlatEdgeColor.Text = ComponentCommon.GetListDisableFlatEdgeColor();
            #endregion
            #region ContextMenuStrip
            label_ContextDefaultFontColor.Text = ComponentCommon.GetContextDefaultFontColor();
            label_ContextDefaultBackColor.Text = ComponentCommon.GetContextDefaultBackColor();
            label_ContextDefaultEdgeColor.Text = ComponentCommon.GetContextDefaultEdgeColor();
            label_ContextHoverFontColor.Text = ComponentCommon.GetContextHoverFontColor();
            label_ContextHoverBackColor.Text = ComponentCommon.GetContextHoverBackColor();
            label_ContextHoverEdgeColor.Text = ComponentCommon.GetContextHoverEdgeColor();
            label_ContextSelectedFontColor.Text = ComponentCommon.GetContextSelectedFontColor();
            label_ContextSelectedBackColor.Text = ComponentCommon.GetContextSelectedBackColor();
            label_ContextSelectedEdgeColor.Text = ComponentCommon.GetContextSelectedEdgeColor();
            label_ContextSelectedHoverFontColor.Text = ComponentCommon.GetContextSelectedHoverFontColor();
            label_ContextSelectedHoverBackColor.Text = ComponentCommon.GetContextSelectedHoverBackColor();
            label_ContextSelectedHoverEdgeColor.Text = ComponentCommon.GetContextSelectedHoverEdgeColor();
            label_ContextDisableFontColor.Text = ComponentCommon.GetContextDisableFontColor();
            label_ContextDisableBackColor.Text = ComponentCommon.GetContextDisableBackColor();
            label_ContextDisableEdgeColor.Text = ComponentCommon.GetContextDisableEdgeColor();
            #endregion
            #region MenuStrip
            label_MenuDefaultFontColor.Text = ComponentCommon.GetMenuDefaultFontColor();
            label_MenuDefaultBackColor.Text = ComponentCommon.GetMenuDefaultBackColor();
            label_MenuHoverFontColor.Text = ComponentCommon.GetMenuHoverFontColor();
            label_MenuHoverBackColor.Text = ComponentCommon.GetMenuHoverBackColor();
            label_MenuDisableFontColor.Text = ComponentCommon.GetMenuDisableFontColor();
            label_MenuDisableBackColor.Text = ComponentCommon.GetMenuDisableBackColor();
            #endregion
            #region Button
            label_ButtonDefaultPrimaryFontColor.Text = ComponentCommon.GetButtonDefaultPrimaryFontColor();
            label_ButtonDefaultPrimaryBackColor.Text = ComponentCommon.GetButtonDefaultPrimaryBackColor();
            label_ButtonDefaultPrimaryEdgeColor.Text = ComponentCommon.GetButtonDefaultPrimaryEdgeColor();
            label_ButtonDefaultTonalFontColor.Text = ComponentCommon.GetButtonDefaultTonalFontColor();
            label_ButtonDefaultTonalBackColor.Text = ComponentCommon.GetButtonDefaultTonalBackColor();
            label_ButtonDefaultTonalEdgeColor.Text = ComponentCommon.GetButtonDefaultTonalEdgeColor();
            label_ButtonDefaultOutlinedFontColor.Text = ComponentCommon.GetButtonDefaultOutlinedFontColor();
            label_ButtonDefaultOutlinedBackColor.Text = ComponentCommon.GetButtonDefaultOutlinedBackColor();
            label_ButtonDefaultOutlinedEdgeColor.Text = ComponentCommon.GetButtonDefaultOutlinedEdgeColor();
            label_ButtonDefaultTextFontColor.Text = ComponentCommon.GetButtonDefaultTextFontColor();
            label_ButtonDefaultTextBackColor.Text = ComponentCommon.GetButtonDefaultTextBackColor();
            label_ButtonDefaultTextEdgeColor.Text = ComponentCommon.GetButtonDefaultTextEdgeColor();
            label_ButtonHoverPrimaryFontColor.Text = ComponentCommon.GetButtonHoverPrimaryFontColor();
            label_ButtonHoverPrimaryBackColor.Text = ComponentCommon.GetButtonHoverPrimaryBackColor();
            label_ButtonHoverPrimaryEdgeColor.Text = ComponentCommon.GetButtonHoverPrimaryEdgeColor();
            label_ButtonHoverTonalFontColor.Text = ComponentCommon.GetButtonHoverTonalFontColor();
            label_ButtonHoverTonalBackColor.Text = ComponentCommon.GetButtonHoverTonalBackColor();
            label_ButtonHoverTonalEdgeColor.Text = ComponentCommon.GetButtonHoverTonalEdgeColor();
            label_ButtonHoverOutlinedFontColor.Text = ComponentCommon.GetButtonHoverOutlinedFontColor();
            label_ButtonHoverOutlinedBackColor.Text = ComponentCommon.GetButtonHoverOutlinedBackColor();
            label_ButtonHoverOutlinedEdgeColor.Text = ComponentCommon.GetButtonHoverOutlinedEdgeColor();
            label_ButtonHoverTextFontColor.Text = ComponentCommon.GetButtonHoverTextFontColor();
            label_ButtonHoverTextBackColor.Text = ComponentCommon.GetButtonHoverTextBackColor();
            label_ButtonHoverTextEdgeColor.Text = ComponentCommon.GetButtonHoverTextEdgeColor();
            label_ButtonPressedPrimaryFontColor.Text = ComponentCommon.GetButtonPressedPrimaryFontColor();
            label_ButtonPressedPrimaryBackColor.Text = ComponentCommon.GetButtonPressedPrimaryBackColor();
            label_ButtonPressedPrimaryEdgeColor.Text = ComponentCommon.GetButtonPressedPrimaryEdgeColor();
            label_ButtonPressedTonalFontColor.Text = ComponentCommon.GetButtonPressedTonalFontColor();
            label_ButtonPressedTonalBackColor.Text = ComponentCommon.GetButtonPressedTonalBackColor();
            label_ButtonPressedTonalEdgeColor.Text = ComponentCommon.GetButtonPressedTonalEdgeColor();
            label_ButtonPressedOutlinedFontColor.Text = ComponentCommon.GetButtonPressedOutlinedFontColor();
            label_ButtonPressedOutlinedBackColor.Text = ComponentCommon.GetButtonPressedOutlinedBackColor();
            label_ButtonPressedOutlinedEdgeColor.Text = ComponentCommon.GetButtonPressedOutlinedEdgeColor();
            label_ButtonPressedTextFontColor.Text = ComponentCommon.GetButtonPressedTextFontColor();
            label_ButtonPressedTextBackColor.Text = ComponentCommon.GetButtonPressedTextBackColor();
            label_ButtonPressedTextEdgeColor.Text = ComponentCommon.GetButtonPressedTextEdgeColor();
            label_ButtonDisablePrimaryFontColor.Text = ComponentCommon.GetButtonDisablePrimaryFontColor();
            label_ButtonDisablePrimaryBackColor.Text = ComponentCommon.GetButtonDisablePrimaryBackColor();
            label_ButtonDisablePrimaryEdgeColor.Text = ComponentCommon.GetButtonDisablePrimaryEdgeColor();
            label_ButtonDisableTonalFontColor.Text = ComponentCommon.GetButtonDisableTonalFontColor();
            label_ButtonDisableTonalBackColor.Text = ComponentCommon.GetButtonDisableTonalBackColor();
            label_ButtonDisableTonalEdgeColor.Text = ComponentCommon.GetButtonDisableTonalEdgeColor();
            label_ButtonDisableOutlinedFontColor.Text = ComponentCommon.GetButtonDisableOutlinedFontColor();
            label_ButtonDisableOutlinedBackColor.Text = ComponentCommon.GetButtonDisableOutlinedBackColor();
            label_ButtonDisableOutlinedEdgeColor.Text = ComponentCommon.GetButtonDisableOutlinedEdgeColor();
            label_ButtonDisableTextFontColor.Text = ComponentCommon.GetButtonDisableTextFontColor();
            label_ButtonDisableTextBackColor.Text = ComponentCommon.GetButtonDisableTextBackColor();
            label_ButtonDisableTextEdgeColor.Text = ComponentCommon.GetButtonDisableTextEdgeColor();
            #endregion
            #region ToggleButton
            label_ToggleOnTonalFontColor.Text = ComponentCommon.GetToggleOnTonalFontColor();
            label_ToggleOnTonalBackColor.Text = ComponentCommon.GetToggleOnTonalBackColor();
            label_ToggleOnTonalEdgeColor.Text = ComponentCommon.GetToggleOnTonalEdgeColor();
            label_ToggleOnOutlinedFontColor.Text = ComponentCommon.GetToggleOnOutlinedFontColor();
            label_ToggleOnOutlinedBackColor.Text = ComponentCommon.GetToggleOnOutlinedBackColor();
            label_ToggleOnOutlinedEdgeColor.Text = ComponentCommon.GetToggleOnOutlinedEdgeColor();
            label_ToggleOnTextFontColor.Text = ComponentCommon.GetToggleOnTextFontColor();
            label_ToggleOnTextBackColor.Text = ComponentCommon.GetToggleOnTextBackColor();
            label_ToggleOnTextEdgeColor.Text = ComponentCommon.GetToggleOnTextEdgeColor();
            label_ToggleOffTonalFontColor.Text = ComponentCommon.GetToggleOffTonalFontColor();
            label_ToggleOffTonalBackColor.Text = ComponentCommon.GetToggleOffTonalBackColor();
            label_ToggleOffTonalEdgeColor.Text = ComponentCommon.GetToggleOffTonalEdgeColor();
            label_ToggleOffOutlinedFontColor.Text = ComponentCommon.GetToggleOffOutlinedFontColor();
            label_ToggleOffOutlinedBackColor.Text = ComponentCommon.GetToggleOffOutlinedBackColor();
            label_ToggleOffOutlinedEdgeColor.Text = ComponentCommon.GetToggleOffOutlinedEdgeColor();
            label_ToggleOffTextFontColor.Text = ComponentCommon.GetToggleOffTextFontColor();
            label_ToggleOffTextBackColor.Text = ComponentCommon.GetToggleOffTextBackColor();
            label_ToggleOffTextEdgeColor.Text = ComponentCommon.GetToggleOffTextEdgeColor();
            #endregion
            #region Calendar
            label_CalendarDefaultFontColor.Text = ComponentCommon.GetCalendarDefaultFontColor();
            label_CalendarDefaultBackColor.Text = ComponentCommon.GetCalendarDefaultBackColor();
            label_CalendarDefaultTitleFontColor.Text = ComponentCommon.GetCalendarDefaultTitleFontColor();
            label_CalendarDefaultTitleBackColor.Text = ComponentCommon.GetCalendarDefaultTitleBackColor();
            label_CalendarDefaultTrailingFontColor.Text = ComponentCommon.GetCalendarDefaultTrailingFontColor();
            #endregion
            #region ProgressBar
            label_ProgressDefaultFontColor.Text = ComponentCommon.GetProgressDefaultFontColor();
            label_ProgressDefaultBackColor.Text = ComponentCommon.GetProgressDefaultBackColor();
            #endregion
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

        private void button_RdtComboBox_Click(object sender, EventArgs e)
        {
            Form_RdtComboBox form = new Form_RdtComboBox();
            form.Show();
        }
    }
}

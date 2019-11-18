using System;
using System.Windows.Forms;
using AxMSVidCtlLib;
partial class MainForm : Form {
	//Menu bar 
	private MenuStrip menuStrip;
	private ToolStripMenuItem menuFile, menuFileNew, menuFileEixt, menuHelp, menuHelpAbout;

	//Encode Setting
	private Label encodeLabel, outPutFileNameLabel, encoderLabel, outPutVideoLabel, outPutAudioLabel;
	private TextBox outPutFileName;
	private ComboBox resourceMachine, encodeProfile, encoder;
	private Button resourceMachineSetting, encodeProfileSaveButton;
	private CheckBox outPutVideoCheckBox, outPutAudioCheckBox;

	//Video Preview
	private AxMSVidCtl videoPreview;

	public MainForm() {
		InitializeComponent();
	}

	private void menuFileExitClick(object sender, EventArgs e) {
		this.Close();
	}

	private void menuHelpAboutClick(object sender, EventArgs e) {
		AboutForm aboutForm = new AboutForm();
		aboutForm.ShowDialog();
	}
	
	private void resourceMachineSettingClick(object sender, EventArgs e) {
		SettingForm settingForm = new SettingForm();
		settingForm.SelectSetting = "Resource Machines";
		settingForm.ShowDialog();
	}
}

using System;
using System.Windows.Forms;

public partial class MainForm : Form {
	//Menu bar 
	private MenuStrip menuStrip;
	private ToolStripMenuItem menuFile, menuFileNew, menuFileEixt, menuHelp, menuHelpAbout;

	//Main
	//Files
	private Label inputFileLabel, outputFileLabel, outputFolderLabel;
	private TextBox inputFilePath, outputFileName, outputFolderPath;
	private Button inputFileSelect, outputFolderSelect;

	//Settings
	private ComboBox resouceSelect, profileSelect;
	private Button resouceSetting, profileSetting;

	//EncodeExecute
	private Button encodeExecute;

	//VideoOptions
	private Panel videoOptions;
	private CheckBox encodeVideo;
	private ComboBox videoEncoder;
	private Label videoBitrateLabel, videoBitrateUnit;
	private NumericUpDown videoBitrate;
	private TrackBar videoBitrateBar;
	private Button videoOtherOptions;

	//AudioOptions
	private Panel audioOptions;
	private CheckBox encodeAudio, audioSamplingrateEnable;
	private ComboBox audioEncoder;
	private Label audioBitrateLabel, audioBitrateUnit, audioSamplingrateUnit;
	private NumericUpDown audioBitrate, audioSamplingrate;
	private TrackBar audioBitrateBar, audioSamplingrateBar;
	private Button audioOtherOptions;

	public MainForm() {
		InitializeComponent();
		Load += mainFormLoad;
	}

	private void mainFormLoad(object sender, EventArgs e) {
		this.loadSSHConfig();
	}

	//SSH Config Load
	private void loadSSHConfig() {
		SSHConfig sshConfig = new SSHConfig();
		var configs = sshConfig.Load();
		foreach (string key in configs.Keys) {
			this.resouceSelect.Items.Remove(key);
			this.resouceSelect.Items.Add(key);
		}
	}

	//Menu Bar
	private void menuFileExitClick(object sender, EventArgs e) {
		this.Close();
	}

	private void menuHelpAboutClick(object sender, EventArgs e) {
		AboutForm aboutForm = new AboutForm();
		aboutForm.ShowDialog();
	}

	//File Select
	private void inputFileCLick(object sender, EventArgs e) {
		OpenFileDialog openFile = new OpenFileDialog() {
			Multiselect = false,
		};

		if (openFile.ShowDialog() == DialogResult.OK) {
			this.inputFilePath.Text = openFile.FileName;
		}
	}

	//Folder Select
	private void outputFolderClick(object sender, EventArgs e) {
		FolderSelectDialog openFolder = new FolderSelectDialog();

		DialogResult result = openFolder.ShowDialog();
		if (result == DialogResult.OK) {
			this.outputFolderPath.Text = openFolder.Path;
		}
	}

	//Resouce Setting
	private void resouceSettingClick(object sender, EventArgs e) {
		SettingForm settingForm = new SettingForm();
		settingForm.SelectSetting = "Resource Machines";
		DialogResult result = settingForm.ShowDialog();
		if (result == DialogResult.OK) {
			this.loadSSHConfig();
		}
	}

	//Encode
	private void encodeClick(object sender, EventArgs e) {
		var key = this.resouceSelect.SelectedItem.ToString();
		var inputFile = this.inputFilePath.Text;
		if (inputFile == "") {
			return;
		}

		var swapFileName = inputFile.Split('\\');
		var fileName = swapFileName[swapFileName.Length - 1];
		var encode = new Encode();
		encode.UploadSCP(key, inputFile);

		var commnad = encode.MakeCommand(fileName, this.outputFileName.Text);
		Console.WriteLine(commnad);
		encode.Ffmpeg(key, commnad);

		encode.DownlaodSCP(key, @"C:\Users\yusei\Documents\ORE\", this.outputFileName.Text);
	}

	//Video Bitrate
	private void videoBitrateChange(object sender, EventArgs e) {
		this.videoBitrateBar.Value = (int)Math.Round((double)this.videoBitrate.Value / 10);
	}

	private void videoBitrateBarScroll(object sender, EventArgs e) {
		this.videoBitrate.Value = (decimal)((double)this.videoBitrateBar.Value * 10);
	}

	//Audio Bitrate
	private void audioBitrateChange(object sender, EventArgs e) {
		this.audioBitrateBar.Value = (int)Math.Round((double)this.audioBitrate.Value / 16);
	}

	private void audioBitrateBarScroll(object sender, EventArgs e) {
		this.audioBitrate.Value = (int)this.audioBitrateBar.Value * 16;
	}

	private void audioSamplingrateChange(object sender, EventArgs e) {
		this.audioSamplingrateBar.Value = (int)Math.Round((double)this.audioSamplingrate.Value / 1000);
	}

	private void audioSamplingrateBarScroll(object sender, EventArgs e) {
		this.audioSamplingrate.Value = (int)this.audioSamplingrateBar.Value * 1000;
	}
}

using System;
using System.Windows.Forms;
//using LibVLCSharp.Shared;
//using LibVLCSharp.WinForms;
partial class MainForm : Form {
	//Menu bar 
	private MenuStrip menuStrip;
	private ToolStripMenuItem menuFile, menuFileNew, menuFileEixt, menuHelp, menuHelpAbout;

	//Encode Setting
	private Label encodeLabel, inputFileNameLabel, outPutFileNameLabel, outputDirLabel, encoderLabel, outPutVideoLabel, outPutAudioLabel;
	private TextBox inputFileName, outPutFileName, outputDirPath;
	private ComboBox resourceMachine, encodeProfile, encoder;
	private Button inputFileSelect, outputDirSelect, resourceMachineSetting, encodeProfileManegerButton, encode;
	private CheckBox outPutVideoCheckBox, outPutAudioCheckBox;

	/*
	//Video Preview
	private LibVLC livVLC;
	private MediaPlayer mediaPlayer;
	private VideoView videoView;
	*/

	public MainForm() {
		/*
		if (!DesignMode) {
			Core.Initialize();
		}
		*/
		InitializeComponent();
		Load += mainFormLoad;
	}

	private void mainFormLoad(object sender, EventArgs e) {
	/*	
		this.mediaPlayer.Play(
			new Media(
				this.livVLC, 
				"http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4", 
				FromType.FromLocation
			)
		);
		*/
		this.loadSSHConfig();
	}

	private void loadSSHConfig() {
		SSHConfig sshConfig = new SSHConfig();
		var configs = sshConfig.Load();
		foreach (string key in configs.Keys) {
			this.resourceMachine.Items.Remove(key);
			this.resourceMachine.Items.Add(key);
		}
	}

	private void menuFileExitClick(object sender, EventArgs e) {
		this.Close();
	}

	private void menuHelpAboutClick(object sender, EventArgs e) {
		AboutForm aboutForm = new AboutForm();
		aboutForm.ShowDialog();
	}

	private void inputFileOpenClick(object sender, EventArgs e) {
		OpenFileDialog openFile = new OpenFileDialog() {
			Multiselect = false,
		};

		DialogResult result = openFile.ShowDialog();
		if (result == DialogResult.OK) {
			this.inputFileName.Text = openFile.FileName;
		}
	}
	private void outputFolderOpenClick(object sender, EventArgs e) {
		FolderBrowserDialog openFolder = new FolderBrowserDialog();

		DialogResult result = openFolder.ShowDialog();
		if (result == DialogResult.OK) {
			this.outputDirPath.Text = openFolder.SelectedPath;
		}
	}

	private void resourceMachineSettingClick(object sender, EventArgs e) {
		SettingForm settingForm = new SettingForm();
		settingForm.SelectSetting = "Resource Machines";
		DialogResult result = settingForm.ShowDialog();
		if (result == DialogResult.OK) {
			this.loadSSHConfig();
		}
	}

	private void encodeProfileManegerButtonClick(object sender, EventArgs e) {
		EncodeProfileForm encodeProfileForm = new EncodeProfileForm();
		encodeProfileForm.ShowDialog();
	}
	
	private void encodeClick(object sender, EventArgs e) {
		var key = this.resourceMachine.SelectedItem.ToString();
		var inputFile = this.inputFileName.Text;
		if (inputFile == "") {
			return;
		}

		var swapFileName = inputFile.Split('\\');
		var fileName = swapFileName[swapFileName.Length -1]; 
		var encode = new Encode();
		encode.UploadSCP(key, inputFile);

		var commnad = encode.MakeCommand(fileName, this.outPutFileName.Text);
		Console.WriteLine(commnad);
		encode.Ffmpeg(key, commnad);

		encode.DownlaodSCP(key, @"C:\Users\yusei\Documents\ORE\", this.outPutFileName.Text);
	}
}
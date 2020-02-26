using System;
using System.Drawing;
using System.Windows.Forms;
public partial class MainForm : Form {
	public void InitializeComponent() {
		int margen = 15;
		int curW, curH;
		string fontFamilyName = SystemFonts.DefaultFont.FontFamily.Name;
		int mainSize = 400;

		//Main
		//Files
		this.inputFileLabel = new Label();
		this.outputFileLabel = new Label();
		this.outputFolderLabel = new Label();
		this.inputFilePath = new TextBox();
		this.outputFileName = new TextBox();
		this.outputFolderPath = new TextBox();
		this.inputFileSelect = new Button();
		this.outputFolderSelect = new Button();

		//Settings
		this.resouceSelect = new ComboBox();
		this.profileSelect = new ComboBox();
		this.resouceSetting = new Button();
		this.profileSetting = new Button();

		//EncodeExecute
		this.encodeExecute = new Button();

		//VideoOptions
		this.videoOptions = new Panel();
		this.encodeVideo = new CheckBox();
		this.videoEncoder = new ComboBox();
		this.videoBitrateLabel = new Label();
		this.videoBitrate = new NumericUpDown();
		this.videoBitrateUnit = new Label();
		this.videoBitrateBar = new TrackBar();
		this.videoOtherOptions = new Button();

		//AudioOptions
		this.audioOptions = new Panel();
		this.encodeAudio = new CheckBox();
		this.audioEncoder = new ComboBox();
		this.audioBitrateLabel = new Label();
		this.audioBitrate = new NumericUpDown();
		this.audioBitrateUnit = new Label();
		this.audioBitrateBar = new TrackBar();
		this.audioSamplingrateEnable = new CheckBox();
		this.audioSamplingrate = new NumericUpDown();
		this.audioSamplingrateUnit = new Label();
		this.audioSamplingrateBar = new TrackBar();
		this.audioOtherOptions = new Button();

		//Menu bar 
		this.menuStrip = new MenuStrip();
		this.menuFile = new ToolStripMenuItem();
		this.menuFileNew = new ToolStripMenuItem();
		this.menuFileEixt = new ToolStripMenuItem();
		this.menuHelp = new ToolStripMenuItem();
		this.menuHelpAbout = new ToolStripMenuItem();

		curW = curH = margen;

		//Client
		this.Text = "Other Resource Encoder";

		int mainFormW = 800 + margen * 3;
		int mainFormH = 545;
		this.ClientSize = new Size(mainFormW, mainFormH);
		this.MainMenuStrip = this.menuStrip;

		//Menu Bar
		this.menuFile.Text = "File(F)";
		this.menuFile.DropDownItems.AddRange(new ToolStripItem[] {
			this.menuFileNew,
			this.menuFileEixt,
		});

		this.menuFileNew.Text = "New(N)";
		this.menuFileNew.ShortcutKeys = Keys.Control | Keys.N;

		this.menuFileEixt.Text = "Exit(X)";
		this.menuFileEixt.ShortcutKeys = Keys.Alt | Keys.F4;

		this.menuHelp.Text = "Help(H)";
		this.menuHelp.DropDownItems.AddRange(new ToolStripItem[] {
			this.menuHelpAbout,
		});

		this.menuHelpAbout.Text = "About(A)";
		this.menuStrip.Items.AddRange(new ToolStripItem[]{
			this.menuFile,
			this.menuHelp,
		});

		curH += this.MainMenuStrip.Size.Height;

		//Main

		this.inputFileLabel.Text = "Select File To Encode";
		this.inputFileLabel.Font = new Font(fontFamilyName, 16f);
		this.inputFileLabel.Size = new Size(300, 30);
		this.inputFileLabel.Location = new Point(curW, curH);

		curH += this.inputFileLabel.Size.Height;

		this.inputFilePath.Font = new Font(fontFamilyName, 16f);
		this.inputFilePath.AutoSize = false;
		this.inputFilePath.Size = new Size(320, 30);
		this.inputFilePath.Location = new Point(curW, curH);

		this.inputFileSelect.Text = "Select";
		this.inputFileSelect.Font = new Font(fontFamilyName, 16f);
		this.inputFileSelect.Size = new Size(80, 30);
		this.inputFileSelect.Location = new Point(curW + this.inputFilePath.Size.Width, curH);
		this.inputFileSelect.Click += new EventHandler(inputFileCLick);

		curH += this.inputFilePath.Size.Height;

		this.outputFileLabel.Text = "Output File Name";
		this.outputFileLabel.Font = new Font(fontFamilyName, 16f);
		this.outputFileLabel.Size = new Size(200, 30);
		this.outputFileLabel.Location = new Point(curW, curH);

		curH += this.outputFileLabel.Size.Height;

		this.outputFileName.Font = new Font(fontFamilyName, 16f);
		this.outputFileName.AutoSize = false;
		this.outputFileName.Size = new Size(400, 30);
		this.outputFileName.Location = new Point(curW, curH);

		curH += this.outputFileName.Size.Height;

		this.outputFolderLabel.Text = "Output Folder";
		this.outputFolderLabel.Font = new Font(fontFamilyName, 16f);
		this.outputFolderLabel.Size = new Size(200, 30);
		this.outputFolderLabel.Location = new Point(curW, curH);

		curH += this.outputFolderLabel.Size.Height;

		this.outputFolderPath.Font = new Font(fontFamilyName, 16f);
		this.outputFolderPath.AutoSize = false;
		this.outputFolderPath.Size = new Size(320, 30);
		this.outputFolderPath.Location = new Point(curW, curH);

		this.outputFolderSelect.Text = "Select";
		this.outputFolderSelect.Font = new Font(fontFamilyName, 16f);
		this.outputFolderSelect.Size = new Size(80, 30);
		this.outputFolderSelect.Location = new Point(curW + this.outputFolderPath.Size.Width, curH);
		this.outputFolderSelect.Click += new EventHandler(outputFolderClick);

		curH += this.outputFolderPath.Size.Height + margen;

		this.resouceSelect.Items.AddRange(new object[] {
			"Resouce Machine"
		});
		this.resouceSelect.SelectedIndex = 0;
		this.resouceSelect.DropDownStyle = ComboBoxStyle.DropDownList;
		this.resouceSelect.ItemHeight = 33;
		this.resouceSelect.Font = new Font(fontFamilyName, 16f);
		this.resouceSelect.Size = new Size(315, 30);
		this.resouceSelect.Location = new Point(curW, curH);

		this.resouceSetting.Text = "Setting";
		this.resouceSetting.Font = new Font(fontFamilyName, 16f);
		this.resouceSetting.Size = new Size(85, 30);
		this.resouceSetting.Location = new Point(curW + this.resouceSelect.Size.Width, curH);
		this.resouceSetting.Click += new EventHandler(resouceSettingClick);

		curH += this.resouceSelect.Size.Height + margen;

		this.profileSelect.Items.AddRange(new object[] {
			"Profile"
		});
		this.profileSelect.SelectedIndex = 0;
		this.profileSelect.DropDownStyle = ComboBoxStyle.DropDownList;
		this.profileSelect.Font = new Font(fontFamilyName, 16f);
		this.profileSelect.Size = new Size(315, 30);
		this.profileSelect.AutoSize = false;
		this.profileSelect.Location = new Point(curW, curH);

		this.profileSetting.Text = "Setting";
		this.profileSetting.Font = new Font(fontFamilyName, 16f);
		this.profileSetting.Size = new Size(85, 30);
		this.profileSetting.Location = new Point(curW + this.profileSelect.Size.Width, curH);

		curH += this.profileSelect.Size.Height + margen;
		this.encodeExecute.Text = "Encode";
		this.encodeExecute.Font = new Font(fontFamilyName, 16f);
		this.encodeExecute.Size = new Size(100, 30);
		this.encodeExecute.Location = new Point(curW, curH);
		this.encodeExecute.Click += new EventHandler(encodeClick);

		//VideoOptions
		this.videoOptions.BorderStyle = BorderStyle.FixedSingle;
		this.videoOptions.Size = new Size(400, 200);
		this.videoOptions.Location = new Point(
			mainSize + margen * 2,
			this.MainMenuStrip.Size.Height + margen
		);

		int vcurW, vcurH;
		vcurW = vcurH = margen;

		this.encodeVideo.Text = "Video";
		this.encodeVideo.Font = new Font(fontFamilyName, 16f);
		this.encodeVideo.Size = new Size(100, 30);
		this.encodeVideo.Location = new Point(vcurW, vcurH);

		vcurH += encodeVideo.Size.Height;

		this.videoEncoder.Items.AddRange(new object[]{
			"Codec Copy",
			"libx264",
			"libx265",
			"h264",
			"hevc",
			"flv1",
			"mjpeg",
			"mpeg1video",
			"mpeg2video",
			"msvideo1",
			"vp3",
			"vp6",
			"vp6a",
			"vp6f",
			"vp7",
			"vp8",
			"vp9",
			"wmv1",
			"wmv2",
			"wmv3",
		});
		this.videoEncoder.SelectedIndex = 0;
		this.videoEncoder.DropDownStyle = ComboBoxStyle.DropDownList;
		this.videoEncoder.Font = new Font(fontFamilyName, 16f);
		this.videoEncoder.Size = new Size(400 - margen * 2, 30);
		this.videoEncoder.Location = new Point(vcurW, vcurH);

		vcurH += this.videoEncoder.Size.Height;

		this.videoBitrateLabel.Text = "Bitrate";
		this.videoBitrateLabel.Font = new Font(fontFamilyName, 16f);
		this.videoBitrateLabel.Size = new Size(160, 30);
		this.videoBitrateLabel.Location = new Point(vcurW, vcurH);

		this.videoBitrate.Minimum = 0;
		this.videoBitrate.Maximum = 500;
		this.videoBitrate.Value = (decimal)12.00;
		this.videoBitrate.DecimalPlaces = 2;
		this.videoBitrate.Font = new Font(fontFamilyName, 16f);
		this.videoBitrate.TextAlign = HorizontalAlignment.Right;
		this.videoBitrate.Size = new Size(95, 30);
		this.videoBitrate.Location = new Point(vcurW + this.videoBitrateLabel.Size.Width + margen, vcurH);
		this.videoBitrate.ValueChanged += new EventHandler(videoBitrateChange);

		this.videoBitrateUnit.Text = "Mbps";
		this.videoBitrateUnit.Font = new Font(fontFamilyName, 16f);
		this.videoBitrateUnit.Size = new Size(75, 30);
		this.videoBitrateUnit.Location = new Point(
			this.videoBitrate.Location.X + this.videoBitrate.Size.Width,
			vcurH
		);

		vcurH += this.videoBitrateUnit.Size.Height;

		this.videoBitrateBar.Minimum = 0;
		this.videoBitrateBar.Maximum = 50;
		this.videoBitrateBar.Value = 30;
		this.videoBitrateBar.Size = new Size(400 - margen * 2, 30);
		this.videoBitrateBar.Location = new Point(vcurW, vcurH);
		this.videoBitrateBar.Scroll += new EventHandler(videoBitrateBarScroll);

		vcurH += this.videoBitrateBar.Size.Height;

		this.videoOtherOptions.Text = "Options";
		this.videoOtherOptions.Font = new Font(fontFamilyName, 16f);
		this.videoOtherOptions.Size = new Size(100, 30);
		this.videoOtherOptions.Location = new Point(
			this.videoOptions.Width - margen - this.videoOtherOptions.Size.Width,
			this.videoOptions.Height - margen - this.videoOtherOptions.Size.Height
		);

		this.videoOptions.Controls.Add(this.encodeVideo);
		this.videoOptions.Controls.Add(this.videoEncoder);
		this.videoOptions.Controls.Add(this.videoBitrateLabel);
		this.videoOptions.Controls.Add(this.videoBitrate);
		this.videoOptions.Controls.Add(this.videoBitrateUnit);
		this.videoOptions.Controls.Add(this.videoBitrateBar);
		this.videoOptions.Controls.Add(this.videoOtherOptions);

		//AudioOptions
		this.audioOptions.BorderStyle = BorderStyle.FixedSingle;
		this.audioOptions.Size = new Size(400, 275);
		this.audioOptions.Location = new Point(
			mainSize + margen * 2,
			this.videoOptions.Location.Y + this.videoOptions.Size.Height + margen);

		int acurW, acurH;
		acurW = acurH = margen;

		this.encodeAudio.Text = "Audio";
		this.encodeAudio.Font = new Font(fontFamilyName, 16f);
		this.encodeAudio.Size = new Size(100, 30);
		this.encodeAudio.Location = new Point(acurW, acurH);

		acurH += encodeAudio.Size.Height;

		this.audioEncoder.Items.AddRange(new object[]{
			"Codec Copy",
			"libmp3lame",
			"aac",
			"alac",
			"on2",
			"mp1",
			"mp2",
			"mp3",
			"opus",
			"pcm_s16le",
			"pcm_s24le",
			"vorbis",
			"wmav1",
			"wmav2",
		});
		this.audioEncoder.SelectedIndex = 0;
		this.audioEncoder.DropDownStyle = ComboBoxStyle.DropDownList;
		this.audioEncoder.Font = new Font(fontFamilyName, 16f);
		this.audioEncoder.Size = new Size(400 - margen * 2, 30);
		this.audioEncoder.Location = new Point(acurW, acurH);

		acurH += this.audioEncoder.Size.Height;

		this.audioBitrateLabel.Text = "Bitrate";
		this.audioBitrateLabel.Font = new Font(fontFamilyName, 16f);
		this.audioBitrateLabel.Size = new Size(160, 30);
		this.audioBitrateLabel.Location = new Point(acurW, acurH);

		this.audioBitrate.Minimum = 0;
		this.audioBitrate.Maximum = 1280;
		this.audioBitrate.Value = 128;
		this.audioBitrate.Font = new Font(fontFamilyName, 16f);
		this.audioBitrate.TextAlign = HorizontalAlignment.Right;
		this.audioBitrate.Size = new Size(95, 30);
		this.audioBitrate.Location = new Point(acurW + this.audioBitrateLabel.Size.Width + margen, acurH);
		this.audioBitrate.ValueChanged += new EventHandler(audioBitrateChange);

		this.audioBitrateUnit.Text = "Kbps";
		this.audioBitrateUnit.Font = new Font(fontFamilyName, 16f);
		this.audioBitrateUnit.Size = new Size(75, 30);
		this.audioBitrateUnit.Location = new Point(
			this.audioBitrate.Location.X + this.audioBitrate.Size.Width,
			acurH
		);

		acurH += this.audioBitrateUnit.Size.Height;

		this.audioBitrateBar.Minimum = 0;
		this.audioBitrateBar.Maximum = 80;
		this.audioBitrateBar.Value = 8;
		this.audioBitrateBar.Size = new Size(400 - margen * 2, 30);
		this.audioBitrateBar.Location = new Point(acurW, acurH);
		this.audioBitrateBar.Scroll += new EventHandler(audioSamplingrateChange);

		acurH += this.audioBitrateBar.Size.Height;

		this.audioSamplingrateEnable.Text = "Sampling Rate";
		this.audioSamplingrateEnable.Font = new Font(fontFamilyName, 16f);
		this.audioSamplingrateEnable.Size = new Size(160, 30);
		this.audioSamplingrateEnable.Location = new Point(acurW, acurH);

		this.audioSamplingrate.Minimum = 0;
		this.audioSamplingrate.Maximum = 1000000;
		this.audioSamplingrate.Value = 48000;
		this.audioSamplingrate.Font = new Font(fontFamilyName, 16f);
		this.audioSamplingrate.TextAlign = HorizontalAlignment.Right;
		this.audioSamplingrate.Size = new Size(95, 30);
		this.audioSamplingrate.Location = new Point(acurW + this.audioSamplingrateEnable.Size.Width + margen, acurH);

		this.audioSamplingrateUnit.Text = "Hz";
		this.audioSamplingrateUnit.Font = new Font(fontFamilyName, 16f);
		this.audioSamplingrateUnit.Size = new Size(75, 30);
		this.audioSamplingrateUnit.Location = new Point(
			this.audioSamplingrate.Location.X + this.audioSamplingrate.Size.Width,
			acurH
		);

		acurH += this.audioSamplingrateUnit.Size.Height;

		this.audioSamplingrateBar.Minimum = 0;
		this.audioSamplingrateBar.Maximum = 1000;
		this.audioSamplingrateBar.Value = 48;
		this.audioSamplingrateBar.Size = new Size(400 - margen * 2, 30);
		this.audioSamplingrateBar.Location = new Point(acurW, acurH);
		this.audioSamplingrateBar.Scroll += new EventHandler(audioSamplingrateBarScroll);

		acurH += this.audioSamplingrateBar.Size.Height;

		this.audioOtherOptions.Text = "Options";
		this.audioOtherOptions.Font = new Font(fontFamilyName, 16f);
		this.audioOtherOptions.Size = new Size(100, 30);
		this.audioOtherOptions.Location = new Point(
			this.audioOptions.Width - margen - this.audioOtherOptions.Size.Width,
			this.audioOptions.Height - margen - this.audioOtherOptions.Size.Height
		);

		this.audioOptions.Controls.Add(this.encodeAudio);
		this.audioOptions.Controls.Add(this.audioEncoder);
		this.audioOptions.Controls.Add(this.audioBitrateLabel);
		this.audioOptions.Controls.Add(this.audioBitrate);
		this.audioOptions.Controls.Add(this.audioBitrateUnit);
		this.audioOptions.Controls.Add(this.audioBitrateBar);
		this.audioOptions.Controls.Add(this.audioSamplingrateEnable);
		this.audioOptions.Controls.Add(this.audioSamplingrate);
		this.audioOptions.Controls.Add(this.audioSamplingrateUnit);
		this.audioOptions.Controls.Add(this.audioSamplingrateBar);
		this.audioOptions.Controls.Add(this.audioOtherOptions);

		this.Controls.Add(this.menuStrip);
		this.Controls.Add(this.inputFileLabel);
		this.Controls.Add(this.inputFilePath);
		this.Controls.Add(this.inputFileSelect);
		this.Controls.Add(this.outputFileLabel);
		this.Controls.Add(this.outputFileName);
		this.Controls.Add(this.outputFolderLabel);
		this.Controls.Add(this.outputFolderPath);
		this.Controls.Add(this.outputFolderSelect);
		this.Controls.Add(this.resouceSelect);
		this.Controls.Add(this.resouceSetting);
		this.Controls.Add(this.profileSelect);
		this.Controls.Add(this.profileSetting);
		this.Controls.Add(this.encodeExecute);
		this.Controls.Add(this.videoOptions);
		this.Controls.Add(this.audioOptions);
	}
}
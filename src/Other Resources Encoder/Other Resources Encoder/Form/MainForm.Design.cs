﻿using System;
using System.Drawing;
using System.Windows.Forms;
using LibVLCSharp.Shared;
using LibVLCSharp.WinForms;

partial	class MainForm : Form {
	private void InitializeComponent() {
		int margen = 15;
		int curW, curH;

		//Menu Var 
		this.menuStrip               = new MenuStrip();
		this.menuFile                = new ToolStripMenuItem();
		this.menuFileNew             = new ToolStripMenuItem();
		this.menuFileEixt            = new ToolStripMenuItem();
		this.menuHelp                = new ToolStripMenuItem();
		this.menuHelpAbout           = new ToolStripMenuItem();
		//Encode Setting
		this.encodeLabel             = new Label();
		this.outPutFileNameLabel     = new Label();
		this.outPutFileName          = new TextBox();
		this.resourceMachine         = new ComboBox();
		this.resourceMachineSetting  = new Button();
		this.encodeProfile           = new ComboBox();
		this.encodeProfileManegerButton = new Button();
		this.encoderLabel            = new Label();
		this.encoder                 = new ComboBox();
		this.outPutVideoCheckBox     = new CheckBox();
		this.outPutVideoLabel        = new Label();
		this.outPutAudioCheckBox     = new CheckBox();
		this.outPutAudioLabel        = new Label();

		//Video Preview
		this.livVLC = new LibVLC();
		this.mediaPlayer = new MediaPlayer(this.livVLC);
		this.videoView = new VideoView();

		int encodeSettingArea = 300;

		curW = curH = margen;

		//Client
		this.Text = "Other Resource Encoder";
		int mainFormW = (int)Math.Round(Screen.GetWorkingArea(this).Width * 0.9);
		int mainFormH = (int)Math.Round(Screen.GetWorkingArea(this).Height * 0.9);
		this.ClientSize = new Size(mainFormW, mainFormH);
		this.MinimumSize = new Size(encodeSettingArea + margen * 3, 0);
		this.MainMenuStrip = menuStrip;
		this.WindowState = FormWindowState.Maximized;

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
		this.menuFileEixt.Click += new EventHandler(menuFileExitClick);

		this.menuHelp.Text = "Help(H)";
		this.menuHelp.DropDownItems.AddRange(new ToolStripItem[] {
			this.menuHelpAbout,
		});

		this.menuHelpAbout.Text = "About(A)";
		this.menuStrip.Items.AddRange(new ToolStripItem[]{
			this.menuFile,
			this.menuHelp,
		});
		this.menuHelpAbout.Click += new EventHandler(menuHelpAboutClick);

		//Form
		curH += MainMenuStrip.Size.Height;

		this.encodeLabel.Text = "Encode";
		this.encodeLabel.Font = new Font("arial", 17f);
		this.encodeLabel.Size = new Size(300, 25);
		this.encodeLabel.Location = new Point(curW, curH);

		this.videoView.MediaPlayer = mediaPlayer;
		this.videoView.BackColor = Color.Black;
		int videoViewWidth  = this.ClientSize.Width - (encodeSettingArea + margen * 3);
		int videoViewHeigth = (int)Math.Round((double)(videoViewWidth / 16 * 9));
		this.videoView.Size = new Size(videoViewWidth, videoViewHeigth);
		this.videoView.Location = new Point(
			encodeSettingArea + margen * 2,
			curH
		);
		this.videoView.Anchor = (
			AnchorStyles.Top |
			AnchorStyles.Bottom |
			AnchorStyles.Left |
			AnchorStyles.Right
		);

		curH += this.encodeLabel.Size.Height + margen;

		this.outPutFileNameLabel.Text = "OutPut File Name :";
		this.outPutFileNameLabel.Font = new Font("arial", 12f);
		this.outPutFileNameLabel.TextAlign = ContentAlignment.MiddleLeft;
		this.outPutFileNameLabel.Size = new Size (140, 25);
		this.outPutFileNameLabel.Location = new Point(curW, curH);

		this.outPutFileName.Size = new Size(160, 25);
		this.outPutFileName.Font = new Font("arial", 12f);
		this.outPutFileName.Location = new Point(curW + this.outPutFileNameLabel.Size.Width, curH);

		curH += this.outPutFileNameLabel.Size.Height + margen;

		this.resourceMachine.Items.AddRange(new object[] {
			"Resource Machine"
		});
		this.resourceMachine.SelectedIndex = 0;
		this.resourceMachine.DropDownStyle = ComboBoxStyle.DropDownList;
		this.resourceMachine.Font = new Font("arial", 12f);
		this.resourceMachine.Size = new Size(220, 0);
		this.resourceMachine.Location = new Point(curW, curH);

		this.resourceMachineSetting.Text = "Setting";
		this.resourceMachineSetting.Font = new Font("arial", 12f);
		this.resourceMachineSetting.Size = new Size(80, this.resourceMachine.Size.Height);
		this.resourceMachineSetting.Location = new Point(
			encodeSettingArea - this.resourceMachineSetting.Size.Width + margen,
			curH
		);
		this.resourceMachineSetting.Click += new EventHandler(resourceMachineSettingClick);

		curH += this.resourceMachineSetting.Size.Height + margen;

		this.encodeProfile.Items.AddRange(new object[] {
			"Profile"
		});
		this.encodeProfile.SelectedIndex = 0;
		this.encodeProfile.DropDownStyle = ComboBoxStyle.DropDownList;
		this.encodeProfile.Font = new Font("arial", 12f);
		this.encodeProfile.Size = new Size(220, 0);
		this.encodeProfile.Location = new Point(curW, curH);

		this.encodeProfileManegerButton.Text = "Maneger";
		this.encodeProfileManegerButton.Font = new Font("arial", 12f);
		this.encodeProfileManegerButton.Size = new Size(80, this.encodeProfile.Size.Height);
		this.encodeProfileManegerButton.Location = new Point(
			encodeSettingArea - this.encodeProfileManegerButton.Size.Width + margen,
			curH
		);
		this.encodeProfileManegerButton.Click += new EventHandler(encodeProfileManegerButtonClick);

		curH += this.encodeProfileManegerButton.Size.Height + margen;
		
		this.encoderLabel.Text = "Encoder :";
		this.encoderLabel.Font = new Font("arial", 12f);
		this.encoderLabel.Size = new Size(75, 25);
		this.encoderLabel.TextAlign = ContentAlignment.MiddleLeft;
		this.encoderLabel.Location = new Point(curW, curH);

		this.encoder.Items.AddRange(new object[]{
			"x264",
			"x265",
		});
		this.encoder.SelectedIndex = 0;
		this.encoder.DropDownStyle = ComboBoxStyle.DropDownList;
		this.encoder.Font = new Font("arial", 12f);
		this.encoder.Size = new Size(encodeSettingArea - this.encoderLabel.Size.Width, 0);
		this.encoder.Location = new Point(curW + this.encoderLabel.Size.Width, curH);

		curH += this.encoder.Size.Height + margen;

		int outputSettingsWidth = curW;

		this.outPutVideoCheckBox.Checked = true;
		this.outPutVideoCheckBox.Size = new Size(20, 20);
		this.outPutVideoCheckBox.Location = new Point(curW, curH);

		outputSettingsWidth += outPutVideoCheckBox.Size.Width;

		this.outPutVideoLabel.Text = "Output Video";
		this.outPutVideoLabel.Font = new Font("arial", 12f);
		this.outPutVideoLabel.Size = new Size(130, 25);
		this.outPutVideoLabel.Location = new Point(outputSettingsWidth, curH);

		outputSettingsWidth += this.outPutVideoLabel.Size.Width;

		this.outPutAudioCheckBox.Checked = true;
		this.outPutAudioCheckBox.Size = new Size(20, 20);
		this.outPutAudioCheckBox.Location = new Point(outputSettingsWidth, curH);

		outputSettingsWidth += this.outPutAudioCheckBox.Size.Width;

		this.outPutAudioLabel.Text = "Output Audio";
		this.outPutAudioLabel.Font = new Font("arial", 12f);
		this.outPutAudioLabel.Size = new Size(120, 30);
		this.outPutAudioLabel.Location = new Point(outputSettingsWidth, curH);

		this.Controls.Add(this.menuStrip);
		this.Controls.Add(this.encodeLabel);
		this.Controls.Add(this.videoView);
		this.Controls.Add(this.outPutFileNameLabel);
		this.Controls.Add(this.outPutFileName);
		this.Controls.Add(this.resourceMachine);
		this.Controls.Add(this.resourceMachineSetting);
		this.Controls.Add(this.encodeProfile);
		this.Controls.Add(this.encodeProfileManegerButton);
		this.Controls.Add(this.encoderLabel);
		this.Controls.Add(this.encoder);
		this.Controls.Add(this.outPutVideoCheckBox);
		this.Controls.Add(this.outPutVideoLabel);
		this.Controls.Add(this.outPutAudioCheckBox);
		this.Controls.Add(this.outPutAudioLabel);
	}
}
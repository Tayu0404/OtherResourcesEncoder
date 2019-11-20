﻿using System;
using System.Windows.Forms;
using LibVLCSharp.Shared;
using LibVLCSharp.WinForms;
partial class MainForm : Form {
	//Menu bar 
	private MenuStrip menuStrip;
	private ToolStripMenuItem menuFile, menuFileNew, menuFileEixt, menuHelp, menuHelpAbout;

	//Encode Setting
	private Label encodeLabel, outPutFileNameLabel, encoderLabel, outPutVideoLabel, outPutAudioLabel;
	private TextBox outPutFileName;
	private ComboBox resourceMachine, encodeProfile, encoder;
	private Button resourceMachineSetting, encodeProfileManegerButton;
	private CheckBox outPutVideoCheckBox, outPutAudioCheckBox;

	//Video Preview
	private LibVLC livVLC;
	private MediaPlayer mediaPlayer;
	private VideoView videoView;
	
	public MainForm() {
		if (!DesignMode) {
			Core.Initialize();
		}
		InitializeComponent();
		Load += mainFormLoad;
	}

	private void mainFormLoad(object sender, EventArgs e) {
		this.mediaPlayer.Play(new Media(this.livVLC, "http://commondatastorage.googleapis.com/gtv-videos-bucket/sample/BigBuckBunny.mp4", FromType.FromLocation));
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

	private void encodeProfileManegerButtonClick(object sender, EventArgs e){
		EncodeProfileForm encodeProfileForm = new EncodeProfileForm();
		encodeProfileForm.ShowDialog();
	}
}

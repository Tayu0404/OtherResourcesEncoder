﻿using System;
using System.Windows.Forms;
using AxMSVidCtlLib;
partial class MainForm : Form{

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
	
	private void resourceMachineSettingClick(object sender, EventArgs e) {
		SettingForm settingForm = new SettingForm();
		settingForm.ShowDialog();
	}
}

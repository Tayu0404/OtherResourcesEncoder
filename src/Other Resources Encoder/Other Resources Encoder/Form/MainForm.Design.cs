using System;
using System.Drawing;
using System.Windows.Forms;
using AxMSVidCtlLib;

partial	class MainForm : Form {
	private	void InitializeComponent(){
		int margen = 15;
		int curW, curH;


		//Encode Setting
		this.encodeLabel                  = new Label();
		this.outPutFileNameLabel          = new Label();
		this.outPutFileName               = new TextBox();
		this.resourceMachine              = new ComboBox();
		this.resourceMachineSettingButton = new Button();
		this.encodeProfile                = new ComboBox();
		this.encodeProfileSaveButton      = new Button();
		this.encoderLabel                 = new Label();
		this.encoder                      = new ComboBox();
		this.outPutVideoCheckBox          = new CheckBox();
		this.outPutVideoLabel             = new Label();
		this.outPutAudioCheckBox          = new CheckBox();
		this.outPutAudioLabel             = new Label();

		//Video Preview
		this.videoPreview = new AxMSVidCtl();

		curW = curH = margen;

		this.encodeLabel.Text = "Encode";
		this.encodeLabel.Size = new Size(400, 30);
		this.encodeLabel.Location = new Point(curW, curH);

		this.videoPreview.Size = new Size(960, 540);
		this.videoPreview.Location = new Point(curW + this.encodeLabel.Size.Width + margen, curH);

		curH += this.encodeLabel.Size.Height;

		this.outPutFileNameLabel.Text = "OutPut File Name :";
		this.outPutFileNameLabel.Size = new Size(70, 20);
		this.outPutFileNameLabel.Location = new Point(curW, curH);

		this.outPutFileName.Size = new Size(330, 20);
		this.outPutFileName.Location = new Point(curW + this.outPutFileNameLabel.Size.Width, curH);

		curH += this.outPutFileName.Size.Height;

		this.resourceMachine.Items.AddRange(new object[] {
			"Resource Machine"
		});
		this.resourceMachine.SelectedIndex = 0;
		this.resourceMachine.DropDownStyle = ComboBoxStyle.DropDownList;
		this.resourceMachine.Size = new Size(350, 20);
		this.resourceMachine.Location = new Point(curW, curH);

		this.resourceMachineSettingButton.Text = "Setting";
		this.resourceMachineSettingButton.Size = new Size(50, 20);
		this.resourceMachineSettingButton.Location = new Point(curW + this.resourceMachine.Size.Width, curH);

		curH += this.resourceMachineSettingButton.Size.Height;

		this.encodeProfile.Items.AddRange(new object[] {
			"Profile"
		});
		this.encodeProfile.SelectedIndex = 0;
		this.encodeProfile.DropDownStyle = ComboBoxStyle.DropDownList;
		this.encodeProfile.Size = new Size(350, 20);
		this.encodeProfile.Location = new Point(curW, curH);

		this.encodeProfileSaveButton.Text = "Save";
		this.encodeProfileSaveButton.Size = new Size(50, 20);
		this.encodeProfileSaveButton.Location = new Point(curW + this.encodeProfile.Size.Width, curH);

		curH = curH + this.encodeProfileSaveButton.Size.Height;

		this.encoderLabel.Text = "Encoder";
		this.encoderLabel.Size = new Size(50, 20);
		this.encoderLabel.Location = new Point(curW, curH);

		this.encoder.Items.AddRange(new object[]{
			"x264",
			"x265",
		});
		this.encoder.SelectedIndex = 0;
		this.encoder.DropDownStyle = ComboBoxStyle.DropDownList;
		this.encoder.Size = new Size(350, 20);
		this.encoder.Location = new Point(curW + this.encoderLabel.Size.Width, curH);

		curH = curH + this.encoder.Size.Height;

		int outputSettingsWidth = curW;

		this.outPutVideoCheckBox.Checked = true;
		this.outPutVideoCheckBox.Size = new Size(20, 20);
		this.outPutVideoCheckBox.Location = new Point(curW, curH);

		outputSettingsWidth += outPutVideoCheckBox.Size.Width;

		this.outPutVideoLabel.Text = "Output Video";
		this.outPutVideoLabel.Size = new Size(180, 20);
		this.outPutVideoLabel.Location = new Point(outputSettingsWidth, curH);

		outputSettingsWidth += this.outPutVideoLabel.Size.Width;

		this.outPutAudioCheckBox.Checked = true;
		this.outPutAudioCheckBox.Size = new Size(20, 20);
		this.outPutAudioCheckBox.Location = new Point(outputSettingsWidth, curH);

		outputSettingsWidth += this.outPutAudioCheckBox.Size.Width;

		this.outPutAudioLabel.Text = "Output Audio";
		this.outPutAudioLabel.Size = new Size(180, 20);
		this.outPutAudioLabel.Location = new Point(outputSettingsWidth, curH);

		this.Text = "Other Resource Encoder";
		this.ClientSize = new Size(1440, 810);

		this.Controls.Add(this.encodeLabel);
		this.Controls.Add(this.videoPreview);
		this.Controls.Add(this.outPutFileNameLabel);
		this.Controls.Add(this.outPutFileName);
		this.Controls.Add(this.resourceMachine);
		this.Controls.Add(this.resourceMachineSettingButton);
		this.Controls.Add(this.encodeProfile);
		this.Controls.Add(this.encodeProfileSaveButton);
		this.Controls.Add(this.encoderLabel);
		this.Controls.Add(this.encoder);
		this.Controls.Add(this.outPutVideoCheckBox);
		this.Controls.Add(this.outPutVideoLabel);
		this.Controls.Add(this.outPutAudioCheckBox);
		this.Controls.Add(this.outPutAudioLabel);
	}
}

using System;
using System.Drawing;
using System.Windows.Forms;
using AxMSVidCtlLib;

partial	class MainForm : Form {
	private void InitializeComponent() {
		int margen = 15;
		int curW, curH;


		//Encode Setting
		this.encodeLabel             = new Label();
		this.outPutFileNameLabel     = new Label();
		this.outPutFileName          = new TextBox();
		this.resourceMachine         = new ComboBox();
		this.resourceMachineSetting  = new Button();
		this.encodeProfile           = new ComboBox();
		this.encodeProfileSaveButton = new Button();
		this.encoderLabel            = new Label();
		this.encoder                 = new ComboBox();
		this.outPutVideoCheckBox     = new CheckBox();
		this.outPutVideoLabel        = new Label();
		this.outPutAudioCheckBox     = new CheckBox();
		this.outPutAudioLabel        = new Label();

		//Video Preview
		this.videoPreview = new AxMSVidCtl();

		this.ClientSize = new Size(1920, 1080);

		curW = curH = margen;

		this.encodeLabel.Text = "Encode";
		this.encodeLabel.Font = new Font("arial", 17f);
		this.encodeLabel.Size = new Size(400, 25);
		this.encodeLabel.Location = new Point(curW, curH);

		this.videoPreview.Size = new Size(1440, 810);
		this.videoPreview.Location = new Point(
			this.ClientSize.Width - this.videoPreview.Size.Width - margen,
			curH
		);
		int encodeSettingArea = this.ClientSize.Width - this.videoPreview.Size.Width - margen * 3;
		curH += this.encodeLabel.Size.Height + margen;

		this.outPutFileNameLabel.Text = "OutPut File Name :";
		this.outPutFileNameLabel.Font = new Font("arial", 14f);
		this.outPutFileNameLabel.TextAlign = ContentAlignment.MiddleLeft;
		this.outPutFileNameLabel.Size = new Size (170, 25);
		this.outPutFileNameLabel.Location = new Point(curW, curH);

		this.outPutFileName.Size = new Size(encodeSettingArea - this.outPutFileNameLabel.Width, 25);
		this.outPutFileName.Font = new Font("arial", 14f);
		this.outPutFileName.Location = new Point(curW + this.outPutFileNameLabel.Size.Width, curH);

		curH += this.outPutFileNameLabel.Size.Height + margen;

		this.resourceMachine.Items.AddRange(new object[] {
			"Resource Machine"
		});
		this.resourceMachine.SelectedIndex = 0;
		this.resourceMachine.DropDownStyle = ComboBoxStyle.DropDownList;
		this.resourceMachine.Font = new Font("arial", 14f);
		this.resourceMachine.Size = new Size(encodeSettingArea - 100, 0);
		this.resourceMachine.Location = new Point(curW, curH);

		this.resourceMachineSetting.Text = "Setting";
		this.resourceMachineSetting.Font = new Font("arial", 14f);
		this.resourceMachineSetting.Size = new Size(100, this.resourceMachine.Size.Height);
		this.resourceMachineSetting.Location = new Point(
			encodeSettingArea - this.resourceMachineSetting.Size.Width + margen,
			curH
		);

		curH += this.resourceMachineSetting.Size.Height + margen;

		this.encodeProfile.Items.AddRange(new object[] {
			"Profile"
		});
		this.encodeProfile.SelectedIndex = 0;
		this.encodeProfile.DropDownStyle = ComboBoxStyle.DropDownList;
		this.encodeProfile.Font = new Font("arial", 14f);
		this.encodeProfile.Size = new Size(encodeSettingArea - 100, 0);
		this.encodeProfile.Location = new Point(curW, curH);

		this.encodeProfileSaveButton.Text = "Save";
		this.encodeProfileSaveButton.Font = new Font("arial", 14f);
		this.encodeProfileSaveButton.Size = new Size(100, this.encodeProfile.Size.Height);
		this.encodeProfileSaveButton.Location = new Point(
			encodeSettingArea - this.encodeProfileSaveButton.Size.Width + margen,
			curH
		);

		curH += this.encodeProfileSaveButton.Size.Height + margen;
		
		this.encoderLabel.Text = "Encoder";
		this.encoderLabel.Font = new Font("arial", 14f);
		this.encoderLabel.Size = new Size(100, 30);
		this.encoderLabel.TextAlign = ContentAlignment.MiddleLeft;
		this.encoderLabel.Location = new Point(curW, curH);

		this.encoder.Items.AddRange(new object[]{
			"x264",
			"x265",
		});
		this.encoder.SelectedIndex = 0;
		this.encoder.DropDownStyle = ComboBoxStyle.DropDownList;
		this.encoder.Font = new Font("arial", 14f);
		this.encoder.Size = new Size(encodeSettingArea - this.encoderLabel.Size.Width, 0);
		this.encoder.Location = new Point(curW + this.encoderLabel.Size.Width, curH);

		curH += this.encoder.Size.Height + margen;

		int outputSettingsWidth = curW;

		this.outPutVideoCheckBox.Checked = true;
		this.outPutVideoCheckBox.Size = new Size(25, 25);
		this.outPutVideoCheckBox.Location = new Point(curW, curH);

		outputSettingsWidth += outPutVideoCheckBox.Size.Width;

		this.outPutVideoLabel.Text = "Output Video";
		this.outPutVideoLabel.Font = new Font("arial", 14f);
		this.outPutVideoLabel.Size = new Size(180, 30);
		this.outPutVideoLabel.Location = new Point(outputSettingsWidth, curH);

		outputSettingsWidth += this.outPutVideoLabel.Size.Width;

		this.outPutAudioCheckBox.Checked = true;
		this.outPutAudioCheckBox.Size = new Size(25, 25);
		this.outPutAudioCheckBox.Location = new Point(outputSettingsWidth, curH);

		outputSettingsWidth += this.outPutAudioCheckBox.Size.Width;

		this.outPutAudioLabel.Text = "Output Audio";
		this.outPutAudioLabel.Font = new Font("arial", 14f);
		this.outPutAudioLabel.Size = new Size(180, 30);
		this.outPutAudioLabel.Location = new Point(outputSettingsWidth, curH);

		this.Text = "Other Resource Encoder";
		int mainFormW = (int)Math.Round(Screen.GetWorkingArea(this).Width * 0.9);
		int mainFormH = (int)Math.Round(Screen.GetWorkingArea(this).Height * 0.9);
		this.ClientSize = new Size(mainFormW, mainFormH);

		this.Controls.Add(this.encodeLabel);
		this.Controls.Add(this.videoPreview);
		this.Controls.Add(this.outPutFileNameLabel);
		this.Controls.Add(this.outPutFileName);
		this.Controls.Add(this.resourceMachine);
		this.Controls.Add(this.resourceMachineSetting);
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
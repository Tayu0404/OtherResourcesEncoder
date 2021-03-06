﻿using System;
using System.Drawing;
using System.Windows.Forms;

partial class SettingForm : Form {
	private void InitializeComponent() {

		const int margen = 15;
		int curW, curH;
		string fontFamilyName = SystemFonts.DefaultFont.FontFamily.Name;

		//Setting List
		this.settingList          = new ListBox();
		this.okButton             = new Button();
		//Remote Machines
		this.resourceMachineLabel = new Label();
		this.machineProfile       = new ComboBox();
		this.profileLabel         = new Label();
		this.profileName          = new TextBox();
		this.hostLabel            = new Label();
		this.host                 = new TextBox();
		this.portLabel            = new Label();
		this.port                 = new TextBox();
		this.userLabel            = new Label();
		this.user                 = new TextBox();
		this.passLabel            = new Label();
		this.password             = new TextBox();
		this.identityLabel        = new Label();
		this.identityFile         = new TextBox();
		this.identityFileOpen     = new Button();
		this.profileSave          = new Button();
		this.profileRemove        = new Button();
		this.rmError              = new Label();
		//Priority
		this.usagePriorityLabel   = new Label();

		//Client
		this.Name = "Setting";
		this.ClientSize = new Size(750 + margen *3,500);
		this.StartPosition = FormStartPosition.CenterParent;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.ShowInTaskbar = false;
		this.FormBorderStyle = FormBorderStyle.FixedSingle;
		this.AcceptButton = okButton;

		curW = curH = margen;

		//Setting List 
		this.settingList.Items.AddRange(new object[] {
			"Resource Machines",
			"Usage Priority",
		});
		this.settingList.Font = new Font(fontFamilyName, 15f);
		this.settingList.Size = new Size(250, this.ClientSize.Height - margen * 2);
		this.settingList.Location = new Point(curW, curH);
		this.settingList.SelectedIndexChanged += new EventHandler(settingListChange);

		this.okButton.Text = "Accept";
		this.okButton.DialogResult = DialogResult.OK;
		this.okButton.Font = new Font(fontFamilyName, 14f);
		this.okButton.Size = new Size(150, 30);
		this.okButton.Location = new Point(
			this.ClientSize.Width - margen - this.okButton.Size.Width,
			this.ClientSize.Height - margen - this.okButton.Size.Height
		);

		curW = this.settingList.Size.Width + margen * 2;

		//Remote Machines
		this.resourceMachineLabel.Text = "Resource Machines";
		this.resourceMachineLabel.Font = new Font(fontFamilyName, 15f);
		this.resourceMachineLabel.Size = new Size(250, 30);
		this.resourceMachineLabel.Location = new Point(curW, curH);

		curH += this.resourceMachineLabel.Size.Height + margen;

		this.machineProfile.Items.Add("New Profile");
		this.machineProfile.DropDownStyle = ComboBoxStyle.DropDownList;
		this.machineProfile.Font = new Font(fontFamilyName, 14f);
		this.machineProfile.Size = new Size(500, 30);
		this.machineProfile.Location = new Point(curW, curH);
		this.machineProfile.SelectedIndexChanged += new EventHandler(machineProfileChange);
		this.machineProfile.SelectedIndex = 0;

		curH +=this.machineProfile.Size.Height + margen;

		this.profileLabel.Text = "Profile Name";
		this.profileLabel.TextAlign = ContentAlignment.MiddleLeft;
		this.profileLabel.Font = new Font(fontFamilyName, 14f);
		this.profileLabel.Size = new Size(110, 30);
		this.profileLabel.Location = new Point(curW, curH);
		
		this.profileName.Font = new Font(fontFamilyName, 14f);
		this.profileName.Size = new Size(390, 30);
		this.profileName.Location = new Point(curW + this.profileLabel.Size.Width, curH);

		curH += this.profileName.Size.Height + margen;

		this.hostLabel.Text = "Host";
		this.hostLabel.TextAlign = ContentAlignment.MiddleLeft;
		this.hostLabel.Font = new Font(fontFamilyName, 14f);
		this.hostLabel.Size = new Size(110, 30);
		this.hostLabel.Location = new Point(curW, curH);

		this.host.Font = new Font(fontFamilyName, 14f);
		this.host.Size = new Size(390, 30);
		this.host.Location = new Point(curW + hostLabel.Size.Width, curH);

		curH += this.host.Size.Height + margen;

		this.portLabel.Text = "Port";
		this.portLabel.TextAlign = ContentAlignment.MiddleLeft;
		this.portLabel.Font = new Font(fontFamilyName, 14f);
		this.portLabel.Size = new Size(110, 30);
		this.portLabel.Location = new Point(curW, curH);

		this.port.Font = new Font(fontFamilyName, 14f);
		this.port.Size = new Size(390, 30);
		this.port.Location = new Point(curW + this.portLabel.Size.Width, curH);
		this.port.KeyPress += new KeyPressEventHandler(portKeyPress);

		curH += this.port.Size.Height + margen;

		this.userLabel.Text = "User";
		this.userLabel.TextAlign = ContentAlignment.MiddleLeft;
		this.userLabel.Font = new Font(fontFamilyName, 14f);
		this.userLabel.Size = new Size(110, 30);
		this.userLabel.Location = new Point(curW, curH);

		this.user.Font = new Font(fontFamilyName, 14f);
		this.user.Size = new Size(390, 30);
		this.user.Location = new Point(curW + this.userLabel.Size.Width, curH);

		curH += this.user.Size.Height + margen;

		this.passLabel.Text = "Password";
		this.passLabel.TextAlign = ContentAlignment.MiddleLeft;
		this.passLabel.Font = new Font(fontFamilyName, 14f);
		this.passLabel.Size = new Size(110, 30);
		this.passLabel.Location = new Point(curW, curH);

		this.password.Font = new Font(fontFamilyName, 14f);
		this.password.UseSystemPasswordChar = true;
		this.password.Size = new Size(390, 30);
		this.password.Location = new Point(curW + this.passLabel.Size.Width, curH); ;

		curH += this.password.Size.Height + margen;

		this.identityLabel.Text = "Private Key";
		this.identityLabel.Font = new Font(fontFamilyName, 14f);
		this.identityLabel.Size = new Size(110, 30);
		this.identityLabel.Location = new Point(curW, curH);

		this.identityFile.Font = new Font(fontFamilyName, 14f);
		this.identityFile.Size = new Size(340, 30);
		this.identityFile.Location = new Point(curW + this.identityLabel.Size.Width, curH);

		this.identityFileOpen.Text = "...";
		this.identityFileOpen.Font = new Font(fontFamilyName, 14f);
		this.identityFileOpen.Size = new Size(50, 27);
		this.identityFileOpen.Location = new Point(
			this.identityFile.Location.X + this.identityFile.Size.Width,
			curH
		);
		this.identityFileOpen.Click += new EventHandler(identityFileOpenClick);

		curH += this.identityFileOpen.Size.Height + margen;

		
		this.profileSave.Text = "Save";
		this.profileSave.Font = new Font(fontFamilyName, 14f);
		this.profileSave.Size = new Size(100, 30);
		this.profileSave.Location = new Point(
			this.password.Location.X + this.password.Size.Width - this.profileSave.Size.Width,
			curH
		);
		this.profileSave.Click += new EventHandler(profileSaveClick);

		this.profileRemove.Text = "Remove";
		this.profileRemove.Font = new Font(fontFamilyName, 14f);
		this.profileRemove.Size = new Size(100, 30);
		this.profileRemove.Location = new Point(
			this.profileSave.Location.X - this.profileRemove.Size.Width - margen,
			curH
		);
		this.profileRemove.Click += new EventHandler(profileRemoveClick);

		curH += this.profileRemove.Size.Height;

		this.rmError.ForeColor = Color.Red;
		this.rmError.Font = new Font(fontFamilyName, 14f);
		this.rmError.Size = new Size(
			this.ClientSize.Width - this.settingList.Size.Width - margen * 3,
			100
		);
		this.rmError.Location = new Point(curW, curH);

		//Setting List
		this.Controls.Add(this.settingList);
		this.Controls.Add(this.okButton);
		
		//Remote Machines
		this.Controls.Add(this.resourceMachineLabel);
		this.Controls.Add(this.machineProfile);
		this.Controls.Add(this.profileLabel);
		this.Controls.Add(this.profileName);
		this.Controls.Add(this.hostLabel);
		this.Controls.Add(this.host);
		this.Controls.Add(this.portLabel);
		this.Controls.Add(this.port);
		this.Controls.Add(this.userLabel);
		this.Controls.Add(this.user);
		this.Controls.Add(this.passLabel);
		this.Controls.Add(this.password);
		this.Controls.Add(this.identityLabel);
		this.Controls.Add(this.identityFile);
		this.Controls.Add(this.identityFileOpen);
		this.Controls.Add(this.profileSave);
		this.Controls.Add(this.profileRemove);
		this.Controls.Add(this.rmError);
		
		//Priority
		this.Controls.Add(this.usagePriorityLabel);
	}
}
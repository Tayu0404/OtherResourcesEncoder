﻿using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

partial class SettingForm : Form {
	private ListBox settingList;
	private Button okButton;
	//Remote Machine
	private Label resourceMachineLabel, profileLabel, hostLabel, portLabel, userLabel, passLabel, identityLabel, rmError;
	private ComboBox machineProfile;
	private TextBox profileName, host, port, user, password, identityFile;
	private Button profileSave, profileRemove, identityFileOpen;
	//Priority
	private Label usagePriorityLabel;

	public String SelectSetting {
		set { settingList.SelectedItem = value; }
	}

	private void settingListChange(object sender, EventArgs e) {
		ListBox settingList = sender as ListBox;

		switch (settingList.SelectedItem) {
			case ("Resource Machines"):
				//Remote Machines
				this.resourceMachineLabel.Visible = true;
				this.machineProfile.Visible = true;
				this.profileLabel.Visible = true;
				this.profileName.Visible = true;
				this.hostLabel.Visible = true;
				this.host.Visible = true;
				this.portLabel.Visible = true;
				this.port.Visible = true;
				this.userLabel.Visible = true;
				this.user.Visible = true;
				this.passLabel.Visible = true;
				this.password.Visible = true;
				this.identityLabel.Visible = true;
				this.identityFile.Visible = true;
				this.identityFileOpen.Visible = true;
				this.profileSave.Visible = true;
				this.profileRemove.Visible = true;
				this.rmError.Visible = true;
				//Priority
				this.usagePriorityLabel.Visible = false;
				break;

			case ("Usage Priority"):
				//Remote Machines
				this.resourceMachineLabel.Visible = false;
				this.machineProfile.Visible = false;
				this.profileLabel.Visible = false;
				this.profileName.Visible = false;
				this.hostLabel.Visible = false;
				this.host.Visible = false;
				this.portLabel.Visible = false;
				this.port.Visible = false;
				this.userLabel.Visible = false;
				this.user.Visible = false;
				this.passLabel.Visible = false;
				this.password.Visible = false;
				this.identityLabel.Visible = false;
				this.identityFile.Visible = false;
				this.identityFileOpen.Visible = false;
				this.profileSave.Visible = false;
				this.profileRemove.Visible = false;
				this.rmError.Visible = false;
				//Priority
				this.usagePriorityLabel.Visible = true;
				break;
		}
	}

	public SettingForm() {
		InitializeComponent();
		Load += settingFormLoad;
	}

	private void settingFormLoad(object sender, EventArgs e) {
		this.loadSSHConfig();
	}

	private void loadSSHConfig() {
		SSHConfig sshConfig = new SSHConfig();
		var configs = sshConfig.Load();
		foreach (string key in configs.Keys) {
			this.machineProfile.Items.Remove(key);
			this.machineProfile.Items.Add(key);
		}
	}

	private void machineProfileChange(object sender, EventArgs e) {
		ComboBox machineProfile = sender as ComboBox;
		string key = machineProfile.SelectedItem.ToString();
		/*Initialization*/
		this.rmError.Text = string.Empty;
		this.profileLabel.ForeColor = Color.Black;
		this.hostLabel.ForeColor = Color.Black;
		this.portLabel.ForeColor = Color.Black;
		this.userLabel.ForeColor = Color.Black;
		this.passLabel.ForeColor = Color.Black;

		if (key == "New Profile") {
			this.profileName.Text = string.Empty;
			this.host.Text = string.Empty;
			this.port.Text = string.Empty;
			this.user.Text = string.Empty;
			this.port.Text = string.Empty;
			this.password.Text = string.Empty;
			this.identityFile.Text = string.Empty;
			this.profileRemove.Enabled = false;
			return;
		}
		var configs = new SSHConfig().Load();
		this.profileName.Text = configs[key].HostName;
		this.host.Text = configs[key].Host;
		this.port.Text = configs[key].Port;
		this.user.Text = configs[key].User;
		this.password.Text = configs[key].Password;
		this.identityFile.Text = configs[key].Identityfile;
		this.profileRemove.Enabled = true;
	}

	private void profileSaveClick(object sender, EventArgs e) {
		bool errorFlag = false;
		/*Initialization*/
		this.rmError.Text = string.Empty;
		this.profileLabel.ForeColor = Color.Black;
		this.hostLabel.ForeColor = Color.Black;
		this.portLabel.ForeColor = Color.Black;
		this.userLabel.ForeColor = Color.Black;
		this.passLabel.ForeColor = Color.Black;

		if (this.profileName.Text == string.Empty) {
			this.profileLabel.ForeColor = Color.Red;
			errorFlag = true;
		}
		if (this.host.Text == string.Empty) {
			this.hostLabel.ForeColor = Color.Red;
			errorFlag = true;
		}
		if (this.port.Text == string.Empty) {
			this.portLabel.ForeColor = Color.Red;
			errorFlag = true;
		}
		if (this.user.Text == string.Empty) {
			this.userLabel.ForeColor = Color.Red;
			errorFlag = true;
		}
		if (this.password.Text == string.Empty) {
			this.passLabel.ForeColor = Color.Red;
			errorFlag = true;
		}
		if (errorFlag) {
			this.rmError.Text = "Please Enter";
			return;
		}

		SSHConfig sshConfig = new SSHConfig();
		var config = new SSHConfig.Config {
			HostName = this.profileName.Text,
			Host = this.host.Text,
			Port = this.port.Text,
			User = this.user.Text,
			Password = this.password.Text,
			Identityfile = this.identityFile.Text,
		};
		sshConfig.Save(config);
		this.loadSSHConfig();
		this.machineProfile.SelectedItem = config.HostName;
	}

	private void profileRemoveClick(object sender, EventArgs e) {
		SSHConfig sshConfig = new SSHConfig();
		var key = this.profileName.Text;
		sshConfig.Remove(key);
		this.loadSSHConfig();
		this.machineProfile.Items.Remove(key);
		this.machineProfile.SelectedIndex = 0;
	}

	private void portKeyPress(object sender, KeyPressEventArgs e) {
		if ((e.KeyChar < '0' || '9' < e.KeyChar) && e.KeyChar != '\b') {
			e.Handled = true;
		}
	}

	private void identityFileOpenClick(object sender, EventArgs e) {
		OpenFileDialog openFile = new OpenFileDialog() {
			Multiselect = false,
		};

		DialogResult result = openFile.ShowDialog();
		if (result == DialogResult.OK) {
			this.identityFile.Text = openFile.FileName;
		}
	}
}
 
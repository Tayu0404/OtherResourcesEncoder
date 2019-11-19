using System;
using System.Drawing;
using System.Windows.Forms;

partial class SettingForm : Form {
	private ListBox settingList;
	private Button okButton;
	//Remote Machine
	private Label resourceMachineLabel, profileLabel, hostLabel, portLabel, userLabel, passLabel;
	private ComboBox machineProfile;
	private TextBox profileName, host, port, user, password;
	private Button profileSave, profileRemove;
	//SSH Key
	private Label sshKeyLabel;
	private Button privateKeyCopy, privateKeyOpen, publicKeyCopy, publicKeyOpen, keygen;
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
				this.profileSave.Visible = true;
				this.profileRemove.Visible = true;
				//SSH key
				this.sshKeyLabel.Visible = false;
				this.privateKeyCopy.Visible = false;
				this.privateKeyOpen.Visible = false;
				this.publicKeyCopy.Visible = false;
				this.publicKeyOpen.Visible = false;
				this.keygen.Visible = false;
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
				this.profileSave.Visible = false;
				this.profileRemove.Visible = false;
				//SSH key
				this.sshKeyLabel.Visible = false;
				this.privateKeyCopy.Visible = false;
				this.privateKeyOpen.Visible = false;
				this.publicKeyCopy.Visible = false;
				this.publicKeyOpen.Visible = false;
				this.keygen.Visible = false;
				//Priority
				this.usagePriorityLabel.Visible = true;
				break;

			case ("SSH Key"):
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
				this.profileSave.Visible = false;
				this.profileRemove.Visible = false;
				//SSH key
				this.sshKeyLabel.Visible = true;
				this.privateKeyCopy.Visible = true;
				this.privateKeyOpen.Visible = true;
				this.publicKeyCopy.Visible = true;
				this.publicKeyOpen.Visible = true;
				this.keygen.Visible = true;
				//Priority
				this.usagePriorityLabel.Visible = false;
				break;
		}
	}

	private void keygenClick (object sender, EventArgs e) {
		SSHKey sshKey = new SSHKey();
		var keygen = sshKey.SSHKeygen();

		if (!keygen) {
			var overwriteCheck = MessageBox.Show(
				"SSH Key already exists. Do you want to generate it?",
				"Attention",
				MessageBoxButtons.YesNo
			);
			if (overwriteCheck == DialogResult.Yes) {
				sshKey.SSHKeygen(true);
			}
		}
	}

	public SettingForm() {
		InitializeComponent();
	}
}
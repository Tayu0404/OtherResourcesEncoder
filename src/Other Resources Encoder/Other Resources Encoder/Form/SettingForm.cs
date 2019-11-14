using System;
using System.Drawing;
using System.Windows.Forms;

partial class SettingForm : Form {
	ListBox optionSettings;
	//Remote Machine
	Label remoteMachineLabel, profileLabel, hostLabel, portLabel, userLabel, passLabel;
	ComboBox machineProfile;
	TextBox profileName, host, port, user, password;
	Button profileSave;
	//SSH Key
	Label sshKeyLabel;
	Button privateKeyCopy, privateKeyOpen, publicKeyCopy, publicKeyOpen, keygen;
	//Priority
	Label usagePriority;
	
	public SettingForm() {
		InitializeComponent();
	}
}

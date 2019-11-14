using System;
using System.Drawing;
using System.Windows.Forms;

partial class SettingForm : Form {
	private ListBox settingList;
	//Remote Machine
	private Label remoteMachineLabel, profileLabel, hostLabel, portLabel, userLabel, passLabel;
	private ComboBox machineProfile;
	private TextBox profileName, host, port, user, password;
	private Button profileSave, profileRemove;
	//SSH Key
	private Label sshKeyLabel;
	private Button privateKeyCopy, privateKeyOpen, publicKeyCopy, publicKeyOpen, keygen;
	//Priority
	private Label usagePriorityLabel;
	
	public SettingForm() {
		InitializeComponent();
	}
}
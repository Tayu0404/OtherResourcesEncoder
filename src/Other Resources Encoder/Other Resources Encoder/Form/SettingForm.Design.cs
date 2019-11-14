using System;
using System.Drawing;
using System.Windows.Forms;

partial class SettingForm : Form {
	private void InitializeComponent() {
		const int margen = 15;
		
		//Setting List
		this.settingList = new ListBox();
		//Remote Machine
		this.remoteMachineLabel = new Label();
		this.machineProfile = new ComboBox();
		this.profileLabel = new Label();
		this.profileName = new TextBox();
		this.hostLabel = new Label();
		this.host = new TextBox();
		this.portLabel = new Label();
		this.port = new TextBox();
		this.userLabel = new Label();
		this.user = new TextBox();
		this.passLabel = new Label();
		this.password = new TextBox();
		this.profileSave = new Button();
		this.profileRemove = new Button();
		//SSH key
		this.sshKeyLabel = new Label();
		this.privateKeyCopy = new Button();
		this.privateKeyOpen = new Button();
		this.publicKeyCopy = new Button();
		this.publicKeyOpen = new Button();
		this.keygen = new Button();
		//Priority
		this.usagePriorityLabel = new Label();

		//Client
		this.Name = "Setting";
		this.ClientSize = new Size();
		this.StartPosition = FormStartPosition.CenterParent;

		//Setting List 
		this.settingList.Items.AddRange(new object[] {
			"Remote Machines",
			"Usage Priority",
			"SSH Key",
		});
		this.settingList.Font = new Font("arial", 14f);
		this.settingList.Size = new Size(300, this.ClientSize.Height - margen * 2);
		this.settingList.Location = new Point(margen, margen);
	}
}
using System;
using System.Windows.Forms;

partial class EncodeProfileForm : Form {
	private ListBox profileList;
	private Label profileNameLabel;
	private TextBox profileName;
	private Button profileCancel, profileSave, cancelButton, acceptButton;
	
	public EncodeProfileForm() {
		InitializeComponent();
	}
}
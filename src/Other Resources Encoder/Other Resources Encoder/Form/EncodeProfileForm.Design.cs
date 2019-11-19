using System;
using System.Drawing;
using System.Windows.Forms;

partial class EncodeProfileForm : Form {
	private void InitializeComponent() {
		this.profileList      = new ListBox();
		this.profileNameLabel = new Label();
		this.profileName      = new TextBox();
		this.profileSave      = new Button();
		this.profileCancel    = new Button();
		this.acceptButton     = new Button();
		this.cancelButton     = new Button();

		const int margen = 15;
		int curW, curH;

		this.Name = "Profile Maneger";
		this.ClientSize = new Size(750 + margen * 3, 500);
		this.StartPosition = FormStartPosition.CenterParent;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.ShowInTaskbar = false;
		this.FormBorderStyle = FormBorderStyle.FixedSingle;
		this.AcceptButton = this.acceptButton;

		this.acceptButton.Text = "Accept";
		this.acceptButton.DialogResult = DialogResult.OK;
		this.acceptButton.Font = new Font("arial", 12f);
		this.acceptButton.Size = new Size(100, 30);
		this.acceptButton.Location = new Point(
			this.ClientSize.Width - margen - this.acceptButton.Size.Width,
			this.ClientSize.Height - margen - this.acceptButton.Size.Height
		);

		this.cancelButton.Text = "Cancel";
		this.cancelButton.Font = new Font("arial", 12f);
		this.cancelButton.Size = new Size(100, 30);
		this.cancelButton.Location = new Point(
			this.acceptButton.Location.X - this.cancelButton.Size.Width,
			this.acceptButton.Location.Y
		);

		curW = curH = margen;
		this.profileList.Font = new Font("arial", 14f);
		this.profileList.Size = new Size(250, this.ClientSize.Height - margen * 2);
		this.profileList.Location = new Point(curW, curH);

		curW += this.profileList.Size.Width + margen;

		this.profileNameLabel.Text = "Profile Name";
		this.profileNameLabel.Font = new Font("arial", 12f);
		this.profileNameLabel.Size = new Size(130, 30);
		this.profileNameLabel.Location = new Point(curW, curH);

		this.profileName.Font = new Font("arial", 12f);
		this.profileName.Size = new Size(370, 30);
		this.profileName.Location = new Point(curW + this.profileNameLabel.Size.Width, curH);

		curH += this.profileName.Size.Height + margen;

		this.profileSave.Text = "Save";
		this.profileSave.Font = new Font("arial", 12f);
		this.profileSave.Size = new Size(100, 30);
		this.profileSave.Location = new Point(
			this.ClientSize.Width - margen - this.profileSave.Size.Width,
			curH
		);

		this.profileCancel.Text = "Cancel";
		this.profileCancel.Font = new Font("arial", 12f);
		this.profileCancel.Size = new Size(100, 30);
		this.profileCancel.Location = new Point(
			this.profileSave.Location.X - this.profileCancel.Size.Width,
			curH
		);

		this.Controls.Add(this.acceptButton);
		this.Controls.Add(this.cancelButton);
		this.Controls.Add(this.profileList);
		this.Controls.Add(this.profileNameLabel);
		this.Controls.Add(this.profileName);
		this.Controls.Add(this.profileSave);
		this.Controls.Add(this.profileCancel);
	}
}
using System;
using System.Collections.Generic;
using System.Windows.Forms;

partial class AboutForm : Form {
	private ListBox itemList;
	//ORE
	private Label ore, version, copyright, license;
	//Packeage Lisences
	private ListBox licenses;
	private TextBox packageInfo;
	private Dictionary<string, package> packagesData;

	private struct package {
		public string name;
		public string version;
		public string license;
		public string copyright;
		public string source;
	}

	public AboutForm() {
		InitializeComponent();
	}

	private void makePackagesData() {
		this.packagesData = new Dictionary<string, package>();
		package packageData = new package();
		/*SSH.NET*/
		packageData.name      = "SSH.NET";
		packageData.version   = "2017.0.0";
		packageData.license   = "MIT";
		packageData.copyright = "Renchi";
		packageData.source    = "";
		this.packagesData.Add(packageData.name, packageData);
		/*LivVLCSharp*/
		packageData.name      = "LivVLCSharp";
		packageData.version   = "3.3.1";
		packageData.license   = "LGPL-2.1-or-later";
		packageData.copyright = "Copyright (C) 1991, 1999 Free Software Foundation, Inc.";
		packageData.source    = "https://code.videolan.org/videolan/LibVLCSharp";
		this.packagesData.Add(packageData.name, packageData);
		/*LivVLCSharp.WinForms*/
		packageData.name      = "LivVLCSharp.WinForms";
		packageData.version   = "3.3.1";
		packageData.license   = "LGPL-2.1-or-later";
		packageData.copyright = "Copyright (C) 1991, 1999 Free Software Foundation, Inc.";
		packageData.source    = "https://code.videolan.org/videolan/LibVLCSharp";
		this.packagesData.Add(packageData.name, packageData);
		/*VideoLAN.LibVLC.Windows*/
		packageData.name      = "VideoLAN.LibVLC.Windows";
		packageData.version   = "3.0.8.1";
		packageData.license   = "LGPL-2.1-or-later";
		packageData.copyright = "Copyright (C) 1991, 1999 Free Software Foundation, Inc.";
		packageData.source    = "https://code.videolan.org/videolan/libvlc-nuget";
		this.packagesData.Add(packageData.name, packageData);
	}

	private void itemListChange(object sender, EventArgs e) {
		ListBox itemList = sender as ListBox;
		switch (itemList.SelectedItem) {
			case ("About"):
				//ORE
				this.ore.Visible         = true;
				this.version.Visible     = true;
				this.copyright.Visible   = true;
				this.license.Visible     = true;
				//Package Licenses;
				this.licenses.Visible    = false;
				this.packageInfo.Visible = false;
				break;
			case ("Licenses"):
				//ORE
				this.ore.Visible         = false;
				this.version.Visible     = false;
				this.copyright.Visible   = false;
				this.license.Visible     = false;
				//Package Licenses;
				this.licenses.Visible    = true;
				this.packageInfo.Visible = true;
				break;
		}
	}

	private void licensesChange(object sender, EventArgs e) {
		ListBox licenses = sender as ListBox;
		string key = (string)licenses.SelectedItem;
		this.packageInfo.Text = (
			$"{this.packagesData[key].name}\r\n" +
			$"Version : {this.packagesData[key].version}\r\n" +
			$"License : {this.packagesData[key].license}\r\n" +
			$"{this.packagesData[key].copyright}"
		);
		if (this.packagesData[key].source != "") {
			this.packageInfo.Text += $"\r\nSource\r\n{this.packagesData[key].source}";
		}
	}
}
using System;
using System.Data;
using System.Windows.Forms;

partial class AboutForm : Form {
	private ListBox itemList;
	//ORE
	private Label ore, version, copyright, license;
	//Packeage Lisences
	private ListBox licenses;
	private TextBox packageInfo;
	private package[] packagesData;
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
		this.packagesData = new package[4];
		/*SSH.NET*/
		this.packagesData[0].name      = "SSH.NET";
		this.packagesData[0].version   = "2017.0.0";
		this.packagesData[0].license   = "MIT";
		this.packagesData[0].copyright = "Renchi";
		/*LivVLCSharp*/
		this.packagesData[1].name      = "LivVLCSharp";
		this.packagesData[1].version   = "3.3.1";
		this.packagesData[1].license   = "LGPL-2.1-or-later";
		this.packagesData[1].copyright = "Copyright (C) 1991, 1999 Free Software Foundation, Inc.";
		this.packagesData[1].source    = "https://code.videolan.org/videolan/LibVLCSharp";
		/*LivVLCSharp.WinForms*/
		this.packagesData[2].name      = "LivVLCSharp.WinForms";
		this.packagesData[2].version   = "3.3.1";
		this.packagesData[2].license   = "LGPL-2.1-or-later";
		this.packagesData[2].copyright = "Copyright (C) 1991, 1999 Free Software Foundation, Inc.";
		this.packagesData[2].source    = "https://code.videolan.org/videolan/LibVLCSharp";
		/*VideoLAN.LibVLC.Windows*/
		this.packagesData[3].name      = "VideoLAN.LibVLC.Windows";
		this.packagesData[3].version   = "3.0.8.1";
		this.packagesData[3].license   = "LGP+-2.1-or-later";
		this.packagesData[3].copyright = "Copyright (C) 1991, 1999 Free Software Foundation, Inc.";
		this.packagesData[3].source    = "https://code.videolan.org/videolan/libvlc-nuget";
	}
}
 
 
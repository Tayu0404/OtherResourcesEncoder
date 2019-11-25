﻿using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

partial class AboutForm : Form {
	private void InitializeComponent() {
		int curW, curH;
		const int margen = 15;

		//Client
		this.Name = "Setting";
		this.ClientSize = new Size(150 + 300 + margen * 3, 300);
		this.StartPosition = FormStartPosition.CenterParent;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.ShowInTaskbar = false;
		curW = curH = margen;
		 
		this.itemList     = new ListBox();
		//ORE
		this.ore          = new Label();
		this.version      = new Label();
		this.copyright    = new Label();
		this.license      = new Label();
		//Package Licenses;
		this.licenses     = new ListBox();
		this.packageInfo = new TextBox();

		this.itemList.Items.AddRange(new Object[]{
			"About",
			"Licenses",
		});
		this.Font = new Font("arial", 12f);
		this.itemList.Size = new Size(150, this.ClientSize.Height - margen);
		this.itemList.Location = new Point(curW, curH);

		curW += this.itemList.Size.Width + margen;

		this.ore.Text = "Other Resources Encoder";
		this.ore.Font = new Font("arial", 17f);
		this.ore.TextAlign = ContentAlignment.MiddleCenter;
		this.ore.Size = new Size(300, 30);
		this.ore.Location = new Point(curW, curH);

		curH += this.ore.Size.Height;

		this.version.Text = "Unknown Version";
		this.version.Font = new Font("arial", 12f);
		this.version.TextAlign = ContentAlignment.MiddleCenter;
		this.version.Size = new Size(300, 30);
		this.version.Location = new Point(curW, curH);

		curH += this.version.Size.Height;

		this.copyright.Text = "(c) 2019 Tayu";
		this.copyright.Font = new Font("arial", 12f);
		this.copyright.TextAlign = ContentAlignment.MiddleCenter;
		this.copyright.Size = new Size(300, 30);
		this.copyright.Location = new Point(curW, curH);

		curH += this.copyright.Size.Height;

		this.license.Text = "The MIT License";
		this.license.Font = new Font("arial", 12f);
		this.license.TextAlign = ContentAlignment.MiddleCenter;
		this.license.Size = new Size(300, 30);
		this.license.Location = new Point(curW, curH);

		//Package Licenses
		curH = margen;

		makePackagesData();
		foreach (package package in this.packagesData) {
			this.licenses.Items.Add(package.name);
		}
		this.licenses.Size = new Size(
			this.ClientSize.Width - curW - margen,
			100
		);
		this.licenses.Location = new Point(curW, curH);

		curH += this.licenses.Size.Height + margen;

		this.packageInfo.Size = new Size(
			this.licenses.Size.Width,
			this.ClientSize.Height - curH - margen
		);
		this.packageInfo.Location = new Point(curW, curH);

		this.Controls.Add(this.itemList);
		/*
		this.Controls.Add(this.ore);
		this.Controls.Add(this.version);
		this.Controls.Add(this.copyright);
		this.Controls.Add(this.license);
		*/
		this.Controls.Add(this.licenses);
		this.Controls.Add(this.packageInfo);
	}
}
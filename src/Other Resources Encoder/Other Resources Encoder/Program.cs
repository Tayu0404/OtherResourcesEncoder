﻿using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Other_Resources_Encoder {
	static class Program {
		[STAThread]
		static void Main() {
			Path folderPath = new Path();
			folderPath.FolderPathCheck();
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Other_Resources_Encoder {
	static class Program {
		[STAThread]
		static void Main() {
			FolderPath folderPath = new FolderPath();
			folderPath.FolderPathCheck();
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
	}
}

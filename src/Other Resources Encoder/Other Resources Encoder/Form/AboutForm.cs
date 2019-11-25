using System;
using System.Data;
using System.Windows.Forms;

partial class AboutForm : Form {
	private ListBox itemList;
	//ORE
	private Label ore, version, copyright, license;
	//Packeage Lisences
	private DataGrid licenses;
	private DataSet licensesData;
	public AboutForm() {
		InitializeComponent();
	}

	private void makeLicensesData() {
		this.licensesData = new DataSet();

		DataTable tPackages = new DataTable("Packages");

		DataColumn cPackeage = new DataColumn("Packages");
		DataColumn cVersion  = new DataColumn("Version");
		DataColumn cCopyright = new DataColumn("Copyright");

		tPackages.Columns.Add(cPackeage);
		tPackages.Columns.Add(cVersion);
		tPackages.Columns.Add(cCopyright);

		licensesData.Tables.Add(tPackages);
	}
}
using System;
using System.IO;

class Path {

	public void FolderPathCheck (){
		if (!Directory.Exists(this.OREFolderPath)) {
			Directory.CreateDirectory(this.OREFolderPath);
		}
		if (!Directory.Exists(this.SSHKeyFolderPath)) {
			Directory.CreateDirectory(this.SSHKeyFolderPath);
		}
		if (!Directory.Exists(this.EncodeProfileFolderPath)) {
			Directory.CreateDirectory(this.EncodeProfileFolderPath);
		}
		if (!Directory.Exists(this.ConfigFolderPath)) {
			Directory.CreateDirectory(this.ConfigFolderPath);
		}
	}

	public string OREFolderPath {
		get {
			string oreForlderPath;
			oreForlderPath = (
				Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) +
				"\\OtherResourcesEncoder\\"
			);
			return oreForlderPath;
		}
	}

	public string SSHKeyFolderPath {
		get {
			string sshKeyFolderPath; 
			sshKeyFolderPath = (
				this.OREFolderPath +
				"SSHKey\\"
			);
			return sshKeyFolderPath;
		}
	}
	
	public string EncodeProfileFolderPath {
		get {
			string encodeProfileFolderPath;
			encodeProfileFolderPath = (
				this.OREFolderPath +
				"EncodeProfiles\\"
			);
			return encodeProfileFolderPath;
		}
	}

	public string ConfigFolderPath {
		get {
			string configFolderPath;
			configFolderPath = (
				this.OREFolderPath +
				"Config\\"
			);
			return configFolderPath;
		}
	}

	public string SSHConfigFilePath {
		get {
			string sshConfigFilePath;
			sshConfigFilePath = (
				this.ConfigFolderPath +
				"sshConfig.xml"
			);
			return sshConfigFilePath;	
		}
	}
}
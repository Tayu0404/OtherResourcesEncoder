using System;

class FolderPath {
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

	public string ResourceMachinesFolderPath {
		get {
			string resourceMachinesFolderPath;
			resourceMachinesFolderPath = (
				this.OREFolderPath +
				"ResourceMachines\\"
			);
			return resourceMachinesFolderPath;
		}
	}
}
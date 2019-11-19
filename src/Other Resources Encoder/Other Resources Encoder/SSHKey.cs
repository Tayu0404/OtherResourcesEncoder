using System;
using System.IO;

class SSHKey {
	private string privateKeyFilePath {
		get {
			FolderPath folderPath = new FolderPath();
			string sshKeyFolderPath = folderPath.SSHKeyFolderPath;
			var filePath = sshKeyFolderPath + "\\id_rsa";
			return filePath;
		}
	}

	private string publicKeyFilePath {
		get {
			FolderPath folderPath = new FolderPath();
			string sshKeyFolderPath = folderPath.SSHKeyFolderPath;
			var filePath = sshKeyFolderPath + "\\id_rsa.pub";
			return filePath;
		}
	}

	public bool SSHKeyCheck() {
		bool privateKeyExists, publicKeyExists;

		privateKeyExists = File.Exists(this.privateKeyFilePath);
		publicKeyExists = File.Exists(this.publicKeyFilePath);

		if (privateKeyExists | publicKeyExists) {
			return true;
		}
		return false;
	}
	
	public bool SSHKeygen(string userName) {
		if (this.SSHKeyCheck()) {
			return false;
		}
		var machineName = Environment.MachineName;
		var keyGenerator = new SshKeyGenerator.SshKeyGenerator(3072);
		var privateKey = keyGenerator.ToPrivateKey();
		var publicKey = keyGenerator.ToRfcPublicKey(userName + "@" + machineName + "-ORE");
		File.WriteAllText(this.privateKeyFilePath, privateKey);
		File.WriteAllText(this.publicKeyFilePath, publicKey);
		return true;
	}
}
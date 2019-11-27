using System;
using System.IO;

class SSHKey {
	public string PrivateKeyFilePath {
		get {
			Path folderPath = new Path();
			string sshKeyFolderPath = folderPath.SSHKeyFolderPath;
			var filePath = sshKeyFolderPath + "id_rsa";
			return filePath;
		}
	}

	public string PublicKeyFilePath {
		get {
			Path folderPath = new Path();
			string sshKeyFolderPath = folderPath.SSHKeyFolderPath;
			var filePath = sshKeyFolderPath + "id_rsa.pub";
			return filePath;
		}
	}

	public string PrivateKey {
		get {
			return File.ReadAllText(PrivateKeyFilePath);
		}
	}

	public string PublicKey {
		get {
			return File.ReadAllText(PublicKeyFilePath);
		}
	}

	public bool SSHKeyCheck() {
		bool privateKeyExists, publicKeyExists;

		privateKeyExists = File.Exists(this.PrivateKeyFilePath);
		publicKeyExists = File.Exists(this.PublicKeyFilePath);

		if (privateKeyExists | publicKeyExists) {
			return true;
		}
		return false;
	}
	
	public bool SSHKeygen(bool overwrite = false) {
		if (!overwrite) {
			if (this.SSHKeyCheck()) {
				return false;
			}
		}
		var userName = Environment.UserName;
		var machineName = Environment.MachineName;
		var keyGenerator = new SshKeyGenerator.SshKeyGenerator(3072);
		var privateKey = keyGenerator.ToPrivateKey();
		var publicKey = keyGenerator.ToRfcPublicKey(userName + "@" + machineName + "-ORE");
		File.WriteAllText(this.PrivateKeyFilePath, privateKey);
		File.WriteAllText(this.PublicKeyFilePath, publicKey);
		return true;
	}
}
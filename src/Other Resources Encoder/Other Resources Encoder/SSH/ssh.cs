using System;
using Renci.SshNet;

partial class SSH {
	public SshClient Client(string key) {
		ConnectionInfo info;
		var configs  = new SSHConfig().Load();
		var host     = configs[key].Host;
		var port     = configs[key].Port;
		var user     = configs[key].User;
		var password = configs[key].Password;
		var identity = configs[key].Identityfile;

		if (identity != string.Empty) {
			info = new ConnectionInfo(host, int.Parse(port), user,
				new AuthenticationMethod[] {
					new PrivateKeyAuthenticationMethod(user, new PrivateKeyFile[] {
						new PrivateKeyFile(identity)
					}),
				}
			);
		} else {
			info = new ConnectionInfo(host, int.Parse(port), user,
				new AuthenticationMethod[] {
					new PasswordAuthenticationMethod(user, password)
				}
			);
		}
		
		SshClient client = new SshClient(info);
		return client;
	}
}
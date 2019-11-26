using System;
using Renci.SshNet;

partial class SSH {
	private string host;
	private string hostname;
	private string port;
	private string user;
	private string password;
	private string identityfile;
	public SSH() {
		
	}

	public string Host {
		set { value = host; }
		get { return host; }
	}
	public string HostName {
		set { value = hostname; }
		get { return hostname; }
	}
	public string Port {
		set { value = port; }
		get { return port; }
	}
	public string User {
		set { value = user; }
		get { return user; }
	}
	public string Password {
		set { value = password; }
		get { return password; }
	}
	public string Identityfile {
		set { value = identityfile; }
		get { return identityfile; }
	}
}
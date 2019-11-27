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
		set { host = value; }
		get { return host; }
	}
	public string HostName {
		set { hostname = value; }
		get { return hostname; }
	}
	public string Port {
		set { port = value; }
		get { return port; }
	}
	public string User {
		set { user = value; }
		get { return user; }
	}
	public string Password {
		set { password = value; }
		get { return password; }
	}
	public string Identityfile {
		set { identityfile = value; }
		get { return identityfile; }
	}
}
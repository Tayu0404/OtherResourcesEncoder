using System;
using System.Collections.Generic;
using System.Xml.Linq;
using System.Linq;

public class SSHConfig {
	public struct Config {
		public string HostName;
		public string Host;
		public string Port;
		public string User;
		public string Password;
		public string Identityfile;
	}


	public void Save(Config config) {
		var sshConfigs = this.Load();

		if (sshConfigs.ContainsKey(config.HostName)) {
			sshConfigs.Remove(config.HostName);
		}

		sshConfigs.Add(config.HostName, config);

		var elements = sshConfigs.Select(x =>
			new XElement("sshconfig",
				new XElement("hostname", x.Value.HostName),
				new XElement("host", x.Value.Host),
				new XElement("port", x.Value.Port),
				new XElement("user", x.Value.User),
				new XElement("password", x.Value.Password),
				new XElement("identity", x.Value.Identityfile)
			)
		);
		var xml = new XElement("sshconfigs", elements);
		var xdoc = new XDocument(xml);

		xdoc.Save(new Path().SSHConfigFilePath);		
	}

	public Dictionary<string, Config> Load () {
		Dictionary<string, Config> sshConfigs = new Dictionary<string, Config>();
		Config sshConfig;
		XDocument xdoc;
		try {
			xdoc = XDocument.Load(new Path().SSHConfigFilePath);
		}
		catch {
			return sshConfigs;
		}

		var elements = xdoc.Root.Elements();
		foreach (var econfig in elements) {
			sshConfig = new Config {
				HostName     = econfig.Element("hostname").Value,
				Host         = econfig.Element("host").Value,
				Port         = econfig.Element("port").Value,
				User         = econfig.Element("user").Value,
				Password     = econfig.Element("password").Value,
				Identityfile = econfig.Element("identity").Value,
			};
			sshConfigs.Add(sshConfig.HostName, sshConfig);
		}
		
		return sshConfigs;
	}
}
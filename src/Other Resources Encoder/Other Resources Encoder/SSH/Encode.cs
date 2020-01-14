using System;
using System.Diagnostics;

class Encode {
	private ProcessStartInfo sshInfo(string key) {
		var configs = new SSHConfig().Load();
		string sshArguments;
		sshArguments = configs[key].User;
		sshArguments += "@" + configs[key].Host;
		sshArguments += " -p " + configs[key].Port;
		sshArguments += " -i " + configs[key].Identityfile;

		var sshInfo = new ProcessStartInfo();
		sshInfo.FileName = @"C:\Users\yusei\Documents\ORE\ssh.exe";
		sshInfo.Arguments = sshArguments;
		sshInfo.UseShellExecute = false;
		sshInfo.RedirectStandardOutput = true;
		sshInfo.RedirectStandardInput = true;

		return sshInfo;
	}
	public string Ffmpeg(string key, string command) {
		var ffmpeg = Process.Start(sshInfo(key));
		ffmpeg.StandardInput.Write(command);
		ffmpeg.StandardInput.Write("exit\n");

		var output = ffmpeg.StandardOutput.ReadToEnd().ToString();
		ffmpeg.WaitForExit();

		var outputList = output.Split(new[] { "\r\n", "\n", "\r" }, StringSplitOptions.None);
		ffmpeg.Dispose();

		var num = outputList.Length - 2;

		return outputList[num];
	}

	public bool Monitoring(string key, string id) {
		var monitoring = Process.Start(sshInfo(key));
		monitoring.StandardInput.Write("docker container ls -q -f id=" + id + "\n");
		monitoring.StandardInput.Write("exit\n");

		var output = monitoring.StandardOutput.ReadToEnd().ToString();
		var outputList = output.Split(new[] { "\r\n", "\n", "\r" }, StringSplitOptions.None);
		monitoring.Dispose();

		var cid = outputList[outputList.Length - 2];
		if (cid == id.Substring(0, 12)) {
			return true;
		}
		return false;
	}

	public void UploadSCP(string key, string filePath) {
		var configs = new SSHConfig().Load();
		string scpArguments;
		scpArguments = @"-i " + configs[key].Identityfile;
		scpArguments += " -P " + configs[key].Port;
		scpArguments += " " + filePath;
		scpArguments += " " + configs[key].User;
		scpArguments += "@" + configs[key].Host;
		scpArguments += ":.";

		var uploadSCPInfo = new ProcessStartInfo();
		uploadSCPInfo.FileName = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\OpenSSH\scp.exe";
		uploadSCPInfo.Arguments = scpArguments;
		uploadSCPInfo.UseShellExecute = false;
		uploadSCPInfo.RedirectStandardOutput = true;
		uploadSCPInfo.RedirectStandardInput = true;
		var uploadSCP = Process.Start(uploadSCPInfo);
		uploadSCP.WaitForExit();
		Console.WriteLine(uploadSCP.ExitCode.ToString());
	}

	public void DownlaodSCP(string key, string folderPath, string fileName) {
		var configs = new SSHConfig().Load();
		string scpArguments;
		scpArguments = "-i " + configs[key].Identityfile;
		scpArguments += " -P " + configs[key].Port;
		scpArguments += " " + configs[key].User;
		scpArguments += "@" + configs[key].Host;
		scpArguments += ":./ORE/output/" + fileName;
		scpArguments += " " + folderPath;

		var downloadSCPInfo = new ProcessStartInfo();
		downloadSCPInfo.FileName = Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\OpenSSH\scp.exe";
		downloadSCPInfo.Arguments = scpArguments;
		downloadSCPInfo.UseShellExecute = false;
		downloadSCPInfo.RedirectStandardOutput = true;
		downloadSCPInfo.RedirectStandardInput = true;
		var downloadSCP = Process.Start(downloadSCPInfo);
		downloadSCP.WaitForExit();
		Console.WriteLine(downloadSCP.ExitCode.ToString());
	}
}
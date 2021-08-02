using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace AntiCheat
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			Process process = new Process
			{
				StartInfo = new ProcessStartInfo("FortniteClient-Win64-Shipping.exe", "-" + Environment.CommandLine)
				{
					UseShellExecute = false,
					RedirectStandardOutput = false,
					CreateNoWindow = true
				}
			};
			process.Start();
            process.WaitForInputIdle();
			Injector.Inject(process.Id, "Storm.dll");
			bool flag = Environment.CommandLine.Contains("fromfl=be");
			if (flag)
			{
				new Process().StartInfo = new ProcessStartInfo("C:\\Windows\\System32\\cmd.exe", "/c net start BeService")
				{
					UseShellExecute = true,
					RedirectStandardOutput = false,
					CreateNoWindow = false
				};
			}
			else
			{
				new Process().StartInfo = new ProcessStartInfo("C:\\Windows\\System32\\cmd.exe", "/c net start EasyAntiCheat")
				{
					UseShellExecute = true,
					RedirectStandardOutput = false,
					CreateNoWindow = false
				};
			}
			process.WaitForExit();
			var Proc = new ProcessStartInfo();
			Proc.CreateNoWindow = true;
			Proc.FileName = "cmd.exe";
			Proc.Arguments = "/C start com.epicgames.launcher://apps/Fortnite?action=verify";
			Process.Start(Proc);

		}





		private const string BESERVICE = "C:\\Windows\\System32\\cmd.exe\\";


		private const string EACSERVICE = "C:\\Program Files (x86)\\EasyAntiCheat\\EasyAntiCheat.exe";


		private const string COMMANDLINE = "C:\\Windows\\System32\\cmd.exe";
	}
}
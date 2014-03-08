using System;
using inteliBOT.Scripts;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Collections.Generic;


namespace inteliBOT
{
	partial class MainClass
	{
		public static bool ValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
		{
        	return true; 
		}
		public static void Main (string[] args)
		{
			ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(ValidateServerCertificate);
			string mLocation = System.Reflection.Assembly.GetExecutingAssembly().Location;
			string version = System.Diagnostics.FileVersionInfo.GetVersionInfo(mLocation).FileVersion;
			Console.Clear();
			Console.ForegroundColor = ConsoleColor.DarkMagenta;
			Console.WriteLine ("Welcome to inteliBOT {0}", version);
			Console.WriteLine("For DOS and *nix console");
			Console.ResetColor();
			if (args.Length > 0)
			{
				if (login())
				{
					foreach(string arg in args)
						Console.WriteLine(arg);
					Apps(args);
				}
			}
			else
			if (login()) Apps();
		}
		public static void Apps()
		{
			Console.WriteLine();
			Console.Write(">");
			string[] Params = Console.ReadLine().Split(' ');
			string Action = Params[0];
			switch (Action)
			{
			case "":
				break;
				
			case "exit":
				Environment.Exit(0);
				break;
			case "help":
				new help(Params);
				break;
				
			case "replace":
				new replace(Params);
				break;

			case "votecheck":
				new vote(Params);
				break;	

			default:
				Console.WriteLine("Command '{0}' not found", Action);
				break;
			}
			Apps();
		}
		public static void Apps(string[] Params)
		{
			string Action = Params[0];
			switch (Action)
			{
			case "":
				break;
				
			case "exit":
				Environment.Exit(0);
				break;
			case "help":
				new help(Params);
				break;
				
			case "replace":
				new replace(Params);
				break;
				
			case "votecheck":
				new vote(Params);
				break;	
				
			default:
				Console.WriteLine("Command '{0}' not found", Action);
				break;
			}
		}
	}
}

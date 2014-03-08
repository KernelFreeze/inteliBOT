using System;

namespace inteliBOT.Scripts
{
	public class help
	{
		public help(string[] param)
		{
			for(int i = 1; i < param.Length; i++)
			{
				Console.WriteLine("Parameter '{0}' not found", param[i]);	
			}
			Console.WriteLine("List of available commands:{0}1. replace: Replace text in one or more wiki pages.{0}2. help: Display the screen help.{0}3. exit: Log off and close the app.",  Environment.NewLine);
		}
	}
}


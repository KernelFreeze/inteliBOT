using System;
using LinqToWiki.Generated;

namespace inteliBOT
{
	public partial class MainClass
	{
		public static string pass = "PASSWORD";//Change with the bot password
		public static string UserName = "SUPERBOT";//Change with bot user name
		public static string WikiPath = "https://es.wikipedia.org/";
		public static bool login()
		{
			try
			{
				Site.wiki = new LinqToWiki.Generated.Wiki("inteliBOT/1.0 (http://tools.wmflabs.org/intelibot/, miguel2706@outlook.com)",
				                                          new Uri(WikiPath).Host, "/w/api.php");
				var result = Site.wiki.login(UserName, pass);
            		if (result.result == loginresult.NeedToken)
                		result = Site.wiki.login(UserName, pass, token: result.token);

            		if (result.result != loginresult.Success)
                		throw new Exception(result.result.ToString());
					Site.Name = WikiPath;
					return true;
				}
				catch (Exception e)
				{
					Console.WriteLine(e.Message);
					Environment.Exit(0);
					return false;
				}
		}
	}
}


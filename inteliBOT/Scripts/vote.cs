using System;
using System.Text.RegularExpressions;
using LinqToWiki.Generated;
using LinqToWiki;
using System.Collections;
using System.Collections.Generic;
using RestSharp;
using System.Globalization;
using System.Linq;

namespace inteliBOT.Scripts
{
	public class vote
	{
		private static string Start = null;
		private static string Page = null;
		private static string Cat = null;
		
		public vote(string[] param)
		{
			//If you are a helper, put your name here
			Console.WriteLine("'Checker votes' by Miguel Peláez <miguel2706@outlook.com>");
			
			for(int i = 1; i < param.Length; i++)
			{
				string p = param[i];
				//Detect the start at
				if (p.Contains("-start:"))
				{
					Start = param[i];
					Start = Start.Replace("-start:", "");
					break;
				}
				else if (p.Contains("-cat:"))
				{
					Cat = param[i];
					Cat = Cat.Replace("-cat:", "");
					break;
				}
				else if (p.Contains("-page:"))
				{
					Page = param[i];
					Page = Page.Replace("-page:", "");
					break;
				}
			}
			//Checker main in single page
			if (!string.IsNullOrEmpty(Page))
			{
				VoteCheck(Page);
			}
			if (!string.IsNullOrEmpty(Cat))
			{
				string[] P = CategoryMembers(Site.wiki, Cat);
				foreach (string CatPage in P)
				{
					VoteCheck(CatPage);
				}
				Console.ForegroundColor = ConsoleColor.Magenta;
				Console.WriteLine("Check on cat '{0}' ready", Cat);
				Console.ResetColor();
			}
			/*if (!string.IsNullOrEmpty(Start))
			{
				string[] P = AllPages(Start, true);
				while (!String.IsNullOrEmpty(P[0]))
				{
					for (int i = 0; i < P.Length; i++)
					{
						string StPage = P[i];
						inteliBOT.Page page = new inteliBOT.Page(StPage);
						Console.ForegroundColor = ConsoleColor.Magenta;
						Console.WriteLine("Attempt to replace text order in {0}", page.Tittle);
						Console.ResetColor();
						//Console.WriteLine("Page namespace: {0}", page.GetNamespace().ToString());
						if(!REX) page.Text = page.Text.Replace(OldText, NewText);
						else page.Text = Regex.Replace(page.Text, OldText, NewText);				
						Console.WriteLine(page.Save(page.Text, "BOT: Reemplazo automático programado [[Usuario:inteliBOT/Errores|Me equivoqué]]"));
					}
					P = AllPages();
				}
				Console.ForegroundColor = ConsoleColor.Magenta;
				Console.WriteLine("Replace ready");
				Console.ResetColor();
			}*/
		}
		public static void VoteCheck(string art)
		{
			//Defines a inteliBOT.art
			inteliBOT.Page page = new inteliBOT.Page(art);
			Console.ForegroundColor = ConsoleColor.Magenta;
			Console.WriteLine("Attempt to check votes in {0}", art);
			Console.ResetColor();
			string[] Lines = page.Text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
			List<string> LinesD = new List<string>();
			//Use a loop for improve the speed
			for(int i = 0; i < Lines.Length; i++)
			{
				string Line = Lines[i];
				if (Line.StartsWith("#") && Line.ToCharArray()[1] != ':')
				{
					string userName = String.Empty;
					Regex regex = new Regex("[Uu]s(er|uari[ao])([ _][Dd]iscusión|[ _][Tt]alk)?:\\s*(.*?)[#\\|\\/\\]]",RegexOptions.IgnoreCase|RegexOptions.Singleline);
					Match match = regex.Match(Line);
					userName = match.Groups[3].ToString();
					Console.WriteLine("Checking {0}", userName);
					if (EditCounter(userName) < 100 || ((TimeSpan)(DateTime.Now - FirstEdit(userName))).Days < 30)
					{
						Line = "#:<s>" + Line.Replace("#", "") + "</s> {{votonulo|~~~~}}";
					}
					LinesD.Add(Line);
				}
				else 
				{
					LinesD.Add(Line);
					continue;
				}
				
			}
			page.Text = string.Empty;
			foreach (string Line in LinesD)
			{
				if(!String.IsNullOrEmpty(page.Text))
					page.Text = page.Text + Environment.NewLine + Line;
				else page.Text = Line;
			}
			Console.WriteLine("Page '{0}' checked whith result {1}",
			                  page.Tittle, page.Save(page.Text,
			                       "BOT: Marcando a los usuarios que no cumplen los requisitos para votar [[Usuario:inteliBOT/Errores|¿Me equivoqué?]]"));
		}
		private static string[] CategoryMembers(Wiki wiki, string Cat)
		{
			if (!Cat.StartsWith("Category:") || !Cat.StartsWith("Categoría:")) Cat = "Category:" + Cat;
			return (from cm in wiki.Query.categorymembers()
			        where cm.title == Cat
			        && cm.ns == Namespace.Category // or new[] { Namespace.Category }
			        select cm.title).ToList().ToArray();
			
		}
		private static string AllPagesLast;
		private static string[] AllPages (string StartAt = "!", bool Start = false)
		{
			Wiki wiki = Site.wiki;
			if (!Start) StartAt = AllPagesLast;
			string[] result = (from page in wiki.Query.allpages()
			                   where page.@from == StartAt
			                   select page.title)
				.ToList().ToArray();
			AllPagesLast = result[result.Length - 1];
			return result;
		}
		private static int EditCounter(string UserName)
		{
			int Edits = 0;
			int Edits104 = 0;
			int Deleted = 0;
			string URL = String.Format("http://toolserver.org/~river/cgi-bin/count_edits?user={0}&dbname=eswiki_p&machread=1", UserName);
			var client = new RestClient(URL);
			// client.Authenticator = new HttpBasicAuthenticator(username, password);
			
			var request = new RestRequest(Method.GET);
			// easily add HTTP Headers
			request.AddHeader("User-Agent", "inteliBOT/1.0 (http://tools.wmflabs.org/intelibot/, miguel2706@outlook.com)");
			// execute the request
			RestResponse response = (RestResponse)client.Execute(request);
			string[] Lines = response.Content.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
			foreach (string Line in Lines)
			{
				if (Line.StartsWith("EDITS_NS_0 ")) Edits = int.Parse(Line.Replace("EDITS_NS_0 ", ""));
				else if (Line.StartsWith("EDITS_NS_104 ")) Edits104 = int.Parse(Line.Replace("EDITS_NS_104 ", ""));
				else if (Line.StartsWith("DELETED_EDITS ")) Deleted = int.Parse(Line.Replace("DELETED_EDITS ", ""));
			}
			return Edits + Deleted + Edits104; // raw content as string
		}
		private static DateTime FirstEdit(string UserName)
		{
			DateTime First = new DateTime();
			string URL = String.Format("http://toolserver.org/~river/cgi-bin/count_edits?user={0}&dbname=eswiki_p&machread=1", UserName);
			var client = new RestClient(URL);
			// client.Authenticator = new HttpBasicAuthenticator(username, password);
			
			var request = new RestRequest(Method.GET);
			// easily add HTTP Headers
			request.AddHeader("User-Agent", "inteliBOT/1.0 (http://tools.wmflabs.org/intelibot/, miguel2706@outlook.com)");
			// execute the request
			RestResponse response = (RestResponse)client.Execute(request);
			string[] Lines = response.Content.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
			for (int i = 0; i < Lines.Length; i++)
			{
				String Line = Lines[i];
				if (Line.StartsWith("FIRST_EDIT "))
				{
					Line = Line.Replace("FIRST_EDIT ", "");
					Line = Line.Remove(8);
					First = DateTime.ParseExact(Line, "yyyyMMdd", null);
				}
			}
			return First; // raw content as string
		}
	}
}


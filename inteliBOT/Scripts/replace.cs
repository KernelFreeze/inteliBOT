using System;
using System.Text.RegularExpressions;
using LinqToWiki.Generated;
using LinqToWiki;
using System.Collections;
using System.Collections.Generic;
namespace inteliBOT.Scripts
{
	public class replace
	{
		private static string Start = null;
		private static string OldText;
		private static string NewText;
		//private static string NS = "0";
		private static bool REX = false;
		private static string Page = null;
		private static string Cat = null;
		
		public replace(string[] param)
		{
			Console.WriteLine("'Replace' by Miguel Peláez <miguel2706@outlook.com>");
			
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
				/*
				else if (p.Contains("-ns:"))
				{
					NS = param[i];
					NS = NS.Replace("-ns:", "");
					int ns = 0;
					if (!int.TryParse(NS, out ns)){ NS = "0"; ns = 0; Console.WriteLine("Error: '{0}' is unknown namespace. The correct format is a number.", NS);}
					break;
				}*/
				else if (p.Contains("-rex:"))
				{
					string rex = param[i];
					rex = rex.Replace("-rex:", "");
					if (!bool.TryParse(rex, out REX)){ Console.WriteLine("Error: '{0}' is unknown regular expression bool. The correct format is a true|false echo.", rex);}
					break;
				}
				else if (p.Contains("-page:"))
				{
					Page = param[i];
					Page = Page.Replace("-page:", "");
					break;
				}
			}
			Console.ForegroundColor = ConsoleColor.DarkBlue;
			Console.Write("Text to replace (old):");
			Console.ResetColor();
			OldText = Console.ReadLine();
			
			Console.ForegroundColor = ConsoleColor.DarkBlue;
			Console.Write("Text for replace (new):");
			Console.ResetColor();
			NewText = Console.ReadLine();
			//Replace main
			if (!string.IsNullOrEmpty(Page))
			{
				inteliBOT.Page page = new inteliBOT.Page(Page);
				Console.ForegroundColor = ConsoleColor.Magenta;
				Console.WriteLine("Attempt to replace text order in {0}", Page);
				Console.ResetColor();
				//Console.WriteLine("Page namespace: {0}", page.GetNamespace().ToString());
				if(!REX) page.Text = page.Text.Replace(OldText, NewText);
				else page.Text = Regex.Replace(page.Text, OldText, NewText);				
				Console.WriteLine(page.Save(page.Text, "BOT: Reemplazando texto de forma programada [[Usuario:inteliBOT/Errores|Me equivoqué]]"));
			}
			if (!string.IsNullOrEmpty(Cat))
			{
				string[] P = CategoryMembers(Site.wiki, Cat);
				for (int i = 0; i < P.Length; i++)
				{
					string CatPage = P[i];
					inteliBOT.Page page = new inteliBOT.Page(CatPage);
					Console.ForegroundColor = ConsoleColor.Magenta;
					Console.WriteLine("Attempt to replace text order in {0}", page.Tittle);
					Console.ResetColor();
					//Console.WriteLine("Page namespace: {0}", page.GetNamespace().ToString());
					if(!REX) page.Text = page.Text.Replace(OldText, NewText);
					else page.Text = Regex.Replace(page.Text, OldText, NewText);				
					Console.WriteLine(page.Save(page.Text, "BOT: Reemplazo automático programado [[Usuario:inteliBOT/Errores|Me equivoqué]]"));
				}
				Console.ForegroundColor = ConsoleColor.Magenta;
				Console.WriteLine("Replace on cat '{0}' ready", Cat);
				Console.ResetColor();
			}
			if (!string.IsNullOrEmpty(Start))
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
			}
		}
		private static string[] CategoryMembers(Wiki wiki, string Cat)
        {
			if (!Cat.StartsWith("Category:")) Cat = "Category:" + Cat;
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
	}
}


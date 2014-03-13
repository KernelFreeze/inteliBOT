using System.Net;
using System;
using LinqToWiki.Generated;
using System.IO;
using RestSharp;
using System.Xml;

namespace inteliBOT
{
	public class Page
	{
		public string Text;
		public string Tittle;
		public string OldId;

		public Page (string Name)
		{
			Tittle = Name;
			string url = new System.Uri (Site.Name).Host;
			Text = Request (String.Format ("http://{0}/w/index.php?title={1}&action=raw", url, Name));
			XmlDocument doc = new XmlDocument ();
			doc.LoadXml (Request (String.Format (@"http://{0}.wikipedia.org/w/api.php?action=query&titles={1}&prop=info&format=xml", "es", Name)));
			OldId = doc.SelectSingleNode ("/api/query/pages/page/@lastrevid").Value;

		}

		public string Save (string Text, string Comment, bool Minor, bool Bot, bool NewSection, string sectiontitle = null)
		{
			XmlDocument doc = new XmlDocument ();
			doc.LoadXml (Request (String.Format (@"http://{0}.wikipedia.org/w/api.php?action=query&titles={1}&prop=info&format=xml", "es", Tittle)));
			string newID = doc.SelectSingleNode ("/api/query/pages/page/@lastrevid").Value;
			if (this.OldId == newID) {
				var token = Site.wiki.tokens (new[] { tokenstype.edit }).edittoken;
				var result = Site.wiki.edit (
                	title: Tittle, text: Text,
					summary: Comment, token: token);
				return result.result.Value;
			} else {
				return "Conflict edit, oldid: " + OldId + "NewId: " + newID;
			}
		}

		public string Save (string Text, string Comment)
		{
			return Save (Text, Comment, false, true, false);
		}

		public int GetNameSpace ()
		{
			throw new NotImplementedException ();
		}

		private string Request (string URL)
		{
			var client = new RestClient (URL);
			// client.Authenticator = new HttpBasicAuthenticator(username, password);

			var request = new RestRequest (Method.GET);
			// easily add HTTP Headers
			request.AddHeader ("User-Agent", "inteliBOT/1.0 (http://tools.wmflabs.org/intelibot/, miguel2706@outlook.com)");
			// execute the request
			RestResponse response = (RestResponse)client.Execute (request);
			return response.Content; // raw content as string

		}
	}
}


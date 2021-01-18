using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace ThemeProcessor
{
	class MergeItem
	{
		public XDocument Document { get; set; }

		public ThemeBuilder Builder { get; set; }

		public XElement Dictionary { get; set; }

		private Dictionary<string, string> NSList = new Dictionary<string, string>();

		#region internal void Process()
		internal void Process()
		{
			
			// need to add style...
			foreach (var item in Dictionary.Attributes().Where(x=>x.Name.Namespace == XNamespace.Xmlns).ToArray())
			{
				if(Document.Root.Attributes().Any(x=>x.Name.Namespace == XNamespace.Xmlns 
					&& x.Name.LocalName == item.Name.LocalName
					&& x.Value == item.Value
					))
				{
					continue;
				}

				// add...
				item.Remove();
				Document.Root.Add(item);
			}

			foreach (var item in Dictionary.Elements().ToArray())
			{

				// do not add referenced dictionaries !!
				if (item.Name.LocalName == "ResourceDictionary.MergedDictionaries")
					continue;

				item.Remove();

				Document.Root.Add(item);
			}

		}
		#endregion
}
}

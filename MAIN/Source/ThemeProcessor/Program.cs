using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.IO;

namespace ThemeProcessor
{
	class Program
	{
		static void Main(string[] args)
		{
			try
			{

				string folder = args[0];

				string target = args[1];

				if (folder.EndsWith("\\"))
					folder = folder.Substring(0, folder.Length - 1);

				using (StreamWriter sout = new StreamWriter(folder + "\\ThemeProcessor.log"))
				{


					Console.SetOut(sout);
					Console.SetError(sout);

					ThemeBuilder builder = null;

					// first find default.wpf...
					switch (target)
					{
						case "WPF":
							builder = new WPFBuilder { };
							break;
						case "Silverlight":
							builder = new SilverlightBuilder{};
							break;
						default:
							throw new NotImplementedException("Not implemented for " + target);
					}

					builder.RootFolder = folder;

					builder.Run();
				}

				//Console.ReadLine();
				System.Environment.Exit(0);
			}
			catch (Exception ex) {
				Console.WriteLine(ex.ToString());
			}
		}
	}

	public class ThemeBuilder {

		public string RootFolder { get; set; }

		public string OutputPath { get; set; }

		public virtual string PostFix { get { throw new NotImplementedException(); } }

		//private XDocument document = new XDocument();

		public XDocument Document { get; private set; }

		public void Run() {
			try
			{
				OutputPath = RootFolder + "\\Themes\\Generic.xaml";

				string defaultStyle = string.Format("{0}\\Themes\\Default.{1}.xaml", RootFolder, PostFix);
				using (FileStream fs = File.OpenRead(defaultStyle))
				{
					Document = XDocument.Load(fs);
				}

				DirectoryInfo root = new DirectoryInfo(RootFolder);
				AppendFolder(root);

				Document.Save(OutputPath, SaveOptions.OmitDuplicateNamespaces);
			}
			catch (Exception ex) {
				Console.WriteLine(ex.ToString());
			}
		}

		#region private void AppendFolder(DirectoryInfo root)
		private void AppendFolder(DirectoryInfo root)
		{

			// dont do anything in themes folder...
			if (root.Name == "Themes")
				return;

			foreach (var item in root.EnumerateDirectories())
			{
				AppendFolder(item);
			}

			foreach (var item in root.EnumerateFiles("*." + PostFix + ".xaml"))
			{
				// found...
				XDocument doc;
				using(FileStream fs = item.OpenRead()){
					doc = XDocument.Load(fs);
				}

				MergeItem merge = new MergeItem { Document = Document, Builder = this, Dictionary = doc.Root };

				merge.Process();
			}
		}
		#endregion


	}

	public class WPFBuilder : ThemeBuilder {
		#region public override string  PostFix
		public override string PostFix
		{
			get
			{
				return "WPF";
			}
		}
		#endregion

	}

	public class SilverlightBuilder : ThemeBuilder {
		#region public override string  PostFix
		public override string PostFix
		{
			get
			{
				return "Silverlight";
			}
		}
		#endregion

	}
}

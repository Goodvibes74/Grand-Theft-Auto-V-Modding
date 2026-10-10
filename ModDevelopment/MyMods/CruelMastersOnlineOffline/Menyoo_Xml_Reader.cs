using System;
using System.Globalization;
using System.IO;
using System.Xml;

namespace CruelMastersOnlineOffline;

internal class Menyoo_Xml_Reader
{
	private static void Main(string[] args)
	{
		XmlDataDocument xmlDataDocument = new XmlDataDocument();
		int num = 0;
		string text = null;
		string text2 = null;
		string text3 = null;
		string text4 = null;
		string text5 = null;
		string text6 = null;
		string text7 = null;
		FileStream inStream = new FileStream("none.xml", FileMode.Open, FileAccess.Read);
		xmlDataDocument.Load(inStream);
		XmlNodeList elementsByTagName = xmlDataDocument.GetElementsByTagName("Placement");
		for (num = 0; num <= elementsByTagName.Count - 1; num++)
		{
			text = elementsByTagName[num].ChildNodes.Item(4).InnerText.Trim();
			text2 = elementsByTagName[num].ChildNodes.Item(21).ChildNodes.Item(0).InnerText.Trim();
			text3 = elementsByTagName[num].ChildNodes.Item(21).ChildNodes.Item(1).InnerText.Trim();
			text4 = elementsByTagName[num].ChildNodes.Item(21).ChildNodes.Item(2).InnerText.Trim();
			float num2 = (float)Math.Round(decimal.Parse(text4), 4);
			text6 = elementsByTagName[num].ChildNodes.Item(21).ChildNodes.Item(3).InnerText.Trim();
			decimal d = decimal.Parse(text6, NumberStyles.Any);
			float num3 = (float)Math.Round(d, 4);
			text5 = elementsByTagName[num].ChildNodes.Item(21).ChildNodes.Item(4).InnerText.Trim();
			decimal d2 = decimal.Parse(text5, NumberStyles.Any);
			float num4 = (float)Math.Round(d2, 4);
			text7 = elementsByTagName[num].ChildNodes.Item(21).ChildNodes.Item(5).InnerText.Trim();
			decimal d3 = decimal.Parse(text7, NumberStyles.Any);
			float num5 = (float)Math.Round(d3, 4);
			Console.WriteLine("PropSpawnData.Add(new PropSpawnClass(new Model(\"" + text + "\"), new Vector3(" + text2 + "f, " + text3 + "f, " + num2 + "f),  new Vector3(" + num3 + "f, " + num4 + "f, " + num5 + "f)));");
		}
	}
}

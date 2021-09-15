using System.Collections.Generic;
using System.Xml.Serialization;

namespace WebApp.Models.Xml
{
    [XmlRoot(ElementName = "link", Namespace = "http://www.w3.org/2005/Atom")]
	public class Link
	{

		[XmlAttribute(AttributeName = "href", Namespace = "")]
		public string Href { get; set; }

		[XmlAttribute(AttributeName = "rel", Namespace = "")]
		public string Rel { get; set; }

		[XmlAttribute(AttributeName = "type", Namespace = "")]
		public string Type { get; set; }
	}

	[XmlRoot(ElementName = "guid", Namespace = "")]
	public class Guid
	{

		[XmlAttribute(AttributeName = "isPermaLink", Namespace = "")]
		public bool IsPermaLink { get; set; }

		[XmlText]
		public string Text { get; set; }
	}

	[XmlRoot(ElementName = "thumbnail", Namespace = "http://search.yahoo.com/mrss/")]
	public class Thumbnail
	{

		[XmlAttribute(AttributeName = "url", Namespace = "")]
		public string Url { get; set; }

		[XmlAttribute(AttributeName = "width", Namespace = "")]
		public int Width { get; set; }

		[XmlAttribute(AttributeName = "height", Namespace = "")]
		public int Height { get; set; }
	}

	[XmlRoot(ElementName = "item", Namespace = "")]
	public class Item
	{

		[XmlElement(ElementName = "title", Namespace = "")]
		public string Title { get; set; }

		[XmlElement(ElementName = "link", Namespace = "")]
		public string Link { get; set; }

		[XmlElement(ElementName = "guid", Namespace = "")]
		public Guid Guid { get; set; }

		[XmlElement(ElementName = "pubDate", Namespace = "")]
		public string PubDate { get; set; }

		[XmlElement(ElementName = "content", Namespace = "http://search.yahoo.com/mrss/")]
		public object Content { get; set; }

		[XmlElement(ElementName = "description", Namespace = "")]
		public string Description { get; set; }

		[XmlElement(ElementName = "category", Namespace = "")]
		public List<string> Category { get; set; }

		[XmlElement(ElementName = "keywords", Namespace = "http://search.yahoo.com/mrss/")]
		public string Keywords { get; set; }

		[XmlElement(ElementName = "creator", Namespace = "http://purl.org/dc/elements/1.1/")]
		public string Creator { get; set; }

		[XmlElement(ElementName = "modified", Namespace = "http://purl.org/dc/elements/1.1/")]
		public string Modified { get; set; }

		[XmlElement(ElementName = "publisher", Namespace = "http://purl.org/dc/elements/1.1/")]
		public string Publisher { get; set; }

		[XmlElement(ElementName = "subject", Namespace = "http://purl.org/dc/elements/1.1/")]
		public string Subject { get; set; }

		[XmlElement(ElementName = "thumbnail", Namespace = "http://search.yahoo.com/mrss/")]
		public Thumbnail Thumbnail { get; set; }
	}

	[XmlRoot(ElementName = "channel", Namespace = "")]
	public class Channel
	{

		[XmlElement(ElementName = "title", Namespace = "")]
		public string Title { get; set; }

		[XmlElement(ElementName = "description", Namespace = "")]
		public string Description { get; set; }

		[XmlElement(ElementName = "link", Namespace = "")]
		public List<string> Link { get; set; }

		[XmlElement(ElementName = "copyright", Namespace = "")]
		public string Copyright { get; set; }

		[XmlElement(ElementName = "language", Namespace = "")]
		public string Language { get; set; }

		[XmlElement(ElementName = "lastBuildDate", Namespace = "")]
		public string LastBuildDate { get; set; }

		[XmlElement(ElementName = "item", Namespace = "")]
		public List<Item> Items { get; set; }
	}

	[XmlRoot(ElementName = "rss", Namespace = "")]
	public class Rss
	{

		[XmlElement(ElementName = "channel", Namespace = "")]
		public Channel Channel { get; set; }

		[XmlAttribute(AttributeName = "atom", Namespace = "http://www.w3.org/2000/xmlns/")]
		public string Atom { get; set; }

		[XmlAttribute(AttributeName = "dc", Namespace = "http://www.w3.org/2000/xmlns/")]
		public string Dc { get; set; }

		[XmlAttribute(AttributeName = "media", Namespace = "http://www.w3.org/2000/xmlns/")]
		public string Media { get; set; }

		[XmlAttribute(AttributeName = "version", Namespace = "")]
		public double Version { get; set; }

		[XmlText]
		public string Text { get; set; }
	}

}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WebApp.Models.Xml;

namespace WebApp.Classes
{
    public class RssManeger
    {

        public static async Task<IEnumerable<Item>> getItemsAsync()
        {
            string inputUri = "https://www.wired.com/feed/rss";
            try
            {
                WebRequest apiRequest = WebRequest.Create(inputUri);
                HttpWebResponse apiResponse = (HttpWebResponse)apiRequest.GetResponse();
                using (WebClient client = new WebClient())
                {

                    var xmlString = await client.DownloadStringTaskAsync(inputUri);
                    XmlSerializer serializer = new XmlSerializer(typeof(Rss));
                    using (StringReader reader = new StringReader(xmlString))
                    {
                        var test = (Rss)serializer.Deserialize(reader);
                        return test.Channel.Items.TakeLast(5);
                    }

                }
            }
            catch (Exception E)
            {

                Console.Error.WriteLine("Con't Deserialize Xml : {0}", E.Message);
                throw new Exception(string.Format("Con't Deserialize Xml {0}", E.Message), E);
            }
        }

    }
}

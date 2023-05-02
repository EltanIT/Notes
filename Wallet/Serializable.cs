using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Xml.Serialization;

namespace Wallet
{
    class Serializable
    {
        public ListView ListViewArticles { get; set; }

        public Serializable(ListView listViewArticles)
        {
            ListViewArticles = listViewArticles;
        }

        public void SerializableDate()
        {
            Articles articles = new Articles();
            foreach (ListViewItem item in ListViewArticles.Items)
            {
                articles.ArticleList.Add((Article)item.Tag);
            }

            SerializableInXML(articles);
        }

        private void SerializableInXML(Articles articles)
        {
            XmlSerializer xml = new XmlSerializer(typeof(Articles));

            using (StreamWriter fs = new StreamWriter("Articles.xml", false))
            {
                xml.Serialize(fs, articles);
            }
        }

        public Articles DeserializiXML()
        {
            XmlSerializer xml = new XmlSerializer(typeof(Articles));

            using (FileStream fs = new FileStream("Articles.xml", FileMode.OpenOrCreate))
            {
                return (Articles)xml.Deserialize(fs);
            }
        }
    }
}

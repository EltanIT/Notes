using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace Wallet
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Articles articles = DeserializiXML();

            foreach (Article item in articles.ArticleList)
            {
                ListViewItem LVI = new ListViewItem();
                LVI.Tag = item;
                LVI.Content = item.Name;

                ListViewArticles.Items.Add(LVI);
            }
        }

        private Articles DeserializiXML()
        {
            XmlSerializer xml = new XmlSerializer(typeof(Articles));

            using (FileStream fs = new FileStream("Articles.xml", FileMode.OpenOrCreate))
            {
               return (Articles)xml.Deserialize(fs);
            }
        }

        public void update(ListView listViewArticles)
        {
            ListViewArticles = listViewArticles;
        }

        private void Click_AddArticle(object sender, RoutedEventArgs e)
        {
            CreateArticle createArticle = new CreateArticle(ListViewArticles);
            createArticle.Show();
        }

        private void ListViewArticles_SelectionChanged(object sender, EventArgs e)
        {
            if (ListViewArticles.SelectedItems.Count == 1)
            {

            }
        }


    }
}

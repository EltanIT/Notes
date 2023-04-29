using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Serialization;

namespace Wallet
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            try
            {
                UpdateListView();
            }
            catch (Exception)
            {

                MessageBox.Show("Ошибка загрузки данных!");
            }
           
        }

        private void UpdateListView()
        {
            Articles articles = DeserializiXML();
            foreach (Article item in articles.ArticleList)
            {
                ListViewItem LVI = new ListViewItem();
                LVI.Tag = item;
                LVI.Content = item.Name;

                ListViewArticles.Items.Add(LVI);
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

        private void SerializableDate()
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
            
        }

        private void Click_DeleteArticle(object sender, RoutedEventArgs e)
        {
            if (ListViewArticles.SelectedItems.Count == 1)
            {
                ListViewItem listviewitem = (ListViewItem)ListViewArticles.SelectedItems[0];
                ListViewArticles.Items.Remove(listviewitem);

                SerializableDate();

            }
        }
        void lv_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var item = ((FrameworkElement)e.OriginalSource).DataContext as Track;
            if (item != null)
            {
                MessageBox.Show("Item's Double Click handled!");
            }
        }

    }
}

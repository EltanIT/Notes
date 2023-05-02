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
        public void update(ListView listViewArticles)
        {
            ListViewArticles = listViewArticles;
        }

        private void UpdateListView()
        {
            Serializable serializable = new Serializable(ListViewArticles);
            Articles articles = serializable.DeserializiXML();

            foreach (Article item in articles.ArticleList)
            {
                ListViewItem LVI = new ListViewItem();
                LVI.Tag = item;
                LVI.Content = item.Name;

                ListViewArticles.Items.Add(LVI);
            }
        }

        private void Click_AddArticle(object sender, RoutedEventArgs e)
        {
            CreateArticle createArticle = new CreateArticle(ListViewArticles);
            createArticle.Show();
        }

        private void Click_DeleteArticle(object sender, RoutedEventArgs e)
        {
            if (ListViewArticles.SelectedItems.Count == 1)
            {
                ListViewItem listviewitem = (ListViewItem)ListViewArticles.SelectedItems[0];
                ListViewArticles.Items.Remove(listviewitem);

                Serializable serializable = new Serializable(ListViewArticles);
                serializable.SerializableDate();

            }
        }

        void lv_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ListViewItem listviewitem = (ListViewItem)ListViewArticles.SelectedItems[0];
            Article article = (Article)listviewitem.Tag;
            RedactArticle redactArticle = new RedactArticle(article);
            redactArticle.Show();
        }

    }
}

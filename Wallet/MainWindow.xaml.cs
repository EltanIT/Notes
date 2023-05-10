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

        public void Update(ListView listViewArticles, ListView listViewArticlesDate = null)
        {
            ListViewArticles = listViewArticles;
            if (listViewArticlesDate != null)
            {
                ListViewDate = listViewArticlesDate;
            }
            

        }


        private void UpdateListView()
        {
            ListViewArticles.Items.Clear();
            Serializable serializable = new Serializable(ListViewArticles);
            Articles articles = serializable.DeserializiXML();

            foreach (Article item in articles.ArticleList)
            {
                ListViewItem LVI = new ListViewItem();
                ListViewItem LVIDate = new ListViewItem();
                LVI.Tag = item;
                LVIDate.Tag = item;
                LVI.Content = item.Name;
                LVIDate.Content = item.Date_create.ToString();

                ListViewArticles.Items.Add(LVI);
                ListViewDate.Items.Add(LVIDate);
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
                ListViewDate.Items.Remove(listviewitem);
                
                Serializable serializable = new Serializable(ListViewArticles);
                serializable.SerializableDate();

            }
        }

        void lv_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ListViewItem listviewitem = (ListViewItem)ListViewArticles.SelectedItems[0];
            int index = ListViewArticles.SelectedIndex;
            Article article = (Article)listviewitem.Tag;
            RedactArticle redactArticle = new RedactArticle(article, index, ListViewArticles, ListViewDate);
            redactArticle.Show();
        }

        private void lv_MouseDoubleClickDate(object sender, MouseButtonEventArgs e)
        {

        }
    }
}

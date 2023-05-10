using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace Wallet
{
    /// <summary>
    /// Логика взаимодействия для RedactArticle.xaml
    /// </summary>
    public partial class RedactArticle : Window
    {
        Article article;
        int index;
        ListView ListViewArticles;
        ListView ListViewArticlesDate;
        public RedactArticle(Article article, int index, ListView listViewArticle, ListView listViewArticlesDate)
        {
            InitializeComponent();

            this.article = article;
            this.index = index;
            this.ListViewArticles = listViewArticle;
            this.ListViewArticlesDate = listViewArticlesDate;
            l_Name.Content = article.Name;
            tb_Description.Text = article.Description;
        }

        private void Click_saveRedact(object sender, RoutedEventArgs e)
        {
            updateArticle();
            updateDate();

            Serializable serializable = new Serializable(ListViewArticles);
            serializable.SerializableDate();

            MainWindow mainWindow = new MainWindow();
            mainWindow.Update(ListViewArticles, ListViewArticlesDate);
        }

        private void updateArticle()
        {
            Article article = new Article(l_Name.Content.ToString(), tb_Description.Text, DateTime.Now);
            ListViewItem LVI = new ListViewItem();
            LVI.Content = l_Name.Content.ToString();
            LVI.Tag = article;
            ListViewArticles.Items.RemoveAt(index);
            ListViewArticles.Items.Insert(index, LVI);
        }

        private void updateDate()
        {
            Article article = new Article(l_Name.Content.ToString(), tb_Description.Text, DateTime.Now);
            ListViewItem LVI = new ListViewItem();
            LVI.Content = DateTime.Now.ToString();
            LVI.Tag = article;

            ListViewArticlesDate.Items.RemoveAt(index);
            ListViewArticlesDate.Items.Insert(index, LVI);
        }
    }
}

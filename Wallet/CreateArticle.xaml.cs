using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Xml.Serialization;

namespace Wallet
{
    /// <summary>
    /// Логика взаимодействия для CreateArticle.xaml
    /// </summary>
    public partial class CreateArticle : Window
    {

        public ListView ListViewArticles { get; set; }

        public CreateArticle(ListView listViewArticles)
        {
            InitializeComponent();
            ListViewArticles = listViewArticles;
        }

      
        private void Click_CreateArticle(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(NameTextBox.Text))
            {
                Article article = new Article(NameTextBox.Text, "Описание", DateTime.Now);

                ListViewItem LVI = new ListViewItem();
                LVI.Tag = article;
                LVI.Content = article.Name;

                ListViewArticles.Items.Add(LVI);

                SerializableDate();

                MainWindow mainWindow = new MainWindow();
                mainWindow.update(ListViewArticles);
                Close();
            }
            else
            {
                MessageBox.Show("Введите название записи!");
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

            using (FileStream fs = new FileStream("Articles.xml", FileMode.OpenOrCreate))
            {
                xml.Serialize(fs, articles);
            }
        }

        private void Click_CloseWindow(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

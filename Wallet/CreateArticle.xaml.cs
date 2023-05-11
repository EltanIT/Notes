using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml.Serialization;

namespace Wallet
{
    /// <summary>
    /// Логика взаимодействия для CreateArticle.xaml
    /// </summary>
    public partial class CreateArticle : Window
    {

        private ListView ListViewArticles;
        private ListView ListViewDate;

        public CreateArticle(ListView listViewArticles, ListView listViewDate)
        {
            InitializeComponent();
            ListViewArticles = listViewArticles;
            ListViewDate = listViewDate;
            FocusManager.SetFocusedElement(this, NameTextBox);
        }

        private void Click_CreateArticle(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(NameTextBox.Text))
            {
                UpdateArticle();
                UpdateDate();

                Serializable serializable = new Serializable(ListViewArticles);
                serializable.SerializableDate();

                MainWindow mainWindow = new MainWindow();
                mainWindow.Update(ListViewArticles,ListViewDate);
                Close();
            }
            else
            {
                MessageBox.Show("Введите название записи!");
            }
            
        }

        private void UpdateArticle()
        {
            Article article = new Article(NameTextBox.Text, " ", DateTime.Now);
            ListViewItem LVI = new ListViewItem();
            LVI.Tag = article;
            LVI.Content = article.Name;
            ListViewArticles.Items.Insert(0, LVI);
        }

        private void UpdateDate()
        {
            Article article = new Article(NameTextBox.Text, " ", DateTime.Now);
            ListBoxItem LVIDate = new ListBoxItem();
            LVIDate.Tag = article;
            LVIDate.Content = DateTime.Now.ToString();
            ListViewDate.Items.Insert(0, LVIDate);
        }

        private void Click_CloseWindow(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

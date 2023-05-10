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
                Article article = new Article(NameTextBox.Text, " ", DateTime.Now);

                ListViewItem LVI = new ListViewItem();
                ListBoxItem LVIDate = new ListBoxItem();
                LVI.Tag = article;
                LVIDate.Tag = article;
                LVI.Content = article.Name;
                LVIDate.Content = DateTime.Now.ToString();

                ListViewArticles.Items.Insert(0, LVI);
                ListViewDate.Items.Insert(0, LVIDate);

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

        private void Click_CloseWindow(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}

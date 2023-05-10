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

        public ListView ListViewArticles { get; set; }

        public CreateArticle(ListView listViewArticles)
        {
            InitializeComponent();
            ListViewArticles = listViewArticles;
            FocusManager.SetFocusedElement(this, NameTextBox);
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

                Serializable serializable = new Serializable(ListViewArticles);
                serializable.SerializableDate();

                MainWindow mainWindow = new MainWindow();
                mainWindow.Update(ListViewArticles);
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

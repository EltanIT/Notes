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
        public RedactArticle(Article article, int index)
        {
            InitializeComponent();

            this.article = article;
            this.index = index;
            l_Name.Content = article.Name;
            tb_Description.Text = article.Description;
        }

        private void Click_saveRedact(object sender, RoutedEventArgs e)
        {
            Article article = new Article(l_Name.Content.ToString(), tb_Description.Text, DateTime.Now);
            MainWindow mainWindow = new MainWindow();
            mainWindow.updateDescription(article, index);
        }
    }
}

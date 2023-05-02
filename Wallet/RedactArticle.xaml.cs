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
        public RedactArticle(Article article)
        {
            InitializeComponent();

            this.article = article;
            l_Name.Content = article.Name;
            tb_Description.Text = article.Description;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

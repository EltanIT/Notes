using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wallet
{
    [Serializable]
    public class Articles
    {
        public List<Article> ArticleList { get; set; } = new List<Article>();
    }

    [Serializable]
    public class Article
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Date_create { get; set; }


        public Article()
        {

        }

        public Article(string name, string description, DateTime date_create)
        {
            Name = name;
            Description = description;
            Date_create = date_create;
        }
    }
}

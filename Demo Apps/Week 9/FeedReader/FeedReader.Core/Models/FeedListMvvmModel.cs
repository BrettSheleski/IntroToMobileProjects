using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Linq;

namespace FeedReader.Core.Models
{
    public class FeedListMvvmModel : Model
    {
        const string RSS_FEED_URL = "http://rss.cnn.com/rss/cnn_tech.rss";

        public bool IsDownloading
        {
            get => _isDownloading;
            set
            {
                _isDownloading = value;
                OnPropertyChanged();
            }
        }

        private string _title;

        public string Title
        {
            get { return _title; }
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        public async Task InitializeAsync()
        {
            await DownloadRssFeedAsync();
        }

        private bool _isDownloading;

        private async Task DownloadRssFeedAsync()
        {
            IsDownloading = true;

            this.Articles.Clear();

            string rssXml;

            using (var httpClient = new System.Net.Http.HttpClient())
            {
                rssXml = await httpClient.GetStringAsync(RSS_FEED_URL);
            }

            XDocument rssDoc = XDocument.Parse(rssXml);
            XNamespace ns = rssDoc.Root.GetDefaultNamespace();

            ArticleModel article;

            this.Title = rssDoc.Root.Elements(ns + "channel").SelectMany(c => c.Elements(ns + "title")).Select(x => x.Value).FirstOrDefault();

            foreach (var articleElement in rssDoc.Root.Elements(ns + "channel").SelectMany(x => x.Elements(ns + "item")))
            {
                article = new ArticleModel
                {
                    Title = articleElement.Elements(ns + "title").Select(x => x.Value).FirstOrDefault(),
                    Url = articleElement.Elements(ns + "link").Select(x => x.Value).FirstOrDefault(),
                    UniqueId = articleElement.Elements(ns + "guid").Select(x => x.Value).FirstOrDefault(),
                    PublishDate = articleElement.Elements(ns + "pubDate").Select(x => x.Value).Select(str => { DateTime dt; DateTime.TryParse(str, out dt); return dt; }).FirstOrDefault(),
                    Description = articleElement.Elements(ns + "description").Select(x => x.Value).FirstOrDefault(),
                };

                if (!string.IsNullOrWhiteSpace(article.Title))
                {
                    // Evidently CNN likes to add empty ad-like items to the RSS feed

                    Articles.Add(article);
                }
            }

            IsDownloading = false;
        }

        public ObservableCollection<ArticleModel> Articles { get; } = new ObservableCollection<ArticleModel>();

        public class ArticleModel : Model
        {
            private string _title;
            private string _url;

            public string Title
            {
                get => _title;
                set
                {
                    _title = value;
                    OnPropertyChanged();
                }
            }

            public string Url
            {
                get => _url;
                set
                {
                    _url = value;
                    OnPropertyChanged();
                }
            }

            public string UniqueId { get; internal set; }
            public DateTime PublishDate { get; internal set; }
            public string Description { get; internal set; }
        }

    }
}

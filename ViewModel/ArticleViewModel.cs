using luceed.Commands;
using luceed.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Windows.Input;
using System.Text.Json;
using luceed.Helpers;

namespace luceed.ViewModel
{
    public class ArticleViewModel : INotifyPropertyChanged
    {
        private Article _article;
        private ObservableCollection<Article> _articleList;

        public int Id
        {
            get { return _article.Id; }
            set
            {
                if (_article.Id != value)
                {
                    _article.Id = value;
                    OnPropertyChanged(nameof(Id));
                }
            }
        }

        public string Name
        {
            get { return _article.Naziv; }
            set
            {
                if (_article.Naziv != value)
                {
                    _article.Naziv = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        public ObservableCollection<Article> ArticleList
        {
            get { return _articleList; }
            set
            {
                _articleList = value;
                OnPropertyChanged(nameof(ArticleList));
            }
        }
        public ArticleViewModel()
        {
            _article = new Article();
            _articleList = new ObservableCollection<Article>();
        }

        private async Task SearchAsync()
        {
            string apiUrl = $"http://apidemo.luceed.hr/datasnap/rest/artikli/naziv/{this.Name}";

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", APIHelper.setAPI());

                HttpResponseMessage response = await client.GetAsync(apiUrl);

                JsonElement resultArray = await APIHelper.getResponseArray(response);

                if (resultArray.GetRawText() != "{}")
                {
                    var articles = resultArray.GetProperty("artikli").EnumerateArray();

                    ArticleList = new ObservableCollection<Article>(articles.Select(articleData => new Article
                    {
                        Naziv = articleData.GetProperty("naziv").GetString(),
                        Id    = articleData.GetProperty("id").GetInt32()
                    })); ;
                }
            }
        }

        public ICommand SearchCommand => new RelayCommand(async () => await SearchAsync());

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

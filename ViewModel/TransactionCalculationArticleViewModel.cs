using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Windows.Input;
using luceed.Commands;
using luceed.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using luceed.Helpers;

namespace luceed.ViewModel
{
    public class TransactionCalculationArticleViewModel : INotifyPropertyChanged
    {
        private string _selectedBusinessUnit;
        public string SelectedBusinessUnit
        {
            get { return _selectedBusinessUnit; }
            set
            {
                if (_selectedBusinessUnit != value)
                {
                    _selectedBusinessUnit = value;
                    OnPropertyChanged(nameof(SelectedBusinessUnit));
                }
            }
        }

        private DateTime _startDate;
        public DateTime StartDate
        {
            get { return _startDate; }
            set
            {
                if (_startDate != value)
                {
                    _startDate = value;
                    OnPropertyChanged(nameof(StartDate));
                }
            }
        }

        private DateTime _endDate;
        public DateTime EndDate
        {
            get { return _endDate; }
            set
            {
                if (_endDate != value)
                {
                    _endDate = value;
                    OnPropertyChanged(nameof(EndDate));
                }
            }
        }

        private ObservableCollection<TransactionCalculationArticle> _transactionCalculationArticles;

        public ObservableCollection<TransactionCalculationArticle> TransactionCalculationArticles
        {
            get { return _transactionCalculationArticles; }
            set
            {
                _transactionCalculationArticles = value;
                OnPropertyChanged(nameof(TransactionCalculationArticles));
            }
        }

        public TransactionCalculationArticleViewModel()
        {
            _transactionCalculationArticles = new ObservableCollection<TransactionCalculationArticle>();
            _startDate = new DateTime(2013, 1, 1);
            _endDate = new DateTime(2030, 1, 1);
            _selectedBusinessUnit = "4986-1";
        }

        private async Task SearchAsync()
        {
            string apiUrl = $"http://apidemo.luceed.hr/datasnap/rest/mpobracun/artikli/{this.SelectedBusinessUnit}/{this.StartDate.Date.ToShortDateString()}/{this.EndDate.Date.ToShortDateString()}";

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", APIHelper.setAPI());

                HttpResponseMessage response = await client.GetAsync(apiUrl);

                JsonElement resultArray = await APIHelper.getResponseArray(response);

                if (resultArray.GetRawText() != "{}")
                {
                    var transactionCalculationArray = resultArray.GetProperty("obracun_artikli").EnumerateArray();

                    TransactionCalculationArticles = new ObservableCollection<TransactionCalculationArticle>(transactionCalculationArray.Select(transactionData => new TransactionCalculationArticle
                    {
                        ArtiklUid    = transactionData.GetProperty("artikl_uid").GetString(),
                        NazivArtikla = transactionData.GetProperty("naziv_artikla").GetString(),
                        Iznos        = transactionData.GetProperty("iznos").GetDecimal(),
                        Usluga       = transactionData.GetProperty("usluga").GetString(),
                        Kolicina     = transactionData.GetProperty("kolicina").GetDecimal()
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

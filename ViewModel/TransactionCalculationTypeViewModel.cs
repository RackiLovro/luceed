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
    public class TransactionCalculationTypeViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<TransactionCalculationType> _transactionCalculationTypes;

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

        public ObservableCollection<TransactionCalculationType> TransactionCalculationTypes
        {
            get { return _transactionCalculationTypes; }
            set
            {
                _transactionCalculationTypes = value;
                OnPropertyChanged(nameof(TransactionCalculationTypes));
            }
        }

        public TransactionCalculationTypeViewModel()
        {
            _transactionCalculationTypes = new ObservableCollection<TransactionCalculationType>();
            _startDate = new DateTime(2013, 1, 1);
            _endDate = new DateTime(2030, 1, 1);
            _selectedBusinessUnit = "4986-1";
        }

        private async Task SearchAsync()
        {
            string apiUrl = $"http://apidemo.luceed.hr/datasnap/rest/mpobracun/placanja/{this.SelectedBusinessUnit}/{this.StartDate.Date.ToShortDateString()}/{this.EndDate.Date.ToShortDateString()}";

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", APIHelper.setAPI());

                HttpResponseMessage response = await client.GetAsync(apiUrl);

                JsonElement resultArray = await APIHelper.getResponseArray(response);

                if (resultArray.GetRawText() != "{}")
                {
                    var transactionCalculationArray = resultArray.GetProperty("obracun_placanja").EnumerateArray();

                    TransactionCalculationTypes = new ObservableCollection<TransactionCalculationType>(transactionCalculationArray.Select(transactionData => new TransactionCalculationType
                    {
                        VrstePlacanjaUid        = transactionData.GetProperty("vrste_placanja_uid").GetString(),
                        Naziv                   = transactionData.GetProperty("naziv").GetString(),
                        Iznos                   = transactionData.GetProperty("iznos").GetDouble(),
                        Nadgrupa_placanja_naziv = transactionData.GetProperty("nadgrupa_placanja_naziv").GetString(),
                        Nadgrupa_placanja_uid   = transactionData.GetProperty("nadgrupa_placanja_uid").GetString()
                    }));
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

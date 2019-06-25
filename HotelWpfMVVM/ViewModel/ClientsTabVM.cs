using HotelWpfMVVM.CMDs;
using HotelWpfMVVM.HotelDBContext;
using HotelWpfMVVM.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace HotelWpfMVVM.ViewModel
{
    public class ClientsTabVM : INotifyPropertyChanged
    {
        public HotelContext Context { get; set; }

        private ObservableCollection<Client> _filteredClientList =
            new ObservableCollection<Client>();
        public ObservableCollection<Client> FilteredClientList
        {
            get => _filteredClientList;
            set => _filteredClientList = value;
        }

        public ClientsTabVM(HotelContext context)
        {
            Context = context;
            Context.Clients.Load();
        }

        private Client _clientFilter = new Client();
        public Client ClientFilter
        {
            get => _clientFilter;
            set
            {
                _clientFilter = value;
                OnPropertyChanged("ClientFilter");
            }
        }

        private Client _clientInfo;
        public Client ClientInfo
        {
            get => _clientInfo;
            set
            {
                _clientInfo = value;
                OnPropertyChanged("ClientInfo");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private Client _selectedClient;
        public Client SelectedClient
        {
            get => _selectedClient;
            set
            {
                _selectedClient = value;
                if (_selectedClient == null)
                    return;
                ClientInfo = new Client()
                {
                    PersonId = _selectedClient.PersonId,
                    FirstName = _selectedClient.FirstName,
                    LastName = _selectedClient.LastName,
                    Birthdate = _selectedClient.Birthdate,
                    Account = _selectedClient.Account,
                    Room = _selectedClient.Room
                };
                OnPropertyChanged();
            }
        }

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private ICommand _addClientCommand = null;
        public ICommand AddClientCmd => _addClientCommand ?? (_addClientCommand = new AddClientCommand(Context));

        private ICommand _updateClientCommand = null;
        public ICommand UpdateClientCmd => _updateClientCommand ?? (_updateClientCommand = new UpdateClientCommand(Context));

        private ICommand _deleteClientCommand = null;
        public ICommand DeleteClientCmd => _deleteClientCommand ?? (_deleteClientCommand = new DeleteClientCommand(Context));

        private ICommand _searchClientsCommand = null;
        public ICommand SearchClientsCmd => _searchClientsCommand ?? (_searchClientsCommand = new SearchClientsCommand(Context, FilteredClientList));

        private ICommand _exportClientsCommand = null;
        public ICommand ExportClientsCmd => _exportClientsCommand ?? (_exportClientsCommand = new ExportClientsCommand(Context));

        private ICommand _resetFilterClientCommand = null;
        public ICommand ResetFilterClientCmd => _resetFilterClientCommand ?? (_resetFilterClientCommand = new ResetFilterClientCommand());
    }
}

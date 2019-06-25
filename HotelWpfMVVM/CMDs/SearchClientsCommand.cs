using HotelWpfMVVM.HotelDBContext;
using HotelWpfMVVM.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace HotelWpfMVVM.CMDs
{
    class SearchClientsCommand : CommandBase
    {
        public HotelContext Context { get; set; }

        public ObservableCollection<Client> Clients { get; set; }

        public SearchClientsCommand(HotelContext context, ObservableCollection<Client> clients)
        {
            Context = context;
            Clients = clients;
        }

        public override bool CanExecute(object parameter) => (parameter as Client) != null &&
                (!string.IsNullOrEmpty((parameter as Client).FirstName) ||
                !string.IsNullOrEmpty((parameter as Client).LastName) ||
                !string.IsNullOrEmpty((parameter as Client).Account) ||
                (parameter as Client).Birthdate != null ||
                (parameter as Client).Room != null);

        public override void Execute(object parameter)
        {
            if (Clients.Count > 0)
                Clients.Clear();
            IEnumerable<Client> queryResult = Context.Clients.Local;
            if (!string.IsNullOrEmpty(((Client)parameter).FirstName))
            {
                queryResult = queryResult.Where(client => client.FirstName.Contains(((Client)parameter).FirstName));
            }
            if (!string.IsNullOrEmpty(((Client)parameter).LastName))
            {
                queryResult = queryResult.Where(client => client.LastName.Contains(((Client)parameter).LastName));
            }
            if (((Client)parameter).Birthdate != null)
            {
                queryResult = queryResult.Where(client => client.Birthdate == ((Client)parameter).Birthdate);
            }
            if (!string.IsNullOrEmpty(((Client)parameter).Account))
            {
                queryResult = queryResult.Where(client => client.Account.Contains(((Client)parameter).Account));
            }
            if (((Client)parameter).Room != null)
            {
                queryResult = queryResult.Where(client => client.Room == ((Client)parameter).Room);
            }

            var clients = queryResult.ToList();

            foreach (var item in clients)
            {
                if(!Clients.Contains(item))
                    Clients.Add(item);
            }
        }
    }
}

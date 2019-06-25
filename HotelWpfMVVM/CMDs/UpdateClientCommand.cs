using HotelWpfMVVM.HotelDBContext;
using HotelWpfMVVM.Model;
using System.Linq;
using System.Windows;

namespace HotelWpfMVVM.CMDs
{
    class UpdateClientCommand : CommandBase
    {
        public HotelContext Context { get; set; }

        public UpdateClientCommand(HotelContext context) => Context = context;

        public override bool CanExecute(object parameter) => (parameter as Client) != null &&
                !string.IsNullOrEmpty((parameter as Client).FirstName) &&
                !string.IsNullOrEmpty((parameter as Client).LastName) &&
                (parameter as Client).Room != null;

        public override void Execute(object parameter)
        {
            Client client = Context.Clients.Local.SingleOrDefault(c => c.PersonId == ((Client)parameter).PersonId);
            if (client != null)
            {
                client.FirstName = ((Client)parameter).FirstName;
                client.LastName = ((Client)parameter).LastName;
                client.Birthdate = ((Client)parameter).Birthdate;
                client.Account = ((Client)parameter).Account;
                client.Room = ((Client)parameter).Room;
                Context.SaveChanges();
            }
            else
                MessageBox.Show("Упс...");
        }
    }
}

using HotelWpfMVVM.HotelDBContext;
using HotelWpfMVVM.Model;
using System.Linq;
using System.Windows;

namespace HotelWpfMVVM.CMDs
{
    class DeleteClientCommand : CommandBase
    {
        public HotelContext Context { get; set; }

        public DeleteClientCommand(HotelContext context) => Context = context;

        public override bool CanExecute(object parameter) => (parameter as Client) != null;

        public override void Execute(object parameter)
        {
            Client client = Context.Clients.Local.SingleOrDefault(c => c.PersonId == ((Client)parameter).PersonId);
            if (client != null)
            {
                Context.Clients.Remove(client);
                Context.SaveChanges();
            }
            else
                MessageBox.Show("Упс...");
        }
    }
}

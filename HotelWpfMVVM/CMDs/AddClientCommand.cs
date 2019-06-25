using HotelWpfMVVM.HotelDBContext;
using HotelWpfMVVM.Model;

namespace HotelWpfMVVM.CMDs
{
    class AddClientCommand : CommandBase
    {
        public HotelContext Context { get; set; }

        public AddClientCommand(HotelContext context) => Context = context;

        public override bool CanExecute(object parameter) => (parameter as Client) != null &&
            !string.IsNullOrEmpty((parameter as Client).FirstName) &&
            !string.IsNullOrEmpty((parameter as Client).LastName) &&
            (parameter as Client).Room != null;

        public override void Execute(object parameter)
        {
            Context.Clients.Add(new Client
            {
                FirstName = ((Client)parameter).FirstName,
                LastName = ((Client)parameter).LastName,
                Birthdate = ((Client)parameter).Birthdate,
                Account = ((Client)parameter).Account,
                Room = ((Client)parameter).Room
            });
            Context.SaveChanges();
        }
    }
}

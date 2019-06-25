using HotelWpfMVVM.Model;

namespace HotelWpfMVVM.CMDs
{
    public class ResetFilterClientCommand : CommandBase
    {
        public override bool CanExecute(object parameter) => (parameter as Client) != null &&
                (!string.IsNullOrEmpty((parameter as Client).FirstName) ||
                !string.IsNullOrEmpty((parameter as Client).LastName) ||
                !string.IsNullOrEmpty((parameter as Client).Account) ||
                (parameter as Client).Birthdate != null ||
                (parameter as Client).Room != null);

        public override void Execute(object parameter)
        {
            Client client = parameter as Client;
            client.FirstName = string.Empty;
            client.LastName = string.Empty;
            client.Account = string.Empty;
            client.Birthdate = null;
            client.Room = null;
        }
    }
}

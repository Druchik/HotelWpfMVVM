using HotelWpfMVVM.HotelDBContext;
using HotelWpfMVVM.Model;
using Microsoft.Win32;
using System.IO;
using System.Linq;

namespace HotelWpfMVVM.CMDs
{
    public class ExportClientsCommand : CommandBase
    {
        public HotelContext Context { get; set; }

        public ExportClientsCommand(HotelContext context) => Context = context;

        public override bool CanExecute(object parameter) => Context.Clients.Count() != 0;

        public override void Execute(object parameter)
        {
            var clientsExport = Context.Clients.ToList().Select(client => new Client
            {
                PersonId = client.PersonId,
                FirstName = client.FirstName,
                LastName = client.LastName,
                Birthdate = client.Birthdate.Value,
                Account = client.Account
                //RoomNumber = client.Room.RoomNumber
            });
            var saveDialog = new SaveFileDialog
            {
                DefaultExt = ".xls",
                Filter = "Excel table (.xls)|*.xls"
            };
            var result = saveDialog.ShowDialog();
            if (result == true)
            {
                using (TextWriter sw = new StreamWriter(saveDialog.FileName))
                {
                    var reportCreator = new ReportCreator();
                    reportCreator.WriteTsv(clientsExport, sw);
                }
            }
        }
    }
}

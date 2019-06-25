using HotelWpfMVVM.HotelDBContext;
using HotelWpfMVVM.Model;
using HotelWpfMVVM.ViewModel;
using System;
using System.Data.Entity;
using System.Windows;

namespace HotelWpfMVVM
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private HotelContext Context { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            RoomTypeCb.ItemsSource = RtCbFilter.ItemsSource = Enum.GetNames(typeof(RoomTypes));
            RfCbFilter.ItemsSource = Enum.GetNames(typeof(RoomsFree));
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<HotelContext>());
            //Database.SetInitializer(new DropCreateDatabaseAlways<HotelContext>()); // set to recreate database
            Context = new HotelContext();
            //Fill(); // uncomment to fill database with default values
            ClientsTab.DataContext = new ClientsTabVM(Context);
            RoomsTab.DataContext = new RoomsTabVM(Context);
        }

        private void Fill()
        {
            var rooms = new[]
            {
                new Room {RoomNumber = "1", RoomType = RoomTypes.StandartRoom, NumPlaces = 1},
                new Room {RoomNumber = "2", RoomType = RoomTypes.JuniorSuite, NumPlaces = 3},
                new Room {RoomNumber = "3", RoomType = RoomTypes.StandartRoom, NumPlaces = 1},
                new Room {RoomNumber = "4", RoomType = RoomTypes.PresidentialSuite, NumPlaces = 2},
                new Room {RoomNumber = "5", RoomType = RoomTypes.JuniorSuite, NumPlaces = 3},
                new Room {RoomNumber = "6", RoomType = RoomTypes.StandartRoom, NumPlaces = 1},
                new Room {RoomNumber = "7", RoomType = RoomTypes.PresidentialSuite, NumPlaces = 2}
            };

            var clients = new[]
            {
                new Client {FirstName = "Sergey", LastName = "Konstantinov", Birthdate = new DateTime(1995, 9, 2), Account = "Serg", Room = rooms[1]},
                new Client {FirstName = "Bob", LastName = "Marley", Birthdate = new DateTime(1952, 3, 25), Account = "919191", Room = rooms[3]},
                new Client {FirstName = "Kirill", LastName = "Orlov", Birthdate = new DateTime(1957, 7, 3), Account = "Orlusha", Room = rooms[3]},
                new Client {FirstName = "Phillip", LastName = "Colt", Birthdate = new DateTime(1966, 12, 6), Account = "Pistol", Room = rooms[5]},
                new Client {FirstName = "Grunt", LastName = "Gustin", Birthdate = new DateTime(1989, 10, 30), Account = "Grand", Room = rooms[4]},
                new Client {FirstName = "Elvis", LastName = "Presley", Birthdate = new DateTime(1960, 2, 17), Account = "The_king", Room = rooms[6]}
            };

            Context.Rooms.AddRange(rooms);
            Context.Clients.AddRange(clients);
            Context.SaveChanges();
        }
    }
}

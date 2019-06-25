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
    public class RoomsTabVM : INotifyPropertyChanged
    {
        public HotelContext Context { get; set;}
        
        public event PropertyChangedEventHandler PropertyChanged;

        public RoomsTabVM(HotelContext context)
        {
            Context = context;
            Context.Rooms.Load();
        }

        private ObservableCollection<Room> _filteredRoomList = 
            new ObservableCollection<Room>();
        public ObservableCollection<Room> FilteredRoomList
        {
            get => _filteredRoomList;
            set => _filteredRoomList = value;
        }

        private Room _selectedRoom;
        public Room SelectedRoom
        {
            get => _selectedRoom;
            set
            {
                _selectedRoom = value;
                if (_selectedRoom == null)
                    return;
                RoomInfo = new Room()
                {
                    RoomId = _selectedRoom.RoomId,
                    RoomNumber = _selectedRoom.RoomNumber,
                    RoomType = _selectedRoom.RoomType,
                    Clients = _selectedRoom.Clients,
                    NumPlaces = _selectedRoom.NumPlaces
                };
                OnPropertyChanged();
            }
        }

        private Room _roomInfo = new Room();
        public Room RoomInfo
        {
            get => _roomInfo;
            set
            {
                _roomInfo = value;
                OnPropertyChanged("RoomInfo");
            }
        }

        private Room _roomFilter = new Room();
        public Room RoomFilter
        {
            get => _roomFilter;
            set
            {
                _roomFilter = value;
                OnPropertyChanged("RoomFilter");
            }
        }

        private ICommand _addRoomCommand = null;
        public ICommand AddRoomCmd => _addRoomCommand ?? (_addRoomCommand = new AddRoomCommand(Context));

        private ICommand _updateRoomCommand = null;
        public ICommand UpdateRoomCmd => _updateRoomCommand ?? (_updateRoomCommand = new UpdateRoomCommand(Context));

        private ICommand _deleteRoomCommand = null;
        public ICommand DeleteRoomCmd => _deleteRoomCommand ?? (_deleteRoomCommand = new DeleteRoomCommand(Context));

        private ICommand _searchRoomsCommand = null;
        public ICommand SearchRoomsCmd => _searchRoomsCommand ?? (_searchRoomsCommand = new SearchRoomsCommand(Context, FilteredRoomList));

        private ICommand _resetFilterRoomCommand = null;
        public ICommand ResetFilterRoomCmd => _resetFilterRoomCommand ?? (_resetFilterRoomCommand = new ResetFilterRoomCommand());

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

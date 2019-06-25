using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace HotelWpfMVVM.Model
{
    public enum RoomTypes
    {
        None,
        StandartRoom,
        BusinessClassRoom,
        JuniorSuite,
        PresidentialSuite
    }

    public enum RoomsFree
    {
        None,
        Free,
        Not_free
    }

    public class Room : INotifyPropertyChanged
    {
        private RoomTypes _roomType;
        private RoomsFree _roomFree;
        private string _roomNumber;
        private int _roomId;
        private int _numPlaces;
        private IList<Client> _clients;

        public event PropertyChangedEventHandler PropertyChanged;

        public RoomTypes RoomType
        {
            get => _roomType;
            set
            {
                if (value == _roomType) return;
                _roomType = value;
                OnPropertyChanged("RoomType");
            }
        }

        public RoomsFree RoomFree
        {
            get => _roomFree;
            set
            {
                if (value == _roomFree) return;
                _roomFree = value;
                OnPropertyChanged("RoomFree");
            }
        }

        public string RoomNumber
        {
            get => _roomNumber;
            set
            {
                if (value == _roomNumber) return;
                _roomNumber = value;
                OnPropertyChanged("RoomNumber");
            }
        }

        public int RoomId
        {
            get => _roomId;
            set
            {
                if (value == _roomId) return;
                _roomId = value;
                OnPropertyChanged("RoomId");
            }
        }

        public IList<Client> Clients
        {
            get => _clients;
            set
            {
                if (Equals(value, _clients)) return;
                _clients = value;
                _roomFree = (RoomsFree)2;
                //_numPlaces--;
                OnPropertyChanged("Clients");
            }
        }

        public int NumPlaces
        {
            get => _numPlaces;
            set
            {
                if (value == _numPlaces) return;
                if(value > 5) { MessageBox.Show("Количество мест не должно превышать 4"); return; }
                _numPlaces = value;
                OnPropertyChanged("NumPlaces");
            }
        }

        public Room() => _clients = new List<Client>();

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

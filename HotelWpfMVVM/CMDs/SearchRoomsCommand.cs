using HotelWpfMVVM.HotelDBContext;
using HotelWpfMVVM.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace HotelWpfMVVM.CMDs
{
    class SearchRoomsCommand : CommandBase
    {
        public HotelContext Context { get; set; }

        public ObservableCollection<Room> Rooms { get; set; }

        public SearchRoomsCommand(HotelContext context, ObservableCollection<Room> rooms)
        {
            Context = context;
            Rooms = rooms;
        }

        public override bool CanExecute(object parameter) => (parameter as Room) != null &&
                (!string.IsNullOrEmpty((parameter as Room).RoomNumber) ||
                (parameter as Room).RoomType != 0 ||
                (parameter as Room).RoomFree != 0);

        public override void Execute(object parameter)
        {
            if (Rooms.Count > 0)
                Rooms.Clear();
            IEnumerable<Room> queryResult = Context.Rooms.Local;
            if (!string.IsNullOrEmpty(((Room)parameter).RoomNumber))
            {
                queryResult = queryResult.Where(r => r.RoomNumber.Contains(((Room)parameter).RoomNumber));
            }
            if (((Room)parameter).RoomType > 0)
            {
                queryResult = queryResult.Where(r => r.RoomType == ((Room)parameter).RoomType);
            }
            if (((Room)parameter).RoomFree == RoomsFree.Free)
            {
                queryResult = queryResult.Where(r => r.Clients.Count == 0);
            }
            if (((Room)parameter).RoomFree == RoomsFree.Not_free)
            {
                queryResult = queryResult.Where(r => r.Clients.Count > 0);
            }

            var rooms = queryResult.ToList();

            foreach (var item in rooms)
            {
                if(!Rooms.Contains(item))
                    Rooms.Add(item);
            }
        }
    }
}

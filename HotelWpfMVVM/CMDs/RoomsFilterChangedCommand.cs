using HotelWpfMVVM.HotelDBContext;
using HotelWpfMVVM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelWpfMVVM.CMDs
{
    class RoomsFilterChangedCommand : CommandBase
    {
        //private HotelContext Context { get; }
        //public RoomsFilterChangedCommand()
        //{

        //}

        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter)
        {
        //    IEnumerable<Room> queryResult = Context.Rooms.Local;
        //    if (!string.IsNullOrEmpty(RoomFilter.RoomNumber))
        //    {
        //        queryResult = queryResult.Where(room => room.RoomNumber.Contains(RoomFilter.RoomNumber));
        //    }
        //    if (RoomFilter.RoomType != RoomTypes.None)
        //    {
        //        queryResult = queryResult.Where(room => room.RoomType == RoomFilter.RoomType);
        //    }
        //    if (RoomFreedomFilterIndex == 1)
        //    {
        //        queryResult = queryResult.Where(room => room.Clients.Count == 0);
        //    }
        //    if (RoomFreedomFilterIndex == 2)
        //    {
        //        queryResult = queryResult.Where(room => room.Clients.Count > 0);
        //    }
        //    //FilteredRoomList = queryResult?.ToList();
        }
    }
}

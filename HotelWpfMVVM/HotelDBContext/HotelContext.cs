﻿using HotelWpfMVVM.Model;
using System.Data.Entity;

namespace HotelWpfMVVM.HotelDBContext
{
    public class HotelContext : DbContext
    {
        public HotelContext(string connectionString = "HotelDbConnectionString")
            : base(connectionString) { }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Room> Rooms { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new PersonConfig());
            modelBuilder.Configurations.Add(new ClientConfig());
            modelBuilder.Configurations.Add(new RoomConfig());
        }
    }
}

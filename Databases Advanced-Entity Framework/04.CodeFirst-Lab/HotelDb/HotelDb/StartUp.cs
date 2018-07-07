using System;
using System.Collections.Generic;
using HotelDb.Models;

namespace HotelDb
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var context = new HotelDbContext();
            var newEntry = new Room
            {
                BedCount = 1,
                Cost = 45.50m,
                IsAvailable = true,
                RoomNickname = "The Room",
                RoomType = RoomType.Standard.ToString(),
                RoomKeyCards = new List<RoomKeyCard>()
                {
                    new RoomKeyCard()
                    {
                        KeyCard = new KeyCard()
                        {
                            CardNumber = 1000
                        }
                    }
                }
            };

            context.Rooms.Add(newEntry);
            context.SaveChanges();

            var room = context.Rooms.Find(1);
            room.RoomKeyCards.Add(new RoomKeyCard() {KeyCard = new KeyCard() {CardNumber = 1200}});
            context.SaveChanges();

        }
    }
}

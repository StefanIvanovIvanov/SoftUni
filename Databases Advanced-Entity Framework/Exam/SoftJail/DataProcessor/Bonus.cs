﻿using System.Linq;
using SoftJail.Data.Models;

namespace SoftJail.DataProcessor
{

    using Data;
    using System;

    public class Bonus
    {
        public static string ReleasePrisoner(SoftJailDbContext context, int prisonerId)
        {
            Prisoner prisoner = context.Prisoners.FirstOrDefault(x => x.Id == prisonerId);

            if (prisoner.ReleaseDate == null)
            {
                return $"Prisoner {prisoner.FullName} is sentenced to life";
            }

            prisoner.ReleaseDate = DateTime.Now;
            prisoner.CellId = 0;

            return $"Prisoner {prisoner.FullName} released";
        }
    }
}

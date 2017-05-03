using System;
using System.Collections.Generic;

namespace Model
{
   public class Genre
    {
        public Int32 Id { get; set; }
        public String Omschrijving { get; set; }
        public ICollection<Boek> Boeken { get; set; }

        public override string ToString()
        {
            return $"{Omschrijving}";
        }
    }
}
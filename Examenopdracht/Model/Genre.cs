using System;
using System.Collections.Generic;

namespace Model
{
    class Genre
    {
        public Int32 Id { get; set; }
        public String Omschrijving { get; set; }
        public virtual ICollection<Boek> Boeken { get; set; }

        public override string ToString()
        {
            return $"{Omschrijving}";
        }
    }
}
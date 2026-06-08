using LiveMatch.Domain.Entities;
using LiveMatchDomain.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace LiveMatch.Domain.Entities
{
   

    public class Player : BaseEntity
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public int Number { get; set; }
        public string Nationality { get; set; }
        public int Age { get; set; }
        public string Photo { get; set; }
        public int ApiFootballId { get; set; }

        public int TeamId { get; set; }
        public Team Team { get; set; }
    }
}

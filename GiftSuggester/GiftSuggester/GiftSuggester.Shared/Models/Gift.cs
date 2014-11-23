namespace GiftSuggester.Models
{
    using SQLite;
    using System;
    using System.Collections.Generic;
    using System.Text;

    using GiftSuggester.Data;

    [Table("Gifts")]
    public class Gift : IBaseEntity
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Unique, MaxLength(150)]
        public string Name { get; set; }

        public string Address { get; set; }

        public double Longitude { get; set; }

        public double Latitude { get; set; }

        public string Image { get; set; }
    }
}

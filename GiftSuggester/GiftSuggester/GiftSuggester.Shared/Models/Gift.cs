namespace GiftSuggester.Models
{
    using SQLite;
    using System;
    using System.Collections.Generic;
    using System.Text;

    [Table("Gifts")]
    public class Gift
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [Unique, MaxLength(150)]
        public string Name { get; set; }

        public string Address { get; set; }

        public string Location { get; set; }

        public string Image { get; set; }
    }
}

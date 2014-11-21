namespace GiftSuggester.Models
{
    using SQLite;
    using System;
    using System.Collections.Generic;
    using System.Text;
        
    [Table("Friends")]
    public class Friend
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(150)]
        public string Name { get; set; }

        public string Avatar { get; set; }

        public ICollection<Gift> Gifts { get; set; }

        public ICollection<Event> Events { get; set; }

    }
}

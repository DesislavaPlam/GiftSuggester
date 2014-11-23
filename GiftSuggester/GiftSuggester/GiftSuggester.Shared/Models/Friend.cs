namespace GiftSuggester.Models
{
    using SQLite;
    using System;
    using System.Collections.Generic;
    using System.Text;

    using GiftSuggester.Data;

    [Table("Friends")]
    public class Friend : IBaseEntity
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(150)]
        public string Name { get; set; }

        public string Avatar { get; set; }
    }
}

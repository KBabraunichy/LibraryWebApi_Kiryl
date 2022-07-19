﻿using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace LibraryWebApi.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Year { get; set; }

        public int AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        [JsonIgnore]
        public Author? Author { get; set; }
        
        public override string ToString()
        {
            return Name + ';' + Year;
        }

    }


}

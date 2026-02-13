using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AcmeLibrary.Models
{
    [MetadataType(typeof(BookMetadata))]
    public partial class Book
    {

    }
    public class BookMetadata
    {
        public int Id { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Required(ErrorMessage = "Please provide the author(s) name")]
        public string Author { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [Required(ErrorMessage = "Please provide a title")]
        public string Title { get; set; }

        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [RegularExpression(@"[0-9]{13}$", ErrorMessage = "ISBN must be exactly 13 digits")]
        public string ISBN { get; set; }

        public DateTime Published { get; set; }

        public string Publisher { get; set; }
    }
}

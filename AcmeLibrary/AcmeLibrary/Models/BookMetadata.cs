using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AcmeLibrary.Models
{
    [MetadataType(typeof(BookMetadata))]
    public partial class book
    {

    }
    public class BookMetadata
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public DateTime Published { get; set; }
        public string Publisher { get; set; }
    }
}
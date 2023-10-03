using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MasterDetails.Models
{
    public class Client
    {
        public Client()
        {
            this.BookingEntries = new List<BookingEntry>();
        }
        public int ClientId { get; set; }
        [Required,StringLength(50, ErrorMessage = "Client Name is Required!!"),Display(Name = "Client Name")]
        public string ClientName { get; set; }
        [Required,Column(TypeName="date"), Display(Name = "Date of Birth"),DisplayFormat(DataFormatString ="{0:yyyy-MM-dd}",ApplyFormatInEditMode = true)]
        public DateTime BirthDate { get; set; }
        public int Age { get; set; }
        public string Picture { get; set; }
        public bool MaritalStatus { get; set; }

        //Nev

        public virtual ICollection<BookingEntry> BookingEntries { get; set; }

    }
    public class Spot
    {
        public Spot()
        {
            this.BookingEntries = new List<BookingEntry>();
        }
        public int SpotId { get; set; }
        [Required, StringLength(50, ErrorMessage = "Spot Name is Required!!"), Display(Name = "Spot Name")]
        public string SpotName { get; set;}

        //Nev

        public virtual ICollection<BookingEntry> BookingEntries { get; set; }
    }
    public class BookingEntry
    {
        public int BookingEntryId { get; set; }
        [ForeignKey("Client")]
        public int CliendId { get; set; }
        [ForeignKey("Spot")]
        public int SpotId { get; set; }

        //Nevigation or Assosiation
        public virtual Client Client { get; set; }
        public virtual Spot Spot { get; set; }

    }



}
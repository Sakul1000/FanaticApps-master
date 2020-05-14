using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace EventRestServ.Modles
{
    
    [Table("Event")]
     public partial class Events
    {
        [Required]
        [StringLength(50)]
        public int EventId { get; set; }

        public string EventNavn { get; set; }

        public int EventTid { get; set; }

        public int EventDato { get; set; }

        public string EventAdresse { get; set; }

        public int EventPostnummer { get; set; }
    }
}
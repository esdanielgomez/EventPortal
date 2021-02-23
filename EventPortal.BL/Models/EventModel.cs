using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPortal.BL.Models
{
    public class EventModel
    {
        public int IdEvent { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string RegistrationLink { get; set; }
        public string StreamingLink { get; set; }
    }
}

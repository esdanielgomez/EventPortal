using System;
using System.Collections.Generic;
using System.Text;

namespace EventPortal.BL.Models.Speakers
{
    public class SpeakerModel
    {
        public int IdSpeaker { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string FirstLastName { get; set; }
        public string SecondLastName { get; set; }
        public string PhotoLink { get; set; }
        public string TwitterLink { get; set; }
        public string LinkedInLink { get; set; }

        public List<SpeakerHasSessionModel> Sessions { get; set; }
    }
}

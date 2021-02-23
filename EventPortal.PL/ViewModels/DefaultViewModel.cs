using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using DotVVM.Framework.ViewModel;
using DotVVM.Framework.Hosting;
using EventPortal.BL.Models;
using EventPortal.BL.Services;

namespace EventPortal.PL.ViewModels
{
    public class DefaultViewModel : MasterPageViewModel
    {
		public string Title { get; set;}

		private SponsorService SponsorService;
		private EventService EventService;
		private SessionService SessionService;
		private OrganizerService OrganizerService { get; set; }
		public List<SponsorModel> Sponsors { get; set; }
		public List<OrganizerModel> Organizers { get; set; }
		public List<CalendarSpeakers> Calendar { get; set; } = new List<CalendarSpeakers>();

		public EventModel Event { get; set; }

		public DefaultViewModel(
			SponsorService SponsorService, 
			OrganizerService OrganizerService, 
			EventService EventService,
			SessionService SessionService)
		{
			Title = "Hello from DotVVM!";
			this.SponsorService = SponsorService;
			this.OrganizerService = OrganizerService;
			this.EventService = EventService;
			this.SessionService = SessionService;
		}

		private async Task MakeCalendarSessions()
        {

			
			int Day = 1;

			for (var dt = Event.StartDate; dt <= Event.EndDate; dt = dt.AddDays(1))
			{
				CalendarSpeakers DayCalendar = new CalendarSpeakers
				{
					DateDay = dt,
					NumberOfDayRef = "day-" + Day,
					NumberOfDayRef2 = "#day-" + Day,
					NumberOfDay = Day,
					Css = "col-lg-9  tab-pane fade"
				};

				if(Day == 1)
                {
					DayCalendar.Css = "col-lg-9 tab-pane fade show active";
                }

				DayCalendar.Sessions = await SessionService.GetAllSessionByDayAsync(dt);

				foreach (SessionModel session in DayCalendar.Sessions)
				{
					session.SpeakersSessions = await SessionService.GetSpeakerHasSessionList(session.IdSession);
					
					for (int s = 0; s < session.SpeakersSessions.Count; s++)
                    {
						
						session.SpeakerString = session.SpeakerString + (session.SpeakersSessions[s].FirstName + " " + session.SpeakersSessions[s].FirstLastName);

						Console.WriteLine(session.SpeakerString);

						if (s + 1 < session.SpeakersSessions.Count)
							session.SpeakerString = session.SpeakerString + ", ";

					}
				}

				Calendar.Add(DayCalendar);
				Day++;

			}
		}

		public override async Task PreRender()
		{
			Sponsors = await SponsorService.GetAllSponsorsAsync();
			Organizers = await OrganizerService.GetAllOrganizersAsync();

			Event = await EventService.GetEventByIdAsync();

			await MakeCalendarSessions();

			await base.PreRender();
		}
	}

	public class CalendarSpeakers
    {
		public int NumberOfDay { get; set; }
		public string NumberOfDayRef { get; set; }
		public string NumberOfDayRef2 { get; set; }
		public DateTime DateDay { get; set; }
		public string Css { get; set; }
		public List<SessionModel> Sessions { get; set; }
    }
}

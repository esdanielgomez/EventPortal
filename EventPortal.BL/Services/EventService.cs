using EventPortal.BL.Models;
using EventPortal.DAL;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPortal.BL.Services
{
    public class EventService
    {
        private readonly DBContext DbContext;

        public EventService(DBContext DbContext)
        {
            this.DbContext = DbContext;
        }

        public async Task<EventModel> GetEventByIdAsync()
        {
            return await DbContext.Event.Select(
                    s => new EventModel
                    {
                        IdEvent = s.IdEvent,
                        Name = s.Name,
                        Description = s.Description,
                        Icon = s.Icon,
                        RegistrationLink = s.RegistrationLink,
                        StreamingLink = s.StreamingLink,
                        StartDate = s.StartDate,
                        EndDate = s.EndDate

                    })
                .FirstOrDefaultAsync(s => s.IdEvent == EventId.GetInstance().Id);

        }
    }
}

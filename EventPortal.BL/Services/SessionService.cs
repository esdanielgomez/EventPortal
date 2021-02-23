using EventPortal.BL.Models;
using EventPortal.BL.Models.Speakers;
using EventPortal.DAL;
using EventPortal.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventPortal.BL.Services
{
    public class SessionService
    {
        private readonly DBContext DbContext;

        public SessionService(DBContext DbContext)
        {
            this.DbContext = DbContext;
        }

        public async Task<List<SessionModel>> GetAllSessionAsync()
        {

            return await DbContext.Session.Select(
                 s => new SessionModel
                {
                    IdSession = s.IdSession,
                    Name = s.Name,
                    StartDate = s.StartDate,
                    EndDate = s.EndDate,
                    Description = s.Description,
                    IconLink = s.IconLink,
                    IdSessionLevel = s.IdSessionLevelNavigation.IdSessionLevel,
                    NameSessionLevel = s.IdSessionLevelNavigation.Name,
                    IdSessionType = s.IdSessionTypeNavigation.IdSessionType,
                    NameSessionType = s.IdSessionTypeNavigation.Name
                 }).ToListAsync();
        }

        public async Task<List<SessionModel>> GetAllSessionByDayAsync(DateTime date)
        {

            return await DbContext.Session.Select(
                 s => new SessionModel
                 {
                     IdSession = s.IdSession,
                     Name = s.Name,
                     StartDate = s.StartDate,
                     EndDate = s.EndDate,
                     Description = s.Description,
                     IconLink = s.IconLink,
                     IdSessionLevel = s.IdSessionLevelNavigation.IdSessionLevel,
                     NameSessionLevel = s.IdSessionLevelNavigation.Name,
                     IdSessionType = s.IdSessionTypeNavigation.IdSessionType,
                     NameSessionType = s.IdSessionTypeNavigation.Name
                 }).Where(s => s.StartDate.Value.Day == date.Day && s.StartDate.Value.Month == date.Month && s.StartDate.Value.Year == date.Year).OrderBy(o => o.StartDate).ToListAsync();
        }

        public async Task<List<SpeakerHasSessionModel>> GetSpeakerHasSessionList(int IdSession)
        {
                return await DbContext.SpeakerHasSession.Select(
                s => new SpeakerHasSessionModel
                {
                    IdSpeaker = s.IdSpeaker,
                    FirstName = s.IdSpeakerNavigation.FirstName,
                    SecondName = s.IdSpeakerNavigation.SecondName,
                    FirstLastName = s.IdSpeakerNavigation.FirstLastName,
                    SecondLastName = s.IdSpeakerNavigation.SecondLastName,

                    IdSession = s.IdSession,
                    Name = s.IdSessionNavigation.Name,
                    StartDate = s.IdSessionNavigation.StartDate,
                    NameSessionLevel = s.IdSessionNavigation.IdSessionLevelNavigation.Name,
                    NameSessionType = s.IdSessionNavigation.IdSessionTypeNavigation.Name
                }
            ).Where(s => s.IdSession == IdSession).ToListAsync();
        }

        
    }
}

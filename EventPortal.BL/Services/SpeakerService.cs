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
    public class SpeakerService
    {
        private readonly DBContext DbContext;

        public SpeakerService(DBContext DbContext)
        {
            this.DbContext = DbContext;
        }

        public async Task<List<SpeakerModel>> GetAllSpeakerAsync()
        {

            return await DbContext.Speaker.Select(
                s => new SpeakerModel
                {
                    IdSpeaker = s.IdSpeaker,
                    FirstName = s.FirstName,
                    SecondName = s.SecondName,
                    FirstLastName = s.FirstLastName,
                    SecondLastName = s.SecondLastName
                }
            ).ToListAsync();
        }

        public async Task<SpeakerModel> GetSpeakerByIdAsync(int IdSpeaker)
        {
            SpeakerModel speaker = await DbContext.Speaker.Select(
                    s => new SpeakerModel
                    {
                        IdSpeaker = s.IdSpeaker,
                        FirstName = s.FirstName,
                        SecondName = s.SecondName,
                        FirstLastName = s.FirstLastName,
                        SecondLastName = s.SecondLastName,
                        TwitterLink = s.TwitterLink,
                        LinkedInLink = s.LinkedInLink,
                        PhotoLink = s.PhotoLink

                    })
                .FirstOrDefaultAsync(s => s.IdSpeaker == IdSpeaker);

            speaker.Sessions = await DbContext.SpeakerHasSession.Select(
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
            ).Where(s => s.IdSpeaker == IdSpeaker).ToListAsync();

            return speaker;

        }

        
    }
}

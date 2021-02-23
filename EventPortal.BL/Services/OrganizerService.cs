using EventPortal.BL.Models;
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
    public class OrganizerService
    {
        private readonly DBContext DbContext;

        public OrganizerService(DBContext DbContext)
        {
            this.DbContext = DbContext;
        }

        public async Task<List<OrganizerModel>> GetAllOrganizersAsync()
        {

            return await DbContext.Organizer.Select(
                s => new OrganizerModel
                {
                    IdOrganizer = s.IdOrganizer,
                    Name = s.Name,
                    Description = s.Description,
                    WebPage = s.WebPage,
                    LogoLink = s.LogoLink,
                    Email = s.Email,
                    FacebookLink = s.FacebookLink,
                    InstagramLink = s.InstagramLink,
                    TwitterLink = "https://twitter.com/" + s.TwitterLink
                }
            ).ToListAsync();
        }

        
    }
}

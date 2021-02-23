using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EventPortal.BL.Models;
using EventPortal.DAL;
using EventPortal.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventPortal.BL.Services
{
    public class SponsorService
    {
        private readonly DBContext DbContext;

        public SponsorService(DBContext DbContext)
        {
            this.DbContext = DbContext;
        }

        public async Task<List<SponsorModel>> GetAllSponsorsAsync()
        {

            return await DbContext.Sponsor.Select(
                s => new SponsorModel
                {
                    IdSponsor = s.IdSponsor,
                    Name = s.Name,
                    Description = s.Description,
                    LogoLink = s.LogoLink,
                    WebPage = s.WebPage
                    
                }
            ).ToListAsync();
        }

        
    }
}

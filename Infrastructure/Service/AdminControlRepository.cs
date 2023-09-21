using DataContextStructure;
using DataStructure.Entites;
using DataStructure.ViewModel;
using Infrastructure.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Server.IIS.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
    public class AdminControlRepository : IAdminControl
    {
        private readonly ESMContext _context;
           
        public AdminControlRepository(ESMContext context) 
        { _context = context; }

        public async Task<bool> AddOrUpdateAnnouncement(AnnouncementData model)
        {
            bool result;
           if (model.Id <1 ) 
            {
                var data = new Announcement
                {
                    //Announcer = _context.Users.FirstOrDefault().UserName,
                    Announcer=model.Announcer,
                    AnnouncementOne = model.AnnouncementOne,
                    AnnouncementThree = model.AnnouncementThree,
                    AnnouncementTwo = model.AnnouncementTwo,
                    AnnouncementDate = DateTime.Now,
                };
                _context.announcement.Add(data);
                result=await _context.SaveChangesAsync()>0;
            }
            else 
            {
                var getId = _context.announcement.Find(model.Id);
                if (getId == null)
                {
                    throw new("Not found");
                }
                {
                 getId.AnnouncementOne=model.AnnouncementOne;
                    getId.Announcer = model.Announcer;
                    getId.AnnouncementTwo=model.AnnouncementTwo;
                    getId.AnnouncementThree=model.AnnouncementThree;
                    getId.AnnouncementDate=DateTime.Now;
                    result = await _context.SaveChangesAsync() > 0;
                }
              
            }
           return result;
        }

        public async Task<bool> AddOrUpdatePresidentCharge(PresidentChargeData model)
        {
            bool result;

            if (model == null) throw new ("No data available");
            var chargedate = new DateTime();
            if (!string.IsNullOrEmpty(model.ChargeDate))
            {
                var splitChargedate = model.ChargeDate.Split('/');
                chargedate = new DateTime(int.Parse(splitChargedate[2]), int.Parse(splitChargedate[0]), int.Parse(splitChargedate[1]));
            }
            if (chargedate.Year > DateTime.Now.Year || chargedate.Month > DateTime.Now.Month || chargedate.Day > DateTime.Now.Day)
            {
                throw new($"{chargedate.Day}/{chargedate.Month}/{chargedate.Year} not okay. Please select correct date.");
            }
            if (model.Id<1)
            {
                var data = new PresidentCharge
                {
                    Session = model.Session,
                    ChargeDate = chargedate,
                    Surname = model.Surname,
                    Firstname = model.Firstname,
                    Charge = model.Charge,
                    Faculty = model.Faculty,
                    CourseOfStudy = model.CourseOfStudy,
                };
                _context.presidentCharge.Add(data);
              result= await _context.SaveChangesAsync()>0;
            }
            else 
            {
                var getId = _context.presidentCharge.Find(model.Id);
                if (getId == null)
                {
                    throw new("Not found");
                }
                {
                    getId.Session = model.Session;
                    getId.Charge=model.Charge;
                    getId.Firstname= model.Firstname;
                    getId.Surname= model.Surname;
                    getId.CourseOfStudy= model.CourseOfStudy;   
                    getId.Faculty= model.Faculty;   
                    getId.ChargeDate=chargedate;
                }
                result = await _context.SaveChangesAsync() > 0;
            }
            return result;   
        }

        public IQueryable GetAnnouncementOne()
        {
            var ret = _context.announcement.OrderBy(s => s.Id).LastOrDefault().AnnouncementOne
               .AsQueryable();
            if (ret == null)
            {
                throw new("No record found.");
            }
            return ret;
        }

        public IQueryable GetAnnouncementThree()
        {
            var ret = _context.announcement.OrderBy(s => s.Id).LastOrDefault().AnnouncementThree
                .AsQueryable();
            if (ret == null)
            {
                throw new("No record found.");
            }
            return ret; ;
        }

        public IQueryable GetAnnouncementTwo()
        {
            var ret = _context.announcement.OrderBy(s => s.Id).LastOrDefault().AnnouncementTwo
               .AsQueryable();
            if (ret == null)
            {
                throw new("No record found.");
            }
            return ret;
        }

        public IQueryable GetPresidentCharge()
        {
            var ret = _context.presidentCharge.OrderBy(s=>s.Id).LastOrDefault().Charge
               .AsQueryable();
            if (ret==null)
            {
                throw new ("No record found.");
            }
            return ret; 
        }

        public IQueryable<AnnouncementDTO> ListAllAnnouncement()
        {
            return (from p in _context.announcement select new AnnouncementDTO 
            {
               Announcer = p.Announcer,
               AnnouncementDate = p.AnnouncementDate,
               AnnouncementThree= p.AnnouncementThree,
               AnnouncementTwo= p.AnnouncementTwo,
               AnnouncementOne= p.AnnouncementOne,
               Id= p.Id
            });
        }

        public IQueryable<PresidentChargeDTO> ListAllPresidentChargeAsync()
        {
            return(from s in _context.presidentCharge 
            select new PresidentChargeDTO { 
                Id = s.Id,
                Surname = s.Surname == null ? "" : s.Surname,
                Firstname = s.Firstname == null ? "" : s.Firstname,
                Charge = s.Charge == null ? "" : s.Charge,
                Session = s.Session == null ? "" : s.Session,
                ChargeDate = s.ChargeDate,
                Faculty = s.Faculty == null ? "" : s.Faculty,
                CourseOfStudy = s.CourseOfStudy == null ? "" : s.CourseOfStudy,
            });

            
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Threading.Tasks;
using DataStructure.ViewModel;
using DataStructure.Entites;
using DataContextStructure;
using Infrastructure.Interface;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;

namespace Infrastructure.Service
{
    public class UnitRepository:IUnitRepository
    {
        private readonly ESMContext _context;
        public UnitRepository(ESMContext context)
        {
            _context = context;
        }
        public async Task<bool> AddOrUpdatePrayerUnitAsync(PrayerUnitDTOData model)
        {
            
            bool result;
            if (model.id <1)
            {
                
                var pData = new PrayerUnit
                {
                    Surname = model.surname,
                    Firstname = model.firstname,
                    Middlename = model.middlename,
                    PhoneNumber01 = model.phoneNumber01,
                    PhoneNumber02 = model.phoneNumber02,
                    Email = model.email,
                    HomeAddress = model.homeAddress,
                    HostelAddress = model.hostelAddress,
                    CourseOfStudy = model.courseOfStudy,
                    Unit = model.unit,
                    DateOfBirth = model.dateOfBirth,
                    PreviousUnit = model.previousUnit,
                    PositionInFamily = model.positionInFamily,
                    SocialMediaAddress = model.socialMediaAddress,
                    Photo = model.photo,
                    
                };
                _context.prayerUnit.Add(pData);
                result = await _context.SaveChangesAsync() > 0;
            }
            else
            {
                var prayerData = _context.prayerUnit.Find(model.id);
               
                if (prayerData is null)
                {
                    throw new("Not found");
                }
                    prayerData.Surname = model.surname;
                    prayerData.Firstname = model.firstname;
                    prayerData.Middlename = model.middlename;
                    prayerData.PhoneNumber01 = model.phoneNumber01;
                    prayerData.PhoneNumber02 = model.phoneNumber02;
                    prayerData.Email = model.email;
                    prayerData.HomeAddress = model.homeAddress;
                    prayerData.HostelAddress = model.hostelAddress;
                    prayerData.CourseOfStudy = model.courseOfStudy;
                    prayerData.Unit = model.unit;
                    prayerData.DateOfBirth = model.dateOfBirth;
                    prayerData.PreviousUnit = model.previousUnit;
                    prayerData.PositionInFamily = model.positionInFamily;
                    prayerData.SocialMediaAddress = model.socialMediaAddress;
                  //  prayerData.Photo = uniqueFileName;
                    result = await _context.SaveChangesAsync() > 0;
            }
            return result;
        }

      
        public string DeletePrayerUnit(int[] ids)
        {
            foreach (var id in ids)
            {
                var query = $"Delete from Prayerunit where Id={id}";
                _context.Database.ExecuteSqlRaw(query);
            }
            return "";
        }

        public IQueryable<PrayerUnitDTO> ListAllPrayerUnitData()
        {
            return (from s in _context.prayerUnit
                    select new PrayerUnitDTO
                    {
                        Id = s.Id,
                        Surname = s.Surname==null ? "": s.Surname,
                        Firstname= s.Firstname == null ? "" : s.Firstname,
                        Middlename= s.Middlename == null ? "" : s.Middlename,
                        Unit= s.Unit == null ? "" : s.Unit,
                        CourseOfStudy= s.CourseOfStudy == null ? "" : s.CourseOfStudy,
                        Email= s.Email == null ? "" : s.Email,
                        PhoneNumber01= s.PhoneNumber01 == null ? "" : s.PhoneNumber01,
                        PhoneNumber02= s.PhoneNumber02 == null ? "" : s.PhoneNumber02,
                        HomeAddress= s.HomeAddress == null ? "" : s.HomeAddress,
                        HostelAddress= s.HostelAddress == null ? "" : s.HostelAddress,
                        PreviousUnit =s.PreviousUnit == null ? "" : s.PreviousUnit,
                        DateOfBirth=s.DateOfBirth == null ? null : s.DateOfBirth,
                        PositionInFamily=s.PositionInFamily == null ? "" : s.PositionInFamily,
                        SocialMediaAddress=s.SocialMediaAddress == null ? "" : s.SocialMediaAddress,
                        Photo= s.Photo == null ? "":s.Photo,
                    });
        }
    }
}

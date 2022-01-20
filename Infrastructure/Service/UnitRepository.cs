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
                    SocialMediaAddress = model.socialMediaAddress
                    
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
                        Surname = s.Surname,
                        Firstname= s.Firstname,
                        Middlename= s.Middlename,
                        Unit= s.Unit,
                        CourseOfStudy= s.CourseOfStudy,
                        Email= s.Email,
                        PhoneNumber01= s.PhoneNumber01,
                        PhoneNumber02= s.PhoneNumber02,
                        HomeAddress= s.HomeAddress,
                        HostelAddress= s.HostelAddress,
                        PreviousUnit =s.PreviousUnit,
                        DateOfBirth=s.DateOfBirth,
                        PositionInFamily=s.PositionInFamily,
                        SocialMediaAddress=s.SocialMediaAddress,
                    });
        }
    }
}

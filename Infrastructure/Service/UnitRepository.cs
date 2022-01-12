using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataStructure.ViewModel;
using DataStructure.Entites;
using DataContextStructure;
using Infrastructure.Interface;

namespace Infrastructure.Service
{
    public class UnitRepository:IUnitRepository
    {
        private readonly ESMContext _context;
        public UnitRepository(ESMContext context)
        {
            _context = context;
        }
        public async Task<bool> AddOrUpdatePrayerUnit(PrayerUnitDTOData model)
        {
            bool result;
            if (model.Id <1)
            {
                var pData = new PrayerUnit
                {
                    Surname = model.Surname,
                    Firstname = model.Firstname,
                    Middlename = model.Middlename,
                    PhoneNumber01 = model.PhoneNumber01,
                    PhoneNumber02 = model.PhoneNumber02,
                    Email = model.Email,
                    HomeAddress = model.HomeAddress,
                    HostelAddress = model.HostelAddress,
                    CourseOfStudy = model.CourseOfStudy,
                    Unit = model.Unit,
                    DateOfBirth = model.DateOfBirth,
                    PreviousUnit = model.PreviousUnit,
                    PositionInFamily = model.PositionInFamily,
                    SocialMediaAddress = model.SocialMediaAddress
                };
                _context.prayerUnit.Add(pData);
                result = await _context.SaveChangesAsync() > 0;
            }
            else
            {
                var prayerData = _context.prayerUnit.Find(model.Id);
                if (prayerData is null)
                {
                    throw new("Not found");
                }
                    prayerData.Surname = model.Surname;
                    prayerData.Firstname = model.Firstname;
                    prayerData.Middlename = model.Middlename;
                    prayerData.PhoneNumber01 = model.PhoneNumber01;
                    prayerData.PhoneNumber02 = model.PhoneNumber02;
                    prayerData.Email = model.Email;
                    prayerData.HomeAddress = model.HomeAddress;
                    prayerData.HostelAddress = model.HostelAddress;
                    prayerData.CourseOfStudy = model.CourseOfStudy;
                    prayerData.Unit = model.Unit;
                    prayerData.DateOfBirth = model.DateOfBirth;
                    prayerData.PreviousUnit = model.PreviousUnit;
                    prayerData.PositionInFamily = model.PositionInFamily;
                    prayerData.SocialMediaAddress = model.SocialMediaAddress;
                    result = await _context.SaveChangesAsync() > 0;
            }
            return result;
        }
    }
}

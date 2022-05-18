﻿ using System;
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
        private readonly IHostingEnvironment _environment;
        public UnitRepository(ESMContext context, IHostingEnvironment environment)
        {
            _context = context;
            this._environment = environment;
        }
        public async Task<bool> AddOrUpdateBibleStudyUnitAsync(BibleStudyUnitData model)
        {
            bool result;
            if (model.Id < 1)
            {

                var Data = new BibleStudyUnit
                {
                    Surname = model.Surname,
                    Firstname = model.Firstname,
                    Middlename = model.Middlename,
                    PhoneNumber01 = model.PhoneNumber01,
                    PhoneNumber02 = model.PhoneNumber02,
                    Email = model.Email,
                    Gender = model.Gender,
                    StateOfOrigin = model.StateOfOrigin,
                    LGA = model.LGA,
                    HomeAddress = model.HomeAddress,
                    HostelAddress = model.HostelAddress,
                    CourseOfStudy = model.CourseOfStudy,
                    Unit = model.Unit,
                    DateOfBirth = model.DateOfBirth,
                    DateJoinESM = model.DateJoinESM,
                    PreviousUnit = model.PreviousUnit,
                    PositionInFamily = model.PositionInFamily,
                    SocialMediaAddress = model.SocialMediaAddress,

                };
                _context.bibleStudyUnit.Add(Data);
                result = await _context.SaveChangesAsync() > 0;
            }
            else
            {
                var bibleStudyData = _context.bibleStudyUnit.Find(model.Id);

                if (bibleStudyData is null)
                {
                    throw new("Not found");
                }
                bibleStudyData.Surname = model.Surname;
                bibleStudyData.Firstname = model.Firstname;
                bibleStudyData.Middlename = model.Middlename;
                bibleStudyData.PhoneNumber01 = model.PhoneNumber01;
                bibleStudyData.PhoneNumber02 = model.PhoneNumber02;
                bibleStudyData.Email = model.Email;
                bibleStudyData.HomeAddress = model.HomeAddress;
                bibleStudyData.HostelAddress = model.HostelAddress;
                bibleStudyData.CourseOfStudy = model.CourseOfStudy;
                bibleStudyData.Unit = model.Unit;
                bibleStudyData.StateOfOrigin = model.StateOfOrigin;
                bibleStudyData.LGA = model.LGA;
                bibleStudyData.PreviousUnit = model.PreviousUnit;
                bibleStudyData.DateOfBirth = model.DateOfBirth;
                bibleStudyData.DateJoinESM = model.DateJoinESM;
                bibleStudyData.Gender = model.Gender;
                bibleStudyData.PositionInFamily = model.PositionInFamily;
                bibleStudyData.SocialMediaAddress = model.SocialMediaAddress;
                result = await _context.SaveChangesAsync() > 0;
            }
            return result;
        }
        public string DeleteBibleStudyUnit(int id)
        { 
            var del= _context.bibleStudyUnit.Where(u => u.Id == id).FirstOrDefault();
            if (del != null)
                _context.bibleStudyUnit.Remove(del);
            _context.SaveChanges();
            return "";
        }
        public IQueryable<BibleStudyUnitDTO> GetAllBibleStudyUnitsAsync()
        {
            return (from s in _context.bibleStudyUnit
                    select new BibleStudyUnitDTO
                    {
                        Id = s.Id,
                        Surname = s.Surname == null ? "" : s.Surname,
                        Firstname = s.Firstname == null ? "" : s.Firstname,
                        Middlename = s.Middlename == null ? "" : s.Middlename,
                        Unit = s.Unit == null ? "" : s.Unit,
                        CourseOfStudy = s.CourseOfStudy == null ? "" : s.CourseOfStudy,
                        Email = s.Email == null ? "" : s.Email,
                        PhoneNumber01 = s.PhoneNumber01 == null ? "" : s.PhoneNumber01,
                        PhoneNumber02 = s.PhoneNumber02 == null ? "" : s.PhoneNumber02,
                        HomeAddress = s.HomeAddress == null ? "" : s.HomeAddress,
                        HostelAddress = s.HostelAddress == null ? "" : s.HostelAddress,
                        PreviousUnit = s.PreviousUnit == null ? "" : s.PreviousUnit,
                        DateOfBirth = s.DateOfBirth == null ? null : s.DateOfBirth,
                        PositionInFamily = s.PositionInFamily == null ? "" : s.PositionInFamily,
                        SocialMediaAddress = s.SocialMediaAddress == null ? "" : s.SocialMediaAddress,
                        Photo = s.Photo == null ? "" : s.Photo,
                    });
        }
        public IQueryable<StateDTO> ListState()
        {
            return _context.state.AsNoTracking().Select(s => new StateDTO
            {
                StateName=s.StateName
            });
                    
        }
        public async Task<bool> AddOrUpdatePrayerUnitAsync(PrayerUnitDTOData model)
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
                    Gender = model.Gender,
                    StateOfOrigin = model.StateOfOrigin,
                    LGA = model.LGA,
                    HomeAddress = model.HomeAddress,
                    HostelAddress = model.HostelAddress,
                    CourseOfStudy = model.CourseOfStudy,
                    Unit = model.Unit,
                    DateOfBirth = model.DateOfBirth,
                    DateJoinESM = model.DateJoinESM,
                    PreviousUnit = model.PreviousUnit,
                    PositionInFamily = model.PositionInFamily,
                    SocialMediaAddress = model.SocialMediaAddress,
                    
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
                    prayerData.StateOfOrigin=model.StateOfOrigin;
                    prayerData.LGA=model.LGA;
                    prayerData.PreviousUnit=model.PreviousUnit;
                    prayerData.DateOfBirth = model.DateOfBirth;
                    prayerData.DateJoinESM =model.DateJoinESM;
                    prayerData.Gender= model.Gender;
                    prayerData.PositionInFamily = model.PositionInFamily;
                    prayerData.SocialMediaAddress = model.SocialMediaAddress;
                    result = await _context.SaveChangesAsync() > 0;
            }
            return result;
        }

        private string UploadedFile(PrayerUnitDTOData model)
        {
            string uniqueFileName = null;

            if (model.Image != null)
            {
                string uploadsFolder = Path.Combine(_environment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + model.Image.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.Image.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }

        public string DeletePrayerUnit(int id)
        {
            var del = _context.prayerUnit.Where(s => s.Id == id).FirstOrDefault();

            _context.prayerUnit.Remove(del);
            _context.SaveChanges();

            //if (del != null)
            //{
            //    _context.prayerUnit.Remove(del);
            //    _context.SaveChanges();
            //}
            //    var query = $"Delete from Prayerunit where Id={ids}";
            //    _context.Database.ExecuteSqlRaw(query);
            //}
            //foreach (var id in del)
           // {
                //_context.prayerUnit.Remove(ids);
                //_context.SaveChanges();
               // var query = $"Delete from Prayerunit where Id={id}";
                //_context.Database.ExecuteSqlRaw(query);
            //}
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
                        Unit = s.Unit == null ? "" : s.Unit,
                        Gender = s.Gender == null ? "" : s.Gender,
                        LGA = s.LGA == null ? "" : s.LGA,
                        StateOfOrigin = s.StateOfOrigin == null ? "" : s.StateOfOrigin,
                        DateJoinESM = s.DateJoinESM == null ? null : s.DateJoinESM,
                        Ambition = s.Ambition == null ? "" : s.Ambition,
                        CourseOfStudy = s.CourseOfStudy == null ? "" : s.CourseOfStudy,
                        Email = s.Email == null ? "" : s.Email,
                        PhoneNumber01 = s.PhoneNumber01 == null ? "" : s.PhoneNumber01,
                        PhoneNumber02 = s.PhoneNumber02 == null ? "" : s.PhoneNumber02,
                        HomeAddress = s.HomeAddress == null ? "" : s.HomeAddress,
                        HostelAddress = s.HostelAddress == null ? "" : s.HostelAddress,
                        PreviousUnit = s.PreviousUnit == null ? "" : s.PreviousUnit,
                        DateOfBirth = s.DateOfBirth == null ? null : s.DateOfBirth,
                        PositionInFamily = s.PositionInFamily == null ? "" : s.PositionInFamily,
                        SocialMediaAddress = s.SocialMediaAddress == null ? "" : s.SocialMediaAddress,
                        Photo = s.Photo == null ? "" : s.Photo,
                    });
        }

       
    }
}

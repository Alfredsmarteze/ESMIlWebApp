﻿using System;
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
            var bdate = new DateTime();
            if (!string.IsNullOrEmpty(model.DateOfBirth))
            {
                var splitDateOfBirth = model.DateOfBirth.Split('/');
                bdate = new DateTime(int.Parse(splitDateOfBirth[2]), int.Parse(splitDateOfBirth[0]), int.Parse(splitDateOfBirth[1]));
            }

            var dateJoin = new DateTime();
            if (!string.IsNullOrEmpty(model.DateJoinESM))
            {
                var splitDateJoin = model.DateJoinESM.Split('/');
                dateJoin = new DateTime(int.Parse(splitDateJoin[2]), int.Parse(splitDateJoin[0]), int.Parse(splitDateJoin[1]));
            }
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
                    Ambition = model.Ambition,
                    HomeAddress = model.HomeAddress,
                    HostelAddress = model.HostelAddress,
                    CourseOfStudy = model.CourseOfStudy,
                    Unit = model.Unit,
                    DateOfBirth =bdate,
                    DateJoinESM =dateJoin,
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
                bibleStudyData.Ambition = model.Ambition;
                bibleStudyData.StateOfOrigin = model.StateOfOrigin;
                bibleStudyData.LGA = model.LGA;
                bibleStudyData.PreviousUnit = model.PreviousUnit;
                bibleStudyData.DateOfBirth = bdate;
                bibleStudyData.DateJoinESM = dateJoin;
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
        public async Task<bool> AddOrUpdatePrayerUnitAsync(PrayerUnitDTOData model)
        {
            
            bool result;
            //DateTime? bdate = null;
            var bdate = new DateTime();
            if (!string.IsNullOrEmpty(model.DateOfBirth))
            {
                var splitDateOfBirth = model.DateOfBirth.Split('/');
                bdate = new DateTime(int.Parse(splitDateOfBirth[2]), int.Parse(splitDateOfBirth[0]), int.Parse(splitDateOfBirth[1]));
            }

            //DateTime? dateJoin = null;
            var dateJoin = new DateTime();
            if (!string.IsNullOrEmpty(model.DateJoinESM))
            {
                var splitDateJoin = model.DateJoinESM.Split('/');
                dateJoin = new DateTime(int.Parse(splitDateJoin[2]), int.Parse(splitDateJoin[0]), int.Parse(splitDateJoin[1]));
            }

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
                    Ambition=model.Ambition,
                    HomeAddress = model.HomeAddress,
                    HostelAddress = model.HostelAddress,
                    CourseOfStudy = model.CourseOfStudy,
                    Unit = model.Unit,
                    DateOfBirth =bdate,
                    DateJoinESM = dateJoin,
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
                    prayerData.Ambition = model.Ambition;
                    prayerData.StateOfOrigin=model.StateOfOrigin;
                    prayerData.LGA=model.LGA;
                    prayerData.PreviousUnit=model.PreviousUnit;
                    prayerData.DateOfBirth = bdate;//model.DateOfBirth;
                    prayerData.DateJoinESM = dateJoin;// model.DateJoinESM;
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
            if (del==null)
            {
                throw new("Not found");
            }
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
        public async Task<bool>AddOrUpdateChoralUnitAsync(ChoralUnitData model)
        {
            bool result;
            //DateTime? bdate = null;
            var bdate = new DateTime();
            if (!string.IsNullOrEmpty(model.DateOfBirth))
            {
                var splitDateOfBirth = model.DateOfBirth.Split('/');
                bdate = new DateTime(int.Parse(splitDateOfBirth[2]), int.Parse(splitDateOfBirth[0]), int.Parse(splitDateOfBirth[1]));
            }

            //DateTime? dateJoin = null;
            var dateJoin = new DateTime();
            if (!string.IsNullOrEmpty(model.DateJoinESM))
            {
                var splitDateJoin = model.DateJoinESM.Split('/');
                dateJoin = new DateTime(int.Parse(splitDateJoin[2]), int.Parse(splitDateJoin[0]), int.Parse(splitDateJoin[1]));
            }

            if (model.Id < 1)
            {

                var bData = new ChoralUnit
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
                    Ambition = model.Ambition,
                    HomeAddress = model.HomeAddress,
                    HostelAddress = model.HostelAddress,
                    CourseOfStudy = model.CourseOfStudy,
                    Unit = model.Unit,
                    DateOfBirth = bdate,
                    DateJoinESM = dateJoin,
                    PreviousUnit = model.PreviousUnit,
                    PositionInFamily = model.PositionInFamily,
                    SocialMediaAddress = model.SocialMediaAddress,
                };
                _context.choralUnit.Add(bData);
                result = await _context.SaveChangesAsync() > 0;
            }
            else
            {
                var prayerData = _context.choralUnit.Find(model.Id);

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
                prayerData.Ambition = model.Ambition;
                prayerData.StateOfOrigin = model.StateOfOrigin;
                prayerData.LGA = model.LGA;
                prayerData.PreviousUnit = model.PreviousUnit;
                prayerData.DateOfBirth = bdate;//model.DateOfBirth;
                prayerData.DateJoinESM = dateJoin;// model.DateJoinESM;
                prayerData.Gender = model.Gender;
                prayerData.PositionInFamily = model.PositionInFamily;
                prayerData.SocialMediaAddress = model.SocialMediaAddress;
                result = await _context.SaveChangesAsync() > 0;
            }
            return result;
        }
        public IQueryable<ChoralUnitDTO>GetAllChoralUnitsAsync()
        {
            return (from s in _context.choralUnit
                    select new ChoralUnitDTO
                    {
                        Id = s.Id,
                        Surname = s.Surname == null ? "" : s.Surname,
                        Firstname = s.Firstname == null ? "" : s.Firstname,
                        Middlename = s.Middlename == null ? "" : s.Middlename,
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
        public string DeleteChoralUnit(int id)
        {
           var del= _context.choralUnit.FirstOrDefault(c => c.Id == id);
            if (del == null)
            {
                throw new("Not found");
            }
            _context.choralUnit.Remove(del);
            _context.SaveChangesAsync();
            return "";
        }
        public IQueryable<StateDTO> ListState()
        {
            return _context.state.AsNoTracking().Select(s => new StateDTO
            {
                StateName = s.StateName
            });

        }
        public async Task<bool> AddOrUpdateDMEUnitAsync(DMEUnitData model)
        {
            bool result;
            //DateTime? bdate = null;
            var bdate = new DateTime();
            if (!string.IsNullOrEmpty(model.DateOfBirth))
            {
                var splitDateOfBirth = model.DateOfBirth.Split('/');
                bdate = new DateTime(int.Parse(splitDateOfBirth[2]), int.Parse(splitDateOfBirth[0]), int.Parse(splitDateOfBirth[1]));
            }

            //DateTime? dateJoin = null;
            var dateJoin = new DateTime();
            if (!string.IsNullOrEmpty(model.DateJoinESM))
            {
                var splitDateJoin = model.DateJoinESM.Split('/');
                dateJoin = new DateTime(int.Parse(splitDateJoin[2]), int.Parse(splitDateJoin[0]), int.Parse(splitDateJoin[1]));
            }

            if (model.Id < 1)
            {

                var pData = new DmeUnit
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
                    Ambition = model.Ambition,
                    HomeAddress = model.HomeAddress,
                    HostelAddress = model.HostelAddress,
                    CourseOfStudy = model.CourseOfStudy,
                    Unit = model.Unit,
                    DateOfBirth = bdate,
                    DateJoinESM = dateJoin,
                    PreviousUnit = model.PreviousUnit,
                    PositionInFamily = model.PositionInFamily,
                    SocialMediaAddress = model.SocialMediaAddress,
                };
                _context.dmeUnit.Add(pData);
                result = await _context.SaveChangesAsync() > 0;
            }
            else
            {
                var prayerData = _context.dmeUnit.Find(model.Id);

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
                prayerData.Ambition = model.Ambition;
                prayerData.StateOfOrigin = model.StateOfOrigin;
                prayerData.LGA = model.LGA;
                prayerData.PreviousUnit = model.PreviousUnit;
                prayerData.DateOfBirth = bdate;//model.DateOfBirth;
                prayerData.DateJoinESM = dateJoin;// model.DateJoinESM;
                prayerData.Gender = model.Gender;
                prayerData.PositionInFamily = model.PositionInFamily;
                prayerData.SocialMediaAddress = model.SocialMediaAddress;
                result = await _context.SaveChangesAsync() > 0;
            }
            return result;
        }
        public IQueryable<DmeUnitDTO> ListAllDmeUnitData()
        {
            return (from s in _context.dmeUnit
                    select new DmeUnitDTO
                    {
                        Id = s.Id,
                        Surname = s.Surname == null ? "" : s.Surname,
                        Firstname = s.Firstname == null ? "" : s.Firstname,
                        Middlename = s.Middlename == null ? "" : s.Middlename,
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
        public string DeleteDmeUnit(int id)
        {
            var del = _context.dmeUnit.FirstOrDefault(s => s.Id == id);
            if (del != null)
            {
                _context.dmeUnit.Remove(del);
                _context.SaveChangesAsync();
            }
            else {
                return "Not found";
            }

            return "";
        }
        public async Task<bool> AddOrUpdatePublicityUnit(PublicityUnitData model)
        {
            bool result;
            //DateTime? bdate = null;
            var bdate = new DateTime();
            if (!string.IsNullOrEmpty(model.DateOfBirth))
            {
                var splitDateOfBirth = model.DateOfBirth.Split('/');
                bdate = new DateTime(int.Parse(splitDateOfBirth[2]), int.Parse(splitDateOfBirth[0]), int.Parse(splitDateOfBirth[1]));
            }

            //DateTime? dateJoin = null;
            var dateJoin = new DateTime();
            if (!string.IsNullOrEmpty(model.DateJoinESM))
            {
                var splitDateJoin = model.DateJoinESM.Split('/');
                dateJoin = new DateTime(int.Parse(splitDateJoin[2]), int.Parse(splitDateJoin[0]), int.Parse(splitDateJoin[1]));
            }

            if (model.Id < 1)
            {

                var pData = new PublicityAndEditorialUnit
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
                    Ambition = model.Ambition,
                    HomeAddress = model.HomeAddress,
                    HostelAddress = model.HostelAddress,
                    CourseOfStudy = model.CourseOfStudy,
                    Unit = model.Unit,
                    DateOfBirth = bdate,
                    DateJoinESM = dateJoin,
                    PreviousUnit = model.PreviousUnit,
                    PositionInFamily = model.PositionInFamily,
                    SocialMediaAddress = model.SocialMediaAddress,
                };
                _context.publicityAndEditorialUnit.Add(pData);
                result = await _context.SaveChangesAsync() > 0;
            }
            else
            {
                var publicityData = _context.publicityAndEditorialUnit.Find(model.Id);

                if (publicityData is null)
                {
                    throw new("Not found");
                }
                publicityData.Surname = model.Surname;
                publicityData.Firstname = model.Firstname;
                publicityData.Middlename = model.Middlename;
                publicityData.PhoneNumber01 = model.PhoneNumber01;
                publicityData.PhoneNumber02 = model.PhoneNumber02;
                publicityData.Email = model.Email;
                publicityData.HomeAddress = model.HomeAddress;
                publicityData.HostelAddress = model.HostelAddress;
                publicityData.CourseOfStudy = model.CourseOfStudy;
                publicityData.Unit = model.Unit;
                publicityData.Ambition = model.Ambition;
                publicityData.StateOfOrigin = model.StateOfOrigin;
                publicityData.LGA = model.LGA;
                publicityData.PreviousUnit = model.PreviousUnit;
                publicityData.DateOfBirth = bdate;//model.DateOfBirth;
                publicityData.DateJoinESM = dateJoin;// model.DateJoinESM;
                publicityData.Gender = model.Gender;
                publicityData.PositionInFamily = model.PositionInFamily;
                publicityData.SocialMediaAddress = model.SocialMediaAddress;
                result = await _context.SaveChangesAsync() > 0;
            }
            return result;
        }
        public IQueryable<PublicityAndEditorialUnitDTO> ListAllPublicityUnitAsync()
        {
            return (from s in _context.publicityAndEditorialUnit
                    select new PublicityAndEditorialUnitDTO
                    {
                        Id = s.Id,
                        Surname = s.Surname == null ? "" : s.Surname,
                        Firstname = s.Firstname == null ? "" : s.Firstname,
                        Middlename = s.Middlename == null ? "" : s.Middlename,
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
        public string DeletePublicityUnit(int id)
        {
           var del=_context.publicityAndEditorialUnit.FirstOrDefault(x => x.Id == id);
            if (del != null)
            {
                _context.publicityAndEditorialUnit.Remove(del);
                _context.SaveChangesAsync();
            }
            else
            {
              throw new("Not found");
            }
            return "";
        }
    }
}

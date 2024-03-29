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
using DataStructure;
using static DataStructure.ViewModel.EsmafData;
using System.Security.Cryptography;

namespace Infrastructure.Service
{
    public class UnitRepository : IUnitRepository
    {
        private readonly ESMContext _context;
        private readonly IHostingEnvironment _environment;
        public UnitRepository(ESMContext context, IHostingEnvironment environment)
        {
            _context = context;
            this._environment = environment;
        }
        public async Task<bool> AddOrUpdateFirstTimerAsync(FirstTimerData model) 
        {
            bool result;
            var jDate = new DateTime();
            if (!string.IsNullOrEmpty(model.JoiningVisitingDate))
            {
                var splitDateJoinOrVisit= model.JoiningVisitingDate.Split('/');
                jDate = new DateTime(int.Parse(splitDateJoinOrVisit[2]), int.Parse(splitDateJoinOrVisit[0]), int.Parse(splitDateJoinOrVisit[1]));
            }
            if (jDate.Year > DateTime.UtcNow.Year||jDate.Month>DateTime.UtcNow.Month||jDate.Day>DateTime.UtcNow.Day)
            {
                throw new($"You cannot join ESM in year {jDate.Year}. Please input correct date");
            }
            if (model.Id<1)
            {
                var data = new FirstTimer
                {
                    Surname = model.Surname,
                    Othernames = model.Othernames,
                    JoiningVisitingDate = jDate,
                    FacultyName = model.FacultyName,
                    DepartmentName = model.DepartmentName,
                    Gender = model.Gender,  
                    PhoneNumber =model.PhoneNumber,
                    ReasonOfComing=model.ReasonOfComing,
                };
                _context.firstTimer.Add(data);
                result = await _context.SaveChangesAsync() > 0;
            }
            else
            {
                var firstTimer = _context.firstTimer.Find(model.Id);
                if (firstTimer == null)
                {
                    throw new("Not found");
                }
                firstTimer.Surname = model.Surname;
                firstTimer.Othernames = model.Othernames;
                firstTimer.JoiningVisitingDate= jDate;
                firstTimer.FacultyName = model.FacultyName;
                firstTimer.DepartmentName=model.DepartmentName;
                firstTimer.Gender = model.Gender;
                firstTimer.ReasonOfComing = model.ReasonOfComing;
                firstTimer.PhoneNumber =model.PhoneNumber;
                result = await _context.SaveChangesAsync() > 0;
            }
            return result;
        }
        public IQueryable<FirstTimerDTO> ListAllFirstTimerAsync()
        {
            return (from s in _context.firstTimer
                    select new FirstTimerDTO
                    {
                        Id = s.Id,
                        Surname=s.Surname ==null ? "" :s.Surname,  
                        Othernames=s.Othernames ==null ? "" : s.Othernames,    
                        FacultyName=s.FacultyName==null ? "" : s.FacultyName,
                        DepartmentName=s.DepartmentName == null ? "" : s.DepartmentName, 
                        ReasonOfComing=s.ReasonOfComing == null ? "" : s.ReasonOfComing,
                        JoiningVisitingDate=s.JoiningVisitingDate==null ? null:s.JoiningVisitingDate,
                        PhoneNumber=s.PhoneNumber,
                        Gender=s.Gender == null ? "" :s.Gender

                    });
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
            if (dateJoin.Year > DateTime.Now.Year || dateJoin.Month > DateTime.Now.Month || dateJoin.Day > DateTime.Now.Day)
            {
                throw new($"You cannot join ESM in year {dateJoin.Year}. Please select correct date.");
            }
            if (dateJoin.Year == DateTime.Now.Year)
            {
                if (dateJoin.Month == DateTime.Now.Month)
                {
                    if (dateJoin.Day == DateTime.Now.Day)
                    { }
                    else if (dateJoin.Day > DateTime.Now.Day)
                    { throw new($"You cannot join ESM on this future day {dateJoin.Day}. Please input correct date."); }
                }
            }
            if (bdate.Year > dateJoin.Year || bdate.Year == DateTime.Now.Year)
            {
                throw new($"Your date of birth cannot be in year {bdate.Year.ToString()}. please select correct date.");
            }
            if (bdate.Year - DateTime.Now.Year < 14)
            {
                var yr = DateTime.Now.Year - bdate.Year;
                if (yr == 1)
                {
                    throw new($"{yr} year old! Please select correct date of birth");
                }
                else if (yr > 1 && yr < 14)
                {
                    throw new($"{yr} years old! Please select correct date of birth");
                }
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
                    DateOfBirth = bdate,
                    DateJoinESM = dateJoin,
                    PreviousUnit = model.PreviousUnit,
                    PositionInFamily = model.PositionInFamily,
                    SocialMediaAddress = model.SocialMediaAddress,
                    CreatedOn=DateTime.Now,

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
                //var checkLga = _context.lga.Any(s => s.LgaName == model.LGA);
                //if (!checkLga)
                //{
                //    throw new("Please input correct LGA.");
                //}
                //var checkState = _context.state.Any(s => s.StateName == model.StateOfOrigin);
                //if (!checkState)
                //{
                //    throw new("Please input correct State of Origin.");
                //}
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
        public string DeleteBibleStudyUnitById(int id)
        {
            var del = _context.bibleStudyUnit.Where(u => u.Id == id).FirstOrDefault();
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
            if (dateJoin.Year > DateTime.Now.Year || dateJoin.Month > DateTime.Now.Month || dateJoin.Day > DateTime.Now.Day)
            {
                throw new($"You cannot join ESM in year {dateJoin.Year}. Please select correct date.");
            }
            if (dateJoin.Year == DateTime.Now.Year)
            {
                if (dateJoin.Month == DateTime.Now.Month)
                {
                    if (dateJoin.Day == DateTime.Now.Day)
                    { }
                    else if (dateJoin.Day > DateTime.Now.Day)
                    { throw new($"You cannot join ESM on this future day {dateJoin.Day}. Please input correct date."); }
                }
            }
            if (bdate.Year > dateJoin.Year || bdate.Year == DateTime.Now.Year)
            {
                throw new($"Your date of birth cannot be in year {bdate.Year.ToString()}. please select correct date.");
            }
            if (bdate.Year - DateTime.Now.Year < 14)
            {
                var yr = DateTime.Now.Year - bdate.Year;
                if (yr == 1)
                {
                    throw new($"{yr} year old! Please select correct date of birth");
                }
                else if (yr > 1 && yr < 14)
                {
                    throw new($"{yr} years old! Please select correct date of birth");
                }
            }
            if (model.Id < 1)
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
                    Ambition = model.Ambition,
                    HomeAddress = model.HomeAddress,
                    HostelAddress = model.HostelAddress,
                    CourseOfStudy = model.CourseOfStudy,
                    Unit = model.Unit,
                    DateOfBirth = bdate,
                    DateJoinESM = dateJoin,
                    PreviousUnit = model.PreviousUnit,
                    PositionInFamily = model.PositionInFamily,
                    CreatedOn=DateTime.Now,
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
               //var checkLga= _context.lga.Any(s => s.LgaName == model.LGA);
               // if (!checkLga)
               // {
               //     throw new("Please input correct LGA.");
               // }
               // var checkState = _context.state.Any(s => s.StateName == model.StateOfOrigin);
               // if (!checkState)
               // {
               //     throw new("Please input correct State of Origin.");
               // }
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
        public string DeletePrayerUnitById(int id)
        {
            var del = _context.prayerUnit.Where(s => s.Id == id).FirstOrDefault();
            if (del == null)
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
                       // Photo = s.Photo == null ? 0 : s.Photo,
                    });
        }
        public async Task<bool> AddOrUpdateChoralUnitAsync(ChoralUnitData model)
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
            if (dateJoin.Year > DateTime.Now.Year || dateJoin.Month > DateTime.Now.Month || dateJoin.Day > DateTime.Now.Day)
            {
                throw new($"You cannot join ESM in year {dateJoin.Year}. Please select correct date.");
            }
            if (dateJoin.Year == DateTime.Now.Year)
            {
                if (dateJoin.Month == DateTime.Now.Month)
                {
                    if (dateJoin.Day == DateTime.Now.Day)
                    { }
                    else if (dateJoin.Day > DateTime.Now.Day)
                    { throw new($"You cannot join ESM on this future day {dateJoin.Day}. Please input correct date."); }
                }
            }
            if (bdate.Year > dateJoin.Year || bdate.Year == DateTime.Now.Year)
            {
                throw new($"Your date of birth cannot be in year {bdate.Year}. please select correct date.");
            }
            if (bdate.Year - DateTime.Now.Year < 14)
            {
                var yr = DateTime.Now.Year - bdate.Year;
                if (yr == 1)
                {
                    throw new($"{yr} year old! Please select correct date of birth");
                }
                else if (yr > 1 && yr < 14)
                {
                    throw new($"{yr} years old! Please select correct date of birth");
                }
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
                    CreatedOn=DateTime.Now,
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
                //var checkLga = _context.lga.Any(s => s.LgaName == model.LGA);
                //if (!checkLga)
                //{
                //    throw new("Please input correct LGA.");
                //}
                //var checkState = _context.state.Any(s => s.StateName == model.StateOfOrigin);
                //if (!checkState)
                //{
                //    throw new("Please input correct State of Origin.");
                //}
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
        public IQueryable<ChoralUnitDTO> GetAllChoralUnitsAsync()
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
        public string DeleteChoralUnitById(int id)
        {
            var del = _context.choralUnit.FirstOrDefault(c => c.Id == id);
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

        public IQueryable GetState(string stateName)
        {
            var st= _context.lga.Where(s => s.LgaName == stateName).Select(d =>d.LgaName);
            
            return st; 
        }

        public IQueryable<LgaDTO> ListLga()
        {
            return _context.lga.AsNoTracking().Select(s => new LgaDTO
            {
                LgaName = s.LgaName
            });
        }
        public async Task<bool> AddOrUpdateDMEUnitAsync(DMEUnitData model)
        {
            bool result;

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
            if (dateJoin.Year > DateTime.Now.Year || dateJoin.Month > DateTime.Now.Month || dateJoin.Day > DateTime.Now.Day)
            {
                throw new($"You cannot join ESM in year {dateJoin.Year}. Please select correct date.");
            }
            if (dateJoin.Year == DateTime.Now.Year)
            {
                if (dateJoin.Month == DateTime.Now.Month)
                {
                    if (dateJoin.Day == DateTime.Now.Day)
                    { }
                    else if (dateJoin.Day > DateTime.Now.Day)
                    { throw new($"You cannot join ESM on this future day {dateJoin.Day}. Please input correct date."); }
                }
            }
            if (bdate.Year > dateJoin.Year || bdate.Year == DateTime.Now.Year)
            {
                throw new($"Your date of birth cannot be in year {bdate.Year.ToString()}. please select correct date.");
            }
            if (bdate.Year - DateTime.Now.Year < 14)
            {
                var yr = DateTime.Now.Year - bdate.Year;
                if (yr == 1)
                {
                    throw new($"{yr} year old! Please select correct date of birth");
                }
                else if (yr >1 && yr < 14)
                {
                    throw new($"{yr} years old! Please select correct date of birth");
                }
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
                    CreatedOn=DateTime.Now,
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
                //var checkLga = _context.lga.Any(s => s.LgaName == model.LGA);
                //if (!checkLga)
                //{
                //    throw new("Please input correct LGA.");
                //}
                //var checkState = _context.state.Any(s => s.StateName == model.StateOfOrigin);
                //if (!checkState)
                //{
                //    throw new("Please input correct State of Origin.");
                //}
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
        public string DeleteDmeUnitById(int id)
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
            if (dateJoin.Year > DateTime.Now.Year || dateJoin.Month>DateTime.Now.Month|| dateJoin.Day>DateTime.Now.Day)
            {
                throw new($"You cannot join ESM in year {dateJoin.Year}. Please select correct date.");
            }
            if (dateJoin.Year == DateTime.Now.Year)
            {
                if (dateJoin.Month == DateTime.Now.Month)
                {
                    if (dateJoin.Day == DateTime.Now.Day)
                    { }
                    else if (dateJoin.Day > DateTime.Now.Day)
                    { throw new($"You cannot join ESM on this future day {dateJoin.Day}. Please input correct date."); }
                }
            }
            if (bdate.Year > dateJoin.Year || bdate.Year == DateTime.Now.Year)
            {
                throw new($"Your date of birth cannot be in year {bdate.Year.ToString()}. please select correct date.");
            }
            if (bdate.Year - DateTime.Now.Year < 14)
            {
                var yr = DateTime.Now.Year - bdate.Year;
                if (yr == 1)
                {
                    throw new($"{yr} year old! Please select correct date of birth");
                }
                else if (yr>1 && yr<14)
                {
                    throw new($"{yr} years old! Please select correct date of birth");
                } 
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
                    CreatedOn=DateTime.Now,
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
                //var checkLga = _context.lga.Any(s => s.LgaName == model.LGA);
                //if (!checkLga)
                //{
                //    throw new("Please input correct LGA.");
                //}
                //var checkState = _context.state.Any(s => s.StateName == model.StateOfOrigin);
                //if (!checkState)
                //{
                //    throw new("Please input correct State of Origin.");
                //}
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
        public string DeletePublicityUnitById(int id)
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
        public async Task<bool> AddOrUpdateTechnicalUnitAsync(TechnicalUnitData model)
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
            if (dateJoin.Year > DateTime.Now.Year || dateJoin.Month > DateTime.Now.Month || dateJoin.Day > DateTime.Now.Day)
            {
                throw new($"You cannot join ESM in year {dateJoin.Year}. Please select correct date.");
            }
            if (dateJoin.Year == DateTime.Now.Year)
            {
                if (dateJoin.Month == DateTime.Now.Month)
                {
                    if (dateJoin.Day == DateTime.Now.Day)
                    { }
                    else if (dateJoin.Day > DateTime.Now.Day)
                    { throw new($"You cannot join ESM on this future day {dateJoin.Day}. Please input correct date."); }
                }
            }
            if (bdate.Year > dateJoin.Year || bdate.Year == DateTime.Now.Year)
            {
                throw new($"Your date of birth cannot be in year {bdate.Year.ToString()}. please select correct date.");
            }
            if (bdate.Year - DateTime.Now.Year < 14)
            {
                var yr = DateTime.Now.Year - bdate.Year;
                if (yr == 1)
                {
                    throw new($"{yr} year old! Please select correct date of birth");
                }
                else if (yr > 1 && yr < 14)
                {
                    throw new($"{yr} years old! Please select correct date of birth");
                }
            }
            if (model.Id < 1)
            {

                var technicalData = new TechnicalUnit
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
                    CreatedOn=DateTime.Now,
                    DateJoinESM = dateJoin,
                    PreviousUnit = model.PreviousUnit,
                    PositionInFamily = model.PositionInFamily,
                    SocialMediaAddress = model.SocialMediaAddress,
                };
                _context.technicalUnit.Add(technicalData);
                result = await _context.SaveChangesAsync() > 0;
            }
            else
            {
                var technicalData = _context.technicalUnit.Find(model.Id);

                if (technicalData is null)
                {
                    throw new("Not found");
                }
                //var checkLga = _context.lga.Any(s => s.LgaName == model.LGA);
                //if (!checkLga)
                //{
                //    throw new("Please input correct LGA.");
                //}
                //var checkState = _context.state.Any(s => s.StateName == model.StateOfOrigin);
                //if (!checkState)
                //{
                //    throw new("Please input correct State of Origin.");
                //}
                technicalData.Surname = model.Surname;
                technicalData.Firstname = model.Firstname;
                technicalData.Middlename = model.Middlename;
                technicalData.PhoneNumber01 = model.PhoneNumber01;
                technicalData.PhoneNumber02 = model.PhoneNumber02;
                technicalData.Email = model.Email;
                technicalData.HomeAddress = model.HomeAddress;
                technicalData.HostelAddress = model.HostelAddress;
                technicalData.CourseOfStudy = model.CourseOfStudy;
                technicalData.Unit = model.Unit;
                technicalData.Ambition = model.Ambition;
                technicalData.StateOfOrigin = model.StateOfOrigin;
                technicalData.LGA = model.LGA;
                technicalData.PreviousUnit = model.PreviousUnit;
                technicalData.DateOfBirth = bdate;//model.DateOfBirth;
                technicalData.DateJoinESM = dateJoin;// model.DateJoinESM;
                technicalData.Gender = model.Gender;
                technicalData.PositionInFamily = model.PositionInFamily;
                technicalData.SocialMediaAddress = model.SocialMediaAddress;
                result = await _context.SaveChangesAsync() > 0;
            }
            return result;
        }
        public async Task<bool> AddOrUpdateWelfareUnitAsync(WelfareUnitData model)
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
            if (dateJoin.Year > DateTime.Now.Year || dateJoin.Month > DateTime.Now.Month || dateJoin.Day > DateTime.Now.Day)
            {
                throw new($"You cannot join ESM in year {dateJoin.Year}. Please select correct date.");
            }
            if (dateJoin.Year == DateTime.Now.Year)
            {
                if (dateJoin.Month == DateTime.Now.Month)
                {
                    if (dateJoin.Day == DateTime.Now.Day)
                    { }
                    else if (dateJoin.Day > DateTime.Now.Day)
                    { throw new($"You cannot join ESM on this future day {dateJoin.Day}. Please input correct date."); }
                }
            }
            if (bdate.Year > dateJoin.Year || bdate.Year == DateTime.Now.Year)
            {
                throw new($"Your date of birth cannot be in year {bdate.Year.ToString()}. please select correct date.");
            }
            if (bdate.Year - DateTime.Now.Year < 14)
            {
                var yr = DateTime.Now.Year - bdate.Year;
                if (yr == 1)
                {
                    throw new($"{yr} year old! Please select correct date of birth");
                }
                else if (yr > 1 && yr < 14)
                {
                    throw new($"{yr} years old! Please select correct date of birth");
                }
            }
            if (model.Id < 1)
            {

                var pData = new WelfareUnit
                {
                    Surname = model.Surname,
                    Firstname = model.Firstname,
                    Middlename = model.Middlename,
                    PhoneNumber01 = model.PhoneNumber01,
                    PhoneNumber02 = model.PhoneNumber02,
                    Email = model.Email,
                    CreatedOn=DateTime.Now,
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
                _context.welfareUnit.Add(pData);
                result = await _context.SaveChangesAsync() > 0;
            }
            else
            {
                var welfareData = _context.welfareUnit.Find(model.Id);

                if (welfareData is null)
                {
                    throw new("Not found");
                }
                //var checkLga = _context.lga.Any(s => s.LgaName == model.LGA);
                //if (!checkLga)
                //{
                //    throw new("Please input correct LGA.");
                //}
                //var checkState = _context.state.Any(s => s.StateName == model.StateOfOrigin);
                //if (!checkState)
                //{
                //    throw new("Please input correct State of Origin.");
                //}
                welfareData.Surname = model.Surname;
                welfareData.Firstname = model.Firstname;
                welfareData.Middlename = model.Middlename;
                welfareData.PhoneNumber01 = model.PhoneNumber01;
                welfareData.PhoneNumber02 = model.PhoneNumber02;
                welfareData.Email = model.Email;
                welfareData.HomeAddress = model.HomeAddress;
                welfareData.HostelAddress = model.HostelAddress;
                welfareData.CourseOfStudy = model.CourseOfStudy;
                welfareData.Unit = model.Unit;
                welfareData.Ambition = model.Ambition;
                welfareData.StateOfOrigin = model.StateOfOrigin;
                welfareData.LGA = model.LGA;
                welfareData.PreviousUnit = model.PreviousUnit;
                welfareData.DateOfBirth = bdate;//model.DateOfBirth;
                welfareData.DateJoinESM = dateJoin;// model.DateJoinESM;
                welfareData.Gender = model.Gender;
                welfareData.PositionInFamily = model.PositionInFamily;
                welfareData.SocialMediaAddress = model.SocialMediaAddress;
                result = await _context.SaveChangesAsync() > 0;
            }
            return result;
        }
        public IQueryable<TechnicalUnitDTO> ListAllTechnicalUnitAsync()
        {
            return (from s in _context.technicalUnit
                    select new TechnicalUnitDTO
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
        public IQueryable<WelfareUnitDTO> ListAllWelfareUnitAsync()
        {
            return (from s in _context.welfareUnit
                    select new WelfareUnitDTO
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
        public string DeleteTechnicalUnitById(int id)
        {
            var deleteTechUnit = _context.technicalUnit.Find(id);
            if (deleteTechUnit != null)
            _context.Remove(deleteTechUnit);
            _context.SaveChangesAsync();
            return "";
        }
        public string DeleteWelfareUnitById(int id)
        {
            var deleteWelfare=_context.welfareUnit.Find(id);
            if (deleteWelfare != null) 
            _context.Remove(deleteWelfare);
            _context.SaveChangesAsync();
            return "";
        }
        public async Task<bool> AddOrUpdateUsheringUnitAsync(UsheringUnitData model)
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
            if (dateJoin.Year > DateTime.Now.Year || dateJoin.Month > DateTime.Now.Month || dateJoin.Day > DateTime.Now.Day)
            {
                throw new($"You cannot join ESM in year {dateJoin.Year}. Please select correct date.");
            }
            if (dateJoin.Year == DateTime.Now.Year)
            {
                if (dateJoin.Month == DateTime.Now.Month)
                {
                    if (dateJoin.Day == DateTime.Now.Day)
                    { }
                    else if (dateJoin.Day > DateTime.Now.Day)
                    { throw new($"You cannot join ESM on this future day {dateJoin.Day}. Please input correct date."); }
                }
            }
            if (bdate.Year > dateJoin.Year || bdate.Year == DateTime.Now.Year)
            {
                throw new($"Your date of birth cannot be in year {bdate.Year.ToString()}. please select correct date.");
            }
            if (bdate.Year - DateTime.Now.Year < 14)
            {
                var yr = DateTime.Now.Year - bdate.Year;
                if (yr == 1)
                {
                    throw new($"{yr} year old! Please select correct date of birth");
                }
                else if (yr > 1 && yr < 14)
                {
                    throw new($"{yr} years old! Please select correct date of birth");
                }
            }
            if (model.Id < 1)
            {

                var usheringData = new UsheringUnit
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
                    CreatedOn=DateTime.Now,
                    PreviousUnit = model.PreviousUnit,
                    PositionInFamily = model.PositionInFamily,
                    SocialMediaAddress = model.SocialMediaAddress,
                };
                _context.usheringUnit.Add(usheringData);
                result = await _context.SaveChangesAsync() > 0;
            }
            else
            {
                var usheringData = _context.usheringUnit.Find(model.Id);

                if (usheringData is null)
                {
                    throw new("Not found");
                }
                //var checkLga = _context.lga.Any(s => s.LgaName == model.LGA);
                //if (!checkLga)
                //{
                //    throw new("Please input correct LGA.");
                //}
                //var checkState = _context.state.Any(s => s.StateName == model.StateOfOrigin);
                //if (!checkState)
                //{
                //    throw new("Please input correct State of Origin.");
                //}
                usheringData.Surname = model.Surname;
                usheringData.Firstname = model.Firstname;
                usheringData.Middlename = model.Middlename;
                usheringData.PhoneNumber01 = model.PhoneNumber01;
                usheringData.PhoneNumber02 = model.PhoneNumber02;
                usheringData.Email = model.Email;
                usheringData.HomeAddress = model.HomeAddress;
                usheringData.HostelAddress = model.HostelAddress;
                usheringData.CourseOfStudy = model.CourseOfStudy;
                usheringData.Unit = model.Unit;
                usheringData.Ambition = model.Ambition;
                usheringData.StateOfOrigin = model.StateOfOrigin;
                usheringData.LGA = model.LGA;
                usheringData.PreviousUnit = model.PreviousUnit;
                usheringData.DateOfBirth = bdate;//model.DateOfBirth;
                usheringData.DateJoinESM = dateJoin;// model.DateJoinESM;
                usheringData.Gender = model.Gender;
                usheringData.PositionInFamily = model.PositionInFamily;
                usheringData.SocialMediaAddress = model.SocialMediaAddress;
                result = await _context.SaveChangesAsync() > 0;
            }
            return result;
        }
        public IQueryable<UsheringUnitDTO> ListAllUsheringUnitAsync()
        {
            return(from s in _context.usheringUnit select new UsheringUnitDTO {

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
        public string DeleteUsheringUnitById(int id)
        {
           var deleteUsheringById=_context.usheringUnit.Find(id);
            if (deleteUsheringById != null)
                _context.Remove(deleteUsheringById);
            _context.SaveChangesAsync();
            return "";
        }
        public async Task<bool> AddOrUpdateTransportUnitAsync(TransportUnitData model)
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
            if (dateJoin.Year > DateTime.Now.Year || dateJoin.Month > DateTime.Now.Month || dateJoin.Day > DateTime.Now.Day)
            {
                throw new($"You cannot join ESM in year {dateJoin.Year}. Please select correct date.");
            }
            if (dateJoin.Year == DateTime.Now.Year)
            {
                if (dateJoin.Month == DateTime.Now.Month)
                {
                    if (dateJoin.Day == DateTime.Now.Day)
                    { }
                    else if (dateJoin.Day > DateTime.Now.Day)
                    { throw new($"You cannot join ESM on this future day {dateJoin.Day}. Please input correct date."); }
                }
            }
            if (bdate.Year > dateJoin.Year || bdate.Year == DateTime.Now.Year)
            {
                throw new($"Your date of birth cannot be in year {bdate.Year.ToString()}. please select correct date.");
            }
            if (bdate.Year - DateTime.Now.Year < 14)
            {
                var yr = DateTime.Now.Year - bdate.Year;
                if (yr == 1)
                {
                    throw new($"{yr} year old! Please select correct date of birth");
                }
                else if (yr > 1 && yr < 14)
                {
                    throw new($"{yr} years old! Please select correct date of birth");
                }
            }
            if (model.Id < 1)
            {

                var transportUnitData = new TransportUnit
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
                    CreatedOn=DateTime.Now,
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
                _context.transportUnit.Add(transportUnitData);
                result = await _context.SaveChangesAsync() > 0;
            }
            else
            {
                var transportUnitData = _context.transportUnit.Find(model.Id);

                if (transportUnitData is null)
                {
                    throw new("Not found");
                }
                //var checkLga = _context.lga.Any(s => s.LgaName == model.LGA);
                //if (!checkLga)
                //{
                //    throw new("Please input correct LGA.");
                //}
                //var checkState = _context.state.Any(s => s.StateName == model.StateOfOrigin);
                //if (!checkState)
                //{
                //    throw new("Please input correct State of Origin.");
                //}
                transportUnitData.Surname = model.Surname;
                transportUnitData.Firstname = model.Firstname;
                transportUnitData.Middlename = model.Middlename;
                transportUnitData.PhoneNumber01 = model.PhoneNumber01;
                transportUnitData.PhoneNumber02 = model.PhoneNumber02;
                transportUnitData.Email = model.Email;
                transportUnitData.HomeAddress = model.HomeAddress;
                transportUnitData.HostelAddress = model.HostelAddress;
                transportUnitData.CourseOfStudy = model.CourseOfStudy;
                transportUnitData.Unit = model.Unit;
                transportUnitData.Ambition = model.Ambition;
                transportUnitData.StateOfOrigin = model.StateOfOrigin;
                transportUnitData.LGA = model.LGA;
                transportUnitData.PreviousUnit = model.PreviousUnit;
                transportUnitData.DateOfBirth = bdate;//model.DateOfBirth;
                transportUnitData.DateJoinESM = dateJoin;// model.DateJoinESM;
                transportUnitData.Gender = model.Gender;
                transportUnitData.PositionInFamily = model.PositionInFamily;
                transportUnitData.SocialMediaAddress = model.SocialMediaAddress;
                result = await _context.SaveChangesAsync() > 0;
            }
            return result;
        }
        public IQueryable<TransportUnitDTO> ListAllTransportUnitAsync()
        {
            return(from s in _context.transportUnit select new TransportUnitDTO {
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
        public string DeleteTransportUnitById(int id)
        {
            var deleteTransportById =_context.transportUnit.Find(id);
            if (deleteTransportById !=null)
            {
                _context.transportUnit.Remove(deleteTransportById);
                _context.SaveChangesAsync();
            }
            return "";
        }

       
             
    }
}

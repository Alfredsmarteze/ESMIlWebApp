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
using DataStructure;
using static DataStructure.ViewModel.EsmafData;
using System.ComponentModel.Design;

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
        public IQueryable<ESMAFDTO> ListAllEsmafAsync()
        {
            return (from d in _context.eSMAF
                    from c in _context.pastExecutive.Where(x=>d.Surname==x.SurnameExcos && x.OthernameExcos==d.Othernames && x.Gender==d.Gender)
                   // join c in _context.pastExecutive on  d.Surname equals c.SurnameExcos && d.S
                    select new ESMAFDTO
                    {
                        Id=d.Id,
                        Surname = d.Surname ==null ? "" :d.Surname,
                        Othernames=d.Othernames== null ? "" : d.Othernames,
                        Gender=d.Gender== null ? "" : d.Gender,
                        UnitServed=d.UnitServed ==null ? "" :d.UnitServed,
                        Office=c.Office==null ? "" :c.Office,
                        Email=d.Email == null ? "" : d.Email,
                        HouseAddress=d.HouseAddress == null ? "" : d.HouseAddress,
                        PhoneNumber=d.PhoneNumber== null ? "" : d.PhoneNumber,
                        CourseOfStudy=d.CourseOfStudy== null ? "" :d.CourseOfStudy,
                        YearOfEntry=d.YearOfEntry== null ? null : d.YearOfEntry,
                        YearOfGraduation=d.YearOfGraduation==null ? null: d.YearOfGraduation,
                        AcademicSessionDate=d.AcademicSessionDate, 
                        AcademicSessionDate2=d.AcademicSessionDate2,
                        FullAcademicSession=c.AcademicSectionDate == null ? "" : c.AcademicSectionDate
                    });
        }
        public async Task<bool> AddOrUpdateESMAfAsync(EsmafData model)
        {
            int academicSession = int.Parse(model.AcademicSessionDate);
            int academicSession2 = int.Parse(model.AcademicSessionDate2);
            int yearOfEntry = int.Parse(model.YearOfEntry);
            int yearOfGraduation = int.Parse(model.YearOfGraduation);
            using (var saveData= _context)
            {
                bool result;
                if (model.Id<1)
                {

                    var data = new ESMAF
                    {
                        Surname = model.Surname,
                        Othernames = model.Othernames,
                        Gender = model.Gender,
                        PhoneNumber = model.PhoneNumber,
                        Email = model.Email,
                        Faculty = model.Faculty,
                        CourseOfStudy = model.CourseOfStudy,
                        UnitServed = model.UnitServed,
                        HouseAddress = model.HouseAddress,
                        YearOfEntry = yearOfEntry,
                        YearOfGraduation = yearOfGraduation,
                        AcademicSessionDate=academicSession,
                        AcademicSessionDate2=academicSession2,
                        
                    };
                    saveData.eSMAF.Add(data);
                    //result = await saveData.SaveChangesAsync() > 0;

                    var data2 = new PastExecutive // The of this capture is to gather all executive in one table.
                    {
                        SurnameExcos = model.Surname,
                        OthernameExcos = model.Othernames,
                        Gender = model.Gender,
                        Phone=model.PhoneNumber,
                        Email = model.Email,
                        Office = model.Office,
                        AcademicSectionDate = $"{academicSession}/{academicSession2}",
                        //EsmafId=model.Id
                        
                    };
                    saveData.pastExecutive.Add(data2);
               //     _ = await saveData.SaveChangesAsync() > 0;

                    if (model.Office == GetPastExecutive.BibleStudyCordinator.ToString())
                    {
                        var data3 = new PastBibleStudyCordinator
                        {
                            SurnameExcos = model.Surname,
                            OthernameExcos = model.Othernames,
                            Gender = model.Gender,
                            PhoneNumber = model.PhoneNumber,
                            Email = model.Email,
                            AcademicSectionDate = $"{academicSession}/{academicSession2}",
                        };
                        saveData.pastBibleStudyCordinators.Add(data3);
                      //  _ = await saveData.SaveChangesAsync() > 0;
                    }
                    else if (model.Office == GetPastExecutive.PrayerUnitCordinator.ToString())
                    {
                        var data4 = new PastPrayerUnitCordinator
                        {
                            SurnameExcos = model.Surname,
                            OthernameExcos = model.Othernames,
                            Gender = model.Gender,
                            PhoneNumber = model.PhoneNumber,
                            Email = model.Email,
                            AcademicSectionDate = $"{academicSession}/{academicSession2}",
                        };
                        saveData.pastPrayerUnitCordinator.Add(data4);
                       // _ = await saveData.SaveChangesAsync() > 0;
                    }
                    else if (model.Office == GetPastExecutive.ChoralUnitCordinator.ToString())
                    {
                        var data5 = new PastChoralUnitCordinator
                        {
                            SurnameExcos = model.Surname,
                            OthernameExcos = model.Othernames,
                            Gender = model.Gender,
                            PhoneNumber = model.PhoneNumber,
                            Email = model.Email,
                            AcademicSectionDate = $"{academicSession}/{academicSession2}",
                        };
                        saveData.pastChoralUnitCordinator.Add(data5);
                       // _ = await saveData.SaveChangesAsync() > 0;
                    }
                    else if (model.Office == GetPastExecutive.WelfareUnitCordinator.ToString())
                    {
                        var data6 = new PastWelfareUnitCordinator
                        {
                            SurnameExcos = model.Surname,
                            OthernameExcos = model.Othernames,
                            Gender = model.Gender,
                            PhoneNumber = model.PhoneNumber,
                            Email = model.Email,
                            AcademicSectionDate = $"{academicSession}/{academicSession2}",
                        };
                        saveData.pastWelfareUnitCordinator.Add(data6);
                       // _ = await saveData.SaveChangesAsync() > 0;
                    }
                    else if (model.Office == GetPastExecutive.DramaUnitCordinator.ToString())
                    {
                        var data7 = new PastDMECordinator
                        {
                            SurnameExcos = model.Surname,
                            OthernameExcos = model.Othernames,
                            Gender = model.Gender,
                            PhoneNumber = model.PhoneNumber,
                            Email = model.Email,
                            AcademicSectionDate = $"{academicSession}/{academicSession2}",
                        };
                        saveData.pastDMECordinator.Add(data7);
                       // _ = await saveData.SaveChangesAsync() > 0;
                    }
                    else if (model.Office == GetPastExecutive.TechnicalUnitCordinator.ToString())
                    {
                        var data8 = new PastTechnicalUnitCordinator
                        {
                            SurnameExcos = model.Surname,
                            OthernameExcos = model.Othernames,
                            Gender = model.Gender,
                            PhoneNumber = model.PhoneNumber,
                            Email = model.Email,
                            AcademicSectionDate = $"{academicSession}/{academicSession2}",
                        };
                        saveData.pastTechnicalUnitCordinator.Add(data8);
                       // _ = await saveData.SaveChangesAsync() > 0;
                    }
                    else if (model.Office == GetPastExecutive.UsheringUnitCordinator.ToString())
                    {
                        var data8 = new PastUsheringUnitCordinator
                        {
                            SurnameExcos = model.Surname,
                            OthernameExcos = model.Othernames,
                            Gender = model.Gender,
                            PhoneNumber = model.PhoneNumber,
                            Email = model.Email,
                            AcademicSectionDate = $"{academicSession}/{academicSession2}",
                        };
                        saveData.pastUsheringUnitCordinator.Add(data8);
                       // _ = await saveData.SaveChangesAsync() > 0;
                    }
                    else if (model.Office == GetPastExecutive.PublicityUnitCordinator.ToString())
                    {
                        var data9 = new PastPublicityUnitCordinator
                        {
                            SurnameExcos = model.Surname,
                            OthernameExcos = model.Othernames,
                            Gender = model.Gender,
                            PhoneNumber = model.PhoneNumber,
                            Email = model.Email,
                            AcademicSectionDate = $"{academicSession}/{academicSession2}",
                        };
                        saveData.pastPublicityUnitCordinator.Add(data9);
                        //_ = await saveData.SaveChangesAsync() > 0;
                    }
                    else if (model.Office == GetPastExecutive.TransportUnitCordinator.ToString())
                    {
                        var data10 = new PastTransportUnitCordinator
                        {
                            SurnameExcos = model.Surname,
                            OthernameExcos = model.Othernames,
                            Gender = model.Gender,
                            PhoneNumber = model.PhoneNumber,
                            Email = model.Email,
                            AcademicSectionDate = $"{academicSession}/{academicSession2}",
                        };
                        saveData.pastTransportUnitCordinator.Add(data10);
                        //_ = await saveData.SaveChangesAsync() > 0;
                    }
                    else if (model.Office == GetPastExecutive.DramaUnitCordinator.ToString())
                    {
                        var data11 = new PastDramaUnitCordinator
                        {
                            SurnameExcos = model.Surname,
                            OthernameExcos = model.Othernames,
                            Gender = model.Gender,
                            PhoneNumber = model.PhoneNumber,
                            Email = model.Email,
                            AcademicSectionDate = $"{academicSession}/{academicSession2}",
                        };
                        saveData.pastDramaUnitCordinator.Add(data11);
                        //_ = await saveData.SaveChangesAsync() > 0;
                    }
                    else if (model.Office == GetPastExecutive.Treasurer.ToString())
                    {
                        var data12 = new PastTreasurer
                        {
                            SurnameExcos = model.Surname,
                            OthernameExcos = model.Othernames,
                            Gender = model.Gender,
                            PhoneNumber = model.PhoneNumber,
                            Email = model.Email,
                            AcademicSectionDate = $"{academicSession}/{academicSession2}",
                        };
                        saveData.pastTreasurer.Add(data12);
                       // _ = await saveData.SaveChangesAsync() > 0;
                    }
                    
                    else if (model.Office == GetPastExecutive.Secretary.ToString())
                    {
                        var data13 = new PastSecretary
                        {
                            SurnameExcos = model.Surname,
                            OthernameExcos = model.Othernames,
                            Gender = model.Gender,
                            PhoneNumber = model.PhoneNumber,
                            Email = model.Email,
                            AcademicSectionDate = $"{academicSession}/{academicSession2}",
                        };
                        saveData.pastSecretary.Add(data13);
                       // _ = await saveData.SaveChangesAsync() > 0;
                    }
                    else if (model.Office == GetPastExecutive.President.ToString())
                    {

                        var data14 = new PastPresident
                        {
                            SurnameExcos = model.Surname,
                            OthernameExcos = model.Othernames,
                            Gender = model.Gender,
                            PhoneNumber = model.PhoneNumber,
                            Email = model.Email,
                            AcademicSectionDate = $"{academicSession}/{academicSession2}",
                        };
                        saveData.pastPresident.Add(data14);
                        
                    }
                   result = await saveData.SaveChangesAsync() > 0;
                }
                else
                {
                    if (model.Office ==GetPastExecutive.President.ToString()) 
                    {
                        var preData = _context.pastExecutive.Find(model.Id);
                        if (preData != null)
                        {
                            preData.SurnameExcos = model.Surname;
                            preData.SurnameExcos = model.Othernames;
                            preData.AcademicSectionDate = $"{model.AcademicSessionDate}/{model.AcademicSessionDate2}";
                            _ = saveData.Update(preData);
                            _ = await saveData.SaveChangesAsync();
                        }
                    }
                    var esmaf = _context.eSMAF.Find(model.Id);
                    if (esmaf == null)
                    
                    {
                        throw new("Not Found");
                    }
                    esmaf.Gender = model.Gender;
                    esmaf.Othernames = model.Othernames;
                    esmaf.Surname = model.Surname;
                    esmaf.PhoneNumber = model.PhoneNumber;
                    esmaf.CourseOfStudy = model.CourseOfStudy;
                    esmaf.Email = model.Email;
                    esmaf.Faculty = model.Faculty;
                    esmaf.CourseOfStudy = model.CourseOfStudy;
                    esmaf.HouseAddress = model.HouseAddress;
                    esmaf.YearOfEntry = yearOfEntry;
                    esmaf.YearOfGraduation = yearOfGraduation;
                    esmaf.UnitServed = model.UnitServed;
                    esmaf.AcademicSessionDate = academicSession;
                    esmaf.AcademicSessionDate2 = academicSession2;

                    result = await saveData.SaveChangesAsync()>0 ;

                }
                
                
                return result;
             }
             
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
                        Photo = s.Photo == null ? "" : s.Photo,
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

        public Task AddUpdateESMAfAsync<T>(T pastExecutiveData)
        {
            throw new NotImplementedException();
        }
             
    }
}

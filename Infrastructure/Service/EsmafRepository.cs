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

namespace Infrastructure.Service
{
    public class EsmafRepository : IEsmafRepository
    {
        private readonly ESMContext _context;
        private readonly IHostingEnvironment _environment;
        public EsmafRepository(ESMContext context, IHostingEnvironment environment)
        {
            _context = context;
            this._environment = environment;
        }
        public IQueryable<ESMAFDTO> ListAllEsmafAsync()
        {
            return (from d in _context.eSMAF
                        // from c in _context.pastExecutive.Where(x=>d.Surname==x.SurnameExcos && x.OthernameExcos==d.Othernames && x.Gender==d.Gender)
                    join c in _context.pastExecutive on d.Id equals c.EsmafId
                    select new ESMAFDTO
                    {
                        Id = d.Id,
                        Surname = d.Surname == null ? "" : d.Surname,
                        Othernames = d.Othernames == null ? "" : d.Othernames,
                        Gender = d.Gender == null ? "" : d.Gender,
                        UnitServed = d.UnitServed == null ? "" : d.UnitServed,
                        Office = c.Office == null ? "" : c.Office,
                        Email = d.Email == null ? "" : d.Email,
                        HouseAddress = d.HouseAddress == null ? "" : d.HouseAddress,
                        PhoneNumber = d.PhoneNumber == null ? "" : d.PhoneNumber,
                        CourseOfStudy = d.CourseOfStudy == null ? "" : d.CourseOfStudy,
                        YearOfEntry = d.YearOfEntry == null ? null : d.YearOfEntry,
                        YearOfGraduation = d.YearOfGraduation == null ? null : d.YearOfGraduation,
                        AcademicSessionDate = d.AcademicSessionDate,
                        AcademicSessionDate2 = d.AcademicSessionDate2,
                        FullAcademicSession = c.AcademicSectionDate == null ? "" : c.AcademicSectionDate
                    });
        }
        public async Task<bool> AddOrUpdateESMAfAsync(EsmafData model)
        {
            int academicSession = int.Parse(model.AcademicSessionDate);
            int academicSession2 = int.Parse(model.AcademicSessionDate2);
            int yearOfEntry = int.Parse(model.YearOfEntry);
            int yearOfGraduation = int.Parse(model.YearOfGraduation);
            using (var saveData = _context)
            {
                bool result;
                if (model.Id < 1)
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
                        AcademicSessionDate = academicSession,
                        AcademicSessionDate2 = academicSession2
                    };
                    saveData.eSMAF.Add(data);
                    result = await _context.SaveChangesAsync() > 0;
                    var data2 = new PastExecutive // The of this capture is to gather all executive in one table.
                    {
                        SurnameExcos = model.Surname,
                        OthernameExcos = model.Othernames,
                        Gender = model.Gender,
                        Phone = model.PhoneNumber,
                        Email = model.Email,
                        Office = model.Office,
                        EsmafId = data.Id.Value,
                        AcademicSectionDate = $"{academicSession}/{academicSession2}"
                    };
                    saveData.pastExecutive.Add(data2);
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
                            EsmafId = data.Id.Value,
                        };
                        saveData.pastBibleStudyCordinators.Add(data3);
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
                            EsmafId = data.Id.Value,
                        };
                        saveData.pastPrayerUnitCordinator.Add(data4);
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
                            EsmafId = data.Id.Value,
                        };
                        saveData.pastChoralUnitCordinator.Add(data5);
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
                            EsmafId = data.Id.Value,
                        };
                        saveData.pastWelfareUnitCordinator.Add(data6);
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
                            EsmafId = data.Id.Value,
                        };
                        saveData.pastDMECordinator.Add(data7);
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
                            EsmafId = data.Id.Value,
                        };
                        saveData.pastTechnicalUnitCordinator.Add(data8);
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
                            EsmafId = data.Id.Value,
                        };
                        saveData.pastUsheringUnitCordinator.Add(data8);
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
                            EsmafId = data.Id.Value,
                        };
                        saveData.pastPublicityUnitCordinator.Add(data9);
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
                            EsmafId = data.Id.Value,
                        };
                        saveData.pastTransportUnitCordinator.Add(data10);
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
                            EsmafId = data.Id.Value,
                        };
                        saveData.pastDramaUnitCordinator.Add(data11);
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
                            EsmafId = data.Id.Value,
                        };
                        saveData.pastTreasurer.Add(data12);
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
                            EsmafId = data.Id.Value,
                        };
                        saveData.pastSecretary.Add(data13);
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
                            EsmafId = data.Id.Value,
                        };
                        saveData.pastPresident.Add(data14);
                    }
                    result = await saveData.SaveChangesAsync() > 0;
                }
                else
                {
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
                    result = await saveData.SaveChangesAsync() > 0;

                    var pasExcutive = _context.pastExecutive.Find(model.Id);
                    if (pasExcutive != null)
                                 
                    pasExcutive.AcademicSectionDate = $"{academicSession}/{academicSession2}";
                    pasExcutive.Office = model.Office;
                    pasExcutive.SurnameExcos = model.Surname;
                    pasExcutive.OthernameExcos = model.Othernames;
                    pasExcutive.Gender = model.Gender;
                    pasExcutive.Email = model.Email;
                    pasExcutive.Phone = model.PhoneNumber;
                    result = await saveData.SaveChangesAsync() > 0;

                    var prayerCord = _context.pastPrayerUnitCordinator.Find(model.Id);
                    if (prayerCord != null)
                    {
                        prayerCord.Email = model.Email;
                        prayerCord.SurnameExcos = model.Surname;
                        prayerCord.OthernameExcos = model.Othernames;
                        prayerCord.PhoneNumber = model.PhoneNumber;
                        prayerCord.AcademicSectionDate = $"{academicSession}/{academicSession2}";
                        prayerCord.PhoneNumber = model.PhoneNumber;
                        result = await saveData.SaveChangesAsync() > 0;
                    }

                    var choralCord = _context.pastChoralUnitCordinator.Find(model.Id);
                    if (choralCord != null)
                    {
                        choralCord.Email = model.Email;
                        choralCord.SurnameExcos = model.Surname;
                        choralCord.OthernameExcos = model.Othernames;
                        choralCord.PhoneNumber = model.PhoneNumber;
                        choralCord.AcademicSectionDate = $"{academicSession}/{academicSession2}";
                        choralCord.PhoneNumber = model.PhoneNumber;
                        result = await saveData.SaveChangesAsync() > 0;
                    }

                    var bibleCord = _context.pastBibleStudyCordinators.Find(model.Id);
                    if (bibleCord != null)
                    {
                        bibleCord.Email = model.Email;
                        bibleCord.SurnameExcos = model.Surname;
                        bibleCord.OthernameExcos = model.Othernames;
                        bibleCord.PhoneNumber = model.PhoneNumber;
                        bibleCord.AcademicSectionDate = $"{academicSession}/{academicSession2}";
                        bibleCord.PhoneNumber = model.PhoneNumber;
                        result = await saveData.SaveChangesAsync() > 0;
                    }

                    var dMECord = _context.pastDMECordinator.Find(model.Id);
                    if (dMECord != null)
                    {
                        dMECord.Email = model.Email;
                        dMECord.SurnameExcos = model.Surname;
                        dMECord.OthernameExcos = model.Othernames;
                        dMECord.PhoneNumber = model.PhoneNumber;
                        dMECord.AcademicSectionDate = $"{academicSession}/{academicSession2}";
                        dMECord.PhoneNumber = model.PhoneNumber;
                        result = await saveData.SaveChangesAsync() > 0;
                    }

                    var dramaCord = _context.pastDramaUnitCordinator.Find(model.Id);
                    if (dramaCord != null)
                    {
                        dramaCord.Email = model.Email;
                        dramaCord.SurnameExcos = model.Surname;
                        dramaCord.OthernameExcos = model.Othernames;
                        dramaCord.PhoneNumber = model.PhoneNumber;
                        dramaCord.AcademicSectionDate = $"{academicSession}/{academicSession2}";
                        dramaCord.PhoneNumber = model.PhoneNumber;
                        result = await saveData.SaveChangesAsync() > 0;
                    }

                    var publCord = _context.pastPublicityUnitCordinator.Find(model.Id);
                    if (publCord != null)
                    {
                        publCord.Email = model.Email;
                        publCord.SurnameExcos = model.Surname;
                        publCord.OthernameExcos = model.Othernames;
                        publCord.PhoneNumber = model.PhoneNumber;
                        publCord.AcademicSectionDate = $"{academicSession}/{academicSession2}";
                        publCord.PhoneNumber = model.PhoneNumber;
                        result = await saveData.SaveChangesAsync() > 0;
                    }

                    var techCord = _context.pastTechnicalUnitCordinator.Find(model.Id);
                    if (techCord != null)
                    {
                        techCord.Email = model.Email;
                        techCord.SurnameExcos = model.Surname;
                        techCord.OthernameExcos = model.Othernames;
                        techCord.PhoneNumber = model.PhoneNumber;
                        techCord.AcademicSectionDate = $"{academicSession}/{academicSession2}";
                        techCord.PhoneNumber = model.PhoneNumber;
                        result = await saveData.SaveChangesAsync() > 0;
                    }

                    var transportCord = _context.pastTransportUnitCordinator.Find(model.Id);
                    if (transportCord != null)
                    {
                        transportCord.Email = model.Email;
                        transportCord.SurnameExcos = model.Surname;
                        transportCord.OthernameExcos = model.Othernames;
                        transportCord.PhoneNumber = model.PhoneNumber;
                        transportCord.AcademicSectionDate = $"{academicSession}/{academicSession2}";
                        transportCord.PhoneNumber = model.PhoneNumber;
                        result = await saveData.SaveChangesAsync() > 0;
                    }

                    var usheringCord = _context.pastUsheringUnitCordinator.Find(model.Id);
                    if (usheringCord != null)
                    {
                        usheringCord.Email = model.Email;
                        usheringCord.SurnameExcos = model.Surname;
                        usheringCord.OthernameExcos = model.Othernames;
                        usheringCord.PhoneNumber = model.PhoneNumber;
                        usheringCord.AcademicSectionDate = $"{academicSession}/{academicSession2}";
                        usheringCord.PhoneNumber = model.PhoneNumber;
                        result = await saveData.SaveChangesAsync() > 0;
                    }

                    var welfareCord = _context.pastWelfareUnitCordinator.Find(model.Id);
                    if (welfareCord != null)
                    {
                        welfareCord.Email = model.Email;
                        welfareCord.SurnameExcos = model.Surname;
                        welfareCord.OthernameExcos = model.Othernames;
                        welfareCord.PhoneNumber = model.PhoneNumber;
                        welfareCord.AcademicSectionDate = $"{academicSession}/{academicSession2}";
                        welfareCord.PhoneNumber = model.PhoneNumber;
                        result = await saveData.SaveChangesAsync() > 0;
                    }
                }

                return result;
            }

        }


        public Task AddUpdateESMAfAsync<T>(T pastExecutiveData)
        {
            throw new NotImplementedException();
        }

    }
}

using DataContextStructure;
using DataStructure.Entites;
using DataStructure.ViewModel;
using Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
    public class GeneralMemberRepository : IGeneralMemberRepository
    {
        private readonly ESMContext _context;
        public GeneralMemberRepository( ESMContext context)
        {
            this._context = context;
        }
        public async Task<bool> AddOrUpdateGeneralMember(GeneralMemberData model)
        {
            bool result;

            var yJoindate = new DateTime();
            if (!string.IsNullOrEmpty(model.YearJoinESM))
            {
                var splitDateYearJoin = model.YearJoinESM.Split('/');
                yJoindate = new DateTime(int.Parse(splitDateYearJoin[2]), int.Parse(splitDateYearJoin[0]), int.Parse(splitDateYearJoin[1]));
            }
            if (yJoindate.Year > DateTime.UtcNow.Year)
            {
                throw new($"You cannot join ESM in year {yJoindate.Year}. Please select correct date.");
            }

            var yOfEntry = new DateTime();
            if (!string.IsNullOrEmpty(model.YearOfEntry))
            {
                var splitYearOfEntry = model.YearOfEntry.Split('/');
                yOfEntry = new DateTime(int.Parse(splitYearOfEntry[2]), int.Parse(splitYearOfEntry[0]), int.Parse(splitYearOfEntry[1]));
            }
            
            var yOG = new DateTime();
            if (!string.IsNullOrEmpty(model.YearOfGraduation))
            {
                var splitYOG = model.YearOfGraduation.Split('/');
                yOG = new DateTime(int.Parse(splitYOG[2]), int.Parse(splitYOG[0]), int.Parse(splitYOG[1]));
            }

            var dob = new DateTime();
            if (!string.IsNullOrEmpty(model.DateOfBirth))
            {
                var splitDob = model.DateOfBirth.Split('/');
                dob = new DateTime(int.Parse(splitDob[2]), int.Parse(splitDob[0]), int.Parse(splitDob[1]));
            }
            
            if (yOfEntry.Year > DateTime.UtcNow.Year || yOfEntry.Year == yOG.Year || yOfEntry.Year == dob.Year)
            {
                throw new($"Your year of entry cannot be in the year {yOfEntry.Year}. Please input correct date");
            }
            if (dob.Year>DateTime.Now.Year|| dob.Year == yOfEntry.Year || dob.Year==yOG.Year)
            {
                throw new($"Your date of birth cannot be in the year {dob.Year}. Please input correct date");
            }
            if (yOG.Year<DateTime.UtcNow.Year || yOG.Year==yOfEntry.Year || yOG.Year==yJoindate.Year || yOG.Year==dob.Year)
            {
                throw new($"Your year of graduation cannot be in the year {yOG.Year}. Please input correct date");
            }
            if (yJoindate.Year==dob.Year || yJoindate.Year> DateTime.UtcNow.Year || yJoindate.Year==yOG.Year)
            {
                throw new($"You cannot join ESM in year {yJoindate.Year}. Please input correct date");
            }
            if (yJoindate.Year==DateTime.UtcNow.Year)
            {
                if (yJoindate.Month==DateTime.UtcNow.Month)
                {
                    if (yJoindate.Day == DateTime.UtcNow.Day) { }
                    else if (yJoindate.Day > DateTime.UtcNow.Day) { throw new($" You cannot join ESM on this future day {yJoindate.Day}. Please input correct date"); }
                }
            }
            if (dob.Year - DateTime.Now.Year < 14)
            {
                var yr = DateTime.Now.Year - dob.Year;
                if (yr <= 1)
                {
                    throw new($"{yr} year old! Please select correct date of birth");
                }
                throw new($"{yr} years old! Please select correct date of birth");
            }
            if (model.Id < 1)
            {
                var data = new GeneralMember
                {
                    Surname = model.Surname,
                    Firstname = model.Firstname,
                    Othername = model.Othername,
                    Gender = model.Gender,
                    PhoneNumber = model.PhoneNumber,
                    Email = model.Email,
                    Lga=model.LGA,
                    StateOfOrigin = model.StateOfOrigin,
                    SocialMediaAddress = model.SocialMediaAddress,
                    Ambition = model.Ambition,
                    CourseOfStudy = model.CourseOfStudy,
                    Faculty = model.Faculty,
                    HouseAddress = model.HouseAddress,
                    HostelAddress = model.HostelAddress,
                    YearJoinESM = yJoindate,
                    YearOfEntry = yOfEntry,
                    YearOfGraduation=yOG,
                    DateOfBirth=dob
                };
                _context.generalMember.Add(data);
                result = await _context.SaveChangesAsync() > 0;
            }
            else 
            {
                var generalMemberData=_context.generalMember.Find(model.Id);
                if (generalMemberData != null) 
                {
                    generalMemberData.Surname=model.Surname;
                    generalMemberData.Firstname=model.Firstname;
                    generalMemberData.Othername=model.Othername;    
                    generalMemberData.Gender=model.Gender;
                    generalMemberData.PhoneNumber=model.PhoneNumber;    
                    generalMemberData.Email=model.Email;
                    generalMemberData.StateOfOrigin = model.StateOfOrigin;
                    generalMemberData.Lga = model.LGA;
                    generalMemberData.HostelAddress=model.HostelAddress;
                    generalMemberData.HouseAddress=model.HouseAddress;
                    generalMemberData.SocialMediaAddress=model.SocialMediaAddress;
                    generalMemberData.Ambition = model.Ambition;
                    generalMemberData.CourseOfStudy=model.CourseOfStudy;    
                    generalMemberData.Faculty=model.Faculty;
                    generalMemberData.YearJoinESM=yJoindate;
                    generalMemberData.YearOfEntry=yOfEntry;
                    generalMemberData.YearOfGraduation=yOG;
                    generalMemberData.DateOfBirth =dob;
                }
                result = await _context.SaveChangesAsync() > 0;
            }
            return result;
        }

        public IQueryable<GeneralMemberDTO> ListAllGeneralMember()
        {
            return(from s in _context.generalMember select new GeneralMemberDTO{ 
            Id=s.Id,
            Surname = s.Surname==null? "" :s.Surname,
            Firstname=s.Firstname== null? "": s.Firstname,
            Othername=s.Othername==null?"":s.Othername,
            Gender=s.Gender==null? "":s.Gender,
            PhoneNumber=s.PhoneNumber==null? "":s.PhoneNumber,
            HostelAddress=s.HostelAddress==null? "": s.HostelAddress,
            HouseAddress=s.HouseAddress==null? "": s.HouseAddress,
            SocialMediaAddress=s.SocialMediaAddress==null?"":s.SocialMediaAddress,
            LGA=s.Lga==null? "":s.Lga,
            StateOfOrigin=s.StateOfOrigin==null?"":s.StateOfOrigin,
            Email=s.Email==null? "": s.Email,
            CourseOfStudy=s.CourseOfStudy==null? "":s.CourseOfStudy,
            Ambition=s.Ambition==null?"":s.Ambition,
            Faculty=s.Faculty==null? "": s.Faculty,
            YearJoinESM=s.YearJoinESM==null? null:s.YearJoinESM,
            YearOfEntry=s.YearOfEntry==null? null:s.YearOfEntry,
            YearOfGraduation=s.YearOfGraduation==null? null:s.YearOfGraduation,
            DateOfBirth=s.DateOfBirth ==null? null:s.DateOfBirth,

            });
        }
    }
}

using DataContextStructure;
using DataStructure.Entites;
using DataStructure.ViewModel;
using Infrastructure.Interface;
using ESMIlWebApp.Ultilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
    public class TestimonyRepository : ITestimonyRepository
    {
        private readonly ESMContext _context;
         public TestimonyRepository(ESMContext context) 
        {
           this._context = context;
        }

        public async Task<bool> AddOrUpdateTestimony(TestimonyData model)
        {
            bool result;
            //DateTime? bdate = null;
            var bdate = new DateTime();
            if (!string.IsNullOrEmpty(model.TestimonyDate))
            {
                var splitDateOfTestimony = model.TestimonyDate.Split('/');
                bdate = new DateTime(int.Parse(splitDateOfTestimony[2]), int.Parse(splitDateOfTestimony[0]), int.Parse(splitDateOfTestimony[1]));
            }

            if (model.Id < 1)
            {

                var bData = new Testimony
                {
                    Surname = model.Surname,
                    Firstname = model.Firstname,
                    Department = model.Department,
                    TheGoodNews = model.TheGoodNews,
                    TestimonyDate = bdate
                };
                _context.testimony.Add(bData);
                result = await _context.SaveChangesAsync() > 0;
            }
            else
            {
                var testimonyData = _context.testimony.Find(model.Id);

                if (testimonyData is null)
                {
                    throw new("Not found");
                }
                testimonyData.Surname = model.Surname;
                testimonyData.Firstname = model.Firstname;
                testimonyData.Department = model.Department;
                testimonyData.TheGoodNews = model.TheGoodNews;
                testimonyData.TestimonyDate = bdate;

                result = await _context.SaveChangesAsync() > 0;
            }
            return result;
        }

        public async Task<bool> AddTestimonyNumberToDisplay(TestimonyNumberData model)
        {
            int no = int.Parse(model.Number);
            bool result= true;

          var del=  _context.testimonyNumber.FirstOrDefault();
            if (model.Id < 1)
            {

                var bData = new TestimonyNumber
                {
                    Number =no,
                };
                _context.testimonyNumber.Add(bData);
                _context.Remove(del);
                result = await _context.SaveChangesAsync() > 0;
            }
            
            return result;
        }

        public IQueryable GetTestimonyToDisplay(int c)
        {
            
          var no=  _context.testimony.OrderByDescending(s=>s.Id).Take(c);
            return no;
        }

        public IQueryable<TestimonyDTO> ListAllTestimony()
        {
            return (from s in _context.testimony
                    select new TestimonyDTO
                    {   Id=s.Id==null ? 0 : s.Id,
                        Surname = s.Surname == null ? "" : s.Surname,
                        Firstname = s.Firstname == null ? "" : s.Firstname,
                        Department = s.Department == null ? "" : s.Department,
                        TheGoodNews = s.TheGoodNews == null ? "" : s.TheGoodNews,
                        TestimonyDate = s.TestimonyDate == null ? null : s.TestimonyDate,
                    });
        }

        public IQueryable TestimonyNumberToDisplay()
        {
         var no=   _context.testimonyNumber.OrderByDescending(s=>s.Id).FirstOrDefault();
            int no2 = (int)TestimonyNumberEnum.Two;
            int no3=  (int)TestimonyNumberEnum.Three;
            int no4 = (int)TestimonyNumberEnum.Four;
            int no5 = (int)TestimonyNumberEnum.Five;
            if (no != null)
                if (no.Number ==no2) 
                {
                 var two=   GetTestimonyToDisplay(no2); 
                    return two;
                }
                else if (no.Number ==no3)
                {
                var three=   GetTestimonyToDisplay(3);
                    return three;
                }
                else if(no.Number == no4) 
                {
                  var four=  GetTestimonyToDisplay(4);
                    return four;
                }
                else if (no.Number==no5)
                {
                  var five=  GetTestimonyToDisplay(5);
                    return five;
                };
            return TestimonyNumberToDisplay();
        }
    }
}

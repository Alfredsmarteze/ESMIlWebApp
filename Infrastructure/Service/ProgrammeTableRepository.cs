using DataContextStructure;
using DataStructure.Entites;
using DataStructure.ViewModel;
using Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Service
{
    public class ProgrammeTableRepository : IProgrammeTableRepository
    {
        private readonly ESMContext _context;
        public ProgrammeTableRepository(ESMContext context) 
        {
        this._context = context;
        }
        public async Task<bool> AddOrUpdateProgrammeTableAsync(ProgrammeTableData programmeTableData)
        {
            bool result=true;

          var splitProgrammeDate = programmeTableData.ProgrammeDate.Split('/');
          var  splitDate = new DateTime(int.Parse(splitProgrammeDate[2]), int.Parse(splitProgrammeDate[0]), int.Parse(splitProgrammeDate[1]));
            if (programmeTableData.Id < 0)
            {
                var addData = new ProgramTable
                {
                    Speaker = programmeTableData.Speaker,
                    Cordinator = programmeTableData.Cordinator,
                    ProgramDate = splitDate,
                    Programme=programmeTableData.Programme,
                    Note = programmeTableData.Note,
                };
                _context.Add(addData);
                result = await _context.SaveChangesAsync() > 0;
            }
            else {
                var getId = _context.programTable.Find(programmeTableData.Id);
                if (getId == null) { throw new("Not Found");}
                {
                    getId.Note=programmeTableData.Note;
                    getId.Speaker=programmeTableData.Speaker;
                    getId.Cordinator=programmeTableData.Cordinator;
                    getId.Programme = programmeTableData.Programme;
                    getId.ProgramDate = splitDate;
                    result = await _context.SaveChangesAsync() > 0;    
                }
                    
            }
            return result;
        }

        public IQueryable<ProgrammeTableDTO> GetAllProgrammeTableAsync()
        {
            return (from s in _context.programTable
                    select new ProgrammeTableDTO
                    {
                        Speaker=s.Speaker==null ? "" : s.Speaker,
                        Cordinator=s.Cordinator==null ? "" :s.Cordinator,
                        Programme=s.Programme==null ? "" : s.Programme,
                        Note=s.Note==null ? "": s.Note,
                        ProgrammeDate=s.ProgramDate==null ? null:s.ProgramDate,
                    }); 
        }
    }
}

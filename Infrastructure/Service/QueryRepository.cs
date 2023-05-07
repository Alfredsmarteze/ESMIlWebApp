using DataContextStructure;
using Infrastructure.Interface;
using Microsoft.AspNetCore.Server.IIS.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static DataStructure.ViewModel.EsmafData;

namespace Infrastructure.Service
{
    public class QueryRepository : IQueryRepository
    {
        private readonly ESMContext _context;
        public QueryRepository(ESMContext context ) {
        this._context = context;
        }
        public string GetId(int id)
        {
            var res = _context.eSMAF.Where(s=>s.Id==id).FirstOrDefault();
            if (res != null) 
            { 
                if (res.UnitServed == GetPastExecutive.President.ToString()) 
                {
                  var re = _context.pastPresident.Select(s => s.AcademicSectionDate).FirstOrDefault();
                    if (re != null) 
                    {
                        return re;
                    }
                }
                else if (res.UnitServed == GetPastExecutive.BibleStudyCordinator.ToString())
                {
                    var re = _context.pastBibleStudyCordinators.Select(s => s.AcademicSectionDate).FirstOrDefault();
                    if (re != null)
                    {
                        return re;
                    }
                }
                else if(res.UnitServed == GetPastExecutive.ChoralUnitCordinator.ToString())
                {
                    var re = _context.pastChoralUnitCordinator.Select(s => s.AcademicSectionDate).FirstOrDefault();
                    if (re != null)
                    {
                        return re;
                    }
                }
                else if (res.UnitServed == GetPastExecutive.DMEUnitCordinator.ToString())
                {
                    var re = _context.pastDMECordinator.Select(s => s.AcademicSectionDate).FirstOrDefault();
                    if (re != null)
                    {
                        return re;
                    }
                }
                else if (res.UnitServed == GetPastExecutive.DramaUnitCordinator.ToString())
                {
                    var re = _context.pastDramaUnitCordinator.Select(s => s.AcademicSectionDate).FirstOrDefault();
                    if (re != null)
                    {
                        return re;
                    }
                }
                else if (res.UnitServed == GetPastExecutive.Secretary.ToString())
                {
                    var re = _context.pastSecretary.Select(s => s.AcademicSectionDate).FirstOrDefault();
                    if (re != null)
                    {
                        return re;
                    }
                }
                else if (res.UnitServed == GetPastExecutive.WelfareUnitCordinator.ToString())
                {
                    var re = _context.pastWelfareUnitCordinator.Select(s => s.AcademicSectionDate).FirstOrDefault();
                    if (re != null)
                    {
                        return re;
                    }
                }
                else if (res.UnitServed == GetPastExecutive.PrayerUnitCordinator.ToString())
                {
                    var re = _context.pastPrayerUnitCordinator.Select(s => s.AcademicSectionDate).FirstOrDefault();
                    if (re != null)
                    {
                        return re;
                    }
                }
                else if (res.UnitServed == GetPastExecutive.TechnicalUnitCordinator.ToString())
                {
                    var re = _context.pastTechnicalUnitCordinator.Select(s => s.AcademicSectionDate).FirstOrDefault();
                    if (re != null)
                    {
                        return re;
                    }
                }
                else if (res.UnitServed == GetPastExecutive.TransportUnitCordinator.ToString())
                {
                    var re = _context.pastTransportUnitCordinator.Select(s => s.AcademicSectionDate).FirstOrDefault();
                    if (re != null)
                    {
                        return re;
                    }
                }
                else if (res.UnitServed == GetPastExecutive.Treasurer.ToString())
                {
                    var re = _context.pastTreasurer.Select(s => s.AcademicSectionDate).FirstOrDefault();
                    if (re != null)
                    {
                        return re;
                    }
                }
                else if (res.UnitServed == GetPastExecutive.UsheringUnitCordinator.ToString())
                {
                    var re = _context.pastUsheringUnitCordinator.Select(s => s.AcademicSectionDate).FirstOrDefault();
                    if (re != null)
                    {
                        return re;
                    }
                }
            }
            throw new Exception("No record found");
        }
    }
}

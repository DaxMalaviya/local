using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectManagementDL;

namespace ProjectManagementBL
{
    public class AssignedModuleBL
    {
        public void InsertData(ModuleAssigned obj)
        {
            ProjectManagementSystemEntities ent = new ProjectManagementSystemEntities();
            ModuleAssigned objM = (from a in ent.ModuleAssigneds where a.TeamLeaderId == obj.TeamLeaderId && a.ModuleId == obj.ModuleId select a).FirstOrDefault();
            if (objM == null)
            {
                ent.ModuleAssigneds.AddObject(obj);
                ent.SaveChanges();
            }
        }

        public void deleteModuledata(int ID)
        {
            ProjectManagementSystemEntities ent = new ProjectManagementSystemEntities();
            ModuleAssigned obj = (from a in ent.ModuleAssigneds where a.Id == ID select a).FirstOrDefault();
            if (obj != null)
            {
                ent.ModuleAssigneds.DeleteObject(obj);
                ent.SaveChanges();
            }
        }

        public List<AssignModuleView> fillGrid()
        {
            ProjectManagementSystemEntities ent = new ProjectManagementSystemEntities();
            List<AssignModuleView> ModuleList = (from pa in ent.ModuleAssigneds
                                                 join cp in ent.Modules on pa.ModuleId equals cp.ModuleId
                                                 join em in ent.Employees on pa.TeamLeaderId equals em.EmpID
                                                 select new AssignModuleView
                                                 {
                                                     Id = pa.Id,
                                                     FirstName = em.FirstName,
                                                     LastName = em.LastName,
                                                     MiddelName = em.MiddelName,
                                                     TeamLeaderId = em.EmpID,
                                                     ModuleId = cp.ModuleId,
                                                     ModuleName = cp.ModuleName
                                                 }).ToList();
            return ModuleList;
        }

        public int GetModuleId(int Empid)
        {
            ProjectManagementSystemEntities ent = new ProjectManagementSystemEntities();
            ModuleAssigned obj = (from a in ent.ModuleAssigneds where a.TeamLeaderId == Empid select a).FirstOrDefault();
            return Convert.ToInt32(obj.ModuleId);
        }
    }
}


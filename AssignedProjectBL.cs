using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectManagementDL;

namespace ProjectManagementBL
{
    public class AssignedProjectBL
    {
        /// <summary>
        /// Inserts new project Assigned data.
        /// </summary>
        /// <param name="obj"></param>
        public void InsertData(ProjectAssigned obj)
        {
            ProjectManagementSystemEntities ent = new ProjectManagementSystemEntities();
            ProjectAssigned objp = (from a in ent.ProjectAssigneds where a.ProjectId == obj.ProjectId && a.ProjectManagerId == obj.ProjectManagerId select a).FirstOrDefault();
            if (objp == null)
            {
                //objp.ProjectId = obj.ProjectId;
                //objp.ProjectManagerId = obj.ProjectManagerId;

                ent.ProjectAssigneds.AddObject(obj);
                ent.SaveChanges();
            }
        }

        /// <summary>
        /// Retrive records for grid view.
        /// </summary>
        /// <returns></returns>
        public List<AssignProjectView> FillGrid()
        {
            ProjectManagementSystemEntities ent = new ProjectManagementSystemEntities();
            List<AssignProjectView> ProjectList = (from pa in ent.ProjectAssigneds
                                                   join cp in ent.ClientProjects on pa.ProjectId equals cp.ProjectId
                                                   join em in ent.Employees on pa.ProjectManagerId equals em.EmpID
                                                   select new AssignProjectView
                                                   {
                                                       Id = pa.Id,
                                                       FirstName = em.FirstName,
                                                       LastName = em.LastName,
                                                       MiddelName = em.MiddelName,
                                                       PrjectManagerId = em.EmpID,
                                                       ProjectId = cp.ProjectId,
                                                       ProjectName = cp.ProjectName
                                                   }).ToList();
            return ProjectList;
        }


        /// <summary>
        /// Getting projct Id used for project manager to display own projects.
        /// </summary>
        /// <param name="ProMID"></param>
        /// <returns></returns>
        public int getProjectId(int ProMID)
        {
            ProjectManagementSystemEntities ent = new ProjectManagementSystemEntities();
            ProjectAssigned obj = (from a in ent.ProjectAssigneds where a.ProjectManagerId == ProMID select a).FirstOrDefault();
            if (obj != null)
            {
                return Convert.ToInt32(obj.ProjectId);
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// To delete project data from the grid view.
        /// </summary>
        /// <param name="ID"></param>
        public void deleteProjectdata(int ID)
        {
            ProjectManagementSystemEntities ent = new ProjectManagementSystemEntities();
            ProjectAssigned obj = (from a in ent.ProjectAssigneds where a.Id == ID select a).FirstOrDefault();
            if (obj != null)
            {
                ent.ProjectAssigneds.DeleteObject(obj);
                ent.SaveChanges();
            }
        }
    }
}

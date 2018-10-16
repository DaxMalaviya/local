using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectManagementDL;

namespace ProjectManagementBL
{
    public class AssignedTaskBL
    {
        public class gridview
        {
            public int EmpId { get; set; }
            public int TaskId { get; set; }
            public string TaskName { get; set; }
            public string FirstName { get; set; }
            public string MiddelName { get; set; }
            public string LastName { get; set; }
        }

        //public class developergrid
        //{
        //    public int TaskId { get; set; }
        //    public string TaskName { get; set; }
        //    public string TaskDescription { get; set; }
        //    public string StartDate { get; set; }
        //    public string EndDate { get; set; }
        //}

        /// <summary>
        /// Fill GRID VIEW.
        /// </summary>
        /// <returns></returns>
        public List<gridview> fillGrid()
        {
            ProjectManagementSystemEntities ent = new ProjectManagementSystemEntities();
            List<gridview> obj = (from at in ent.TaskAssigneds
                                  join em in ent.Employees on at.EmpId equals em.EmpID
                                  join t in ent.Tasks on at.TaskId equals t.TaskId
                                  select new gridview
                                  {
                                      EmpId = at.EmpId ?? 0,
                                      TaskId = at.TaskId ?? 0,
                                      TaskName = t.TaskName,
                                      FirstName = em.FirstName,
                                      MiddelName = em.MiddelName,
                                      LastName = em.LastName,
                                  }).ToList();
            return obj;
        }

        /// <summary>
        /// Insert new Record.
        /// </summary>
        /// <param name="obj"></param>
        public void InsertData(TaskAssigned obj)
        {
            ProjectManagementSystemEntities ent = new ProjectManagementSystemEntities();
            TaskAssigned objT = (from a in ent.TaskAssigneds where a.EmpId == obj.EmpId && a.TaskId == obj.TaskId select a).FirstOrDefault();
            if (objT == null)
            {
                ent.TaskAssigneds.AddObject(obj);
                ent.SaveChanges();
            }
        }

        /// <summary>
        /// Deleting Record.
        /// </summary>
        /// <param name="id"></param>
        public void DeleteData(int id)
        {
            ProjectManagementSystemEntities ent = new ProjectManagementSystemEntities();
            TaskAssigned obj = (from a in ent.TaskAssigneds where a.TaskId == id select a).FirstOrDefault();
            if (obj != null)
            {
                ent.TaskAssigneds.DeleteObject(obj);
                ent.SaveChanges();
            }
        }

        //public List<developergrid> fillGridForDeveloper(int DID)
        //{
        //    ProjectManagementSystemEntities ent = new ProjectManagementSystemEntities();
        //    List<developergrid> obj = (from ta in ent.TaskAssigneds
        //                               join t in ent.Tasks on ta.TaskId equals t.TaskId
        //                               select new developergrid
        //                               {
        //                                   TaskId = t.TaskId,
        //                                   TaskName = t.TaskName,
        //                                   TaskDescription = t.TaskDescription,
        //                                   StartDate = Convert.ToString(t.StartDate),
        //                                   EndDate = Convert.ToString(t.EndDate),
        //                               }).ToList();
        //    return obj;
        //}


        public int GetTaskId(int DID)
        {
            ProjectManagementSystemEntities ent = new ProjectManagementSystemEntities();
            TaskAssigned obj = (from a in ent.TaskAssigneds where a.EmpId == DID select a).FirstOrDefault();
            return Convert.ToInt32(obj.TaskId);
        }
    }
}

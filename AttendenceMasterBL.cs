using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectManagementDL;

namespace ProjectManagementBL
{
    public class AttendenceMasterBL
    {
        /// <summary>
        /// Fill GridView of all employee Attendence in HR panel.
        /// </summary>
        /// <returns></returns>
        public List<AttendenceMaster> fillGrid(int id)
        {
            ProjectManagementSystemEntities ent = new ProjectManagementSystemEntities();
            List<AttendenceMaster> obj = (from a in ent.AttendenceMasters where a.EmpId == id select a).ToList();
            return obj;
        }

        public List<AttendenceMaster> fillAttendenceGridForAdmin()
        {
            ProjectManagementSystemEntities ent = new ProjectManagementSystemEntities();
            List<AttendenceMaster> obj = (from a in ent.AttendenceMasters select a).ToList();
            return obj;
        }

        /// <summary>
        /// Delete Attendence from the Attendence Grid view in HR Panel.
        /// </summary>
        /// <param name="id"></param>
        public void deleteAttendence(int id)
        {
            ProjectManagementSystemEntities ent = new ProjectManagementSystemEntities();
            AttendenceMaster obj = (from a in ent.AttendenceMasters where a.EmpId == id select a).FirstOrDefault();
            if (obj != null)
            {
                ent.AttendenceMasters.DeleteObject(obj);
                ent.SaveChanges();
            }
        }


        /// <summary>
        /// checking for Attendence button is visible or not.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int CheckForVisibility(int id)
        {
            ProjectManagementSystemEntities ent = new ProjectManagementSystemEntities();
            int flag = 0;
            AttendenceMaster obj = (from a in ent.AttendenceMasters where a.EmpId == id orderby a.Month descending select a).FirstOrDefault();
            DateTime now = DateTime.Now;
            int date = Convert.ToDateTime(now.Date).Day;
            switch (date)
            {
                case 1:
                    if (obj.Day1 == null)
                        flag = 1;
                    else
                        flag = 0;
                    break;
                case 2:
                    if (obj.Day2 == null)
                        flag = 1;
                    else
                        flag = 0;
                    break;
                case 3:
                    if (obj.Day3 == null)
                        flag = 1;
                    else
                        flag = 0;
                    break;
                case 4:
                    if (obj.Day4 == null)
                        flag = 1;
                    else
                        flag = 0;
                    break;
                case 5:
                    if (obj.Day5 == null)
                        flag = 1;
                    else
                        flag = 0;
                    break;
                case 6:
                    if (obj.Day6 == null)
                        flag = 1;
                    else
                        flag = 0;
                    break;
                case 7:
                    if (obj.Day7 == null)
                        flag = 1;
                    else
                        flag = 0;
                    break;
                case 8:
                    if (obj.Day8 == null)
                        flag = 1;
                    else
                        flag = 0;
                    break;
                case 9:
                    if (obj.Day9 == null)
                        flag = 1;
                    else
                        flag = 0;
                    break;
                case 10:
                    if (obj.Day10 == null)
                        flag = 1;
                    else
                        flag = 0;
                    break;
                case 11:
                    if (obj.Day11 == null)
                        flag = 1;
                    else
                        flag = 0;
                    break;
                case 12:
                    if (obj.Day12 == null)
                        flag = 1;
                    else
                        flag = 0;
                    break;
                case 13:
                    if (obj.Day13 == null)
                        flag = 1;
                    else
                        flag = 0;
                    break;
                case 14:
                    if (obj.Day14 == null)
                        flag = 1;
                    else
                        flag = 0;
                    break;
                case 15:
                    if (obj.Day15 == null)
                        flag = 1;
                    else
                        flag = 0;
                    break;
                case 16:
                    if (obj.Day16 == null)
                        flag = 1;
                    else
                        flag = 0;
                    break;
                case 17:
                    if (obj.Day17 == null)
                        flag = 1;
                    else
                        flag = 0;
                    break;
                case 18:
                    if (obj.Day18 == null)
                        flag = 1;
                    else
                        flag = 0;
                    break;
                case 19:
                    if (obj.Day19 == null)
                        flag = 1;
                    else
                        flag = 0;
                    break;
                case 20:
                    if (obj.Day20 == null)
                        flag = 1;
                    else
                        flag = 0;
                    break;
                case 21:
                    if (obj.Day21 == null)
                        flag = 1;
                    else
                        flag = 0;
                    break;
                case 22:
                    if (obj.Day22 == null)
                        flag = 1;
                    else
                        flag = 0;
                    break;
                case 23:
                    if (obj.Day23 == null)
                        flag = 1;
                    else
                        flag = 0;
                    break;
                case 24:
                    if (obj.Day24 == null)
                        flag = 1;
                    else
                        flag = 0;
                    break;
                case 25:
                    if (obj.Day25 == null)
                        flag = 1;
                    else
                        flag = 0;
                    break;
                case 26:
                    if (obj.Day26 == null)
                        flag = 1;
                    else
                        flag = 0;
                    break;
                case 27:
                    if (obj.Day27 == null)
                        flag = 1;
                    else
                        flag = 0;
                    break;
                case 28:
                    if (obj.Day28 == null)
                        flag = 1;
                    else
                        flag = 0;
                    break;
                case 29:
                    if (obj.Day29 == null)
                        flag = 1;
                    else
                        flag = 0;
                    break;
                case 30:
                    if (obj.Day30 == null)
                        flag = 1;
                    else
                        flag = 0;
                    break;
                case 31:
                    if (obj.Day31 == null)
                        flag = 1;
                    else
                        flag = 0;
                    break;
            }
            return flag;
        }


        /// <summary>
        /// Take Attendence of Each employeee on button click 
        /// </summary>
        /// <param name="id"></param>
        public void TakeAttendence(int id, DateTime loginTime)
        {
            ProjectManagementSystemEntities ent = new ProjectManagementSystemEntities();
            AttendenceMaster obj = (from a in ent.AttendenceMasters where a.EmpId == id orderby a.Month descending select a).FirstOrDefault();
            if (obj != null)
            {
                DateTime now = DateTime.Now;
                int month = now.Month;
                if (obj.Month == month)
                {
                    DayEntry(obj, ent, 1);
                }
                else
                {
                    DateTime now1 = DateTime.Now;
                    ProjectManagementSystemEntities ent1 = new ProjectManagementSystemEntities();
                    AttendenceMaster objAttend = new AttendenceMaster();
                    objAttend.EmpId = id;
                    objAttend.LoginTime = loginTime;
                    objAttend.Month = now1.Month;
                    objAttend.Year = now1.Year;
                    DayEntry(objAttend, ent1, 0);
                }
            }
            else
            {
                DateTime now1 = DateTime.Now;
                ProjectManagementSystemEntities ent1 = new ProjectManagementSystemEntities();
                AttendenceMaster objAttend = new AttendenceMaster();
                objAttend.EmpId = id;
                objAttend.LoginTime = loginTime;
                objAttend.Month = now1.Month;
                objAttend.Year = now1.Year;
                DayEntry(objAttend, ent1, 0);
            }
        }


        /// <summary>
        /// Performs Day Entry for All employees.
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="ent"></param>
        /// <param name="flag"></param>
        public void DayEntry(AttendenceMaster obj, ProjectManagementSystemEntities ent, int flag)
        {
            DateTime now = DateTime.Now;
            int date = Convert.ToDateTime(now.Date).Day;
            switch (date)
            {
                case 1:
                    if (flag == 1)
                    {
                        obj.Day1 = true;
                        ent.SaveChanges();
                    }
                    else if (flag == 0)
                    {
                        obj.Day1 = true;
                        ent.AttendenceMasters.AddObject(obj);
                        ent.SaveChanges();
                    }
                    break;
                case 2:
                    if (flag == 1)
                    {
                        obj.Day2 = true;
                        ent.SaveChanges();
                    }
                    else if (flag == 0)
                    {
                        obj.Day2 = true;
                        ent.AttendenceMasters.AddObject(obj);
                        ent.SaveChanges();
                    }
                    break;
                case 3:
                    if (flag == 1)
                    {
                        obj.Day3 = true;
                        ent.SaveChanges();
                    }
                    else if (flag == 0)
                    {
                        obj.Day3 = true;
                        ent.AttendenceMasters.AddObject(obj);
                        ent.SaveChanges();
                    }
                    break;
                case 4:
                    if (flag == 1)
                    {
                        obj.Day4 = true;
                        ent.SaveChanges();
                    }
                    else if (flag == 0)
                    {
                        obj.Day4 = true;
                        ent.AttendenceMasters.AddObject(obj);
                        ent.SaveChanges();
                    }
                    break;
                case 5:
                    if (flag == 1)
                    {
                        obj.Day5 = true;
                        ent.SaveChanges();
                    }
                    else if (flag == 0)
                    {
                        obj.Day5 = true;
                        ent.AttendenceMasters.AddObject(obj);
                        ent.SaveChanges();
                    }
                    break;
                case 6:
                    if (flag == 1)
                    {
                        obj.Day6 = true;
                        ent.SaveChanges();
                    }
                    else if (flag == 0)
                    {
                        obj.Day6 = true;
                        ent.AttendenceMasters.AddObject(obj);
                        ent.SaveChanges();
                    }
                    break;
                case 7:
                    if (flag == 1)
                    {
                        obj.Day7 = true;
                        ent.SaveChanges();
                    }
                    else if (flag == 0)
                    {
                        obj.Day7 = true;
                        ent.AttendenceMasters.AddObject(obj);
                        ent.SaveChanges();
                    }
                    break;
                case 8:
                    if (flag == 1)
                    {
                        obj.Day8 = true;
                        ent.SaveChanges();
                    }
                    else if (flag == 0)
                    {
                        obj.Day8 = true;
                        ent.AttendenceMasters.AddObject(obj);
                        ent.SaveChanges();
                    }
                    break;
                case 9:
                    if (flag == 1)
                    {
                        obj.Day9 = true;
                        ent.SaveChanges();
                    }
                    else if (flag == 0)
                    {
                        obj.Day9 = true;
                        ent.AttendenceMasters.AddObject(obj);
                        ent.SaveChanges();
                    }
                    break;
                case 10:
                    if (flag == 1)
                    {
                        obj.Day10 = true;
                        ent.SaveChanges();
                    }
                    else if (flag == 0)
                    {
                        obj.Day10 = true;
                        ent.AttendenceMasters.AddObject(obj);
                        ent.SaveChanges();
                    }
                    break;
                case 11:
                    if (flag == 1)
                    {
                        obj.Day11 = true;
                        ent.SaveChanges();
                    }
                    else if (flag == 0)
                    {
                        obj.Day11 = true;
                        ent.AttendenceMasters.AddObject(obj);
                        ent.SaveChanges();
                    }
                    break;
                case 12:
                    if (flag == 1)
                    {
                        obj.Day12 = true;
                        ent.SaveChanges();
                    }
                    else if (flag == 0)
                    {
                        obj.Day12 = true;
                        ent.AttendenceMasters.AddObject(obj);
                        ent.SaveChanges();
                    }
                    break;
                case 13:
                    if (flag == 1)
                    {
                        obj.Day13 = true;
                        ent.SaveChanges();
                    }
                    else if (flag == 0)
                    {
                        obj.Day13 = true;
                        ent.AttendenceMasters.AddObject(obj);
                        ent.SaveChanges();
                    }
                    break;
                case 14:
                    if (flag == 1)
                    {
                        obj.Day14 = true;
                        ent.SaveChanges();
                    }
                    else if (flag == 0)
                    {
                        obj.Day14 = true;
                        ent.AttendenceMasters.AddObject(obj);
                        ent.SaveChanges();
                    }
                    break;
                case 15:
                    if (flag == 1)
                    {
                        obj.Day15 = true;
                        ent.SaveChanges();
                    }
                    else if (flag == 0)
                    {
                        obj.Day15 = true;
                        ent.AttendenceMasters.AddObject(obj);
                        ent.SaveChanges();
                    }
                    break;
                case 16:
                    if (flag == 1)
                    {
                        obj.Day16 = true;
                        ent.SaveChanges();
                    }
                    else if (flag == 0)
                    {
                        obj.Day16 = true;
                        ent.AttendenceMasters.AddObject(obj);
                        ent.SaveChanges();
                    }
                    break;
                case 17:
                    if (flag == 1)
                    {
                        obj.Day17 = true;
                        ent.SaveChanges();
                    }
                    else if (flag == 0)
                    {
                        obj.Day17 = true;
                        ent.AttendenceMasters.AddObject(obj);
                        ent.SaveChanges();
                    }
                    break;
                case 18:
                    if (flag == 1)
                    {
                        obj.Day18 = true;
                        ent.SaveChanges();
                    }
                    else if (flag == 0)
                    {
                        obj.Day18 = true;
                        ent.AttendenceMasters.AddObject(obj);
                        ent.SaveChanges();
                    }
                    break;
                case 19:
                    if (flag == 1)
                    {
                        obj.Day19 = true;
                        ent.SaveChanges();
                    }
                    else if (flag == 0)
                    {
                        obj.Day19 = true;
                        ent.AttendenceMasters.AddObject(obj);
                        ent.SaveChanges();
                    }
                    break;
                case 20:
                    if (flag == 1)
                    {
                        obj.Day20 = true;
                        ent.SaveChanges();
                    }
                    else if (flag == 0)
                    {
                        obj.Day20 = true;
                        ent.AttendenceMasters.AddObject(obj);
                        ent.SaveChanges();
                    }
                    break;
                case 21:
                    if (flag == 1)
                    {
                        obj.Day21 = true;
                        ent.SaveChanges();
                    }
                    else if (flag == 0)
                    {
                        obj.Day21 = true;
                        ent.AttendenceMasters.AddObject(obj);
                        ent.SaveChanges();
                    }
                    break;
                case 22:
                    if (flag == 1)
                    {
                        obj.Day22 = true;
                        ent.SaveChanges();
                    }
                    else if (flag == 0)
                    {
                        obj.Day22 = true;
                        ent.AttendenceMasters.AddObject(obj);
                        ent.SaveChanges();
                    }
                    break;
                case 23:
                    if (flag == 1)
                    {
                        obj.Day23 = true;
                        ent.SaveChanges();
                    }
                    else if (flag == 0)
                    {
                        obj.Day23 = true;
                        ent.AttendenceMasters.AddObject(obj);
                        ent.SaveChanges();
                    }
                    break;
                case 24:
                    if (flag == 1)
                    {
                        obj.Day24 = true;
                        ent.SaveChanges();
                    }
                    else if (flag == 0)
                    {
                        obj.Day24 = true;
                        ent.AttendenceMasters.AddObject(obj);
                        ent.SaveChanges();
                    }
                    break;
                case 25:
                    if (flag == 1)
                    {
                        obj.Day25 = true;
                        ent.SaveChanges();
                    }
                    else if (flag == 0)
                    {
                        obj.Day25 = true;
                        ent.AttendenceMasters.AddObject(obj);
                        ent.SaveChanges();
                    }
                    break;
                case 26:
                    if (flag == 1)
                    {
                        obj.Day26 = true;
                        ent.SaveChanges();
                    }
                    else if (flag == 0)
                    {
                        obj.Day26 = true;
                        ent.AttendenceMasters.AddObject(obj);
                        ent.SaveChanges();
                    }
                    break;
                case 27:
                    if (flag == 1)
                    {
                        obj.Day27 = true;
                        ent.SaveChanges();
                    }
                    else if (flag == 0)
                    {
                        obj.Day27 = true;
                        ent.AttendenceMasters.AddObject(obj);
                        ent.SaveChanges();
                    }
                    break;
                case 28:
                    if (flag == 1)
                    {
                        obj.Day28 = true;
                        ent.SaveChanges();
                    }
                    else if (flag == 0)
                    {
                        obj.Day28 = true;
                        ent.AttendenceMasters.AddObject(obj);
                        ent.SaveChanges();
                    }
                    break;
                case 29:
                    if (flag == 1)
                    {
                        obj.Day29 = true;
                        ent.SaveChanges();
                    }
                    else if (flag == 0)
                    {
                        obj.Day29 = true;
                        ent.AttendenceMasters.AddObject(obj);
                        ent.SaveChanges();
                    }
                    break;
                case 30:
                    if (flag == 1)
                    {
                        obj.Day30 = true;
                        ent.SaveChanges();
                    }
                    else if (flag == 0)
                    {
                        obj.Day30 = true;
                        ent.AttendenceMasters.AddObject(obj);
                        ent.SaveChanges();
                    }
                    break;
                case 31:
                    if (flag == 1)
                    {
                        obj.Day31 = true;
                        ent.SaveChanges();
                    }
                    else if (flag == 0)
                    {
                        obj.Day31 = true;
                        ent.AttendenceMasters.AddObject(obj);
                        ent.SaveChanges();
                    }
                    break;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectManagementDL;

namespace ProjectManagementBL
{
    public class ChangePasswordBL
    {
        /// <summary>
        /// Inserting Data.
        /// </summary>
        /// <param name="obj"></param>
        public void InsertData(ChangePasswordTBL obj)
        {
            ProjectManagementSystemEntities ent = new ProjectManagementSystemEntities();
            ent.ChangePasswordTBLs.AddObject(obj);
            ent.SaveChanges();
        }

        /// <summary>
        /// Take new password.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string TakePassword(int id)
        {
            ProjectManagementSystemEntities ent = new ProjectManagementSystemEntities();
            List<ChangePasswordTBL> objj = (from a in ent.ChangePasswordTBLs where a.EmpId == id select a).ToList();
            ChangePasswordTBL obj = objj.Last();
            return obj.NewPassword;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ProjectManagementDL;

namespace ProjectManagementBL
{
    public class ClientBL
    {
        /// <summary>
        /// Add New Client
        /// </summary>
        /// <param name="objclnt"></param>
        public void AddNewClient(Client objclnt)
        {
            ProjectManagementSystemEntities ent = new ProjectManagementSystemEntities();
            Client obj = new Client();
            obj.FirstName = objclnt.FirstName;
            obj.MiddelName = objclnt.MiddelName;
            obj.LastName = objclnt.LastName;
            obj.Mobile = objclnt.Mobile;
            obj.Email = objclnt.Email;
            obj.CreateDate = objclnt.CreateDate;
            obj.CreateBy = objclnt.CreateBy;
            obj.IsActive = objclnt.IsActive;
            obj.IsDelete = objclnt.IsDelete;

            ent.Clients.AddObject(obj);
            ent.SaveChanges();
        }

        /// <summary>
        /// Get Data for client grid view.
        /// </summary>
        /// <returns></returns>
        public List<Client> getdataforclient()
        {
            ProjectManagementSystemEntities ent = new ProjectManagementSystemEntities();
            List<Client> objclnt = (from a in ent.Clients select a).ToList();
            return objclnt;
        }

        /// <summary>
        /// Delete Data for client grid view.
        /// </summary>
        /// <param name="id"></param>
        public void deleteClientdata(int id)
        {
            ProjectManagementSystemEntities ent = new ProjectManagementSystemEntities();
            Client objclnt = (from a in ent.Clients where a.ClientId == id select a).FirstOrDefault();
            if (objclnt != null)
            {
                ent.Clients.DeleteObject(objclnt);
                ent.SaveChanges();
            }
        }


        /// <summary>
        /// Retrive Record for perticular client.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Client retriveClientrecord(int id)
        {
            ProjectManagementSystemEntities ent = new ProjectManagementSystemEntities();
            Client objclnt = (from a in ent.Clients where a.ClientId == id select a).FirstOrDefault();
            return objclnt;
        }


        /// <summary>
        /// Update Data for Client.
        /// </summary>
        /// <param name="objclnt"></param>
        public void updateClientdata(Client objclnt)
        {
            ProjectManagementSystemEntities ent = new ProjectManagementSystemEntities();
            Client objclntupdate = (from a in ent.Clients where a.ClientId == objclnt.ClientId select a).FirstOrDefault();
            if (objclntupdate != null)
            {
                objclntupdate.FirstName = objclnt.FirstName;
                objclntupdate.LastName = objclnt.LastName;
                objclntupdate.MiddelName = objclnt.MiddelName;
                objclntupdate.Mobile = objclnt.Mobile;
                objclntupdate.Email = objclnt.Email;
                objclntupdate.ModifyDate = objclnt.ModifyDate;
                objclntupdate.ModifyBy = objclnt.ModifyBy;

                ent.SaveChanges();
            }
        }
    }
}

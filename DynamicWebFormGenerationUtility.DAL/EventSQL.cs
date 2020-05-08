using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynamicWebFormGenerationUtility.Entity;


namespace DynamicWebFormGenerationUtility.DAL
{
    public class EventSQL : BaseSQLManager
    {
        public virtual List<Entity.Event> GetEventByFormName(string FormName)
        {
            List<Entity.Event> lstEvent = new List<Entity.Event>();
            SqlCommand cmdSelect = new SqlCommand();
            cmdSelect.CommandType = CommandType.StoredProcedure;
            cmdSelect.CommandText = "GetEventByFormName";
            cmdSelect.Parameters.AddWithValue("@FormName", FormName);

            SqlDataReader dr = this.ExecuteDataReader(cmdSelect);
            while (dr.Read())
            {
                Entity.Event objEvent = new Entity.Event();
                lstEvent.Add(objEvent);
                this.FillEntityEvent(dr, objEvent, 0);
            }
            base.ForceCloseConnection(cmdSelect);
            return lstEvent;
        }

        protected void FillEntityEvent(IDataReader dr, Entity.Event objEvent, int Type)
        {
            objEvent.EventId = GetFieldInt(dr, "EventId");
            objEvent.EventName = GetField(dr, "EventName");
        }
    }
}

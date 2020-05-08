using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web.UI.WebControls;

namespace DynamicWebFormGenerationUtility.BAL
{
    public class FillDropdown
    {
        public void LoadInputTypeMasterDropdown(DropDownList drp)
        {
            DAL.DataLoad fdl = new DAL.DataLoad();
            ParameterCollection pm = new ParameterCollection();
            fdl.FillingDropDown("dbo.LoadInputTypeMasterDropdown", drp, pm);
        }
        public void LoadTemplateDropDown(DropDownList drp)
        {
            DAL.DataLoad fdl = new DAL.DataLoad();
            ParameterCollection pm = new ParameterCollection();
            fdl.FillingDropDown("dbo.LoadTemplateDropDown", drp, pm);
        }

        public void LoadFormname(DropDownList drp)
        {
            DAL.DataLoad fdl = new DAL.DataLoad();
            ParameterCollection pm = new ParameterCollection();
            fdl.FillingDropDown("dbo.LoadFormname", drp, pm);
        }
        public void LoadConfigurationFormname(DropDownList drp)
        {
            DAL.DataLoad fdl = new DAL.DataLoad();
            ParameterCollection pm = new ParameterCollection();
            fdl.FillingDropDown("dbo.LoadConfigurationFormname", drp, pm);
        }
        public void LoadValidationType(DropDownList drp)
        {
            DAL.DataLoad fdl = new DAL.DataLoad();
            ParameterCollection pm = new ParameterCollection();
            fdl.FillingDropDown("dbo.LoadValidationType", drp, pm);
        }
        
        public void LoadColumnname(DropDownList drp,String Formid)
        {
            DAL.DataLoad fdl = new DAL.DataLoad();
            ParameterCollection pm = new ParameterCollection();
            pm.Add("@Formid", Formid);
            fdl.FillingDropDown("dbo.SummaryQueryBuilder", drp, pm);
        }
        public void LoadSummaryQueryDropdown(DropDownList drp )
        {
            DAL.DataLoad fdl = new DAL.DataLoad();
            ParameterCollection pm = new ParameterCollection();
            fdl.FillingDropDown("dbo.LoadSummaryQueryDropdown", drp, pm);
        }

        
        public void BindDropDownFromTemplateDropDownIdAndPara1(DropDownList drp, string TemplateDropDownId, string Para1)
        {
            DAL.DataLoad fdl = new DAL.DataLoad();
            ParameterCollection pm = new ParameterCollection();
            pm.Add("@TemplateDropDownId", TemplateDropDownId);
            pm.Add("@Para1", Para1);
            fdl.FillingDropDown("BindDropDownFromTemplateDropDownIdAndPara1", drp, pm);
        }

        public void LoadChildDropDownByFormId(DropDownList drp, string FormId)
        {
            DAL.DataLoad fdl = new DAL.DataLoad();
            ParameterCollection pm = new ParameterCollection();
            pm.Add("@FormId", FormId);
            fdl.FillingDropDown("LoadChildDropDownByFormId", drp, pm);
        }
        public void LoadFormComponentFormId(DropDownList drp, string FormId)
        {
            DAL.DataLoad fdl = new DAL.DataLoad();
            ParameterCollection pm = new ParameterCollection();
            pm.Add("@FormId", FormId);
            fdl.FillingDropDown("LoadFormComponentFormId", drp, pm);
        }
        
        public void CascadingDropDownTemplate(DropDownList drp, string BaseTemplateDropDownId, string Para1)
        {
            DAL.DataLoad fdl = new DAL.DataLoad();
            ParameterCollection pm = new ParameterCollection();
            pm.Add("@TemplateDropDownId", BaseTemplateDropDownId);
            pm.Add("@Parameter", Para1);
            fdl.FillingDropDown("CascadingDropDownTemplate", drp, pm);
        }

        public void LoadQueryName(DropDownList drp)
        {
            DAL.DataLoad fdl = new DAL.DataLoad();
            ParameterCollection pm = new ParameterCollection();
            fdl.FillingDropDown("dbo.GetQueryName", drp, pm);
        }


    }
}

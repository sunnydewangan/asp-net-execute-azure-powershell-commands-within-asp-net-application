using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Management.Automation;
using System.Collections.ObjectModel;
using System.Text;

namespace SampleAzure
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {


            ExecutePowershell();
        }

        protected void ExecutePowershell()
        {
            string WebAppName = txtWebappName.Text;
            string ResourceGroup = txtRG.Text;
            string AppServicePlan = txtASP.Text;
            string Location = txtLocation.Text;

            using (PowerShell PowerShellInstance = PowerShell.Create())
            {
                try
                {
                    PowerShellInstance.AddCommand("Login-AzureRmAccount");
                    PowerShellInstance.Invoke();
                 //   PowerShellInstance.AddCommand("Select-AzureSubscription -SubscriptionName 'Microsoft Azure Internal Consumption' ");
                    //   PowerShellInstance.AddCommand("Get-AzureRmSubscription -SubscriptionName 'Microsoft Azure Internal Consumption' | Select-AzureRmSubscription");
               //     PowerShellInstance.Invoke();
                    PowerShellInstance.AddCommand("New-AzureRmResourceGroup -ResourceGroupName '" + ResourceGroup + "' -Location '" + Location + "'");
                    PowerShellInstance.Invoke();
                    Response.Write("<H1>Webapp Successfully Created</H1>");
                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message);
                }
            }
        }
    }
}
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
                    StringBuilder PowerShellScript = new StringBuilder();
                    PowerShellScript.Append("Login-AzureRmAccount" + Environment.NewLine);
                    PowerShellScript.Append("Get-AzureRmSubscription -SubscriptionName 'Test - Microsoft Azure Internal Consumption' | Select-AzureRmSubscription" + Environment.NewLine);
                    PowerShellScript.Append("New-AzureRmResourceGroup -ResourceGroupName '" + ResourceGroup + "' -Location '" + Location + "'" + Environment.NewLine);
                    PowerShellScript.Append("New-AzureRmAppServicePlan -Name '" + AppServicePlan + "' -Location '" + Location + "' -Tier Free -ResourceGroupName '" + ResourceGroup + "'" + Environment.NewLine);
                    PowerShellScript.Append("New-AzureRmWebApp -ResourceGroupName '" + ResourceGroup + "' -Name '" + WebAppName + "' -AppServicePlan '" + AppServicePlan + "' -Location '" + Location + "'");
                    PowerShellInstance.AddScript(PowerShellScript.ToString());
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
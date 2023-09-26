using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.IdentityModel.Metadata;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class BasicPlugin : IPlugin
    {
        void IPlugin.Execute(IServiceProvider serviceProvider)
        {
            var context = (IPluginExecutionContext)serviceProvider.GetService(typeof(IPluginExecutionContext));

            if (context.InputParameters.Contains("Target") && context.InputParameters["Target"] is Entity)
            {
                //LAVORO
                IOrganizationServiceFactory factory = (IOrganizationServiceFactory)serviceProvider.GetService(typeof(IOrganizationServiceFactory));

                IOrganizationService service = factory.CreateOrganizationService(context.UserId);

                Contact cnt = (Contact)context.InputParameters["Target"];

                Contact preImage = (Contact)context.PreEntityImages["PreImage"];

                Contact postImage = (Contact)context.PostEntityImages["PostImage"];

                if(preImage.ald_Originatingboutique != null && postImage.ald_Originatingboutique == null )
                {
                    Contact contactToUpdate = new Contact();
                    contactToUpdate.Id = cnt.Id;
                    contactToUpdate.ald_MKTMailConsens = false;
                    contactToUpdate.ald_MKTSmsConsens = false;

                    service.Update(contactToUpdate);
                }

            }

            //NON LAVORO
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Http;

namespace convertServer0._1
{
    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class Service1
    {
        private static List<string> lst = new List<string>
        {
            "Arrays",
            "Queues",
            "Stacks"
        };

        [WebGet(UriTemplate = "/Tutorial")]
        public string GetAllTutorials() => String.Join(",", lst);

        [WebGet(UriTemplate = "/Tutorial/{TutorialId}")]

        public string GetTutorialByID(string TutorialId)
        {
            int pid;
            if (!Int32.TryParse(TutorialId, out pid))
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Unauthorized));
            }
            return lst[pid];
        }
        /*post*/
        [WebInvoke(Method = "POST", RequestFormat = WebMessageFormat.Json,
            UriTemplate = "/Tutorial", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped)]

        public void AddTutorial(string str) => lst.Add(str);

        [WebInvoke(Method = "DELETE", RequestFormat = WebMessageFormat.Json,
            UriTemplate = "/Tutorial/{TutorialId}", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped)]

        public void DeleteTutorial(string TutorialId)
        {
            int pid;
            if (!Int32.TryParse(TutorialId, out pid))
            {
                throw new HttpResponseException(new HttpResponseMessage(HttpStatusCode.Unauthorized));
            }
            lst.RemoveAt(pid);
        }


        [OperationContract]
        public void DoWork()
        {
            // Добавьте здесь реализацию операции
            return;
        }

        // Добавьте здесь дополнительные операции и отметьте их атрибутом [OperationContract]
    }
}

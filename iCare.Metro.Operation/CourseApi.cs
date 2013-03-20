using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iCare.Metro.Model;
using iCare.Net;

namespace iCare.Metro.Operation
{
    public class CourseApi : Api
    {
        public async Task<CourseResult> Get(string patienId)
        {
            CourseResult result = new CourseResult();
            RestRequest request = new RestRequest(Config.Actions.GetCourses);
            request.AddUrlSegment("patienid", patienId);
            Task<string> task = Client.ExecuteAsync(request);
            string json = await Client.ExecuteAsync(request);
            result = result.DeSerialize(json) as CourseResult;
            return result;
        }


    }
}

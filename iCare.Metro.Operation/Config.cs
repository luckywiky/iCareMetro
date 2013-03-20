using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iCare.Metro.Operation
{
    /// <summary>
    /// 应用程序配置信息，
    /// 将来会改成读取配置文件方式
    /// </summary>
    public abstract class Config
    {
        public static string ApiHost = "http://localhost:28273";

        private static ActionUrls actions = new ActionUrls();
        public static ActionUrls Actions
        {
            get
            {
                return actions;
            }
        }
    }

    public class ActionUrls
    {
        public string GetPatientInfo = "get_patient_info";
        public string GetCourses = "get_courses";
        public string GetInspectionResult = "get_inspection_result";
    }
}

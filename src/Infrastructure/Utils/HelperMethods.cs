using System.Linq;

namespace HelpfulWebsite_2.Infrastructure.Utils
{
    internal class HelperMethods
    {
        public static string GetQueryString(object obj)
        {
            var properties =
                from p in obj.GetType().GetProperties()
                where p.GetValue(obj) != null
                // ReSharper disable twice PossibleNullReferenceException - it's handled by the line above
                select p.Name.ToLower() + "=" + System.Web.HttpUtility.UrlEncode(p.GetValue(obj).ToString().ToLower());

            return string.Join("&", properties.ToArray());
        }
    }
}

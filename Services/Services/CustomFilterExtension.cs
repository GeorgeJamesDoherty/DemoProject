using System;
using System.Collections.Generic;
using System.Text;

namespace DemoProject.Services.Services
{
    public static class CustomFilterExtension
    {
        public static IEnumerable<T> CustomWhere<T>(this IEnumerable<T> customList, Func<T, bool> function)
        {
            var returnList = new List<T>();
            foreach(var entry in customList)
            {
                if(function(entry) == true)
                {
                    returnList.Add(entry);
                }
            }
            return returnList;
        }
    }
}

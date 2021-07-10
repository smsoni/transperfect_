using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WahooFitnessFramework
{
    // Use this when you want to store space in your enum
    public static class Extension
    {
        public static TAttribute GetAttribute<TAttribute>(this Enum value)
   where TAttribute : Attribute
        {
            var enumType = value.GetType();
            var name = Enum.GetName(enumType, value);
            return enumType.GetField(name).GetCustomAttributes(false).OfType<TAttribute>().SingleOrDefault();
        }
    }

    public enum JobName
    {
        [DescriptionAttr("1000")]
        Currency = 1000,

        [DescriptionAttr("Temp")]
        Customers = 1010

    }

    ////In Method consume like this
    //public void RunDistributionSchedule(JobName jobName) // JobName is enum
    //{
    //    //Get the description attribute from Enum.
    // Inside jobDescription you will get attributes like Temp and all
    //    string jobDescription = jobName.GetAttribute<DescriptionAttr>().Name;
    //}

}

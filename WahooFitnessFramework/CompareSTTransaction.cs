using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WahooFitnessFramework
{
    public static class CompareSTTransaction
    {
        public static List<string> DetailedCompare<T>(T T1, T T2, List<string> exceptionlist=null)
        {
            List<string> differences = new List<string>();
            // ILog log = LogManager.GetLogger(typeof(CompareSTTransaction).Name);
           // log.DebugFormat(String.Format("Object 1 Type:{0}, Object 1{1}", T1.GetType(), WriteObjectToXML.GetXml<T>(T1)));
          //  log.DebugFormat(String.Format("Object 1 Type:{0}, Object 1{1}", T1.GetType(), WriteObjectToXML.GetXml<T>(T1)));
          if(exceptionlist!=null)
            {
               /// log.DebugFormat("Exception List");
                // exceptionlist.ForEach(x => log.DebugFormat(x.ToString()));
            }

           // log.DebugFormat(String.Format("Stack trace for DetailedCompare: {0}", Environment.StackTrace));

            foreach(PropertyInfo property in T1.GetType().GetProperties())
            {
                dynamic value1 = property.GetValue(T1, null);
                dynamic value2 = property.GetValue(T1, null);

                if (value1 != null && value2 != null && value1.GetType().IsGenericType)
                {
                    if(value1.Count != value2.Count)
                    {
                        differences.Add(String.Format("{0}-  list Count is different. Object 1 has elements Count:{1} and Object 2 has elements count:{2}", T1.GetType().Name, value1.Count, value2.Count));

                    }
                    using(var e1 = value1.GetEnumerator())
                    using(var e2 = value1.GetEnumerator())
                    {
                        while(e1.MoveNext() && e2.MoveNext())
                        {
                            var item1 = e1.Current;
                            var item2 = e2.Current;

                            List<string> recdifferences = DetailedCompare(item1, item2, exceptionlist);
                            if(recdifferences!=null && recdifferences.Count>0)
                            {
                                differences.AddRange(recdifferences);
                            }

                        }
                    }
                }

                if(value1!=null &&value2!=null && !value1.Equals(value2) && !value1.GetType.IsGenericType)
                {
                    if(exceptionlist!=null)
                    {
                        if(!exceptionlist.Contains(property.Name))
                        {
                            differences.Add(String.Format("{0} - {1} is different. Object 1 has value:{2} and Object 2 has value {3}", T1.GetType().Name, property.ToString().Split(' ')[1].ToString(), value1, value2));
                        }
                    }
                    else
                    {
                        differences.Add(String.Format("{0} - {1} is different. Object 1 has value:{2} and Object 2 has value {3}", T1.GetType().Name, property.ToString().Split(' ')[1].ToString(), value1, value2));
                    }

                }
            }
            return differences;
        }
    }
}

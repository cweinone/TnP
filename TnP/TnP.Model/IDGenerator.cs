using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TnP.Model
{
    public class IDGenerator
    {
        public static long generateID()
        {
            return DateTime.Now.ToFileTime();
        } 
    }
}

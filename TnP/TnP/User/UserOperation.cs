using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TnP.User
{
    public class UserOperation
    {
        private static UserOperation _uo = null;
        public static UserOperation GetInstance()
        {
            if (_uo == null)
            {
                _uo = new UserOperation();
            }
            return _uo;
        }

        private static object _lock = new object();
        private Queue<string> uoperation = new Queue<string>();
        private Queue<string> uarg = new Queue<string>();

        public void Add(string p, string arg)
        {
            lock (_lock)
            {
                uoperation.Enqueue(p);
                uarg.Enqueue(arg);
            }
        }
        public void Add(string p)
        {
            lock (_lock)
            {
                uoperation.Enqueue(p);
                uarg.Enqueue(null);
            }
        }

        public void Remove()
        {
            lock (_lock)
            {
                uoperation.Dequeue();
                uarg.Dequeue();
            }
        }

        public int count()
        {
            return uoperation.Count;
        }

        
    }
}

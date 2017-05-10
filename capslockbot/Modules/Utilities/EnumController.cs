using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace capslockbot.Modules.Utilities
{
    //WORK IN PROGRESS
    public static class EnumController
    {

        public static int Count(this IEnumerable source)
        {
            var col = source as ICollection;
            if (col != null)
                return col.Count;

            int c = 0;
            var e = source.GetEnumerator();
            DynamicUsing(e, () =>
            {
                while (e.MoveNext())
                    c++;
            });
            return c;
        }
  
        private static void DynamicUsing(object resource, Action action)
        {
            try
            {
                action();
            }finally
            {
                IDisposable d = resource as IDisposable;
                if (d != null)
                    d.Dispose();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Net.Lab.DAL.Helpers
{
    public static class ModelsChangeHelper
    {
        public static object AssignObject(Object to, Object from)
        {
            if (to.GetType().Name != from.GetType().Name)
                throw new ArgumentException();

            foreach (PropertyInfo propertyInfo in to.GetType().GetProperties())
            {
                propertyInfo.SetValue(to, propertyInfo.GetValue(from));
            }

            return to;
        }
    }
}

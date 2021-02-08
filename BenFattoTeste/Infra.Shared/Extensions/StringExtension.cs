using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Infra.Shared.Extensions
{
    public static class StringExtension
    {
        public static bool TryParse<T>(string s, out T value)
        {
            TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
            try
            {
                value = (T)converter.ConvertFromString(s);
                return true;
            }
            catch
            {
                value = default(T);
                return false;
            }
        }

        public static int TryParseInt(this string s)
        {
            int value;

            TryParse<int>(s, out value);

            return value;
        }
    }
}

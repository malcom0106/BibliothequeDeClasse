using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibraryMR
{
    /**
    * C# <> JavaScript Date Converter
    * Copyright (c) 2011 marlun78
    * MIT License, https://gist.github.com/marlun78/bd0800cf5e8053ba9f83
    */
    /// <summary>
    /// Provides a Convert method to convert between C# DateTime values and JavaScript parsable Int64 date values. 
    /// </summary>
    public static class JavaScriptDateConverter
    {
        // 
        private static DateTime _jan1st1970 = new DateTime(1970, 1, 1);

        /// <summary>
        /// Converts a DateTime into a (JavaScript parsable) Int64.
        /// </summary>
        /// <param name="from">The DateTime to convert from</param>
        /// <returns>An integer value representing the number of milliseconds since 1 January 1970 00:00:00 UTC.</returns>
        public static long Convert(DateTime from)
        {
            return System.Convert.ToInt64((from - _jan1st1970).TotalMilliseconds);
        }

        /// <summary>
        /// Converts a (JavaScript parsable) Int64 into a DateTime.
        /// </summary>
        /// <param name="from">An integer value representing the number of milliseconds since 1 January 1970 00:00:00 UTC.</param>
        /// <returns>The date as a DateTime</returns>
        public static DateTime Convert(long from)
        {
            return _jan1st1970.AddMilliseconds(from);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace JsonDuplicatesSearcher.Extensions
{
    public static class ThrowHelper
    {
        /// <summary>
        /// Throws an <see cref="ArgumentNullException"/> if <paramref name="argument"/> is null.
        /// </summary>
        /// <param name="argument">The reference type argument to validate as non-null.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="argument"/> corresponds.</param>
        /// <param name="message">The exception message.</param>
        public static void ThrowArgumentNullExIfNull(object argument, string paramName = null, string message = null)
        {
            if (argument == null)
                throw new ArgumentNullException(paramName, message);
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if <paramref name="array"/> is empty.
        /// </summary>
        /// <param name="array">The reference type array argument to validate as non-empty.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="array"/> corresponds.</param>
        /// <param name="message">The exception message.</param>
        /// <exception cref="ArgumentException"></exception>
        public static void ThrowArgumentExIfEmpty<T>(IEnumerable<T> array, string paramName = null, string message = null)
            where T : class
        {
            if (!array.Any())
                throw new ArgumentException(message, paramName);
        }

        /// <summary>
        /// Throws an <see cref="ArgumentException"/> if <paramref name="str"/> is empty.
        /// </summary>
        /// <param name="str">The reference type array argument to validate as non-empty.</param>
        /// <param name="paramName">The name of the parameter with which <paramref name="str"/> corresponds.</param>
        /// <param name="message">The exception message.</param>
        /// <exception cref="ArgumentException"></exception>
        public static void ThrowArgumentExIfEmpty(String str, string paramName = null, string message = null)
        {
            if (str.Trim().Length == 0)
                throw new ArgumentException(message, paramName);
        }
    }
}

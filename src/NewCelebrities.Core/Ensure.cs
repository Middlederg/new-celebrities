using System;
using System.Collections.Generic;
using System.Linq;

namespace NewCelebrities
{
    /// <summary>
    /// Will throw exceptions when conditions are not satisfied.
    /// </summary>
    public static partial class Ensure
    {
        /// <summary>
        /// Ensures that the given expression is true
        /// </summary>
        /// <exception cref="Exception">Exception thrown if false condition</exception>
        /// <param name="condition">Condition to test/ensure</param>
        /// <param name="message">Message for the exception</param>
        /// <exception cref="Exception">Thrown when <paramref name="condition"/> is false</exception>
        public static void That(bool condition, string message = "")
        {
            That<Exception>(condition, message);
        }

        /// <summary>
        /// Ensures that the given expression is true
        /// </summary>
        /// <typeparam name="TException">Type of exception to throw</typeparam>
        /// <param name="condition">Condition to test/ensure</param>
        /// <param name="message">Message for the exception</param>
        /// <exception cref="TException">Thrown when <paramref name="condition"/> is false</exception>
        /// <remarks><see cref="TException"/> must have a constructor that takes a single string</remarks>
        public static void That<TException>(bool condition, string message = "") where TException : Exception
        {
            if (!condition)
            {
                throw (TException)Activator.CreateInstance(typeof(TException), message);
            }
        }

        /// <summary>
        /// Ensures given condition is false
        /// </summary>
        /// <typeparam name="TException">Type of exception to throw</typeparam>
        /// <param name="condition">Condition to test</param>
        /// <param name="message">Message for the exception</param>
        /// <exception cref="TException">Thrown when <paramref name="condition"/> is true</exception>
        /// <remarks><see cref="TException"/> must have a constructor that takes a single string</remarks>
        public static void Not<TException>(bool condition, string message = "") where TException : Exception
        {
            That<TException>(!condition, message);
        }

        /// <summary>
        /// Ensures given condition is false
        /// </summary>
        /// <param name="condition">Condition to test</param>
        /// <param name="message">Message for the exception</param>
        /// <exception cref="Exception">Thrown when <paramref name="condition"/> is true</exception>
        public static void Not(bool condition, string message = "")
        {
            Not<Exception>(condition, message);
        }

        /// <summary>
        /// Ensures given object is not null
        /// </summary>
        /// <param name="value">Value of the object to test for null reference</param>
        /// <param name="message">Message for the Null Reference Exception</param>
        /// <exception cref="NullReferenceException">Thrown when <paramref name="value"/> is null</exception>
        public static void NotNull(object value, string message = "")
        {
            That<NullReferenceException>(value != null, message);
        }

        /// <summary>
        /// Ensures given string is not null or empty
        /// </summary>
        /// <param name="value">String value to compare</param>
        /// <param name="message">Message of the exception if value is null or empty</param>
        /// <exception cref="Exception">string value is null or empty</exception>
        public static void NotNullOrEmpty(string value, string message = "String cannot be null or empty")
        {
            That(!String.IsNullOrEmpty(value), message);
        }

        /// <summary>
        /// Ensures given objects are equal
        /// </summary>
        /// <typeparam name="T">Type of objects to compare for equality</typeparam>
        /// <param name="left">First Value to Compare</param>
        /// <param name="right">Second Value to Compare</param>
        /// <param name="message">Message of the exception when values equal</param>
        /// <exception cref="Exception">Exception is thrown when <paramref cref="left"/> not equal to <paramref cref="right"/></exception>
        /// <remarks>Null values will cause an exception to be thrown</remarks>
        public static void Equal<T>(T left, T right, string message = "Values must be equal")
        {
            That(left != null && right != null && left.Equals(right), message);
        }

        /// <summary>
        /// Ensures given objects are not equal
        /// </summary>
        /// <typeparam name="T">Type of objects to compare for equality</typeparam>
        /// <param name="left">First Value to Compare</param>
        /// <param name="right">Second Value to Compare</param>
        /// <param name="message">Message of the exception when values equal</param>
        /// <exception cref="Exception">Thrown when <paramref cref="left"/> equal to <paramref cref="right"/></exception>
        /// <remarks>Null values will cause an exception to be thrown</remarks>
        public static void NotEqual<T>(T left, T right, string message = "Values must not be equal")
        {
            That(left != null && right != null && !left.Equals(right), message);
        }

        /// <summary>
        /// Ensures given collection contains a value that satisfied a predicate
        /// </summary>
        /// <typeparam name="T">Collection type</typeparam>
        /// <param name="collection">Collection to test</param>
        /// <param name="predicate">Predicate where one value in the collection must satisfy</param>
        /// <param name="message">Message of the exception if value not found</param>
        /// <exception cref="Exception">
        ///     Thrown if collection is null, empty or doesn't contain a value that satisfies <paramref cref="predicate"/>
        /// </exception>
        public static void Contains<T>(IEnumerable<T> collection, Func<T, bool> predicate, string message = "")
        {
            That(collection != null && collection.Any(predicate), message);
        }

        /// <summary>
        /// Ensures ALL items in the given collection satisfy a predicate
        /// </summary>
        /// <typeparam name="T">Collection type</typeparam>
        /// <param name="collection">Collection to test</param>
        /// <param name="predicate">Predicate that ALL values in the collection must satisfy</param>
        /// <param name="message">Message of the exception if not all values are valid</param>
        /// <exception cref="Exception">
        ///     Thrown if collection is null, empty or not all values satisfies <paramref cref="predicate"/>
        /// </exception>
        public static void Items<T>(IEnumerable<T> collection, Func<T, bool> predicate, string message = "")
        {
            That(collection != null && !collection.Any(x => !predicate(x)), message);
        }
    }
}

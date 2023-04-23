#nullable disable

// Tests copied from dotnet/runtime repo. Original source code can be found here:
// https://github.com/dotnet/runtime/blob/main/src/libraries/Common/tests/System/Collections/TestBase.Generic.cs

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Xunit;

namespace PerfView.Collections.Tests
{
    /// <summary>
    /// Provides a base set of generic operations that are used by all other generic testing interfaces.
    /// </summary>
    internal abstract class TestBase<T> : TestBase
    {
        #region Helper Methods

        /// <summary>
        /// To be implemented in the concrete collections test classes. Creates an instance of T that
        /// is dependent only on the seed passed as input and will return the same value on repeated
        /// calls with the same seed.
        /// </summary>
        protected abstract T CreateT(int seed);

        /// <summary>
        /// The EqualityComparer that can be used in the overriding class when creating test enumerables
        /// or test collections. Default if not overridden is the default comparator.
        /// </summary>
        protected virtual IEqualityComparer<T> GetIEqualityComparer() => EqualityComparer<T>.Default;

        /// <summary>
        /// The Comparer that can be used in the overriding class when creating test enumerables
        /// or test collections. Default if not overridden is the default comparator.
        /// </summary>
        protected virtual IComparer<T> GetIComparer() => Comparer<T>.Default;

        /// <summary>
        /// Helper function to create a Queue fulfilling the given specific parameters. The function will
        /// create an Queue and then add values
        /// to it until it is full. It will begin by adding the desired number of matching,
        /// followed by random (deterministic) elements until the desired count is reached.
        /// </summary>
        protected IEnumerable<T> CreateQueue(IEnumerable<T> enumerableToMatchTo, int count, int numberOfMatchingElements, int numberOfDuplicateElements)
        {
            Queue<T> queue = new Queue<T>(count);
            int seed = 528;
            int duplicateAdded = 0;
            List<T> match = null;

            // Enqueue Matching elements
            if (enumerableToMatchTo != null)
            {
                match = enumerableToMatchTo.ToList();
                for (int i = 0; i < numberOfMatchingElements; i++)
                {
                    queue.Enqueue(match[i]);
                    while (duplicateAdded++ < numberOfDuplicateElements)
                        queue.Enqueue(match[i]);
                }
            }

            // Enqueue elements to reach the desired count
            while (queue.Count < count)
            {
                T toEnqueue = CreateT(seed++);
                while (queue.Contains(toEnqueue) || (match != null && match.Contains(toEnqueue))) // Don't want any unexpectedly duplicate values
                    toEnqueue = CreateT(seed++);
                queue.Enqueue(toEnqueue);
                while (duplicateAdded++ < numberOfDuplicateElements)
                    queue.Enqueue(toEnqueue);
            }

            // Validate that the Enumerable fits the guidelines as expected
            Debug.Assert(queue.Count == count);
            if (match != null)
            {
                int actualMatchingCount = 0;
                foreach (T lookingFor in match)
                    actualMatchingCount += queue.Contains(lookingFor) ? 1 : 0;
                Assert.Equal(numberOfMatchingElements, actualMatchingCount);
            }

            return queue;
        }

        /// <summary>
        /// Helper function to create an List fulfilling the given specific parameters. The function will
        /// create an List and then add values
        /// to it until it is full. It will begin by adding the desired number of matching,
        /// followed by random (deterministic) elements until the desired count is reached.
        /// </summary>
        protected IEnumerable<T> CreateList(IEnumerable<T> enumerableToMatchTo, int count, int numberOfMatchingElements, int numberOfDuplicateElements)
        {
            List<T> list = new List<T>(count);
            int seed = 528;
            int duplicateAdded = 0;
            List<T> match = null;

            // Add Matching elements
            if (enumerableToMatchTo != null)
            {
                match = enumerableToMatchTo.ToList();
                for (int i = 0; i < numberOfMatchingElements; i++)
                {
                    list.Add(match[i]);
                    while (duplicateAdded++ < numberOfDuplicateElements)
                        list.Add(match[i]);
                }
            }

            // Add elements to reach the desired count
            while (list.Count < count)
            {
                T toAdd = CreateT(seed++);
                while (list.Contains(toAdd) || (match != null && match.Contains(toAdd))) // Don't want any unexpectedly duplicate values
                    toAdd = CreateT(seed++);
                list.Add(toAdd);
                while (duplicateAdded++ < numberOfDuplicateElements)
                    list.Add(toAdd);
            }

            // Validate that the Enumerable fits the guidelines as expected
            Debug.Assert(list.Count == count);
            if (match != null)
            {
                int actualMatchingCount = 0;
                foreach (T lookingFor in match)
                    actualMatchingCount += list.Contains(lookingFor) ? 1 : 0;
                Assert.Equal(numberOfMatchingElements, actualMatchingCount);
            }

            return list;
        }

        /// <summary>
        /// Helper function to create an HashSet fulfilling the given specific parameters. The function will
        /// create an HashSet using the Comparer constructor and then add values
        /// to it until it is full. It will begin by adding the desired number of matching,
        /// followed by random (deterministic) elements until the desired count is reached.
        /// </summary>
        protected IEnumerable<T> CreateHashSet(IEnumerable<T> enumerableToMatchTo, int count, int numberOfMatchingElements)
        {
            HashSet<T> set = new HashSet<T>(GetIEqualityComparer());
            int seed = 528;
            List<T> match = null;

            // Add Matching elements
            if (enumerableToMatchTo != null)
            {
                match = enumerableToMatchTo.ToList();
                for (int i = 0; i < numberOfMatchingElements; i++)
                    set.Add(match[i]);
            }

            // Add elements to reach the desired count
            while (set.Count < count)
            {
                T toAdd = CreateT(seed++);
                while (set.Contains(toAdd) || (match != null && match.Contains(toAdd, GetIEqualityComparer()))) // Don't want any unexpectedly duplicate values
                    toAdd = CreateT(seed++);
                set.Add(toAdd);
            }

            // Validate that the Enumerable fits the guidelines as expected
            Debug.Assert(set.Count == count);
            if (match != null)
            {
                int actualMatchingCount = 0;
                foreach (T lookingFor in match)
                    actualMatchingCount += set.Contains(lookingFor) ? 1 : 0;
                Assert.Equal(numberOfMatchingElements, actualMatchingCount);
            }

            return set;
        }

        /// <summary>
        /// Helper function to create an SortedSet fulfilling the given specific parameters. The function will
        /// create an SortedSet using the Comparer constructor and then add values
        /// to it until it is full. It will begin by adding the desired number of matching,
        /// followed by random (deterministic) elements until the desired count is reached.
        /// </summary>
        protected IEnumerable<T> CreateSortedSet(IEnumerable<T> enumerableToMatchTo, int count, int numberOfMatchingElements)
        {
            SortedSet<T> set = new SortedSet<T>(GetIComparer());
            int seed = 528;
            List<T> match = null;

            // Add Matching elements
            if (enumerableToMatchTo != null)
            {
                match = enumerableToMatchTo.ToList();
                for (int i = 0; i < numberOfMatchingElements; i++)
                    set.Add(match[i]);
            }

            // Add elements to reach the desired count
            while (set.Count < count)
            {
                T toAdd = CreateT(seed++);
                while (set.Contains(toAdd) || (match != null && match.Contains(toAdd, GetIEqualityComparer()))) // Don't want any unexpectedly duplicate values
                    toAdd = CreateT(seed++);
                set.Add(toAdd);
            }

            // Validate that the Enumerable fits the guidelines as expected
            Debug.Assert(set.Count == count);
            if (match != null)
            {
                int actualMatchingCount = 0;
                foreach (T lookingFor in match)
                    actualMatchingCount += set.Contains(lookingFor) ? 1 : 0;
                Assert.Equal(numberOfMatchingElements, actualMatchingCount);
            }

            return set;
        }

        protected IEnumerable<T> CreateLazyEnumerable(IEnumerable<T> enumerableToMatchTo, int count, int numberOfMatchingElements, int numberOfDuplicateElements)
        {
            IEnumerable<T> list = CreateList(enumerableToMatchTo, count, numberOfMatchingElements, numberOfDuplicateElements);
            return list.Select(item => item);
        }

        #endregion
    }
}










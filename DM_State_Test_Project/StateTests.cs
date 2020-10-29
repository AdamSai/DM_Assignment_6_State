using Microsoft.VisualStudio.TestTools.UnitTesting;
using DM_State;
using System;
using System.Collections.Generic;
using System.Text;
using SetTheory;

namespace DM_State.Tests
{
    [TestClass()]
    public class StateTests
    {
        [TestMethod()]
        public void IsSubstateTrueTest()
        {
            // Arrange
            var state1 = new State();
            var state2 = new State();
            var firstDictionary = new Dictionary<string, SetTheory.ISet<long>>()
            {
                {"A", new RangeSet(0, 100)},
                {"B", new HashedSet(new long[]{0, 1, 2, 4, 5})},
            };
            var secondDictionary = new Dictionary<string, SetTheory.ISet<long>>()
            {
                {"A", new RangeSet(-100, 100)},
                {"B", new HashedSet(new long[]{-2, -1, 0, 1, 2, 4, 5})},
            };

            state1.Variables = firstDictionary;
            state2.Variables = secondDictionary;

            // Act
            var actual = state1.IsSubstate(state2);

            // Assert
            Assert.IsTrue(actual);
        }        
        [TestMethod()]
        public void IsSubstateFalseTest()
        {
            // Arrange
            var state1 = new State();
            var state2 = new State();
            var firstDictionary = new Dictionary<string, SetTheory.ISet<long>>()
            {
                {"A", new RangeSet(0, 5)},
                {"B", new HashedSet(new long[]{0})},
            };
            var secondDictionary = new Dictionary<string, SetTheory.ISet<long>>()
            {
                {"A", new RangeSet(50, 100)},
                {"B", new HashedSet(new long[]{0, 1})},
            };

            state1.Variables = firstDictionary;
            state2.Variables = secondDictionary;

            // Act
            var actual = state1.IsSubstate(state2);

            // Assert
            Assert.IsFalse(actual);
        }
    }
}
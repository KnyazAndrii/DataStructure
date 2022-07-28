using NUnit.Framework;
using DataStructuresLibrary;
using System;

namespace DataStructure.Tests
{
    public class MyArrayListTests
    {
        [Test]
        public void ArrayConstructor_WhenNullPassed_ShouldThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                MyArrayListHelper myArrayList = new MyArrayListHelper(null);
            });
        }

        [TestCase(new int[] { }, 0, 20, new int[] { 20 })]
        [TestCase(new int[] { 23 }, 1, -1, new int[] { 23, -1 })]
        [TestCase(new int[] { 30, -99, 2, 10 }, 2, 321, new int[] { 30, -99, 321, 2, 10 })]
        [TestCase(new int[] { 0, 23, -112, 5 }, 4, 15, new int[] { 0, 23, -112, 5, 15 })]
        public void Indexer_WhenAddOneValue_ShouldAddValueByIndex
            (int[] sourceArray, int index, int valueToAdd, int[] expectedArray)
        {
            var myArrayList = new MyArrayListHelper(sourceArray);

            myArrayList[index] = valueToAdd;

            CollectionAssert.AreEqual(expectedArray, myArrayList.ToArray());
        }

        [TestCase(new int[] {  }, 2, -5)]
        [TestCase(new int[] { 99 }, -1, -1)]
        [TestCase(new int[] { 0, -9, 232, 15 }, 5, 321)]
        public void Indexer_WhenAddOneValue_ShouldThrowArgumentException
            (int[] sourceArray, int index, int valueToAdd)
        {
            var myArrayList = new MyArrayListHelper(sourceArray);

            Assert.Throws<ArgumentException>(() =>
            {
                myArrayList[index] = valueToAdd;
            });
        }

        [TestCase(new int[] {  }, -5, new int[] { -5 })]
        [TestCase(new int[] { -5 }, 10, new int[] { -5, 10 })]
        [TestCase(new int[] { 229, -404, 63, -47, -216}, 15, 
            new int[] { 229, -404, 63, -47, -216, 15 })]
        [TestCase(new int[] { 334, -234, 99, -54, -731 }, -2, 
            new int[] { 334, -234, 99, -54, -731, -2 })]
        public void AddBack_WhenAddOneValue_ShouldAddValueToTheEnd
            (int[] sourceArray, int valueToAdd, int[] expectedArray)
        {
            var myArrayList = new MyArrayListHelper(sourceArray);

            myArrayList.AddBack(valueToAdd);

            CollectionAssert.AreEqual(expectedArray, myArrayList.ToArray());
        }

        [TestCase(new int[] { }, new int[] { -5 }, new int[] { -5 })]
        [TestCase(new int[] { 401 }, new int[] { 39, -80 }, new int[] { 401, 39, -80 })]
        [TestCase(new int[] { -317, 190, 12, -479, 3 },
            new int[] { 334, 188, 77, 368, -57 },
            new int[] { -317, 190, 12, -479, 3, 334, 188, 77, 368, -57 })]
        public void AddBack_WhenAddByIEnumerator_ShouldAddValuesToTheEnd
            (int[] sourceArray, int[] valuesToAdd, int[] expectedArray)
        {
            var myArrayList = new MyArrayListHelper(sourceArray);

            myArrayList.AddBack(valuesToAdd);

            CollectionAssert.AreEqual(expectedArray, myArrayList.ToArray());
        }

        [TestCase(new int[] {  }, 3,  new int[] { 3, 3 })]
        [TestCase(new int[] { -12 }, 121, new int[] { -12, 121, 121 })]
        [TestCase(new int[] { 229, -404, 63, -47, -216 }, 1,
            new int[] { 229, -404, 63, -47, -216, 1, 1 })]
        [TestCase(new int[] { 334, -234, 99, -54, -731 }, -23,
            new int[] { 334, -234, 99, -54, -731, -23, -23 })]
        public void AddBack_WhenAddTwoValues_ShouldAddValuesToTheEnd
            (int[] sourceArray, int valueToAdd, int[] expectedArray)
        {
            var myArrayList = new MyArrayListHelper(sourceArray);

            myArrayList.AddBack(valueToAdd);
            myArrayList.AddBack(valueToAdd);

            CollectionAssert.AreEqual(expectedArray, myArrayList.ToArray());
        }

        [TestCase(new int[] { }, 0, -5, new int[] { -5 })]
        [TestCase(new int[] { -5 }, 1, 10, new int[] { -5, 10 })]
        [TestCase(new int[] { -5 }, 0, 10, new int[] { 10, -5 })]
        [TestCase(new int[] { 229, -404, 63, -47, -216 }, 3, 15,
            new int[] { 229, -404, 63, 15, -47, -216 })]
        [TestCase(new int[] { 334, -234, 99, -54, -731 }, 5, -2,
            new int[] { 334, -234, 99, -54, -731, -2 })]
        [TestCase(new int[] { -345, 4, 34, -999, -504, -622 }, 0, -345,
            new int[] { -345, -345, 4, 34, -999, -504, -622 })]
        public void AddByIndex_WhenIndexGreaterThanZero_ShouldAddValueByIndex
            (int[] sourceArray, int index, int valueToAdd, int[] expectedArray)
        {
            var myArrayList = new MyArrayListHelper(sourceArray);

            myArrayList.AddByIndex(index, valueToAdd);

            CollectionAssert.AreEqual(expectedArray, myArrayList.ToArray());
        }

        [TestCase(new int[] { }, -1, 20)]
        [TestCase(new int[] { }, 1, 2)]
        [TestCase(new int[] { 30, -99, 2, 10 }, -2, 5)]
        [TestCase(new int[] { 0, 23, -1, 5 }, 5, 0)]
        public void AddByIndex_WhenIndexIsOutOfArray_ShouldThrowArgumentException
            (int[] sourceArray, int index, int valueToAdd)
        {
            {
                var myArrayList = new MyArrayListHelper(sourceArray);

                Assert.Throws<ArgumentException>(() =>
                {
                    myArrayList.AddByIndex(index, valueToAdd);
                });
            }
        }

        [TestCase(new int[] { }, 0, new int[] { -5 }, new int[] { -5 })]
        [TestCase(new int[] { -5, 3 }, 1, new int[] { 10 }, new int[] { -5, 10, 3 })]
        [TestCase(new int[] { -5 }, 0, new int[] { 10, 111, 12 }, new int[] { 10, 111, 12, -5 })]
        [TestCase(new int[] { 229, -404, 63, -47, -216 }, 3,
            new int[] { -165, -103, 48 },
            new int[] { 229, -404, 63, -165, -103, 48, -47, -216 })]
        public void AddByIndex_WhenIndexAddIEnumerator_ShouldAddValuesByIndex
            (int[] sourceArray, int index, int[] valuesToAdd, int[] expectedArray)
        {
            var myArrayList = new MyArrayListHelper(sourceArray);

            myArrayList.AddByIndex(index, valuesToAdd);

            CollectionAssert.AreEqual(expectedArray, myArrayList.ToArray());
        }

        [TestCase(new int[] { }, -20, new int[] { -20 })]
        [TestCase(new int[] { -51 }, 1, new int[] { 1, -51 })]
        [TestCase(new int[] { 331, 20, -19, 132, -2 }, -21,
            new int[] { -21, 331, 20, -19, 132, -2 })]
        [TestCase(new int[] { 555, -1, 23, -540, -456 }, 99,
            new int[] { 99, 555, -1, 23, -540, -456 })]
        public void AddFront_WhenAddOneValue_ShouldAddValueInTheFront
            (int[] sourceArray, int valueToAdd, int[] expectedArray)
        {
            var myArrayList = new MyArrayListHelper(sourceArray);

            myArrayList.AddFront(valueToAdd);

            CollectionAssert.AreEqual(expectedArray, myArrayList.ToArray());
        }

        [TestCase(new int[] { }, 11, new int[] { 11, 11 })]
        [TestCase(new int[] { 3 }, -121, new int[] { -121, -121, 3 })]
        [TestCase(new int[] { 13, -4, 665, -28, -200 }, 21,
            new int[] { 21, 21, 13, -4, 665, -28, -200 })]
        [TestCase(new int[] { 4, 34, -999, -504, -622 }, -345,
            new int[] { -345, -345, 4, 34, -999, -504, -622 })]
        public void AddFront_WhenAddTwoValues_ShouldAddValuesInTheFront
            (int[] sourceArray, int valueToAdd, int[] expectedArray)
        {
            var myArrayList = new MyArrayListHelper(sourceArray);

            myArrayList.AddFront(valueToAdd);
            myArrayList.AddFront(valueToAdd);

            CollectionAssert.AreEqual(expectedArray, myArrayList.ToArray());
        }

        [TestCase(new int[] {  }, new int[] {  } , new int[] {  })]
        [TestCase(new int[] { -51 }, new int[] { 1, 22 }, new int[] { 1, 22, -51 })]
        [TestCase(new int[] { 331, 20, -19, 132, -2 },
            new int[] { -151, -34, 106 },
            new int[] { -151, -34, 106, 331, 20, -19, 132, -2 })]
        [TestCase(new int[] { 555, -1, 23, -540, -456 },
            new int[] { 394, -38, 4, -491, 267 },
            new int[] { 394, -38, 4, -491, 267, 555, -1, 23, -540, -456 })]
        public void AddFront_WhenAddIEnumerator_ShouldAddValuesInTheFront
            (int[] sourceArray, int[] valuesToAdd, int[] expectedArray)
        {
            var myArrayList = new MyArrayListHelper(sourceArray);

            myArrayList.AddFront(valuesToAdd);

            CollectionAssert.AreEqual(expectedArray, myArrayList.ToArray());
        }

        [TestCase(new int[] { -12 }, -12, 0)]
        [TestCase(new int[] { 3, -34, 219, -5, 31 }, 34, -1)]
        [TestCase(new int[] { 334, -234, 99, -54, -731 }, 334, 0)]
        [TestCase(new int[] { 331, 20, -19, 132, -2 }, 1, -1)]
        [TestCase(new int[] { 229, -404, 63, -47, -216 }, -47, 3)]
        [TestCase(new int[] { 4, 34, -999, -504, -622 }, -622, 4)]
        public void IndexOf_WhenIndexIsValid_ShouldFindIndexOfElement
            (int[] sourceArray, int element, int expected)
        {
            var myArrayList = new MyArrayListHelper(sourceArray);

            int actual = myArrayList.IndexOf(element);

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { -148 }, -148)]
        [TestCase(new int[] { 499, 391 }, 499)]
        [TestCase(new int[] { -109, 23 }, 23)]
        [TestCase(new int[] { -457, 500, 20, -4, 37 }, 500)]
        [TestCase(new int[] { 470, -300, 470, -39, 5, 470 }, 470)]
        public void Max_WhenNoInput_ShouldFindMaxElement
            (int[] sourceArray, int expected)
        {
            var myArrayList = new MyArrayListHelper(sourceArray);

            int actual = myArrayList.Max();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { -148 }, 0)]
        [TestCase(new int[] { 499, 391 }, 0)]
        [TestCase(new int[] { -109, 23 }, 1)]
        [TestCase(new int[] { -457, 20, 500, -4, 37 }, 2)]
        [TestCase(new int[] { 470, -300, 470, -39, 5, 470 }, 0)]
        public void MaxIndex_WhenNoInput_ShouldFindMaxIndex
            (int[] sourceArray, int expected)
        {
            var myArrayList = new MyArrayListHelper(sourceArray);

            int actual = myArrayList.MaxIndex();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]
        public void MaxIndex_WhenEmptyArray_ShouldThrowIndexOutOfRangeException
            (int[] sourceArray)
        {
            var myArrayList = new MyArrayListHelper(sourceArray);

            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                myArrayList.MaxIndex();
            });
        }

        [TestCase(new int[] { 0 }, 0)]
        [TestCase(new int[] { -456, 3 }, -456)]
        [TestCase(new int[] { 80, -18 }, -18)]
        [TestCase(new int[] { 41, -100, -340, 18, -29 }, -340)]
        [TestCase(new int[] { -207, -64, 329, -415, -415, -99 }, -415)]
        public void Min_WhenNoInput_ShouldFindMinElement
            (int[] sourceArray, int expected)
        {
            var myArrayList = new MyArrayListHelper(sourceArray);

            int actual = myArrayList.Min();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { 0 }, 0)]
        [TestCase(new int[] { -456, 3 }, 0)]
        [TestCase(new int[] { 80, -18 }, 1)]
        [TestCase(new int[] { 41, -100, -340, 18, -29 }, 2)]
        [TestCase(new int[] { -207, -64, 329, -415, -415, -99 }, 3)]
        public void MinIndex_WhenNoInput_ShouldFindMinIndex
            (int[] sourceArray, int expected)
        {
            var myArrayList = new MyArrayListHelper(sourceArray);

            int actual = myArrayList.MinIndex();

            Assert.AreEqual(expected, actual);
        }

        [TestCase(new int[] { })]
        public void MinIndex_WhenEmptyArray_ShouldThrowIndexOutOfRangeException
            (int[] sourceArray)
        {
            var myArrayList = new MyArrayListHelper(sourceArray);

            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                myArrayList.MinIndex();
            });
        }

        [TestCase(new int[] { -5 }, -5, new int[] { })]
        [TestCase(new int[] { 0, 10 }, 10, new int[] { 0 })]
        [TestCase(new int[] { 229, -404, 63, -47, -216 }, -216,
            new int[] { 229, -404, 63, -47 })]
        [TestCase(new int[] { 334, -234, 99, -54, -731 }, -731,
            new int[] { 334, -234, 99, -54 })]
        public void RemoveBack_WhenRemoveOneValue_ShouldRemoveValueFromTheEnd
            (int[] sourceArray, int expectedInt, int[] expectedArray)
        {
            var myArrayList = new MyArrayListHelper(sourceArray);

            int actual = myArrayList.RemoveBack();

            Assert.AreEqual(expectedInt, actual);
            CollectionAssert.AreEqual(expectedArray, myArrayList.ToArray());
        }

        [TestCase(new int[] { })]
        public void RemoveBack_WhenLessThenOneIndex_ShouldThrowIndexOutOfRangeException
            (int[] sourceArray)
        {
            var myArrayList = new MyArrayListHelper(sourceArray);

            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                myArrayList.RemoveBack();
            });
        }

        [TestCase(new int[] { -12, 12 }, -12, new int[] { })]
        [TestCase(new int[] { 15, 234, -5 }, 234, new int[] { 15 })]
        [TestCase(new int[] { 229, -404, 63, -47, -216 }, -47,
            new int[] { 229, -404, 63 })]
        [TestCase(new int[] { 334, -234, -54, -54, -731 }, -54,
            new int[] { 334, -234, -54 })]
        public void RemoveBack_WhenRemoveTwoValues_ShouldRemoveValueFromTheEnd
            (int[] sourceArray, int expectedInt, int[] expectedArray)
        {
            var myArrayList = new MyArrayListHelper(sourceArray);

            int actual = myArrayList.RemoveBack();
            actual = myArrayList.RemoveBack();

            Assert.AreEqual(expectedInt, actual);
            CollectionAssert.AreEqual(expectedArray, myArrayList.ToArray());
        }

        [TestCase(new int[] { 2 })]
        public void RemoveBack_WhenOneIndex_ShouldThrowIndexOutOfRangeException
            (int[] sourceArray)
        {
            var myArrayList = new MyArrayListHelper(sourceArray);

            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                myArrayList.RemoveBack();
                myArrayList.RemoveBack();
            });
        }

        [TestCase(new int[] { -12 }, 0, -12, new int[] { })]
        [TestCase(new int[] { 5, 121 }, 1, 121, new int[] { 5 })]
        [TestCase(new int[] { 334, -234, 99, -54, -731 }, 0, 334,
            new int[] { -234, 99, -54, -731 })]
        [TestCase(new int[] { 229, -404, 63, -47, -216 }, 2, 63,
            new int[] { 229, -404, -47, -216 })]
        [TestCase(new int[] { 4, 34, -999, -504, -622 }, 4, -622,
            new int[] { 4, 34, -999, -504 })]
        public void RemoveByIndex_WhenIndexIsValid_ShouldRemoveElement
            (int[] sourceArray, int index, int expectedInt, int[] expectedArray)
        {
            var myArrayList = new MyArrayListHelper(sourceArray);

            int actual = myArrayList.RemoveByIndex(index);

            Assert.AreEqual(expectedInt, actual);
            CollectionAssert.AreEqual(expectedArray, myArrayList.ToArray());
        }

        [TestCase(new int[] { }, 0)]
        [TestCase(new int[] { 1 }, -3)]
        [TestCase(new int[] { -51 }, 2)]
        [TestCase(new int[] { 331, 20, -19, 132, -2 }, -1)]
        [TestCase(new int[] { 555, -1, 23, -540, -456 }, 55)]
        public void RemoveByIndex_WhenInvalidIndex_ShouldThrowIndexOutOfRangeException
            (int[] sourceArray, int index)
        {
            var myArrayList = new MyArrayListHelper(sourceArray);

            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                myArrayList.RemoveByIndex(index);
            });
        }

        [TestCase(new int[] { -5 }, -5, 0, new int[] {  })]
        [TestCase(new int[] { 1, 1 }, 1, 0, new int[] { 1 })]
        [TestCase(new int[] { 0, 10 }, 10, 1, new int[] { 0 })]
        [TestCase(new int[] { 229, 229, 63, -47, -216 }, 229, 0,
            new int[] { 229, 63, -47, -216 })]
        [TestCase(new int[] { 331, 20, -19, 132, -2 }, -22, -1,
            new int[] { 331, 20, -19, 132, -2 })]
        [TestCase(new int[] { 334, -234, 99, -54, -731 }, -731, 4,
            new int[] { 334, -234, 99, -54 })]
        public void RemoveByValue_WhenArrayContainsValue_ShouldRemoveElement
            (int[] sourceArray, int value, int expectedInt, int[] expectedArray)
        {
            var myArrayList = new MyArrayListHelper(sourceArray);

            int actual = myArrayList.RemoveByValue(value);

            Assert.AreEqual(expectedInt, actual);
            CollectionAssert.AreEqual(expectedArray, myArrayList.ToArray());
        }

        [TestCase(new int[] { 2 }, 2, 1, new int[] {  })]
        [TestCase(new int[] { -142, -331 }, -142, 1, new int[] { -331 })]
        [TestCase(new int[] { 67, 67 }, 67, 2, new int[] {  })]
        [TestCase(new int[] { 339, -423, 48, 339, 339 }, 339, 3,
            new int[] { -423, 48 })]
        [TestCase(new int[] { -12, 294, 166, 41, 194 }, 41, 1,
            new int[] { -12, 294, 166, 194 })]
        [TestCase(new int[] { 48, 11, -36, -36, -731 }, -36, 2,
            new int[] { 48, 11, -731 })]
        [TestCase(new int[] { 2, 2, 2, 2, 2 }, 2, 5, new int[] {  } )]
        public void RemoveByValueAll_WhenArrayContainsValue_ShouldRemoveElements
            (int[] sourceArray, int value, int expectedInt, int[] expectedArray)
        {
            var myArrayList = new MyArrayListHelper(sourceArray);

            int actual = myArrayList.RemoveByValueAll(value);

            Assert.AreEqual(expectedInt, actual);
            CollectionAssert.AreEqual(expectedArray, myArrayList.ToArray());
        }

        [TestCase(new int[] { -5 }, -5, new int[] { })]
        [TestCase(new int[] { 0, 10 }, 0, new int[] { 10 })]
        [TestCase(new int[] { 229, -404, 63, -47, -216 }, 229,
            new int[] { -404, 63, -47, -216 })]
        [TestCase(new int[] { 334, -234, 99, -54, -731 }, 334,
            new int[] { -234, 99, -54, -731 })]
        public void RemoveFront_WhenRemoveOneValue_ShouldRemoveValueFromTheFront
            (int[] sourceArray, int expectedInt, int[] expectedArray)
        {
            var myArrayList = new MyArrayListHelper(sourceArray);

            int actual = myArrayList.RemoveFront();

            Assert.AreEqual(expectedInt, actual);
            CollectionAssert.AreEqual(expectedArray, myArrayList.ToArray());
        }

        [TestCase(new int[] { })]
        public void RemoveFront_WhenLessThenOneIndex_ShouldThrowIndexOutOfRangeException
            (int[] sourceArray)
        {
            var myArrayList = new MyArrayListHelper(sourceArray);

            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                myArrayList.RemoveFront();
            });
        }

        [TestCase(new int[] { -12, 12 }, 12, new int[] { })]
        [TestCase(new int[] { 15, 234, -5 }, 234, new int[] { -5 })]
        [TestCase(new int[] { 229, -404, 63, -47, -216 }, -404,
            new int[] { 63, -47, -216 })]
        [TestCase(new int[] { 334, -234, -54, -54, -731 }, -234,
            new int[] { -54, -54, -731 })]
        public void RemoveFront_WhenRemoveTwoValues_ShouldRemoveValueFromTheFront
            (int[] sourceArray, int expectedInt, int[] expectedArray)
        {
            var myArrayList = new MyArrayListHelper(sourceArray);

            int actual = myArrayList.RemoveFront();
            actual = myArrayList.RemoveFront();

            Assert.AreEqual(expectedInt, actual);
            CollectionAssert.AreEqual(expectedArray, myArrayList.ToArray());
        }

        [TestCase(new int[] { 2 })]
        public void RemoveFront_WhenOneIndex_ShouldThrowIndexOutOfRangeException
            (int[] sourceArray)
        {
            var myArrayList = new MyArrayListHelper(sourceArray);

            Assert.Throws<IndexOutOfRangeException>(() =>
            {
                myArrayList.RemoveFront();
                myArrayList.RemoveFront();
            });
        }

        [TestCase(new int[] { -5 }, 1, new int[] { })]
        [TestCase(new int[] { 0, 10 }, 1, new int[] { 0 })]
        [TestCase(new int[] { 20, -40, 555 }, 0, new int[] { 20, -40, 555 })]
        [TestCase(new int[] { 229, -404, 63, -47, -216 }, 3,
            new int[] { 229, -404 })]
        [TestCase(new int[] { 334, -234, 99, -54, -731 }, 5,
            new int[] { })]
        public void RemoveNValuesBack_WhenNNotLessThenZero_ShouldRemoveValuesFromTheEnd
            (int[] sourceArray, int n, int[] expectedArray)
        {
            var myArrayList = new MyArrayListHelper(sourceArray);

            myArrayList.RemoveNValuesBack(n);

            CollectionAssert.AreEqual(expectedArray, myArrayList.ToArray());
        }

        [TestCase(new int[] { }, 1)]
        [TestCase(new int[] { 4 }, -5)]
        [TestCase(new int[] { -12, 294, 166, 41, 194 }, 41)]
        [TestCase(new int[] { 48, -36, -36, -36, -731 }, -3)]
        public void RemoveNValuesBack_WhenNLessThenZeroOrBiggerThanArray_ShouldThrowArgumentException
            (int[] sourceArray, int n)
        {
            var myArrayList = new MyArrayListHelper(sourceArray);

            Assert.Throws<ArgumentException>(() =>
            {
                myArrayList.RemoveNValuesBack(n);
            });
        }

        [TestCase(new int[] { -12, 12 }, 1, new int[] { })]
        [TestCase(new int[] { 15, 234, -5 }, 1, new int[] { 15 })]
        [TestCase(new int[] { 229, -404, 63, -47, -216 }, 2,
            new int[] { 229 })]
        [TestCase(new int[] { 334, -234, -54, -54, -731, 1 }, 3,
            new int[] { })]
        public void RemoveNValuesBack_WhenRemoveTwoTimes_ShouldRemoveValuesFromTheEnd
            (int[] sourceArray, int n, int[] expectedArray)
        {
            var myArrayList = new MyArrayListHelper(sourceArray);

            myArrayList.RemoveNValuesBack(n);
            myArrayList.RemoveNValuesBack(n);

            CollectionAssert.AreEqual(expectedArray, myArrayList.ToArray());
        }

        [TestCase(new int[] { -12 }, 0, 1, new int[] { })]
        [TestCase(new int[] { 5, 121 }, 1, 1, new int[] { 5 })]
        [TestCase(new int[] { 334, -234, 99, -54, -731 }, 0, 3,
            new int[] { -54, -731 })]
        [TestCase(new int[] { 229, -404, 63, -47, -216 }, 2, 0,
            new int[] { 229, -404, 63, -47, -216 })]
        [TestCase(new int[] { 4, 34, -999, -504, -622 }, 0, 5,
            new int[] { })]
        public void RemoveNValuesByIndex_WhenIndexIsValid_ShouldRemoveElementsWithThisIndex
            (int[] sourceArray, int index, int n, int[] expected)
        {
            var myArrayList = new MyArrayListHelper(sourceArray);

            myArrayList.RemoveNValuesByIndex(index, n);

            CollectionAssert.AreEqual(expected, myArrayList.ToArray());
        }

        [TestCase(new int[] { 1 }, 0, 5)]
        [TestCase(new int[] { -51, 0 }, 1, 2)]
        [TestCase(new int[] { 331, 20, -19, 132, -2 }, 0, 6)]
        [TestCase(new int[] { 555, -1, 23, -540, -456 }, 3, 3)]
        public void RemoveNValuesByIndex_WhenInvalidN_ShouldThrowArgumentException
            (int[] sourceArray, int index, int n)
        {
            var myArrayList = new MyArrayListHelper(sourceArray);

            Assert.Throws<ArgumentException>(() =>
            {
                myArrayList.RemoveNValuesByIndex(index, n);
            });
        }

        [TestCase(new int[] { -5 }, 1, new int[] { })]
        [TestCase(new int[] { 0, 10 }, 1, new int[] { 10 })]
        [TestCase(new int[] { 30, -333 }, 2, new int[] { })]
        [TestCase(new int[] { 229, -404, 63, -47, -216 }, 1,
            new int[] { -404, 63, -47, -216 })]
        [TestCase(new int[] { 229, -404, 63, -47, -216 }, 3,
            new int[] { -47, -216 })]
        [TestCase(new int[] { 334, -234, 99, -54, -731 }, 5,
            new int[] { })]
        public void RemoveNValuesFront_WhenRemoveOneTime_ShouldRemoveValuesFromTheFront
            (int[] sourceArray, int n, int[] expectedArray)
        {
            var myArrayList = new MyArrayListHelper(sourceArray);

            myArrayList.RemoveNValuesFront(n);

            CollectionAssert.AreEqual(expectedArray, myArrayList.ToArray());
        }

        [TestCase(new int[] { }, 3)]
        [TestCase(new int[] { -51, 0 }, 3)]
        [TestCase(new int[] { 331, 20, -19, 132, -2 }, -1)]
        [TestCase(new int[] { 555, -1, 23, -540, -456 }, 6)]
        public void RemoveNValuesFront_WhenInvalidIndex_ShouldThrowArgumentException
            (int[] sourceArray, int n)
        {
            var myArrayList = new MyArrayListHelper(sourceArray);

            Assert.Throws<ArgumentException>(() =>
            {
                myArrayList.RemoveNValuesFront(n);
            });
        }

        [TestCase(new int[] { -12, 12 }, 1, new int[] { })]
        [TestCase(new int[] { 15, 234, -5 }, 1, new int[] { -5 })]
        [TestCase(new int[] { 229, -404, 63, -47, -216 }, 2,
            new int[] { -216 })]
        [TestCase(new int[] { 334, -234, -54, -54, -731, 0 }, 3,
            new int[] { })]
        public void RemoveNValuesFront_WhenRemoveTwoValues_ShouldRemoveValueFromTheFront
            (int[] sourceArray, int n, int[] expectedArray)
        {
            var myArrayList = new MyArrayListHelper(sourceArray);

            myArrayList.RemoveNValuesFront(n);
            myArrayList.RemoveNValuesFront(n);

            CollectionAssert.AreEqual(expectedArray, myArrayList.ToArray());
        }

        [TestCase(new int[] { }, new int[] { })]
        [TestCase(new int[] { -5 }, new int[] { -5 })]
        [TestCase(new int[] { 0, 10 }, new int[] { 10, 0 })]
        [TestCase(new int[] { 30, -333 }, new int[] { -333, 30 })]
        [TestCase(new int[] { 229, -404, 63, -47, -216 },
            new int[] { -216, -47, 63, -404, 229 })]
        [TestCase(new int[] { 334, -234, 99, -54, -731, 11 },
            new int[] { 11, -731, -54, 99, -234, 334 })]
        public void Reverse_WhenArrayIsRandom_ShouldReverseArray
            (int[] sourceArray, int[] expected)
        {
            var myArrayList = new MyArrayListHelper(sourceArray);

            myArrayList.Reverse();

            CollectionAssert.AreEqual(expected, myArrayList.ToArray());
        }

        [TestCase(new int[] { 2 }, false,
            new int[] { 2 })]//
        [TestCase(new int[] { -142, -331 }, true,
            new int[] { -331, -142 })]//
        [TestCase(new int[] { 67, 67 }, true,
            new int[] { 67, 67 })]
        [TestCase(new int[] { 339, -423, 48, -14, 339 }, false,
            new int[] { 339, 339, 48, -14, -423 })]
        [TestCase(new int[] { -12, 294, 166, 41 }, true,
            new int[] { -12, 41, 166, 294 })]//
        [TestCase(new int[] { 2, 2, 2, 2, 2 }, true,
            new int[] { 2, 2, 2, 2, 2 })]
        public void Sort_WhenArrayIsRandom_ShouldSortArrayByAscending
            (int[] sourceArray, bool ascending, int[] expected)
        {
            var myArrayList = new MyArrayListHelper(sourceArray);

            myArrayList.Sort(ascending);

            CollectionAssert.AreEqual(expected, myArrayList.ToArray());
        }
    }
}
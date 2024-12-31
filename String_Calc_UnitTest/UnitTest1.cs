using StringCalculator_TDD_Assignment1;
using System.Runtime.CompilerServices;


namespace String_Calc_UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        StringCalculator strcalc = new StringCalculator();
        [TestMethod]
        public void Add_CheckStrEmpty_ReturnsZero()
        {
            int actual_Result = strcalc.Add("");
            int expected_Result = 0;
            Assert.AreEqual(expected_Result, actual_Result);
        }

        [TestMethod]
        public void Add_CheckStrOne_ReturnsOne()
        {
            int actual_Result = strcalc.Add("10");
            int expected_Result = 10;
            Assert.AreEqual(expected_Result, actual_Result);
        }

        [TestMethod]
        public void Add_CheckStrTwo_ReturnsThree()
        {
            int actual_Result = strcalc.Add("17,25");
            int expected_Result = 42;
            Assert.AreEqual(expected_Result, actual_Result);
        }

        [TestMethod]
        public void Add_CheckStr_N_Numbers_ReturnsResult()
        {
            int actual_Result = strcalc.Add("0,1,2,3,4,5,6,7,8");
            int expected_Result = 36;
            Assert.AreEqual(actual_Result, expected_Result);
        }

        [TestMethod]

        public void Add_Check_NumberStr_With_Newline_ReturnsResult()
        {
            int actual_Result = strcalc.Add("0\n1\n2\n3\n4\n5\n6\n7\n8");
            int expected_Result = 36;
            Assert.AreEqual(actual_Result, expected_Result);
            actual_Result = strcalc.Add("0\n1,2\n3,4\n5\n6\n7\n8");
            Assert.AreEqual(36, expected_Result);
        }

        [TestMethod]
        public void Add_Check_NumberStr_With_Diff_Delimiters_ReturnsResult()
        {
            int actual_Result = strcalc.Add("//;\n1;2\n3\n4\n5\n6;8");
            int expected_Result = 29;
            Assert.AreEqual(actual_Result, expected_Result);
            Assert.AreEqual(15, strcalc.Add("//*\n1\n2,3*4,5"));
        }

        [TestMethod]
        public void Add_Check_Str_With_Negative_Number_ThrowEXception()
        {
            try
            {
                strcalc.Add("1,-2,3,4,5");
                throw new Exception();
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Negatives are not allowed", ex.Message);
            }
        }

        [TestMethod]

        public void Add_Check_Str_With_MultipleNegative()
        {
            try
            {
                strcalc.Add("1,-2,3,-4, 5");
                throw new Exception();
            }
            catch (Exception ex)
            {
                Assert.AreEqual("Negatives are not allowed : -2-4", ex.Message);
            }
        }
        [TestMethod]

        public void Add_Check_Str_GreaterThanThousand()
        {
            Assert.AreEqual(2, strcalc.Add("2,1001"));
            Assert.AreEqual(1070, strcalc.Add("1,2001,3,400,123456789,666"));
        }

        [TestMethod]
        public void TestLongSeparators()
        {
            Assert.AreEqual(15, strcalc.Add("//[<->]\n1<->2,3<->4<->5"));
            Assert.AreEqual(10, strcalc.Add("//[**][+++][=====]\n1**2+++3=====4"));
        }
        [TestMethod]

        public void Add_Check_Str_WithDifferentLength_SameDelimiters()
        {
            Assert.AreEqual(6,  strcalc.Add("//[***]\n1***2***3"));
            Assert.AreEqual(21, strcalc.Add("//[*][**][***][****]\n1,2*3**4***5****6"));
            Assert.AreEqual(21, strcalc.Add("//[****][***][**][*]\n1,2*3**4***5****6"));
            Assert.AreEqual(21, strcalc.Add("//[**++][***][++][*]\n1,2*3**4***5**++6"));
            Assert.AreEqual(21, strcalc.Add("//[++][***][**++]\n1,2++3***4***5**++6"));
        }

        [TestMethod]

        public void Add_Check_Str_WithMultipleDelimiters()
        {
            Assert.AreEqual(6, strcalc.Add("//[*][%]\n1*2%3"));
        }

        [TestMethod]

        public void Add_Check_Str_WithMultiple_DiferentLength_Delimiters()
        {
            Assert.AreEqual(6, strcalc.Add("//[**][%%]\n1**2%%3"));
        }

        [TestMethod]

        public void Add_Str_WithBackSlashAndSeparators()
        {
            Assert.AreEqual(200, strcalc.Add("//[\t][**]\n75\t1234\n25**100"));

        }
    }
}
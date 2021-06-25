using IIG.PasswordHashingUtils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;



namespace PassTest
{
    [TestClass]
    public class UnitTest1
    {

        public static string oneStr;
        public static string passOverFlow;
        public static string saltOverFlow;
        

        [ClassInitialize()]
        public static void InitData(TestContext context)
        {
            
            oneStr = "one";
            saltOverFlow = "ಠ_ಠ";
            passOverFlow = "┻━┻ ┻━┻ ︵ ヽ(°□°ヽ)";

        }


        //_____________________________ pass is Not a string _______________________
        [TestMethod]
        public void Route_1_6_7()
        {
            String result = PasswordHasher.GetHash(null);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void Route_1_5_6_7()
        {
            String result = PasswordHasher.GetHash(null, null, 3);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void Route_1_2_4_5_6_7()
        {
            String result = PasswordHasher.GetHash(null, oneStr, 6);
            Assert.IsNull(result);
        }

        [TestMethod]
        public void Route_1_2_3_4_6_7()
        {
            String result = PasswordHasher.GetHash(null, saltOverFlow);

            Assert.IsNull(result);
        }

        [TestMethod]
        public void Route_1_2_4_6_7()
        {
            String result = PasswordHasher.GetHash(null, oneStr);
            Assert.IsNull(result);
        }

        //___________________________________ pass is string _________________________


        [TestMethod]
        public void Route_1_2_4_6_8_10()
        {
            String result = PasswordHasher.GetHash("oneTwo", "oneTwo");
            Assert.IsNotNull(result);
        }



        [TestMethod]
        public void Route_1_2_4_5_6_8_10()
        {
            String result = PasswordHasher.GetHash(oneStr, oneStr, 3);
            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void Route_1_5_6_8_10()
        {
            String result = PasswordHasher.GetHash(oneStr, null, 6);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Route_1_2_3_4_6_8_10()
        {
            String result = PasswordHasher.GetHash(oneStr, saltOverFlow);
            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void Route_1_2_3_4_5_6_7_8_10()
        {
            String result = PasswordHasher.GetHash(oneStr, saltOverFlow, 6);
            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void Route_1_2_4_6_8_9_10()
        {
         
            String result = PasswordHasher.GetHash(passOverFlow, oneStr);
            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void Route_1_6_8_10_noSt()
        {
            String result = PasswordHasher.GetHash(oneStr);
            Assert.IsNotNull(result);
        }


        [TestMethod]
        public void Route_1_6_8_10_salt_StringEmpty()
        {
            String result = PasswordHasher.GetHash("oneTwo", string.Empty);
            Assert.IsNotNull(result);
        }




    }
}

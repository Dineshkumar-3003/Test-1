using CaliberHomes.TestCases;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaliberHomes
{
    public class Class1
    {
        [SetUp]
        public void Initializer()
        {

        }
        [Test]
        //public void Caliber()
        //{
        //    CaliberCase1.CaliberCase();
        //}
        //[TearDown]

        public void LeadershipPO()
        {
            LeadershipCase.LeadershipTC();
        }
        public void CloseBrowser()
        {

        }
    }
}

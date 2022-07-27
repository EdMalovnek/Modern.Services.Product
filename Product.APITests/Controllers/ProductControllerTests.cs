using Microsoft.VisualStudio.TestTools.UnitTesting;
using Product.API.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.API.Controllers.Tests
{
    [TestClass()]
    public class ProductControllerTests
    {
        //Ran out of time to implement these but more than happy to run through what i would do over a call.

        [TestMethod()]
        public void CreateTest()
        {
            /* Edge Cases we need to test:
             * Passing through an invalid model
             * Returning interpretable results when the item is created
             */
            Assert.Fail();
        }

        [TestMethod()]
        public void UpdateTest()
        {
            /* Edge Cases we need to test:
             * Passing through an invalid model
             * Account the we return an error result when an itemcode isnt found
             * Return a correct result when the item is updated
              */
            Assert.Fail();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace PortScanner.Tests
{
   public class BaseTestSetup
    {
        [SetUp]
        public void SetUp()
        {
            //Do generic Stuff 
        }

        [TearDown]
        public void TearDown()
        {
            // Do generic stuff 
        }

    }
}

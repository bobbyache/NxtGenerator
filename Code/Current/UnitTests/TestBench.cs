using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace UnitTestFile
{
    [TestClass]
    public class FileTest
    {
        // http://testdriven.net/
		
        // MOQ: Quick Start: https://github.com/Moq/moq4/wiki/Quickstart
        // Ninject: http://www.ninject.org/wiki.html
        // Ninject: http://www.ninject.org/learn.html

        // http://codeclimber.net.nz/archive/2009/10/23/10-resources-to-learn-moq.aspx

        // READ THIS: http://stephenwalther.com/archive/2008/06/12/tdd-introduction-to-moq


        [TestMethod]
        [DeploymentItem(@"Files\helloworld.txt")]
        public void MyTest()
        {
            Assert.IsTrue(File.Exists(@"helloworld.txt"));
        }
    }
}

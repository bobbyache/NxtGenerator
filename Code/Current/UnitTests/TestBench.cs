using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using UnitTests.Helpers;
using System.Data;
using Nxt.Domain.Generator;

// http://testdriven.net/
// MOQ: Quick Start: https://github.com/Moq/moq4/wiki/Quickstart
// Ninject: http://www.ninject.org/wiki.html
// Ninject: http://www.ninject.org/learn.html
// http://codeclimber.net.nz/archive/2009/10/23/10-resources-to-learn-moq.aspx
// READ THIS: http://stephenwalther.com/archive/2008/06/12/tdd-introduction-to-moq
//[TestMethod]
//[DeploymentItem(@"Files\helloworld.txt")]
//public void MyTest()
//{
//    Assert.IsTrue(File.Exists(@"helloworld.txt"));
//}

namespace UnitTestFile
{
    [TestClass]
    [DeploymentItem(@"Files\DataSets\People.nxtdata")]
    public class TestBench
    {
        private DataTable peopleTable = null;
        private string peopleDelimitedBlueprint_Default = "@{First},@{Last},@{Date},@{Number}\n";
        private string peopleDelimitedBlueprint_Pattern1 = "<%=First%>,<%=Last%>,<%=Date%>,<%=Number%>\n";

        [TestInitialize]
        public void LoadData()
        {
            string peoplePath = @"People.nxtdata";
            this.peopleTable = DatasetLoader.LoadFileData(peoplePath);
        }

        [TestMethod]
        public void GenerateOutput()
        {
            OutputGenerator generator = new OutputGenerator(peopleTable, peopleDelimitedBlueprint_Default);
            string output = generator.Generate();
            Assert.IsTrue(output.Length > 0);
        }

        [TestMethod]
        public void GenerateOutput_Different_Prefix_Postfix_Pattern()
        {
            OutputGenerator generator = new OutputGenerator(peopleTable, peopleDelimitedBlueprint_Pattern1);
            generator.PlaceholderPrefix = "<%=";
            generator.PlaceholderPostfix = "%>";

            string output = generator.Generate();
            Assert.IsTrue(output.Length > 0);
        }

        [TestMethod]
        public void GenerateOutput_Check_Values()
        {
            OutputGenerator generator = new OutputGenerator(peopleTable, peopleDelimitedBlueprint_Pattern1);
            generator.PlaceholderPrefix = "<%=";
            generator.PlaceholderPostfix = "%>";
            string output = generator.Generate();

            PeopleOutputReader reader = new PeopleOutputReader();
            string[,] matrixOutput = reader.CommaDelimitedLines(output, 3, 4);

            Assert.IsTrue(matrixOutput[0, 0] == "Andrew");
            Assert.IsTrue(matrixOutput[0, 1] == "Miller");
            Assert.IsTrue(matrixOutput[0, 2] == "2016-03-12T00:00:00+02:00");
            Assert.IsTrue(matrixOutput[0, 3] == "34");
        }
    }
}

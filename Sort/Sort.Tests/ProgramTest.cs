using System.Collections.Generic;
// <copyright file="ProgramTest.cs">Copyright ©  2016</copyright>

using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sort;

namespace Sort.Tests
{
    [TestClass]
    [PexClass(typeof(Program))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class ProgramTest
    {

        [PexMethod]
        public void write_textfile(List<person> all, string new_path)
        {
            Program.write_textfile(all, new_path);
            // TODO: add assertions to method ProgramTest.write_textfile(List`1<person>, String)
        }
    }
}

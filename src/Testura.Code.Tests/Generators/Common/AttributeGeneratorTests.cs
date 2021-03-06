﻿using System.Collections.Generic;
using NUnit.Framework;
using Testura.Code.Generators.Common;
using Testura.Code.Generators.Common.Arguments.ArgumentTypes;
using Testura.Code.Models;
using Assert = NUnit.Framework.Assert;

namespace Testura.Code.Tests.Generators.Common
{
    [TestFixture]
    public class AttributeGeneratorTests
    {
        [Test]
        public void Create_WhenNotProvidingAnyAttributes_ShouldGetEmptyString()
        {
            Assert.AreEqual(string.Empty, AttributeGenerator.Create().ToString());
        }

        [Test]
        public void Create_WhenCreatingWithSingleAttrbute_ShoulGenerateCorrectCode()
        {
            Assert.AreEqual("[Test]", AttributeGenerator.Create(new Attribute("Test", new List<IArgument>())).ToString());
        }

        [Test]
        public void Create_WhenCreatingWithMultipleAttributes_ShoulGenerateCorrectCode()
        {
            Assert.AreEqual("[Test][TestCase]", AttributeGenerator.Create(new Attribute("Test"), new Attribute("TestCase")).ToString());
        }

        [Test]
        public void Create_WhenCreatingAttributeWithParameters_ShoulGenerateCorrectCode()
        {
            Assert.AreEqual("[Test(1,2)]", AttributeGenerator.Create(new Attribute("Test", new List<IArgument>() { new ValueArgument(1), new ValueArgument(2)})).ToString());
        }


    }
}

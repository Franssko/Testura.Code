﻿using System.Collections.Generic;
using NUnit.Framework;
using Testura.Code.Generators.Class;
using Testura.Code.Models;
using Assert = NUnit.Framework.Assert;

namespace Testura.Code.Tests.Generators.Class
{
    [TestFixture]
    class PropertyGeneratorTests
    {
        [Test]
        public void Create_WhenCreatingPropertyWithOnlyGet_ShouldHaveNoSet()
        {
            Assert.AreEqual("intMyProperty{get;}", PropertyGenerator.Create(new Property("MyProperty", typeof(int), PropertyTypes.Get)).ToString());   
        }

        [Test]
        public void Create_WhenCreatingPropertyWithOnlyGetAndSet_ShouldHaveBothGetAndSet()
        {
            Assert.AreEqual("intMyProperty{get;set;}", PropertyGenerator.Create(new Property("MyProperty", typeof(int), PropertyTypes.GetAndSet)).ToString());
        }

        [Test]
        public void Create_WhenCreatingPropertyWithAttribute_ShouldHaveAttribute()
        {
            Assert.AreEqual("[Test]intMyProperty{get;set;}", PropertyGenerator.Create(new Property("MyProperty", typeof(int), PropertyTypes.GetAndSet, new List<Modifiers>(), new List<Attribute> { new Attribute("Test")})).ToString());
        }

        [Test]
        public void Create_WhenCreatingPropertyWithModifer_ShouldHaveModifier()
        {
            Assert.AreEqual("publicstaticintMyProperty{get;set;}", PropertyGenerator.Create(new Property("MyProperty", typeof(int), PropertyTypes.GetAndSet, new List<Modifiers>() { Modifiers.Public, Modifiers.Static })).ToString());
        }
    }
}

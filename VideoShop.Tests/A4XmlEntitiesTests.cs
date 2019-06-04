using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Owasp.Data;

namespace VideoShop.Tests
{
    [TestClass]
    public class A4XmlEntitiesTests
    {
        [TestMethod]
        public void GoodXmlRead()
        {
            //Arrange
            string markup =
            @"<!DOCTYPE Root [  
            <!ENTITY anEntity ""Expands to more than 30 characters"">  
            <!ELEMENT Root (#PCDATA)>  
            ]>  
            <Root>Content &anEntity;</Root>";

            //Act
            string result = XmlUtils.ReadXml(markup, 100);

            //Assert
            Assert.AreEqual("success", result);
        }

        [TestMethod]
        public void BadXmlRead()
        {
            //Arrange
            string markup =
            @"<!DOCTYPE lolz[
            <!ENTITY lol ""lol"">
            <!ELEMENT lolz (#PCDATA)>
            <!ENTITY lol1 ""&lol;&lol;&lol;&lol;&lol;&lol;&lol;&lol;&lol;&lol;"">
            <!ENTITY lol2 ""&lol1;&lol1;&lol1;&lol1;&lol1;&lol1;&lol1;&lol1;&lol1;&lol1;"">
            <!ENTITY lol3 ""&lol2;&lol2;&lol2;&lol2;&lol2;&lol2;&lol2;&lol2;&lol2;&lol2;"">
            <!ENTITY lol4 ""&lol3;&lol3;&lol3;&lol3;&lol3;&lol3;&lol3;&lol3;&lol3;&lol3;""> 
            <!ENTITY lol5 ""&lol4;&lol4;&lol4;&lol4;&lol4;&lol4;&lol4;&lol4;&lol4;&lol4;"">
            <!ENTITY lol6 ""&lol5;&lol5;&lol5;&lol5;&lol5;&lol5;&lol5;&lol5;&lol5;&lol5;"">
            <!ENTITY lol7 ""&lol6;&lol6;&lol6;&lol6;&lol6;&lol6;&lol6;&lol6;&lol6;&lol6;"">
            <!ENTITY lol8 ""&lol7;&lol7;&lol7;&lol7;&lol7;&lol7;&lol7;&lol7;&lol7;&lol7;"">
            <!ENTITY lol9 ""&lol8;&lol8;&lol8;&lol8;&lol8;&lol8;&lol8;&lol8;&lol8;&lol8;"">
            ]>
            <lolz>&lol9;</lolz> ";

            //Act
            string result = XmlUtils.ReadXml(markup, long.MaxValue);

            //Assert
            Assert.IsTrue(result.StartsWith("Success"));
        }
    }
}

using Haosen.Common.xml;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace Haosen.Api.Test
{
    [TestClass]
    public class XmlHelperTest
    {
        [TestMethod]
        public void TestSerialize()
        {
            var dom = new Computers();
            dom.Computer = new List<Computer>();
            dom.Computer.Add(new Computer() { name = "Lenovo", price = 5000, id="0001",description="联想" });
            dom.Computer.Add(new Computer() { name = "Dell", price = 10000, id = "0002", description = "戴尔" });

            var str = XmlHelper.Serialize<Computers>(dom);

            Assert.IsTrue(!string.IsNullOrEmpty(str));
        }

        [TestMethod]
        public void TestDeSerialize()
        {
            string xml = "<Computers xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\"><Computer id=\"0001\" description=\"联想\"><name>Lenovo</name><price>5000</price></Computer><Computer id=\"0002\" description=\"戴尔\"><name>Dell</name><price>10000</price></Computer></Computers>";
            var item = XmlHelper.Deserialize<Computers>(xml);

            Assert.IsTrue(item.Computer.Count == 2);
        }
    }

    [XmlRoot(ElementName = "Computers")]
    public class Computers
    {
        [XmlElement(ElementName = "Computer")]
        public List<Computer> Computer { get; set; }
    }

    public class Computer
    {
        [XmlElement(ElementName = "name")]
        public string name { get; set; }

        [XmlElement(ElementName = "price")]
        public decimal price { get; set; }

        [XmlAttribute(AttributeName = "id")]
        public string id { get; set; }

        [XmlAttribute(AttributeName = "description")]
        public string description { get; set; }
    }
}

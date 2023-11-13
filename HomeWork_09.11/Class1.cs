using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace HomeWork_09._11
{
    internal class Class1
    {
        public static void Main(string[] args)
        {

            var people = new List<Person>();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("C:\\Users\\1\\source\\repos\\HomeWork_09.11\\HomeWork_09.11\\people.xml");
            XmlElement? xRoot = xmlDoc.DocumentElement;

            XmlElement personElem = xmlDoc.CreateElement("person");

            XmlAttribute nameAttr = xmlDoc.CreateAttribute("name");

            XmlElement sizeElem = xmlDoc.CreateElement("size");
            XmlElement formeElem = xmlDoc.CreateElement("forme");
            XmlElement tasteElem = xmlDoc.CreateElement("taste");
            XmlElement fillingElem = xmlDoc.CreateElement("filling");
            XmlElement cookMethodElem = xmlDoc.CreateElement("cookMethod");

            XmlText nameText = xmlDoc.CreateTextNode("с маком");
            XmlText sizeText = xmlDoc.CreateTextNode("Средняя");
            XmlText formeText = xmlDoc.CreateTextNode("Прямоугольная");
            XmlText tasteText = xmlDoc.CreateTextNode("9");
            XmlText fillingText = xmlDoc.CreateTextNode("Да");
            XmlText cookMethodText = xmlDoc.CreateTextNode("Испечённая");

            nameAttr.AppendChild(nameText);
            sizeElem.AppendChild(sizeText);
            formeElem.AppendChild(formeText);
            tasteElem.AppendChild(tasteText);
            fillingElem.AppendChild(fillingText);
            cookMethodElem.AppendChild(cookMethodText);

            personElem.Attributes.Append(nameAttr);

            personElem.AppendChild(sizeElem);
            personElem.AppendChild(formeElem);
            personElem.AppendChild(tasteElem);
            personElem.AppendChild(fillingElem);
            personElem.AppendChild(cookMethodElem);

            xRoot?.AppendChild(personElem);

            if (xRoot != null)
            {
                foreach (XmlElement xnode in xRoot)
                {
                    Person person = new Person();
                    XmlNode? attr = xnode.Attributes.GetNamedItem("name");
                    person.Name = attr?.Value;
                    foreach (XmlNode childNode in xnode.ChildNodes)
                    {
                        if (childNode.Name == "size")
                        {
                            person.Size = childNode.InnerText;
                        }
                        if (childNode.Name == "forme")
                        {
                            person.Forme = childNode.InnerText;
                        }
                        if (childNode.Name == "taste")
                        {
                            person.Taste = int.Parse(childNode.InnerText);
                        }
                        if (childNode.Name == "filling")
                        {
                            person.Filling = childNode.InnerText;
                        }
                        if (childNode.Name == "cookMethod")
                        {
                            person.CookMethod = childNode.InnerText;
                        }

                    }
                    people.Add(person);
                }
                foreach (var person in people)
                {
                    Console.WriteLine("Название: " + person.Name + ", размер: " + person.Size +
                        ", форма: " + person.Forme + ", вкус: " + person.Taste +
                        ", начинка есть: " + person.Filling + ", способ приготовления: " + person.CookMethod);
                }
            }
        }
    }
}


using System;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace XMLDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            DeserializeXmlFileToObject();
            Console.WriteLine("XML File created...");
        }
        
        private static void SerializeObjectToXMLFile()
        {
            var member = new Member
            {
                Name = "John",
                Email = "john@gmail.com",
                Age = 30,
                JoiningDate = DateTime.Now,
                IsPlatimumMember = false
            };
            
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Member));

            using (var writer = new StreamWriter(@"C:\Users\akash\source\repos\XMLDemo\XMLDemo\XMLFiles\sample01.xml"))
            { 
                xmlSerializer.Serialize(writer, member);
                var xmlContent = writer.ToString();
                Console.WriteLine(xmlContent);
                DeserializeXMLStringToObject(xmlContent);
            }
        
        }

        private static void DeserializeXMLStringToObject(string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof (Member));
            using (var reader = new StringReader(xmlString))
            {
                var member = (Member) xmlSerializer.Deserialize(reader);
            }
        }

        private static void SerializeListToXMLFile()
        {
            var memberList = new List<Member>
            {
                new Member
                {
                    Name = "John",
                    Email = "john@gmail.com",
                    Age = 30,
                    JoiningDate = DateTime.Now,
                    IsPlatimumMember = false
                },
                new Member
                {
                    Name = "Peter",
                    Email = "peter@gmail.com",
                    Age = 35,
                    JoiningDate = DateTime.Now,
                    IsPlatimumMember = true
                },
                new Member
                {
                    Name = "David",
                    Email = "david@gmail.com",
                    Age = 25,
                    JoiningDate = DateTime.Now,
                    IsPlatimumMember = true
                },
                new Member
                {
                    Name = "George",
                    Email = "george@gmail.com",
                    Age = 29,
                    JoiningDate = DateTime.Now,
                    IsPlatimumMember = false
                }
            };

            var xmlSerializer = new XmlSerializer(typeof(List<Member>));

            using (var writer = new StreamWriter(@"C:\Users\akash\source\repos\XMLDemo\XMLDemo\XMLFiles\sample02.xml"))
            {
                xmlSerializer.Serialize (writer, memberList);
            }
        }

        private static void DeserializeXMLFileToList()
        {
            var xmlSerializer = new XmlSerializer(typeof(List<Member>));
            using (var reader = new StreamReader(@"C:\Users\akash\source\repos\XMLDemo\XMLDemo\XMLFiles\sample02.xml"))
            {
                var members = (List<Member>)xmlSerializer.Deserialize(reader);
            }
        }

        private static void DeserializeXmlFileToObject()
        {
            var xmlSerializer = new XmlSerializer (typeof(Member));
            using (var reader = new StreamReader(@"C:\Users\akash\source\repos\XMLDemo\XMLDemo\XMLFiles\sample01.xml")) 
            {
                var member = (Member)xmlSerializer.Deserialize(reader);
            }
        }
    }
}


/*Member.cs */
using System;
using System.Xml.Serialization;

namespace XMLDemo
{
    
    public class Member
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public int Age { get; set; }
        
        public DateTime JoiningDate { get; set; }

        public bool IsPlatimumMember { get; set; }
    }
}

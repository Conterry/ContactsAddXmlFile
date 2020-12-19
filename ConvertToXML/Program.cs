using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ConvertToXML
{

    class Program
    {
        const string path = "XmlSave";
        static private List<Contact> contacts = new List<Contact>();
        public static Contact AddContact(Contact contact)
        {
            contacts.Add(contact);
            return contact;
        }

        public static void SaveToXml()
        {
            var XmlSerializer = new XmlSerializer(typeof(List<Contact>));
            using(StreamWriter sw = new StreamWriter(path))
            {
                foreach(Contact c in contacts)
                {
                    XmlSerializer.Serialize(sw, contacts);
                }
            }

        }

        public static bool IsEnd = false;
        static void Main(string[] args)
        {
            while (!IsEnd)
            {
                string InputComand = Console.ReadLine();
                if(InputComand == "/add contact")
                {
                    Contact contact = new Contact();
                    while (contact.Name == null || contact.Number == null) {
                        string InputContact = Console.ReadLine();
                        if (InputContact == "/add name")
                        {
                            Console.WriteLine("new name: ");
                            string InputValue = Console.ReadLine();
                            contact.Name = InputValue;
                        }
                        else if (InputContact == "/add number")
                        {
                            Console.WriteLine("new number: ");
                            string InputValue = Console.ReadLine();
                            contact.Number = InputValue;
                        }
                        else
                        {
                            Console.WriteLine("Incorect command for contacts. Write /add number or /add name to do some with this information");
                        }
                    }
                    AddContact(contact);
                }
                else if(InputComand == "/end")
                {
                    IsEnd = true;
                }
                else
                {
                    Console.WriteLine("pls write /add contact to add contact");
                }
                
            }
            SaveToXml();
        }
    }
}

using System;
using System.Xml;
using System.IO;
using System.Xml.Serialization;
using TraineeEmployeeClient.MyManager;

namespace TraineeEmployeeClient
{
    class Program
    {
        static void Main(string[] args)
        {
            TraineeEmployeeClient.MyManager.EmployeeClient manager = new EmployeeClient();

            Console.WriteLine(manager.SalaryCalculator("1"));

            TraineeEmployeeClient.MyTrainee.EmployeeClient trainee = new MyTrainee.EmployeeClient();

            Console.WriteLine(trainee.SalaryCalculator("1"));

            //Console.WriteLine(SerializeOperations.XMLSerializeEmployee(emp));

            //Employee e =(Employee) SerializeOperations.XMLDeSerializeEmployee(SerializeOperations.XMLSerializeEmployee(emp),typeof(Employee));

            Console.ReadLine();
        }
        class SerializeOperations
        {
            public static string XMLSerializeEmployee(Employee employee)
            {
                StringWriter stringwriter = new StringWriter();
                XmlWriter xmlwriter = XmlWriter.Create(stringwriter);

                System.Xml.Serialization.XmlSerializer ser = new System.Xml.Serialization.XmlSerializer(typeof(Employee));
                ser.Serialize(xmlwriter, employee);

                return stringwriter.ToString();
            }

            public static object XMLDeSerializeEmployee(string xml, Type objectType)
            {
                StringReader strReader = new StringReader(xml);
                XmlSerializer serializer = new XmlSerializer(objectType);
                XmlTextReader xmlReader = new XmlTextReader(strReader); 
                Object objectToReturn = serializer.Deserialize(xmlReader);

                return objectToReturn;
            }
        }
    }
}

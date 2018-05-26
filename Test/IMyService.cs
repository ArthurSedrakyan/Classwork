using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Test
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IMyService
    {
        [OperationContract]
        Result SorcePerson(Person person);
        // TODO: Add your service operations here
    }

    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    // You can add XSD files into the project. After building the project, you can directly use the data types defined there, with the namespace "Test.ContractType".
    [DataContract]
    public class Person
    {
        private int id;
        private string name;
        private double price;
        private string group;

        [DataMember]
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        [DataMember]
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        [DataMember]
        public string Group
        {
            get { return group; }
            set { group = value; }
        }

        [DataMember]
        public double Price
        {
            get { return price; }
            set { price = value; }
        }
    }


    [DataContract]
    public struct Result
    {
        public Result(string messege, string answer)
        {
            this.messege = messege;
            this.answer = answer;
        }

        private string messege;
        private string answer;

        [DataMember]
        public string Messege
        {
            get { return messege; }
            set { messege = value; }
        }

        [DataMember]
        public string Answer
        {
            get { return answer; }
            set { answer = value; }
        }
    }
}

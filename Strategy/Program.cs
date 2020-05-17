using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy
{
    class Program
    {
        interface ISerializable
        {
            void Serialize(string str);
            void DeSerialize(string str);
        }

        class XmlSerializer : ISerializable
        {
            public void DeSerialize(string str)
            {
                Console.WriteLine("Xml ters serileştirme");
            }

            public void Serialize(string str)
            {
                Console.WriteLine("Xml serileştirme");
            }
        }

        class JsonSerializer : ISerializable
        {
            public void DeSerialize(string str)
            {
                Console.WriteLine("Json ters serileştirme");
            }

            public void Serialize(string str)
            {
                Console.WriteLine("Json serileştirme");
            }
        }

        class Serializer
        {
            ISerializable _serializer;
            public Serializer(ISerializable serializer)
            {
                _serializer = serializer;
            }

            public void Serialize(string str)
            {
                _serializer.Serialize(str);
            }

            public void DeSerialize(string str)
            {
                _serializer.DeSerialize(str);
            }
        }

        //Bir işlem için birden fazla farklı yöntemlerin uygulanabileceği durumlar mevcuttur. İşte bu tarz durumlarda hangi yöntemin uygulanacağını, hangisinin devreye sokulacağını Strategy Design Pattern ile gerçekleştirebiliyoruz.
        static void Main(string[] args)
        {
            Serializer serializer = new Serializer(new JsonSerializer());
            serializer.Serialize("test");
            serializer.DeSerialize("test");

            Console.ReadLine();
        }
    }
}

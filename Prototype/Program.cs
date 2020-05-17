using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prototype
{
    //prototype
    abstract class AdventurePrototype
    {
        public abstract AdventurePrototype Clone();
    }

    //Concrete prototype
    class Product : AdventurePrototype
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public Product(int productId, string name, double price)
        {
            ProductId = productId;
            Name = name;
            Price = price;
        }

        public override AdventurePrototype Clone()
        {
            return MemberwiseClone() as AdventurePrototype;
        }
    }

    class Person : AdventurePrototype
    {
        public string Name { get; set; }

        public Person(string name)
        {
            Name = name;
        }

        public override AdventurePrototype Clone()
        {
            return MemberwiseClone() as AdventurePrototype;
        }
    }

    class Adventure
    {
        public List<AdventurePrototype> Entities { get; set; }
        public Adventure()
        {
            Entities = new List<AdventurePrototype>();
        }
    }

    //Shallow Copy ve Deep Copy olmak üzere iki tür nesne kopyalama işlemi mevcuttur. Shallow Copy ile nesnelerin bellekteki adresleri kopyalanmakta dolayısıyla yüzeysel olarak bir kopyalama işlemi gerçekleştirileceği için yeni bir nesne üretilmemekte, var olan nesne üzerine referanslar ile işaretleme yapılmaktadır. Anlayacağınız Shallow Copy, Prototype Design Pattern için uygun tercih olmayacaktır.

    //Deep Copy ile nesneler birebir kopyalanabilmekte ve bu kopya sonucu ile asıl nesne farklı referanslar ile işaretlenebilmektedir. İşte Prototype Design Pattern’de bu kopyalama yaklaşımında bulunmak en doğrusudur.
    class Program
    {
        static void Main(string[] args)
        {
            Adventure adventure = new Adventure();

            Product product = new Product(100, "test", 350);
            adventure.Entities.Add(product);

            Person person = new Person("test");
            adventure.Entities.Add(person);

            adventure.Entities.Add(product.Clone() as Product);
            adventure.Entities.Add(person.Clone() as Person);
        }
    }
}

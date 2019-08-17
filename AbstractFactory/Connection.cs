using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactory
{
    public abstract class Connection
    {
        public abstract bool Connect();
        public abstract bool DisConnect();
        public abstract string State { get; }
    }

    public abstract class Command
    {
        public abstract void Execute(string query);
    }

    public class DB2Connection : Connection
    {
        public override string State => "Open";

        public override bool Connect()
        {
            Console.WriteLine("Db2 açılacak");
            return true;
        }

        public override bool DisConnect()
        {
            Console.WriteLine("Db2 kapatılacak");
            return true;
        }
    }

    public class InterBaseConnection : Connection
    {
        public override string State => "Open";

        public override bool Connect()
        {
            Console.WriteLine("InterBase açılacak");
            return true;
        }

        public override bool DisConnect()
        {
            Console.WriteLine("InterBase kapatılacak");
            return true;
        }
    }

    public class Db2Command : Command
    {
        public override void Execute(string query)
        {
            Console.WriteLine("Db2 sorgusu çalıştırıldı");
        }
    }

    public class InterBaseCommand : Command
    {
        public override void Execute(string query)
        {
            Console.WriteLine("InterBase sorgusu çalıştırıldı");
        }
    }

    public abstract class DatabaseFactory
    {
        public abstract Connection CreateConnection();
        public abstract Command CreateCommand();
    }

    public class Db2Factory : DatabaseFactory
    {
        public override Command CreateCommand()
        {
            return new Db2Command();
        }

        public override Connection CreateConnection()
        {
            return new DB2Connection();
        }
    }

    public class InterBaseFactory : DatabaseFactory
    {
        public override Command CreateCommand()
        {
            return new InterBaseCommand();
        }

        public override Connection CreateConnection()
        {
            return new InterBaseConnection();
        }
    }

    public class Factory
    {
        private DatabaseFactory _databaseFactory;
        private Connection _connection;
        private Command _command;

        public Factory(DatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
            _connection = _databaseFactory.CreateConnection();
            _command = databaseFactory.CreateCommand();
        }

        public void Start()
        {
            _connection.Connect();
            if (_connection.State == "Open")
                _command.Execute("select ...");
        }
    }
}

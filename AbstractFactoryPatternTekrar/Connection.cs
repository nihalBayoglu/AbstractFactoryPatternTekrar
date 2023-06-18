using System;

namespace AbstractFactoryPatternTekrar
{
    public abstract class Connection //Soyut ürünlerden bir tanesi
    {
        public abstract bool Connect();
        public abstract bool Disconnect();
        public abstract string State //readonly
        {
            get;
        }
    }

    public abstract class Command //Soyut ürünlerden diğer bir tanesi
    {
        public abstract void Execute(string query);
    }

    public class OracleConncetion : Connection
    {
        public override string State
        {
            get { return "Open"; }
        }

        public override bool Connect()
        {
            Console.WriteLine("Bağlantı oracle veri tabanı sunucusu için sağlandı.");
            return true;
        }

        public override bool Disconnect()
        {
            Console.WriteLine("Bağlantı oracle veri tabanı sunucusu için kapatıldı.");
            return true;
        }
    }

    public class MongoConnection : Connection
    {
        public override string State { get { return "Open"; } }

        public override bool Connect()
        {
            Console.WriteLine("Bağlantı mongo veri tabanı sunucusu için sağlandı.");
            return true;
        }

        public override bool Disconnect()
        {
            Console.WriteLine("Bağlantı mongo veri tabanı sunucusu için kapatıldı.");
            return true;
        }
    }

    public class OracleCommand : Command
    {
        public override void Execute(string query )
        {
            Console.WriteLine("Oracle veri tabanı sunucusu için query çalıştırıldı.");
        }
    }

    public class MongoCommand : Command
    {
        public override void Execute(string query)
        {
            Console.WriteLine("Mongo veri tabanı sunucusu için query çalıştırıldı.");
        }
    }

    //Fabrika tanımları yapacağız
    public abstract class DatabaseFactory
    {
        public abstract Connection CreateConnection();
        public abstract Command CreateCommand();
    }

    public class OracleFactory : DatabaseFactory
    {
        public override Command CreateCommand()
        {
            return new OracleCommand();
        }

        public override Connection CreateConnection()
        {
            return new OracleConncetion();
        }
    }

    public class MongoFactory : DatabaseFactory
    {
        public override Command CreateCommand()
        {
            return new MongoCommand();
        }

        public override Connection CreateConnection()
        {
            return new MongoConnection();
        }
    }

    //Fabrika seçimini yapabilecek class'ı tanımlayacağız
    public class Factory
    {
        DatabaseFactory _databaseFactory;
        Connection _connection;
        Command _command;

        public Factory(DatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
            _connection = _databaseFactory.CreateConnection();
            _command = _databaseFactory.CreateCommand();
        }

        public void Start()
        {
            _connection.Connect();
            if (_connection.State == "Open")
                _command.Execute("Select ...");
        }
    }
}

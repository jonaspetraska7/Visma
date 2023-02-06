using Common.Entities;
using LinqToDB;
using LinqToDB.Configuration;
using LinqToDB.Data;

namespace Common.Data
{
    public class VismaDataConnection : DataConnection
    {
        public VismaDataConnection(LinqToDBConnectionOptions<VismaDataConnection> options) : base(options) { }

        public ITable<Employee> Employees => this.GetTable<Employee>();
        public ITable<Log> Logs => this.GetTable<Log>();
    }
}

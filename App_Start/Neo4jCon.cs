using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Neo4j.Driver.V1;

namespace ProyectoProgramado3.App_Start
{
    public class Neo4jCon
    {
        
            private readonly IDriver _driver;

            public Neo4jCon(string uri, string user, string password)
            {
                _driver = GraphDatabase.Driver(uri, AuthTokens.Basic(user, password));
            }

            public void PrintGreeting(string message)
            {
                using (var session = _driver.Session())
                {
                    var greeting = session.WriteTransaction(tx =>
                    {
                        var result = tx.Run("CREATE (a:Greeting) " +
                                            "SET a.message = $message " +
                                            "RETURN a.message + ', from node ' + id(a)",
                            new { message });
                        //return result.Single()[0].As();
                        return true;
                    });
                    Console.WriteLine(greeting);
                }
            }

            public void Dispose()
            {
                _driver?.Dispose();
            }

            //public static void Main()
            //{
            //    using (var greeter = new Neo4jCon("bolt://localhost:7687", "neo4j", "password"))
            //    {
            //        greeter.PrintGreeting("hello, world");
            //    }
            //}
        
    }
}
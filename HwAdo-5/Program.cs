using System;
using System.Threading;
using System.Reflection;
using System.Reflection.Emit;
using System.Security.Permissions;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace HwAdo_5
{
    public class Program
    {
        static void Main(string[] args)
        {
            DataSet shopDB = new DataSet("books");

            Console.WriteLine(shopDB.GetXmlSchema());

            DataTable customers = new DataTable("Customers");
            customers.Columns.Add(new DataColumn()
            {
                AllowDBNull = false,
                AutoIncrement = true,
                AutoIncrementSeed = 1,
                AutoIncrementStep = 1,
                ColumnName = "id",
                DataType = typeof(int),
                Unique = true
            });
            customers.Columns.Add("name", typeof(string));
            shopDB.Tables.Add(customers);

            DataTable employees = new DataTable("Employees");
            employees.Columns.Add(new DataColumn()
            {
                AllowDBNull = false,
                AutoIncrement = true,
                AutoIncrementSeed = 1,
                AutoIncrementStep = 1,
                ColumnName = "id",
                DataType = typeof(int),
                Unique = true
            });
            employees.Columns.Add("name", typeof(string));
            shopDB.Tables.Add(employees);

            DataTable products = new DataTable("Products");
            products.Columns.Add(new DataColumn()
            {
                AllowDBNull = false,
                AutoIncrement = true,
                AutoIncrementSeed = 1,
                AutoIncrementStep = 1,
                ColumnName = "id",
                DataType = typeof(int),
                Unique = true
            });
            products.Columns.Add("name", typeof(string));
            shopDB.Tables.Add(products);

            DataTable orders = new DataTable("Orders");
            orders.Columns.Add(new DataColumn()
            {
                AllowDBNull = false,
                AutoIncrement = true,
                AutoIncrementSeed = 1,
                AutoIncrementStep = 1,
                ColumnName = "id",
                DataType = typeof(int),
                Unique = true
            });
            orders.Columns.Add("customerId", typeof(int));
            orders.Columns.Add("productId", typeof(int));
            shopDB.Tables.Add(orders);

            DataTable details = new DataTable("Details");
            details.Columns.Add(new DataColumn()
            {
                AllowDBNull = false,
                AutoIncrement = true,
                AutoIncrementSeed = 1,
                AutoIncrementStep = 1,
                ColumnName = "id",
                DataType = typeof(int),
                Unique = true
            });
            details.Columns.Add("orderId", typeof(int));
            details.Columns.Add("orderDate", typeof(DateTime));
            shopDB.Tables.Add(details);
            

            shopDB.Relations.Add("Orders_Details_fk",
                shopDB.Tables["Orders"].Columns["id"],
                shopDB.Tables["Details"].Columns["orderId"]);

            shopDB.Relations.Add("Customers_Orders_fk",
                shopDB.Tables["Customers"].Columns["id"],
                shopDB.Tables["Orders"].Columns["customerId"]);
            
            shopDB.Relations.Add("Products_Orders_fk",
               shopDB.Tables["Products"].Columns["id"],
               shopDB.Tables["Orders"].Columns["productId"]);

            return;
        }
    }
}

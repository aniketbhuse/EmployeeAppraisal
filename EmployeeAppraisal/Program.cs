using System;
using System.Data.SqlClient;
using ConectionDl;
namespace EmployeeAppraisal
{
    class Program
    {
       
        static void Main(string[] args)
        {
           SqlConnect.Conection();
        }
    }
}

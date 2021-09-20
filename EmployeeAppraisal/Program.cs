using System;
using System.Data.SqlClient;

namespace EmployeeAppraisal
{
    class Program
    {
        static SqlDataReader dr;
        static void Main(string[] args)
        {
        
            int k;
            Console.WriteLine("----*---- Appraisal History of Employee ----*----\n");
            Console.WriteLine("1. List of Employee who joined as 'Intern' And now are 'Manger'.\n2. Employee with maximum Appraisal.\n3. Employee role was not changed after Appraisal.\n4. Employee who did not have Appraisal.\n5. Exit.");
            Console.WriteLine(" ---------*--------*----------*---------");
            Console.WriteLine("Enter Your Choice");
            do
            {
                k = Convert.ToInt32(Console.ReadLine());
                if (k == 1)
                {
                    Console.WriteLine("List of Employee who joined as 'Intern' And now are 'Manger' :- \n");
                    SqlConnection con = new SqlConnection("data source=DESKTOP-3AICL2B;initial catalog=school; integrated security=true;");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select * from Students",con);
                    dr = cmd.ExecuteReader();
                    Console.Write("id\tname\trollno\t\temail\n");
                    while (dr.Read())
                    {
                        Console.Write("{0}\t{1}\t{2}\t{3}\t\n", dr[0], dr[1], dr[2], dr[3]);
                    }
                    con.Close();
                    Console.WriteLine("Enter Your Choice");
                }
                else if (k == 2)
                {
                    Console.WriteLine("Employee with maximum Appraisal :- ");
                    SqlConnection con = new SqlConnection("data source=DESKTOP-3AICL2B;initial catalog=school; integrated security=true;");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select * from students where id='"+2+"'", con);
                    dr = cmd.ExecuteReader();
                    Console.Write("id\tname\trollno\t\temail\n");
                    while (dr.Read())
                    {
                        Console.Write("{0}\t{1}\t{2}\t{3}\t\n", dr[0], dr[1], dr[2], dr[3]);
                    }
                    con.Close();
                    Console.WriteLine("Enter Your Choice");
                }
                else if (k == 3)
                {
                    Console.WriteLine("Employee role was not changed after Appraisal :-");
                    Console.WriteLine("Enter Your Choice");
                }
                else if (k == 4)
                {
                    Console.WriteLine(" Employee who did not have Appraisal :-");
                    Console.WriteLine("Enter Your Choice");
                }
                else if (k == 5)
                {
                    Console.WriteLine("thank You '");
                }
                else
                {
                    Console.WriteLine("Enter Correct Choice");
                }
            } while (k != 5);
        }
    }
}

using System;
using System.Data.SqlClient;


namespace ConectionDl
{
    public class SqlConnect
    {
        static SqlDataReader dr;
        public static void Conection()
        {
            int k,j;
            Console.WriteLine("----*---- Appraisal History of Employee ----*----\n");
            Console.WriteLine("1. Add information about appraisal for any employee .\n2. List of Employee who joined as 'Intern' And now are 'Manger'.\n3. Employee with maximum Appraisal.\n4. Employee role was not changed after Appraisal.\n5. Employee who did not have Appraisal.\n6. Exit.");
            Console.WriteLine("\n ---------*--------*----------*---------");
            Console.WriteLine("Enter Your Choice");
            do
            {
                k = Convert.ToInt32(Console.ReadLine());
                if(k == 1)
                {
                    Console.WriteLine("----*---- Add Employee Details ----*----\n");
                    Console.WriteLine("1.Add Employee EmpId EmpName RoleId JoinDate. \n2. Add new Roles \n3. Modify Roles\n4. Delete Roles\n5. Exit\n");
                    Console.WriteLine("Enter Your Choice");
                    do
                    {
                        j = Convert.ToInt32(Console.ReadLine());
                        if(j == 1)
                        { 
                            Console.WriteLine("Enter Empid CurrentRole NewAppraisalDate RoleId");
                            int empid;
                            String CurrentRole;
                            String NewAPDate;
                            int roleid;
                            empid = Convert.ToInt32(Console.ReadLine());
                            CurrentRole = Console.ReadLine();
                            NewAPDate =Console.ReadLine();
                            roleid = Convert.ToInt32(Console.ReadLine());
                            SqlConnection con = new SqlConnection("data source=DESKTOP-3AICL2B;initial catalog=Employee; integrated security=true;");
                            con.Open();
                            SqlCommand cmd = new SqlCommand("insert into EmpAppraisal(empid,CurrentRole,NewAPDate,roleid) values(" + empid+",'"+CurrentRole+"','"+NewAPDate+"',"+roleid+")",con);
                            cmd.ExecuteNonQuery();
                            Console.ReadKey();
                            con.Close();
                            Console.WriteLine("\nEnter Your Choice");
                        }
                        else if(j == 2)
                        {
                            String  NewRole;
                            Console.WriteLine("Enter New Role And Empid");
                            NewRole = Console.ReadLine();
                            int empId;
                            empId = Convert.ToInt32(Console.ReadLine());
                            SqlConnection con = new SqlConnection("data source=DESKTOP-3AICL2B;initial catalog=Employee; integrated security=true;");
                            con.Open();
                            SqlCommand cmd = new SqlCommand("update EmpAppraisal set NewRole ='"+NewRole+"' where EmpId = "+empId+"",con);
                            cmd.ExecuteNonQuery();
                            Console.ReadKey();
                            con.Close();
                            Console.WriteLine("\nEnter Your Choice");
                        }
                        else if(j == 3)
                        {
                            int EmpId;
                            String NewRole;
                            Console.WriteLine("Enter NewRole and EmpId to Modify Role");
                            NewRole = Console.ReadLine();
                            EmpId = Convert.ToInt32(Console.ReadLine());
                            SqlConnection con = new SqlConnection("data source=DESKTOP-3AICL2B;initial catalog=Employee; integrated security=true;");
                            con.Open();
                            SqlCommand cmd = new SqlCommand("update EmpAppraisal set NewRole = '"+NewRole+"' where EmpId ='"+EmpId+"'", con);
                            cmd.ExecuteNonQuery();
                            Console.ReadKey();
                            con.Close();
                            Console.WriteLine("\nEnter Your Choice");

                        }
                        else if(j == 4)
                        {
                            int EmpId;
                            Console.WriteLine("Enter Emp id to Delete Role");
                            EmpId = Convert.ToInt32(Console.ReadLine());
                            SqlConnection con = new SqlConnection("data source=DESKTOP-3AICL2B;initial catalog=Employee; integrated security=true;");
                            con.Open();
                            SqlCommand cmd = new SqlCommand("delete EmpAppraisal where Empid ='"+EmpId+"'", con);
                            cmd.ExecuteNonQuery();
                            Console.ReadKey();
                            con.Close();
                            Console.WriteLine("\nEnter Your Choice");

                        }
                        else if(j == 5)
                        {
                            Console.WriteLine("Data Added SucessFully...!\n");
                            Console.WriteLine("Enter Your Choice");
                        }
                        else
                        {
                            Console.WriteLine("Enter Correct Choice");
                        }
                    } while(j != 5);  
                }
                else if (k == 2)
                {
                    Console.WriteLine("List of Employee who joined as 'Intern' And now are 'Manger' :- ");
                    SqlConnection con = new SqlConnection("data source=DESKTOP-3AICL2B;initial catalog=Employee; integrated security=true;");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select emp.EmpName,emp.JoinDate,ea.CurrentRole,ea.NewRole from EmpAppraisal ea inner Join Employee emp on emp.EmpId = ea.EmpId where CurrentRole = 'Intern' and NewRole = 'Manager'", con);
                    dr = cmd.ExecuteReader();
                    Console.Write("EmpName\tJoinDate\tCurrentRole\tNewRole\t\n");
                    while (dr.Read())
                    {
                        Console.Write("{0}\t{1}\t{2}\t\t{3}\n", dr[0], dr[1], dr[2],dr[3]);
                    }
                    con.Close();
                    Console.WriteLine("\nEnter Your Choice");
                }
                else if (k == 3)
                {
                    Console.WriteLine("Employee with maximum Appraisal :- ");
                    SqlConnection con = new SqlConnection("data source=DESKTOP-3AICL2B;initial catalog=Employee; integrated security=true;");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select CurrentRole, NewRole, EmpId from EmpAppraisal where roleid= (select  MAX(roleid) from EmpAppraisal)", con);
                    dr = cmd.ExecuteReader();
                    Console.Write("CurrentRole\tNewRole\t\tEmpId\n");
                    while (dr.Read())
                    {
                        Console.Write("{0}\t\t{1}\t\t{2}\n", dr[0], dr[1], dr[2]);
                    }
                    con.Close();
                    Console.WriteLine("\nEnter Your Choice");
                }  
                else if (k == 4)
                {
                    Console.WriteLine("Employee role was not changed after Appraisal :-");
                    SqlConnection con = new SqlConnection("data source=DESKTOP-3AICL2B;initial catalog=Employee; integrated security=true;");
                    con.Open();
                    SqlCommand cmd = new SqlCommand(" select emp.EmpName,ap.CurrentRole,ap.NewRole from Employee emp inner join EmpAppraisal ap on emp.EmpId = ap.EmpId where CurrentRole = NewRole", con);
                    dr = cmd.ExecuteReader();
                    Console.Write("EmpName\t\tCurrentRole\t\tNewRole\n");
                    while (dr.Read())
                    {
                        Console.Write("{0}\t\t{1}\t\t{2}\n", dr[0], dr[1], dr[2]);
                    }
                    con.Close();
                    Console.WriteLine("\nEnter Your Choice");
                    
                }
                else if (k == 5)
                {
                    Console.WriteLine("Employee who did not have Appraisal :-");
                    SqlConnection con = new SqlConnection("data source=DESKTOP-3AICL2B;initial catalog=Employee; integrated security=true;");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("select * from EmpAppraisal where NewRole is null", con);
                    dr = cmd.ExecuteReader();
                    Console.Write("Empid\tCurrentRole\t\tNewRole\t\n");
                    while (dr.Read())
                    {
                        Console.Write("{0}\t{1}\t{2}\t\n", dr[0], dr[1], dr[2]);
                    }
                    con.Close();
                    Console.WriteLine("\nEnter Your Choice");
                }
                else if (k == 6)
                {
                    Console.WriteLine("Thank You ..!");
                }
                else
                {
                    Console.WriteLine("Enter Correct Choice");
                }
            } while (k != 6);
        }
    }
}

using System;
using System.Data.SqlClient;
using System.IO;
using System.Xml.Linq;

namespace Crud_Console_App
{
    class Program {
        SqlConnection con = new SqlConnection(@"Data Source=ZENX\SQLEXPRESS04;Initial Catalog=Student;Integrated Security=true;");
        SqlCommand cmd;

        class Student
        {
            public int id;
            public string Name;
            public string email;
            public long phone;
            public int registration;
        }
        static List<Student> students = new List<Student>();

        public void introduction()
        {
            Console.WriteLine("Welcome to Record Management System");
           

        }

       
        public void services()
        {
            Console.WriteLine("1. Add Student");
            Console.WriteLine("2. Update Student");
            Console.WriteLine("3. Delete Details");
            Console.WriteLine("4. Show All Details");
            Console.WriteLine("5. Exit");


        }

        /* public void choiceTaker()
         {
             Program obj1 = new Program();
             obj1.services();
             int option = Convert.ToInt32(Console.ReadLine());
             switch (option)
             {
                 case 1: addStudent();break;
                 case 2: UpdateStudent(); break;
                 case 3: DeleteStudent(); break;
                 case 4: ShowAll(); break;
                 case 5: isExist = true; break;
                 default: Console.WriteLine("Invalid Choice"); break;
             }
         }*/
        //public void addStudent()
        //{
        //    int studentId = 1;
        //    con.Open();
        //    studentId++; // Increment studentId here

        //    cmd = new SqlCommand("insert into student (id, name, email, registration, phone) values (@id, @name, @email, @registration, @phone)", con);
        //    cmd.Parameters.AddWithValue("@id", studentId);

        //    Console.WriteLine("Enter Student Name");
        //    string name = Console.ReadLine();
        //    cmd.Parameters.AddWithValue("@name", name);

        //    Console.WriteLine("Enter Registration Number");
        //    int reg = Convert.ToInt32(Console.ReadLine());
        //    cmd.Parameters.AddWithValue("@registration", reg);

        //    Console.WriteLine("Enter Phone Number");
        //    long num = Convert.ToInt64(Console.ReadLine());
        //    cmd.Parameters.AddWithValue("@phone", num);

        //    Console.WriteLine("Enter Email");
        //    string email = Console.ReadLine();
        //    cmd.Parameters.AddWithValue("@email", email);

        //    cmd.ExecuteNonQuery(); // Execute the command

        //    con.Close();
        //    Console.WriteLine("Student Added Successfully");
        //}

        public void addStudent()
        {
            con.Open();
             cmd = new SqlCommand("insert into student (name,email,registration,phone) values (@name,@email,@reg,@num)", con);
      
            // Student s1 = new Student();
            Console.WriteLine("Enter Student Name");
            string name = Console.ReadLine();
            cmd.Parameters.AddWithValue("@name", name);

            Console.WriteLine("Enter Registration Number");
            int reg = Convert.ToInt32(Console.ReadLine());
            cmd.Parameters.AddWithValue("@reg", reg);
            /// s1.registration = Convert.ToInt32(Console.ReadLine());
            /// 
            Console.WriteLine("Enter Phone Number");
            long num = Convert.ToInt64(Console.ReadLine());
            cmd.Parameters.AddWithValue("@num", num);
            // s1.phone = Convert.ToInt64(Console.ReadLine());

            Console.WriteLine("Enter Email");
            string email = Console.ReadLine();
            cmd.Parameters.AddWithValue("@email", email);
            //s1.email = Console.ReadLine();
            //students.Add(s1);
            cmd.ExecuteNonQuery();
            con.Close();
            Console.WriteLine("Student Added Successfully");
        }

        public void UpdateStudent()
        {
            Console.WriteLine("Enter Student name to update: ");
            string studentName = Console.ReadLine();
            con.Open();
            cmd = new SqlCommand("update student set name = @newName, email =@email, phone = @num where name = @name", con);

            //update student set name = 'Raj', email = 'a@gmail.com',registration = 12124, phone = 9849270904 where name = 'Rajesh'
            // Student studentToUpdate = students.Find(x => x.Name.Equals(studentName));
            cmd.Parameters.AddWithValue("@name", studentName);
            if (studentName != null)
            {
                Console.WriteLine("Enter student Name");
               // studentToUpdate.Name = 
                cmd.Parameters.AddWithValue("@newName", (Console.ReadLine()));

                //Console.WriteLine("Enter Registration Number");
                ////  studentToUpdate.registration = Convert.ToInt32(Console.ReadLine());
                //cmd.Parameters.AddWithValue("@reg", (Convert.ToInt32(Console.ReadLine())));

                Console.WriteLine("Enter Phone Number");
                cmd.Parameters.AddWithValue("@num", (Convert.ToInt64(Console.ReadLine())));
                //studentToUpdate.phone = Convert.ToInt64(Console.ReadLine());

                Console.WriteLine("Enter Email");
                cmd.Parameters.AddWithValue("@email", (Console.ReadLine()));
                //studentToUpdate.email = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Student not found");
            }

            cmd.ExecuteNonQuery();
            con.Close();



        }

        public void DeleteStudent() {
            Console.WriteLine("Enter Student name to delete");
            string studentName = Console.ReadLine();
            con.Open();
            cmd = new SqlCommand("delete student where name = @name", con);

            //Student studentToDelte = students.Find(x =>x.Name.Equals(studentName));
            if (studentName != null)
            {
                //delete student where name = 'sameer'
                cmd.Parameters.AddWithValue("@name",studentName);
                cmd.ExecuteNonQuery();
                Console.WriteLine("Student Deleted Successfully");
            }
            else
            {
                Console.WriteLine("Student Not Found");
            }

            con.Close();
        }

        public void ShowAll()
        {
            con.Open();
            cmd = new SqlCommand("select * from student", con);
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                students.Add(new Student
                {
                    id = Convert.ToInt32(dr["id"]),
                    Name = dr["name"].ToString(),
                    email = dr["email"].ToString(),
                    phone = Convert.ToInt64(dr["phone"]),
                    registration = Convert.ToInt32(dr["registration"])

                });
            }

            Console.WriteLine("Student Details");
            foreach (var student in students)
            {
                Console.WriteLine("Id : " + student.id + " Name : " + student.Name + " Email : " + student.email + " Phome " + student.phone + " Registration " + student.registration);
            }

        }
                


           
        



        static void Main(string[] args)
        {
            Program obj = new Program();
            Student s2 = new Student();
            obj.introduction();
            // obj.services();
            bool isExist = false;
            while (!isExist)
            {
                //obj.choiceTaker();
                obj.services();
                int option = Convert.ToInt32(Console.ReadLine());
                switch (option)
                {
                    case 1: obj.addStudent(); break;
                    case 2: obj.UpdateStudent(); break;
                    case 3: obj.DeleteStudent(); break;
                    case 4: obj.ShowAll(); break;
                    case 5: isExist = true; break;
                    default: Console.WriteLine("Invalid Choice"); break;
                }
            }
            
            //obj.addStudent();
            //int choice = obj.choiceTaker();
            //Console.WriteLine(choice);
            /// Console.WriteLine(s2.SName);
            /// Console.WriteLine(s2.email);
            /// Console.WriteLine(s2.phone);
            /// Console.WriteLine(s2.registration);
            /// 
            //ShowAll();
            //foreach (Student student in students)
            //{
            //    Console.WriteLine("Student name is : " + student.Name + " email : " + student.email + " phone number : " + student.phone);
            //}

        }
    }
}
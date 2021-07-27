using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace CaseStudy
{
    class PersistentAppEngine : AppEngine
    {
        public void Introduce(Courses course) { }
        public void Register(StudentDB student)
        {
            SqlConnection con = null;
            SqlCommand cmd = null;
            try
            {
                con = new SqlConnection("Data Source = BHAVESH\\SQLEXPRESS; Initial Catalog = db_student; Integrated Security = true");
                con.Open();
                //Insertion
                cmd = new SqlCommand("insert into tbl_studentdetail(StuId,StuName,StuDOB) values(@id,@name,@DOB)", con);
                cmd.Parameters.AddWithValue("@id", student.id);
                cmd.Parameters.AddWithValue("@name", student.name);
                cmd.Parameters.AddWithValue("@DOB", student.dateofbirth);
                int i = cmd.ExecuteNonQuery();
                Console.WriteLine("No. Of row affected: {0}", i);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                con.Close();
            }
        }
        public List<StudentDB> ListOfStudent()
        {
            int n;
            Console.WriteLine("Enter number of students: ");
            n = Convert.ToInt32(Console.ReadLine());
            List<StudentDB> studata = new List<StudentDB>();
            for (int i = 0; i < n; i++)
            {
                int StuID;
                string StuName;
                DateTime DOB;

                Console.WriteLine("Enter student id, name, dob");
                StuID = Convert.ToInt32(Console.ReadLine());
                StuName = Console.ReadLine();
                DOB = Convert.ToDateTime(Console.ReadLine());

                studata.Add(new StudentDB(StuID, StuName, DOB));
            }
            return studata;
        }
        public void Enroll(StudentDB student, Courses course) { }
        public List<EnrollExample> ListOfEnrollments()
        {
            StudentDB student = new StudentDB(1, "Yashvi", Convert.ToDateTime("14/01/1999"));
            StudentDB student1 = new StudentDB(2, "Rhea", Convert.ToDateTime("19/05/1999"));
            StudentDB student2 = new StudentDB(3, "Dia", Convert.ToDateTime("15/06/1999"));
            Courses course = new Courses(1001, "Java", "6 Months", 5000);
            Courses course1 = new Courses(1002, "Python", "6 Months", 7000);
            Courses course2 = new Courses(1003, "C#", "3 Months", 4000);

            Console.WriteLine("Enter the enrollment date");
            DateTime date = Convert.ToDateTime(Console.ReadLine());

            List<EnrollExample> enrollstudent = new List<EnrollExample>();

            EnrollExample enrollstudent1 = new EnrollExample(student, course, date);
            EnrollExample enrollstudent2 = new EnrollExample(student1, course1, date);
            EnrollExample enrollstudent3 = new EnrollExample(student2, course2, date);

            enrollstudent.Add(enrollstudent1);
            enrollstudent.Add(enrollstudent2);
            enrollstudent.Add(enrollstudent3);
            return enrollstudent;
        }
    }
    
    class AppEngineConnection
    {
        static void Main()
        {
            int id;
            string sname;
            DateTime sdob;
            Console.WriteLine("Enter id, student name and student dob");
            id = Convert.ToInt32(Console.ReadLine());
            sname = Console.ReadLine();
            sdob = Convert.ToDateTime(Console.ReadLine());

            PersistentAppEngine pengine = new PersistentAppEngine();
            pengine.Register(new StudentDB(id, sname, sdob));
        }
    }
}

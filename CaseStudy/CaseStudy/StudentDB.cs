using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace CaseStudy
{


        class StudentDB
        {
            internal int id { get; set; }
            internal string name { get; set; }
            internal DateTime dateofbirth { get; set; }
            internal static string collegeName = "NITS";

            public StudentDB(int id, string name, DateTime dateofbirth)
            {
                this.id = id;
                this.name = name;
                this.dateofbirth = dateofbirth;
            }
        }

        class Info
        {
            public static void display(StudentDB student)
            {
                Console.WriteLine(student.id + " " + student.name + " " + (student.dateofbirth).ToString("dd/MM/yyyy"));
            }
        }

        class App
        {
            public static void Scenario1()
            {
                StudentDB student1 = new StudentDB(1, "Rahul", Convert.ToDateTime("14/01/1999"));
                StudentDB student2 = new StudentDB(2, "Rishi", Convert.ToDateTime("19/05/1999"));
                StudentDB student3 = new StudentDB(3, "Daisy", Convert.ToDateTime("15/06/1999"));

                Info info = new Info();
                Info.display(student1);
                Info.display(student2);
                Info.display(student3);
            }


            public static void Scenario2()
            {
                StudentDB[] students = new StudentDB[3];
                students[0] = new StudentDB(1, "Rahul", Convert.ToDateTime("14/01/1999"));
                students[1] = new StudentDB(2, "Rishi", Convert.ToDateTime("19/05/1999"));
                students[2] = new StudentDB(3, "Daisy", Convert.ToDateTime("15/06/1999"));

                foreach (StudentDB student in students)
                {
                    Info.display(student);
                }

            }
            public static void Scenario3()
            {
                Console.WriteLine("Enter number of students");
                int n = Convert.ToInt32(Console.ReadLine());
                StudentDB[] students = new StudentDB[n];
                for (int i = 0; i < students.Length; i++)
                {
                    Console.WriteLine("Enter Roll No, Name, and DOB");
                    int id = Convert.ToInt32(Console.ReadLine());
                    String name = Console.ReadLine();
                    DateTime date = DateTime.Parse(Console.ReadLine());
                    students[i] = new StudentDB(id, name, date);
                }
                foreach (StudentDB student in students)
                {
                    Info.display(student);
                }
            }

            public static void Scenario4()
            {
                Console.WriteLine("Enter number of students");
                int n = Convert.ToInt32(Console.ReadLine());
                ArrayList students = new ArrayList();
                for (int i = 0; i < n; i++)
                {
                    Console.WriteLine("Enter Roll No, Name, and DOB");
                    int id = Convert.ToInt32(Console.ReadLine());
                    String name = Console.ReadLine();
                    DateTime date = DateTime.Parse(Console.ReadLine());
                    students.Add(new StudentDB(id, name, date));

                }
                foreach (StudentDB student in students)
                {
                    Info.display(student);
                }
            }

            static void Main()
            {
                App.Scenario1();
                App.Scenario2();
                App.Scenario3();
                App.Scenario4();
            }
        }

}
  
       

    
   
    


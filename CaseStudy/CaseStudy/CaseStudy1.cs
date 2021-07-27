using System;
using System.Collections.Generic;
using System.Text;

namespace CaseStudy
{
    class Courses
    {
        internal int ID { get; set; }
        internal String Name { get; set; }
        internal String Duration { get; set; }
        internal int Fees { get; set; }

        internal Courses(int ID, string Name, string Duration, int Fees)
        {
            this.ID = ID;
            this.Name = Name;
            this.Duration = Duration;
            this.Fees = Fees;
        }
        protected internal virtual void CalculateMonthlyFees()
        {
            Console.WriteLine("This is monthly fees calculation method for parent class");
        }

    }

    class InfoC
    {
        internal static void display(Courses course)
        {
            Console.WriteLine(course.ID + " " + course.Name + " " + course.Duration + " " + course.Fees);
        }
    }

    class DegreeCourse : Courses
    {
        internal enum Level
        {
            Bachelors = 1, Masters = 2
        }
        internal Level level;
        internal bool isPlacementActivity;
        internal DegreeCourse(int ID, string Name, string Duration, int Fees, int levelp, bool isPlacementActivity) : base(ID, Name, Duration, Fees)
        {
            this.isPlacementActivity = isPlacementActivity;
            this.level = (Level)Enum.Parse(typeof(Level), Convert.ToString(levelp));
        }
        protected internal override void CalculateMonthlyFees()
        {
            double Placementservice;
            base.CalculateMonthlyFees();
            if (isPlacementActivity)
            {
                Placementservice = Fees * 0.1;
                Console.WriteLine("Level: {0} || Fees: {1} || Placement Service: {2} || Total Fees: {3}", (Level)level, Fees, Placementservice, (Fees + Placementservice));
            }
            else
            {
                Console.WriteLine("Placement activity is not going on");
            }
        }
    }
    class Diploma : Courses
    {
        internal enum Type
        {
            Professional = 1, Academics = 2
        }
        internal Type type;
        internal Diploma(int ID, string Name, string Duration, int Fees, int type_d) : base(ID, Name, Duration, Fees)
        {
            this.type = (Type)type_d;
        }
        protected internal override void CalculateMonthlyFees()
        {
            double ProfessionalCharge, AcademicCharge;
            base.CalculateMonthlyFees();
            if (Convert.ToInt32(type) == 1)
            {
                ProfessionalCharge = Fees * 0.1;
                Console.WriteLine("Course Type: {0} || Fees: {1} || Placement Service: {2} || Total Fees: {3}", (Type)type, Fees, ProfessionalCharge, (Fees + ProfessionalCharge));
            }
            else
            {
                AcademicCharge = Fees * 0.05;
                Console.WriteLine("Course Type: {0} || Fees: {1} || Placement Service: {2} || Total Fees: {3}", (Type)type, Fees, AcademicCharge, (Fees + AcademicCharge));
            }
        }
    }

    class AppC
    {
        static void Main()
        {
            Courses course = new Courses(1001, "Java", "6 Months", 5000);
            Courses course1 = new Courses(1002, "Python", "6 Months", 7000);
            Courses course2 = new Courses(1003, "C#", "3 Months", 4000);
            Courses course3 = new Courses(1004, ".Net", "2 Months", 3000);

            InfoC info = new InfoC();
            InfoC.display(course);
            InfoC.display(course1);
            InfoC.display(course2);
            InfoC.display(course3);

            Courses profcourse = new DegreeCourse(1001, "Java", "6 Months", 5000, 1, true);
            profcourse.CalculateMonthlyFees();
            Console.WriteLine("------------------------------------------");
            Courses profcourse1 = new Diploma(1001, "Java", "6 Months", 5000, 1);
            profcourse1.CalculateMonthlyFees();
        }
    }
}





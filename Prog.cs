using System;


using System.Text;

namespace ConsoleApp5
{
    struct StudentList
    {
        private Student[] _studentList;

        public void AddStudent(Student newStudent)
        {
            Student[] newStudentList;
            if (_studentList == null)
            {
                newStudentList = new Student[1];
                newStudentList[0] = newStudent;
            }
            else
            {
                newStudentList = new Student[_studentList.Length + 1];
                int i = 0;
                foreach (var student in _studentList)
                {
                    newStudentList[i] = student;
                }
                newStudentList[_studentList.Length] = newStudent;
            }
            _studentList = newStudentList;
        }

        public void RemoveStudent(Student removableStudent)
        {
            Student[] newStudentList = new Student[_studentList.Length - 1];
            for (int i = 0, space = 0; i < _studentList.Length; i++, space++)
            {
                if (_studentList[space].Equals(removableStudent))
                {
                    i--;
                }
                else
                {
                    newStudentList[i] = _studentList[space];
                }
            }
            _studentList = newStudentList;
        }

        public override string ToString()
        {
            Array.Sort(_studentList, (student, student1) => student.SumMark - student1.SumMark);
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine("**************Report Card**************");
            for (int i = 0; i < _studentList.Length; i++)
            {
                stringBuilder.AppendLine(_studentList[i].ToString(i + 1));
            }
            return stringBuilder.ToString();
        }
    }

    struct Student
    {
        public string Name;
        public int[,] Marks;

        public int EnglishMarks
        {
            get => Marks[0, 0];
            set => Marks[0, 0] = value;
        }

        public int MathMarks
        {
            get => Marks[1, 0];
            set => Marks[1, 0] = value;
        }

        public int ComputerMarks
        {
            get => Marks[2, 0];
            set => Marks[2, 0] = value;
        }

        public int SumMark
        {
            get { return EnglishMarks + MathMarks + ComputerMarks; }
        }

        public Student(string name) : this()
        {
            Name = name;
            Marks = new int[3, 1];
        }

        public Student(string name, int englishMarks, int mathMarks, int computerMarks)
        {
            Name = name;
            Marks = new int[3, 1];
            EnglishMarks = englishMarks;
            MathMarks = mathMarks;
            ComputerMarks = computerMarks;
        }

        public override string ToString()
        {
            StringBuilder card = new StringBuilder();
            card.AppendLine("***************************************");
            card.Append($"Student Name: {Name}, Total: {SumMark}/300");
            return card.ToString();
        }

        public string ToString(int pos)
        {
            StringBuilder card = new StringBuilder();
            card.AppendLine("***************************************");
            card.Append($"Student Name: {Name}, Position: {pos}, Total: {SumMark}/300");
            return card.ToString();
        }
    }

    class Program
    {
        private static StudentList _studentList;
        static void Main()
        {
            FirstVariant();
        }

        private static void FirstVariant()
        {
            _studentList = new StudentList();
            Console.WriteLine("Press any following key");
            Console.ReadKey();
            Console.Write("Enter Total Students : ");
            int count;
            while (!Int32.TryParse(Console.ReadKey().KeyChar.ToString(), out count)) { }
            for (int i = 0; i < count; i++)
            {
                AddStudent(ref _studentList);
            }
            Console.WriteLine(_studentList.ToString());
        }

        private static void AddStudent(ref StudentList studentList)
        {
            Student newStudent = new Student("New");
            Console.Write("\nEnter Student Name : ");
            newStudent.Name = Console.ReadLine();
            do
            {
                Console.Write("\nEnter English Marks (Out Of 100) : ");
                while (!Int32.TryParse(Console.ReadLine(), out newStudent.Marks[0, 0])) { }
            } while (newStudent.EnglishMarks < 0 || newStudent.EnglishMarks > 100);
            do
            {
                Console.Write("\nEnter Math Marks (Out Of 100) : ");
                while (!Int32.TryParse(Console.ReadLine(), out newStudent.Marks[1, 0])) { }
            } while (newStudent.MathMarks < 0 || newStudent.MathMarks > 100);
            do
            {
                Console.Write("\nEnter Computer Marks (Out Of 100) : ");
                while (!Int32.TryParse(Console.ReadLine(), out newStudent.Marks[2, 0])) { }
            } while (newStudent.ComputerMarks < 0 || newStudent.ComputerMarks > 100);

            Console.WriteLine("****************************\n");
            studentList.AddStudent(newStudent);
        }
    }
}
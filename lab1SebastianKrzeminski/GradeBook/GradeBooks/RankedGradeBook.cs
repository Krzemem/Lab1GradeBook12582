using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name, bool isWeighted) : base(name, isWeighted)
        {
            Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            var studentsWithLowerAverageGrade = 0.0;


            if (Students.Count < 5)
            {
                throw new InvalidOperationException("Invalid operation");
            }

            foreach (var student in Students)
            {
                if (student.AverageGrade < averageGrade)
                {
                    studentsWithLowerAverageGrade += 1;
                }
            }

            double percentageRangeOfWeakerStudents = studentsWithLowerAverageGrade / Students.Count;
            double percentageRangeOfStudentsGrade = 100 - (percentageRangeOfWeakerStudents * 100);

            if (percentageRangeOfStudentsGrade <= 20)
                return 'A';
            else if (percentageRangeOfStudentsGrade > 20 && percentageRangeOfStudentsGrade <= 40)
                return 'B';
            else if (percentageRangeOfStudentsGrade > 40 && percentageRangeOfStudentsGrade <= 60)
                return 'C';
            else if (percentageRangeOfStudentsGrade > 60 && percentageRangeOfStudentsGrade <= 80)
                return 'D';
            else
                return 'F';
        }


        public override void CalculateStatistics()
        {
            if (Students.Count < 5)
            {
                Console.Write("Ranked grading requires at least 5 students");
            }
            else
            {
                base.CalculateStatistics();
            }
        }

        public override void CalculateStudentStatistics(string name)
        {
            if (Students.Count < 5)
            {
                Console.Write("Ranked grading requires at least 5 students");
            }
            else
            {
                base.CalculateStudentStatistics(name);
            }
        }


    }
}

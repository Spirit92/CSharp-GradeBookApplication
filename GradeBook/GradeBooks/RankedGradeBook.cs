using GradeBook.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace GradeBook.GradeBooks
{
    class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if (Students.Count < 5)
                throw new InvalidOperationException();

            List<double> grades = new List<double>();
            foreach (var s in Students)
                grades.Add(s.AverageGrade);

            grades.Sort();

            int perGrade = (int)(Students.Count * 0.2d);
            int mark = 5;

            for (var i = Students.Count - 1 - perGrade; i >= 0; i -= perGrade)
            {
                if (averageGrade > grades[i])
                {
                    break;
                }
                else
                {
                    --mark;
                }
            }

            switch(mark)
            {
                case 5: return 'A';
                case 4: return 'B';
                case 3: return 'C';
                case 2: return 'D';
            }

            return 'F';
        }
    }
}

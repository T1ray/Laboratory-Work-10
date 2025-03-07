using Lab9_1;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace TestProgram
{
    [TestClass]
    public sealed class TestStudent
    {
        private Student baseStudent;
        private Student schoolStudent;
        private Student firstCourseGoodMarksStudent;
        private Student firstCourseBadMarksStudent;
        private Student secondCourseGoodMarksStudent;
        private Student secondCourseBadMarksStudent;
        private Student brokenGpaStudent1;
        private Student brokenGpaStudent2;

        (string, string) StudentComparison(Student student1, Student student2) => Student.CompareStudents(student1, student2);
        (string, string) StaticStudentComparison(Student student1, Student student2) => student1.CompareStudents(student2);

        [TestInitialize]
        public void InitializeStudent()
        {
            baseStudent = new Student();
            schoolStudent = new Student(1, "Владимир", 15, 8);
            brokenGpaStudent1 = new Student(2, "Валерия", 19, -2.26);
            brokenGpaStudent2 = new Student(3, "Афанасий", 19, 12.79);
            firstCourseGoodMarksStudent = new Student(4, "Ольга", 18, 8.39);
            firstCourseBadMarksStudent = new Student(5, "артем", 18, 4.69);
            secondCourseGoodMarksStudent = new Student(6, "данил", 19, 8.39);
            secondCourseBadMarksStudent = new Student(7, "Татьяна", 19, 3.94);
        }

        [TestMethod]
        public void TestMethod1()
        {
            Assert.AreEqual("Вася", baseStudent.Name);
            Assert.AreEqual(18, baseStudent.Age);
            Assert.AreEqual(0, baseStudent.Gpa);
            Assert.AreEqual(0, baseStudent.Id.Id);
        }

        [TestMethod]
        public void TestBrokenStudent1()
        {
            Assert.AreEqual(-1, schoolStudent.Age);
        }

        [TestMethod]
        public void TestBrokenStudent2()
        {
            Assert.AreEqual(-1, brokenGpaStudent1.Gpa);
        }

        [TestMethod]
        public void TestBrokenStudent3()
        {
            Assert.AreEqual(-1, brokenGpaStudent2.Gpa);
        }

        [TestMethod]
        public void TestComparsion1()
        {
            var comparison = StudentComparison(firstCourseGoodMarksStudent, firstCourseBadMarksStudent);
            Assert.AreEqual("ровесник", comparison.Item1);
            Assert.AreEqual("выше", comparison.Item2);
        }

        [TestMethod]
        public void TestComparsion2()
        {
            var comparison = StudentComparison(firstCourseBadMarksStudent, firstCourseGoodMarksStudent);
            Assert.AreEqual("ровесник", comparison.Item1);
            Assert.AreEqual("ниже", comparison.Item2);
        }

        [TestMethod]
        public void TestComparsion3()
        {
            var comparison = StudentComparison(firstCourseGoodMarksStudent, secondCourseGoodMarksStudent);
            Assert.AreEqual("младше", comparison.Item1);
            Assert.AreEqual("равен", comparison.Item2);
        }

        [TestMethod]
        public void TestComparsion4()
        {
            var comparison = StudentComparison(secondCourseGoodMarksStudent, firstCourseGoodMarksStudent);
            Assert.AreEqual("старше", comparison.Item1);
            Assert.AreEqual("равен", comparison.Item2);
        }

        [TestMethod]
        public void TestComparsion5()
        {
            var comparison = StaticStudentComparison(firstCourseGoodMarksStudent, firstCourseBadMarksStudent);
            Assert.AreEqual("ровесник", comparison.Item1);
            Assert.AreEqual("выше", comparison.Item2);
        }

        [TestMethod]
        public void TestComparsion6()
        {
            var comparison = StaticStudentComparison(firstCourseBadMarksStudent, firstCourseGoodMarksStudent);
            Assert.AreEqual("ровесник", comparison.Item1);
            Assert.AreEqual("ниже", comparison.Item2);
        }

        [TestMethod]
        public void TestComparsion7()
        {
            var comparison = StaticStudentComparison(firstCourseGoodMarksStudent, secondCourseGoodMarksStudent);
            Assert.AreEqual("младше", comparison.Item1);
            Assert.AreEqual("равен", comparison.Item2);
        }

        [TestMethod]
        public void TestComparsion8()
        {
            var comparison = StaticStudentComparison(secondCourseGoodMarksStudent, firstCourseGoodMarksStudent);
            Assert.AreEqual("старше", comparison.Item1);
            Assert.AreEqual("равен", comparison.Item2);
        }

        [TestMethod]
        public void TestOverloadedOperations1()
        {
            firstCourseBadMarksStudent = ~firstCourseBadMarksStudent;
            Assert.AreEqual("Артем", firstCourseBadMarksStudent.Name);
        }

        [TestMethod]
        public void TestOverloadedOperations2()
        {
            secondCourseBadMarksStudent++;
            Assert.AreEqual(20, secondCourseBadMarksStudent.Age);
        }

        [TestMethod]
        public void TestOverloadedOperations3()
        {
            int course = (int)secondCourseBadMarksStudent;
            Assert.AreEqual(2, course);
        }

        [TestMethod]
        public void TestOverloadedOperations4()
        {
            int course = (int)schoolStudent;
            Assert.AreEqual(-1, course); // Возраст < 18
        }

        [TestMethod]
        public void TestOverloadedOperations5()
        {
            bool isGoodMarks = secondCourseGoodMarksStudent;
            Assert.AreEqual(true, isGoodMarks); // GPA >= 6
        }

        [TestMethod]
        public void TestOverloadedOperations6()
        {
            bool isGoodMarks = secondCourseBadMarksStudent;
            Assert.AreEqual(false, isGoodMarks); // GPA < 6
        }

        [TestMethod]
        public void TestOverloadedOperations7()
        {
            secondCourseGoodMarksStudent -= 4;
            Assert.AreEqual(4.39, secondCourseGoodMarksStudent.Gpa, 0.01);
        }

        [TestMethod]
        public void TestOverloadedOperations8()
        {
            baseStudent %= "Петр";
            Assert.AreEqual("Петр", baseStudent.Name);
        }

        [TestMethod]
        public void TestOverloadedOperations9()
        {
            try
            {
                secondCourseGoodMarksStudent -= 10;
                Assert.Fail("Ожидалось исключение");
            }
            catch (Exception e)
            {
                Assert.AreEqual("Gpa не может стать отрицательным", e.Message);
            }
        }

        [TestMethod]
        public void TestInfoOutput()
        {
            StringWriter output = new StringWriter();
            Console.SetOut(output);
            secondCourseBadMarksStudent.Info();
            Assert.AreEqual("Имя: Татьяна, Возраст:19, gpa: 3,94\r\n", output.ToString());
        }
        
        [TestMethod]
        public void TestId()
        {
            Assert.AreEqual(4, firstCourseGoodMarksStudent.Id.Id);
        }

        [TestMethod]
        public void TestEqualsWithId1()
        {
            Student student1 = new Student(1, "Ольга", 18, 8.39);
            Student student2 = new Student(1, "Ольга", 18, 8.39);
            Assert.IsTrue(student1.Equals(student2));
        }

        [TestMethod]
        public void TestEqualsWithId2()
        {
            Student student1 = new Student(1, "Ольга", 18, 8.39);
            Student student2 = new Student(2, "Ольга", 18, 8.39);
            Assert.IsFalse(student1.Equals(student2));
        }

        [TestMethod]
        public void TestToString()
        {
            string rightString = $"Id студента: 4 \nИмя студента: Ольга \nВозраст:18 \nGpa: 8,39\n";
            Assert.AreEqual(rightString, firstCourseGoodMarksStudent.ToString());
        }

        [TestMethod]
        public void TestClone()
        {
            Student cloned = (Student)firstCourseGoodMarksStudent.Clone();
            Assert.AreEqual(firstCourseGoodMarksStudent.Id.Id, cloned.Id.Id);
            Assert.AreEqual(firstCourseGoodMarksStudent.Name, cloned.Name);
            Assert.AreEqual(firstCourseGoodMarksStudent.Age, cloned.Age);
            Assert.AreEqual(firstCourseGoodMarksStudent.Gpa, cloned.Gpa, 0.001);
        }

        [TestMethod]
        public void TestCopy()
        {
            Student copyed = (Student)secondCourseGoodMarksStudent.ShallowClone();
            Assert.AreEqual(secondCourseGoodMarksStudent.Id.Id, copyed.Id.Id);
            Assert.AreEqual(secondCourseGoodMarksStudent.Name, copyed.Name);
            Assert.AreEqual(secondCourseGoodMarksStudent.Age, copyed.Age);
            Assert.AreEqual(secondCourseGoodMarksStudent.Gpa, copyed.Gpa, 0.001);
        }
    }
}
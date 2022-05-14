using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Mediator mediator = new Mediator();


            Teacher engin = new Teacher(mediator);
            engin.Name = "ENGİN";
            mediator.teacher = engin;

            Student selcuk = new Student(mediator);
            selcuk.Name = "SELCUK";
            //mediator.students.Add(selcuk);

            Student gokhan = new Student(mediator);
            gokhan.Name = "GOKHAN";
            //mediator.students.Add(gokhan);

            mediator.students = new List<Student> { selcuk, gokhan };

            selcuk.SendQuestion("is it true ?");
            engin.RecieveQuestion("is it true? ", selcuk);
            engin.SendNewImageUrl("slide1.jpg");

            Console.ReadLine();
        }
    }

    abstract class CourseMember
    {
        protected Mediator Mediator;

        protected CourseMember(Mediator mediator)
        {
            Mediator = mediator;
        }
    }

    class Teacher : CourseMember
    {
        public Teacher(Mediator mediator) : base(mediator)
        {
        }

        public void RecieveQuestion(string question, Student student)
        {
            Console.WriteLine("Teacher recieved from: {0}, {1}", student.Name, question);
        }

        public void SendNewImageUrl(string url)
        {
            Console.WriteLine("Teacher {1} change slide:  {0}", url, Name);
            Mediator.UpdateImage(url);
        }

        public void AnswerQuestion(string answer, Student student)
        {
            Console.WriteLine("Teacher Answer Question: {0} {1}", student.Name, answer);
            Mediator.SendAnswer(answer, student);
        }

        public string Name { get; set; }
    }

    class Student : CourseMember
    {
        public Student(Mediator mediator) : base(mediator)
        {
        }

        internal void RecieveImage(string url)
        {
            Console.WriteLine("{0} Student recived image:  {1}", Name, url);
        }

        internal void RecieveAnswer(string answer)
        {
            Console.WriteLine("Student recived answer:  {0}", answer);
        }

        internal void SendQuestion(string question)
        {
            Console.WriteLine("{1} send questiom:  {0}", question, Name);
        }

        public string Name { get; set; }
    }

    class Mediator
    {
        public Teacher teacher { get; set; }
        public List<Student> students { get; set; }

        public void UpdateImage(string url)
        {
            foreach (var student in students)
            {
                student.RecieveImage(url);
            }
        }

        public void SendQuestion(string question, Student student)
        {
            teacher.RecieveQuestion(question, student);
        }

        public void SendAnswer(string answer, Student student)
        {
            student.RecieveAnswer(answer);
        }

    }
}

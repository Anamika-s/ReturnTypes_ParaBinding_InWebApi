using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FirstWebApi.Models;

namespace FirstWebApi.Controllers
{
    public class StudentsController : ApiController
    {
        static List<Student> students = null;
        public StudentsController()
        {
            if (students == null)
            {
                students = new List<Student>()
                {
                    new Student() { StudentId = 1, Name = "Ajay", Batch = "B001", Marks = 90, DateOfBirth = Convert.ToDateTime("12/12/2001") },
                    new Student() { StudentId = 2, Name = "Deepak", Batch = "B003", Marks = 78, DateOfBirth = Convert.ToDateTime("10/06/2020") },
                    new Student() { StudentId = 3, Name = "Sagar", Batch = "B002", Marks = 98, DateOfBirth = Convert.ToDateTime("10/06/2020") },
                    new Student() { StudentId = 4, Name = "Pradeep", Batch = "B002", Marks = 80, DateOfBirth = Convert.ToDateTime("10/06/2020") }
                };

            }
        }
        // GET: api/Students
        public IEnumerable<Student> Get()
        {
            return students;

        }

        // GET: api/Students/5
        public Student Get([FromUri] int id)
        {
            return students.FirstOrDefault(x => x.StudentId == id);

        }


        //public Student Get([FromBody] int id)
        //{
        //    return students.FirstOrDefault(x => x.StudentId == id);

        //}

        // POST: api/Students
        //public void Post([FromBody] Student student)
        //{
        //    students.Add(student);
        //}

        public void Post([FromUri] Student student)
        {
            students.Add(student);
        }


        // PUT: api/Students/5
        public void Put(int id, Student student)
        {
            Student obj = students.FirstOrDefault(x=>x.StudentId == id);
            if (obj!=null)
            {
                foreach(Student temp in students)
                {
                    if(temp.StudentId == obj.StudentId)
                    {
                        temp.Name = student.Name;
                        temp.Batch = student.Batch;
                        temp.DateOfBirth = student.DateOfBirth;
                        temp.Marks = student.Marks;
                    }
                }
            }
        }

        // DELETE: api/Students/5
        public void Delete(int id)
        {
            Student obj = students.FirstOrDefault(x => x.StudentId == id);
            if (obj != null)
            {
                students.Remove(obj);
            }
            }
        }
}

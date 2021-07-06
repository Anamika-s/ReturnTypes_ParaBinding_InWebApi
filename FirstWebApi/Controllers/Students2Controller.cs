using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FirstWebApi.Models;

namespace FirstWebApi.Controllers
{
    public class Students2Controller : ApiController
    {
       static List<Student> students = null;
        public Students2Controller()
        {
                if(students == null)
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
        public IHttpActionResult Get()
        {
            if (students == null)
            {
                return NotFound();


            }
            else
            {

                return Ok(students);
            }
        }
        // GET: api/Students/5
        public IHttpActionResult Get(int id)
        {

            Student student = students.FirstOrDefault(x => x.StudentId == id);
            if (student == null)
                return NotFound();

            else
                return Ok(student);
        }

        // POST: api/Students
        public IHttpActionResult Post(Student student)
        {
            students.Add(student);
            return Created<Student>("Created", student);
        }

        // PUT: api/Students/5
        public IHttpActionResult Put(int id, Student student)
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
                return Ok("Record edited");
            }
            else
            {
                return NotFound();
            }
        }

        // DELETE: api/Students/5
        public IHttpActionResult Delete(int id)
        {
            Student obj = students.FirstOrDefault(x => x.StudentId == id);
            if (obj != null)
            {
                students.Remove(obj);
                return Ok("Record deleted");
            }
            else
            {
                return NotFound();
            }

        }
    }
}

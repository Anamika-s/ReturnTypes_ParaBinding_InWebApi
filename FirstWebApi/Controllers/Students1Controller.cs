using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using FirstWebApi.Models;

namespace FirstWebApi.Controllers
{
    public class Students1Controller : ApiController
    {
       static List<Student> students = null;
        public Students1Controller()
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
        public HttpResponseMessage Get()
        {
            if (students == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound, "No Records");
            }
            else
            {

                return Request.CreateResponse(HttpStatusCode.OK, students);
            }
        }
        // GET: api/Students/5
        public HttpResponseMessage Get(int id)
        {

            Student student = students.FirstOrDefault(x => x.StudentId == id);
            if (student == null)
                return Request.CreateResponse(HttpStatusCode.NotFound);
            else
                return Request.CreateResponse(HttpStatusCode.OK, student);
        }

        // POST: api/Students
        public HttpResponseMessage Post(Student student)
        {
            students.Add(student);
            return Request.CreateResponse(HttpStatusCode.Created, "Student record is creted")
;        }

        // PUT: api/Students/5
        public HttpResponseMessage Put(int id, Student student)
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
                return Request.CreateResponse(HttpStatusCode.OK, "Record edited");
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);

            }
        }

        // DELETE: api/Students/5
        public HttpResponseMessage Delete(int id)
        {
            Student obj = students.FirstOrDefault(x => x.StudentId == id);
            if (obj != null)
            {
                students.Remove(obj);
                return Request.CreateResponse(HttpStatusCode.OK, "Record deleted");

            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

        }
    }
}

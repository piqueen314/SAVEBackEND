using System.Data.Entity;
using AutoMapper;
using Microsoft.Ajax.Utilities;
using SaveOrg.Migrations;
using SaveOrg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SaveOrg.Data
{
  public class StudentRepository
  {
    //public void DeleteStudent(Student student)
    //{
    //  using (var db = new SaveDbContext())
    //  {
    //    db.Students.Remove(student);
    //    db.SaveChanges();
    //  }
      
    //}

    public List<Student> GetStudents(bool includeInactive = false)
    {
      var students = new List<Student>();

      using (var db = new SaveDbContext())
      {
        students = includeInactive ? 
          GetStudentQuery(db).ToList() : 
          GetStudentQuery(db).Where(x => !x.InactiveDate.HasValue).ToList();
      }

      return students;
    }

    public Student GetStudent(int studentId)
    {
      var student = new Student();

      using (var db = new SaveDbContext())
      {
        student = GetStudentQuery(db).Single(x => x.StudentId == studentId);
      }

      return student;
    }

    /// <summary>
    /// add a new student to the database
    /// </summary>
    /// <param name="student"></param>
    /// <returns></returns>
    public Student CreateStudent(Student student)
    {
      using (var db = new SaveDbContext())
      {
        db.Students.Add(student);
        db.SaveChanges();
      }

      return student;
    }

    public Address ModifyStudentAddress(Address address, int studentId)
    {
      using (var db = new SaveDbContext())
      {
        if (address.AddressId > 0)
        {
          //edit address, it's already in StudentAddresses table
          db.Addresses.Attach(address);

          db.Entry(address).State = EntityState.Modified;
        }
        else
        {
          //new address
          var student = db.Students.Include(x => x.StudentAddresses).Single(x => x.StudentId == studentId);

          if (student.StudentAddresses == null)
          {
            student.StudentAddresses = new List<StudentAddress>();
          }

          var studentAddress = new StudentAddress
          {
            Address = address,
            ModDate = address.ModDate,
            ModUser = address.ModUser,
            SetupDate = address.SetupDate,
            SetupUser = address.SetupUser,
            StudentId = studentId
          };

          student.StudentAddresses.Add(studentAddress);
        }

        db.SaveChanges();
      }

      return address;
    }

    /// <summary>
    /// modify an existing student
    /// </summary>
    /// <param name="student"></param>
    /// <returns></returns>
    public Student ModifyStudent(Student student)
    {
      using (var db = new SaveDbContext())
      {

        if (student.StudentId > 0)
        {
          //edit a student
          db.Students.Attach(student);
          
          db.Entry(student).State = EntityState.Modified;

          //get the history for this student so we can add a record
          student.StudentHistories = db.StudentHistories.Where(x => x.StudentId == student.StudentId).ToList();
        }
        else
        {
          //create a student
          db.Students.Add(student);

          //initialize the history collection so we can add a record
          student.StudentHistories = new List<StudentHistory>();
        }

        AddStudentHistory(db, student);
        db.SaveChanges();
      }

      return student;
    }

    private void AddStudentHistory(SaveDbContext db, Student student)
    {
      /*
       * set up automapper map for student -> studenthistory
       * map your student param to a new studenthistory
       * db.Students.StudentHistories.Add(studentHistory)
       */
      var studentHistory = Mapper.Map<Student, StudentHistory>(student);

      student.StudentHistories.Add(studentHistory);
    }

    /// <summary>
    /// your main student query, add includes as you add more models
    /// </summary>
    /// <param name="db"></param>
    /// <returns></returns>
    private IQueryable<Student> GetStudentQuery(SaveDbContext db)
    {
      return db.Students
        .Include(x => x.StudentAddresses)
        .Include(x => x.StudentAddresses.Select(y => y.Address));
    }
  }
}

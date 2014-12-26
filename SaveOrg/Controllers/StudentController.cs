using viewModels = SaveOrg.ViewModels;
using dataModels = SaveOrg.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SaveOrg.Data;
using AutoMapper;
using SaveOrg.Utilities;

namespace SaveOrg.Controllers
{
  [Authorize]
  public class StudentController : Controller
  {
    private SaveDbContext db = new SaveDbContext();
    // GET: Student
    public ActionResult Index()
    {
      var repo = new StudentRepository();

      var students = repo.GetStudents();

      var studentViews = Mapper.Map<List<dataModels.Student>, List<viewModels.Student>>(students);
      
      return View(studentViews);
    }

    // GET: Student/Create
    public ActionResult Create()
    {
      //load page for creating a new student
      viewModels.Student studentView = new viewModels.Student();

      //make the gender select list
      studentView.GenderList = Lookups.GetGenderList();

      return View(studentView);
    }

    // POST: Student/Create
    [HttpPost]
    public ActionResult Create(viewModels.Student studentView)
    {
      //create page submission, map the view back to the data and add it to the db
      dataModels.Student studentData = Mapper.Map<viewModels.Student, dataModels.Student>(studentView);

      //set up mod/setup user
      DateTime curDate = DateTime.Now;
      string curUser = User.Identity.Name;

      studentData.SetupDate = curDate;
      studentData.SetupUser = curUser;
      studentData.ModDate = curDate;
      studentData.ModUser = curUser;

      StudentRepository studentRepo = new StudentRepository();

      try
      {
        studentRepo.ModifyStudent(studentData);
      }
      catch (Exception)
      {
        throw;
      }

      //go back to the index page
      return RedirectToAction("Index", "Student");
    }

    // GET: Student/Edit/5
    public ActionResult Edit(int id)
    {
      //var student = new dataModels.Student();
      //using (var db = new SaveDbContext())
      //{
      //    student = db.Students.Find(id);
      //}
      //var studentData = Mapper.Map<dataModels.Student,viewModels.Student>(student);
      //return (studentData);

      var repo = new StudentRepository();
      var student = repo.GetStudent(id);

      viewModels.Student studentView = Mapper.Map<dataModels.Student, viewModels.Student>(student);

      return View(studentView);
    }

    // POST: Student/Edit/5
    [HttpPost]
    public ActionResult Edit(viewModels.Student studentView)
    {
      //create page submission, map the view back to the data and add it to the db
      dataModels.Student studentData = Mapper.Map<viewModels.Student, dataModels.Student>(studentView);

      //set up mod/setup user
      DateTime curDate = DateTime.Now;
      string curUser = User.Identity.Name;

      studentData.ModDate = curDate;
      studentData.ModUser = curUser;

      StudentRepository studentRepo = new StudentRepository();

      try
      {
        studentRepo.ModifyStudent(studentData);
      }

      catch (Exception)
      {
        throw;
      }

      //go back to the index page
      return RedirectToAction("Index", "Student");
    }

    // GET: Student/Delete/5
    public ActionResult Delete(int id)
    {
      dataModels.Student student = db.Students.Find(id);
      viewModels.Student studentView = Mapper.Map<dataModels.Student, viewModels.Student>(student);

      return View(studentView);
    }

    // POST: Student/Delete/5
    [HttpPost]
    public ActionResult Delete(viewModels.Student studentView)
    {
      //create page submission, map the view back to the data and add it to the db
      var studentData = Mapper.Map<viewModels.Student, dataModels.Student>(studentView);

      ////set up mod/setup user hopefully later we will record who deleted a student
      var curDate = DateTime.Now;
      var curUser = User.Identity.Name;

      studentData.ModDate = curDate;
      studentData.ModUser = curUser;
      studentData.InactiveDate = curDate;
     
      try
      {
        var studentRepo = new StudentRepository();

        studentRepo.ModifyStudent(studentData);
       
        return RedirectToAction("Index", "Student");
      }
      catch (Exception ex)
      {
        return View(studentView);
      }
    }

    [HttpPost]
    public PartialViewResult EditAddress(viewModels.Address addressModel)
    {
      var repo = new StudentRepository();
      var address = Mapper.Map<viewModels.Address, dataModels.Address>(addressModel);

      var curDate = DateTime.Now;
      var curUser = User.Identity.Name;

      address.ModDate = curDate;
      address.ModUser = curUser;

      if (addressModel.AddressId == 0)
      {
        address.SetupDate = curDate;
        address.SetupUser = curUser;
      }

      address = repo.ModifyStudentAddress(address, addressModel.OwnerId);

      addressModel = Mapper.Map<dataModels.Address, viewModels.Address>(address);
     
      return PartialView("DisplayTemplates/Address", addressModel);
    }
  }
}

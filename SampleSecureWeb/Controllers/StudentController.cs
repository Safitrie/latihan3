using System;
using Microsoft.AspNetCore.Mvc;
using SampleSecureWeb.Data;
using SampleSecureWeb.Models;

namespace SampleSecureWeb.Controllers;

public class StudentController : Controller
{
    private readonly IStudent _studentData;
    
    private StudentController(IStudent studentData)
    {
        _studentData = studentData;
    }
  
    public IActionResult Index()
    {
        var students = _studentData.GetStudents();
        return View(students);
    }

    [HttpPost]
    public IActionResult Create(Student student)
    {
        try
        {
            _studentData.AddStudent(student);
            return RedirectToAction("Index");
        }
        catch (System.Exception ex)
        {
            ViewBag.Error = ex.Message;
        }
        return View();
    }

    public IActionResult Edit()
    {
        return View();
    }

    public IActionResult Delete()
    {
        return View();
    }


}
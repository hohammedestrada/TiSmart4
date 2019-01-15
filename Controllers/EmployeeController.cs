using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

using TiSmart4.Models;
using TiSmart4.Dao;
  
namespace TiSmart4.Controllers  
{  
    [Route("api/[controller]")]
    [ApiController]
    
    public class EmployeeController : ControllerBase 
    {  
        EmployeeDao objemployee = new EmployeeDao();  

        /////List////////
        // GET api/values
        [HttpGet, Authorize]
        public ActionResult<List<Employee>> Get()
        {   
            var currentUser = HttpContext.User;
             List<Employee> lstEmployee = new List<Employee>();  
            lstEmployee = objemployee.GetAllEmployees().ToList();    
            return (lstEmployee);
        }
        
         // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Employee> Get(int id)
        {
            if (id == 0)  
            {  
                return NotFound();  
            }  
            Employee employee = objemployee.GetEmployeeData(id);  
        
            if (employee == null)  
            {  
                return NotFound();  
            }  
            return (employee); 
            
        }

        // POST api/values
        [HttpPost]
        public IActionResult Create([FromBody]Employee employee)  
        {  
            if (employee == null)  
                return BadRequest();  
    
            try{
                objemployee.AddEmployee(employee);  
    
            //var outputModel = ToOutputModel(model);  
            //return CreatedAtRoute("GetMovie",   
               //         new { id = outputModel.Id }, outputModel);  
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        } 

        [HttpPut("{id}")]  
        public IActionResult Update(int id, [FromBody]Employee employee)  
        {  
            Console.WriteLine("Ingreoso al Metodo Put:"+employee);
            if (employee == null || id != employee.biIdEmployee)  
                return BadRequest();  
    
            try{
                 objemployee.UpdateEmployee(employee);  
                 return Ok(); 
            }
    
             catch (Exception e)
            {
                return NoContent(); 
            }
            
    
             
        } 

/* 
        /////Create////
        [HttpGet]  
        public IActionResult Create()  
        {  
            return View();  
        }  
        
        [HttpPost]  
        [ValidateAntiForgeryToken]  
        public IActionResult Create([Bind] Employee employee)  
        {  
            if (ModelState.IsValid)  
            {  
                objemployee.AddEmployee(employee);  
                return RedirectToAction("Index");  
            }  
            return View(employee);  
        } 

        ///////Edit//////

        [HttpGet]  
        public IActionResult Edit(int? id)  
        {  
            Console.Write("Ingreso a action result Edit "+ id);

            if (id == null)  

            {  Console.Write("Ingreso a action result Edit Nulllll "+ id);
                return NotFound();  
            }  
            
            Employee employee = objemployee.GetEmployeeData(id);  
             Console.Write(employee);
        
            if (employee == null)  
            {  
                return NotFound();  
            }  
            return View(employee);  
        }  
        
        [HttpPost]  
        [ValidateAntiForgeryToken]  
        public IActionResult Edit(int id, [Bind]Employee employee)  
        {  
            if (id != employee.biIdEmployee)  
            {  
                return NotFound();  
            }  
            if (ModelState.IsValid)  
            {  
                objemployee.UpdateEmployee(employee);  
                return RedirectToAction("Index");  
            }  
            return View(employee);  
        }

        ///////Details//////

        [HttpGet]  
        public IActionResult Details(int? id)  
        {  
            if (id == null)  
            {  
                return NotFound();  
            }  
            Employee employee = objemployee.GetEmployeeData(id);  
        
            if (employee == null)  
            {  
                return NotFound();  
            }  
            return View(employee);  
        }

        ///Delete//////

        [HttpGet]  
        public IActionResult Delete(int? id)  
        {  
            if (id == null)  
            {  
                return NotFound();  
            }  
            Employee employee = objemployee.GetEmployeeData(id);  
        
            if (employee == null)  
            {  
                return NotFound();  
            }  
            return View(employee);  
        }  
        
        [HttpPost, ActionName("Delete")]  
        [ValidateAntiForgeryToken]  
        public IActionResult DeleteConfirmed(int? biIdEmployee)  
        {  
            objemployee.DeleteEmployee(biIdEmployee);  
            return RedirectToAction("Index");  
        }


        */  
     } 

     
    
}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProfkomManagement.Data.Interfeces;
using ProfkomManagement.Models;
using ProfkomManagement.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfkomManagement.Controllers
{
    [Authorize]
    public class FacultiesController : Controller
    {
        private readonly IFacultyRepository _repository;

        public FacultiesController(IFacultyRepository repository)
        {
            _repository = repository;
        }
        
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Faculty newFaculty)
        {
            if(ModelState.IsValid)
            {
                //TODO: Add checking on existing faculty 
                _repository.Create(newFaculty);

                return RedirectToAction("list", "faculties");
            }

            return View("index", "index");
        }

        // Get list of faculties.
        [HttpGet]
        public IActionResult List()
        {
            return View(_repository.GetList());
        }

        // Get list of groups of faculty.
        [HttpGet]
        [Route("[controller]/{facultyId}/[action]")]
        public IActionResult Groups(int facultyId)
        {
            // Get list of faculties groups.
            var groups = _repository.Groups(facultyId);
            // Get list of students without groups.
            var membersWithoutGroups = _repository.Members(facultyId).Where(m => m.GroupId == null);

            FacultiesGroupsViewModel model = new FacultiesGroupsViewModel
            {
                FacultyTitle = _repository.Get(facultyId).Title,
                Groups = groups,
                MembersWithoutGroups = membersWithoutGroups
            };

            if (facultyId != 0)
            {
                return View(model);
            }

            return View(model);
        }     


        // TODO: Rename API methods

        // API - Get list of groups of faculty.   
        [HttpGet]
        public JsonResult GroupsApi(int id)
        { 
            if(id != 0)
            {
                var list = _repository.Groups(id).ToList();
                return new JsonResult(list);
            }

            return new JsonResult($"id = {id} does'n exist");
        }

        // API - Get json list of faculties.

        [HttpGet]
        public JsonResult FacultiesJsonList() =>  new JsonResult(_repository.GetList());

    }
}

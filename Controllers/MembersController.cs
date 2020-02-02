using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
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
    public class MembersController : Controller
    {
        private readonly IMemberRepository _membersRepository;
        private readonly IFacultyRepository _facultyRepository;

        public MembersController(IMemberRepository membersRepository, IFacultyRepository facultyRepository)
        {
            _membersRepository = membersRepository;
            _facultyRepository = facultyRepository;
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new CreateMemberViewModel();
            model.Faculties = _facultyRepository.GetList();

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(CreateMemberViewModel model)
        {
            if(ModelState.IsValid)
            {
                int? facultyId,
                    groupId;

                if (model.FacultyId == 0)
                    facultyId = null;
                else
                    facultyId = model.FacultyId;

                if (model.GroupId == 0)
                    groupId = null;
                else groupId = model.GroupId;

                Member member = new Member
                {
                    Name = model.Name,
                    Surname = model.Surname,
                    Patronymic = model.Patronymic,
                    DateOfEntry = model.DateOfEntry,
                    IsScholarship = model.IsScholarship,
                    FacultyId = facultyId,
                    GroupId = groupId,
                    NumberOfTicket = model.NumberOfTicket
                };               
                _membersRepository.Create(member);

                return RedirectToAction("index", "home");
            }

            return RedirectToAction("create");
        }

        [HttpPost]
        public IActionResult Search(string search)
        {
            var members = _membersRepository.Search(search);

            return RedirectToAction("index", "home", members);
        }

        //TODO: add another route.

        //[Route("Faculties/{facultyId}/Groups/{groupId}/[controller]/{id}/[action]")]
        public IActionResult DeleteMember(int id, string redirectUrl)
        {

            string r = UriHelper.GetDisplayUrl(Request);
            var deletedMember = _membersRepository.Delete(id);

            if(deletedMember == null)
            {
                return NotFound("Member with id = {0} not found" + id);
            }

            return LocalRedirect(redirectUrl);            
        }

        /// <summary>
        /// GET method. 
        /// Allows us to edit the member's personal information.
        /// </summary>
        /// <param name="id">Member's ID</param>
        /// <returns>Pass EditMemberViewModel to View</returns>
        [HttpGet]
        public IActionResult EditMember(int id)
        {
            var member = _membersRepository.Get(id);

            if(member != null)
            {
                var model = new EditMemberViewModel
                {
                    Id = member.Id,
                    Name = member.Name,
                    Surname = member.Surname,
                    Patronymic = member.Patronymic,
                    Contribution = member.Contribution,
                    DateOfEntry = member.DateOfEntry,
                    DateOfExit = member.DateOfExit,                  
                    IsScholarship = member.IsScholarship,
                    NumberOfTicket = member.NumberOfTicket,
                    Faculties = _facultyRepository.GetList()
                };

                model.GroupId = member.GroupId ?? 0;
                model.GroupTitle = model.GroupId == 0 ? "Група не обрана" : member.Group.Title;
                
                model.FacultyId = member.FacultyId ?? 0;

                return View(model);
            }

            return NotFound();
        }

        /// <summary>
        /// POST method.
        /// Allows us to post edited member's data in the data base.
        /// </summary>
        /// <param name="model">Model from View</param>
        /// <returns>Redirect to Index page or Group members page.</returns>
        [HttpPost]
        public IActionResult EditMember(EditMemberViewModel model)
        {

            if (model != null)
            {
                var member = new Member
                {
                    Id = model.Id,
                    Surname = model.Surname,
                    Name = model.Name,
                    Patronymic = model.Patronymic,
                    DateOfEntry = model.DateOfEntry,
                    NumberOfTicket = model.NumberOfTicket,
                    IsScholarship = model.IsScholarship,
                    Contribution = model.Contribution,
                    FacultyId = model.FacultyId,
                    GroupId = model.GroupId
                };

                // If GroupID or FacultyId is '0', need to set value of fields to 'null'. 
                // We need to do this, because we get foregign key update error. 
                member.GroupId = model.GroupId == 0 ? null : model.GroupId;
                member.FacultyId = model.FacultyId == 0 ? null : model.FacultyId;

                _membersRepository.Update(member);
            }

            // If group isn't selected.
            if (model.GroupId == 0)
                return RedirectToAction("index", "home");
            // If group is selected.
            else
                return RedirectToAction("members", "groups", new { groupId = model.GroupId });
        }

    }
}

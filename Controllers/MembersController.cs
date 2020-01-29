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
                    FacultyId = member.FacultyId,
                    Faculties = _facultyRepository.GetList(),
                    GroupId = member.GroupId,
                    GroupTitle = member.Group.Title,
                    IsScholarship = member.IsScholarship,
                    NumberOfTicket = member.NumberOfTicket
                };

                return View(model);
            }

            return NotFound();
        }

        [HttpPost]
        public IActionResult EditMember(EditMemberViewModel model)
        {
            if(model != null)
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

                _membersRepository.Update(member);
            }

            return RedirectToAction("index", "home");
        }

    }
}

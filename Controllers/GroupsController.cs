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
    public class GroupsController : Controller
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IFacultyRepository _facultyRepository;
        private readonly IMemberRepository _memberRepository;

        public GroupsController(IGroupRepository groupRepository, 
            IFacultyRepository facultyRepository,
            IMemberRepository memberRepository)
        {
            _groupRepository = groupRepository;
            _facultyRepository = facultyRepository;
            _memberRepository = memberRepository;
        }

        [HttpGet]
        public IActionResult Create()
        {
            var model = new CreateGroupViewModel
            {
                Faculties = _facultyRepository.GetList()
            };

            return View(model);
        }

        [HttpPost]
        public JsonResult Create(CreateGroupViewModel model)
        {
            if(ModelState.IsValid)
            {
                var group = new Group
                {
                    FacultyId = model.FacultyId,
                    Title = model.Title
                };

                _groupRepository.Create(group);
                return new JsonResult(group);
            }
            return new JsonResult("hello");
        }

        [HttpGet]
        public IActionResult ListOfGroups()
        {
            return View(_groupRepository.GetList());
        }

        [Route("Faculties/[controller]/{groupId}/[action]")]
        [Route("[controller]/{groupId}/[action]")]
        public IActionResult Members(int groupId)
        {
            if(groupId != 0)
            {
                var members = _groupRepository.GetGroupMembers(groupId);
                return View(members);
            }
            
            return View();
        }

        public IActionResult DeleteGroup(int id)
        {
            var group = _groupRepository.Delete(id);
            
            if(group != null)
            {
                int facultyId = group.FacultyId??1;
                return RedirectToAction("groups", "faculties", new { id = facultyId });
            }

            return NotFound(id);
            
        }


        [HttpGet]
        [Route("Faculties/[controller]/{groupId}/[action]")]
        public IActionResult AddGroupMembers(int groupId)
        {
            // TODO: Add checking on NULL.
            var group = _groupRepository.Get(groupId);
            // Get members with defined Group property.
            var membersWithGroup = _memberRepository.GetList().Where(m => m.GroupId == groupId);
            // Get members with non defined Group property but from the same faculty.
            var membersWithoutGroup = _memberRepository.GetList().Where(m => 
                m.FacultyId == group.FacultyId && m.GroupId == null);

            var model = new AddGroupMembersViewModel
            {
                GroupId = groupId,
                GroupTitle = group.Title,
                FacultyTitle = group.Faculty.Title,
                MembersWithGroup = membersWithGroup,
                MembersWithoutGroup = membersWithoutGroup
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult AddGroupMembers([FromBody]GroupMembersPassViewModel model)
        {
            for (int i = 0; i < model.MembersId.Length; i++)
            {
                var member = _memberRepository.Get(model.MembersId[i]);

                if (member != null)
                {
                    member.GroupId = model.GroupId;
                    _memberRepository.Update(member);
                }
            }

            return View(model.GroupId);
        }
    }
}

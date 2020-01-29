using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProfkomManagement.Models;
using ProfkomManagement.Data.Interfeces;
using Microsoft.AspNetCore.Routing;

namespace ProfkomManagement.Controllers.Home
{
    public class HomeController : Controller
    {
        private readonly IMemberRepository _membersRepository;

        public HomeController(IMemberRepository membersRepository)
        {
            _membersRepository = membersRepository;
        }
      
        public IActionResult Index(string search = null)
        {
            if (search == null)
                return View(_membersRepository.GetList().OrderByDescending(f => f.DateOfEntry)); 
            
            return View(_membersRepository.Search(search));
        }

        public IActionResult Members(IEnumerable<Member> members)
        {
            return PartialView(members);
        }

    }
}

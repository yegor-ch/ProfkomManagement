using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProfkomManagement.Models
{
    public class MockMembersRepository : IProfkomRepository
    {
        private readonly List<Member> _members;

        public MockMembersRepository()
        {
            _members = new List<Member>
            {
                new Member()
                {
                    Id = 1,
                    Surname = "Часновский",
                    Name = "Егор",
                    Patronymic = "Анатольевич",
                    IsScholarship = true,
                    Group = new Group
                    {
                        Title = "122",
                        Faculty = new Faculty
                        {
                            Title = "ICIT"
                        }
                    }
                },
                new Member()
                {
                    Id = 2,
                    Surname = "Часновский",
                    Name = "Денис",
                    Patronymic = "Анатольевич",
                    IsScholarship = true,
                    Group = new Group
                    {
                        Title = "122",
                        Faculty = new Faculty
                        {
                            Title = "ICIT"
                        }
                    }
                },
                new Member()
                {
                    Id = 3,
                    Surname = "Бадрак",
                    Name = "Олег",
                    Patronymic = "Сергеевич",
                    IsScholarship = false,
                    Group = new Group
                    {
                        Title = "124",
                        Faculty = new Faculty
                        {
                            Title = "ICIT"
                        }
                    }
                }
            };
        }

        public Member CreateMember(Member member)
        {
            member.Id = _members.Max(m => m.Id) + 1;
            _members.Add(member);
            return member;
        }

        public Member UpdateMember(Member memberChanges)
        {
            throw new NotImplementedException();
        }

        public Member DeleteMember(Member member)
        {
            throw new NotImplementedException();
        }

        public Member GetMember(int id)
        {
            return _members.FirstOrDefault(m => m.Id == id);
        }

        public IEnumerable<Member> GetAllMembers()
        {
            return _members;
        }

        public Group GetGroup(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Group> GetGroups()
        {
            throw new NotImplementedException();
        }

        public Faculty GetFaculty(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Faculty> GetFaculties()
        {
            throw new NotImplementedException();
        }
    }
}

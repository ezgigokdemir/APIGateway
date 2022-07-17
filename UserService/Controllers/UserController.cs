using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private List<User> users;

        public UserController()
        {
            users = new List<User>();
            for (int i = 1; i < 4; i++)
            {
                users.Add(new User(i, "User", $"Test {i}", i % 2 == 0 ? true : false));
            }
        }

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return users;
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            var student = users.FirstOrDefault(s => s.Id == id);

            if (student != null) return JsonConvert.SerializeObject(student);

            return $"User not found with Id: {id}";
        }
    }

    public class User
    {
        public User(int id, string name, string surname, bool isActive)
        {
            Id = id;
            Name = name;
            Surname = surname;
            IsActive = isActive;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool IsActive { get; set; }
    }
}

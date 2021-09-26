using OnlineBanking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.domain.Models
{
    
    public class UpdateRoleViewModel
    {
        public UpdateRoleViewModel()
        {
            Users = new List<User>();
        }
        [Required(ErrorMessage = "Title of the Role is required")]
        public string Name { get; set; }

        public string Id { get; set; }

        public List<User> Users { get; set; }
    }

}

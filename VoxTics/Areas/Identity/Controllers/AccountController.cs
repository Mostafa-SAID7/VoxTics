
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Security.Claims;
using System.Threading.Tasks;
using VoxTics.Areas.Identity.Models.Entities;
using VoxTics.Areas.Identity.Models.ViewModels;
using VoxTics.Repositories.IRepositories;
using VoxTics.Services.Interfaces;
using VoxTics.Utility;
using VoxTics.Utitlity;
namespace VoxTics.Areas.Identity.Controllers

{
    [Area(SD.IdentityArea)]
    public class AccountController : Controller
    {
        private readonly IApplicationUsersService _usersService;

        public AccountController(IApplicationUsersService usersService)
        {
            _usersService = usersService;
        }

       
    }
}

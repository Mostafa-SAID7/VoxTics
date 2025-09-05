using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using VoxTics.Helpers;
using VoxTics.Models.ViewModels;
using VoxTics.Repositories.Interfaces;

namespace VoxTics.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserRepository _userRepo;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository userRepo, IMapper mapper)
        {
            _userRepo = userRepo;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(string? search, int pageIndex = 1, int pageSize = 12)
        {
            var query = _userRepo.Query();

            if (!string.IsNullOrWhiteSpace(search))
                query = query.Where(u => u.UserName.Contains(search) || u.Email.Contains(search));

            var pagedEntities = await PaginatedList<VoxTics.Models.Entities.User>.CreateAsync(query, pageIndex, pageSize);

            var mapped = pagedEntities.Select(u => _mapper.Map<UserVM>(u));
            var pagedVM = PaginatedList<UserVM>.Create(mapped, pageIndex, pageSize);

            if (Request.Headers["X-Requested-With"] == "XMLHttpRequest")
                return PartialView("_UserCards", pagedVM);

            return View(pagedVM);
        }

        public async Task<IActionResult> Details(int id)
        {
            var user = await _userRepo.GetByIdAsync(id);
            if (user == null) return NotFound();

            var vm = _mapper.Map<UserVM>(user);
            return View(vm);
        }
    }
}

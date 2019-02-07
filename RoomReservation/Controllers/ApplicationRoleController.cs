using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RoomReservation.Data;
using RoomReservation.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RoomReservation.Controllers
{
    public class ApplicationRoleController : Controller
    {
        private readonly RoleManager<ApplicationRole> roleManager;

        public ApplicationRoleController(RoleManager<ApplicationRole> roleManager)
        {
            this.roleManager = roleManager;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var model = new List<ApplicationRoleListViewModel>();
            model = roleManager.Roles.Select(r =>
                new ApplicationRoleListViewModel
                {
                    RoleName = r.Name,
                    Id = r.Id,
                    Description = r.Description
                }).ToList();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddEditApplicationRole(string id)
        {
            var model = new ApplicationRoleViewModel();
            var applicationRole = await roleManager.FindByIdAsync(id);
            if (applicationRole != null)
            {
                model.Id = applicationRole.Id;
                model.RoleName = applicationRole.Name;
                model.Description = applicationRole.Description;
            }

            return PartialView("_AddEditApplicationRole", model);
        }

        [HttpPost]
        public async Task<IActionResult> AddEditApplicationRole(string id, ApplicationRoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var isExist = !string.IsNullOrEmpty(id);
                var applicationRole = isExist ? await roleManager.FindByIdAsync(id) : new ApplicationRole
                {
                    CreatedDate = DateTime.UtcNow
                };

                applicationRole.Name = model.RoleName;
                applicationRole.Description = model.Description;
                applicationRole.IpAddress = Request.HttpContext.Connection.RemoteIpAddress.ToString();

                var roleResult = isExist
                    ? await roleManager.UpdateAsync(applicationRole)
                    : await roleManager.CreateAsync(applicationRole);
                if (roleResult.Succeeded)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteApplicationRole(string id)
        {
            var name = string.Empty;
            if (!string.IsNullOrEmpty(id))
            {
                var applicationRole = await this.roleManager.FindByIdAsync(id);
                if(applicationRole != null)
                {
                    name = applicationRole.Name;
                }
            }

            return PartialView("_DeleteApplicationRole", name);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteApplicationRole(string id, IFormCollection form)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var applicationRole = await roleManager.FindByIdAsync(id);
                if (applicationRole != null)
                {
                    IdentityResult roleResult = await roleManager.DeleteAsync(applicationRole);
                    if (roleResult.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                }
            }

            return View();
        }
    }
}
using AutoMapper;
using BlogProject.Entity.Dtos.Articles;
using BlogProject.Entity.Dtos.Users;
using BlogProject.Entity.Entities;
using BlogProject.Web.ResultMessages;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using System.Data;

namespace BlogProject.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<AppRole> roleManager;
        private readonly IMapper mapper;
        private readonly IToastNotification toastNotification;

        public UserController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager, IMapper mapper, IToastNotification toastNotification)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.mapper = mapper;
            this.toastNotification = toastNotification;
        }
        public async Task<IActionResult> Index()
        {
            var users = await userManager.Users.ToListAsync();
            var map = mapper.Map<List<UserDto>>(users);

            foreach (var item in map)
            {
                var findUser = await userManager.FindByIdAsync(item.Id.ToString());
                var role = string.Join("", await userManager.GetRolesAsync(findUser));

                item.Role = role;
            }
            return View(map);
        }
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var role = await roleManager.Roles.ToListAsync();
            return View(new UserAddDto { Roles = role });
        }
        [HttpPost]
        public async Task<IActionResult> Add(UserAddDto userAddDto)
        {
            var map = mapper.Map<AppUser>(userAddDto);
            var role = await roleManager.Roles.ToListAsync();

            if (ModelState.IsValid)
            {
                map.UserName = userAddDto.Email;
                var result = await userManager.CreateAsync(map, string.IsNullOrEmpty(userAddDto.Password) ? "" : userAddDto.Password);
                if (result.Succeeded)
                {
                    var findRole = await roleManager.FindByIdAsync(userAddDto.RoleId.ToString());
                    await userManager.AddToRoleAsync(map, findRole.ToString());
                    toastNotification.AddSuccessToastMessage(Messages.User.Add(userAddDto.Email), new ToastrOptions { Title = "Başarılı!" });
                    return RedirectToAction("Index", "User", new { Area = "Admin" });
                }
                else
                {
                    foreach (var errors in result.Errors)
                        ModelState.AddModelError("", errors.Description);
                    return View(new UserAddDto { Roles = role });
                }
            }
            return View(new UserAddDto { Roles = role });
        }
        [HttpGet]
        public async Task<IActionResult> Update(Guid userId)
        {
            var user = await userManager.FindByIdAsync(userId.ToString());
            var roles = await roleManager.Roles.ToListAsync();
            var userRole = string.Join("", await userManager.GetRolesAsync(user));

            var map = mapper.Map<UserUpdateDto>(user);
            map.Roles = roles;
            map.RoleId = roles.FirstOrDefault(r => r.Name == userRole).Id;
            return View(map);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UserUpdateDto userUpdateDto)
        {
            var user = await userManager.FindByIdAsync(userUpdateDto.Id.ToString());

            if(user!= null)
            {
                var userRole = string.Join("", await userManager.GetRolesAsync(user));
                var roles = await roleManager.Roles.ToListAsync();
                if (ModelState.IsValid)
                {
                    mapper.Map(userUpdateDto, user);
                    //user.FirstName = userUpdateDto.FirstName;
                    //user.LastName = userUpdateDto.LastName;
                    //user.Email = userUpdateDto.Email;
                    user.UserName = userUpdateDto.Email;
                    user.SecurityStamp = Guid.NewGuid().ToString(); //Bununla securitystamp a yeni guid atayıp oturumlarını geçersiz kılarız
                    var result = await userManager.UpdateAsync(user);
                    if(result.Succeeded)
                    {
                        await userManager.RemoveFromRoleAsync(user, userRole);
                        var findRole = await roleManager.FindByIdAsync(userUpdateDto.RoleId.ToString());
                        await userManager.AddToRoleAsync(user,findRole.Name);
                        toastNotification.AddSuccessToastMessage(Messages.User.Update(userUpdateDto.Email), new ToastrOptions { Title = "Başarılı!" });
                        return RedirectToAction("Index", "User", new { Area = "Admin" });
                    }
                    else
                    {
                        foreach (var errors in result.Errors)
                            ModelState.AddModelError("", errors.Description);
                        return View(new UserUpdateDto { Roles = roles });
                    }
                }
            }

            return NotFound();
        }
        public async Task<IActionResult> Delete(Guid userId)
        {
            var user = await userManager.FindByIdAsync(userId.ToString());
            if(user != null)
            {
                //var userRole = string.Join("", await userManager.GetRolesAsync(user)); //identity nin kendi özelliği nedeniyle kullanıcıya bağlı olan tüm şeylerde silinir bu nedenle bu metoda gerek yoktur
                var result = await userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    //await userManager.RemoveFromRoleAsync(user, userRole); //identity nin kendi özelliği nedeniyle kullanıcıya bağlı olan tüm şeylerde silinir bu nedenle bu metoda gerek yoktur
                    toastNotification.AddSuccessToastMessage(Messages.User.Delete(user.Email), new ToastrOptions { Title = "Başarılı" });
                    return RedirectToAction("Index", "User", new { Area = "Admin" });
                }
                else
                {
                    foreach (var errors in result.Errors)
                        ModelState.AddModelError("", errors.Description);
                }
            }
            return NotFound();
        }

    }
}

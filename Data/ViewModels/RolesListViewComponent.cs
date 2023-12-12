using EStore.Data.Cart;
using EStore.Data.Services;
using EStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace EStore.Data.ViewModels
{
    public class RolesListViewComponent : ViewComponent
    {
        private readonly RoleManager

        <IdentityRole> roleManager
        ;
        

        public RolesListViewComponent(RoleManager<IdentityRole> roleManager)
        {
            this.roleManager = roleManager;
        }
       

       

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var roles = roleManager.Roles;
            return View(roles);
        }
    }

}

using EStore.Data.Cart;
using EStore.Data.Services;
using EStore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace EStore.Data.ViewModels
{
    public class UsersListViewComponent : ViewComponent
    {
      
        private readonly AppDbContext _context;

        public UsersListViewComponent( AppDbContext context)
        {
     
            _context = context;
        }


      

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var users = await _context.Users.ToListAsync();
            return View(users);
        }
    }

}

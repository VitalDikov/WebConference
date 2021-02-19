using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntershipProject.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;


namespace IntershipProject.Controllers
{
    public class BlockchainController : Controller
    {
        private readonly AppDbContext _dbContext;

        public BlockchainController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}

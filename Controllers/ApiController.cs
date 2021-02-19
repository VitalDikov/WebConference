using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntershipProject.Domain;
using IntershipProject.Models;

namespace IntershipProject.Controllers
{
    public class BcModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public double Timestamp { get; set; }
    }
    [ApiController]
    [Route("[controller]")]
    public class ApiController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public ApiController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public IEnumerable<BcModel> Get()
        {
            var curLog = _dbContext.Logging.FirstOrDefault();
            var timeDiff = curLog.Timestamp - DateTime.UnixEpoch;
            BcModel newLog = new BcModel() {
                Id = curLog.Id,
                Username = curLog.Username,
                Timestamp = timeDiff.TotalSeconds
            };
            return Enumerable.Range(1, 1).Select(index => new BcModel() {
                    Id = curLog.Id,
                    Username = curLog.Username,
                    Timestamp = Math.Floor(timeDiff.TotalSeconds)
                })
                .ToArray();
        }
    }
}

﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HNCHOME.Controllers
{
    [Authorize]
    [Area("Admin")]
    public class BaseController : Controller
    {
        protected HNCDbContext _dbContext;
        public BaseController(HNCDbContext dbContext)
        {
            _dbContext = dbContext;
        }
    }
}

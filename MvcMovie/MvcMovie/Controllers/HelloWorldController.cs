﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Text.Encodings.Web;

namespace MvcMovie.Controllers
{
  public class HelloWorldController : Controller
  {
    // 
    // GET: /HelloWorld/

    public IActionResult Index()
    {
      return View();
    }
    public IActionResult Welcome(string name, int numTimes = 1)
    {
      ViewData["Message"] = "Hello " + name;
      ViewData["NumTimes"] = numTimes;

      return View();
    }
    public IActionResult Test()
    {
      return View();
    }
  }
}
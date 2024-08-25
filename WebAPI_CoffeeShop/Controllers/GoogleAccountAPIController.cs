using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WebAPI_CoffeeShop.Models;
using WebAPI_CoffeeShop.Repositories;

namespace WebAPI_CoffeeShop.Controllers
{
    public class GoogleAccountAPIController : ApiController
    {
        [HttpGet]
        public string connectGoogleAuth()
        {
            return null;
        }
        [HttpGet]
        public async Task<GoogleAccount> GoogleLoginCallBack(string code)
        {
            return null;
        }
    }
}

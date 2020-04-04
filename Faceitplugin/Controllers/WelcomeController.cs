using Microsoft.AspNetCore.Mvc;
using Faceitplayermodel.config;
using TodoApi.Models;
using Faceitplugin.Abstraction;
using Faceitplugin.Client;
using Faceitplugin.config;
using Faceitplugin.Modelle;
using Newtonsoft.Json;
using System.Net;

namespace Faceitplugin.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WelcomeController : ControllerBase
    {
        public TodoContext Context { get; }

        public WelcomeController(TodoContext context)
        {
            Context = context;
        }

        // GET: FaceitLivetimeStats
        [HttpGet]
        public IActionResult GetTodoItems()
        {
            var path = System.IO.Path.Combine(@"C:\_\FaceitCore\Faceitplugin\wwwroot\HTML", "index.html");
            return PhysicalFile(path, "text/html");
            /*return new ContentResult
            {
                ContentType = "text/html",
                StatusCode = (int)HttpStatusCode.OK,
                Content = System.IO.File.ReadAllText("C:/_/FaceitCore/Faceitplugin/wwwroot/HTML/index.html"),
            };*/

        }
    }
}
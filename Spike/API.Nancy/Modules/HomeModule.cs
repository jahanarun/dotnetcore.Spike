using Nancy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Nancy.Modules
{
    public class HomeModule : NancyModule
    {
        public HomeModule()
        {
            Get("/", args => "Hello Nancy World!");

            Get("/SayHello", args => $"Hello {this.Request.Query["name"]}");

            Get("/SayHello/{name}", args => $"Hello {args.name}");
        }
    }
}

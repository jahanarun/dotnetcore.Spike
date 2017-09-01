using API.Data.Context;
using API.Data.Models;
using Nancy;
using Nancy.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Nancy.Modules
{
    public class PeopleModule : NancyModule
    {
        private SpikeContext _context;

        public PeopleModule(SpikeContext context) 
            :base ("/people")
        {
            _context = context;
            Get("/", args => "Hello People World");
            Get("/all", args => {
                return new People { Name = "ttt", Age = 33 };
                //return _context.Peoples;
            });

            Get("/{id}", args =>
            {
                int id = Request.Query["id"];
                var item = _context.Peoples.FirstOrDefault(t => t.Id == id);
                return item;
            });

            Get("/alls", args =>
            {
                return Negotiate.WithModel(new People { Name = "Alls" });
                //.WithHeaders("X-Custom", "SomeValue");
            });

            Post("/", args =>
            {
                var people = this.Bind<People>();
                if (people == null)
                {
                    return null;
                }
                _context.Peoples.Add(people);
                _context.SaveChanges();
                return people;
            });

            Put("/{id}", args =>
            {
                var people = this.Bind<People>();
                if (people == null || people.Id != args.id)
                {
                    return null;
                }
                int id = args.id;
                var existingPeople = _context.Peoples.FirstOrDefault(x => x.Id == id);
                if (existingPeople == null)
                {
                    return null;
                }
                existingPeople.Age = people.Age;
                existingPeople.Name = people.Name;
                _context.SaveChanges();

                return people;
            });


        }
    }
}

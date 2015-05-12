using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Core;
using System.Data.Entity.Core;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MySql.Data.MySqlClient;

namespace webapi.Controllers
{
    public class Person
    {
        public int ID { get; set; }
        public string First { get; set; }
        public string Last { get; set; }
    }

    public class returnedDriver
    {
        public string nickname {get; set;}
        public string email {get;set;}
        public Nullable<sbyte> deleted { get; set; }

        public Nullable<System.DateTime> inactive_until { get; set; }
    }

    public delegate int MyDelegate(string obj);

    public class DriversController : ApiController
    {
        public void myAction(string text)
        {
            System.Diagnostics.Debug.Print(text);
        }

        

        int MyFunction(string text)
        {
            int i;
            Int32.TryParse(text,out i);
            return i;
        }

        // GET api/Person
        public IEnumerable<driver> Get()
        {
            MyDelegate deleg = MyFunction;
            /*deleg += delegate(string t)
            {
                return -10;
            };*/
            //deleg = s => return -11;
            

            returnedDriver rd = new returnedDriver();            


            System.Diagnostics.Debug.Write(deleg("lala"));
            System.Diagnostics.Debug.Write(deleg("105"));

            using(var db = new pairparkEntities())
            {
                
                
                driver d1 = new driver
                {
                    id = 2,
                    active = 1,
                    deleted = 0,
                    email = "eythimisspam@gmail.com",
                    nickname = "12345",
                    password = "1234"
                };

                db.drivers.Add(d1);
                
                

                try
                {
                    db.SaveChanges();
                }
                catch(DbEntityValidationException exc)
                {

                }
                
                

                db.Database.Log = myAction;
                
                /*
                var s = db.drivers.SqlQuery(@"select * from drivers d").ToList();

                return s;
                */

                //var s = db.Database.ExecuteSqlCommand("select * from drivers where nickname = @p0", "tim");
                var drivers = from d in db.drivers
                              select d;
                     //if we do not disable lazy loading then use the below, or else it fails
                     //to serialize
                     //new returnedDriver { nickname = d.nickname, email = d.email, deleted = d.deleted, inactive_until = d.inactive_until };

                var dr = db.drivers.Select(s => s).Where(s => s.nickname == "tim");
                
                return dr.ToList<driver>();               

            }
        }

        // GET api/Person/5
        //public Person Get(int id)
        //{
        //    return null;
        //}

        public IHttpActionResult GetDrivers(int id)
        {
            using(var db = new pairparkEntities())
            {
                db.Database.Log = myAction;
                
                //linq to entity
                var driver = db.drivers.FirstOrDefault(p => p.id == id);

                var l2equery = db.drivers.Where(s => s.active == 15);
                var oneDriver = l2equery.FirstOrDefault();

                var res = from d in db.drivers
                           group d by d.active into groupedActive
                           select groupedActive;

                foreach (var nameGroup in res)
                {
                    Console.WriteLine("Key: {0}", nameGroup.Key);
                    foreach (var driver3 in nameGroup)
                    {
                        Console.WriteLine("\t{0}, {1}", driver3.nickname, driver3.email);
                    }
                }


                if(driver == null)
                {
                    return NotFound();
                }
                else
                {
                    db.Entry<driver>(driver).Collection(s => s.cars).Load();

                    return Ok(driver);

                }
            }
           
        }

        // POST api/Person
        public IHttpActionResult Post(driver value)
        {
            using(var db = new pairparkEntities())
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                db.drivers.Add(value);
                db.SaveChanges();

                return Ok();
            }
            

            

        }

        // PUT api/Person/5
        public void Put(int id, [FromBody]Person value)
        {
        }

        // DELETE api/Person/5
        public void Delete(int id)
        {
        }

        
    }
}
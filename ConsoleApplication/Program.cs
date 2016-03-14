using NinjaDomain.Classes;
using NinjaDomain.DataModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Database.SetInitializer(new NullDatabaseInitializer<NinjaContext>());
            //InsertNinja();
            //InsertMultipleNinjas();
            //SimpleNinjaQueries();
            //QueryAndUpdateNinja();
            //QueryAndUpdateNinjaDisconnected();
            DeleteNinja();
            //InsertNinjaWithEquipment();
            //SimpleNinjaGraphQuery();
            ProjectionQuery();

            Console.ReadKey();
        }

        private static void ProjectionQuery()
        {
            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;

                var ninjas = context.Ninjas.Select
                    (n => new { n.Name, n.DateOfBirth, n.EquipmentOwned }).ToList();

                foreach (var ninja in ninjas)
                {
                    Console.WriteLine(" " + ninja.Name, ninja.DateOfBirth);
                    foreach (var item in ninja.EquipmentOwned)
                    {
                        Console.WriteLine("\t{0}:  {1}", item.Type, item.Name);
                    }
                }

            }
        }

        private static void SimpleNinjaGraphQuery()
        {
            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;

                var ninja = context.Ninjas.FirstOrDefault(n => n.Name.StartsWith("Kacy"));
                Console.WriteLine("Ninja Retrieved: {0}", ninja.Name);
                //context.Entry(ninja).Collection(n => n.EquipmentOwned).Load();
                Console.WriteLine("Ninja Equipment Count: {0}", ninja.EquipmentOwned.Count);
            }
        }

        private static void InsertNinjaWithEquipment()
        {
            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;

                var ninja = new Ninja
                {
                    Name = "Kacy fjdk",
                    ServedInOniwaban = false,
                    DateOfBirth = new DateTime(1990, 1, 14),
                    ClanId = 1
                };
                var muscles = new NinjaEquipment
                {
                    Name = "Mouth",
                    Type = EquipmentType.Tool
                };
                var spunk = new NinjaEquipment
                {
                    Name = "Hurtful Words",
                    Type = EquipmentType.Weapon
                };
                context.Ninjas.Add(ninja);
                ninja.EquipmentOwned.Add(muscles);
                ninja.EquipmentOwned.Add(spunk);
                context.SaveChanges();
            }
        }

        private static void DeleteNinja()
        {
            Ninja ninja;
            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                ninja = context.Ninjas.FirstOrDefault(n => n.Name.StartsWith("Kacy"));
                context.Entry(ninja).State = EntityState.Deleted;
                context.SaveChanges();

                //context.Ninjas.Remove(ninja);
                //context.SaveChanges();

            }
            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                //context.Ninjas.Attach(ninja);
                //context.Ninjas.Remove(ninja);
            }
        }


        //This method is to for a website or service to retrieve data from database to a client, 
        //manipulate the data, send it back through website or service and update database.
        private static void QueryAndUpdateNinjaDisconnected()
        {
            Ninja ninja;
            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                ninja = context.Ninjas.FirstOrDefault();
            }

            ninja.ServedInOniwaban = (!ninja.ServedInOniwaban);

            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                //context.Ninjas.Add(ninja);
                context.Ninjas.Attach(ninja);
                context.Entry(ninja).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        private static void QueryAndUpdateNinja()
        {
            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                var ninja = context.Ninjas.Where(n => n.Name == "StephanieElder").FirstOrDefault();
                ninja.Name = "Stephanie Elder";
                context.SaveChanges();
            }
        }

        private static void SimpleNinjaQueries()
        {
            using (var context = new NinjaContext())
            {
                var ninjas = context.Ninjas.ToList();
                foreach (var ninja in context.Ninjas)
                {
                    Console.WriteLine(ninja.Name);
                }
                context.Database.Log = Console.WriteLine;
            }
        }

        private static void InsertNinja()
        {
            var ninja = new Ninja
            {
                Name = "StephanieElder",
                ServedInOniwaban = false,
                DateOfBirth = new DateTime(1979, 9, 17),
                ClanId = 1
            };

            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                context.Ninjas.Add(ninja);
                context.SaveChanges();
            }
        }

        private static void InsertMultipleNinjas()
        {
            var ninja1 = new Ninja
            {
                Name = "JustinElder",
                ServedInOniwaban = false,
                DateOfBirth = new DateTime(1979,8,14),
                ClanId =1
            };
            var ninja2 = new Ninja
            {
                Name = "StephanieElder",
                ServedInOniwaban = false,
                DateOfBirth = new DateTime(1979,9,17),
                ClanId = 1
            };

            using (var context = new NinjaContext())
            {
                context.Database.Log = Console.WriteLine;
                context.Ninjas.AddRange(new List<Ninja> { ninja1, ninja2 });
                context.SaveChanges();
            }
        }
    }
}

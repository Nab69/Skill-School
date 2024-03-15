using Dal;
using DomainModel;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TestDb();
            Console.WriteLine("Hello, World!");
        }

        static void TestDb()
        {
            using (var context = new SchoolContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                //context.People.ToList();


                // --- add ---

                //var classroom = new Classroom()
                //{
                //    Name = "Salle Bill Gates",
                //    Floor = 3,
                //    Corridor = "A"
                //};

                //context.Classrooms.Add(classroom);
                //context.SaveChanges();

                // --- update ---

                //var classroom = new Classroom()
                //{
                //    ClassroomID = 1,
                //    Name = "Salle Satya Nadella",
                //    Floor = 3,
                //    Corridor = "B"
                //};

                //context.Classrooms.Update(classroom);
                //context.SaveChanges();

                // --- remove

                //Classroom? classroom = context.Classrooms.Find(1);

                //if(classroom != null)
                //{
                //    context.Classrooms.Remove(classroom);
                //    context.SaveChanges();
                //}

            }// appel Dispose() implicite
        }
    }
}

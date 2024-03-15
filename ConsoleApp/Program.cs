using Dal;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TestDb();
            Console.WriteLine("Hello, World!");
        }

        static void TestDb()
        {
            using (var context = new SchoolContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.People.ToList();

            }// appel Dispose() implicite
        }
    }
}

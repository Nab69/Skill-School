using Dal;
using DomainModel;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Data;
using System.Security.AccessControl;
using System;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TestDb();
            Console.WriteLine("Hello, World!");
        }

        static void Queries()
        {
            using (var context = new SchoolContext())
            {
                //	Affichez toutes les personnes

                IEnumerable<Person> people = context.People;

                foreach (var person in people) // requête sql
                {
                    Console.WriteLine($"{person.FirstName} {person.LastName}");
                }

                //	Affichez tous les étudiants

                List<Student> students = context.Students.ToList(); // requête sql

                foreach (var student in students) // requête sql
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName}, average : {student.Average}");
                }

                //	Affichez la personne ayant la clé primaire égale à 2

                Person? person1 = context.People.Find(2);

                if( person1 != null )
                    Console.WriteLine($"{person1.FirstName} {person1.LastName}");

                //	Filtrez et affichez les personnes ayant un âge supérieur ou égal à 30 ans

                List<Person> personOlderThan30 = context.People.Where(p => p.Age >= 30)
                                                               .ToList();

                //	Sélectionnez et affichez le prénom des personnes

                string[] firstNames = context.People.Select(p => p.FirstName)
                                                    .ToArray();

                //	Sélectionnez et affichez le prénom et le nom des personnes

                var firstNamesAndLastNames = context.People.Select(p => new { p.FirstName, p.LastName })
                                                           .ToArray();

                foreach (var item in firstNamesAndLastNames)
                {
                    Console.WriteLine($"{item.FirstName} {item.LastName}");
                }

                //	Récupérez et affichez la première personne de la liste qui a un âge supérieur à 30 ans

                Person person2 = context.People.First(p => p.Age >= 30);

                //	Récupérez et affichez la dernière personne de la liste qui a un âge supérieur à 30 ans

                Person person3 = context.People.OrderBy(p => p.Age)
                                               .Last(p => p.Age >= 30);

                Person person4 = context.People.OrderByDescending(p => p.Age)
                                               .First(p => p.Age >= 30);

                //	Récupérez et affichez la seule personne qui a plus de 60 ans

                Person person5 = context.People.Single(p => p.Age >= 60);

                //	Affichez la liste triée par prénoms

                List<Person> people2 = context.People.OrderBy(p => p.FirstName)
                                                     .ToList();

                //	Affichez la liste triée par âge, puis par nom en tri secondaire, puis par prénom en tri tertiaire

                List<Person> people3 = context.People.OrderBy(p => p.Age)
                                                     .ThenBy(p => p.LastName)
                                                     .ThenBy(p => p.FirstName)
                                                     .ToList();

                //	Filtrez les personnes dont le nom commence par la lettre S,
                //puis triez les données par âge, puis sélectionnez uniquement l'âge

                List<int?> ages = context.People.Where(p => p.LastName.StartsWith("S"))
                                                .OrderBy(p => p.Age)
                                                .Select(p => p.Age)
                                                .ToList();

                //	Récupérez et affichez la classroom avec l’id égale à 1, ainsi que ses étudiants et son professeur

                Classroom classroom = context.Classrooms.Include(c => c.Students)
                                                        .Include(c => c.Teacher)
                                                        .Single(c => c.ClassroomID == 1);

                //	Affichez le nombre et la moyenne de tous les étudiants

                int numberOfStudents = context.Students.Count();

                double averageOfStudents = context.Students.Average(p => p.Average);

            }
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

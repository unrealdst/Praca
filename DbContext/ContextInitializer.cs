using System.Collections.Generic;
using System.Data.Entity;
using DbContext.Models;

namespace DbContext
{
    public class ContextInitializer : DropCreateDatabaseIfModelChanges<Context>
    {
        protected override void Seed(Context context)
        {
            var projects = new List<Project>();
            for (int i = 0; i < 10; i++)
            {
                projects.Add(new Project()
                {
                    Id=i,
                    Name = @"Name{i}"
                });
            }

            projects.ForEach(x => context.Projects.Add(x));
            context.SaveChanges();

        }
    }
}
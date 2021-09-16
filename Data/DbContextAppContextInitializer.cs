using Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class DbContextAppContextInitializer : DropCreateDatabaseIfModelChanges<DbContextApp>
    {
        protected override void Seed(DbContextApp context)
        {
            base.Seed(context);

            for (int i = 0; i < 2; i++)
            {
                var newRoot = new RootModel() { ID = i, Title = $"Корневой элемент: {DateTime.Now}" };
                for (int j = 0; j < 3; j++)
                {
                    var newChild = new ChildModel() { ID = i, Title = $"Дочерний элемент: {DateTime.Now}", ParentID = i };
                    context.Children.Add(newChild);
                }
                context.Roots.Add(newRoot);
            }

            context.SaveChanges();
        }
    }
}

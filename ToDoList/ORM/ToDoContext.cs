using System.Data.Entity;

namespace ORM
{
    public class ToDoContext : DbContext
    {
        public ToDoContext() : base("name=ToDoContext")
        {

        }

        public DbSet<Task> Tasks { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TodoApi.Models;

namespace TodoApi.Data
{

    public class TodoContext : DbContext
    {

        public DbSet<TodoItem> TodoItems { get; set; }
        public DbSet<Category> Categories { get; set; }


        public TodoContext(DbContextOptions<TodoContext> options) : base(options)
        {
        


        }
        /*protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=todoitems;User=root1;Password=1234;");
        }*/

    }
}




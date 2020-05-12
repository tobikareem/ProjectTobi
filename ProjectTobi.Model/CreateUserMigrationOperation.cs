
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace ProjectTobi.Model
{
    public class CreateUserMigrationOperation : MigrationOperation
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}

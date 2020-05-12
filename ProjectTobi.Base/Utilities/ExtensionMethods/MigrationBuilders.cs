
using Microsoft.EntityFrameworkCore.Migrations;
using ProjectTobi.Model;

namespace ProjectTobi.Base.Utilities.ExtensionMethods
{
    /// <summary>
    /// This class is to extend the Migration builder
    /// </summary>
    public static class MigrationBuilders
    {
        /// <summary>
        /// Method to create a new user to the DB
        /// </summary>
        /// <param name="migration"></param>
        /// <param name="name"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static MigrationBuilder CreateUser(this MigrationBuilder migrationBuilder, string name, string password)
        {
            migrationBuilder.Operations.Add(
                new CreateUserMigrationOperation { UserName = name, Password = password }
                );


            return migrationBuilder;
        }

    }
}

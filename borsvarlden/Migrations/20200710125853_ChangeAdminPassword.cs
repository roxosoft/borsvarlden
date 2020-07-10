using Microsoft.EntityFrameworkCore.Migrations;

namespace borsvarlden.Migrations
{
    public partial class ChangeAdminPassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData("ApplicationUsers", "UserName", "admin", "PasswordHash",  "26C47F623988A3B69053047DD79CA5A7");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData("ApplicationUsers", "UserName", "admin", "PasswordHash", "21232F297A57A5A743894A0E4A801FC3");
        }
    }
}

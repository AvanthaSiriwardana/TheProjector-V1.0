using Microsoft.EntityFrameworkCore.Migrations;

namespace TheProjector.Domain.Migrations
{
    public partial class TheProjectorInitialMigrationV10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Persons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(200)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(11)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Persons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Remarks = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Budget = table.Column<decimal>(type: "decimal(18,4)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectAssignment",
                columns: table => new
                {
                    ProjectId = table.Column<int>(nullable: false),
                    PersonId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectAssignment", x => new { x.PersonId, x.ProjectId });
                    table.ForeignKey(
                        name: "FK_ProjectAssignment_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectAssignment_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Persons",
                columns: new[] { "Id", "FirstName", "LastName", "Password", "UserName" },
                values: new object[,]
                {
                    { 1, "Person 1", "Person 1", "Person 1", "Person 1" },
                    { 2, "Person 2", "Person 2", "Person 2", "Person 2" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Budget", "Code", "Name", "Remarks" },
                values: new object[,]
                {
                    { 1, 152000m, "Project 1", "Project 1", "Project 1" },
                    { 2, 75000m, "Project 2", "Project 2", "Project 2" }
                });

            migrationBuilder.InsertData(
                table: "ProjectAssignment",
                columns: new[] { "PersonId", "ProjectId" },
                values: new object[] { 1, 1 });

            migrationBuilder.InsertData(
                table: "ProjectAssignment",
                columns: new[] { "PersonId", "ProjectId" },
                values: new object[] { 2, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectAssignment_ProjectId",
                table: "ProjectAssignment",
                column: "ProjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectAssignment");

            migrationBuilder.DropTable(
                name: "Persons");

            migrationBuilder.DropTable(
                name: "Projects");
        }
    }
}

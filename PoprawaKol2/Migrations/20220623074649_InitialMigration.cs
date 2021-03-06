using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PoprawaKol2.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Organizations",
                columns: table => new
                {
                    OrganizationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    OrganizationDomain = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organizations", x => x.OrganizationID);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    MemberID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationID = table.Column<int>(type: "int", nullable: false),
                    MemberName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    MemberSurname = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    MemberNickName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.MemberID);
                    table.ForeignKey(
                        name: "FK_Members_Organizations_OrganizationID",
                        column: x => x.OrganizationID,
                        principalTable: "Organizations",
                        principalColumn: "OrganizationID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    TeamID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationID = table.Column<int>(type: "int", nullable: false),
                    TeamName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    TeamDescription = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.TeamID);
                    table.ForeignKey(
                        name: "FK_Teams_Organizations_OrganizationID",
                        column: x => x.OrganizationID,
                        principalTable: "Organizations",
                        principalColumn: "OrganizationID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Files",
                columns: table => new
                {
                    FileID = table.Column<int>(type: "int", nullable: false),
                    TeamID = table.Column<int>(type: "int", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FileExtension = table.Column<string>(type: "nvarchar(4)", maxLength: 4, nullable: false),
                    FileSize = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Files", x => new { x.FileID, x.TeamID });
                    table.ForeignKey(
                        name: "FK_Files_Teams_TeamID",
                        column: x => x.TeamID,
                        principalTable: "Teams",
                        principalColumn: "TeamID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Memberships",
                columns: table => new
                {
                    MemberID = table.Column<int>(type: "int", nullable: false),
                    TeamID = table.Column<int>(type: "int", nullable: false),
                    MembershipDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Memberships", x => new { x.MemberID, x.TeamID });
                    table.ForeignKey(
                        name: "FK_Memberships_Members_MemberID",
                        column: x => x.MemberID,
                        principalTable: "Members",
                        principalColumn: "MemberID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Memberships_Teams_TeamID",
                        column: x => x.TeamID,
                        principalTable: "Teams",
                        principalColumn: "TeamID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "OrganizationID", "OrganizationDomain", "OrganizationName" },
                values: new object[] { 1, "What is a domain", "PJWSTK" });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "OrganizationID", "OrganizationDomain", "OrganizationName" },
                values: new object[] { 2, "Like https?", "PJATK" });

            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "OrganizationID", "OrganizationDomain", "OrganizationName" },
                values: new object[] { 3, "I don't get it", "PJAIT" });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "MemberID", "MemberName", "MemberNickName", "MemberSurname", "OrganizationID" },
                values: new object[,]
                {
                    { 1, "Jan", "xXDevastatorXx", "Kowalski", 1 },
                    { 2, "Adrian", "GodKiller420BlazeIt", "Kura", 2 },
                    { 3, "Michał", null, "Góra", 3 }
                });

            migrationBuilder.InsertData(
                table: "Teams",
                columns: new[] { "TeamID", "OrganizationID", "TeamDescription", "TeamName" },
                values: new object[,]
                {
                    { 1, 1, "Cool subject", "NAI" },
                    { 2, 2, "Really cool subject", "APBD" },
                    { 3, 3, "Not a very cool subject", "PRI" }
                });

            migrationBuilder.InsertData(
                table: "Files",
                columns: new[] { "FileID", "TeamID", "FileExtension", "FileName", "FileSize" },
                values: new object[,]
                {
                    { 1, 1, "txt", "Bayes", 12345 },
                    { 2, 1, "txt", "kNN", 12345 },
                    { 3, 2, "docx", "EFCore", 12345 },
                    { 4, 2, "docx", "CodeFirst", 12345 },
                    { 5, 3, "jpg", "Class Diagram", 12345 },
                    { 6, 3, "png", "UseCase Diagram", 12345 }
                });

            migrationBuilder.InsertData(
                table: "Memberships",
                columns: new[] { "MemberID", "TeamID", "MembershipDate" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2020, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1, new DateTime(2020, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, 2, new DateTime(2020, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 2, new DateTime(2020, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 1, new DateTime(2020, 1, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 2, new DateTime(2020, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, 3, new DateTime(2020, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 3, new DateTime(2020, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 3, new DateTime(2020, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Files_TeamID",
                table: "Files",
                column: "TeamID");

            migrationBuilder.CreateIndex(
                name: "IX_Members_OrganizationID",
                table: "Members",
                column: "OrganizationID");

            migrationBuilder.CreateIndex(
                name: "IX_Memberships_TeamID",
                table: "Memberships",
                column: "TeamID");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_OrganizationID",
                table: "Teams",
                column: "OrganizationID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Files");

            migrationBuilder.DropTable(
                name: "Memberships");

            migrationBuilder.DropTable(
                name: "Members");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Organizations");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace EduHome.Migrations
{
    public partial class CreateTeacherTeacherDetailTeacherPositionTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TeacherPositions",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherPositions", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Teachers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Facebook = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pinterest = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Violet = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Twitter = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TeacherPositionID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teachers", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Teachers_TeacherPositions_TeacherPositionID",
                        column: x => x.TeacherPositionID,
                        principalTable: "TeacherPositions",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TeacherDetails",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TeacherID = table.Column<int>(type: "int", nullable: false),
                    AboutMe = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DEGREE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EXPERIENCE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HOBBIES = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FACULTY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MAILME = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MAKECALL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SKYPE = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Language = table.Column<double>(type: "float", nullable: false),
                    TeamLeader = table.Column<double>(type: "float", nullable: false),
                    Development = table.Column<double>(type: "float", nullable: false),
                    Design = table.Column<double>(type: "float", nullable: false),
                    Innovation = table.Column<double>(type: "float", nullable: false),
                    Communication = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherDetails", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TeacherDetails_Teachers_TeacherID",
                        column: x => x.TeacherID,
                        principalTable: "Teachers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TeacherDetails_TeacherID",
                table: "TeacherDetails",
                column: "TeacherID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_TeacherPositionID",
                table: "Teachers",
                column: "TeacherPositionID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TeacherDetails");

            migrationBuilder.DropTable(
                name: "Teachers");

            migrationBuilder.DropTable(
                name: "TeacherPositions");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace SongRecommendation.Migrations
{
    public partial class addUserGradesToDatabaseBetter : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Genre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Type = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "SongsDB",
                columns: table => new
                {
                    id = table.Column<short>(type: "smallint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    artist_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    release_id = table.Column<int>(type: "int", nullable: false),
                    release_name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    song_id = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    terms = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    year = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SongsDB", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "UserGrades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SongId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Grade = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGrades", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "SongsDB");

            migrationBuilder.DropTable(
                name: "UserGrades");
        }
    }
}

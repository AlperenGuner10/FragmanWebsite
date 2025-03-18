using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieMVC.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreId);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    MovieId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BigPictureFirst = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Aciklama = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PictureFirst = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AciklamaFirst = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PictureSecond = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AciklamaSecond = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BigPictureSecond = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BigAciklamaSecond = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BigPictureThird = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BigAciklamaThird = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PictureFourth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BigAciklamaFourth = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.MovieId);
                    table.ForeignKey(
                        name: "FK_Movies_Genres_GenreId",
                        column: x => x.GenreId,
                        principalTable: "Genres",
                        principalColumn: "GenreId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Movies_GenreId",
                table: "Movies",
                column: "GenreId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Genres");
        }
    }
}

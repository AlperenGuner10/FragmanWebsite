using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieMVC.Migrations
{
    /// <inheritdoc />
    public partial class mig_1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AciklamaSecond",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "BigAciklamaFourth",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "BigAciklamaSecond",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "BigAciklamaThird",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "BigPictureSecond",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "BigPictureThird",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "PictureFourth",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "PictureSecond",
                table: "Movies");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AciklamaSecond",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BigAciklamaFourth",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BigAciklamaSecond",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BigAciklamaThird",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BigPictureSecond",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "BigPictureThird",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PictureFourth",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PictureSecond",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}

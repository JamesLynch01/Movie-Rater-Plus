using Microsoft.EntityFrameworkCore.Migrations;

namespace capstone.Data.Migrations
{
    public partial class MovieInfoData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MovieInfos",
                columns: new[] { "Id", "Director", "MainCatergory", "Title", "UserRating" },
                values: new object[] { 1, "Michael Bay", "Action-Mess", "Transformers", 2 });

            migrationBuilder.InsertData(
                table: "MovieInfos",
                columns: new[] { "Id", "Director", "MainCatergory", "Title", "UserRating" },
                values: new object[] { 2, "Rosso Brothers", "SuperHero", "Endgame", 5 });

            migrationBuilder.InsertData(
                table: "MovieInfos",
                columns: new[] { "Id", "Director", "MainCatergory", "Title", "UserRating" },
                values: new object[] { 3, "Nora Ephron", "Romantic Comedy", "Sleepless in Seattle", 4 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MovieInfos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MovieInfos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MovieInfos",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}

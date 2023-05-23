using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataAccessLibrary.Migrations
{
    /// <inheritdoc />
    public partial class initialdb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hobbies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hobbies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "State",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_State", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    HobbyId = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Hobbies_HobbyId",
                        column: x => x.HobbyId,
                        principalTable: "Hobbies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_User_State_StateId",
                        column: x => x.StateId,
                        principalTable: "State",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Hobbies",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Football" },
                    { 2, "Movie Binge" },
                    { 3, "Reading" },
                    { 4, "Music" },
                    { 5, "Photography" },
                    { 6, "Cooking" },
                    { 7, "Painting" }
                });

            migrationBuilder.InsertData(
                table: "State",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Andhra Pradesh" },
                    { 2, "Arunachal Pradesh" },
                    { 3, "Assam" },
                    { 4, "Bihar" },
                    { 5, "Chhattisgarh" },
                    { 6, "Goa" },
                    { 7, "Gujarat" },
                    { 8, "Haryana" },
                    { 9, "Himachal Pradesh" },
                    { 10, "Jammu and Kashmir" },
                    { 11, "Jharkhand" },
                    { 12, "Karnataka" },
                    { 13, "Kerala" },
                    { 14, "Madhya Pradesh" },
                    { 15, "Maharashtra" },
                    { 16, "Manipur" },
                    { 17, "Meghalaya" },
                    { 18, "Mizoram" },
                    { 19, "Nagaland" },
                    { 20, "Odisha" },
                    { 21, "Punjab" },
                    { 22, "Rajasthan" },
                    { 23, "Sikkim" },
                    { 24, "Tamil Nadu" },
                    { 25, "Telangana" },
                    { 26, "Tripura" },
                    { 27, "Uttarakhand" },
                    { 28, "Uttar Pradesh" },
                    { 29, "West Bengal" },
                    { 30, "Andaman and Nicobar Islands" },
                    { 31, "Chandigarh" },
                    { 32, "Dadra and Nagar Haveli" },
                    { 33, "Daman and Diu" },
                    { 34, "Delhi" },
                    { 35, "Lakshadweep" },
                    { 36, "Puducherry" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_HobbyId",
                table: "User",
                column: "HobbyId");

            migrationBuilder.CreateIndex(
                name: "IX_User_StateId",
                table: "User",
                column: "StateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "Hobbies");

            migrationBuilder.DropTable(
                name: "State");
        }
    }
}

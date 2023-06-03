using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace e_Book.Migrations
{
    /// <inheritdoc />
    public partial class _5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfilePicture = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.ID);
                });
            migrationBuilder.CreateTable(
               name: "Actors_Movies",
               columns: table => new
               {
                   MovieId = table.Column<int>(type: "int", nullable: false),
                   AuthorID = table.Column<int>(type: "int", nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Actors_Movies", x => new { x.AuthorID, x.MovieId });
                   table.ForeignKey(
                       name: "FK_Actors_Movies_Actors_ActorId",
                       column: x => x.AuthorID,
                       principalTable: "Authors",
                       principalColumn: "ID",
                       onDelete: ReferentialAction.Cascade);
                   table.ForeignKey(
                       name: "FK_Actors_Movies_Movies_MovieId",
                       column: x => x.MovieId,
                       principalTable: "Movies",
                       principalColumn: "ID",
                       onDelete: ReferentialAction.Cascade);
               });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

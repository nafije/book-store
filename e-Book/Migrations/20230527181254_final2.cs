using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace e_Book.Migrations
{
    /// <inheritdoc />
    public partial class final2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
          name: "Publishing_house",
          columns: table => new
          {
              ID = table.Column<int>(type: "int", nullable: false)
                  .Annotation("SqlServer:Identity", "1, 1"),
              Logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
              Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
              Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
          },
          constraints: table =>
          {
              table.PrimaryKey("PK_Publishing_house", x => x.ID);
          });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookCategory = table.Column<int>(type: "int", nullable: false),
                    Publishing_HouseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Books_Publishing_house_Publishing_HouseId",
                        column: x => x.Publishing_HouseId,
                        principalTable: "Publishing_house",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Author_Book",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false),
                    AuthorID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Author_Book", x => new { x.AuthorID, x.BookId });
                    table.ForeignKey(
                        name: "FK_Author_Book_Authors_AuthorID",
                        column: x => x.AuthorID,
                        principalTable: "Authors",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Author_Book_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Author_Book_BookId",
                table: "Author_Book",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_Publishing_HouseId",
                table: "Books",
                column: "Publishing_HouseId");

          

            migrationBuilder.CreateTable(
              name: "Coments",
               columns: table => new
               {
                   ID = table.Column<int>(type: "int", nullable: false)
                       .Annotation("SqlServer:Identity", "1, 1"),
                   Comment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                   CommentedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                   BookID = table.Column<int>(type: "int", nullable: false)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Coments", x => x.ID);
                   table.ForeignKey(
                       name: "FK_Coments_Books_BookID",
                       column: x => x.BookID,
                       principalTable: "Books",
                       principalColumn: "ID",
                       onDelete: ReferentialAction.Cascade);
               });
            //migrationBuilder.AddForeignKey(
            //  name: "FK_Coments_Books_BookID",
            //  table: "Coments",
            //  column: "BookID",
            //  principalTable: "Books",
            //  principalColumn: "ID",
            //  onDelete: ReferentialAction.Cascade);
            migrationBuilder.CreateIndex(
                name: "IX_Coments_BookID",
                table: "Coments",
                column: "BookID");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

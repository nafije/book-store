﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace e_Book.Migrations
{
    /// <inheritdoc />
    public partial class final : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Coments_Movies_MovieID",
            //    table: "Coments");

            //migrationBuilder.DropTable(
            //    name: "Actors_Movies");

            //migrationBuilder.DropTable(
            //    name: "Movies");

            //migrationBuilder.DropTable(
            //    name: "Cinemas");

            //migrationBuilder.DropTable(
            //    name: "Producers");

            //migrationBuilder.RenameColumn(
            //    name: "MovieID",
            //    table: "Coments",
            //    newName: "BookID");

            //migrationBuilder.RenameIndex(
            //    name: "IX_Coments_MovieID",
            //    table: "Coments",
            //    newName: "IX_Coments_BookID");

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
                        name: "FK_Author_Book_Books_MovieId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Author_Book_MovieId",
                table: "Author_Book",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_Books_Publishing_HouseId",
                table: "Books",
                column: "Publishing_HouseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Coments_Books_BookID",
                table: "Coments",
                column: "BookID",
                principalTable: "Books",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

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

            migrationBuilder.CreateIndex(
                name: "IX_Coments_BookID",
                table: "Coments",
                column: "BookID");
        }
       

/// <inheritdoc />
protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Coments_Books_BookID",
            //    table: "Coments");

            //migrationBuilder.DropTable(
            //    name: "Author_Book");

            //migrationBuilder.DropTable(
            //    name: "Books");

            //migrationBuilder.DropTable(
            //    name: "Publishing_house");

            //migrationBuilder.RenameColumn(
            //    name: "BookID",
            //    table: "Coments",
            //    newName: "MovieID");

            //migrationBuilder.RenameIndex(
            //    name: "IX_Coments_BookID",
            //    table: "Coments",
            //    newName: "IX_Coments_MovieID");

            //migrationBuilder.CreateTable(
            //    name: "Cinemas",
            //    columns: table => new
            //    {
            //        ID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Logo = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Cinemas", x => x.ID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Producers",
            //    columns: table => new
            //    {
            //        ID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        Bio = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        FullName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
            //        ProfilePicture = table.Column<string>(type: "nvarchar(max)", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Producers", x => x.ID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Movies",
            //    columns: table => new
            //    {
            //        ID = table.Column<int>(type: "int", nullable: false)
            //            .Annotation("SqlServer:Identity", "1, 1"),
            //        CinemaId = table.Column<int>(type: "int", nullable: false),
            //        ProducerId = table.Column<int>(type: "int", nullable: false),
            //        Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        ImageURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        MovieCategory = table.Column<int>(type: "int", nullable: false),
            //        Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Price = table.Column<double>(type: "float", nullable: false),
            //        StartDate = table.Column<DateTime>(type: "datetime2", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Movies", x => x.ID);
            //        table.ForeignKey(
            //            name: "FK_Movies_Cinemas_CinemaId",
            //            column: x => x.CinemaId,
            //            principalTable: "Cinemas",
            //            principalColumn: "ID",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Movies_Producers_ProducerId",
            //            column: x => x.ProducerId,
            //            principalTable: "Producers",
            //            principalColumn: "ID",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Actors_Movies",
            //    columns: table => new
            //    {
            //        AuthorID = table.Column<int>(type: "int", nullable: false),
            //        MovieId = table.Column<int>(type: "int", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Actors_Movies", x => new { x.AuthorID, x.MovieId });
            //        table.ForeignKey(
            //            name: "FK_Actors_Movies_Authors_AuthorID",
            //            column: x => x.AuthorID,
            //            principalTable: "Authors",
            //            principalColumn: "ID",
            //            onDelete: ReferentialAction.Cascade);
            //        table.ForeignKey(
            //            name: "FK_Actors_Movies_Movies_MovieId",
            //            column: x => x.MovieId,
            //            principalTable: "Movies",
            //            principalColumn: "ID",
            //            onDelete: ReferentialAction.Cascade);
            //    });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Actors_Movies_MovieId",
            //    table: "Actors_Movies",
            //    column: "MovieId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Movies_CinemaId",
            //    table: "Movies",
            //    column: "CinemaId");

            //migrationBuilder.CreateIndex(
            //    name: "IX_Movies_ProducerId",
            //    table: "Movies",
            //    column: "ProducerId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Coments_Movies_MovieID",
            //    table: "Coments",
            //    column: "MovieID",
            //    principalTable: "Movies",
            //    principalColumn: "ID",
             //   onDelete: ReferentialAction.Cascade);
        }
    }
}

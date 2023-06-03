using e_Book.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using e_Book.Data.Enums;
using e_Book.Data.Static;
using e_Book.Models;
namespace e_Book.Data
{
    public class AppDbInitializzer
    {
        public async Task Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();

                context.Database.EnsureCreated();
                //Commnt
                if (!context.Coments.Any())
                {
                    context.Coments.AddRange(new List<Coments>() {
                        new Coments()
                        {
                            Comment="Coment 1",
                            FullName="Admin User",
                            CommentedOn=DateTime.Now,
                            BookID=2
                        }
                        //,
                        //new Coments()
                        //{
                        //    Comment="Coment 2",
                        //    CommentedOn=DateTime.Now,
                        //    PostID=2
                        //},
                        //new Coments()
                        //{
                        //    Comment="Coment 3",
                        //    CommentedOn=DateTime.Now,
                        //    PostID=2
                        //}
                    });
                    context.SaveChanges();
                }
                //Cinema
                if (!context.Publishing_house.Any())
                {
                    context.Publishing_house.AddRange(new List<Publishing_house>()
                    {
                        new Publishing_house()
                        {
                            Name = "Cinema 1",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-1.jpeg",
                            Description = "This is the description of the first cinema"
                        },
                        new Publishing_house()
                        {
                            Name = "Cinema 2",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-2.jpeg",
                            Description = "This is the description of the first cinema"
                        },
                        new Publishing_house()
                        {
                            Name = "Cinema 3",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-3.jpeg",
                            Description = "This is the description of the first cinema"
                        },
                        new Publishing_house()
                        {
                            Name = "Cinema 4",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-4.jpeg",
                            Description = "This is the description of the first cinema"
                        },
                        new Publishing_house()
                        {
                            Name = "Cinema 5",
                            Logo = "http://dotnethow.net/images/cinemas/cinema-5.jpeg",
                            Description = "This is the description of the first cinema"
                        },
                    });
                    context.SaveChanges();
                }
                //Actors
                if (!context.Authors.Any())
                {
                    context.Authors.AddRange(new List<Authors>()
                    {
                        new Authors()
                        {
                            FullName = "Author 1",
                            Bio = "This is the Bio of the first author",
                            ProfilePicture = "http://dotnethow.net/images/actors/actor-1.jpeg"

                        },
                        new Authors()
                        {
                            FullName = "Author 2",
                            Bio = "This is the Bio of the second author",
                            ProfilePicture = "http://dotnethow.net/images/actors/actor-2.jpeg"
                        },
                        new Authors()
                        {
                            FullName = "Author 3",
                            Bio = "This is the Bio of the second author",
                            ProfilePicture = "http://dotnethow.net/images/actors/actor-3.jpeg"
                        },
                        new Authors()
                        {
                            FullName = "Author 4",
                            Bio = "This is the Bio of the second author",
                            ProfilePicture = "http://dotnethow.net/images/actors/actor-4.jpeg"
                        },
                        new Authors()
                        {
                            FullName = "Author 5",
                            Bio = "This is the Bio of the second author",
                            ProfilePicture = "http://dotnethow.net/images/actors/actor-5.jpeg"
                        }
                    });
                    context.SaveChanges();
                }
                
                //Movies
                if (!context.Books.Any())
                {
                    context.Books.AddRange(new List<Books>()
                    {
                        new Books()
                        {
                            Name = "Life",
                            Description = "This is the Life movie description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-3.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(10),
                            Publishing_HouseId = 3,
                            BookCategory = BookCategory.Documentary
                        },
                        new Books()
                        {
                            Name = "Race",
                            Description = "This is the Race movie description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-6.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-5),
                            Publishing_HouseId = 1,
                            BookCategory = BookCategory.Documentary
                        },
                        new Books()
                        {
                            Name = "Scoob",
                            Description = "This is the Scoob movie description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-7.jpeg",
                            StartDate = DateTime.Now.AddDays(-10),
                            EndDate = DateTime.Now.AddDays(-2),
                            Publishing_HouseId = 1,
                            BookCategory = BookCategory.Animation
                        },
                        new Books()
                        {
                            Name = "Cold Soles",
                            Description = "This is the Cold Soles movie description",
                            Price = 39.50,
                            ImageURL = "http://dotnethow.net/images/movies/movie-8.jpeg",
                            StartDate = DateTime.Now.AddDays(3),
                            EndDate = DateTime.Now.AddDays(20),
                            Publishing_HouseId = 1,
                            BookCategory = BookCategory.Thriller
                        }
                    });
                    context.SaveChanges();
                }
                //Actors & Movies
                if (!context.Author_Book.Any())
                {
                    context.Author_Book.AddRange(new List<Author_Book>()
                    {
                        new Author_Book()
                        {
                            BookId = 2,
                            AuthorID = 1
                           
                        },
                    });
                    context.SaveChanges();
                }
            }
        }

        //public async Task SeedUserAndRolesAsync (IApplicationBuilder applicationBuilder)
        //{
        //    using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
        //    {
        //        //Roles
        //        var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        //        if (!await roleManager.RoleExistsAsync(UserRole.Admin))
        //            await roleManager.CreateAsync(new IdentityRole(UserRole.Admin)); 
        //        if (!await roleManager.RoleExistsAsync(UserRole.User))
        //            await roleManager.CreateAsync(new IdentityRole(UserRole.User));
        //        //Users
        //        var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
        //        string adminUserEmail = "admin@etickets.com";

        //        var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
        //        if (adminUser == null)
        //        {
        //            var newAdminUser = new ApplicationUser()
        //            {
        //                FullNAme = "Admin User",
        //                UserName = "admin-user",
        //                Email = adminUserEmail,
        //                EmailConfirmed = true
        //            };
        //            await userManager.CreateAsync(newAdminUser, "Coding@1234?");
        //            await userManager.AddToRoleAsync(newAdminUser, UserRole.Admin);
        //        }

        //        string appUserEmail = "user@etickets.com";

        //        var appUser = await userManager.FindByEmailAsync(appUserEmail);
        //        if (appUser == null)
        //        {
        //            var newAppUser = new ApplicationUser()
        //            {
        //                FullNAme = "Application User",
        //                UserName = "app-user",
        //                Email = adminUserEmail,
        //                EmailConfirmed = true
        //            };
        //            await userManager.CreateAsync(newAppUser, "Coding@1234?");
        //            await userManager.AddToRoleAsync(newAppUser, UserRole.User);
        //        }

        //    }
        //}
    }
}

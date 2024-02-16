using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

using Pizza_Core.Models;
using System.Reflection.Metadata;

namespace Pizza_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Pizza> Pizzas { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<PizzaIngredient> PizzaIngredients { get; set; }

        #region DataSeeding
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pizza>()
                        .HasMany(e => e.Ingredients)
                        .WithMany(e => e.Pizzas)
                        .UsingEntity<PizzaIngredient>();
            modelBuilder.Entity<Pizza>()
                    .Property(b => b.Price)
                    .HasPrecision(37, 2);

            #region ingredient
            var ingredientsList = new List<Ingredient>
                {
                    new Ingredient { Id = 1, Name = "Sauce tomate", Description = "Sauce de base."},
                    new Ingredient { Id = 2, Name = "Mozzarella", Description = "Fromage italien." },
                    new Ingredient { Id = 3, Name = "Basilic", Description = "Herbe aromatique." },
                    new Ingredient { Id = 4, Name = "Pepperoni", Description = "Salami épicé." },
                    new Ingredient { Id = 5, Name = "Chèvre", Description = "Fromage de chèvre." },
                    new Ingredient { Id = 6, Name = "Bleu", Description = "Fromage persillé." },
                    new Ingredient { Id = 7, Name = "Emmental", Description = "Fromage suisse." },
                    new Ingredient { Id = 8, Name = "Jambon", Description = "Viande de porc." },
                    new Ingredient { Id = 9, Name = "Ananas", Description = "Fruit tropical." },
                    new Ingredient { Id = 10, Name = "Poivrons", Description = "Légume coloré." },
                    new Ingredient { Id = 11, Name = "Oignons", Description = "Légume aromatique." },
                    new Ingredient { Id = 12, Name = "Champignons", Description = "Fongus comestible." },
                    new Ingredient { Id = 13, Name = "Olives", Description = "Fruit méditerranéen." }
                };
            #endregion

            #region pizza
            var pizzaList = new List<Pizza>()
                {

                   new Pizza
                   {
                       Id = 1,
                       Name = "Margherita",
                       Description = "Simple et classique avec de la sauce tomate, du fromage mozzarella et du basilic frais.",
                       Price = 8.99M,
                       IsSpicy = false,
                       IsVege = true,
                       ImagePath = "images/margherita.jpg",
                       //PizzaIngredients = new List<PizzaIngredient>() {
                       //    new PizzaIngredient(){Id = 1, PizzaId = 1, IngredientId = },
                       //    new PizzaIngredient(){Id = 2, PizzaId = 1, IngredientId = },
                       //    new PizzaIngredient(){Id = 3, PizzaId = 1, IngredientId = },
                       //    new PizzaIngredient(){Id = 4, PizzaId = 1, IngredientId = },
                       //}

                   },

                    new Pizza
                    {
                        Id = 2,
                        Name = "Pepperoni",
                        Description = "Garnie de tranches de pepperoni épicées sur une base de sauce tomate et mozzarella.",
                        Price = 10.99M,
                        IsSpicy = true,
                        IsVege = false,
                        ImagePath = "images/pepperoni.jpg",

                    },

                    new Pizza
                    {
                        Id = 3,
                        Name = "bacon",
                        Description = "Garnie de tranches de pepperoni épicées sur une base de sauce tomate et mozzarella.",
                        Price = 10.99M,
                        IsSpicy = true,
                        IsVege = false,
                        ImagePath = "images/pepperoni.jpg",

                    },
                    new Pizza
                    {
                        Id = 4,
                        Name = "cheese",
                        Description = "Garnie de fromage mozzarella fondant sur une base de sauce tomate.",
                        Price = 8.99M,
                        IsSpicy = false,
                        IsVege = true,
                        ImagePath = "images/cheese.jpg"
                    },

                    new Pizza
                    {
                        Id = 5,
                        Name = "bacon",
                        Description = "Garnie de tranches de bacon croustillantes sur une base de sauce tomate et mozzarella.",
                        Price = 10.99M,
                        IsSpicy = false,
                        IsVege = false,
                        ImagePath = "images/bacon.jpg"
                    },

                    new Pizza
                    {
                        Id = 6,
                        Name = "meaty",
                        Description = "Une pizza copieuse garnie de pepperoni, de bacon, de saucisse italienne et de jambon sur une base de sauce tomate et mozzarella.",
                        Price = 12.99M,
                        IsSpicy = false,
                        IsVege = false,
                        ImagePath = "images/meaty.jpg"
                    },

                    new Pizza
                    {
                        Id = 7,
                        Name = "mushroom",
                        Description = "Garnie de champignons frais sur une base de sauce tomate et mozzarella.",
                        Price = 9.99M,
                        IsSpicy = false,
                        IsVege = true,
                        ImagePath = "images/mushroom.jpg"
                    },

                    new Pizza
                    {
                        Id = 8,
                        Name = "veggie",
                        Description = "Une pizza végétarienne généreusement garnie de légumes frais sur une base de sauce tomate et mozzarella.",
                        Price = 10.49M,
                        IsSpicy = false,
                        IsVege = true,
                        ImagePath = "images/veggie.jpg"
                    }

                                    };
            #endregion

            #region PizzaIngredient
            var pizzaIngredientList = new List<PizzaIngredient>()
            {
                // Pizza "cheese" : Sauce tomate et Mozzarella
                new PizzaIngredient(){ Id = 1, PizzaId = 1, IngredientId = 1},
                new PizzaIngredient(){Id = 2,PizzaId = 1,IngredientId = 2 },
                new PizzaIngredient{Id = 3,PizzaId = 2,IngredientId = 3,},
                // Pizza "cheese" : Sauce tomate et Mozzarella
                new PizzaIngredient(){ Id = 4, PizzaId = 4, IngredientId = 1}, // Sauce tomate
                new PizzaIngredient(){ Id = 5, PizzaId = 4, IngredientId = 2}, // Mozzarella

                // Pizza "bacon" : Sauce tomate, Mozzarella et Pepperoni
                new PizzaIngredient(){ Id = 6, PizzaId = 5, IngredientId = 1}, // Sauce tomate
                new PizzaIngredient(){ Id = 7, PizzaId = 5, IngredientId = 2}, // Mozzarella
                new PizzaIngredient(){ Id = 8, PizzaId = 5, IngredientId = 4}, // Pepperoni

                // Pizza "meaty" : Sauce tomate, Mozzarella et Jambon
                new PizzaIngredient(){ Id = 9, PizzaId = 6, IngredientId = 1}, // Sauce tomate
                new PizzaIngredient(){ Id = 10, PizzaId = 6, IngredientId = 2}, // Mozzarella
                new PizzaIngredient(){ Id = 11, PizzaId = 6, IngredientId = 8}, // Jambon

                // Pizza "mushroom" : Sauce tomate et Champignons
                new PizzaIngredient(){ Id = 12, PizzaId = 7, IngredientId = 1}, // Sauce tomate
                new PizzaIngredient(){ Id = 13, PizzaId = 7, IngredientId = 12}, // Champignons

                // Pizza "veggie" : Sauce tomate et Poivrons
                new PizzaIngredient(){ Id = 14, PizzaId = 8, IngredientId = 1}, // Sauce tomate
                new PizzaIngredient(){ Id = 15, PizzaId = 8, IngredientId = 10} // Poivrons

            };

            #endregion

            #region Users
            var userList = new List<User>()
                {
                                new User
                                {
                                    Id = 1,
                                    FirstName = "Jean",
                                    LastName = "Bon",
                                    Email = "jeanbon@beurre.com",
                                    Password = "PAssword00++",
                                    PhoneNumber = "01 02 03 04 05",
                                    Address = "32 rue des potirons"
                                },
                                new User
                                {
                                    Id = 2,
                                    FirstName = "Marie",
                                    LastName = "Curie",
                                    Email = "mariecurie@radium.com",
                                    Password = "SeCur3P@ss!",
                                    PhoneNumber = "02 03 04 05 06",
                                    Address = "54 rue de la Physique"
                                },

                                new User
                                {
                                    Id = 3,
                                    FirstName = "Luc",
                                    LastName = "Skywalker",
                                    Email = "lucskywalker@force.com",
                                    Password = "Jed1Kn1ght!",
                                    PhoneNumber = "03 04 05 06 07",
                                    Address = "77 rue des Étoiles"
                                },

                                new User
                                {
                                    Id = 4,
                                    FirstName = "Alice",
                                    LastName = "Wonder",
                                    Email = "alicewonder@wonderland.com",
                                    Password = "W0nd3rL@nd!",
                                    PhoneNumber = "04 05 06 07 08",
                                    Address = "88 chemin du Lapin Blanc"
                                },
                };
            #endregion

            modelBuilder.Entity<Pizza>().HasData(pizzaList);
            modelBuilder.Entity<Ingredient>().HasData(ingredientsList);
            modelBuilder.Entity<User>().HasData(userList);
            modelBuilder.Entity<PizzaIngredient>().HasData(pizzaIngredientList);



        }
        #endregion
    }
}


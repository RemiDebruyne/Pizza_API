using Pizza_View.Models;

public static class InitialPizza
    {
// partie avec les pizzas au complet, avec leurs ingrédients inclus
// utile si on veut faire une FakeDb
        public static readonly List<Pizza> completePizzas = new List<Pizza>()
        {
            new Pizza{ Id =1, Name ="Bacon", Price = 12, Ingredients = new List<Ingredient>(){
                new () {Id = 1, PizzaId = 1, Name = "bacon" },
                new () {Id = 2, PizzaId = 1, Name = "mozzarella"},
                new () {Id = 3, PizzaId = 1, Name = "champignon"},
                new () {Id = 4, PizzaId = 1, Name = "emmental" },
            }, ImagePath = "/images/bacon.jpg"  },
            new Pizza{ Id =2, Name ="4 fromages", Price= 11, Ingredients = new List<Ingredient>(){
                new () {Id = 5, PizzaId = 2, Name = "cantal"},
                new () {Id = 6, PizzaId = 2, Name = "mozzarella"},
                new () {Id = 7, PizzaId = 2, Name = "fromage de chèvre" },
                new () {Id = 8, PizzaId = 2, Name = "gruyère" },
            }, ImagePath = "/images/cheese.jpg"  },
            new Pizza{ Id =3, Name ="Margherita", Price = 10, Ingredients = new List<Ingredient>(){
                new () {Id = 9, PizzaId = 3, Name = "sauce tomate" },
                new () {Id = 10, PizzaId = 3, Name = "mozzarella"},
                new () {Id = 11, PizzaId = 3, Name = "basilic" },
            }, ImagePath = "/images/margherita.jpg"  },
            new Pizza{ Id =4, Name ="Mexicaine", Price=12, Ingredients = new List<Ingredient>(){
                new () {Id = 12, PizzaId = 4, Name = "boeuf"},
                new () {Id = 13, PizzaId = 4, Name = "mozzarella"},
                new () {Id = 14, PizzaId = 4, Name = "maïs"},
                new () {Id = 15, PizzaId = 4, Name = "tomates"},
                new () {Id = 16, PizzaId = 4, Name = "oignon"},
                new () {Id = 17, PizzaId = 4, Name = "coriandre" },
            }, ImagePath = "/images/meaty.jpg"  },
            new Pizza{ Id =5, Name ="Reine", Price=11, Ingredients = new List<Ingredient>(){
                new () {Id = 18, PizzaId = 5, Name = "jambon"},
                new () {Id = 19, PizzaId = 5, Name = "champignons"},
                new () {Id = 20, PizzaId = 5, Name = "mozzarella" },
            }, ImagePath = "/images/mushroom.jpg"  },
            new Pizza{ Id =6, Name ="Pepperoni", Price=11, Ingredients = new List<Ingredient>(){
                new () {Id = 21, PizzaId = 6, Name = "mozzarella"},
                new () {Id = 22, PizzaId = 6, Name = "pepperoni"},
                new () {Id = 23, PizzaId = 6, Name = "tomates" },
            }, ImagePath = "/images/pepperoni.jpg"  },
            new Pizza{ Id =7, Name ="Végétarienne",Price = 10, Ingredients = new List<Ingredient>(){
                new () {Id = 24, PizzaId = 7, Name = "champignons"},
                new () {Id = 25, PizzaId = 7, Name = "roquette"},
                new () {Id = 26, PizzaId = 7, Name = "artichauts"},
                new () {Id = 27, PizzaId = 7, Name = "aubergine" }
            }, ImagePath = "/images/veggie.jpg"  },
        };


// partie avec les pizzas et les ingrédients séparément
// utile pour faire un dataseed avec EFCore
        public static readonly List<Pizza> pizzas = new List<Pizza>()
        {
            new Pizza{ Id =1, Name ="Bacon", Price = 12, ImagePath = "/images/bacon.jpg"  },
            new Pizza{ Id =2, Name ="4 fromages", Price= 11, ImagePath = "/images/cheese.jpg"  },
            new Pizza{ Id =3, Name ="Margherita", Price = 10, ImagePath = "/images/margherita.jpg"  },
            new Pizza{ Id =4, Name ="Mexicaine", Price=12,  ImagePath = "/images/meaty.jpg"  },
            new Pizza{ Id =5, Name ="Reine", Price=11, ImagePath = "/images/mushroom.jpg"  },
            new Pizza{ Id =6, Name ="Pepperoni", Price=11, ImagePath = "/images/pepperoni.jpg"  },
            new Pizza{ Id =7, Name ="Végétarienne",Price = 10, ImagePath = "/images/veggie.jpg"  },
        };
        public static readonly List<Ingredient> ingredients = new List<Ingredient>()
        {
            new () {Id = 1, PizzaId = 1, Name = "bacon" },
            new () {Id = 2, PizzaId = 1, Name = "mozzarella"},
            new () {Id = 3, PizzaId = 1, Name = "champignon"},
            new () {Id = 4, PizzaId = 1, Name = "emmental" },
            new () {Id = 5, PizzaId = 2, Name = "cantal"},
            new () {Id = 6, PizzaId = 2, Name = "mozzarella"},
            new () {Id = 7, PizzaId = 2, Name = "fromage de chèvre" },
            new () {Id = 8, PizzaId = 2, Name = "gruyère" },
            new () {Id = 9, PizzaId = 3, Name = "sauce tomate" },
            new () {Id = 10, PizzaId = 3, Name = "mozzarella"},
            new () {Id = 11, PizzaId = 3, Name = "basilic" },
            new () {Id = 12, PizzaId = 4, Name = "boeuf"},
            new () {Id = 13, PizzaId = 4, Name = "mozzarella"},
            new () {Id = 14, PizzaId = 4, Name = "maïs"},
            new () {Id = 15, PizzaId = 4, Name = "tomates"},
            new () {Id = 16, PizzaId = 4, Name = "oignon"},
            new () {Id = 17, PizzaId = 4, Name = "coriandre" },
            new () {Id = 18, PizzaId = 5, Name = "jambon"},
            new () {Id = 19, PizzaId = 5, Name = "champignons"},
            new () {Id = 20, PizzaId = 5, Name = "mozzarella" },
            new () {Id = 21, PizzaId = 6, Name = "mozzarella"},
            new () {Id = 22, PizzaId = 6, Name = "pepperoni"},
            new () {Id = 23, PizzaId = 6, Name = "tomates" },
            new () {Id = 24, PizzaId = 7, Name = "champignons"},
            new () {Id = 25, PizzaId = 7, Name = "roquette"},
            new () {Id = 26, PizzaId = 7, Name = "artichauts"},
            new () {Id = 27, PizzaId = 7, Name = "aubergine" }
        };
    }



// A mettre dans le ApplicationDbContext pour utiliser le data seed
    //protected override void OnModelCreating(ModelBuilder modelBuilder)
    //    {
    //        modelBuilder.Entity<Pizza>().HasData(InitialPizza.pizzas);
    //        modelBuilder.Entity<Ingredient>().HasData(InitialPizza.ingredients);
    //    }
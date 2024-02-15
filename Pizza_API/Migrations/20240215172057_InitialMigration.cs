using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pizza_API.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ingredients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "pizzas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(37,2)", precision: 37, scale: 2, nullable: false),
                    IsSpicy = table.Column<bool>(type: "bit", nullable: true),
                    IsVege = table.Column<bool>(type: "bit", nullable: true),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pizzas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone_number = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    administrator_status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PizzaIngredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PizzaId = table.Column<int>(type: "int", nullable: false),
                    IngredientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PizzaIngredients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PizzaIngredients_ingredients_IngredientId",
                        column: x => x.IngredientId,
                        principalTable: "ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PizzaIngredients_pizzas_PizzaId",
                        column: x => x.PizzaId,
                        principalTable: "pizzas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ingredients",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Sauce de base.", "Sauce tomate" },
                    { 2, "Fromage italien.", "Mozzarella" },
                    { 3, "Herbe aromatique.", "Basilic" },
                    { 4, "Salami épicé.", "Pepperoni" },
                    { 5, "Fromage de chèvre.", "Chèvre" },
                    { 6, "Fromage persillé.", "Bleu" },
                    { 7, "Fromage suisse.", "Emmental" },
                    { 8, "Viande de porc.", "Jambon" },
                    { 9, "Fruit tropical.", "Ananas" },
                    { 10, "Légume coloré.", "Poivrons" },
                    { 11, "Légume aromatique.", "Oignons" },
                    { 12, "Fongus comestible.", "Champignons" },
                    { 13, "Fruit méditerranéen.", "Olives" }
                });

            migrationBuilder.InsertData(
                table: "pizzas",
                columns: new[] { "Id", "Description", "ImagePath", "IsSpicy", "IsVege", "Name", "Price" },
                values: new object[,]
                {
                    { 1, "Simple et classique avec de la sauce tomate, du fromage mozzarella et du basilic frais.", "images/margherita.jpg", false, true, "Margherita", 8.99m },
                    { 2, "Garnie de tranches de pepperoni épicées sur une base de sauce tomate et mozzarella.", "images/pepperoni.jpg", true, false, "Pepperoni", 10.99m }
                });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "Address", "Email", "FirstName", "administrator_status", "LastName", "Password", "phone_number" },
                values: new object[,]
                {
                    { 1, "32 rue des potirons", "jeanbon@beurre.com", "Jean", false, "Bon", "PAssword00++", "01 02 03 04 05" },
                    { 2, "54 rue de la Physique", "mariecurie@radium.com", "Marie", false, "Curie", "SeCur3P@ss!", "02 03 04 05 06" },
                    { 3, "77 rue des Étoiles", "lucskywalker@force.com", "Luc", false, "Skywalker", "Jed1Kn1ght!", "03 04 05 06 07" },
                    { 4, "88 chemin du Lapin Blanc", "alicewonder@wonderland.com", "Alice", false, "Wonder", "W0nd3rL@nd!", "04 05 06 07 08" }
                });

            migrationBuilder.InsertData(
                table: "PizzaIngredients",
                columns: new[] { "Id", "IngredientId", "PizzaId" },
                values: new object[] { 1, 1, 1 });

            migrationBuilder.InsertData(
                table: "PizzaIngredients",
                columns: new[] { "Id", "IngredientId", "PizzaId" },
                values: new object[] { 2, 2, 1 });

            migrationBuilder.InsertData(
                table: "PizzaIngredients",
                columns: new[] { "Id", "IngredientId", "PizzaId" },
                values: new object[] { 3, 3, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_PizzaIngredients_IngredientId",
                table: "PizzaIngredients",
                column: "IngredientId");

            migrationBuilder.CreateIndex(
                name: "IX_PizzaIngredients_PizzaId",
                table: "PizzaIngredients",
                column: "PizzaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PizzaIngredients");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "ingredients");

            migrationBuilder.DropTable(
                name: "pizzas");
        }
    }
}

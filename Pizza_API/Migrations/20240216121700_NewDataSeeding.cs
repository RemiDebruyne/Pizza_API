using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pizza_API.Migrations
{
    public partial class NewDataSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "pizzas",
                columns: new[] { "Id", "Description", "ImagePath", "IsSpicy", "IsVege", "Name", "Price" },
                values: new object[,]
                {
                    { 3, "Garnie de tranches de pepperoni épicées sur une base de sauce tomate et mozzarella.", "images/pepperoni.jpg", true, false, "bacon", 10.99m },
                    { 4, "Garnie de fromage mozzarella fondant sur une base de sauce tomate.", "images/cheese.jpg", false, true, "cheese", 8.99m },
                    { 5, "Garnie de tranches de bacon croustillantes sur une base de sauce tomate et mozzarella.", "images/bacon.jpg", false, false, "bacon", 10.99m },
                    { 6, "Une pizza copieuse garnie de pepperoni, de bacon, de saucisse italienne et de jambon sur une base de sauce tomate et mozzarella.", "images/meaty.jpg", false, false, "meaty", 12.99m },
                    { 7, "Garnie de champignons frais sur une base de sauce tomate et mozzarella.", "images/mushroom.jpg", false, true, "mushroom", 9.99m },
                    { 8, "Une pizza végétarienne généreusement garnie de légumes frais sur une base de sauce tomate et mozzarella.", "images/veggie.jpg", false, true, "veggie", 10.49m }
                });

            migrationBuilder.InsertData(
                table: "PizzaIngredients",
                columns: new[] { "Id", "IngredientId", "PizzaId" },
                values: new object[,]
                {
                    { 4, 1, 4 },
                    { 5, 2, 4 },
                    { 6, 1, 5 },
                    { 7, 2, 5 },
                    { 8, 4, 5 },
                    { 9, 1, 6 },
                    { 10, 2, 6 },
                    { 11, 8, 6 },
                    { 12, 1, 7 },
                    { 13, 12, 7 },
                    { 14, 1, 8 },
                    { 15, 10, 8 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PizzaIngredients",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PizzaIngredients",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PizzaIngredients",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "PizzaIngredients",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "PizzaIngredients",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "PizzaIngredients",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "PizzaIngredients",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "PizzaIngredients",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "PizzaIngredients",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "PizzaIngredients",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "PizzaIngredients",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "PizzaIngredients",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "pizzas",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "pizzas",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "pizzas",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "pizzas",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "pizzas",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "pizzas",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace DatabaseAccess.Migrations
{
    public partial class ClientTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Projects",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ClientId",
                table: "Projects",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Projects_Client_ClientId",
                table: "Projects",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.InsertData("Client", "Name", "Igor");
            migrationBuilder.InsertData("Client", "Name", "Vlad");
            migrationBuilder.InsertData("Client", "Name", "Tom");
            migrationBuilder.InsertData("Client", "Name", "Max");
            migrationBuilder.InsertData("Client", "Name", "Harry");

            migrationBuilder.InsertData("Projects", new string[] { "Name", "Budget", "StartedDate", "ClientId" }, new string[] { "SeriesX", "40000000", "2021-12-12", "1" });
            migrationBuilder.InsertData("Projects", new string[] { "Name", "Budget", "StartedDate", "ClientId" }, new string[] { "IPhone 11", "95000000", "2021-11-22", "2" });
            migrationBuilder.InsertData("Projects", new string[] { "Name", "Budget", "StartedDate", "ClientId" }, new string[] { "MarketPlus", "5100000", "2020-05-03", "3" });
            migrationBuilder.InsertData("Projects", new string[] { "Name", "Budget", "StartedDate", "ClientId" }, new string[] { "Android 10", "100000000", "2021-01-12", "4" });
            migrationBuilder.InsertData("Projects", new string[] { "Name", "Budget", "StartedDate", "ClientId" }, new string[] { "AmazingTools", "66000000", "2021-10-11", "5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Projects_Client_ClientId",
                table: "Projects");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropIndex(
                name: "IX_Projects_ClientId",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Projects");
        }
    }
}

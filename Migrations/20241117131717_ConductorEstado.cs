using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend_CruzRoja.Migrations
{
    /// <inheritdoc />
    public partial class ConductorEstado : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EstadoConductoresId",
                table: "Conductores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "EstadoConductores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoConductores", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Conductores_EstadoConductoresId",
                table: "Conductores",
                column: "EstadoConductoresId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Conductores_EstadoConductores_EstadoConductoresId",
            //    table: "Conductores",
            //    column: "EstadoConductoresId",
            //    principalTable: "EstadoConductores",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_Conductores_EstadoConductores_EstadoConductoresId",
            //    table: "Conductores");

            migrationBuilder.DropTable(
                name: "EstadoConductores");

            migrationBuilder.DropIndex(
                name: "IX_Conductores_EstadoConductoresId",
                table: "Conductores");

            migrationBuilder.DropColumn(
                name: "EstadoConductoresId",
                table: "Conductores");
        }
    }
}

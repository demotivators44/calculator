using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Weather.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DeleteSummary2Column : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Summary2",
                table: "WeatherForecasts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Summary2",
                table: "WeatherForecasts",
                type: "character varying(64)",
                maxLength: 64,
                nullable: true);
        }
    }
}

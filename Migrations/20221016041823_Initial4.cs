using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelApp.Migrations
{
    public partial class Initial4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feature_RoomType_RoomTypeID",
                table: "Feature");

            migrationBuilder.DropIndex(
                name: "IX_Feature_RoomTypeID",
                table: "Feature");

            migrationBuilder.DropColumn(
                name: "RoomTypeID",
                table: "Feature");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoomTypeID",
                table: "Feature",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Feature_RoomTypeID",
                table: "Feature",
                column: "RoomTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Feature_RoomType_RoomTypeID",
                table: "Feature",
                column: "RoomTypeID",
                principalTable: "RoomType",
                principalColumn: "RoomTypeID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

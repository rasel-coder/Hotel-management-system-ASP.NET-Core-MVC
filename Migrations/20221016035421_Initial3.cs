using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelApp.Migrations
{
    public partial class Initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FeatureName",
                table: "RoomType",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FeatureName",
                table: "Feature",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feature_RoomType_RoomTypeID",
                table: "Feature");

            migrationBuilder.DropIndex(
                name: "IX_Feature_RoomTypeID",
                table: "Feature");

            migrationBuilder.DropColumn(
                name: "FeatureName",
                table: "RoomType");

            migrationBuilder.DropColumn(
                name: "RoomTypeID",
                table: "Feature");

            migrationBuilder.AlterColumn<string>(
                name: "FeatureName",
                table: "Feature",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }
    }
}

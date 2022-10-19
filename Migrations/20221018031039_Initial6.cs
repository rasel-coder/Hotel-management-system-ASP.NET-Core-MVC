using Microsoft.EntityFrameworkCore.Migrations;

namespace HotelApp.Migrations
{
    public partial class Initial6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomType_Feature_FeatureID",
                table: "RoomType");

            migrationBuilder.AlterColumn<int>(
                name: "FeatureID",
                table: "RoomType",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Room",
                columns: table => new
                {
                    RoomID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomNumber = table.Column<int>(type: "int", nullable: false),
                    RoomTypeID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomTypeID1 = table.Column<int>(type: "int", nullable: true),
                    Available = table.Column<bool>(type: "bit", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Room", x => x.RoomID);
                    table.ForeignKey(
                        name: "FK_Room_RoomType_RoomTypeID1",
                        column: x => x.RoomTypeID1,
                        principalTable: "RoomType",
                        principalColumn: "RoomTypeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RoomImages",
                columns: table => new
                {
                    ImageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomID = table.Column<int>(type: "int", nullable: false),
                    RoomImage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomImages", x => x.ImageID);
                    table.ForeignKey(
                        name: "FK_RoomImages_Room_RoomID",
                        column: x => x.RoomID,
                        principalTable: "Room",
                        principalColumn: "RoomID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Room_RoomTypeID1",
                table: "Room",
                column: "RoomTypeID1");

            migrationBuilder.CreateIndex(
                name: "IX_RoomImages_RoomID",
                table: "RoomImages",
                column: "RoomID");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomType_Feature_FeatureID",
                table: "RoomType",
                column: "FeatureID",
                principalTable: "Feature",
                principalColumn: "FeatureID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RoomType_Feature_FeatureID",
                table: "RoomType");

            migrationBuilder.DropTable(
                name: "RoomImages");

            migrationBuilder.DropTable(
                name: "Room");

            migrationBuilder.AlterColumn<int>(
                name: "FeatureID",
                table: "RoomType",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_RoomType_Feature_FeatureID",
                table: "RoomType",
                column: "FeatureID",
                principalTable: "Feature",
                principalColumn: "FeatureID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccess.Migrations
{
    public partial class AddedGame : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPosition_Position_PositionId",
                table: "UserPosition");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPosition_Users_UserId",
                table: "UserPosition");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserPosition",
                table: "UserPosition");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Position",
                table: "Position");

            migrationBuilder.RenameTable(
                name: "UserPosition",
                newName: "UserPositions");

            migrationBuilder.RenameTable(
                name: "Position",
                newName: "Positions");

            migrationBuilder.RenameIndex(
                name: "IX_UserPosition_PositionId",
                table: "UserPositions",
                newName: "IX_UserPositions_PositionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserPositions",
                table: "UserPositions",
                columns: new[] { "UserId", "PositionId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Positions",
                table: "Positions",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Result = table.Column<int>(type: "int", nullable: false),
                    PlayedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Games_UserId",
                table: "Games",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPositions_Positions_PositionId",
                table: "UserPositions",
                column: "PositionId",
                principalTable: "Positions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPositions_Users_UserId",
                table: "UserPositions",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPositions_Positions_PositionId",
                table: "UserPositions");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPositions_Users_UserId",
                table: "UserPositions");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserPositions",
                table: "UserPositions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Positions",
                table: "Positions");

            migrationBuilder.RenameTable(
                name: "UserPositions",
                newName: "UserPosition");

            migrationBuilder.RenameTable(
                name: "Positions",
                newName: "Position");

            migrationBuilder.RenameIndex(
                name: "IX_UserPositions_PositionId",
                table: "UserPosition",
                newName: "IX_UserPosition_PositionId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserPosition",
                table: "UserPosition",
                columns: new[] { "UserId", "PositionId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Position",
                table: "Position",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserPosition_Position_PositionId",
                table: "UserPosition",
                column: "PositionId",
                principalTable: "Position",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPosition_Users_UserId",
                table: "UserPosition",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

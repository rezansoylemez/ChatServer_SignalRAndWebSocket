using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChatServer.Migrations
{
    /// <inheritdoc />
    public partial class ChatLobbyAndChatLobbyAndUserTablesAreAddedAndSomeTablesAreUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ChatLobbyId",
                table: "Messages",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ChatLobby",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatLobby", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ChatLobbyAndUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ChatLobbyId = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatLobbyAndUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChatLobbyAndUser_ChatLobby_ChatLobbyId",
                        column: x => x.ChatLobbyId,
                        principalTable: "ChatLobby",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChatLobbyAndUser_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ChatLobbyId",
                table: "Messages",
                column: "ChatLobbyId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatLobbyAndUser_ChatLobbyId",
                table: "ChatLobbyAndUser",
                column: "ChatLobbyId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatLobbyAndUser_UserId",
                table: "ChatLobbyAndUser",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Messages_ChatLobby_ChatLobbyId",
                table: "Messages",
                column: "ChatLobbyId",
                principalTable: "ChatLobby",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Messages_ChatLobby_ChatLobbyId",
                table: "Messages");

            migrationBuilder.DropTable(
                name: "ChatLobbyAndUser");

            migrationBuilder.DropTable(
                name: "ChatLobby");

            migrationBuilder.DropIndex(
                name: "IX_Messages_ChatLobbyId",
                table: "Messages");

            migrationBuilder.DropColumn(
                name: "ChatLobbyId",
                table: "Messages");
        }
    }
}

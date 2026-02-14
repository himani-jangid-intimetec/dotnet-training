using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportsManagementApp.Migrations
{
    /// <inheritdoc />
    public partial class AddedMatchSets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventRequests_Users_ApprovedById",
                table: "EventRequests");

            migrationBuilder.DropColumn(
                name: "WinnerType",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "ScoreA",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "ScoreB",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "SideAType",
                table: "Matches");

            migrationBuilder.RenameColumn(
                name: "SideBType",
                table: "Matches",
                newName: "TotalSets");

            migrationBuilder.RenameColumn(
                name: "ApprovedById",
                table: "EventRequests",
                newName: "OperationsReviewerId");

            migrationBuilder.RenameIndex(
                name: "IX_EventRequests_ApprovedById",
                table: "EventRequests",
                newName: "IX_EventRequests_OperationsReviewerId");

            migrationBuilder.AddColumn<int>(
                name: "TournamentType",
                table: "EventCategories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MatchSets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatchId = table.Column<int>(type: "int", nullable: false),
                    SetNumber = table.Column<int>(type: "int", nullable: false),
                    ScoreA = table.Column<int>(type: "int", nullable: false),
                    ScoreB = table.Column<int>(type: "int", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchSets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchSets_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MatchSets_MatchId",
                table: "MatchSets",
                column: "MatchId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventRequests_Users_OperationsReviewerId",
                table: "EventRequests",
                column: "OperationsReviewerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventRequests_Users_OperationsReviewerId",
                table: "EventRequests");

            migrationBuilder.DropTable(
                name: "MatchSets");

            migrationBuilder.DropColumn(
                name: "TournamentType",
                table: "EventCategories");

            migrationBuilder.RenameColumn(
                name: "TotalSets",
                table: "Matches",
                newName: "SideBType");

            migrationBuilder.RenameColumn(
                name: "OperationsReviewerId",
                table: "EventRequests",
                newName: "ApprovedById");

            migrationBuilder.RenameIndex(
                name: "IX_EventRequests_OperationsReviewerId",
                table: "EventRequests",
                newName: "IX_EventRequests_ApprovedById");

            migrationBuilder.AddColumn<int>(
                name: "WinnerType",
                table: "Results",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ScoreA",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ScoreB",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SideAType",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_EventRequests_Users_ApprovedById",
                table: "EventRequests",
                column: "ApprovedById",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

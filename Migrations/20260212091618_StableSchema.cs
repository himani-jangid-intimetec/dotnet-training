using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportsManagementApp.Migrations
{
    /// <inheritdoc />
    public partial class StableSchema : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ScoreA",
                table: "Results");

            migrationBuilder.DropColumn(
                name: "ScoreB",
                table: "Results");

            migrationBuilder.RenameColumn(
                name: "Sport",
                table: "Events",
                newName: "SportId");

            migrationBuilder.RenameColumn(
                name: "RegistrationDate",
                table: "Events",
                newName: "RegistrationDeadline");

            migrationBuilder.AlterColumn<int>(
                name: "SideBId",
                table: "Matches",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SideAId",
                table: "Matches",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "BracketPosition",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RoundNumber",
                table: "Matches",
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
                name: "TotalRounds",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SportId",
                table: "EventRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Sports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sports", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_SportId",
                table: "Events",
                column: "SportId");

            migrationBuilder.CreateIndex(
                name: "IX_EventRequests_SportId",
                table: "EventRequests",
                column: "SportId");

            migrationBuilder.AddForeignKey(
                name: "FK_EventRequests_Sports_SportId",
                table: "EventRequests",
                column: "SportId",
                principalTable: "Sports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Sports_SportId",
                table: "Events",
                column: "SportId",
                principalTable: "Sports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EventRequests_Sports_SportId",
                table: "EventRequests");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Sports_SportId",
                table: "Events");

            migrationBuilder.DropTable(
                name: "Sports");

            migrationBuilder.DropIndex(
                name: "IX_Events_SportId",
                table: "Events");

            migrationBuilder.DropIndex(
                name: "IX_EventRequests_SportId",
                table: "EventRequests");

            migrationBuilder.DropColumn(
                name: "BracketPosition",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "RoundNumber",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "ScoreA",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "ScoreB",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "TotalRounds",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "SportId",
                table: "EventRequests");

            migrationBuilder.RenameColumn(
                name: "SportId",
                table: "Events",
                newName: "Sport");

            migrationBuilder.RenameColumn(
                name: "RegistrationDeadline",
                table: "Events",
                newName: "RegistrationDate");

            migrationBuilder.AddColumn<int>(
                name: "ScoreA",
                table: "Results",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ScoreB",
                table: "Results",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "SideBId",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "SideAId",
                table: "Matches",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}

using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FinalProject.Migrations
{
    public partial class DBForMoel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bot",
                columns: table => new
                {
                    BotID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LevelID = table.Column<int>(nullable: false),
                    Recording = table.Column<string>(nullable: true),
                    time = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bot", x => x.BotID);
                });

            migrationBuilder.CreateTable(
                name: "HighScore",
                columns: table => new
                {
                    HighScore_ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserID = table.Column<int>(nullable: false),
                    LevelID = table.Column<int>(nullable: false),
                    time = table.Column<int>(nullable: false),
                    recording = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HighScore", x => x.HighScore_ID);
                });

            migrationBuilder.CreateTable(
                name: "Level",
                columns: table => new
                {
                    LevelID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BackGroundImage = table.Column<string>(nullable: true),
                    LevelObsticles = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Level", x => x.LevelID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    CurrentLevel = table.Column<int>(nullable: false),
                    NosContainers = table.Column<int>(nullable: false),
                    Cash = table.Column<int>(nullable: false),
                    Nos = table.Column<bool>(nullable: false),
                    SkinRed = table.Column<bool>(nullable: false),
                    SkinBlue = table.Column<bool>(nullable: false),
                    SkinGreen = table.Column<bool>(nullable: false),
                    SkinPurple = table.Column<bool>(nullable: false),
                    SkinChrome = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bot");

            migrationBuilder.DropTable(
                name: "HighScore");

            migrationBuilder.DropTable(
                name: "Level");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}

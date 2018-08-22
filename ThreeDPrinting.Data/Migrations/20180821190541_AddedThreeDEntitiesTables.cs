namespace ThreeDPrinting.Web.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Metadata;
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class AddedThreeDEntitiesTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ThreeDFilaments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Make = table.Column<string>(maxLength: 100, nullable: false),
                    Color = table.Column<string>(maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    ImageUrl = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThreeDFilaments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThreeDFilaments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ThreeDPrinters",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Make = table.Column<string>(maxLength: 100, nullable: false),
                    Model = table.Column<string>(maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    BuildVolume = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 6000, nullable: false),
                    ImageUrl = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThreeDPrinters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThreeDPrinters_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ThreeDScanners",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Make = table.Column<string>(maxLength: 100, nullable: false),
                    Model = table.Column<string>(maxLength: 100, nullable: false),
                    Price = table.Column<decimal>(nullable: false),
                    WorkingRange = table.Column<string>(maxLength: 50, nullable: false),
                    DepthImageSize = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 6000, nullable: false),
                    ImageUrl = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ThreeDScanners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ThreeDScanners_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ThreeDFilaments_UserId",
                table: "ThreeDFilaments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ThreeDPrinters_UserId",
                table: "ThreeDPrinters",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ThreeDScanners_UserId",
                table: "ThreeDScanners",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ThreeDFilaments");

            migrationBuilder.DropTable(
                name: "ThreeDPrinters");

            migrationBuilder.DropTable(
                name: "ThreeDScanners");
        }
    }
}

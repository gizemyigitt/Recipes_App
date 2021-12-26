using Microsoft.EntityFrameworkCore.Migrations;

namespace WebSite.Data.Migrations
{
    public partial class site : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DunyaMutfak",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DunyaMutfakAd = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DunyaMutfak", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Kategori",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriAd = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kategori", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Malzeme",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Miktar = table.Column<double>(type: "float", nullable: false),
                    Birim = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Malzeme", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tatli",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tarif = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DunyaMutfakId = table.Column<int>(type: "int", nullable: true),
                    TatlıFoto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KategoriId = table.Column<int>(type: "int", nullable: true),
                    KisiSayisi = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tatli", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tatli_DunyaMutfak_DunyaMutfakId",
                        column: x => x.DunyaMutfakId,
                        principalTable: "DunyaMutfak",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tatli_Kategori_KategoriId",
                        column: x => x.KategoriId,
                        principalTable: "Kategori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tarifler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KategoriId = table.Column<int>(type: "int", nullable: false),
                    TatliId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarifler", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tarifler_Kategori_KategoriId",
                        column: x => x.KategoriId,
                        principalTable: "Kategori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tarifler_Tatli_TatliId",
                        column: x => x.TatliId,
                        principalTable: "Tatli",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TatliMalzeme",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TatliId = table.Column<int>(type: "int", nullable: false),
                    MalzemeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TatliMalzeme", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TatliMalzeme_Malzeme_MalzemeId",
                        column: x => x.MalzemeId,
                        principalTable: "Malzeme",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TatliMalzeme_Tatli_TatliId",
                        column: x => x.TatliId,
                        principalTable: "Tatli",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tarifler_KategoriId",
                table: "Tarifler",
                column: "KategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarifler_TatliId",
                table: "Tarifler",
                column: "TatliId");

            migrationBuilder.CreateIndex(
                name: "IX_Tatli_DunyaMutfakId",
                table: "Tatli",
                column: "DunyaMutfakId");

            migrationBuilder.CreateIndex(
                name: "IX_Tatli_KategoriId",
                table: "Tatli",
                column: "KategoriId");

            migrationBuilder.CreateIndex(
                name: "IX_TatliMalzeme_MalzemeId",
                table: "TatliMalzeme",
                column: "MalzemeId");

            migrationBuilder.CreateIndex(
                name: "IX_TatliMalzeme_TatliId",
                table: "TatliMalzeme",
                column: "TatliId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tarifler");

            migrationBuilder.DropTable(
                name: "TatliMalzeme");

            migrationBuilder.DropTable(
                name: "Malzeme");

            migrationBuilder.DropTable(
                name: "Tatli");

            migrationBuilder.DropTable(
                name: "DunyaMutfak");

            migrationBuilder.DropTable(
                name: "Kategori");
        }
    }
}

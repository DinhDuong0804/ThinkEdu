using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ThinkEdu_Core_Service.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class DbInit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "to_chuc",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ma_to_chuc = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    ten_to_chuc = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    so_dien_thoai = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true),
                    status = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_by = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_to_chuc", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "setting",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    setting_key = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    setting_value = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    tenant_id = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_setting", x => x.id);
                    table.ForeignKey(
                        name: "FK_setting_to_chuc_tenant_id",
                        column: x => x.tenant_id,
                        principalTable: "to_chuc",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "trung_tam",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    tenant_id = table.Column<long>(type: "bigint", nullable: false),
                    ten_trung_tam = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    dia_chi = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    so_dien_thoai = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true),
                    email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    hinh_anh = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    mo_ta = table.Column<string>(type: "varchar", nullable: true),
                    co_so_max = table.Column<int>(type: "int", nullable: true),
                    status = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_by = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    updated_by = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_trung_tam", x => x.id);
                    table.ForeignKey(
                        name: "FK_trung_tam_to_chuc_tenant_id",
                        column: x => x.tenant_id,
                        principalTable: "to_chuc",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "co_so",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ma_co_so = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    ten_co_so = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false),
                    dia_chi = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    so_dien_thoai = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true),
                    email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    trung_tam_id = table.Column<long>(type: "bigint", nullable: false),
                    tenant_id = table.Column<long>(type: "bigint", nullable: false),
                    status = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    created_by = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    updated_by = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_co_so", x => x.id);
                    table.ForeignKey(
                        name: "FK_co_so_trung_tam_trung_tam_id",
                        column: x => x.trung_tam_id,
                        principalTable: "trung_tam",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_co_so_ma_co_so",
                table: "co_so",
                column: "ma_co_so",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_co_so_trung_tam_id",
                table: "co_so",
                column: "trung_tam_id");

            migrationBuilder.CreateIndex(
                name: "IX_setting_tenant_id",
                table: "setting",
                column: "tenant_id");

            migrationBuilder.CreateIndex(
                name: "IX_trung_tam_tenant_id",
                table: "trung_tam",
                column: "tenant_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "co_so");

            migrationBuilder.DropTable(
                name: "setting");

            migrationBuilder.DropTable(
                name: "trung_tam");

            migrationBuilder.DropTable(
                name: "to_chuc");
        }
    }
}

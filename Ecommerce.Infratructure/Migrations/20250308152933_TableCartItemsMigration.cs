using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.Infratructure.Migrations
{
    /// <inheritdoc />
    public partial class TableCartItemsMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cart_Product_ProductId",
                table: "Cart");

            migrationBuilder.DropIndex(
                name: "IX_Cart_ProductId",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Cart");

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CartId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Cart_CartId",
                        column: x => x.CartId,
                        principalTable: "Cart",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartItems_Product_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("2587a6b7-0606-4355-9791-187993b185fb"),
                column: "Password",
                value: "$2a$11$l1e3iGO7RO/2dzhaJRxUaueNMlmzKZkYHZT5zNsvMBmA1j2v2XsEa");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("26fba044-0f72-4eb2-a22f-1aa5133f3597"),
                column: "Password",
                value: "$2a$11$7ugq.4g7LrBKecXp.yw/GODF2PBgnpuKpiLbll3LtuMJxXm6wwbIy");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("357766ff-0ea4-4e41-95e5-dc091d07dce6"),
                column: "Password",
                value: "$2a$11$.Dgqz9hkvGzRBf.mrZIfTOKFLIl8sdtGf0HYxxmEVXh7br8aISqtW");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("457bce7f-2925-43b2-8ea1-9e16d214c4d4"),
                column: "Password",
                value: "$2a$11$qndoeRvH2WY7HOWoQKpIr.UGgLZsSfT3RyJmhAlUMYWg99FkD9x0S");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("470a4a17-033a-43ab-890f-5bfa2dc58c11"),
                column: "Password",
                value: "$2a$11$k4tocQGRUA4qYd2WO828Oezel0A2AoVEO2nhuYXtEHdVl0UDABQju");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("5d3a0719-ec82-47cf-9dc6-09742a90e699"),
                column: "Password",
                value: "$2a$11$vktnShwVKBwprqyINBNTR.WPif97R6/u6MbYiXmbzFheWkpX78oUO");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("75cd8061-acbc-4ebd-92a5-1f10513c49f6"),
                column: "Password",
                value: "$2a$11$Hfj.BTw06FEVi6u9GvoYL./IiN.TrTaeYj3mm5XyPsNi7mI26gCTe");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("9a1e850e-4d06-4046-aca7-8e3b5a2e6ecb"),
                column: "Password",
                value: "$2a$11$QtOrXuVtx/MD4hpFWDuPP.icwUnpFGVCjWRpHM9f5EGbuVO1aEoEm");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("9f7a4dc4-1834-40e6-93ef-feaf829fc2b4"),
                column: "Password",
                value: "$2a$11$wMAAqxTUoJ1mvEvaAVlW8enOpITVLDcjNhr16/ga5WsAJSBF4mSKe");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("c3943215-fcb6-40d3-a813-2f952b721f0d"),
                column: "Password",
                value: "$2a$11$fn03OyZNm0VZ2eG/HMTRX.5zik6spuTX9kfWDPUHqB1RQL6HRgki2");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("ce88e8d1-0c0d-41a8-983e-932c2a7a99fc"),
                column: "Password",
                value: "$2a$11$xgNgvpjHlig6aGIGWRYq/.CIQ7GS1ninrAJPM.ugHBcDga16XVwBu");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("d20cf5b1-fca3-4a88-ab52-fea58d34f25d"),
                column: "Password",
                value: "$2a$11$dNEMqm7/bHC9KnRNzpkKVe0bz7Jf0pSuX6lVnKrjmI3EWPTbgMwLK");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("d74473dd-4cfb-421b-9a97-8a48de482804"),
                column: "Password",
                value: "$2a$11$iNs7GSXKMQZgzmKzGDsduuSv0K//of5RkjpXcw6Cv2BwOYpvVzile");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e525b409-dfa7-4f7b-97df-d47c4f61bc99"),
                column: "Password",
                value: "$2a$11$W8Sqpf/KLotlyHYYDOVYrOieynn08HVleEpV6xY7.BU6k3T7qu.NC");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f7a7da30-33db-454e-a2eb-574e9a834b59"),
                column: "Password",
                value: "$2a$11$DTD.OejvG38qnG1hMcOoXe8tF4QPPzEttaiR14Xbj6HTCmtF.aS2C");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_CartId",
                table: "CartItems",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_ProductId",
                table: "CartItems",
                column: "ProductId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductId",
                table: "Cart",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Cart",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("2587a6b7-0606-4355-9791-187993b185fb"),
                column: "Password",
                value: "$2a$11$37wPZVmiTUsMGfFxQOy6QeL36q1xSgwMizZ9mBqGqfBi7Pbsh4r5.");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("26fba044-0f72-4eb2-a22f-1aa5133f3597"),
                column: "Password",
                value: "$2a$11$nctY7tuujMl0cg2cdEwzxOBNkx.GTkNCpcgGUzQx6T5VzYhJu6pwu");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("357766ff-0ea4-4e41-95e5-dc091d07dce6"),
                column: "Password",
                value: "$2a$11$4OtAo2Kh6h1J12WfC3Z0F.hG4jnNY8NgERImF1nqQixi7rbASly.m");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("457bce7f-2925-43b2-8ea1-9e16d214c4d4"),
                column: "Password",
                value: "$2a$11$i4djBfN0Mp309Xtz4tGum.HDsO59OIqXZ3PB/pma15OpVab3y8uzm");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("470a4a17-033a-43ab-890f-5bfa2dc58c11"),
                column: "Password",
                value: "$2a$11$40rzdGvlDEdIoEAaDsCVJ.FFc.yCRTHJHl1BdsgUNcgyfVYqK8zja");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("5d3a0719-ec82-47cf-9dc6-09742a90e699"),
                column: "Password",
                value: "$2a$11$dlk2ZIhXWLHVxNrLBnIhEuMBqv/.qE17tCdp/crLBI6R3mwm.JBQy");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("75cd8061-acbc-4ebd-92a5-1f10513c49f6"),
                column: "Password",
                value: "$2a$11$JtOWW22vyjZECbsllMfmwuMUzZ/./jxqmX7ae/uY59LsefE6b7cCC");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("9a1e850e-4d06-4046-aca7-8e3b5a2e6ecb"),
                column: "Password",
                value: "$2a$11$E6hoVSOCtaJqOWhEDwV/.udusHQclOQZcfRu8ngsJZ2xbDBr6RESm");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("9f7a4dc4-1834-40e6-93ef-feaf829fc2b4"),
                column: "Password",
                value: "$2a$11$ZEEaZHJpwxTBcfm2cOz1L.5ORY7KlzpAweLQp6Ekk30XVjKjsQstG");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("c3943215-fcb6-40d3-a813-2f952b721f0d"),
                column: "Password",
                value: "$2a$11$EryXLITJA3t/Eecj104thukwQTnA9uHZ4lyhMOXomKd7OQMQQvMny");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("ce88e8d1-0c0d-41a8-983e-932c2a7a99fc"),
                column: "Password",
                value: "$2a$11$WUFN1j0XDd95V1UqQVnvSuxTHSmN28M6VCsobD9j96esrcR9qnXyS");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("d20cf5b1-fca3-4a88-ab52-fea58d34f25d"),
                column: "Password",
                value: "$2a$11$HSu3csIcUvQkigBrzMPeaujHEawHLDRjSyijJrT8HL1U3iBelxBV.");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("d74473dd-4cfb-421b-9a97-8a48de482804"),
                column: "Password",
                value: "$2a$11$nvENX05mBUKw03On2tEJAu6eIwLUJpH9WBwDuGVlGm4/kk.QTyLCC");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e525b409-dfa7-4f7b-97df-d47c4f61bc99"),
                column: "Password",
                value: "$2a$11$Q4po1aElASPVDCwUDnyzkODb0yH5a1f.i1bHg/OA6WuyPEMFHTO5y");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f7a7da30-33db-454e-a2eb-574e9a834b59"),
                column: "Password",
                value: "$2a$11$bA.5tDAf/8WkptAanIXULuyJLUnTVuQNisYfExLq2hmiLaTKY1bJq");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_ProductId",
                table: "Cart",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cart_Product_ProductId",
                table: "Cart",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

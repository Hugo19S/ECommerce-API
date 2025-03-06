using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.Infratructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeProductOwnershipMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_User_UpdatedBy",
                table: "Product");

            migrationBuilder.DropIndex(
                name: "IX_Product_UpdatedBy",
                table: "Product");

            migrationBuilder.AlterColumn<Guid>(
                name: "UpdatedBy",
                table: "Product",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "UpdatedBy",
                table: "Product",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("2587a6b7-0606-4355-9791-187993b185fb"),
                column: "Password",
                value: "$2a$11$Z6zQyfFxcGMip5oxPd9Zn.i1Y79Q0ssd/RbvFnVb1D/5wCVV7NrbC");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("26fba044-0f72-4eb2-a22f-1aa5133f3597"),
                column: "Password",
                value: "$2a$11$IfkBJmmHGr9cfOm.fiH8LOqaBX.wX4GrhKjYyJy97Xqkn6aOlUMdi");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("357766ff-0ea4-4e41-95e5-dc091d07dce6"),
                column: "Password",
                value: "$2a$11$mh3SJ.Lkzu/zLc4d1Iz2I.531EVH62CehxjqiwBMMmeuHAf0eXADi");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("457bce7f-2925-43b2-8ea1-9e16d214c4d4"),
                column: "Password",
                value: "$2a$11$h/p5l3C6N1zad/h9cd0B0eJPKeVAFBKTBOFAmIDZ9XdBQKUzzXaey");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("470a4a17-033a-43ab-890f-5bfa2dc58c11"),
                column: "Password",
                value: "$2a$11$VKO8lAHwmCwr/kq89izD9OF2YGNrDHQjtU6L6bwwKR0NYEOkMIcDi");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("5d3a0719-ec82-47cf-9dc6-09742a90e699"),
                column: "Password",
                value: "$2a$11$LhsREZ1x4pVHEVuB5ZHE5Okns3DGEKH7NX7V/dn.fwpMRradRHV7m");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("75cd8061-acbc-4ebd-92a5-1f10513c49f6"),
                column: "Password",
                value: "$2a$11$nMZXrVmrYxY.3JcM5OBIU.IV6wiGdwB33xCJrAB04d.RfiQ1Fw9A6");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("9a1e850e-4d06-4046-aca7-8e3b5a2e6ecb"),
                column: "Password",
                value: "$2a$11$.KtKk9A.RuZKuzYx5wA4PeVo8ePyuf8F56OveQ60YHNiZ08nUln4m");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("9f7a4dc4-1834-40e6-93ef-feaf829fc2b4"),
                column: "Password",
                value: "$2a$11$GSB.AgtB3oHRbvXQdKmK7uJcJEnOnk1hYsF77SjS/mTEfZ4E9KdWO");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("c3943215-fcb6-40d3-a813-2f952b721f0d"),
                column: "Password",
                value: "$2a$11$ww6eHmGr.MuyVKsNtf5ZXu8YYcKN3m2H/L5bD5Ku7lmuPSaea..rW");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("ce88e8d1-0c0d-41a8-983e-932c2a7a99fc"),
                column: "Password",
                value: "$2a$11$rVtJTKGjHfgu5fd44hD6UeRupGrvAO/3vpmJqRENtcBXUl5I7.rvO");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("d20cf5b1-fca3-4a88-ab52-fea58d34f25d"),
                column: "Password",
                value: "$2a$11$VIsB6fNzvmlDgNBFlPhaTOfRCY1IFh9jsh5q808p3NRwA6s.I0KzC");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("d74473dd-4cfb-421b-9a97-8a48de482804"),
                column: "Password",
                value: "$2a$11$85hRXWa8OpwOQgCDqh1P/.n2fCVXFhWxoJzsnZu7l4IlwuqwS5GQ2");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e525b409-dfa7-4f7b-97df-d47c4f61bc99"),
                column: "Password",
                value: "$2a$11$hMzwUFZlBn5Uk/sf/834l.UUOkjrVgFOYt.XCt3Ge3nMxmzrq7xTC");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f7a7da30-33db-454e-a2eb-574e9a834b59"),
                column: "Password",
                value: "$2a$11$cW1.hawHWR01dTsFjHE/JuQNQH.EVyAqcBdxFho2DPFhRhAAu..sK");

            migrationBuilder.CreateIndex(
                name: "IX_Product_UpdatedBy",
                table: "Product",
                column: "UpdatedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_User_UpdatedBy",
                table: "Product",
                column: "UpdatedBy",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

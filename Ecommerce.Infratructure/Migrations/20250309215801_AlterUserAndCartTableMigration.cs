using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.Infratructure.Migrations
{
    /// <inheritdoc />
    public partial class AlterUserAndCartTableMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Cart_UserId",
                table: "Cart");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("2587a6b7-0606-4355-9791-187993b185fb"),
                column: "Password",
                value: "$2a$11$qk6OoOi2j9x.fS/kJnfEt.NhGpm9dm/0XBI8XAkzKoOhT1zHUT7hm");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("26fba044-0f72-4eb2-a22f-1aa5133f3597"),
                column: "Password",
                value: "$2a$11$EvxQCnE3eV50RjZtT5lfyurpwMU1FPQ15M/Mriys8nvS3cDwO4aEe");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("357766ff-0ea4-4e41-95e5-dc091d07dce6"),
                column: "Password",
                value: "$2a$11$wwwD7FtIbmqn4ekqIZwE.eQjikpN5y6V3mQ1z3rXkHxFr2lWkUcGa");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("457bce7f-2925-43b2-8ea1-9e16d214c4d4"),
                column: "Password",
                value: "$2a$11$C3e.mGbwSZgbnmrs9xH0yOjUZluadgxm/8nKURRXmO3qqg53SGRh.");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("470a4a17-033a-43ab-890f-5bfa2dc58c11"),
                column: "Password",
                value: "$2a$11$QFKQwYp/4mJLQUN.yAF1ouUejvIgpB5XXMC769W2HneTQEYf.6LoC");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("5d3a0719-ec82-47cf-9dc6-09742a90e699"),
                column: "Password",
                value: "$2a$11$1qf7oO63s1tl6py5TzxLbu85CgDKOODU8HQhyNB32co12bvKTCfFK");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("75cd8061-acbc-4ebd-92a5-1f10513c49f6"),
                column: "Password",
                value: "$2a$11$3s2dz3cVKeSitFrfE8UuUOOOJNYk3KeTUAvziM9R648BuZruert5u");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("9a1e850e-4d06-4046-aca7-8e3b5a2e6ecb"),
                column: "Password",
                value: "$2a$11$I4fzvnbphmnNNtM9mZKmAe5aDfXxvbari.UYgQf2in3KqyH7t.cnC");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("9f7a4dc4-1834-40e6-93ef-feaf829fc2b4"),
                column: "Password",
                value: "$2a$11$m/rBaokE3lEKidNRhFbJlONVpBsb77bAipMMzUuVNT2kShd.uezlK");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("c3943215-fcb6-40d3-a813-2f952b721f0d"),
                column: "Password",
                value: "$2a$11$8heuX8.hfFG/pAfrRVMbrOJ.uXBTyZJRXFHGnjWEYqg9xJaN/gVPS");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("ce88e8d1-0c0d-41a8-983e-932c2a7a99fc"),
                column: "Password",
                value: "$2a$11$PP4mMKZNKAHZA6yGGrcEPe0x0mziDz4ieb4DrXjHMThARIWCCF/Fa");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("d20cf5b1-fca3-4a88-ab52-fea58d34f25d"),
                column: "Password",
                value: "$2a$11$xHnLRW1grfOWsAtAxPcq1.h6PFM8LvgVh5OPcZLI/eEgT2Vo0O4fS");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("d74473dd-4cfb-421b-9a97-8a48de482804"),
                column: "Password",
                value: "$2a$11$AsDSgtyUmxPtLo.4GpkBU.8I1LYALl7RJj5/Urw4iKc7QfEre.fkC");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e525b409-dfa7-4f7b-97df-d47c4f61bc99"),
                column: "Password",
                value: "$2a$11$P0mFUdnxbKWaRWOCEFj0yOSW111ea.iB52r645xeCPhtJRn4ZvbQi");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f7a7da30-33db-454e-a2eb-574e9a834b59"),
                column: "Password",
                value: "$2a$11$fWD1wqS7tnJnGfHkcjMk0epByybQAyvCnLDeLiy4AfVskWDBg6aAK");

            migrationBuilder.CreateIndex(
                name: "IX_User_UserRoleId",
                table: "User",
                column: "UserRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_UserId",
                table: "Cart",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_User_UserRoles_UserRoleId",
                table: "User",
                column: "UserRoleId",
                principalTable: "UserRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_UserRoles_UserRoleId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_UserRoleId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_Cart_UserId",
                table: "Cart");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("2587a6b7-0606-4355-9791-187993b185fb"),
                column: "Password",
                value: "$2a$11$yKNNT01bLveMyafPcmnCpepfHKxWrqJ4jj1aWnsjkL2Q1JCyinBPi");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("26fba044-0f72-4eb2-a22f-1aa5133f3597"),
                column: "Password",
                value: "$2a$11$tUxx552N2RcbSqEnzXerneFDKf/c3SVSdRIJoBKZ/oO.vggU0lh0S");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("357766ff-0ea4-4e41-95e5-dc091d07dce6"),
                column: "Password",
                value: "$2a$11$oV18.2gyKHuMsCe0v0TFLOv1LyQGKptyr/n8ouANpt//rzWZ637kG");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("457bce7f-2925-43b2-8ea1-9e16d214c4d4"),
                column: "Password",
                value: "$2a$11$t/RWQBQImCQVs.PPiFI/B.i9dPoPNeEcij9LLYVDVULC3NSTDU/U6");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("470a4a17-033a-43ab-890f-5bfa2dc58c11"),
                column: "Password",
                value: "$2a$11$4r2KQGv1GucGkmu9JYwdy.MEVIDKZ3F/oo9vso.GOSDYPh/o/8REW");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("5d3a0719-ec82-47cf-9dc6-09742a90e699"),
                column: "Password",
                value: "$2a$11$spna8//wVD5ciUDxN0OG3.WVUz35MS9rTFbxQ/Itk56lgZTJDcoH2");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("75cd8061-acbc-4ebd-92a5-1f10513c49f6"),
                column: "Password",
                value: "$2a$11$cqA9yLJ.nYXDNyhWpslage.5fMKEcMRLMaXa9oohZXxFgUVDr8wh2");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("9a1e850e-4d06-4046-aca7-8e3b5a2e6ecb"),
                column: "Password",
                value: "$2a$11$19IHtBtINCd7I1cQOJzP7.gJuoDMbjaQs4IwRoXNhfi2rwE4T88Fi");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("9f7a4dc4-1834-40e6-93ef-feaf829fc2b4"),
                column: "Password",
                value: "$2a$11$ryb9Ag014nN.F7mgEOJyE.OIqId31FhkTy9/LaJW0JkcSL3N4aZfW");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("c3943215-fcb6-40d3-a813-2f952b721f0d"),
                column: "Password",
                value: "$2a$11$u4RN3gDRd6UjDTiEwOiozucILyrzJTSGwT1K9OCx2A.NiXfHUWooW");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("ce88e8d1-0c0d-41a8-983e-932c2a7a99fc"),
                column: "Password",
                value: "$2a$11$s008T.RQ92ZSPz9sFJOuI.dXSDSGEtlFxKF8blOK5ZRDwAL6YmeQG");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("d20cf5b1-fca3-4a88-ab52-fea58d34f25d"),
                column: "Password",
                value: "$2a$11$1UNbsFtW38rOajOTC3.wfO3yCCUz8jlrgpLoi58pvCVBKhH4G/cY6");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("d74473dd-4cfb-421b-9a97-8a48de482804"),
                column: "Password",
                value: "$2a$11$/rYeEnFHlXlnCaeU3tMdEOqNUtglncrkgqZL3oIQZxKu.HNsliW3O");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e525b409-dfa7-4f7b-97df-d47c4f61bc99"),
                column: "Password",
                value: "$2a$11$T06lJFoJwiQZoh.pv2s.yOByYd/EJSJSoDHQp7O4RPIu36ziLk9mu");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f7a7da30-33db-454e-a2eb-574e9a834b59"),
                column: "Password",
                value: "$2a$11$Dw00amqT1GTjaW6bNuuaYebe77q.xNqN4dpOY3WekeMgM.KT9bvna");

            migrationBuilder.CreateIndex(
                name: "IX_Cart_UserId",
                table: "Cart",
                column: "UserId");
        }
    }
}

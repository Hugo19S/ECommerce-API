using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ecommerce.Infratructure.Migrations
{
    /// <inheritdoc />
    public partial class RemoveRequeiredFromAddresUserTableMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_UserRoles_UserRoleId",
                table: "User");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropIndex(
                name: "IX_User_UserRoleId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UserRoleId",
                table: "User");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "User",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("2587a6b7-0606-4355-9791-187993b185fb"),
                column: "Password",
                value: "$2a$11$0wYvlxyrgRxIPDVkvGM4x.ht4vCLnbqmhC0HfYKfFY7EpvXf9y60K");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("26fba044-0f72-4eb2-a22f-1aa5133f3597"),
                column: "Password",
                value: "$2a$11$P5RUO9FzkqLcBBcvLb7LVuqR27iawYfSFnhjFM3WesOsUl3.W8kXG");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("357766ff-0ea4-4e41-95e5-dc091d07dce6"),
                column: "Password",
                value: "$2a$11$UlZNwrgg2Mk0h11rD6mwku9nAI51rlv1rqKZyewC2oWK6GW1AAWIK");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("457bce7f-2925-43b2-8ea1-9e16d214c4d4"),
                column: "Password",
                value: "$2a$11$cpu9k1ksOV4FDisaSHh3h./hfFfVOOaCrr9JxrE4F.NYAzeFXq0ci");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("470a4a17-033a-43ab-890f-5bfa2dc58c11"),
                column: "Password",
                value: "$2a$11$2KGck76WJIcNG7fmgYKFI.i6zIJwVpIu4ItVzY9PRKkPqlEcP4NVG");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("5d3a0719-ec82-47cf-9dc6-09742a90e699"),
                column: "Password",
                value: "$2a$11$P1.Bj.9pIc2DqCgWji6A5.myVXDLZnSe0CAcruatbmIYlmvWi1fbS");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("75cd8061-acbc-4ebd-92a5-1f10513c49f6"),
                column: "Password",
                value: "$2a$11$aLhkWv/hCrj5wqwEN/tC/ecScJLMyu1G3EqV570FS8PkKVjoraeWW");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("9a1e850e-4d06-4046-aca7-8e3b5a2e6ecb"),
                column: "Password",
                value: "$2a$11$pImfLkLbITFAY1mK/4yCl.KWwrPtSHxrnCx5yQa.Jk9UvCWJoei4a");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("9f7a4dc4-1834-40e6-93ef-feaf829fc2b4"),
                column: "Password",
                value: "$2a$11$PbyZJkkv55q1JUb5Obto6.qK6cDBo5RSNJ9Fw16IbSAmdfmehAdL6");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("c3943215-fcb6-40d3-a813-2f952b721f0d"),
                column: "Password",
                value: "$2a$11$cJeIhsW8T8WlgpD/Hpgwoukj4HzI0LC7g/WF7IWyovphXRhpHPl1m");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("ce88e8d1-0c0d-41a8-983e-932c2a7a99fc"),
                column: "Password",
                value: "$2a$11$.Q13N9G8PaPZq6KGlVbZ7uneNd0d75TRWuzoSlJE720wDRaUuP8Yy");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("d20cf5b1-fca3-4a88-ab52-fea58d34f25d"),
                column: "Password",
                value: "$2a$11$sD9aZEMW1QduFsixeJGZ/Ok7GtGr3ID2QdlnzL/4gByLDkKyfEYDK");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("d74473dd-4cfb-421b-9a97-8a48de482804"),
                column: "Password",
                value: "$2a$11$dyz.BYGxzWRYTSV/dbrE7uXThGlvVRFvVi97Aq5g9AZuit/vw2cL2");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e525b409-dfa7-4f7b-97df-d47c4f61bc99"),
                column: "Password",
                value: "$2a$11$kunJrmHYQNfomnEqnVd.1erEqMKTEcYMhEuMFWD4KJlxE/5odQZtS");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f7a7da30-33db-454e-a2eb-574e9a834b59"),
                column: "Password",
                value: "$2a$11$0B1l/lcBc5wHFZl0LUMaouVKzM4TIfwL8BDRMw9pdVW9dWkOneIru");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Address",
                table: "User",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "UserRoleId",
                table: "User",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("2587a6b7-0606-4355-9791-187993b185fb"),
                columns: new[] { "Password", "UserRoleId" },
                values: new object[] { "$2a$11$qk6OoOi2j9x.fS/kJnfEt.NhGpm9dm/0XBI8XAkzKoOhT1zHUT7hm", new Guid("1a2b3c4d-5e6f-7890-1234-56789abcdef0") });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("26fba044-0f72-4eb2-a22f-1aa5133f3597"),
                columns: new[] { "Password", "UserRoleId" },
                values: new object[] { "$2a$11$EvxQCnE3eV50RjZtT5lfyurpwMU1FPQ15M/Mriys8nvS3cDwO4aEe", new Guid("1a2b3c4d-5e6f-7890-1234-56789abcdef0") });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("357766ff-0ea4-4e41-95e5-dc091d07dce6"),
                columns: new[] { "Password", "UserRoleId" },
                values: new object[] { "$2a$11$wwwD7FtIbmqn4ekqIZwE.eQjikpN5y6V3mQ1z3rXkHxFr2lWkUcGa", new Guid("1a2b3c4d-5e6f-7890-1234-56789abcdef0") });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("457bce7f-2925-43b2-8ea1-9e16d214c4d4"),
                columns: new[] { "Password", "UserRoleId" },
                values: new object[] { "$2a$11$C3e.mGbwSZgbnmrs9xH0yOjUZluadgxm/8nKURRXmO3qqg53SGRh.", new Guid("3c4d5e6f-7890-1234-5678-9abcdef01234") });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("470a4a17-033a-43ab-890f-5bfa2dc58c11"),
                columns: new[] { "Password", "UserRoleId" },
                values: new object[] { "$2a$11$QFKQwYp/4mJLQUN.yAF1ouUejvIgpB5XXMC769W2HneTQEYf.6LoC", new Guid("3c4d5e6f-7890-1234-5678-9abcdef01234") });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("5d3a0719-ec82-47cf-9dc6-09742a90e699"),
                columns: new[] { "Password", "UserRoleId" },
                values: new object[] { "$2a$11$1qf7oO63s1tl6py5TzxLbu85CgDKOODU8HQhyNB32co12bvKTCfFK", new Guid("3c4d5e6f-7890-1234-5678-9abcdef01234") });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("75cd8061-acbc-4ebd-92a5-1f10513c49f6"),
                columns: new[] { "Password", "UserRoleId" },
                values: new object[] { "$2a$11$3s2dz3cVKeSitFrfE8UuUOOOJNYk3KeTUAvziM9R648BuZruert5u", new Guid("3c4d5e6f-7890-1234-5678-9abcdef01234") });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("9a1e850e-4d06-4046-aca7-8e3b5a2e6ecb"),
                columns: new[] { "Password", "UserRoleId" },
                values: new object[] { "$2a$11$I4fzvnbphmnNNtM9mZKmAe5aDfXxvbari.UYgQf2in3KqyH7t.cnC", new Guid("3c4d5e6f-7890-1234-5678-9abcdef01234") });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("9f7a4dc4-1834-40e6-93ef-feaf829fc2b4"),
                columns: new[] { "Password", "UserRoleId" },
                values: new object[] { "$2a$11$m/rBaokE3lEKidNRhFbJlONVpBsb77bAipMMzUuVNT2kShd.uezlK", new Guid("3c4d5e6f-7890-1234-5678-9abcdef01234") });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("c3943215-fcb6-40d3-a813-2f952b721f0d"),
                columns: new[] { "Password", "UserRoleId" },
                values: new object[] { "$2a$11$8heuX8.hfFG/pAfrRVMbrOJ.uXBTyZJRXFHGnjWEYqg9xJaN/gVPS", new Guid("3c4d5e6f-7890-1234-5678-9abcdef01234") });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("ce88e8d1-0c0d-41a8-983e-932c2a7a99fc"),
                columns: new[] { "Password", "UserRoleId" },
                values: new object[] { "$2a$11$PP4mMKZNKAHZA6yGGrcEPe0x0mziDz4ieb4DrXjHMThARIWCCF/Fa", new Guid("3c4d5e6f-7890-1234-5678-9abcdef01234") });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("d20cf5b1-fca3-4a88-ab52-fea58d34f25d"),
                columns: new[] { "Password", "UserRoleId" },
                values: new object[] { "$2a$11$xHnLRW1grfOWsAtAxPcq1.h6PFM8LvgVh5OPcZLI/eEgT2Vo0O4fS", new Guid("3c4d5e6f-7890-1234-5678-9abcdef01234") });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("d74473dd-4cfb-421b-9a97-8a48de482804"),
                columns: new[] { "Password", "UserRoleId" },
                values: new object[] { "$2a$11$AsDSgtyUmxPtLo.4GpkBU.8I1LYALl7RJj5/Urw4iKc7QfEre.fkC", new Guid("3c4d5e6f-7890-1234-5678-9abcdef01234") });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e525b409-dfa7-4f7b-97df-d47c4f61bc99"),
                columns: new[] { "Password", "UserRoleId" },
                values: new object[] { "$2a$11$P0mFUdnxbKWaRWOCEFj0yOSW111ea.iB52r645xeCPhtJRn4ZvbQi", new Guid("3c4d5e6f-7890-1234-5678-9abcdef01234") });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f7a7da30-33db-454e-a2eb-574e9a834b59"),
                columns: new[] { "Password", "UserRoleId" },
                values: new object[] { "$2a$11$fWD1wqS7tnJnGfHkcjMk0epByybQAyvCnLDeLiy4AfVskWDBg6aAK", new Guid("3c4d5e6f-7890-1234-5678-9abcdef01234") });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("1a2b3c4d-5e6f-7890-1234-56789abcdef0"), "Has full access to the system and can manage other users.", "Admin" },
                    { new Guid("2b3c4d5e-6f78-9012-3456-789abcdef123"), "Can manage product listings and view sales reports.", "Manager" },
                    { new Guid("3c4d5e6f-7890-1234-5678-9abcdef01234"), "Can browse products, place orders, and track deliveries.", "Customer" },
                    { new Guid("4d5e6f78-9012-3456-789a-bcdef1234567"), "Can manage inventory and supply chain logistics.", "Supplier" },
                    { new Guid("5e6f7890-1234-5678-9abc-def012345678"), "Handles customer support and resolves user issues.", "Support" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_UserRoleId",
                table: "User",
                column: "UserRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_UserRoles_UserRoleId",
                table: "User",
                column: "UserRoleId",
                principalTable: "UserRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

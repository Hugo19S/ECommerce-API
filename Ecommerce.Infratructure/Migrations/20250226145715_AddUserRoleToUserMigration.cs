using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.Infratructure.Migrations
{
    /// <inheritdoc />
    public partial class AddUserRoleToUserMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "User");

            migrationBuilder.AddColumn<Guid>(
                name: "UserRoleId",
                table: "User",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("2587a6b7-0606-4355-9791-187993b185fb"),
                columns: new[] { "Password", "UserRoleId" },
                values: new object[] { "$2a$11$Z6zQyfFxcGMip5oxPd9Zn.i1Y79Q0ssd/RbvFnVb1D/5wCVV7NrbC", new Guid("1a2b3c4d-5e6f-7890-1234-56789abcdef0") });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("26fba044-0f72-4eb2-a22f-1aa5133f3597"),
                columns: new[] { "Password", "UserRoleId" },
                values: new object[] { "$2a$11$IfkBJmmHGr9cfOm.fiH8LOqaBX.wX4GrhKjYyJy97Xqkn6aOlUMdi", new Guid("1a2b3c4d-5e6f-7890-1234-56789abcdef0") });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("357766ff-0ea4-4e41-95e5-dc091d07dce6"),
                columns: new[] { "Password", "UserRoleId" },
                values: new object[] { "$2a$11$mh3SJ.Lkzu/zLc4d1Iz2I.531EVH62CehxjqiwBMMmeuHAf0eXADi", new Guid("1a2b3c4d-5e6f-7890-1234-56789abcdef0") });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("457bce7f-2925-43b2-8ea1-9e16d214c4d4"),
                columns: new[] { "Password", "UserRoleId" },
                values: new object[] { "$2a$11$h/p5l3C6N1zad/h9cd0B0eJPKeVAFBKTBOFAmIDZ9XdBQKUzzXaey", new Guid("3c4d5e6f-7890-1234-5678-9abcdef01234") });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("470a4a17-033a-43ab-890f-5bfa2dc58c11"),
                columns: new[] { "Password", "UserRoleId" },
                values: new object[] { "$2a$11$VKO8lAHwmCwr/kq89izD9OF2YGNrDHQjtU6L6bwwKR0NYEOkMIcDi", new Guid("3c4d5e6f-7890-1234-5678-9abcdef01234") });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("5d3a0719-ec82-47cf-9dc6-09742a90e699"),
                columns: new[] { "Password", "UserRoleId" },
                values: new object[] { "$2a$11$LhsREZ1x4pVHEVuB5ZHE5Okns3DGEKH7NX7V/dn.fwpMRradRHV7m", new Guid("3c4d5e6f-7890-1234-5678-9abcdef01234") });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("75cd8061-acbc-4ebd-92a5-1f10513c49f6"),
                columns: new[] { "Password", "UserRoleId" },
                values: new object[] { "$2a$11$nMZXrVmrYxY.3JcM5OBIU.IV6wiGdwB33xCJrAB04d.RfiQ1Fw9A6", new Guid("3c4d5e6f-7890-1234-5678-9abcdef01234") });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("9a1e850e-4d06-4046-aca7-8e3b5a2e6ecb"),
                columns: new[] { "Password", "UserRoleId" },
                values: new object[] { "$2a$11$.KtKk9A.RuZKuzYx5wA4PeVo8ePyuf8F56OveQ60YHNiZ08nUln4m", new Guid("3c4d5e6f-7890-1234-5678-9abcdef01234") });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("9f7a4dc4-1834-40e6-93ef-feaf829fc2b4"),
                columns: new[] { "Password", "UserRoleId" },
                values: new object[] { "$2a$11$GSB.AgtB3oHRbvXQdKmK7uJcJEnOnk1hYsF77SjS/mTEfZ4E9KdWO", new Guid("3c4d5e6f-7890-1234-5678-9abcdef01234") });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("c3943215-fcb6-40d3-a813-2f952b721f0d"),
                columns: new[] { "Password", "UserRoleId" },
                values: new object[] { "$2a$11$ww6eHmGr.MuyVKsNtf5ZXu8YYcKN3m2H/L5bD5Ku7lmuPSaea..rW", new Guid("3c4d5e6f-7890-1234-5678-9abcdef01234") });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("ce88e8d1-0c0d-41a8-983e-932c2a7a99fc"),
                columns: new[] { "Password", "UserRoleId" },
                values: new object[] { "$2a$11$rVtJTKGjHfgu5fd44hD6UeRupGrvAO/3vpmJqRENtcBXUl5I7.rvO", new Guid("3c4d5e6f-7890-1234-5678-9abcdef01234") });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("d20cf5b1-fca3-4a88-ab52-fea58d34f25d"),
                columns: new[] { "Password", "UserRoleId" },
                values: new object[] { "$2a$11$VIsB6fNzvmlDgNBFlPhaTOfRCY1IFh9jsh5q808p3NRwA6s.I0KzC", new Guid("3c4d5e6f-7890-1234-5678-9abcdef01234") });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("d74473dd-4cfb-421b-9a97-8a48de482804"),
                columns: new[] { "Password", "UserRoleId" },
                values: new object[] { "$2a$11$85hRXWa8OpwOQgCDqh1P/.n2fCVXFhWxoJzsnZu7l4IlwuqwS5GQ2", new Guid("3c4d5e6f-7890-1234-5678-9abcdef01234") });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e525b409-dfa7-4f7b-97df-d47c4f61bc99"),
                columns: new[] { "Password", "UserRoleId" },
                values: new object[] { "$2a$11$hMzwUFZlBn5Uk/sf/834l.UUOkjrVgFOYt.XCt3Ge3nMxmzrq7xTC", new Guid("3c4d5e6f-7890-1234-5678-9abcdef01234") });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f7a7da30-33db-454e-a2eb-574e9a834b59"),
                columns: new[] { "Password", "UserRoleId" },
                values: new object[] { "$2a$11$cW1.hawHWR01dTsFjHE/JuQNQH.EVyAqcBdxFho2DPFhRhAAu..sK", new Guid("3c4d5e6f-7890-1234-5678-9abcdef01234") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserRoleId",
                table: "User");

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "User",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("2587a6b7-0606-4355-9791-187993b185fb"),
                columns: new[] { "Password", "Role" },
                values: new object[] { "$2a$11$.HBnurdCauTaWcDGV83V/O2Kj4VqN2H0e49/YPYb0zfhtv6GRZBma", "Admin" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("26fba044-0f72-4eb2-a22f-1aa5133f3597"),
                columns: new[] { "Password", "Role" },
                values: new object[] { "$2a$11$OJOWpihl5yP60WoryuOAn.3aLdwic37D19Ly6shPgLgXOMQe9JVXS", "Admin" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("357766ff-0ea4-4e41-95e5-dc091d07dce6"),
                columns: new[] { "Password", "Role" },
                values: new object[] { "$2a$11$ZEk3pXUAgUDtj0DHTVvulO21OkzK1TO5S5oevlSN3jE2.VBfXK4TS", "Admin" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("457bce7f-2925-43b2-8ea1-9e16d214c4d4"),
                columns: new[] { "Password", "Role" },
                values: new object[] { "$2a$11$hlFBmawwEXKlAYScuZmnZOMoLW/uFxaXT3pVCALpH4.vw2vfcJCnS", "Admin" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("470a4a17-033a-43ab-890f-5bfa2dc58c11"),
                columns: new[] { "Password", "Role" },
                values: new object[] { "$2a$11$fkTMYiriw6Nqa.ORepJxveU3.1CrQvf3N8819MLUIF2hAYVXNQkBq", "Admin" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("5d3a0719-ec82-47cf-9dc6-09742a90e699"),
                columns: new[] { "Password", "Role" },
                values: new object[] { "$2a$11$IpcoSMaXAU/TKhjwKwgpSuXiuTV4cwkt8gFn3YOFMyiywViG.1mQq", "User" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("75cd8061-acbc-4ebd-92a5-1f10513c49f6"),
                columns: new[] { "Password", "Role" },
                values: new object[] { "$2a$11$RZHsIom/h3HgYbgUVOOJAO1NiCMgZjIso6BE/cLikSl9gqSHFyuOu", "User" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("9a1e850e-4d06-4046-aca7-8e3b5a2e6ecb"),
                columns: new[] { "Password", "Role" },
                values: new object[] { "$2a$11$K05QB8LpYUg2QGj7smilG.ewJn3fb.zgfLhj6oyR7FK/VspUYN96K", "User" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("9f7a4dc4-1834-40e6-93ef-feaf829fc2b4"),
                columns: new[] { "Password", "Role" },
                values: new object[] { "$2a$11$UqWyyOPZc5o48Y09fQ/1EesTqBd4uz592iZVskfHvPicHnmqSrdha", "User" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("c3943215-fcb6-40d3-a813-2f952b721f0d"),
                columns: new[] { "Password", "Role" },
                values: new object[] { "$2a$11$yOZx1SKNTCdZAvLRkwHxSu.xV5o0a3vyjcU37l2ZIP730.7UbUHWu", "User" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("ce88e8d1-0c0d-41a8-983e-932c2a7a99fc"),
                columns: new[] { "Password", "Role" },
                values: new object[] { "$2a$11$wVn7HKNdLUp7RrqyHUz5CevJbaO.T.tGh2f5e7teraaUYfsMQ42D2", "User" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("d20cf5b1-fca3-4a88-ab52-fea58d34f25d"),
                columns: new[] { "Password", "Role" },
                values: new object[] { "$2a$11$FmtH2EctaEjw9Ac5OIKFK.15sBGeyi4k7yTnujRVesoiwvGQPVw3O", "User" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("d74473dd-4cfb-421b-9a97-8a48de482804"),
                columns: new[] { "Password", "Role" },
                values: new object[] { "$2a$11$MMosDT3PLRFlTZEpvvsZie9mRacVisV0uwkRoZ9awPXUJFvg0uwbC", "User" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e525b409-dfa7-4f7b-97df-d47c4f61bc99"),
                columns: new[] { "Password", "Role" },
                values: new object[] { "$2a$11$oAEYFBb6H9owCkQgaVyt1enNs0s9WB.O8Ea4.M7n7ppOO6L0m7iNu", "User" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f7a7da30-33db-454e-a2eb-574e9a834b59"),
                columns: new[] { "Password", "Role" },
                values: new object[] { "$2a$11$wDzdFa5h3RoyWSoMPTmXNOATjH43nOsf2A.shW8F0qxLc1gWRvhHW", "User" });
        }
    }
}

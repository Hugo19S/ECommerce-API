using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Ecommerce.Infratructure.Migrations
{
    /// <inheritdoc />
    public partial class UserRoleMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("2587a6b7-0606-4355-9791-187993b185fb"),
                column: "Password",
                value: "$2a$11$.HBnurdCauTaWcDGV83V/O2Kj4VqN2H0e49/YPYb0zfhtv6GRZBma");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("26fba044-0f72-4eb2-a22f-1aa5133f3597"),
                column: "Password",
                value: "$2a$11$OJOWpihl5yP60WoryuOAn.3aLdwic37D19Ly6shPgLgXOMQe9JVXS");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("357766ff-0ea4-4e41-95e5-dc091d07dce6"),
                column: "Password",
                value: "$2a$11$ZEk3pXUAgUDtj0DHTVvulO21OkzK1TO5S5oevlSN3jE2.VBfXK4TS");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("457bce7f-2925-43b2-8ea1-9e16d214c4d4"),
                column: "Password",
                value: "$2a$11$hlFBmawwEXKlAYScuZmnZOMoLW/uFxaXT3pVCALpH4.vw2vfcJCnS");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("470a4a17-033a-43ab-890f-5bfa2dc58c11"),
                column: "Password",
                value: "$2a$11$fkTMYiriw6Nqa.ORepJxveU3.1CrQvf3N8819MLUIF2hAYVXNQkBq");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("5d3a0719-ec82-47cf-9dc6-09742a90e699"),
                column: "Password",
                value: "$2a$11$IpcoSMaXAU/TKhjwKwgpSuXiuTV4cwkt8gFn3YOFMyiywViG.1mQq");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("75cd8061-acbc-4ebd-92a5-1f10513c49f6"),
                column: "Password",
                value: "$2a$11$RZHsIom/h3HgYbgUVOOJAO1NiCMgZjIso6BE/cLikSl9gqSHFyuOu");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("9a1e850e-4d06-4046-aca7-8e3b5a2e6ecb"),
                column: "Password",
                value: "$2a$11$K05QB8LpYUg2QGj7smilG.ewJn3fb.zgfLhj6oyR7FK/VspUYN96K");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("9f7a4dc4-1834-40e6-93ef-feaf829fc2b4"),
                column: "Password",
                value: "$2a$11$UqWyyOPZc5o48Y09fQ/1EesTqBd4uz592iZVskfHvPicHnmqSrdha");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("c3943215-fcb6-40d3-a813-2f952b721f0d"),
                column: "Password",
                value: "$2a$11$yOZx1SKNTCdZAvLRkwHxSu.xV5o0a3vyjcU37l2ZIP730.7UbUHWu");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("ce88e8d1-0c0d-41a8-983e-932c2a7a99fc"),
                column: "Password",
                value: "$2a$11$wVn7HKNdLUp7RrqyHUz5CevJbaO.T.tGh2f5e7teraaUYfsMQ42D2");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("d20cf5b1-fca3-4a88-ab52-fea58d34f25d"),
                column: "Password",
                value: "$2a$11$FmtH2EctaEjw9Ac5OIKFK.15sBGeyi4k7yTnujRVesoiwvGQPVw3O");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("d74473dd-4cfb-421b-9a97-8a48de482804"),
                column: "Password",
                value: "$2a$11$MMosDT3PLRFlTZEpvvsZie9mRacVisV0uwkRoZ9awPXUJFvg0uwbC");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e525b409-dfa7-4f7b-97df-d47c4f61bc99"),
                column: "Password",
                value: "$2a$11$oAEYFBb6H9owCkQgaVyt1enNs0s9WB.O8Ea4.M7n7ppOO6L0m7iNu");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f7a7da30-33db-454e-a2eb-574e9a834b59"),
                column: "Password",
                value: "$2a$11$wDzdFa5h3RoyWSoMPTmXNOATjH43nOsf2A.shW8F0qxLc1gWRvhHW");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("2587a6b7-0606-4355-9791-187993b185fb"),
                column: "Password",
                value: "$2a$11$azUFOkohBXKH3dH27.yEUeG7..W.EuYBk48W8T/UMRc3DKfjhcqCC");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("26fba044-0f72-4eb2-a22f-1aa5133f3597"),
                column: "Password",
                value: "$2a$11$30mkmc1/.tUNlz21ME1iCOpffyu.PHaQmsNzpZ2vkK5CwKeTcnKAW");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("357766ff-0ea4-4e41-95e5-dc091d07dce6"),
                column: "Password",
                value: "$2a$11$7oVASZrOCcJecgpTrVBJkej3.RaUQkT9tbc8KxznkLW2EI4Cq3p/i");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("457bce7f-2925-43b2-8ea1-9e16d214c4d4"),
                column: "Password",
                value: "$2a$11$vLvWz4.66V/bwgGnMRBWMuY.HzIbT/AK3IFOpVRtCrlHkZx/vg.Qe");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("470a4a17-033a-43ab-890f-5bfa2dc58c11"),
                column: "Password",
                value: "$2a$11$7Np8MiBEdH9yP9npyFRjze3R4Y5Jnl2hkuJRRsAR5EYZp2e7ZBkri");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("5d3a0719-ec82-47cf-9dc6-09742a90e699"),
                column: "Password",
                value: "$2a$11$wKnrrTHD2bA1lWyL0HQbue3g9nl48JdBj2vs12/fqvHyGFrRexBoe");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("75cd8061-acbc-4ebd-92a5-1f10513c49f6"),
                column: "Password",
                value: "$2a$11$NSKLqwEdM50lfmW4kISbZuuuGHf/n61giQJAvoiA5uXsOCPv22Yde");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("9a1e850e-4d06-4046-aca7-8e3b5a2e6ecb"),
                column: "Password",
                value: "$2a$11$9Y/pCOVlh13YMJUl2ygRYO.6nj7LS0F5uZWWeVxScBhvqlOuwEMBe");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("9f7a4dc4-1834-40e6-93ef-feaf829fc2b4"),
                column: "Password",
                value: "$2a$11$EMV888OPGHENgRcrc1E0ReKlaZYa.BTNTkA9n99NaW13d0OdrBSii");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("c3943215-fcb6-40d3-a813-2f952b721f0d"),
                column: "Password",
                value: "$2a$11$m1DbR/aw7LWPg51EHLMnb.Su88Ms9lyjOD.CCRZi6gXA.1kmRyyXG");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("ce88e8d1-0c0d-41a8-983e-932c2a7a99fc"),
                column: "Password",
                value: "$2a$11$BU.HZG23bgP7t8d9DYd0YuakwtafliSwTzcmxwSpLrxNhCV03uP5y");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("d20cf5b1-fca3-4a88-ab52-fea58d34f25d"),
                column: "Password",
                value: "$2a$11$TYNl7ZydUTRM3PBzzUZYP.4TJAoHzn8vMh2meMKZYiIcTFhtfyHh6");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("d74473dd-4cfb-421b-9a97-8a48de482804"),
                column: "Password",
                value: "$2a$11$by1CTOiNt83P87IIZ19bTe6RheXETVfdrvkTzQaefyLlO2k1hpj8e");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("e525b409-dfa7-4f7b-97df-d47c4f61bc99"),
                column: "Password",
                value: "$2a$11$gjveauG2YXz61Cxi54iPLev.kIBJVAGUcOXrKb1gCMQ5uAxqtQso6");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("f7a7da30-33db-454e-a2eb-574e9a834b59"),
                column: "Password",
                value: "$2a$11$Rj2rsbzJibvpwglPQsqEhu6kRlwKDsvXRW22R.0UiA7ThirWZQR3W");
        }
    }
}

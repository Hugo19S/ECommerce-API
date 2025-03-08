using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ecommerce.Infratructure.Migrations
{
    /// <inheritdoc />
    public partial class AlterPaymentTableMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalPaid",
                table: "Payment",
                newName: "TotalPayable");

            migrationBuilder.RenameIndex(
                name: "IX_Payment_TotalPaid",
                table: "Payment",
                newName: "IX_Payment_TotalPayable");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TotalPayable",
                table: "Payment",
                newName: "TotalPaid");

            migrationBuilder.RenameIndex(
                name: "IX_Payment_TotalPayable",
                table: "Payment",
                newName: "IX_Payment_TotalPaid");

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
        }
    }
}

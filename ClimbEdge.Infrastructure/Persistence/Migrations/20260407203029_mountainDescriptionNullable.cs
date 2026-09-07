using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClimbEdge.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mountainDescriptionNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Mountain",
                type: "character varying(500)",
                maxLength: 500,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500);

            migrationBuilder.UpdateData(
                table: "DifficultyGroup",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 741, DateTimeKind.Utc).AddTicks(6311), new Guid("6796321c-2077-46e6-a5aa-46176fc62e9f") });

            migrationBuilder.UpdateData(
                table: "DifficultyGroup",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 741, DateTimeKind.Utc).AddTicks(6343), new Guid("65ca541a-b4d9-4979-a674-23d40d28567a") });

            migrationBuilder.UpdateData(
                table: "DifficultyGroup",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 741, DateTimeKind.Utc).AddTicks(6347), new Guid("be78cd7d-9ed4-48fc-ae45-074e556e19d5") });

            migrationBuilder.UpdateData(
                table: "DifficultyGroup",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 741, DateTimeKind.Utc).AddTicks(6349), new Guid("2a954f72-1549-49aa-a2f4-0a68d4ba95dc") });

            migrationBuilder.UpdateData(
                table: "DifficultyGroup",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 741, DateTimeKind.Utc).AddTicks(6353), new Guid("fbe3b62a-aa5d-45ab-b525-b5cfce0fef43") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(6940), new Guid("8975d45a-fa5c-4253-89eb-30060ed54c1d") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(6967), new Guid("a3f6a460-9e3d-47ec-accb-fb5236488fd8") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(6978), new Guid("62859785-a040-4616-8f2f-bbb636c62520") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(6982), new Guid("937ad4de-f92a-4b99-a6db-5ee1c78bd15b") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(6985), new Guid("57d4a214-fdb4-40dc-9be0-05cadacd1c41") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(6989), new Guid("f743a737-d484-40ab-bd11-3bf418887864") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(6991), new Guid("9f7b2146-bd14-47a4-987e-241d56e2d3c3") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(6994), new Guid("8b02d862-0ff9-4489-b27a-056efb2707c9") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(6996), new Guid("56eb7d3a-e390-4a08-9336-4ce6becc2d5c") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(6999), new Guid("b6a3d16d-f9ec-49a1-9a43-8e32d098b861") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 11L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7005), new Guid("5a5e49f0-6363-4a39-9793-f005e34e3872") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 12L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7008), new Guid("ffa2935e-ab12-469a-bde4-d68f791d9193") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 13L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7010), new Guid("f9fb3b38-96c2-4814-a8af-3a83f6301071") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 14L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7013), new Guid("2ca98186-9d97-4292-97e3-0a2e452c2f06") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 15L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7016), new Guid("4a9e9c5d-eb84-46df-a824-39c9a5063db8") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 16L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7018), new Guid("b9cade77-fc6c-4fae-b716-cc5963832429") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 17L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7021), new Guid("959783b1-bb83-44c9-bf2e-171f92df803a") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 18L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7023), new Guid("2c5287a7-263b-472c-9835-76497d1db228") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 19L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7029), new Guid("baf6741e-fbeb-46e8-801a-bf4bfc805bf7") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 20L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7031), new Guid("0ef38c31-0218-47ac-904a-8dfec4d8cf8e") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 21L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7040), new Guid("49d44760-2057-4a31-a44e-bc808ed49aa9") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 22L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7044), new Guid("99fd6e4c-fb87-42ed-8042-2cdc44ef015e") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 23L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7047), new Guid("9ec5d134-4baf-43e9-8132-8682e79a18f6") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 24L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7051), new Guid("785adfdc-194d-4b3e-b890-120ea4013a56") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 25L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7055), new Guid("b90a3a08-95b2-425e-8357-303a9229bdb6") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 26L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7059), new Guid("1251731c-5924-4e18-a0d7-71236cb9c51c") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 27L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7064), new Guid("ed783d8f-b5b6-4082-bc54-b23dd25f36c1") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 28L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7068), new Guid("4031221f-f617-47b2-ad48-e23be5a0bfcb") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 29L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7072), new Guid("a53676b7-8ab0-484d-8d9a-c891b9eae6e4") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 30L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7075), new Guid("1331a945-97d6-457d-9d8d-a2536ae1ac6f") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 31L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7077), new Guid("b1481f91-3fbb-42ac-9c58-5bb50eb3cae7") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 32L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7080), new Guid("eb3fbf08-f6d9-4396-904b-3d60759ea520") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 33L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7084), new Guid("3038f9f8-05e8-421c-a437-0703d64aaa12") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 34L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7087), new Guid("8dd3fd7d-0cc2-48d0-b77e-ce1e2f03a3e8") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 35L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7092), new Guid("3ae9a0ac-872e-4d06-a2b5-63c92545bbdb") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 36L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7095), new Guid("a735346d-4173-4ba0-adbf-0ca414c67cc1") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 37L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7098), new Guid("4a7de922-0b3f-4cd0-9ef4-b9821cea1194") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 38L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7101), new Guid("c1654c8b-16cd-4e4d-8bc3-161d2beb637b") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 39L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7104), new Guid("f9b52bda-b5ea-49e3-b2dd-a719192b819a") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 40L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7107), new Guid("2fab1f9c-0e6a-4a60-b480-669a2f6db47c") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 41L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7110), new Guid("4ee02020-7aec-4dc3-b5be-5ee4372156c3") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 42L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7113), new Guid("f4f6764f-8442-4e5f-9b07-48c5636ff776") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 43L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7128), new Guid("0051e28e-0db9-434b-ae88-f1d49edca428") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 44L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7131), new Guid("69e05b0b-fc2f-47d3-9c98-2b0ce84f5996") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 45L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7134), new Guid("470d0d2b-4a76-4c4d-bad8-9cc57dbb9d65") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 46L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7137), new Guid("5b830145-cfbe-448b-91da-5a7dc08d4828") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 47L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7141), new Guid("01135ba5-cb51-4566-9eb2-b37837976660") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 48L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7145), new Guid("fe747a97-f703-4837-86c0-59b5fa7d7a43") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 49L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7149), new Guid("d20a31b4-5b16-41ba-8583-a10671d3e00e") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 50L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7152), new Guid("b19ac82f-6660-435b-a3cc-9a00346d517b") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 51L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7157), new Guid("cf7d2af0-49db-4f3c-b06f-bff59e622543") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 52L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7160), new Guid("52bdd96a-beb8-4b17-93d5-649e0c74daf2") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 53L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7165), new Guid("44d0240e-d19c-4109-81bf-1e73fa6ce307") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 54L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7169), new Guid("fc9ee6c6-ca4f-43fe-aeca-97951666ac14") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 55L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7172), new Guid("e77b717f-0575-4622-9df4-66863eda5aa6") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 56L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7174), new Guid("5f25091b-285e-4901-b7c9-cd16d4e239d9") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 57L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7177), new Guid("4f3431b0-c05f-43ed-859a-ac0811da65f9") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 58L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7179), new Guid("42aea9fa-0081-424b-9bc4-12287968da78") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 59L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7184), new Guid("09e19391-b891-45fa-bdab-cf2095cf33ae") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 60L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7187), new Guid("8602a68e-7dc3-4a62-b45a-e3623f8218a7") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 61L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7190), new Guid("20dd0a9b-d4f4-4748-a765-8a4c693b0f29") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 62L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7193), new Guid("908d7000-ed06-4e2a-9e53-cf631627d35a") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 63L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7196), new Guid("c8bd73c0-9fae-42cb-9a7e-ed0d5e0c9625") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 64L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7198), new Guid("a777aba5-d6ce-4266-9f15-04cd9c9d7dfa") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 65L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7201), new Guid("1755087e-615b-4476-a194-503e1a83edf9") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 66L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7217), new Guid("924f866c-bfab-4b5f-bcfe-86aadedd1c36") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 67L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7223), new Guid("01414d8b-ccec-49b6-bff6-65093f9e7f69") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 68L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7226), new Guid("f4d411d8-6e60-4764-98a5-97352a5a216d") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 69L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7229), new Guid("2d9a5622-03cd-4962-87c5-c4a21d4c1bc1") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 70L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7232), new Guid("7379b2d9-ad5e-494b-848f-1c9356c0b141") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 71L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7235), new Guid("31d60e3f-b357-4299-9e62-bf699b3892cb") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 72L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7238), new Guid("ed0992e4-8c3b-40a0-adbf-ca39b298795a") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 73L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7241), new Guid("c347cf63-a7b5-4856-b183-4a4ae69f15f1") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 74L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7243), new Guid("586e70f1-26ec-4e90-bcd8-ea534b50abdd") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 75L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7248), new Guid("9ab7e28b-cbeb-478b-931b-168472a5d865") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 76L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7251), new Guid("68f76f36-144a-42e0-9c05-8e620b969936") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 77L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7254), new Guid("9a5977a9-9727-42e6-a757-af227c905d57") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 78L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7257), new Guid("bc8d23a1-bb21-499a-a8dd-bcb4ee0b47c7") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 79L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7260), new Guid("c05a40cd-69eb-494a-9732-eeb249d17301") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 80L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7262), new Guid("cf617bd6-0839-4f38-8fae-d561a17117c8") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 81L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7265), new Guid("7914ba8d-8020-4cb5-bb2a-c4f279fdeb3f") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 82L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7268), new Guid("a1049974-41f1-46b5-8901-cdd4b08e9532") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 83L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7274), new Guid("dd29d029-5c2f-4613-8610-a74cd03c236b") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 84L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7276), new Guid("3a8fbaa9-a97c-457c-959a-3e377103a655") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 85L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7279), new Guid("08fd660d-a002-424e-98df-4188636e38d3") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 86L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7287), new Guid("3471beaa-ba62-4d60-acdb-b997f63298d9") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 87L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7290), new Guid("230fd058-bbe4-451a-a7c7-503079cd1695") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 88L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7294), new Guid("ef0976d2-f258-474d-971a-ecfa43555afc") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 89L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7297), new Guid("bb048f49-d7dc-40ab-a77d-d4e49239fd4c") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 90L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7301), new Guid("0e9fd1e1-043d-4a73-bc46-c445d42e80b5") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 91L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7306), new Guid("d2760b80-793b-404e-9265-8a6f2a6ec898") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 92L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7310), new Guid("72dd69d3-8917-4150-9a72-10b2fbe97584") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 93L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7313), new Guid("4347c46f-95f2-49fa-b6fc-de5a7a70f6f9") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 94L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7315), new Guid("692dc6a2-2c06-450a-8eb2-741fdf578f16") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 95L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7319), new Guid("a4193eaf-b05b-4b7e-a59c-93c39e223e37") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 96L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7322), new Guid("7363b072-11de-4cf8-a0b3-a000f2cd606a") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 97L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7325), new Guid("ff08b0d4-49f2-4cd7-8f8f-ad88d76a756d") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 98L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7328), new Guid("663f9bc5-a2b4-4746-8e05-9f5f0ed7b929") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 99L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7333), new Guid("4bdc9a3a-3937-4a68-8727-3f477a371e09") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 100L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7336), new Guid("3732bb97-046c-401a-adb0-e55eaf4b5c96") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 101L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7338), new Guid("afcd05e2-ed08-4a18-a428-84675b80f85e") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 102L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7341), new Guid("399080c5-24b2-4dcd-9acd-03ec0e3da904") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 103L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7344), new Guid("5812c311-2320-471c-ada8-b4e86c0d09a7") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 104L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7347), new Guid("3b10ab34-e953-4914-bca2-c00ae23c661a") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 105L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7349), new Guid("2f993b44-d13e-42b0-82f9-cd0fb317a1b1") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 106L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7353), new Guid("f2c6b0a8-a451-4123-986f-9d3aef1949e6") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 107L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7363), new Guid("bf510623-cd77-40c6-9c81-38a1925e4d30") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 108L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7366), new Guid("f6a78931-538e-47db-8653-bedb900dbcfc") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 109L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7369), new Guid("bafa4068-6cca-4fe6-8a37-3976e277cf79") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 110L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7372), new Guid("242a25ff-7e8b-46b4-ae0c-dec2f8303d28") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 111L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7375), new Guid("e70dde24-2168-4543-b97f-600e1f5f7bd3") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 112L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7378), new Guid("45030bff-a97d-42c8-809b-5e6875464db8") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 113L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7383), new Guid("4ebc2e2a-d6d7-47de-9dcf-fe4b47d633e8") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 114L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7386), new Guid("5d61515f-3893-4f33-b377-c7f7e221fac3") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 115L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7391), new Guid("6a5e0546-343a-4856-b8a1-5a964eb67fd5") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 116L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7394), new Guid("645f349f-4a79-4ebf-ad17-30ef8820249b") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 117L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7396), new Guid("6089a5c6-248c-4808-b603-f4c96115a7c8") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 118L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7399), new Guid("d8df4af4-cf7e-4e44-b626-4afb7e082cfe") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 119L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7402), new Guid("55b024f5-c805-4e15-a8db-21406ce259ea") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 120L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7404), new Guid("9ba8193c-bb73-4abf-8db5-6d822b14a049") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 121L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7407), new Guid("6dccd320-b151-4019-bdf4-b8542caadfb0") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 122L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7409), new Guid("c6f2a094-53b7-4668-8505-9bfec43ed128") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 123L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7414), new Guid("cda9cff7-8f0a-4541-9b48-25743a323a72") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 124L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7417), new Guid("3661229c-5805-490c-bdec-2a55202e2120") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 125L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7420), new Guid("958c3f6f-ec55-4fe8-9d88-d3c0a17b3b64") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 126L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7423), new Guid("7b470740-b846-4120-a663-cb669d8c5ceb") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 127L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7426), new Guid("694e5085-995c-474c-921a-2c00beb2defb") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 128L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7436), new Guid("10dadef4-3488-4497-9003-b5bbef459ddc") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 129L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7440), new Guid("df958509-e491-4b89-b8b5-41ad1efefa0f") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 130L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7444), new Guid("af1be7f3-2a95-43db-bbad-98f510ff6b87") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 131L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7450), new Guid("f23096e9-d823-4048-b5e7-06520dca9051") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 132L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7453), new Guid("1de8961c-5873-42ca-bd04-41933202dbd8") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 133L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7456), new Guid("d5b72a39-073d-43ff-9a86-e335691d8604") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 134L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7459), new Guid("f85382dd-09d8-47e2-8443-602ea4d69a59") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 135L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7463), new Guid("0dc8c0cb-4be8-46b6-8f7d-c8b0d07ec84b") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 136L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7466), new Guid("8f44e0fb-ff8c-48d1-b6e7-1df03ed5ae52") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 137L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7469), new Guid("2808c4fc-d257-4056-9a2e-77a13f7ab0c0") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 138L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7471), new Guid("caf1a97c-8e05-454c-aa48-9e0cef6ca21b") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 139L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7476), new Guid("df689eae-ae21-49c4-b33c-1f150ea17d89") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 140L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7479), new Guid("baf5d906-ccab-425c-b580-b01c89ee7cfd") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 141L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7483), new Guid("22ff6647-eb0d-481b-be90-2b80401a0abc") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 142L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7486), new Guid("68c89052-432b-4b3c-9c16-b5902c528c80") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 143L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7493), new Guid("f98797bc-fcf0-4aa7-9734-8b8d1d13fe0f") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 144L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7496), new Guid("28d9a85c-9f33-4a8d-8b4a-7b0e037b5186") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 145L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7499), new Guid("dba4b444-73e5-4bca-9f69-c83f7e0c3dbf") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 146L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7502), new Guid("869c6de3-3fc6-400a-a83b-54de3ba2865b") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 147L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7508), new Guid("5d570a1d-a243-4adf-8ca3-9203c42dad49") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 148L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7517), new Guid("3b003453-59e3-454b-b0ed-9aac5204e851") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 149L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7520), new Guid("afb8b544-756c-41e7-b0b8-4bd25d7bb34f") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 150L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7523), new Guid("5a5196f3-28a6-4e75-b961-0624d3d8b090") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 151L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7525), new Guid("90240224-c743-4975-a0c0-5f2ce617f728") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 152L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7528), new Guid("78161a57-8543-4170-810b-49ee11bd692f") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 153L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7531), new Guid("6d72e764-1366-41b7-9341-3dfafde5dafe") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 154L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7534), new Guid("80b826ef-b169-41c2-98f3-1aeaac1147fe") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 155L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7540), new Guid("2e481d19-c581-4f09-91cd-6d9d20e23756") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 156L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7543), new Guid("fffaa2f2-8fd9-4872-bf58-bac0d21315eb") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 157L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7547), new Guid("6920e6e4-d8a5-490a-b8c5-cf9f760501ab") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 158L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7550), new Guid("d862ae89-4baf-4e18-a7b8-7826e56d7937") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 159L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7553), new Guid("c7ca1616-5da3-4862-b075-30e472a63fd3") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 160L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7557), new Guid("f37c373a-f73e-4a62-8858-0abbd82ac4be") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 161L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7560), new Guid("15d43ab9-c703-4805-8203-43b622fa6170") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 162L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7563), new Guid("8d52d64d-ccc3-466e-a111-c6e66f6c2398") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 163L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7568), new Guid("119ee124-f1b6-49a6-a901-f5011099a4eb") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 164L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7571), new Guid("98af3e33-383d-493e-b600-5b43b3d624f3") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 165L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7575), new Guid("57806ac4-fe6d-4726-baf5-2b2b00aa6a7f") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 166L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7577), new Guid("9e89dc59-7f90-47c4-8db6-ff98745edde5") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 167L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7581), new Guid("14f0a18e-c9b8-474e-a9ef-65843ecb95f7") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 168L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7584), new Guid("6bfd6fa9-9d19-4ada-9278-13822b37c0d5") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 169L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7595), new Guid("aa8b4f1c-9e5b-4476-827c-b5f617c9a2c4") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 170L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7599), new Guid("3d967fff-a554-4f56-bc0c-ac442810b65c") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 171L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7603), new Guid("71105379-7d32-4243-a0ce-a8df13820519") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 172L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7606), new Guid("b56cb164-c8e2-4925-be3a-da4de1d90b05") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 173L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7609), new Guid("db31313d-3a56-4492-9cc4-829d1d12058b") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 174L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7612), new Guid("8a0352d4-bf49-4843-b0d4-e28f8856493b") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 175L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7614), new Guid("2b265128-d99d-46cf-8b56-1f604c0017dd") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 176L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7617), new Guid("53be0bd6-a922-4d46-aa07-decdcc4d9b2d") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 177L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7620), new Guid("0d144576-6ef0-46b6-b72e-56c91fd940f0") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 178L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7623), new Guid("7d116706-3a43-4890-afbf-3187e4503f8c") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 179L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7628), new Guid("9b75a88e-ad93-489d-a985-4a9e10545d9a") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 180L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7632), new Guid("57782bf8-b4c7-4018-bb7d-4988138496d8") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 181L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7634), new Guid("b2326662-a602-4e9f-8e9d-da95e1672669") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 182L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7637), new Guid("f0934bb1-1ddf-4305-aef6-57ae5dc57b0b") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 183L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7640), new Guid("d3fca9d8-69b9-402a-b18b-c9f1eaa87e1a") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 184L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7643), new Guid("f7ee8df1-4ea8-4890-854f-6885f4a401fc") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 185L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7645), new Guid("c03b3abb-8ead-4544-a9dd-5697e68a4975") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 186L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7651), new Guid("8f995e1d-5b59-4487-8d17-1f929610a88e") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 187L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7656), new Guid("6e43fe4a-b2bd-421c-9fe8-77d1e0c5c087") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 188L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7659), new Guid("38c7d633-74b4-4f09-9d7e-a1965ae05a49") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 189L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7662), new Guid("6002b19e-9e78-49d5-949d-a2d7a06ca475") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 190L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7676), new Guid("5b760b3b-2177-449d-91bd-3d3bb9264799") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 191L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7680), new Guid("b66259d9-359f-4d0e-807c-e82128b6a713") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 192L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7683), new Guid("d9b83041-41d0-496e-b3f5-1711fd18cf46") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 193L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7686), new Guid("d3c1c778-c6d6-41c9-8edc-4c570eddf63f") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 194L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7689), new Guid("ca406615-c5eb-4acf-9e2a-47c95e9ad8d5") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 195L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7694), new Guid("e90bc271-65bf-40f4-90e0-5f188b707b94") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 196L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7697), new Guid("ac65f620-7e14-4bc3-bbb7-6bf9767ad9f8") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 197L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7700), new Guid("64676372-c992-4cd6-b2b8-9f8babcb5b97") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 198L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7703), new Guid("0e33a790-08ed-491a-a331-acb027307dc4") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 199L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7706), new Guid("43447dca-753b-4fad-bea6-e7ff648b259c") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 200L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7709), new Guid("31d8561f-e0df-4474-be61-82855a01ff25") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 201L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7712), new Guid("f3a7ef70-5324-4013-960d-bb22f4634558") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 202L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7715), new Guid("a84d6eed-b291-4069-832b-f72c520dddd9") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 203L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7720), new Guid("719a8048-7071-4e1e-8487-73245cd11123") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 204L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7724), new Guid("fb7f604e-0ca4-47d9-a02b-0b75064dc077") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 205L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7727), new Guid("cb8df14d-54e9-4123-b300-55d6da0d5841") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 206L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7730), new Guid("3a578c30-600b-4b97-a42e-e1f85e0f8c53") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 207L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7733), new Guid("fdd1f61d-eddc-465b-a7d1-d1a9f2a4e9c9") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 208L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7736), new Guid("dec6059d-ed37-41d9-9abf-dae7bdac5eb9") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 209L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7739), new Guid("2d5acdc7-9795-4ec7-95d8-40914c200664") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 210L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7742), new Guid("b2834900-594c-4e6f-b2eb-a2befdc1b3c9") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 211L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7755), new Guid("a9b5643c-1a1e-41f5-b898-8a2c7deb506e") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 212L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7758), new Guid("515676a4-3a6c-4c48-a911-8a2ae12bf0cc") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 213L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7761), new Guid("74ecc813-473d-4a17-bae5-7d9ef7827d08") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 214L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7764), new Guid("e7ff5f46-3b2d-40d1-9f1b-ba9a43bd8616") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 215L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7767), new Guid("25a3cb8d-50f4-47e8-bbac-fb89848fd187") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 216L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7770), new Guid("a0edc012-63f7-4f97-aa61-e5c26b7a8671") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 217L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7773), new Guid("5f81a601-d567-4685-83dc-daa8c6c80a38") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 218L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7775), new Guid("4ce55553-6b39-4760-aa60-2a3a44d53322") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 219L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7781), new Guid("23583113-8ef8-46ad-94a1-b7cc33ff8052") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 220L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7783), new Guid("32c30027-5ca8-43db-89ac-cbab8a47afcd") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 221L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7787), new Guid("e637a616-a5dc-41d7-b89a-f7ae5fbe4134") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 222L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7790), new Guid("622a232f-0fc0-4327-bb54-da5cf46811b1") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 223L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7793), new Guid("c40a97dc-196a-4148-95bb-074350eacd33") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 224L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7795), new Guid("30477a36-e235-42ce-9f8e-45a199f78417") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 225L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7798), new Guid("c16efacf-4c2a-429e-9b98-a1b20a30f06c") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 226L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 744, DateTimeKind.Utc).AddTicks(7801), new Guid("f29bbed8-79bf-4dde-9c04-cedf3580d061") });

            migrationBuilder.UpdateData(
                table: "DifficultyScaleName",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 746, DateTimeKind.Utc).AddTicks(5358), new Guid("e5a0008c-1cbe-4881-8363-acec0c23d350") });

            migrationBuilder.UpdateData(
                table: "DifficultyScaleName",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 746, DateTimeKind.Utc).AddTicks(5378), new Guid("52d6548a-346d-4c9f-bac8-97d59c20492b") });

            migrationBuilder.UpdateData(
                table: "DifficultyScaleName",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 746, DateTimeKind.Utc).AddTicks(5389), new Guid("08a318a4-734e-4fe1-8f2d-10e2338ba509") });

            migrationBuilder.UpdateData(
                table: "DifficultyScaleName",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 746, DateTimeKind.Utc).AddTicks(5392), new Guid("1a8370c3-2601-4fe2-91bd-1794229a1716") });

            migrationBuilder.UpdateData(
                table: "DifficultyScaleName",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 746, DateTimeKind.Utc).AddTicks(5398), new Guid("9d2130ad-3522-4492-80df-94e1f248f6f4") });

            migrationBuilder.UpdateData(
                table: "DifficultyScaleName",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 746, DateTimeKind.Utc).AddTicks(5401), new Guid("a9eb1b89-332e-40dc-b03d-6844141824de") });

            migrationBuilder.UpdateData(
                table: "DifficultyScaleName",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 746, DateTimeKind.Utc).AddTicks(5405), new Guid("6bfa3c5d-25f9-431c-b311-d258ef19f03a") });

            migrationBuilder.UpdateData(
                table: "DifficultyScaleName",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 746, DateTimeKind.Utc).AddTicks(5408), new Guid("e9a05125-53e0-4bd0-98e6-2d7b70edb7ca") });

            migrationBuilder.UpdateData(
                table: "DifficultyScaleName",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 746, DateTimeKind.Utc).AddTicks(5415), new Guid("4785636f-780a-4422-a960-0426ee1955f8") });

            migrationBuilder.UpdateData(
                table: "DifficultyScaleName",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 746, DateTimeKind.Utc).AddTicks(5418), new Guid("0185c602-c5e2-428d-b2fd-9e0b3704b141") });

            migrationBuilder.UpdateData(
                table: "DifficultyScaleName",
                keyColumn: "Id",
                keyValue: 11L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 746, DateTimeKind.Utc).AddTicks(5432), new Guid("d276b497-527f-429f-9fef-da4506834939") });

            migrationBuilder.UpdateData(
                table: "DifficultyScaleName",
                keyColumn: "Id",
                keyValue: 12L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 746, DateTimeKind.Utc).AddTicks(5435), new Guid("00e96849-146d-43a5-a1a5-33cf3e7b8f66") });

            migrationBuilder.UpdateData(
                table: "DifficultyScaleName",
                keyColumn: "Id",
                keyValue: 13L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 746, DateTimeKind.Utc).AddTicks(5438), new Guid("80af9531-6956-49f7-80ae-26e0eb2337d0") });

            migrationBuilder.UpdateData(
                table: "DifficultyScaleName",
                keyColumn: "Id",
                keyValue: 14L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 746, DateTimeKind.Utc).AddTicks(5442), new Guid("0f552810-bee6-4c39-91e7-60d1681180ed") });

            migrationBuilder.UpdateData(
                table: "DifficultyScaleName",
                keyColumn: "Id",
                keyValue: 15L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 746, DateTimeKind.Utc).AddTicks(5445), new Guid("cef15058-5af7-4b86-bb8c-621da47e050d") });

            migrationBuilder.UpdateData(
                table: "DifficultyScaleName",
                keyColumn: "Id",
                keyValue: 16L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 746, DateTimeKind.Utc).AddTicks(5449), new Guid("e670dff0-2595-4c4d-943e-fb9d39c657bd") });

            migrationBuilder.UpdateData(
                table: "DifficultyScaleName",
                keyColumn: "Id",
                keyValue: 17L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 746, DateTimeKind.Utc).AddTicks(5454), new Guid("f0ff0fb1-b0bb-4d46-9c49-04cad6b28b1c") });

            migrationBuilder.UpdateData(
                table: "DifficultyScaleType",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 747, DateTimeKind.Utc).AddTicks(4740), new Guid("67e68905-eef9-4385-ba17-4290c3ea6789") });

            migrationBuilder.UpdateData(
                table: "DifficultyScaleType",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 747, DateTimeKind.Utc).AddTicks(4760), new Guid("18adbc67-2138-43a3-9be2-0e90c7c327dc") });

            migrationBuilder.UpdateData(
                table: "DifficultyScaleType",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 747, DateTimeKind.Utc).AddTicks(4766), new Guid("9103f796-cd0e-48fd-8221-baca239b619b") });

            migrationBuilder.UpdateData(
                table: "DifficultyScaleType",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 747, DateTimeKind.Utc).AddTicks(4770), new Guid("2721acec-de0e-4e6d-a762-9236ef9a2a03") });

            migrationBuilder.UpdateData(
                table: "DifficultyScaleType",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 747, DateTimeKind.Utc).AddTicks(4773), new Guid("8214cb32-4072-470b-91e1-6c174154a5a5") });

            migrationBuilder.UpdateData(
                table: "DifficultyScaleType",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 747, DateTimeKind.Utc).AddTicks(4777), new Guid("dd6b61f6-afd8-4afc-9ab1-4a9df2856c23") });

            migrationBuilder.UpdateData(
                table: "DifficultyScaleType",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 747, DateTimeKind.Utc).AddTicks(4781), new Guid("c0bf8f9a-8b99-4b10-8e96-a91c2c4e4a09") });

            migrationBuilder.UpdateData(
                table: "DifficultyScaleType",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 7, 20, 30, 26, 747, DateTimeKind.Utc).AddTicks(4789), new Guid("08efcab6-e5f8-4de6-8569-93263ea1ce95") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Mountain",
                type: "character varying(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "character varying(500)",
                oldMaxLength: 500,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "DifficultyGroup",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 512, DateTimeKind.Utc).AddTicks(1189), new Guid("d9ea3890-3371-426e-b72d-9a3db4d5ed51") });

            migrationBuilder.UpdateData(
                table: "DifficultyGroup",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 512, DateTimeKind.Utc).AddTicks(1220), new Guid("02a4d121-95e9-4758-b526-90913222b930") });

            migrationBuilder.UpdateData(
                table: "DifficultyGroup",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 512, DateTimeKind.Utc).AddTicks(1224), new Guid("bf4c6a68-6338-4811-9531-3092979947a9") });

            migrationBuilder.UpdateData(
                table: "DifficultyGroup",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 512, DateTimeKind.Utc).AddTicks(1227), new Guid("975b7859-ca45-4c9e-b620-7e459e2e7d39") });

            migrationBuilder.UpdateData(
                table: "DifficultyGroup",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 512, DateTimeKind.Utc).AddTicks(1230), new Guid("0387a12f-f424-4862-86c5-42c11592e623") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4320), new Guid("c1d48fd9-1727-41c1-ab6f-194cfd7f24a1") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4340), new Guid("4a7cf757-710d-47ea-8fca-e63d8aa9d0a3") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4344), new Guid("48abee41-5e9c-4198-aa69-83c8b573e898") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4352), new Guid("7e139548-a837-4acd-8a91-fa8d497af702") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4355), new Guid("22fbcf90-2c83-4eb9-9d30-7c18501c49e4") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4357), new Guid("8ed655bb-5841-44ec-b31a-6fd5dda06646") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4360), new Guid("b4ce1bd2-42e8-4fa7-9d04-606117b6ae60") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4362), new Guid("086df1c0-d1c8-43ea-9dc8-e8673d2f7197") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4365), new Guid("1a3dd456-fc7d-4451-a13e-a099de3651b2") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4368), new Guid("a0e47085-4e22-4e6e-b2cb-39517c6809b6") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 11L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4379), new Guid("02cf3931-bf42-46db-9256-8881ea8ed006") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 12L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4384), new Guid("9f52baea-a1fe-453d-9d01-125b6f25fcd3") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 13L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4387), new Guid("c2545e1d-5628-4f7c-aa46-e15ffede2095") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 14L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4390), new Guid("c463623e-1252-45d8-8b37-228054b7bb70") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 15L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4394), new Guid("b77b7421-aacc-410d-a4aa-ecab2ad015d1") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 16L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4397), new Guid("028f44cf-9335-48ac-930f-800d1d068ffb") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 17L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4400), new Guid("103e9824-131d-486f-8363-4ac47ed8716b") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 18L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4403), new Guid("aa488f04-7580-4e82-bb2d-efce70e70735") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 19L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4408), new Guid("77cbefe2-58b4-48bd-a3d2-6e43969d6d01") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 20L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4414), new Guid("0d2cffed-f22d-4e8a-a7dc-0a9373414deb") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 21L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4417), new Guid("5cb70c8b-2316-4b84-bc45-04090ffc98d2") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 22L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4419), new Guid("cb2eaeb6-f138-4e7a-8ff5-0da699aba1fc") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 23L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4422), new Guid("891dbaf3-a6cc-44b4-afe3-544f3ea70d8e") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 24L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4425), new Guid("612631d4-22de-4f58-9802-f7220119bdf1") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 25L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4428), new Guid("e4c577d6-fb02-4d22-bad3-f4c32ce70934") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 26L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4432), new Guid("36fef2db-9a2d-4bb6-bafb-814444e3d455") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 27L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4434), new Guid("e54c97be-2f71-4b3a-a2f7-274e65ac0234") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 28L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4439), new Guid("a9d1df68-df08-4115-b299-980b6c34a98a") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 29L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4441), new Guid("f5d2d1e0-4d63-4373-a997-19cae868aeb3") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 30L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4444), new Guid("7bfe0ed1-402e-4d82-b03c-15176ecfb8e1") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 31L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4447), new Guid("7865d1d3-9633-47a0-83cb-f2f0876c91ef") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 32L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4449), new Guid("1bb1bac4-f947-40c2-b334-d173c97f69cc") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 33L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4460), new Guid("73bb8650-778d-4626-83c4-2e0044ec1746") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 34L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4464), new Guid("9a33d7c6-4eaa-4253-bd5c-036a89804f2a") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 35L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4467), new Guid("d41cacd7-fa89-4555-8a5f-532ef27d7bb8") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 36L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4472), new Guid("05bc2e84-5e56-457b-922a-4c134e32569d") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 37L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4476), new Guid("60738bc2-f603-4eb9-8b55-199fd513ee02") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 38L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4478), new Guid("a4512b00-29ce-4731-8da0-486085c8aca4") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 39L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4481), new Guid("ab44511d-8d04-44e0-88f2-e1ea96879c34") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 40L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4487), new Guid("3b402f16-da89-4dde-9fbf-1083760fd1ef") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 41L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4491), new Guid("22eedcd2-0933-4865-b46f-12c16840dc92") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 42L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4495), new Guid("549adb80-7507-4f59-bfeb-d4d9684ec968") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 43L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4498), new Guid("2f065fe8-186f-4c78-a40f-8254e68fbc40") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 44L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4503), new Guid("b0b73354-997a-472b-8d4d-ff877a6e3ad6") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 45L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4507), new Guid("b9b5d766-79e9-4839-8c41-4716a90caedf") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 46L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4510), new Guid("367fb547-8c0d-4f81-a952-d65663b55e76") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 47L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4514), new Guid("c1a6c27c-2271-494f-bda0-2a4d538328b6") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 48L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4518), new Guid("90653f0c-a5d2-4a86-98a7-25c66de7c9f1") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 49L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4521), new Guid("7b30fe38-8fbb-4d30-83a3-de5a5c702b7e") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 50L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4524), new Guid("a9a968a1-0652-4860-8d03-64cc74a2bff9") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 51L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4527), new Guid("d2df9631-9ab5-44a2-abe0-c73b9efba287") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 52L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4533), new Guid("9851d731-08eb-4084-bd92-1d39d5d004f1") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 53L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4536), new Guid("82b8c98b-6430-47eb-a1dd-8aa7d738c916") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 54L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4539), new Guid("983561cd-abc0-4cc7-a989-d40b3672b15c") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 55L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4542), new Guid("9ea5b746-01c4-428f-b318-5ac01839930d") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 56L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4550), new Guid("02dfd043-866b-4a12-8ab6-bc2e5fe21cfe") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 57L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4555), new Guid("aea6e7fa-1e0b-45b0-9da9-3ba7e3892d3c") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 58L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4558), new Guid("7b64509d-48df-49b0-8826-397520448222") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 59L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4561), new Guid("79718948-4e69-4f03-86ed-1696ac84ace5") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 60L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4567), new Guid("02989fa5-0ad3-471f-b8bb-a94fa0f788cb") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 61L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4572), new Guid("16f01a54-c756-4368-be08-719560cb08fe") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 62L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4574), new Guid("f3734ca3-eb3f-4454-9f0f-0f685d076892") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 63L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4576), new Guid("9d18a5ee-d46a-439c-b463-3f937f3216d5") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 64L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4579), new Guid("2f90852b-e637-4490-a315-a0265e64fe09") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 65L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4582), new Guid("aeae50b2-7ae5-4862-8ebe-83f617043866") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 66L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4591), new Guid("88993ff9-dd6a-48cb-b78c-ee3b18e8faaf") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 67L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4596), new Guid("157df1e8-d5b9-4a40-9fa8-8219ce4e80fe") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 68L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4602), new Guid("8d15561a-501a-44c1-909a-f3b3346f4b35") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 69L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4606), new Guid("2672e194-186b-4310-8ee8-7ffed2c6fbdd") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 70L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4610), new Guid("fc9ba6f3-d675-434e-afa4-96d561ed59ae") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 71L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4614), new Guid("82c5169c-5be6-46a3-9077-ecf4d52362b4") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 72L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4618), new Guid("ae26fc72-d670-41d6-aa05-4d3ff8e70781") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 73L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4625), new Guid("ff189d62-3864-492d-a532-7360b69372f1") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 74L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4628), new Guid("c41e3f02-ad19-4951-a87b-24e11545fc69") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 75L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4632), new Guid("4cdbb31e-5ccf-4c1c-b6b6-94a033d97743") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 76L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4637), new Guid("58a4d786-d250-4fc3-8249-aae4fef9cde6") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 77L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4647), new Guid("54460227-d406-45ff-be98-80acd6079a0d") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 78L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4653), new Guid("4454aa16-8a69-45d0-8d7d-c695f4ff047e") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 79L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4656), new Guid("538dddb0-5220-4d8f-8a78-8f4261b58850") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 80L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4660), new Guid("86d55da4-7ff6-498d-a36c-480c78938c19") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 81L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4664), new Guid("69f2b018-5fee-47ed-abe6-662883a07d98") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 82L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4668), new Guid("9f30a29e-12cc-458c-a5e4-7ccbe79faf1a") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 83L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4671), new Guid("c6d97e8b-77cf-491d-93f3-704c1b092a1d") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 84L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4677), new Guid("057a4edf-6514-4cce-bebd-f0132bf2770d") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 85L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4681), new Guid("ecaa0374-9a77-461a-a401-0229a00e8e7b") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 86L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4684), new Guid("9888976f-61d5-4224-b721-ad383df94dc1") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 87L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4688), new Guid("0a9bcf69-eb0c-4641-8fdd-00046e6e35dd") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 88L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4692), new Guid("2ab75766-1333-4086-a322-b795d28c477e") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 89L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4696), new Guid("47334833-7342-4492-b9e7-fb26df7217ce") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 90L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4699), new Guid("6d7a920e-e002-4288-ada2-34a14128c269") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 91L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4702), new Guid("da020064-cb9d-49ca-b244-d301d60b7886") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 92L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4708), new Guid("c172f873-3cf6-421a-bea6-0ae6f04cad1b") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 93L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4712), new Guid("ab652e1e-1c71-4d7e-a232-4b87d75316bc") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 94L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4715), new Guid("c78af906-4724-459d-809e-ca751ba88b19") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 95L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4718), new Guid("d94ace4c-9670-4c8f-b871-11c2de18bc76") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 96L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4721), new Guid("88b8d744-cb31-4741-afe8-8bdca521e24a") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 97L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4725), new Guid("de3657a8-0265-4de4-a1c0-7d0affb1f03c") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 98L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4737), new Guid("9d3b0484-bc05-4924-9ce3-58d0fe3eac0f") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 99L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4740), new Guid("c32a34dc-bf0e-457e-94cf-c262cbd56ff2") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 100L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4745), new Guid("46746321-b87b-4b29-8a8d-6ccce5139101") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 101L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4748), new Guid("53752aa7-6872-4232-b407-1f73063ed89b") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 102L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4751), new Guid("1c9689b9-9461-4e10-9549-9b8e670597d8") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 103L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4755), new Guid("dd2b3704-7773-4d53-9ad7-0469c68026b3") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 104L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4759), new Guid("d2804379-2d47-455d-b6cb-0ba6cbc8636b") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 105L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4764), new Guid("835ff387-2f8e-4e4f-bebf-365c781b8391") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 106L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4768), new Guid("e6e7fe27-d6ec-4ce2-8153-77343524ee90") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 107L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4771), new Guid("c2554d82-6efe-4fb5-b53a-3a5e0eb9829b") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 108L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4777), new Guid("004e7343-162c-4443-a95e-243aa4f1bd5d") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 109L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4781), new Guid("7a511ba5-3a77-4cf2-9fda-ce42d4924ade") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 110L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4784), new Guid("431de418-3c0d-4cd6-bad7-6d35ff923c1d") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 111L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4789), new Guid("6a478840-dbfb-42f8-a5d8-c0ae43829316") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 112L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4792), new Guid("c367528c-8c43-4cad-b204-ccfb85fbd698") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 113L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4795), new Guid("7eb0147b-e0c1-4530-9e32-84cc2902f223") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 114L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4798), new Guid("87863753-f0c8-4eb6-8cd7-d89c95b30a2b") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 115L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4801), new Guid("2c788d57-1c3b-4771-8e98-5a1915c84426") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 116L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4806), new Guid("cb9810cd-ad80-4b35-b1f7-bd8fbe571507") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 117L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4809), new Guid("8b1da065-6c0d-4266-87ea-025f1a2b63d5") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 118L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4818), new Guid("d7a1bda8-4c6a-40ed-9b85-480dd71e2f11") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 119L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4820), new Guid("958afa5e-daa0-4a94-ae6a-f8ee3f5d9509") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 120L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4823), new Guid("cc8e07ad-e81d-4756-98d2-c545f7311a05") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 121L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4826), new Guid("c8de65bb-343f-4d14-9962-b63d74158d47") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 122L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4829), new Guid("5fef395d-ace6-43dc-bd47-63a5b09d151d") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 123L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4832), new Guid("8d5bffb0-f869-4b98-b328-5ab01d629c82") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 124L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4838), new Guid("fadfc0eb-53fb-4d70-88fa-26ac0a5abca9") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 125L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4841), new Guid("e21bc8cd-9c2f-4cfb-a4ca-741f170b4b68") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 126L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4844), new Guid("09d1d98e-f9dc-47c7-8d28-4752f10fe3f5") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 127L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4847), new Guid("4e69e2ce-e1d9-4bcf-9c1b-f14939a1874a") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 128L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4850), new Guid("71609e2a-a3b5-4d29-a791-23650f884e11") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 129L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4853), new Guid("aaed8a43-6300-4339-89a5-9eb9b0bd507f") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 130L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4856), new Guid("22016a7c-4d88-43d6-8562-38965f5a4097") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 131L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4859), new Guid("2b1033d1-b422-466c-9c28-88231c9be583") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 132L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4864), new Guid("bf254c6e-982b-404d-8468-263a0e702573") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 133L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4868), new Guid("c23eccbf-f12f-4136-8f58-ea6885dd232a") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 134L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4872), new Guid("dcd9ea15-e825-4c66-a6e8-34c89bb058bf") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 135L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4876), new Guid("43bba1a7-94f4-4bb2-843d-d6d130964c8e") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 136L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4879), new Guid("505369ce-39eb-477e-833c-043ac409a9fe") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 137L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4882), new Guid("1a551efe-5761-47de-aad0-12a228194816") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 138L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4885), new Guid("c90d0bf7-8fe1-4bfa-99e9-9626693615a7") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 139L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4895), new Guid("2ef73a5d-8ef4-4e77-9e3e-2d3b4cbdaff8") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 140L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4900), new Guid("2f5f695d-be1d-4b8e-ae08-a300404ac12a") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 141L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4904), new Guid("efd6100e-785f-4ffb-a0a1-5bb321b44e6e") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 142L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4906), new Guid("e35f2063-d76d-4590-8451-43c1c2dd4ecb") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 143L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4909), new Guid("111362b6-fc16-4468-8f19-3c8bddb9c0c3") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 144L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4912), new Guid("78449112-8392-46dc-90dc-f1654bd87ced") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 145L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4915), new Guid("1edd5e3c-fba8-4e9f-9d6a-ac92c8d75c0d") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 146L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4920), new Guid("0fa94f8f-1a17-4c2a-bc7e-f3b53c6d5645") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 147L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4923), new Guid("ec7c2674-8901-4762-be57-6822c162b378") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 148L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4929), new Guid("cb6adf16-5a2c-4ac6-9482-7e35eae7f992") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 149L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4933), new Guid("88897696-d35e-4de5-b3d9-7a5cc70cca9a") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 150L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4937), new Guid("2b3fa4c5-c08b-4cb0-8a1f-4219382ebf7a") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 151L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4940), new Guid("23db0399-2e68-416e-8d9f-a97222f986ae") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 152L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4944), new Guid("61b1aa31-31d3-4c0d-b081-385ac34ee052") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 153L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4947), new Guid("932205de-4ad4-4326-8872-2ed96273efb5") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 154L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4951), new Guid("cfdc011e-9651-42e6-b8f0-e5cc2c3328ba") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 155L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4957), new Guid("599c6add-ec87-4268-b065-06d936227eb7") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 156L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4963), new Guid("5c645bf9-3a65-49f7-b5a6-9e7b61fe8879") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 157L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4967), new Guid("ddb59993-7a0c-4157-bee7-55558f48041e") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 158L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4970), new Guid("c5573e29-8540-430d-8865-ac7c24303cda") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 159L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4974), new Guid("d520c9e6-c63b-468e-a76c-6d4090721309") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 160L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4985), new Guid("1d3781e4-8e08-4de7-a62f-9f121ec117c2") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 161L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4988), new Guid("25b816b2-8582-4119-8b83-394e51790093") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 162L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4991), new Guid("414b44a3-bffb-4a10-87b7-cbdbcc7b34dc") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 163L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4995), new Guid("a4bdf286-1c38-4433-97bc-31aee4e6f157") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 164L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5002), new Guid("4a7ce1c7-dad7-44a4-b44a-9fd5be1b55b6") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 165L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5006), new Guid("4f667cdb-7a9d-4c93-8232-82190a75dbb5") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 166L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5009), new Guid("6b3b43e7-5e97-4e8d-836e-280a3195b694") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 167L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5016), new Guid("c6607c3b-3bae-4939-947c-6ec984ffe728") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 168L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5018), new Guid("cecb3500-1e1c-4159-859e-c113661e8939") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 169L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5022), new Guid("0e7d09c9-6c1c-4a35-b04d-503c84dddae3") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 170L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5025), new Guid("8f02a9c7-64b6-4c05-98b5-bb293d250900") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 171L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5028), new Guid("daf9dfb4-2feb-4bc6-b9ee-186177d4acc4") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 172L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5033), new Guid("fa333147-c349-450c-b752-152ad1c73d77") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 173L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5037), new Guid("2244f616-7158-4f24-9aef-4fc8c3dcda96") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 174L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5040), new Guid("c2eb173f-710f-468f-82fe-345ef7f02621") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 175L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5042), new Guid("d2b442aa-52dd-4a9c-8255-8e74ed45c429") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 176L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5045), new Guid("7a4cde2a-bae9-4a73-89e2-fa484839af4d") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 177L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5048), new Guid("c107d78f-cdd1-4c66-a895-caffa3d0439e") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 178L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5051), new Guid("ba1f5285-3c92-4b95-83ed-dde18f29bbe8") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 179L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5054), new Guid("eb2a48c2-afc4-4642-9051-63749aa1aa28") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 180L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5059), new Guid("7b34f41b-eeeb-43e7-b082-00734f5c113d") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 181L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5070), new Guid("3b121632-2530-4a64-a42d-bec5e7244a57") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 182L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5073), new Guid("6216edaa-e29f-42ac-b20a-e56054d3f192") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 183L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5077), new Guid("ffba8f14-c593-4cc9-bffc-5ec14425260b") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 184L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5080), new Guid("a0a05d50-7ad4-455a-b703-a801199690ed") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 185L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5084), new Guid("7e4ff666-73eb-47d5-97c4-1d669da0871c") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 186L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5089), new Guid("6d17fb09-5f32-4c55-a552-3f5dc907bcc7") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 187L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5092), new Guid("222cdd17-ad14-4e33-ab4d-5ff7dc7b80c0") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 188L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5097), new Guid("ecbca8d0-c92e-4d9a-af98-db191f7a19c5") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 189L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5101), new Guid("2ead306a-5dfa-4216-9f26-45e08d439d0e") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 190L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5104), new Guid("ae47e425-3b54-433e-8d5e-767ad2b5a521") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 191L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5108), new Guid("9edb773d-6bc1-4632-9710-cc4a6d3623e1") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 192L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5111), new Guid("20d92531-97fe-451f-979b-7c691d1202ed") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 193L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5114), new Guid("92d09308-e33c-46dd-976b-0723acb1b3a6") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 194L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5117), new Guid("0a7081a3-4c30-49eb-ae7a-59c73d7bca62") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 195L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5120), new Guid("77475fb2-71f3-4a71-8105-22148ee8e576") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 196L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5125), new Guid("f0390e9d-7a79-4dfe-8e01-7026f481d61a") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 197L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5128), new Guid("4e9cb227-ce85-4c42-b9e5-9f855c5465bb") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 198L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5131), new Guid("dd9e8e3b-6978-478a-8cf7-f59855f8103b") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 199L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5134), new Guid("65934439-0d22-42e2-85a8-e5e004ff831d") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 200L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5138), new Guid("727983dd-038b-4cb5-996b-2490d5080dab") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 201L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5141), new Guid("ca81316e-2a22-4fd7-8e10-aba63679f6f7") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 202L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5152), new Guid("07fa2e69-d342-426d-8ca3-c1d808d80e8b") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 203L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5155), new Guid("c622d586-b3b7-4117-bd3b-4b59740a0bd5") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 204L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5160), new Guid("79146856-c999-44f6-af98-b3401eb99552") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 205L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5164), new Guid("ba22b9e7-b605-4de3-bc54-65a5a5254bb8") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 206L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5167), new Guid("9909baad-e77f-46ce-8647-63973b0545a2") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 207L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5171), new Guid("bac49943-b1b7-4769-859d-7dba5a9ad26f") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 208L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5174), new Guid("ed716d8d-39dc-4cde-b39e-91d6cdf5ff68") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 209L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5177), new Guid("c56e4d3b-e24d-4450-8ad0-735ddc204009") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 210L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5180), new Guid("9061ae72-f556-441a-80f0-03b31d4d5af6") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 211L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5182), new Guid("3dfe2724-b136-4807-a81e-d823fdb923a1") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 212L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5188), new Guid("da7d7948-5f8f-4e18-9f83-20161caffc64") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 213L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5191), new Guid("cfe26a83-0885-4c51-ad58-6f47d2edc11a") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 214L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5195), new Guid("eecbd73f-f7cc-4791-8f7c-27aa85703299") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 215L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5198), new Guid("7c708c2f-5874-411a-a764-954a230e2675") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 216L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5201), new Guid("91d5ce3e-a3dc-431e-a150-8a5b2b963f0b") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 217L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5204), new Guid("e6ed7a69-dd8f-44ab-ba68-ead9974b58f0") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 218L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5206), new Guid("f29588ca-1001-4edc-b0ee-2c042fc2f551") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 219L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5210), new Guid("78234f14-3973-4733-b7d4-500d70a97401") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 220L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5215), new Guid("8f1da2cc-5c2d-48db-ad71-c0268d03a758") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 221L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5218), new Guid("b468905e-286e-48a2-869e-786f9d9193d9") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 222L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5227), new Guid("d6108a30-3070-4086-8b2f-86bf4a9b2e22") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 223L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5231), new Guid("10107424-6883-4a97-a4f5-409299b34412") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 224L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5234), new Guid("a9e27be0-fb38-4d8b-99a2-c082d7f7ed40") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 225L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5237), new Guid("1700f253-bf6b-4151-81f5-0016b9160621") });

            migrationBuilder.UpdateData(
                table: "DifficultyScale",
                keyColumn: "Id",
                keyValue: 226L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5240), new Guid("7b5cacfa-f355-4499-9783-a506a79c4f00") });

            migrationBuilder.UpdateData(
                table: "DifficultyScaleName",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 517, DateTimeKind.Utc).AddTicks(2986), new Guid("d8794ddd-a9c5-4167-a65c-002bf572af5a") });

            migrationBuilder.UpdateData(
                table: "DifficultyScaleName",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 517, DateTimeKind.Utc).AddTicks(3024), new Guid("d3f0afc7-4fb9-42c3-b7fb-e445d43852c8") });

            migrationBuilder.UpdateData(
                table: "DifficultyScaleName",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 517, DateTimeKind.Utc).AddTicks(3035), new Guid("7efa282b-87e7-4ddf-9064-93a113fecc19") });

            migrationBuilder.UpdateData(
                table: "DifficultyScaleName",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 517, DateTimeKind.Utc).AddTicks(3039), new Guid("69b3d486-083a-4a5f-ae22-ca1bd0f3bb53") });

            migrationBuilder.UpdateData(
                table: "DifficultyScaleName",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 517, DateTimeKind.Utc).AddTicks(3043), new Guid("315e15ee-2b8b-45f0-a43a-e19c945edb0b") });

            migrationBuilder.UpdateData(
                table: "DifficultyScaleName",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 517, DateTimeKind.Utc).AddTicks(3046), new Guid("f9714181-b01f-4224-b35b-6605b75a268d") });

            migrationBuilder.UpdateData(
                table: "DifficultyScaleName",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 517, DateTimeKind.Utc).AddTicks(3049), new Guid("d8fcd736-9b00-4620-83d5-6865719e2838") });

            migrationBuilder.UpdateData(
                table: "DifficultyScaleName",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 517, DateTimeKind.Utc).AddTicks(3054), new Guid("137827c9-7a2a-43c8-b878-d695e6950ebd") });

            migrationBuilder.UpdateData(
                table: "DifficultyScaleName",
                keyColumn: "Id",
                keyValue: 9L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 517, DateTimeKind.Utc).AddTicks(3057), new Guid("050a4239-70ab-466c-b168-b30a266eb1e3") });

            migrationBuilder.UpdateData(
                table: "DifficultyScaleName",
                keyColumn: "Id",
                keyValue: 10L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 517, DateTimeKind.Utc).AddTicks(3063), new Guid("77ca35c0-8700-4011-a26c-8321ad4d484e") });

            migrationBuilder.UpdateData(
                table: "DifficultyScaleName",
                keyColumn: "Id",
                keyValue: 11L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 517, DateTimeKind.Utc).AddTicks(3066), new Guid("96d8a8ee-3749-4a22-9b61-715f4d76aeb3") });

            migrationBuilder.UpdateData(
                table: "DifficultyScaleName",
                keyColumn: "Id",
                keyValue: 12L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 517, DateTimeKind.Utc).AddTicks(3069), new Guid("a342962e-40fa-41ab-8ff6-b57e969b51aa") });

            migrationBuilder.UpdateData(
                table: "DifficultyScaleName",
                keyColumn: "Id",
                keyValue: 13L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 517, DateTimeKind.Utc).AddTicks(3072), new Guid("9e97feeb-c86d-4cfb-a77f-3af94fc1a16c") });

            migrationBuilder.UpdateData(
                table: "DifficultyScaleName",
                keyColumn: "Id",
                keyValue: 14L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 517, DateTimeKind.Utc).AddTicks(3077), new Guid("5e58e5aa-e77e-406f-844d-fb2ba82097ef") });

            migrationBuilder.UpdateData(
                table: "DifficultyScaleName",
                keyColumn: "Id",
                keyValue: 15L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 517, DateTimeKind.Utc).AddTicks(3080), new Guid("e1c52a23-005f-4706-b6aa-cce44ae050e4") });

            migrationBuilder.UpdateData(
                table: "DifficultyScaleName",
                keyColumn: "Id",
                keyValue: 16L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 517, DateTimeKind.Utc).AddTicks(3084), new Guid("b0450fe5-1df7-4d9f-9408-ad72c35f7836") });

            migrationBuilder.UpdateData(
                table: "DifficultyScaleName",
                keyColumn: "Id",
                keyValue: 17L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 517, DateTimeKind.Utc).AddTicks(3088), new Guid("140debeb-be20-4066-afb1-9b95e8ac4beb") });

            migrationBuilder.UpdateData(
                table: "DifficultyScaleType",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 518, DateTimeKind.Utc).AddTicks(2718), new Guid("dbbe06f1-fb76-4798-ac4c-2478a4e3b8ae") });

            migrationBuilder.UpdateData(
                table: "DifficultyScaleType",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 518, DateTimeKind.Utc).AddTicks(2740), new Guid("1d359729-f5a3-4cd6-bc32-e1fb6762b855") });

            migrationBuilder.UpdateData(
                table: "DifficultyScaleType",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 518, DateTimeKind.Utc).AddTicks(2746), new Guid("9b9412bf-6675-44b6-a028-bb0cd9c9b80b") });

            migrationBuilder.UpdateData(
                table: "DifficultyScaleType",
                keyColumn: "Id",
                keyValue: 4L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 518, DateTimeKind.Utc).AddTicks(2749), new Guid("0a23a5e5-7e23-4f31-a4cd-e70c07df44de") });

            migrationBuilder.UpdateData(
                table: "DifficultyScaleType",
                keyColumn: "Id",
                keyValue: 5L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 518, DateTimeKind.Utc).AddTicks(2753), new Guid("9d90feac-b87a-492d-9215-98878bfd2c8b") });

            migrationBuilder.UpdateData(
                table: "DifficultyScaleType",
                keyColumn: "Id",
                keyValue: 6L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 518, DateTimeKind.Utc).AddTicks(2757), new Guid("0696b264-4ac2-4bdd-a88d-b1fcc5417d85") });

            migrationBuilder.UpdateData(
                table: "DifficultyScaleType",
                keyColumn: "Id",
                keyValue: 7L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 518, DateTimeKind.Utc).AddTicks(2760), new Guid("83d166f0-da30-499d-ae07-3289b81a9868") });

            migrationBuilder.UpdateData(
                table: "DifficultyScaleType",
                keyColumn: "Id",
                keyValue: 8L,
                columns: new[] { "CreatedAt", "Uid" },
                values: new object[] { new DateTime(2026, 4, 2, 20, 1, 41, 518, DateTimeKind.Utc).AddTicks(2764), new Guid("fe0937c8-ef97-4aaf-a36e-bda5a5a7d95d") });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlogProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class DALExtensions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("2bd5469c-b027-4ae0-9bc9-5c317cd4414d"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("6dceb422-7dcc-4bd3-884e-8e6b5749da76"));

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "Title", "UpdatedBy", "UpdatedDate", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("77cfb61d-8c51-4e63-a1bb-b5fb89e4a8d5"), new Guid("301de9f5-8a72-4738-863e-4104123917f7"), "Lorem ipsum dolor sit amet mxalknclcnaljcnlscnlxclnaslcnaslcnc sql server", "Admin Hasan", new DateTime(2024, 5, 11, 15, 55, 37, 264, DateTimeKind.Local).AddTicks(337), null, null, new Guid("efedf71d-350e-4869-bfaa-6d0e24f1014d"), false, "Sql Server Makale", null, null, 25 },
                    { new Guid("e52d874f-c712-427e-9225-31441cd75d31"), new Guid("933b9554-cc1b-4715-97c9-9a1a85db9bc5"), "Lorem ipsum dolor sit amet", "Admin Hasan", new DateTime(2024, 5, 11, 15, 55, 37, 264, DateTimeKind.Local).AddTicks(324), null, null, new Guid("f91b9913-a95d-4c7c-a204-e1d32a151c72"), false, "C# Makale", null, null, 13 }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("301de9f5-8a72-4738-863e-4104123917f7"),
                column: "CreatedDate",
                value: new DateTime(2024, 5, 11, 15, 55, 37, 264, DateTimeKind.Local).AddTicks(1246));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("933b9554-cc1b-4715-97c9-9a1a85db9bc5"),
                column: "CreatedDate",
                value: new DateTime(2024, 5, 11, 15, 55, 37, 264, DateTimeKind.Local).AddTicks(1243));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("efedf71d-350e-4869-bfaa-6d0e24f1014d"),
                column: "CreatedDate",
                value: new DateTime(2024, 5, 11, 15, 55, 37, 264, DateTimeKind.Local).AddTicks(1822));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("f91b9913-a95d-4c7c-a204-e1d32a151c72"),
                column: "CreatedDate",
                value: new DateTime(2024, 5, 11, 15, 55, 37, 264, DateTimeKind.Local).AddTicks(1819));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("77cfb61d-8c51-4e63-a1bb-b5fb89e4a8d5"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("e52d874f-c712-427e-9225-31441cd75d31"));

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "Title", "UpdatedBy", "UpdatedDate", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("2bd5469c-b027-4ae0-9bc9-5c317cd4414d"), new Guid("301de9f5-8a72-4738-863e-4104123917f7"), "Lorem ipsum dolor sit amet mxalknclcnaljcnlscnlxclnaslcnaslcnc sql server", "Admin Hasan", new DateTime(2024, 5, 10, 0, 37, 46, 86, DateTimeKind.Local).AddTicks(2964), null, null, new Guid("efedf71d-350e-4869-bfaa-6d0e24f1014d"), false, "Sql Server Makale", null, null, 25 },
                    { new Guid("6dceb422-7dcc-4bd3-884e-8e6b5749da76"), new Guid("933b9554-cc1b-4715-97c9-9a1a85db9bc5"), "Lorem ipsum dolor sit amet", "Admin Hasan", new DateTime(2024, 5, 10, 0, 37, 46, 86, DateTimeKind.Local).AddTicks(2949), null, null, new Guid("f91b9913-a95d-4c7c-a204-e1d32a151c72"), false, "C# Makale", null, null, 13 }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("301de9f5-8a72-4738-863e-4104123917f7"),
                column: "CreatedDate",
                value: new DateTime(2024, 5, 10, 0, 37, 46, 86, DateTimeKind.Local).AddTicks(3909));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("933b9554-cc1b-4715-97c9-9a1a85db9bc5"),
                column: "CreatedDate",
                value: new DateTime(2024, 5, 10, 0, 37, 46, 86, DateTimeKind.Local).AddTicks(3906));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("efedf71d-350e-4869-bfaa-6d0e24f1014d"),
                column: "CreatedDate",
                value: new DateTime(2024, 5, 10, 0, 37, 46, 86, DateTimeKind.Local).AddTicks(5910));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("f91b9913-a95d-4c7c-a204-e1d32a151c72"),
                column: "CreatedDate",
                value: new DateTime(2024, 5, 10, 0, 37, 46, 86, DateTimeKind.Local).AddTicks(5906));
        }
    }
}

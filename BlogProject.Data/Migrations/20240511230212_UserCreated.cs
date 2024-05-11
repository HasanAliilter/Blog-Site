using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BlogProject.Data.Migrations
{
    /// <inheritdoc />
    public partial class UserCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("77cfb61d-8c51-4e63-a1bb-b5fb89e4a8d5"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("e52d874f-c712-427e-9225-31441cd75d31"));

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Articles",
                columns: new[] { "Id", "CategoryId", "Content", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "ImageId", "IsDeleted", "Title", "UpdatedBy", "UpdatedDate", "ViewCount" },
                values: new object[,]
                {
                    { new Guid("43c5fa2c-e637-4175-85b8-8f68bc86ae43"), new Guid("933b9554-cc1b-4715-97c9-9a1a85db9bc5"), "Lorem ipsum dolor sit amet", "Admin Hasan", new DateTime(2024, 5, 12, 2, 2, 12, 264, DateTimeKind.Local).AddTicks(1910), null, null, new Guid("f91b9913-a95d-4c7c-a204-e1d32a151c72"), false, "C# Makale", null, null, 13 },
                    { new Guid("d0d344aa-d5df-43c5-8500-95b49fcfa195"), new Guid("301de9f5-8a72-4738-863e-4104123917f7"), "Lorem ipsum dolor sit amet mxalknclcnaljcnlscnlxclnaslcnaslcnc sql server", "Admin Hasan", new DateTime(2024, 5, 12, 2, 2, 12, 264, DateTimeKind.Local).AddTicks(1916), null, null, new Guid("efedf71d-350e-4869-bfaa-6d0e24f1014d"), false, "Sql Server Makale", null, null, 25 }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("0efe8ca4-1721-488a-ab5c-180a3dc1185a"), "c64624b5-53e1-43eb-bb77-6f85ae2142f8", "Superadmin", "SUPERADMIN" },
                    { new Guid("602604cf-571d-492d-88cd-b9315d3c9611"), "f604b60a-64b0-4b72-a5b1-44931d9a2c5e", "User", "USER" },
                    { new Guid("eb145eca-c68e-4d60-8372-1a04792ff810"), "a025f567-e265-48ed-83e2-28c79e02193a", "Admin", "ADMIN" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "FirstName", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("46e64aa1-ef33-4ade-84fd-e029a5464469"), 0, "a79009b9-c108-494f-ae70-87fe1760879b", "superadmin@gmail.com", true, "Hasan Ali", "Ilter", false, null, "SUPERADMIN@GMAİL.COM", "SUPERADMIN@GMAİL.COM", "AQAAAAIAAYagAAAAEFN0dxvDQOSzy3mpVIqo/sJX9PjubCOt/52XhNw2eliXK5kl9ANw8f8ZN8uLTLkIFA==", "+905331111111", true, "e9921b07-181a-44b1-85c6-5214376b7d99", false, "superadmin@gmail.com" },
                    { new Guid("b4dbcd88-b32f-4cc5-8ae3-046132c19f56"), 0, "91536820-a51b-4bc4-a900-c32618095efb", "admin@gmail.com", false, "Atahan", "Tutar", false, null, "ADMIN@GMAİL.COM", "ADMIN@GMAİL.COM", "AQAAAAIAAYagAAAAECwMLLQQDqB8KyqfwxdUyRDjt95WiEmWODydXAuQR+eh0Zb+w1b/0Bd3fhz/JMPzEA==", "+905331111112", false, "0b54ad8b-c569-4f61-b5ff-905a491286dc", false, "admin@gmail.com" }
                });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("301de9f5-8a72-4738-863e-4104123917f7"),
                column: "CreatedDate",
                value: new DateTime(2024, 5, 12, 2, 2, 12, 264, DateTimeKind.Local).AddTicks(2888));

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("933b9554-cc1b-4715-97c9-9a1a85db9bc5"),
                column: "CreatedDate",
                value: new DateTime(2024, 5, 12, 2, 2, 12, 264, DateTimeKind.Local).AddTicks(2885));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("efedf71d-350e-4869-bfaa-6d0e24f1014d"),
                column: "CreatedDate",
                value: new DateTime(2024, 5, 12, 2, 2, 12, 264, DateTimeKind.Local).AddTicks(3462));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: new Guid("f91b9913-a95d-4c7c-a204-e1d32a151c72"),
                column: "CreatedDate",
                value: new DateTime(2024, 5, 12, 2, 2, 12, 264, DateTimeKind.Local).AddTicks(3458));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { new Guid("0efe8ca4-1721-488a-ab5c-180a3dc1185a"), new Guid("46e64aa1-ef33-4ade-84fd-e029a5464469") },
                    { new Guid("eb145eca-c68e-4d60-8372-1a04792ff810"), new Guid("b4dbcd88-b32f-4cc5-8ae3-046132c19f56") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("43c5fa2c-e637-4175-85b8-8f68bc86ae43"));

            migrationBuilder.DeleteData(
                table: "Articles",
                keyColumn: "Id",
                keyValue: new Guid("d0d344aa-d5df-43c5-8500-95b49fcfa195"));

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
    }
}

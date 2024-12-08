using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _0412 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("d244fdc8-ce03-4f26-8840-be0a49102226"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("887c616c-d198-4d1d-a3ba-a629e8beffce"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("9646eecb-64ea-4a54-82d6-f0d744ca2090"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "huseyin1@gmail.com", new byte[] { 76, 231, 96, 69, 7, 52, 104, 160, 133, 97, 208, 235, 224, 206, 141, 161, 122, 165, 3, 163, 74, 97, 130, 40, 65, 56, 217, 16, 119, 127, 37, 53, 231, 157, 79, 198, 219, 73, 153, 160, 132, 109, 100, 130, 126, 65, 203, 25, 73, 109, 161, 153, 246, 234, 77, 95, 187, 160, 103, 35, 105, 166, 165, 5 }, new byte[] { 8, 120, 254, 233, 59, 33, 234, 157, 166, 129, 89, 162, 172, 123, 178, 240, 156, 167, 22, 238, 184, 129, 101, 11, 55, 221, 176, 63, 220, 207, 141, 252, 214, 53, 190, 168, 130, 81, 50, 88, 171, 40, 140, 163, 2, 137, 116, 132, 246, 143, 65, 89, 213, 177, 61, 42, 144, 64, 225, 53, 234, 107, 203, 36, 184, 18, 40, 214, 250, 59, 161, 15, 23, 235, 58, 16, 23, 180, 181, 101, 127, 26, 179, 65, 35, 49, 194, 186, 167, 211, 37, 120, 65, 9, 164, 122, 185, 141, 38, 141, 137, 83, 75, 149, 56, 60, 198, 77, 151, 201, 204, 180, 155, 18, 47, 126, 48, 86, 231, 231, 87, 6, 136, 127, 77, 100, 135, 32 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("44d9fead-e92a-4c2d-ac21-fc06b3ed4f7b"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("9646eecb-64ea-4a54-82d6-f0d744ca2090") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("44d9fead-e92a-4c2d-ac21-fc06b3ed4f7b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9646eecb-64ea-4a54-82d6-f0d744ca2090"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("887c616c-d198-4d1d-a3ba-a629e8beffce"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "huseyin1@gmail.com", new byte[] { 91, 247, 229, 233, 218, 218, 69, 17, 228, 15, 157, 205, 21, 85, 145, 52, 9, 143, 34, 0, 70, 177, 180, 119, 122, 52, 198, 13, 242, 204, 229, 20, 194, 106, 197, 37, 35, 218, 62, 46, 208, 187, 28, 141, 22, 131, 228, 208, 9, 130, 199, 18, 75, 190, 63, 26, 39, 200, 0, 27, 85, 197, 191, 59 }, new byte[] { 135, 134, 166, 196, 104, 11, 199, 102, 36, 5, 102, 36, 106, 98, 242, 36, 12, 178, 90, 49, 148, 232, 227, 104, 208, 215, 34, 114, 248, 189, 148, 182, 32, 236, 54, 94, 2, 2, 44, 255, 253, 18, 81, 170, 24, 83, 173, 111, 89, 11, 90, 35, 145, 216, 98, 127, 255, 165, 54, 15, 180, 226, 79, 26, 246, 143, 101, 23, 233, 85, 206, 86, 138, 189, 239, 5, 70, 248, 129, 212, 211, 205, 111, 43, 232, 146, 46, 136, 238, 175, 90, 224, 90, 14, 72, 52, 46, 189, 2, 17, 7, 127, 163, 167, 108, 160, 115, 170, 106, 216, 228, 81, 69, 125, 246, 237, 29, 23, 23, 149, 9, 192, 161, 184, 223, 4, 18, 128 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("d244fdc8-ce03-4f26-8840-be0a49102226"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("887c616c-d198-4d1d-a3ba-a629e8beffce") });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _2511 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("8a318f01-7e08-4be6-801e-02c53e1d7092"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("0af72357-7402-4480-a612-6577237a323e"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("d883eaae-1906-4c4b-b3d6-37aaf057d7b6"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "huseyin1@gmail.com", new byte[] { 4, 115, 121, 14, 35, 23, 207, 86, 162, 150, 42, 221, 127, 215, 225, 58, 236, 183, 121, 57, 240, 70, 18, 65, 202, 124, 145, 48, 83, 107, 136, 117, 65, 250, 68, 127, 11, 212, 178, 255, 117, 204, 189, 7, 230, 211, 254, 107, 161, 211, 6, 203, 68, 163, 16, 205, 7, 194, 189, 46, 195, 71, 3, 163 }, new byte[] { 96, 232, 219, 244, 218, 2, 14, 53, 86, 64, 226, 209, 66, 37, 140, 212, 224, 251, 7, 186, 3, 160, 9, 87, 116, 249, 79, 40, 158, 101, 161, 196, 40, 2, 92, 134, 59, 176, 84, 112, 40, 72, 119, 208, 125, 162, 118, 248, 193, 80, 61, 200, 208, 82, 197, 187, 67, 7, 48, 139, 173, 20, 104, 4, 116, 120, 109, 200, 31, 94, 28, 144, 42, 114, 8, 216, 240, 35, 35, 9, 51, 33, 157, 182, 175, 101, 125, 241, 42, 130, 178, 190, 5, 52, 149, 98, 218, 96, 175, 29, 133, 87, 123, 69, 147, 250, 36, 39, 8, 60, 221, 145, 224, 130, 39, 158, 155, 12, 214, 25, 143, 12, 141, 57, 70, 209, 161, 250 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("46b7d524-3f75-4132-a2a6-330630c7fb6d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("d883eaae-1906-4c4b-b3d6-37aaf057d7b6") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("46b7d524-3f75-4132-a2a6-330630c7fb6d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d883eaae-1906-4c4b-b3d6-37aaf057d7b6"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("0af72357-7402-4480-a612-6577237a323e"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "huseyin1@gmail.com", new byte[] { 193, 65, 121, 150, 60, 24, 71, 2, 132, 96, 57, 212, 18, 19, 144, 71, 115, 207, 245, 42, 239, 95, 91, 29, 121, 193, 170, 177, 0, 88, 102, 1, 155, 202, 248, 28, 48, 198, 55, 209, 207, 236, 54, 188, 49, 45, 41, 50, 76, 213, 2, 85, 154, 174, 20, 187, 11, 83, 27, 124, 36, 55, 183, 85 }, new byte[] { 116, 167, 202, 89, 227, 130, 223, 135, 246, 23, 100, 36, 1, 19, 247, 158, 234, 184, 156, 84, 62, 108, 114, 20, 130, 246, 44, 29, 77, 200, 163, 54, 206, 178, 132, 79, 159, 156, 75, 236, 74, 173, 29, 65, 148, 42, 52, 35, 243, 177, 111, 220, 113, 29, 20, 116, 83, 126, 86, 198, 185, 237, 123, 143, 251, 131, 125, 105, 119, 135, 146, 101, 212, 69, 19, 221, 248, 69, 214, 94, 17, 93, 39, 4, 31, 131, 208, 59, 18, 191, 135, 84, 0, 232, 187, 52, 92, 15, 161, 223, 148, 137, 20, 215, 71, 140, 185, 32, 237, 165, 238, 237, 230, 36, 19, 188, 167, 63, 52, 212, 117, 26, 92, 147, 17, 150, 85, 184 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("8a318f01-7e08-4be6-801e-02c53e1d7092"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("0af72357-7402-4480-a612-6577237a323e") });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _2811 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { new Guid("695e7055-1551-4996-a775-294b2dc437b2"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "huseyin1@gmail.com", new byte[] { 186, 231, 229, 150, 248, 240, 162, 222, 228, 29, 109, 0, 211, 95, 30, 118, 195, 226, 18, 208, 99, 78, 12, 37, 170, 237, 87, 3, 68, 175, 117, 190, 247, 106, 91, 188, 83, 79, 202, 212, 213, 18, 68, 57, 38, 105, 241, 56, 69, 145, 135, 6, 140, 234, 86, 33, 146, 246, 231, 239, 220, 127, 113, 190 }, new byte[] { 82, 14, 12, 4, 72, 142, 238, 27, 127, 233, 137, 172, 3, 60, 1, 141, 30, 209, 199, 31, 146, 97, 171, 11, 82, 3, 117, 65, 74, 152, 11, 138, 211, 246, 190, 20, 21, 210, 126, 234, 94, 54, 55, 91, 117, 184, 150, 18, 230, 144, 20, 188, 67, 115, 223, 181, 221, 156, 156, 188, 10, 31, 221, 22, 169, 112, 225, 33, 34, 243, 105, 190, 54, 114, 217, 239, 33, 153, 212, 154, 190, 230, 114, 205, 209, 170, 243, 26, 76, 185, 243, 11, 48, 211, 241, 173, 156, 100, 192, 34, 25, 143, 77, 242, 19, 199, 110, 96, 118, 149, 36, 174, 146, 112, 95, 12, 165, 141, 202, 19, 134, 165, 207, 25, 200, 115, 179, 168 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("62ab2352-6937-4005-bdeb-fa814158e77c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("695e7055-1551-4996-a775-294b2dc437b2") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("62ab2352-6937-4005-bdeb-fa814158e77c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("695e7055-1551-4996-a775-294b2dc437b2"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("d883eaae-1906-4c4b-b3d6-37aaf057d7b6"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "huseyin1@gmail.com", new byte[] { 4, 115, 121, 14, 35, 23, 207, 86, 162, 150, 42, 221, 127, 215, 225, 58, 236, 183, 121, 57, 240, 70, 18, 65, 202, 124, 145, 48, 83, 107, 136, 117, 65, 250, 68, 127, 11, 212, 178, 255, 117, 204, 189, 7, 230, 211, 254, 107, 161, 211, 6, 203, 68, 163, 16, 205, 7, 194, 189, 46, 195, 71, 3, 163 }, new byte[] { 96, 232, 219, 244, 218, 2, 14, 53, 86, 64, 226, 209, 66, 37, 140, 212, 224, 251, 7, 186, 3, 160, 9, 87, 116, 249, 79, 40, 158, 101, 161, 196, 40, 2, 92, 134, 59, 176, 84, 112, 40, 72, 119, 208, 125, 162, 118, 248, 193, 80, 61, 200, 208, 82, 197, 187, 67, 7, 48, 139, 173, 20, 104, 4, 116, 120, 109, 200, 31, 94, 28, 144, 42, 114, 8, 216, 240, 35, 35, 9, 51, 33, 157, 182, 175, 101, 125, 241, 42, 130, 178, 190, 5, 52, 149, 98, 218, 96, 175, 29, 133, 87, 123, 69, 147, 250, 36, 39, 8, 60, 221, 145, 224, 130, 39, 158, 155, 12, 214, 25, 143, 12, 141, 57, 70, 209, 161, 250 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("46b7d524-3f75-4132-a2a6-330630c7fb6d"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("d883eaae-1906-4c4b-b3d6-37aaf057d7b6") });
        }
    }
}

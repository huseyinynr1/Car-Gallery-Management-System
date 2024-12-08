using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _212 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("f0a8fd7d-9c82-4586-a560-20c94bef3d47"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a1800ec9-4203-4225-aeb6-1a00c33bd709"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("887c616c-d198-4d1d-a3ba-a629e8beffce"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "huseyin1@gmail.com", new byte[] { 91, 247, 229, 233, 218, 218, 69, 17, 228, 15, 157, 205, 21, 85, 145, 52, 9, 143, 34, 0, 70, 177, 180, 119, 122, 52, 198, 13, 242, 204, 229, 20, 194, 106, 197, 37, 35, 218, 62, 46, 208, 187, 28, 141, 22, 131, 228, 208, 9, 130, 199, 18, 75, 190, 63, 26, 39, 200, 0, 27, 85, 197, 191, 59 }, new byte[] { 135, 134, 166, 196, 104, 11, 199, 102, 36, 5, 102, 36, 106, 98, 242, 36, 12, 178, 90, 49, 148, 232, 227, 104, 208, 215, 34, 114, 248, 189, 148, 182, 32, 236, 54, 94, 2, 2, 44, 255, 253, 18, 81, 170, 24, 83, 173, 111, 89, 11, 90, 35, 145, 216, 98, 127, 255, 165, 54, 15, 180, 226, 79, 26, 246, 143, 101, 23, 233, 85, 206, 86, 138, 189, 239, 5, 70, 248, 129, 212, 211, 205, 111, 43, 232, 146, 46, 136, 238, 175, 90, 224, 90, 14, 72, 52, 46, 189, 2, 17, 7, 127, 163, 167, 108, 160, 115, 170, 106, 216, 228, 81, 69, 125, 246, 237, 29, 23, 23, 149, 9, 192, 161, 184, 223, 4, 18, 128 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("d244fdc8-ce03-4f26-8840-be0a49102226"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("887c616c-d198-4d1d-a3ba-a629e8beffce") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { new Guid("a1800ec9-4203-4225-aeb6-1a00c33bd709"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "huseyin1@gmail.com", new byte[] { 62, 230, 217, 49, 24, 105, 67, 140, 33, 78, 224, 154, 190, 75, 221, 207, 179, 63, 124, 73, 236, 92, 106, 178, 16, 50, 97, 182, 45, 114, 131, 98, 108, 125, 117, 120, 149, 35, 187, 145, 56, 118, 116, 127, 71, 219, 224, 81, 127, 221, 33, 8, 150, 61, 254, 97, 54, 34, 113, 185, 114, 147, 183, 158 }, new byte[] { 111, 199, 22, 196, 41, 217, 214, 58, 85, 177, 84, 69, 53, 253, 76, 114, 249, 136, 84, 70, 9, 163, 68, 211, 205, 184, 219, 44, 72, 244, 129, 52, 154, 51, 255, 229, 183, 61, 21, 156, 12, 136, 160, 176, 97, 155, 102, 104, 95, 104, 139, 6, 244, 219, 235, 11, 159, 235, 196, 76, 140, 5, 13, 194, 255, 209, 219, 29, 0, 25, 116, 160, 205, 209, 187, 231, 45, 1, 234, 175, 235, 255, 75, 215, 50, 195, 239, 223, 169, 188, 54, 150, 22, 199, 96, 70, 157, 214, 183, 42, 185, 107, 254, 185, 244, 215, 252, 222, 142, 130, 255, 160, 205, 209, 211, 53, 11, 172, 241, 138, 221, 132, 79, 23, 219, 71, 171, 91 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("f0a8fd7d-9c82-4586-a560-20c94bef3d47"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("a1800ec9-4203-4225-aeb6-1a00c33bd709") });
        }
    }
}

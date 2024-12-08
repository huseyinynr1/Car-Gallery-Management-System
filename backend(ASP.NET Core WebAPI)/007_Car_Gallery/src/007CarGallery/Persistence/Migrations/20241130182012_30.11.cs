using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _3011 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { new Guid("a1800ec9-4203-4225-aeb6-1a00c33bd709"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "huseyin1@gmail.com", new byte[] { 62, 230, 217, 49, 24, 105, 67, 140, 33, 78, 224, 154, 190, 75, 221, 207, 179, 63, 124, 73, 236, 92, 106, 178, 16, 50, 97, 182, 45, 114, 131, 98, 108, 125, 117, 120, 149, 35, 187, 145, 56, 118, 116, 127, 71, 219, 224, 81, 127, 221, 33, 8, 150, 61, 254, 97, 54, 34, 113, 185, 114, 147, 183, 158 }, new byte[] { 111, 199, 22, 196, 41, 217, 214, 58, 85, 177, 84, 69, 53, 253, 76, 114, 249, 136, 84, 70, 9, 163, 68, 211, 205, 184, 219, 44, 72, 244, 129, 52, 154, 51, 255, 229, 183, 61, 21, 156, 12, 136, 160, 176, 97, 155, 102, 104, 95, 104, 139, 6, 244, 219, 235, 11, 159, 235, 196, 76, 140, 5, 13, 194, 255, 209, 219, 29, 0, 25, 116, 160, 205, 209, 187, 231, 45, 1, 234, 175, 235, 255, 75, 215, 50, 195, 239, 223, 169, 188, 54, 150, 22, 199, 96, 70, 157, 214, 183, 42, 185, 107, 254, 185, 244, 215, 252, 222, 142, 130, 255, 160, 205, 209, 211, 53, 11, 172, 241, 138, 221, 132, 79, 23, 219, 71, 171, 91 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("f0a8fd7d-9c82-4586-a560-20c94bef3d47"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("a1800ec9-4203-4225-aeb6-1a00c33bd709") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { new Guid("695e7055-1551-4996-a775-294b2dc437b2"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "huseyin1@gmail.com", new byte[] { 186, 231, 229, 150, 248, 240, 162, 222, 228, 29, 109, 0, 211, 95, 30, 118, 195, 226, 18, 208, 99, 78, 12, 37, 170, 237, 87, 3, 68, 175, 117, 190, 247, 106, 91, 188, 83, 79, 202, 212, 213, 18, 68, 57, 38, 105, 241, 56, 69, 145, 135, 6, 140, 234, 86, 33, 146, 246, 231, 239, 220, 127, 113, 190 }, new byte[] { 82, 14, 12, 4, 72, 142, 238, 27, 127, 233, 137, 172, 3, 60, 1, 141, 30, 209, 199, 31, 146, 97, 171, 11, 82, 3, 117, 65, 74, 152, 11, 138, 211, 246, 190, 20, 21, 210, 126, 234, 94, 54, 55, 91, 117, 184, 150, 18, 230, 144, 20, 188, 67, 115, 223, 181, 221, 156, 156, 188, 10, 31, 221, 22, 169, 112, 225, 33, 34, 243, 105, 190, 54, 114, 217, 239, 33, 153, 212, 154, 190, 230, 114, 205, 209, 170, 243, 26, 76, 185, 243, 11, 48, 211, 241, 173, 156, 100, 192, 34, 25, 143, 77, 242, 19, 199, 110, 96, 118, 149, 36, 174, 146, 112, 95, 12, 165, 141, 202, 19, 134, 165, 207, 25, 200, 115, 179, 168 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("62ab2352-6937-4005-bdeb-fa814158e77c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("695e7055-1551-4996-a775-294b2dc437b2") });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class _2311 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("511e28f3-13dd-4267-a0dc-0db789d5decc"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d66cc272-a578-4308-9cef-61bc21f96512"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("0af72357-7402-4480-a612-6577237a323e"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "huseyin1@gmail.com", new byte[] { 193, 65, 121, 150, 60, 24, 71, 2, 132, 96, 57, 212, 18, 19, 144, 71, 115, 207, 245, 42, 239, 95, 91, 29, 121, 193, 170, 177, 0, 88, 102, 1, 155, 202, 248, 28, 48, 198, 55, 209, 207, 236, 54, 188, 49, 45, 41, 50, 76, 213, 2, 85, 154, 174, 20, 187, 11, 83, 27, 124, 36, 55, 183, 85 }, new byte[] { 116, 167, 202, 89, 227, 130, 223, 135, 246, 23, 100, 36, 1, 19, 247, 158, 234, 184, 156, 84, 62, 108, 114, 20, 130, 246, 44, 29, 77, 200, 163, 54, 206, 178, 132, 79, 159, 156, 75, 236, 74, 173, 29, 65, 148, 42, 52, 35, 243, 177, 111, 220, 113, 29, 20, 116, 83, 126, 86, 198, 185, 237, 123, 143, 251, 131, 125, 105, 119, 135, 146, 101, 212, 69, 19, 221, 248, 69, 214, 94, 17, 93, 39, 4, 31, 131, 208, 59, 18, 191, 135, 84, 0, 232, 187, 52, 92, 15, 161, 223, 148, 137, 20, 215, 71, 140, 185, 32, 237, 165, 238, 237, 230, 36, 19, 188, 167, 63, 52, 212, 117, 26, 92, 147, 17, 150, 85, 184 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("8a318f01-7e08-4be6-801e-02c53e1d7092"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("0af72357-7402-4480-a612-6577237a323e") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                values: new object[] { new Guid("d66cc272-a578-4308-9cef-61bc21f96512"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "huseyin1@gmail.com", new byte[] { 226, 171, 16, 24, 123, 64, 105, 239, 158, 10, 80, 48, 159, 65, 254, 125, 139, 31, 63, 192, 39, 27, 137, 220, 19, 40, 71, 245, 154, 192, 64, 59, 115, 174, 117, 196, 201, 83, 64, 139, 89, 206, 79, 33, 50, 239, 164, 141, 32, 185, 198, 130, 130, 167, 22, 67, 21, 202, 134, 208, 169, 12, 234, 14 }, new byte[] { 76, 223, 168, 233, 183, 240, 246, 199, 128, 168, 236, 83, 145, 236, 159, 252, 209, 45, 10, 226, 194, 190, 250, 89, 81, 196, 255, 62, 169, 223, 134, 77, 168, 158, 75, 164, 119, 173, 190, 198, 217, 137, 46, 207, 52, 77, 237, 95, 42, 187, 26, 43, 237, 175, 232, 63, 37, 98, 200, 116, 178, 141, 213, 210, 105, 65, 224, 7, 123, 248, 22, 29, 113, 229, 4, 249, 181, 50, 74, 32, 195, 138, 173, 135, 22, 244, 87, 100, 193, 153, 28, 153, 3, 47, 155, 52, 177, 219, 37, 2, 216, 114, 245, 108, 122, 137, 150, 36, 122, 24, 94, 66, 109, 19, 221, 158, 212, 83, 245, 231, 236, 14, 242, 168, 118, 149, 84, 250 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("511e28f3-13dd-4267-a0dc-0db789d5decc"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("d66cc272-a578-4308-9cef-61bc21f96512") });
        }
    }
}

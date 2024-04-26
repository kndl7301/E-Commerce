using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("6034b5a7-00d0-4e69-b912-f91a44499db3"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("785f2925-4a31-463e-a283-db8d1c24b189"));

            migrationBuilder.DropColumn(
                name: "RatingId",
                table: "Ratings");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "ComplaintId",
                table: "Complaints");

            migrationBuilder.DropColumn(
                name: "CommentId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Addresses");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "Phone", "UpdatedDate" },
                values: new object[] { new Guid("28d60de7-513a-4662-8e38-05845febf64a"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", "Kendal", "YÜce", new byte[] { 244, 212, 37, 7, 49, 109, 187, 192, 86, 197, 247, 181, 147, 171, 212, 247, 163, 211, 176, 206, 224, 49, 43, 53, 158, 138, 54, 69, 230, 183, 216, 108, 107, 211, 184, 38, 25, 21, 248, 114, 210, 66, 42, 105, 72, 255, 126, 228, 73, 25, 38, 10, 230, 150, 49, 215, 49, 138, 53, 251, 5, 225, 125, 136 }, new byte[] { 50, 163, 197, 82, 62, 132, 42, 252, 145, 108, 48, 69, 44, 213, 1, 61, 225, 60, 252, 158, 143, 228, 148, 175, 215, 184, 57, 225, 242, 212, 223, 255, 75, 159, 199, 110, 242, 48, 124, 129, 128, 123, 43, 151, 206, 26, 188, 201, 48, 7, 69, 37, 22, 179, 121, 24, 253, 161, 119, 235, 201, 109, 116, 180, 75, 30, 216, 128, 151, 185, 217, 202, 156, 206, 23, 128, 49, 12, 123, 24, 121, 141, 124, 33, 150, 244, 186, 26, 220, 46, 47, 66, 110, 91, 43, 98, 188, 87, 171, 34, 211, 171, 1, 141, 83, 250, 47, 132, 116, 70, 14, 90, 169, 46, 31, 112, 103, 176, 161, 31, 245, 240, 31, 97, 194, 158, 142, 73 }, "05446939067", null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("929ce364-920b-4808-b8be-dd15508b3428"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("28d60de7-513a-4662-8e38-05845febf64a") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("929ce364-920b-4808-b8be-dd15508b3428"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("28d60de7-513a-4662-8e38-05845febf64a"));

            migrationBuilder.AddColumn<int>(
                name: "RatingId",
                table: "Ratings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PaymentId",
                table: "Payments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ComplaintId",
                table: "Complaints",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CommentId",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Addresses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "FirstName", "LastName", "PasswordHash", "PasswordSalt", "Phone", "UpdatedDate" },
                values: new object[] { new Guid("785f2925-4a31-463e-a283-db8d1c24b189"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", "Kendal", "YÜce", new byte[] { 157, 66, 200, 118, 28, 9, 51, 186, 186, 173, 234, 19, 167, 145, 138, 62, 215, 47, 101, 4, 146, 197, 160, 135, 211, 78, 168, 45, 62, 78, 85, 101, 235, 172, 175, 59, 216, 218, 99, 81, 243, 20, 123, 202, 3, 147, 36, 53, 122, 81, 198, 85, 231, 233, 7, 154, 194, 155, 237, 67, 238, 58, 167, 197 }, new byte[] { 114, 20, 154, 125, 183, 42, 215, 188, 9, 116, 180, 107, 172, 15, 193, 17, 12, 216, 148, 40, 75, 157, 52, 227, 94, 115, 175, 28, 58, 96, 36, 150, 232, 60, 218, 1, 21, 110, 180, 26, 166, 226, 62, 63, 216, 20, 33, 98, 184, 192, 157, 62, 64, 248, 146, 123, 84, 228, 217, 100, 49, 133, 137, 122, 201, 83, 50, 237, 26, 200, 159, 21, 144, 46, 119, 204, 173, 179, 83, 252, 100, 196, 234, 185, 67, 197, 78, 31, 36, 73, 91, 123, 159, 156, 213, 113, 80, 31, 160, 21, 46, 253, 105, 46, 244, 220, 149, 121, 55, 241, 254, 138, 81, 124, 91, 120, 171, 100, 59, 13, 10, 94, 149, 93, 233, 139, 180, 153 }, "05446939067", null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("6034b5a7-00d0-4e69-b912-f91a44499db3"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("785f2925-4a31-463e-a283-db8d1c24b189") });
        }
    }
}

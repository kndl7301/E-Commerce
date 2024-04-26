using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("dd44590d-d697-4ab5-ade9-eddd02b6779c"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("37f89b82-3256-42ee-a28e-2034a50c872c"));

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Payments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PaymentId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("2ee28d16-b9b1-4115-8332-1c89a38d8a5e"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 166, 176, 61, 245, 103, 115, 154, 67, 15, 91, 11, 69, 190, 221, 121, 127, 254, 161, 116, 59, 111, 22, 165, 173, 29, 177, 136, 105, 213, 83, 135, 159, 27, 195, 3, 250, 112, 101, 74, 42, 177, 72, 101, 219, 98, 173, 107, 114, 70, 217, 25, 114, 240, 212, 158, 191, 227, 21, 45, 101, 229, 199, 183, 46 }, new byte[] { 207, 4, 207, 146, 127, 26, 105, 55, 216, 141, 194, 198, 25, 233, 86, 81, 225, 233, 126, 85, 251, 30, 58, 65, 34, 111, 180, 115, 181, 253, 238, 154, 27, 243, 209, 210, 75, 196, 46, 201, 83, 19, 252, 240, 56, 187, 123, 232, 254, 92, 55, 189, 195, 252, 166, 27, 191, 169, 229, 45, 161, 51, 178, 150, 37, 181, 81, 182, 19, 116, 33, 102, 90, 39, 91, 176, 14, 95, 155, 112, 140, 138, 163, 112, 145, 120, 38, 188, 151, 236, 231, 85, 61, 203, 127, 250, 15, 245, 105, 120, 133, 133, 46, 107, 28, 49, 82, 69, 211, 111, 201, 159, 149, 116, 73, 35, 184, 217, 190, 235, 220, 75, 166, 26, 57, 164, 200, 196 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("1719674a-dae1-44af-858f-80699c455f7e"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("2ee28d16-b9b1-4115-8332-1c89a38d8a5e") });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PaymentId",
                table: "Orders",
                column: "PaymentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Payments_PaymentId",
                table: "Orders",
                column: "PaymentId",
                principalTable: "Payments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Payments_PaymentId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_PaymentId",
                table: "Orders");

            migrationBuilder.DeleteData(
                table: "UserOperationClaims",
                keyColumn: "Id",
                keyValue: new Guid("1719674a-dae1-44af-858f-80699c455f7e"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2ee28d16-b9b1-4115-8332-1c89a38d8a5e"));

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Payments");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "Orders");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AuthenticatorType", "CreatedDate", "DeletedDate", "Email", "PasswordHash", "PasswordSalt", "UpdatedDate" },
                values: new object[] { new Guid("37f89b82-3256-42ee-a28e-2034a50c872c"), 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "narch@kodlama.io", new byte[] { 131, 62, 198, 240, 23, 113, 220, 217, 117, 1, 69, 47, 8, 203, 76, 59, 37, 34, 2, 158, 107, 201, 34, 104, 144, 178, 234, 211, 170, 202, 98, 207, 242, 55, 229, 101, 26, 30, 148, 15, 244, 32, 112, 85, 37, 118, 209, 52, 2, 25, 21, 181, 137, 214, 236, 232, 113, 34, 242, 102, 63, 14, 109, 32 }, new byte[] { 153, 53, 196, 23, 51, 251, 146, 125, 14, 73, 36, 112, 228, 92, 152, 227, 160, 198, 114, 186, 249, 212, 181, 74, 37, 209, 133, 173, 211, 96, 163, 201, 251, 30, 0, 9, 124, 242, 36, 238, 251, 1, 23, 182, 227, 57, 41, 226, 224, 53, 119, 104, 15, 52, 105, 95, 134, 20, 64, 6, 132, 112, 91, 120, 223, 10, 193, 133, 230, 206, 161, 240, 53, 29, 235, 181, 78, 250, 164, 75, 186, 22, 125, 185, 163, 68, 204, 164, 198, 133, 183, 215, 22, 159, 170, 169, 29, 171, 135, 172, 15, 55, 247, 28, 154, 129, 30, 53, 202, 100, 215, 11, 239, 119, 60, 95, 1, 198, 168, 66, 86, 35, 217, 18, 24, 233, 181, 169 }, null });

            migrationBuilder.InsertData(
                table: "UserOperationClaims",
                columns: new[] { "Id", "CreatedDate", "DeletedDate", "OperationClaimId", "UpdatedDate", "UserId" },
                values: new object[] { new Guid("dd44590d-d697-4ab5-ade9-eddd02b6779c"), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, 1, null, new Guid("37f89b82-3256-42ee-a28e-2034a50c872c") });
        }
    }
}

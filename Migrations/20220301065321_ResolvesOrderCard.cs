using Microsoft.EntityFrameworkCore.Migrations;

namespace SportyApi.Migrations
{
    public partial class ResolvesOrderCard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OrderPaymentData_Zipcode",
                table: "Orders",
                newName: "CreditCard_Zipcode");

            migrationBuilder.RenameColumn(
                name: "OrderPaymentData_OrderAddress_Street",
                table: "Orders",
                newName: "Address_Street");

            migrationBuilder.RenameColumn(
                name: "OrderPaymentData_OrderAddress_City",
                table: "Orders",
                newName: "Address_City");

            migrationBuilder.RenameColumn(
                name: "OrderPaymentData_OrderAddress_BuildingNumber",
                table: "Orders",
                newName: "Address_BuildingNumber");

            migrationBuilder.RenameColumn(
                name: "OrderPaymentData_ExpirationDate",
                table: "Orders",
                newName: "CreditCard_ExpirationDate");

            migrationBuilder.RenameColumn(
                name: "OrderPaymentData_CreditCardNumber",
                table: "Orders",
                newName: "CreditCard_CreditCardNumber");

            migrationBuilder.AlterColumn<int>(
                name: "Address_BuildingNumber",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CreditCard_Zipcode",
                table: "Orders",
                newName: "OrderPaymentData_Zipcode");

            migrationBuilder.RenameColumn(
                name: "CreditCard_ExpirationDate",
                table: "Orders",
                newName: "OrderPaymentData_ExpirationDate");

            migrationBuilder.RenameColumn(
                name: "CreditCard_CreditCardNumber",
                table: "Orders",
                newName: "OrderPaymentData_CreditCardNumber");

            migrationBuilder.RenameColumn(
                name: "Address_Street",
                table: "Orders",
                newName: "OrderPaymentData_OrderAddress_Street");

            migrationBuilder.RenameColumn(
                name: "Address_City",
                table: "Orders",
                newName: "OrderPaymentData_OrderAddress_City");

            migrationBuilder.RenameColumn(
                name: "Address_BuildingNumber",
                table: "Orders",
                newName: "OrderPaymentData_OrderAddress_BuildingNumber");

            migrationBuilder.AlterColumn<int>(
                name: "OrderPaymentData_OrderAddress_BuildingNumber",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}

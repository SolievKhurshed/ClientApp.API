using Microsoft.EntityFrameworkCore.Migrations;

namespace ClientApp.API.Migrations
{
    public partial class UpdateClientContactsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_ClienContacts_ClientContactId",
                table: "Clients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClienContacts",
                table: "ClienContacts");

            migrationBuilder.RenameTable(
                name: "ClienContacts",
                newName: "ClientContacts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClientContacts",
                table: "ClientContacts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_ClientContacts_ClientContactId",
                table: "Clients",
                column: "ClientContactId",
                principalTable: "ClientContacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clients_ClientContacts_ClientContactId",
                table: "Clients");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClientContacts",
                table: "ClientContacts");

            migrationBuilder.RenameTable(
                name: "ClientContacts",
                newName: "ClienContacts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClienContacts",
                table: "ClienContacts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Clients_ClienContacts_ClientContactId",
                table: "Clients",
                column: "ClientContactId",
                principalTable: "ClienContacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace LmycWeb.Data.Migrations
{
    public partial class Add_Reservation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_AspNetUsers_CreateBy",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "CreateBy",
                table: "Reservations",
                newName: "CreatedBy");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_CreateBy",
                table: "Reservations",
                newName: "IX_Reservations_CreatedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_AspNetUsers_CreatedBy",
                table: "Reservations",
                column: "CreatedBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_AspNetUsers_CreatedBy",
                table: "Reservations");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "Reservations",
                newName: "CreateBy");

            migrationBuilder.RenameIndex(
                name: "IX_Reservations_CreatedBy",
                table: "Reservations",
                newName: "IX_Reservations_CreateBy");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_AspNetUsers_CreateBy",
                table: "Reservations",
                column: "CreateBy",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

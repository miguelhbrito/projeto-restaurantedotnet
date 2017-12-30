using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace projetoCEDROWEBAPI.Migrations
{
    public partial class SegundaMigrations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pratos_Restaurantes_RestauranteId",
                table: "Pratos");

            migrationBuilder.AlterColumn<int>(
                name: "RestauranteId",
                table: "Pratos",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pratos_Restaurantes_RestauranteId",
                table: "Pratos",
                column: "RestauranteId",
                principalTable: "Restaurantes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pratos_Restaurantes_RestauranteId",
                table: "Pratos");

            migrationBuilder.AlterColumn<int>(
                name: "RestauranteId",
                table: "Pratos",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Pratos_Restaurantes_RestauranteId",
                table: "Pratos",
                column: "RestauranteId",
                principalTable: "Restaurantes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

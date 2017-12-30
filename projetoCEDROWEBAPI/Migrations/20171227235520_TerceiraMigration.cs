using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace projetoCEDROWEBAPI.Migrations
{
    public partial class TerceiraMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pratos_Restaurantes_RestauranteId",
                table: "Pratos");

            migrationBuilder.RenameColumn(
                name: "RestauranteId",
                table: "Pratos",
                newName: "RestauranteIdRef");

            migrationBuilder.RenameIndex(
                name: "IX_Pratos_RestauranteId",
                table: "Pratos",
                newName: "IX_Pratos_RestauranteIdRef");

            migrationBuilder.AddForeignKey(
                name: "FK_Pratos_Restaurantes_RestauranteIdRef",
                table: "Pratos",
                column: "RestauranteIdRef",
                principalTable: "Restaurantes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pratos_Restaurantes_RestauranteIdRef",
                table: "Pratos");

            migrationBuilder.RenameColumn(
                name: "RestauranteIdRef",
                table: "Pratos",
                newName: "RestauranteId");

            migrationBuilder.RenameIndex(
                name: "IX_Pratos_RestauranteIdRef",
                table: "Pratos",
                newName: "IX_Pratos_RestauranteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pratos_Restaurantes_RestauranteId",
                table: "Pratos",
                column: "RestauranteId",
                principalTable: "Restaurantes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

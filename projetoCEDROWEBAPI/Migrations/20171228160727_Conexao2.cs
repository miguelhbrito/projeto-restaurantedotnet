using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace projetoCEDROWEBAPI.Migrations
{
    public partial class Conexao2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pratos_Restaurantes_RestauranteIdRef",
                table: "Pratos");

            migrationBuilder.DropIndex(
                name: "IX_Pratos_RestauranteIdRef",
                table: "Pratos");

            migrationBuilder.AddColumn<int>(
                name: "RestauranteId",
                table: "Pratos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pratos_RestauranteId",
                table: "Pratos",
                column: "RestauranteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pratos_Restaurantes_RestauranteId",
                table: "Pratos",
                column: "RestauranteId",
                principalTable: "Restaurantes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pratos_Restaurantes_RestauranteId",
                table: "Pratos");

            migrationBuilder.DropIndex(
                name: "IX_Pratos_RestauranteId",
                table: "Pratos");

            migrationBuilder.DropColumn(
                name: "RestauranteId",
                table: "Pratos");

            migrationBuilder.CreateIndex(
                name: "IX_Pratos_RestauranteIdRef",
                table: "Pratos",
                column: "RestauranteIdRef");

            migrationBuilder.AddForeignKey(
                name: "FK_Pratos_Restaurantes_RestauranteIdRef",
                table: "Pratos",
                column: "RestauranteIdRef",
                principalTable: "Restaurantes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

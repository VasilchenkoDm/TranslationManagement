﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TranslationManagement.DataAccess.Migrations
{
    public partial class AddRelationTranslatorToTranslationJob : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TranslatorId",
                table: "TranslationJobs",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TranslationJobs_TranslatorId",
                table: "TranslationJobs",
                column: "TranslatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_TranslationJobs_Translators_TranslatorId",
                table: "TranslationJobs",
                column: "TranslatorId",
                principalTable: "Translators",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TranslationJobs_Translators_TranslatorId",
                table: "TranslationJobs");

            migrationBuilder.DropIndex(
                name: "IX_TranslationJobs_TranslatorId",
                table: "TranslationJobs");

            migrationBuilder.DropColumn(
                name: "TranslatorId",
                table: "TranslationJobs");
        }
    }
}

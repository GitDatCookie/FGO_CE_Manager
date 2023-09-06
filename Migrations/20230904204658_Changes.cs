using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FGO_CE_Manager.Migrations
{
    /// <inheritdoc />
    public partial class Changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FunctionID",
                table: "Sval",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "CEGuid",
                table: "Skill",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SkillID",
                table: "Function",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CharaGraphID",
                table: "ExtraAssets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FacesID",
                table: "ExtraAssets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CollectionNo",
                table: "CE",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ExtraAssetsID",
                table: "CE",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "CE",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Sval_FunctionID",
                table: "Sval",
                column: "FunctionID");

            migrationBuilder.CreateIndex(
                name: "IX_Skill_CEGuid",
                table: "Skill",
                column: "CEGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Function_SkillID",
                table: "Function",
                column: "SkillID");

            migrationBuilder.CreateIndex(
                name: "IX_ExtraAssets_CharaGraphID",
                table: "ExtraAssets",
                column: "CharaGraphID");

            migrationBuilder.CreateIndex(
                name: "IX_ExtraAssets_FacesID",
                table: "ExtraAssets",
                column: "FacesID");

            migrationBuilder.CreateIndex(
                name: "IX_CE_ExtraAssetsID",
                table: "CE",
                column: "ExtraAssetsID");

            migrationBuilder.AddForeignKey(
                name: "FK_CE_ExtraAssets_ExtraAssetsID",
                table: "CE",
                column: "ExtraAssetsID",
                principalTable: "ExtraAssets",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExtraAssets_CharaGraph_CharaGraphID",
                table: "ExtraAssets",
                column: "CharaGraphID",
                principalTable: "CharaGraph",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ExtraAssets_Faces_FacesID",
                table: "ExtraAssets",
                column: "FacesID",
                principalTable: "Faces",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Function_Skill_SkillID",
                table: "Function",
                column: "SkillID",
                principalTable: "Skill",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Skill_CE_CEGuid",
                table: "Skill",
                column: "CEGuid",
                principalTable: "CE",
                principalColumn: "Guid");

            migrationBuilder.AddForeignKey(
                name: "FK_Sval_Function_FunctionID",
                table: "Sval",
                column: "FunctionID",
                principalTable: "Function",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CE_ExtraAssets_ExtraAssetsID",
                table: "CE");

            migrationBuilder.DropForeignKey(
                name: "FK_ExtraAssets_CharaGraph_CharaGraphID",
                table: "ExtraAssets");

            migrationBuilder.DropForeignKey(
                name: "FK_ExtraAssets_Faces_FacesID",
                table: "ExtraAssets");

            migrationBuilder.DropForeignKey(
                name: "FK_Function_Skill_SkillID",
                table: "Function");

            migrationBuilder.DropForeignKey(
                name: "FK_Skill_CE_CEGuid",
                table: "Skill");

            migrationBuilder.DropForeignKey(
                name: "FK_Sval_Function_FunctionID",
                table: "Sval");

            migrationBuilder.DropIndex(
                name: "IX_Sval_FunctionID",
                table: "Sval");

            migrationBuilder.DropIndex(
                name: "IX_Skill_CEGuid",
                table: "Skill");

            migrationBuilder.DropIndex(
                name: "IX_Function_SkillID",
                table: "Function");

            migrationBuilder.DropIndex(
                name: "IX_ExtraAssets_CharaGraphID",
                table: "ExtraAssets");

            migrationBuilder.DropIndex(
                name: "IX_ExtraAssets_FacesID",
                table: "ExtraAssets");

            migrationBuilder.DropIndex(
                name: "IX_CE_ExtraAssetsID",
                table: "CE");

            migrationBuilder.DropColumn(
                name: "FunctionID",
                table: "Sval");

            migrationBuilder.DropColumn(
                name: "CEGuid",
                table: "Skill");

            migrationBuilder.DropColumn(
                name: "SkillID",
                table: "Function");

            migrationBuilder.DropColumn(
                name: "CharaGraphID",
                table: "ExtraAssets");

            migrationBuilder.DropColumn(
                name: "FacesID",
                table: "ExtraAssets");

            migrationBuilder.DropColumn(
                name: "CollectionNo",
                table: "CE");

            migrationBuilder.DropColumn(
                name: "ExtraAssetsID",
                table: "CE");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "CE");
        }
    }
}

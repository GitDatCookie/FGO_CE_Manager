using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FGO_CE_Manager.Migrations
{
    /// <inheritdoc />
    public partial class yuhu : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Function_Skill_CE_SkillID",
                table: "Function");

            migrationBuilder.DropForeignKey(
                name: "FK_Sval_Function_Skills_FunctionSkillID",
                table: "Sval");

            migrationBuilder.RenameColumn(
                name: "Skills_FunctionSkillID",
                table: "Sval",
                newName: "Skills_FunctionFunctionID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Sval",
                newName: "SvalID");

            migrationBuilder.RenameIndex(
                name: "IX_Sval_Skills_FunctionSkillID",
                table: "Sval",
                newName: "IX_Sval_Skills_FunctionFunctionID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Skill",
                newName: "SkillID");

            migrationBuilder.RenameColumn(
                name: "CE_SkillID",
                table: "Function",
                newName: "CE_SkillSkillID");

            migrationBuilder.RenameColumn(
                name: "SkillID",
                table: "Function",
                newName: "FunctionID");

            migrationBuilder.RenameIndex(
                name: "IX_Function_CE_SkillID",
                table: "Function",
                newName: "IX_Function_CE_SkillSkillID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Faces",
                newName: "FacesID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "ExtraAssets",
                newName: "ExtraAssetsID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "CharaGraph",
                newName: "CharaGraphID");

            migrationBuilder.AddForeignKey(
                name: "FK_Function_Skill_CE_SkillSkillID",
                table: "Function",
                column: "CE_SkillSkillID",
                principalTable: "Skill",
                principalColumn: "SkillID");

            migrationBuilder.AddForeignKey(
                name: "FK_Sval_Function_Skills_FunctionFunctionID",
                table: "Sval",
                column: "Skills_FunctionFunctionID",
                principalTable: "Function",
                principalColumn: "FunctionID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Function_Skill_CE_SkillSkillID",
                table: "Function");

            migrationBuilder.DropForeignKey(
                name: "FK_Sval_Function_Skills_FunctionFunctionID",
                table: "Sval");

            migrationBuilder.RenameColumn(
                name: "Skills_FunctionFunctionID",
                table: "Sval",
                newName: "Skills_FunctionSkillID");

            migrationBuilder.RenameColumn(
                name: "SvalID",
                table: "Sval",
                newName: "ID");

            migrationBuilder.RenameIndex(
                name: "IX_Sval_Skills_FunctionFunctionID",
                table: "Sval",
                newName: "IX_Sval_Skills_FunctionSkillID");

            migrationBuilder.RenameColumn(
                name: "SkillID",
                table: "Skill",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "CE_SkillSkillID",
                table: "Function",
                newName: "CE_SkillID");

            migrationBuilder.RenameColumn(
                name: "FunctionID",
                table: "Function",
                newName: "SkillID");

            migrationBuilder.RenameIndex(
                name: "IX_Function_CE_SkillSkillID",
                table: "Function",
                newName: "IX_Function_CE_SkillID");

            migrationBuilder.RenameColumn(
                name: "FacesID",
                table: "Faces",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "ExtraAssetsID",
                table: "ExtraAssets",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "CharaGraphID",
                table: "CharaGraph",
                newName: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Function_Skill_CE_SkillID",
                table: "Function",
                column: "CE_SkillID",
                principalTable: "Skill",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Sval_Function_Skills_FunctionSkillID",
                table: "Sval",
                column: "Skills_FunctionSkillID",
                principalTable: "Function",
                principalColumn: "SkillID");
        }
    }
}

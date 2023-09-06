using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FGO_CE_Manager.Migrations
{
    /// <inheritdoc />
    public partial class change2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Function_Skill_SkillID",
                table: "Function");

            migrationBuilder.DropForeignKey(
                name: "FK_Sval_Function_FunctionID",
                table: "Sval");

            migrationBuilder.DropIndex(
                name: "IX_Sval_FunctionID",
                table: "Sval");

            migrationBuilder.DropIndex(
                name: "IX_Function_SkillID",
                table: "Function");

            migrationBuilder.DropColumn(
                name: "FunctionID",
                table: "Sval");

            migrationBuilder.DropColumn(
                name: "SkillID",
                table: "Function");

            migrationBuilder.AddColumn<int>(
                name: "Skills_FunctionID",
                table: "Sval",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CE_SkillID",
                table: "Function",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sval_Skills_FunctionID",
                table: "Sval",
                column: "Skills_FunctionID");

            migrationBuilder.CreateIndex(
                name: "IX_Function_CE_SkillID",
                table: "Function",
                column: "CE_SkillID");

            migrationBuilder.AddForeignKey(
                name: "FK_Function_Skill_CE_SkillID",
                table: "Function",
                column: "CE_SkillID",
                principalTable: "Skill",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Sval_Function_Skills_FunctionID",
                table: "Sval",
                column: "Skills_FunctionID",
                principalTable: "Function",
                principalColumn: "ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Function_Skill_CE_SkillID",
                table: "Function");

            migrationBuilder.DropForeignKey(
                name: "FK_Sval_Function_Skills_FunctionID",
                table: "Sval");

            migrationBuilder.DropIndex(
                name: "IX_Sval_Skills_FunctionID",
                table: "Sval");

            migrationBuilder.DropIndex(
                name: "IX_Function_CE_SkillID",
                table: "Function");

            migrationBuilder.DropColumn(
                name: "Skills_FunctionID",
                table: "Sval");

            migrationBuilder.DropColumn(
                name: "CE_SkillID",
                table: "Function");

            migrationBuilder.AddColumn<int>(
                name: "FunctionID",
                table: "Sval",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SkillID",
                table: "Function",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sval_FunctionID",
                table: "Sval",
                column: "FunctionID");

            migrationBuilder.CreateIndex(
                name: "IX_Function_SkillID",
                table: "Function",
                column: "SkillID");

            migrationBuilder.AddForeignKey(
                name: "FK_Function_Skill_SkillID",
                table: "Function",
                column: "SkillID",
                principalTable: "Skill",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sval_Function_FunctionID",
                table: "Sval",
                column: "FunctionID",
                principalTable: "Function",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

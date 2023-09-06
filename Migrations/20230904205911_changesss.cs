using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FGO_CE_Manager.Migrations
{
    /// <inheritdoc />
    public partial class changesss : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sval_Function_Skills_FunctionID",
                table: "Sval");

            migrationBuilder.RenameColumn(
                name: "Skills_FunctionID",
                table: "Sval",
                newName: "Skills_FunctionSkillID");

            migrationBuilder.RenameIndex(
                name: "IX_Sval_Skills_FunctionID",
                table: "Sval",
                newName: "IX_Sval_Skills_FunctionSkillID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Function",
                newName: "SkillID");

            migrationBuilder.AddForeignKey(
                name: "FK_Sval_Function_Skills_FunctionSkillID",
                table: "Sval",
                column: "Skills_FunctionSkillID",
                principalTable: "Function",
                principalColumn: "SkillID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sval_Function_Skills_FunctionSkillID",
                table: "Sval");

            migrationBuilder.RenameColumn(
                name: "Skills_FunctionSkillID",
                table: "Sval",
                newName: "Skills_FunctionID");

            migrationBuilder.RenameIndex(
                name: "IX_Sval_Skills_FunctionSkillID",
                table: "Sval",
                newName: "IX_Sval_Skills_FunctionID");

            migrationBuilder.RenameColumn(
                name: "SkillID",
                table: "Function",
                newName: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Sval_Function_Skills_FunctionID",
                table: "Sval",
                column: "Skills_FunctionID",
                principalTable: "Function",
                principalColumn: "ID");
        }
    }
}

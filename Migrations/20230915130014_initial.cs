using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FGO_CE_Manager.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CharaGraph",
                columns: table => new
                {
                    CharaGraphID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUri = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharaGraph", x => x.CharaGraphID);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    FGOEventID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.FGOEventID);
                });

            migrationBuilder.CreateTable(
                name: "Faces",
                columns: table => new
                {
                    FacesID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUri = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Faces", x => x.FacesID);
                });

            migrationBuilder.CreateTable(
                name: "ExtraAssets",
                columns: table => new
                {
                    ExtraAssetsID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CharaGraphID = table.Column<int>(type: "int", nullable: false),
                    FacesID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtraAssets", x => x.ExtraAssetsID);
                    table.ForeignKey(
                        name: "FK_ExtraAssets_CharaGraph_CharaGraphID",
                        column: x => x.CharaGraphID,
                        principalTable: "CharaGraph",
                        principalColumn: "CharaGraphID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ExtraAssets_Faces_FacesID",
                        column: x => x.FacesID,
                        principalTable: "Faces",
                        principalColumn: "FacesID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CE",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ID = table.Column<int>(type: "int", nullable: false),
                    CollectionNo = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExtraAssetsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CE", x => x.Guid);
                    table.ForeignKey(
                        name: "FK_CE_ExtraAssets_ExtraAssetsID",
                        column: x => x.ExtraAssetsID,
                        principalTable: "ExtraAssets",
                        principalColumn: "ExtraAssetsID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Skill",
                columns: table => new
                {
                    SkillID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CEGuid = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skill", x => x.SkillID);
                    table.ForeignKey(
                        name: "FK_Skill_CE_CEGuid",
                        column: x => x.CEGuid,
                        principalTable: "CE",
                        principalColumn: "Guid");
                });

            migrationBuilder.CreateTable(
                name: "Function",
                columns: table => new
                {
                    FunctionID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CE_SkillSkillID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Function", x => x.FunctionID);
                    table.ForeignKey(
                        name: "FK_Function_Skill_CE_SkillSkillID",
                        column: x => x.CE_SkillSkillID,
                        principalTable: "Skill",
                        principalColumn: "SkillID");
                });

            migrationBuilder.CreateTable(
                name: "Sval",
                columns: table => new
                {
                    SvalID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EventID = table.Column<int>(type: "int", nullable: true),
                    FGOEventID = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Skills_FunctionFunctionID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sval", x => x.SvalID);
                    table.ForeignKey(
                        name: "FK_Sval_Event_FGOEventID",
                        column: x => x.FGOEventID,
                        principalTable: "Event",
                        principalColumn: "FGOEventID");
                    table.ForeignKey(
                        name: "FK_Sval_Function_Skills_FunctionFunctionID",
                        column: x => x.Skills_FunctionFunctionID,
                        principalTable: "Function",
                        principalColumn: "FunctionID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CE_ExtraAssetsID",
                table: "CE",
                column: "ExtraAssetsID");

            migrationBuilder.CreateIndex(
                name: "IX_ExtraAssets_CharaGraphID",
                table: "ExtraAssets",
                column: "CharaGraphID");

            migrationBuilder.CreateIndex(
                name: "IX_ExtraAssets_FacesID",
                table: "ExtraAssets",
                column: "FacesID");

            migrationBuilder.CreateIndex(
                name: "IX_Function_CE_SkillSkillID",
                table: "Function",
                column: "CE_SkillSkillID");

            migrationBuilder.CreateIndex(
                name: "IX_Skill_CEGuid",
                table: "Skill",
                column: "CEGuid");

            migrationBuilder.CreateIndex(
                name: "IX_Sval_FGOEventID",
                table: "Sval",
                column: "FGOEventID");

            migrationBuilder.CreateIndex(
                name: "IX_Sval_Skills_FunctionFunctionID",
                table: "Sval",
                column: "Skills_FunctionFunctionID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sval");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "Function");

            migrationBuilder.DropTable(
                name: "Skill");

            migrationBuilder.DropTable(
                name: "CE");

            migrationBuilder.DropTable(
                name: "ExtraAssets");

            migrationBuilder.DropTable(
                name: "CharaGraph");

            migrationBuilder.DropTable(
                name: "Faces");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nickolas_mendonca_feed_aluno.Migrations
{
    /// <inheritdoc />
    public partial class M05AddTableAlunoDsiciplinaUpdateTableName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfessorDisciplina_Disciplinas_DisciplinaId",
                table: "ProfessorDisciplina");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfessorDisciplina_Usuarios_ProfessorId",
                table: "ProfessorDisciplina");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfessorDisciplina",
                table: "ProfessorDisciplina");

            migrationBuilder.RenameTable(
                name: "ProfessorDisciplina",
                newName: "ProfessorDisciplinas");

            migrationBuilder.RenameIndex(
                name: "IX_ProfessorDisciplina_ProfessorId",
                table: "ProfessorDisciplinas",
                newName: "IX_ProfessorDisciplinas_ProfessorId");

            migrationBuilder.RenameIndex(
                name: "IX_ProfessorDisciplina_DisciplinaId",
                table: "ProfessorDisciplinas",
                newName: "IX_ProfessorDisciplinas_DisciplinaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfessorDisciplinas",
                table: "ProfessorDisciplinas",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "AlunoDsiciplinas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlunoId = table.Column<int>(type: "int", nullable: false),
                    DisciplinaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoDsiciplinas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlunoDsiciplinas_Disciplinas_DisciplinaId",
                        column: x => x.DisciplinaId,
                        principalTable: "Disciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AlunoDsiciplinas_Usuarios_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlunoDsiciplinas_AlunoId",
                table: "AlunoDsiciplinas",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_AlunoDsiciplinas_DisciplinaId",
                table: "AlunoDsiciplinas",
                column: "DisciplinaId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessorDisciplinas_Disciplinas_DisciplinaId",
                table: "ProfessorDisciplinas",
                column: "DisciplinaId",
                principalTable: "Disciplinas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessorDisciplinas_Usuarios_ProfessorId",
                table: "ProfessorDisciplinas",
                column: "ProfessorId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProfessorDisciplinas_Disciplinas_DisciplinaId",
                table: "ProfessorDisciplinas");

            migrationBuilder.DropForeignKey(
                name: "FK_ProfessorDisciplinas_Usuarios_ProfessorId",
                table: "ProfessorDisciplinas");

            migrationBuilder.DropTable(
                name: "AlunoDsiciplinas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProfessorDisciplinas",
                table: "ProfessorDisciplinas");

            migrationBuilder.RenameTable(
                name: "ProfessorDisciplinas",
                newName: "ProfessorDisciplina");

            migrationBuilder.RenameIndex(
                name: "IX_ProfessorDisciplinas_ProfessorId",
                table: "ProfessorDisciplina",
                newName: "IX_ProfessorDisciplina_ProfessorId");

            migrationBuilder.RenameIndex(
                name: "IX_ProfessorDisciplinas_DisciplinaId",
                table: "ProfessorDisciplina",
                newName: "IX_ProfessorDisciplina_DisciplinaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProfessorDisciplina",
                table: "ProfessorDisciplina",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessorDisciplina_Disciplinas_DisciplinaId",
                table: "ProfessorDisciplina",
                column: "DisciplinaId",
                principalTable: "Disciplinas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProfessorDisciplina_Usuarios_ProfessorId",
                table: "ProfessorDisciplina",
                column: "ProfessorId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

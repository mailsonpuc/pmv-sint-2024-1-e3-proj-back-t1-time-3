using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace nickolas_mendonca_feed_aluno.Migrations
{
    /// <inheritdoc />
    public partial class M07TabeleAlunos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunoDsiciplinas");

            migrationBuilder.CreateTable(
                name: "AlunoProfessoresDisciplinas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AlunoId = table.Column<int>(type: "int", nullable: false),
                    PorfDiscId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlunoProfessoresDisciplinas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlunoProfessoresDisciplinas_ProfessorDisciplinas_PorfDiscId",
                        column: x => x.PorfDiscId,
                        principalTable: "ProfessorDisciplinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AlunoProfessoresDisciplinas_Usuarios_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlunoProfessoresDisciplinas_AlunoId",
                table: "AlunoProfessoresDisciplinas",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_AlunoProfessoresDisciplinas_PorfDiscId",
                table: "AlunoProfessoresDisciplinas",
                column: "PorfDiscId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlunoProfessoresDisciplinas");

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
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_AlunoDsiciplinas_Usuarios_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlunoDsiciplinas_AlunoId",
                table: "AlunoDsiciplinas",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_AlunoDsiciplinas_DisciplinaId",
                table: "AlunoDsiciplinas",
                column: "DisciplinaId");
        }
    }
}

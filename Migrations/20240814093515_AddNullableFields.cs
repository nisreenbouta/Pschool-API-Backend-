using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PschoolAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddNullableFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_students_parents_ParentId",
                schema: "public",
                table: "students");

            migrationBuilder.DropIndex(
                name: "IX_students_ParentId",
                schema: "public",
                table: "students");

            migrationBuilder.AlterColumn<string>(
                name: "WorkPhone",
                schema: "public",
                table: "parents",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                schema: "public",
                table: "parents",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "HomePhone",
                schema: "public",
                table: "parents",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "HomeAddress",
                schema: "public",
                table: "parents",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "WorkPhone",
                schema: "public",
                table: "parents",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                schema: "public",
                table: "parents",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HomePhone",
                schema: "public",
                table: "parents",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "HomeAddress",
                schema: "public",
                table: "parents",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_students_ParentId",
                schema: "public",
                table: "students",
                column: "ParentId");

            migrationBuilder.AddForeignKey(
                name: "FK_students_parents_ParentId",
                schema: "public",
                table: "students",
                column: "ParentId",
                principalSchema: "public",
                principalTable: "parents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

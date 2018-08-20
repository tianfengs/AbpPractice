using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PatientRecords.Data.Migrations
{
    public partial class AlterHumanModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SocialSecurityNumber",
                table: "Human",
                maxLength: 11,
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Human",
                maxLength: 10,
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SocialSecurityNumber",
                table: "Human",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Human",
                nullable: true);
        }
    }
}

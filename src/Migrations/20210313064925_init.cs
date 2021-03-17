using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace www.veinid365.cn.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NavMenu",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    ParentId = table.Column<int>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    Type = table.Column<byte>(nullable: false),
                    ExternalUrl = table.Column<string>(maxLength: 512, nullable: true),
                    MenuName = table.Column<string>(maxLength: 32, nullable: false),
                    EnMenuName = table.Column<string>(maxLength: 128, nullable: true),
                    IsHidden = table.Column<bool>(nullable: false),
                    BannerImg = table.Column<string>(maxLength: 512, nullable: true),
                    WebsiteKeywords = table.Column<string>(maxLength: 256, nullable: true),
                    WebsiteDescription = table.Column<string>(maxLength: 512, nullable: true),
                    Model = table.Column<byte>(nullable: false),
                    ListTemplateFile = table.Column<string>(maxLength: 512, nullable: true),
                    ContentTemplateFile = table.Column<string>(maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NavMenu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NavMenu_NavMenu_ParentId",
                        column: x => x.ParentId,
                        principalTable: "NavMenu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UserName = table.Column<string>(maxLength: 512, nullable: false),
                    PasswordHash = table.Column<string>(maxLength: 512, nullable: false),
                    Tel = table.Column<string>(maxLength: 512, nullable: true),
                    Email = table.Column<string>(maxLength: 512, nullable: true),
                    Role = table.Column<byte>(nullable: false),
                    LastLoginTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WebsiteSetting",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    WebsiteName = table.Column<string>(maxLength: 32, nullable: false),
                    WebsiteLogo = table.Column<string>(maxLength: 512, nullable: true),
                    WebsiteAddressIcon = table.Column<string>(maxLength: 512, nullable: true),
                    WebsiteTitle = table.Column<string>(maxLength: 256, nullable: false),
                    WebsiteUrl = table.Column<string>(maxLength: 512, nullable: false),
                    WebsiteKeywords = table.Column<string>(maxLength: 256, nullable: true),
                    WebsiteDescription = table.Column<string>(maxLength: 512, nullable: true),
                    Copyright = table.Column<string>(maxLength: 512, nullable: true),
                    CaseNumber = table.Column<string>(maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebsiteSetting", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PageContent",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    NavMenuId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(maxLength: 512, nullable: false),
                    Thumbnail = table.Column<string>(maxLength: 512, nullable: true),
                    Content = table.Column<string>(type: "text", nullable: true),
                    Pageviews = table.Column<int>(nullable: false),
                    IsPublished = table.Column<bool>(nullable: false),
                    WebsiteTitle = table.Column<string>(maxLength: 128, nullable: true),
                    WebsiteKeywords = table.Column<string>(maxLength: 256, nullable: true),
                    WebsiteDescription = table.Column<string>(maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PageContent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PageContent_NavMenu_NavMenuId",
                        column: x => x.NavMenuId,
                        principalTable: "NavMenu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WebsiteCustomForm",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    NavMenuId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 512, nullable: false),
                    Type = table.Column<byte>(nullable: false),
                    IsRequired = table.Column<bool>(nullable: false),
                    IsShowList = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebsiteCustomForm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WebsiteCustomForm_NavMenu_NavMenuId",
                        column: x => x.NavMenuId,
                        principalTable: "NavMenu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WebsiteCustomFormValue",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    NavMenuId = table.Column<int>(nullable: false),
                    Value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebsiteCustomFormValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WebsiteCustomFormValue_NavMenu_NavMenuId",
                        column: x => x.NavMenuId,
                        principalTable: "NavMenu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WebsiteCustomParam",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    WebsiteSettingId = table.Column<int>(nullable: false),
                    Name = table.Column<string>(maxLength: 512, nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebsiteCustomParam", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WebsiteCustomParam_WebsiteSetting_WebsiteSettingId",
                        column: x => x.WebsiteSettingId,
                        principalTable: "WebsiteSetting",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DownloadFile",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    PageContentId = table.Column<int>(nullable: false),
                    FileName = table.Column<string>(maxLength: 512, nullable: false),
                    FileUrl = table.Column<string>(maxLength: 512, nullable: false),
                    Title = table.Column<string>(maxLength: 512, nullable: false),
                    FileSize = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DownloadFile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DownloadFile_PageContent_PageContentId",
                        column: x => x.PageContentId,
                        principalTable: "PageContent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DownloadFile_PageContentId",
                table: "DownloadFile",
                column: "PageContentId");

            migrationBuilder.CreateIndex(
                name: "IX_NavMenu_ParentId",
                table: "NavMenu",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_PageContent_NavMenuId",
                table: "PageContent",
                column: "NavMenuId");

            migrationBuilder.CreateIndex(
                name: "IX_WebsiteCustomForm_NavMenuId",
                table: "WebsiteCustomForm",
                column: "NavMenuId");

            migrationBuilder.CreateIndex(
                name: "IX_WebsiteCustomFormValue_NavMenuId",
                table: "WebsiteCustomFormValue",
                column: "NavMenuId");

            migrationBuilder.CreateIndex(
                name: "IX_WebsiteCustomParam_WebsiteSettingId",
                table: "WebsiteCustomParam",
                column: "WebsiteSettingId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DownloadFile");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "WebsiteCustomForm");

            migrationBuilder.DropTable(
                name: "WebsiteCustomFormValue");

            migrationBuilder.DropTable(
                name: "WebsiteCustomParam");

            migrationBuilder.DropTable(
                name: "PageContent");

            migrationBuilder.DropTable(
                name: "WebsiteSetting");

            migrationBuilder.DropTable(
                name: "NavMenu");
        }
    }
}

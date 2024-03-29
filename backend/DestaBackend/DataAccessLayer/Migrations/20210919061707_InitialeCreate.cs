﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DestaNationConnect.DataAccessLayer.Migrations
{
    public partial class InitialeCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OAuthProvider",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OAuthProvider", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PostTag",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostTag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TagPurpose",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagPurpose", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TagType",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AccessCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsBIPOC = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Door = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Address_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Announce",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Context = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Announce", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Announce_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Business",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    PartnerBusinessId = table.Column<long>(type: "bigint", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PartnerBusinessStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MarketingName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Teasing = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AboutUs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Website = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Business", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Business_Business_PartnerBusinessId",
                        column: x => x.PartnerBusinessId,
                        principalTable: "Business",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Business_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChatMessage",
                columns: table => new
                {
                    ID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserFromID = table.Column<long>(type: "bigint", nullable: false),
                    UserToID = table.Column<long>(type: "bigint", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatMessage", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ChatMessage_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Age = table.Column<long>(type: "bigint", nullable: false),
                    Occupation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Customer_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagTypeId = table.Column<long>(type: "bigint", nullable: false),
                    AuthorId = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tag_TagType_TagTypeId",
                        column: x => x.TagTypeId,
                        principalTable: "TagType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Tag_User_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserFeed",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FeedURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShortDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LongDescription = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFeed", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserFeed_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserOAuth",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    OAuthProviderId = table.Column<long>(type: "bigint", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    EmailIsVerified = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserOAuth", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserOAuth_OAuthProvider_OAuthProviderId",
                        column: x => x.OAuthProviderId,
                        principalTable: "OAuthProvider",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserOAuth_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserProfile",
                columns: table => new
                {
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fax = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfile", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_UserProfile_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BusinessDetail",
                columns: table => new
                {
                    BusinessId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Facebook = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Google = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LinkedIn = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessDetail", x => x.BusinessId);
                    table.ForeignKey(
                        name: "FK_BusinessDetail_Business_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Business",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostTagId = table.Column<long>(type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BusinessUserId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Post_Business_BusinessUserId",
                        column: x => x.BusinessUserId,
                        principalTable: "Business",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Post_PostTag_PostTagId",
                        column: x => x.PostTagId,
                        principalTable: "PostTag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChatData",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChatMessageId = table.Column<long>(type: "bigint", nullable: false),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChatData_ChatMessage_ChatMessageId",
                        column: x => x.ChatMessageId,
                        principalTable: "ChatMessage",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerDetail",
                columns: table => new
                {
                    CustomerId = table.Column<long>(type: "bigint", nullable: false),
                    BirthDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerDetail", x => x.CustomerId);
                    table.ForeignKey(
                        name: "FK_CustomerDetail_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerFavoriteBusiness",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<long>(type: "bigint", nullable: false),
                    BusinessId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerFavoriteBusiness", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerFavoriteBusiness_Business_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Business",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerFavoriteBusiness_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CustomerHabit",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CustomerId = table.Column<long>(type: "bigint", nullable: false),
                    BusinessId = table.Column<long>(type: "bigint", nullable: false),
                    DateOfAction = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Action = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CustomerHabit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CustomerHabit_Business_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Business",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CustomerHabit_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customer",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AnnounceTag",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagId = table.Column<long>(type: "bigint", nullable: false),
                    AnnounceId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnnounceTag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnnounceTag_Announce_AnnounceId",
                        column: x => x.AnnounceId,
                        principalTable: "Announce",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AnnounceTag_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AnnounceTag_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserTag",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    TagId = table.Column<long>(type: "bigint", nullable: false),
                    TagPurposeId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTag_Tag_TagId",
                        column: x => x.TagId,
                        principalTable: "Tag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserTag_TagPurpose_TagPurposeId",
                        column: x => x.TagPurposeId,
                        principalTable: "TagPurpose",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserTag_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Like",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    PostId = table.Column<long>(type: "bigint", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Like", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Like_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Like_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostComment",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostId = table.Column<long>(type: "bigint", nullable: false),
                    BusinessId = table.Column<long>(type: "bigint", nullable: false),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostComment_Business_BusinessId",
                        column: x => x.BusinessId,
                        principalTable: "Business",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PostComment_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "TagPurpose",
                columns: new[] { "Id", "CreationDate", "Description", "Name" },
                values: new object[,]
                {
                    { 1L, new DateTime(2021, 9, 19, 6, 17, 5, 830, DateTimeKind.Utc).AddTicks(1451), "Description de what is a tag of type Interest", "Interest" },
                    { 2L, new DateTime(2021, 9, 19, 6, 17, 5, 830, DateTimeKind.Utc).AddTicks(1848), "Description de what is a tag of type Descriptive", "Descriptive" }
                });

            migrationBuilder.InsertData(
                table: "TagType",
                columns: new[] { "Id", "CreationDate", "Description", "Name" },
                values: new object[,]
                {
                    { 1L, new DateTime(2021, 9, 19, 6, 17, 5, 831, DateTimeKind.Utc).AddTicks(7001), "Description of what is a WHY tag", "Why" },
                    { 2L, new DateTime(2021, 9, 19, 6, 17, 5, 831, DateTimeKind.Utc).AddTicks(7455), "Description of what is a WHAT tag ", "What" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "UserId", "AccessCode", "CreationDate", "IsBIPOC", "Password", "Username" },
                values: new object[,]
                {
                    { 1L, null, new DateTime(2021, 9, 19, 6, 17, 5, 833, DateTimeKind.Utc).AddTicks(1870), false, "AQAAAAEAACcQAAAAEJd5hlfuADJi0QH7JyTId8PIO3ZnptPAop7RHuPnkoyoFFyaeV24acZFyvieWdza/w==", "destau1" },
                    { 2L, null, new DateTime(2021, 9, 19, 6, 17, 5, 833, DateTimeKind.Utc).AddTicks(2467), false, "AQAAAAEAACcQAAAAEP1NVu7SOsNsXyxWpNS0ueruUmoO5HwXUGZg8aqTrnVbYHtCcWtcyenagpa83XSrCg==", "destab1" },
                    { 3L, null, new DateTime(2021, 9, 19, 6, 17, 5, 833, DateTimeKind.Utc).AddTicks(2474), false, "AQAAAAEAACcQAAAAEKCFNBRODGjLqX9MzlfqFwroCTkXLCm9jPzTPK3+nB8zRP8G710N0V/vxYcqH0KZ1Q==", "destab2" }
                });

            migrationBuilder.InsertData(
                table: "Business",
                columns: new[] { "UserId", "AboutUs", "CreationDate", "MarketingName", "PartnerBusinessId", "PartnerBusinessStartDate", "Teasing", "Website" },
                values: new object[,]
                {
                    { 3L, "We sell food and drink", new DateTime(2021, 9, 19, 6, 17, 5, 834, DateTimeKind.Utc).AddTicks(2108), "Hot Africa", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://destabyn.org/" },
                    { 2L, "We are the best", new DateTime(2021, 9, 19, 6, 17, 5, 834, DateTimeKind.Utc).AddTicks(1605), "DestaNation", null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "https://destabyn.org/" }
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "UserId", "Age", "CreationDate", "Occupation" },
                values: new object[] { 1L, 26L, new DateTime(2021, 9, 19, 6, 17, 5, 833, DateTimeKind.Utc).AddTicks(6408), "Sofware developper" });

            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "Id", "AuthorId", "CreationDate", "Description", "Name", "TagTypeId" },
                values: new object[,]
                {
                    { 14L, null, new DateTime(2021, 9, 19, 6, 17, 5, 832, DateTimeKind.Utc).AddTicks(897), "Descriptive WHAT tag about ...", "Legal & Financial", 2L },
                    { 13L, null, new DateTime(2021, 9, 19, 6, 17, 5, 832, DateTimeKind.Utc).AddTicks(895), "Descriptive WHAT tag about ...", "Home & Garden", 2L },
                    { 12L, null, new DateTime(2021, 9, 19, 6, 17, 5, 832, DateTimeKind.Utc).AddTicks(894), "Descriptive WHAT tag about ...", "Health & Lifestyle", 2L },
                    { 11L, null, new DateTime(2021, 9, 19, 6, 17, 5, 832, DateTimeKind.Utc).AddTicks(892), "Descriptive WHAT tag about ...", "Food & Dining", 2L },
                    { 10L, null, new DateTime(2021, 9, 19, 6, 17, 5, 832, DateTimeKind.Utc).AddTicks(889), "Descriptive WHAT tag about ...", "Entertainment", 2L },
                    { 9L, null, new DateTime(2021, 9, 19, 6, 17, 5, 832, DateTimeKind.Utc).AddTicks(887), "Descriptive WHAT tag about ...", "Education", 2L },
                    { 7L, null, new DateTime(2021, 9, 19, 6, 17, 5, 832, DateTimeKind.Utc).AddTicks(883), "Descriptive WHAT tag about ...", "Computers & Electronics", 2L },
                    { 6L, null, new DateTime(2021, 9, 19, 6, 17, 5, 832, DateTimeKind.Utc).AddTicks(881), "Descriptive WHAT tag about ...", "Business Services", 2L },
                    { 5L, null, new DateTime(2021, 9, 19, 6, 17, 5, 832, DateTimeKind.Utc).AddTicks(879), "Descriptive WHAT tag about ...", "Automotive", 2L },
                    { 4L, null, new DateTime(2021, 9, 19, 6, 17, 5, 832, DateTimeKind.Utc).AddTicks(878), "Interest WHY tag about .......", "Promotion / Sale", 1L },
                    { 3L, null, new DateTime(2021, 9, 19, 6, 17, 5, 832, DateTimeKind.Utc).AddTicks(876), "Interest WHY tag about .......", "Community Event", 1L },
                    { 2L, null, new DateTime(2021, 9, 19, 6, 17, 5, 832, DateTimeKind.Utc).AddTicks(870), "Interest WHY tag about .......", "Work opportunities", 1L },
                    { 8L, null, new DateTime(2021, 9, 19, 6, 17, 5, 832, DateTimeKind.Utc).AddTicks(885), "Descriptive WHAT tag about ...", "Construction & Contractors", 2L },
                    { 1L, null, new DateTime(2021, 9, 19, 6, 17, 5, 832, DateTimeKind.Utc).AddTicks(347), "Interest WHY tag about .......", "Volunteering", 1L }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Address_UserId",
                table: "Address",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Announce_UserId",
                table: "Announce",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AnnounceTag_AnnounceId",
                table: "AnnounceTag",
                column: "AnnounceId");

            migrationBuilder.CreateIndex(
                name: "IX_AnnounceTag_TagId",
                table: "AnnounceTag",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_AnnounceTag_UserId",
                table: "AnnounceTag",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Business_PartnerBusinessId",
                table: "Business",
                column: "PartnerBusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatData_ChatMessageId",
                table: "ChatData",
                column: "ChatMessageId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessage_UserId",
                table: "ChatMessage",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerFavoriteBusiness_BusinessId",
                table: "CustomerFavoriteBusiness",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerFavoriteBusiness_CustomerId",
                table: "CustomerFavoriteBusiness",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerHabit_BusinessId",
                table: "CustomerHabit",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_CustomerHabit_CustomerId",
                table: "CustomerHabit",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Like_PostId",
                table: "Like",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Like_UserId",
                table: "Like",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_BusinessUserId",
                table: "Post",
                column: "BusinessUserId");

            migrationBuilder.CreateIndex(
                name: "IX_Post_PostTagId",
                table: "Post",
                column: "PostTagId");

            migrationBuilder.CreateIndex(
                name: "IX_PostComment_BusinessId",
                table: "PostComment",
                column: "BusinessId");

            migrationBuilder.CreateIndex(
                name: "IX_PostComment_PostId",
                table: "PostComment",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Tag_AuthorId",
                table: "Tag",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Tag_TagTypeId",
                table: "Tag",
                column: "TagTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TagPurpose_Name",
                table: "TagPurpose",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_TagType_Name",
                table: "TagType",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_User_Username",
                table: "User",
                column: "Username",
                unique: true,
                filter: "[Username] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserFeed_UserId",
                table: "UserFeed",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOAuth_Email",
                table: "UserOAuth",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_UserOAuth_OAuthProviderId",
                table: "UserOAuth",
                column: "OAuthProviderId");

            migrationBuilder.CreateIndex(
                name: "IX_UserOAuth_UserId",
                table: "UserOAuth",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTag_TagId",
                table: "UserTag",
                column: "TagId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTag_TagPurposeId",
                table: "UserTag",
                column: "TagPurposeId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTag_UserId",
                table: "UserTag",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");

            migrationBuilder.DropTable(
                name: "AnnounceTag");

            migrationBuilder.DropTable(
                name: "BusinessDetail");

            migrationBuilder.DropTable(
                name: "ChatData");

            migrationBuilder.DropTable(
                name: "CustomerDetail");

            migrationBuilder.DropTable(
                name: "CustomerFavoriteBusiness");

            migrationBuilder.DropTable(
                name: "CustomerHabit");

            migrationBuilder.DropTable(
                name: "Like");

            migrationBuilder.DropTable(
                name: "PostComment");

            migrationBuilder.DropTable(
                name: "UserFeed");

            migrationBuilder.DropTable(
                name: "UserOAuth");

            migrationBuilder.DropTable(
                name: "UserProfile");

            migrationBuilder.DropTable(
                name: "UserTag");

            migrationBuilder.DropTable(
                name: "Announce");

            migrationBuilder.DropTable(
                name: "ChatMessage");

            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "OAuthProvider");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "TagPurpose");

            migrationBuilder.DropTable(
                name: "Business");

            migrationBuilder.DropTable(
                name: "PostTag");

            migrationBuilder.DropTable(
                name: "TagType");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}

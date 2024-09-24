using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    public partial class dbreseedupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TaskLists",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatorId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserConnections",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ConnectionId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserConnections", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaskItems",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Details = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    Deadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Estimated = table.Column<float>(type: "real", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatorId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssigneeId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TaskListId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaskItems_TaskLists_TaskListId",
                        column: x => x.TaskListId,
                        principalTable: "TaskLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserTaskLists",
                columns: table => new
                {
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TaskListId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTaskLists", x => new { x.AppUserId, x.TaskListId });
                    table.ForeignKey(
                        name: "FK_UserTaskLists_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserTaskLists_TaskLists_TaskListId",
                        column: x => x.TaskListId,
                        principalTable: "TaskLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ChangeLogs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ChangeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TaskItemId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ChangerId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OldTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OldDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OldPriority = table.Column<int>(type: "int", nullable: false),
                    OldDeadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OldAssigneeId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OldWorkflowItemId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NewTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NewDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NewPriority = table.Column<int>(type: "int", nullable: false),
                    NewDeadline = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NewAssigneeId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NewWorkflowItemId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChangeLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChangeLogs_TaskItems_TaskItemId",
                        column: x => x.TaskItemId,
                        principalTable: "TaskItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserWorkLogs",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LogDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WorkTime = table.Column<long>(type: "bigint", nullable: false),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TaskItemId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserWorkLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserWorkLogs_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserWorkLogs_TaskItems_TaskItemId",
                        column: x => x.TaskItemId,
                        principalTable: "TaskItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WorkflowItems",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeletable = table.Column<bool>(type: "bit", nullable: false),
                    TaskItemId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkflowItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WorkflowItems_TaskItems_TaskItemId",
                        column: x => x.TaskItemId,
                        principalTable: "TaskItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", null, "Admin", "ADMIN" },
                    { "2", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "Image", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "6007eeb4-4568-487f-8efb-8543290591ed", 0, "9516cd33-6997-4689-a1b6-5a23b5ae0864", "AppUser", "emily.williams@example.com", true, "Emily", "https://fastly.picsum.photos/id/916/200/200.jpg?hmac=hEUrLG-ayFdIoyHKUwazT8SMEsVxWH9xGz4tx-e0cN0", "Williams", false, null, "EMILY.WILLIAMS@EXAMPLE.COM", "EMILY.WILLIAMS", "AQAAAAEAACcQAAAAEAll/09lVqw1Pt8hcpDGkmc5JM7165ekNnpeKLxOKeVgMzbgwd5Uvqfc3jzye7Tsew==", null, false, "532ca569-fed9-409f-abb8-7f45e764f458", false, "emily.williams" },
                    { "7aa6b375-c7e4-4229-8edd-abaf8b1e1bd3", 0, "207ad3ea-d247-41c8-b9bd-31625ca2c756", "AppUser", "john.doe@example.com", true, "John", "https://fastly.picsum.photos/id/237/200/200.jpg?hmac=zHUGikXUDyLCCmvyww1izLK3R3k8oRYBRiTizZEdyfI", "Doe", false, null, "JOHN.DOE@EXAMPLE.COM", "JOHN.DOE", "AQAAAAEAACcQAAAAECRFw0eh48sXd9RgdSPHb56FbpJbWP0utnQ6vNUOEII4U3RsfAaHygD+XhoRp7KI1w==", null, false, "634af213-371b-4184-8d70-9bfbd6529f1d", false, "john.doe" },
                    { "a142e4bc-e727-4e31-90ee-099c53851b70", 0, "0f25d628-7939-4978-90b1-2679fe9baf49", "AppUser", "mike.jones@example.com", true, "Mike", "https://fastly.picsum.photos/id/256/200/200.jpg?hmac=MX3r8Dktr5b26lQqb5JB6sgLnCxSgt1KRm0F1eNDHCk", "Jones", false, null, "MIKE.JONES@EXAMPLE.COM", "MIKE.JONES", "AQAAAAEAACcQAAAAELprAFIUCeTxC5XcPwkl/83Agu0Sm1e8VesztTLRTUtPY0lAqzas6Jena3ekw2KAJQ==", null, false, "17fdb3f4-8ad8-4a71-b7f9-17539fad5d09", false, "mike.jones" },
                    { "ba09fe5b-d803-4b28-a18f-bf61b3fad4f1", 0, "b18e9bb3-3f43-4882-b0f2-8e130c1d9cb8", "AppUser", "sarah.smith@example.com", true, "Sarah", "https://fastly.picsum.photos/id/408/200/200.jpg?hmac=VJjKULX_XeyV5C9mbWyv6XTsG5EV-ZBsqbiQIi6xTeg", "Smith", false, null, "SARAH.SMITH@EXAMPLE.COM", "SARAH.SMITH", "AQAAAAEAACcQAAAAEPGXrvjRIn4LHrosz12YWf7rsQByKMz/7M9Gr9lid8rrXS0qyngVpkHmnpVPALWHpA==", null, false, "41682cf5-4719-4492-83fd-e515bbb3d36c", false, "sarah.smith" }
                });

            migrationBuilder.InsertData(
                table: "TaskLists",
                columns: new[] { "Id", "CreatorId", "Description", "Name" },
                values: new object[,]
                {
                    { "0cb29329-e2c4-4ede-ad95-8e52a86a9f42", "7aa6b375-c7e4-4229-8edd-abaf8b1e1bd3", "This list will contain programming tasks.", "Programming tasks" },
                    { "b7b9375f-143c-4403-b8bf-efe753fd98ee", "ba09fe5b-d803-4b28-a18f-bf61b3fad4f1", "This list will contain management type tasks.", "Management tasks" }
                });

            migrationBuilder.InsertData(
                table: "TaskItems",
                columns: new[] { "Id", "AssigneeId", "CreatedAt", "CreatorId", "Deadline", "Details", "Estimated", "Priority", "TaskListId", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { "0c429c0a-c498-428e-ad7a-13a0dcf25395", "a142e4bc-e727-4e31-90ee-099c53851b70", new DateTime(2024, 4, 30, 9, 4, 5, 444, DateTimeKind.Utc).AddTicks(8591), "7aa6b375-c7e4-4229-8edd-abaf8b1e1bd3", new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Conduct a thorough review of the recent code changes in the development branch and provide feedback.", 6f, 2, "0cb29329-e2c4-4ede-ad95-8e52a86a9f42", "Review Code Changes", new DateTime(2024, 4, 30, 9, 4, 5, 444, DateTimeKind.Utc).AddTicks(8592) },
                    { "7410025a-0b45-4e29-98b2-49c8f39d7bfb", "6007eeb4-4568-487f-8efb-8543290591ed", new DateTime(2024, 4, 30, 9, 4, 5, 444, DateTimeKind.Utc).AddTicks(8606), "ba09fe5b-d803-4b28-a18f-bf61b3fad4f1", new DateTime(2024, 5, 4, 0, 0, 0, 0, DateTimeKind.Utc), "Coordinate a meeting with the project team to discuss the upcoming milestones and action items.", 2f, 2, "b7b9375f-143c-4403-b8bf-efe753fd98ee", "Schedule Meeting", new DateTime(2024, 4, 30, 9, 4, 5, 444, DateTimeKind.Utc).AddTicks(8606) },
                    { "773b26c7-544e-4ca3-b0b5-f2096e87a491", "ba09fe5b-d803-4b28-a18f-bf61b3fad4f1", new DateTime(2024, 4, 30, 9, 4, 5, 444, DateTimeKind.Utc).AddTicks(8611), "ba09fe5b-d803-4b28-a18f-bf61b3fad4f1", new DateTime(2024, 5, 10, 0, 0, 0, 0, DateTimeKind.Utc), "Research current market trends and gather insights to inform strategic decisions for the next quarter.", 20f, 0, "b7b9375f-143c-4403-b8bf-efe753fd98ee", "Research Market Trends", new DateTime(2024, 4, 30, 9, 4, 5, 444, DateTimeKind.Utc).AddTicks(8612) },
                    { "79bbcea0-e6ce-4d6a-a9f3-c7db24bf4dcd", "6007eeb4-4568-487f-8efb-8543290591ed", new DateTime(2024, 4, 30, 9, 4, 5, 444, DateTimeKind.Utc).AddTicks(8599), "ba09fe5b-d803-4b28-a18f-bf61b3fad4f1", new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Utc), "Follow up with the client regarding their recent inquiries and provide necessary assistance.", 1f, 2, "b7b9375f-143c-4403-b8bf-efe753fd98ee", "Call Client", new DateTime(2024, 4, 30, 9, 4, 5, 444, DateTimeKind.Utc).AddTicks(8600) },
                    { "d2fd8100-c959-4562-b0f6-590044a82e7d", "7aa6b375-c7e4-4229-8edd-abaf8b1e1bd3", new DateTime(2024, 4, 30, 9, 4, 5, 444, DateTimeKind.Utc).AddTicks(8582), "7aa6b375-c7e4-4229-8edd-abaf8b1e1bd3", new DateTime(2024, 5, 5, 0, 0, 0, 0, DateTimeKind.Utc), "Finish writing the quarterly report for the management team.", 3f, 1, "0cb29329-e2c4-4ede-ad95-8e52a86a9f42", "Complete Report", new DateTime(2024, 4, 30, 9, 4, 5, 444, DateTimeKind.Utc).AddTicks(8583) }
                });

            migrationBuilder.InsertData(
                table: "UserTaskLists",
                columns: new[] { "AppUserId", "TaskListId" },
                values: new object[,]
                {
                    { "6007eeb4-4568-487f-8efb-8543290591ed", "b7b9375f-143c-4403-b8bf-efe753fd98ee" },
                    { "7aa6b375-c7e4-4229-8edd-abaf8b1e1bd3", "0cb29329-e2c4-4ede-ad95-8e52a86a9f42" },
                    { "7aa6b375-c7e4-4229-8edd-abaf8b1e1bd3", "b7b9375f-143c-4403-b8bf-efe753fd98ee" },
                    { "a142e4bc-e727-4e31-90ee-099c53851b70", "0cb29329-e2c4-4ede-ad95-8e52a86a9f42" },
                    { "ba09fe5b-d803-4b28-a18f-bf61b3fad4f1", "0cb29329-e2c4-4ede-ad95-8e52a86a9f42" },
                    { "ba09fe5b-d803-4b28-a18f-bf61b3fad4f1", "b7b9375f-143c-4403-b8bf-efe753fd98ee" }
                });

            migrationBuilder.InsertData(
                table: "UserWorkLogs",
                columns: new[] { "Id", "AppUserId", "LogDate", "TaskItemId", "WorkTime" },
                values: new object[,]
                {
                    { "09ff9b61-5665-4f8d-adcd-20adba1e7bab", "a142e4bc-e727-4e31-90ee-099c53851b70", new DateTime(2024, 4, 30, 9, 4, 5, 444, DateTimeKind.Utc).AddTicks(8808), "0c429c0a-c498-428e-ad7a-13a0dcf25395", 72000000000L },
                    { "b5a8a977-809b-4d60-9899-97afbe0b064f", "7aa6b375-c7e4-4229-8edd-abaf8b1e1bd3", new DateTime(2024, 4, 30, 9, 4, 5, 444, DateTimeKind.Utc).AddTicks(8795), "d2fd8100-c959-4562-b0f6-590044a82e7d", 36000000000L }
                });

            migrationBuilder.InsertData(
                table: "WorkflowItems",
                columns: new[] { "Id", "IsActive", "IsDeletable", "Name", "Order", "TaskItemId" },
                values: new object[,]
                {
                    { "22dbe941-682d-49c3-bc8b-f765dfa41769", true, false, "To Do", 0, "d2fd8100-c959-4562-b0f6-590044a82e7d" },
                    { "282213fb-5fad-4473-8392-04ba79d2eb01", false, false, "Done", 100, "79bbcea0-e6ce-4d6a-a9f3-c7db24bf4dcd" },
                    { "4446a567-690f-4c8a-80b4-19db3c3ef522", false, false, "Done", 100, "7410025a-0b45-4e29-98b2-49c8f39d7bfb" },
                    { "4b695506-757a-406a-bd21-38f4efc9068a", true, false, "To Do", 0, "7410025a-0b45-4e29-98b2-49c8f39d7bfb" },
                    { "74f085f5-9017-4bbe-a976-2f67924e66f8", true, false, "To Do", 0, "0c429c0a-c498-428e-ad7a-13a0dcf25395" },
                    { "83adcd97-b112-4a25-a304-195f350fc191", false, false, "Done", 100, "0c429c0a-c498-428e-ad7a-13a0dcf25395" },
                    { "923fa8ae-c245-411a-9ab2-7c17d58fc722", true, false, "To Do", 0, "79bbcea0-e6ce-4d6a-a9f3-c7db24bf4dcd" },
                    { "a7c281b4-f9fc-4f80-b85a-82366cb9cb5e", false, false, "Done", 100, "d2fd8100-c959-4562-b0f6-590044a82e7d" },
                    { "c1eb92c5-36c7-4f34-a8cd-6790f3366486", true, false, "To Do", 0, "773b26c7-544e-4ca3-b0b5-f2096e87a491" },
                    { "e4fadc1b-5dc6-4c85-b496-9c2240036a11", false, false, "Done", 100, "773b26c7-544e-4ca3-b0b5-f2096e87a491" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_ChangeLogs_TaskItemId",
                table: "ChangeLogs",
                column: "TaskItemId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskItems_TaskListId",
                table: "TaskItems",
                column: "TaskListId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTaskLists_TaskListId",
                table: "UserTaskLists",
                column: "TaskListId");

            migrationBuilder.CreateIndex(
                name: "IX_UserWorkLogs_AppUserId",
                table: "UserWorkLogs",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserWorkLogs_TaskItemId",
                table: "UserWorkLogs",
                column: "TaskItemId");

            migrationBuilder.CreateIndex(
                name: "IX_WorkflowItems_TaskItemId",
                table: "WorkflowItems",
                column: "TaskItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ChangeLogs");

            migrationBuilder.DropTable(
                name: "UserConnections");

            migrationBuilder.DropTable(
                name: "UserTaskLists");

            migrationBuilder.DropTable(
                name: "UserWorkLogs");

            migrationBuilder.DropTable(
                name: "WorkflowItems");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "TaskItems");

            migrationBuilder.DropTable(
                name: "TaskLists");
        }
    }
}

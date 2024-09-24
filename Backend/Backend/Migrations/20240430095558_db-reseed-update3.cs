using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    public partial class dbreseedupdate3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserTaskLists",
                keyColumns: new[] { "AppUserId", "TaskListId" },
                keyValues: new object[] { "30b5ba9d-7faf-4658-a0c6-d7fc6c4f3168", "400759d2-60b2-42ed-a026-2bd318c859f3" });

            migrationBuilder.DeleteData(
                table: "UserTaskLists",
                keyColumns: new[] { "AppUserId", "TaskListId" },
                keyValues: new object[] { "30b5ba9d-7faf-4658-a0c6-d7fc6c4f3168", "c06f8470-72f5-4280-be60-771812d853e1" });

            migrationBuilder.DeleteData(
                table: "UserTaskLists",
                keyColumns: new[] { "AppUserId", "TaskListId" },
                keyValues: new object[] { "41e26ad0-472e-4e2a-ac44-74fee9837fa7", "400759d2-60b2-42ed-a026-2bd318c859f3" });

            migrationBuilder.DeleteData(
                table: "UserTaskLists",
                keyColumns: new[] { "AppUserId", "TaskListId" },
                keyValues: new object[] { "41e26ad0-472e-4e2a-ac44-74fee9837fa7", "c06f8470-72f5-4280-be60-771812d853e1" });

            migrationBuilder.DeleteData(
                table: "UserTaskLists",
                keyColumns: new[] { "AppUserId", "TaskListId" },
                keyValues: new object[] { "91978fde-3e25-4fac-bff7-85b3d778fdbb", "400759d2-60b2-42ed-a026-2bd318c859f3" });

            migrationBuilder.DeleteData(
                table: "UserTaskLists",
                keyColumns: new[] { "AppUserId", "TaskListId" },
                keyValues: new object[] { "d7f4dd75-92a0-42c6-b608-442a73060ff2", "c06f8470-72f5-4280-be60-771812d853e1" });

            migrationBuilder.DeleteData(
                table: "UserWorkLogs",
                keyColumn: "Id",
                keyValue: "331fa9b4-e7c2-4b4b-beec-49f8320d85b1");

            migrationBuilder.DeleteData(
                table: "UserWorkLogs",
                keyColumn: "Id",
                keyValue: "d1368840-e0ff-4d0f-9b34-52190d93eea0");

            migrationBuilder.DeleteData(
                table: "WorkflowItems",
                keyColumn: "Id",
                keyValue: "1df56c23-d9b0-4fd4-b598-3d02a202d4ee");

            migrationBuilder.DeleteData(
                table: "WorkflowItems",
                keyColumn: "Id",
                keyValue: "3ef06ad5-5a2b-47bf-878f-add45ab6e43a");

            migrationBuilder.DeleteData(
                table: "WorkflowItems",
                keyColumn: "Id",
                keyValue: "49a6c827-aacb-44c5-85ca-3a04441e144e");

            migrationBuilder.DeleteData(
                table: "WorkflowItems",
                keyColumn: "Id",
                keyValue: "99a21b35-73d8-4852-8c06-99d2a2f26a1d");

            migrationBuilder.DeleteData(
                table: "WorkflowItems",
                keyColumn: "Id",
                keyValue: "bde566ce-7225-4b10-abef-bb84f8497642");

            migrationBuilder.DeleteData(
                table: "WorkflowItems",
                keyColumn: "Id",
                keyValue: "c7e953da-b66e-4c72-86bd-af498af4e718");

            migrationBuilder.DeleteData(
                table: "WorkflowItems",
                keyColumn: "Id",
                keyValue: "d2c9acbe-f2cb-4846-83ae-bc421cc3811d");

            migrationBuilder.DeleteData(
                table: "WorkflowItems",
                keyColumn: "Id",
                keyValue: "e3a1d385-86bd-4a4c-b325-66da658d9d4f");

            migrationBuilder.DeleteData(
                table: "WorkflowItems",
                keyColumn: "Id",
                keyValue: "ec84d927-3038-4b5a-bfe7-a97f341d1fb5");

            migrationBuilder.DeleteData(
                table: "WorkflowItems",
                keyColumn: "Id",
                keyValue: "f118a162-2ab2-48b0-800b-4fd2de4c645d");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "30b5ba9d-7faf-4658-a0c6-d7fc6c4f3168");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41e26ad0-472e-4e2a-ac44-74fee9837fa7");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "91978fde-3e25-4fac-bff7-85b3d778fdbb");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "d7f4dd75-92a0-42c6-b608-442a73060ff2");

            migrationBuilder.DeleteData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: "29ab1000-1808-47b0-b87d-fc7705e63dfb");

            migrationBuilder.DeleteData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: "45b7476a-78cd-440b-9b8e-c70af4fe5518");

            migrationBuilder.DeleteData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: "4bcd9bdb-5b1c-4f2a-add8-be3aaf35b259");

            migrationBuilder.DeleteData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: "5f14132c-1492-4df4-97c7-2651503e6e67");

            migrationBuilder.DeleteData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: "ffd952c2-ab75-4ade-88c1-d50b9606a772");

            migrationBuilder.DeleteData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: "400759d2-60b2-42ed-a026-2bd318c859f3");

            migrationBuilder.DeleteData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: "c06f8470-72f5-4280-be60-771812d853e1");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "Image", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "073b8b41-492d-4071-818d-b31342988f80", 0, "4ad9a820-898d-469e-a3eb-e5c4ec654158", "AppUser", "mike.jones@example.com", true, "Mike", "https://fastly.picsum.photos/id/256/200/200.jpg?hmac=MX3r8Dktr5b26lQqb5JB6sgLnCxSgt1KRm0F1eNDHCk", "Jones", false, null, "MIKE.JONES@EXAMPLE.COM", "MIKE.JONES", "AQAAAAEAACcQAAAAEHbmXSmxHp5fi2mdsHRvlVDnrJKbvmkrgjNiNFtuZ/mnEBlIEwPfHbmjYuTfCWYXJg==", null, false, "7669a288-d3ff-401a-b6ce-ab74f54ae11a", false, "mike.jones" },
                    { "8372e5a4-9518-442b-9fb2-2368325a9195", 0, "0a453dab-5be4-4180-a586-014d201c6601", "AppUser", "john.doe@example.com", true, "John", "https://fastly.picsum.photos/id/237/200/200.jpg?hmac=zHUGikXUDyLCCmvyww1izLK3R3k8oRYBRiTizZEdyfI", "Doe", false, null, "JOHN.DOE@EXAMPLE.COM", "JOHN.DOE", "AQAAAAEAACcQAAAAEOY1uW80PWa1U1HnG3MU7W4VGkVwUCRdtcfIR2lzLYKYnaoTxpYLjxA+DU8JTp9AjQ==", null, false, "7d500a96-3542-4448-a967-6ff5484363af", false, "john.doe" },
                    { "995dedc8-1872-4244-880e-d191fb126117", 0, "a2ff6f28-af7c-4e64-96f1-93298a329320", "AppUser", "sarah.smith@example.com", true, "Sarah", "https://fastly.picsum.photos/id/408/200/200.jpg?hmac=VJjKULX_XeyV5C9mbWyv6XTsG5EV-ZBsqbiQIi6xTeg", "Smith", false, null, "SARAH.SMITH@EXAMPLE.COM", "SARAH.SMITH", "AQAAAAEAACcQAAAAENOaUMVeqQnpLrqSUhCT9HTKAVHhRCV0rygTcVPudgrQe55ngkQkfuyd+K31NfymKA==", null, false, "d6dd061d-079d-4432-bd35-c53f2eb5fc19", false, "sarah.smith" },
                    { "ec52561d-6e4b-414c-bb51-85e9a2de219f", 0, "ea53857c-31bb-4cd2-89d6-1ccc64e2cb5f", "AppUser", "emily.williams@example.com", true, "Emily", "https://fastly.picsum.photos/id/916/200/200.jpg?hmac=hEUrLG-ayFdIoyHKUwazT8SMEsVxWH9xGz4tx-e0cN0", "Williams", false, null, "EMILY.WILLIAMS@EXAMPLE.COM", "EMILY.WILLIAMS", "AQAAAAEAACcQAAAAEAbUKSsfj2fgp48b+WVf5gQtQQG2uhtktHNnXUz4tkfZOls7D7PIoJ+uNYDE5X6plg==", null, false, "94974b30-eb4d-4416-b367-299a40cd607c", false, "emily.williams" }
                });

            migrationBuilder.InsertData(
                table: "TaskLists",
                columns: new[] { "Id", "CreatorId", "Description", "Name" },
                values: new object[,]
                {
                    { "1487c99c-e1d7-4af4-8a01-7e5bc425e95c", "995dedc8-1872-4244-880e-d191fb126117", "This list will contain management type tasks.", "Management tasks" },
                    { "f61321ff-c641-44bb-8f22-65b7c0f7151c", "8372e5a4-9518-442b-9fb2-2368325a9195", "This list will contain programming tasks.", "Programming tasks" }
                });

            migrationBuilder.InsertData(
                table: "TaskItems",
                columns: new[] { "Id", "AssigneeId", "CreatedAt", "CreatorId", "Deadline", "Details", "Estimated", "Priority", "TaskListId", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { "0c04fb22-ea80-4157-827d-cb564d011034", "8372e5a4-9518-442b-9fb2-2368325a9195", new DateTime(2024, 4, 30, 9, 55, 57, 422, DateTimeKind.Utc).AddTicks(9861), "8372e5a4-9518-442b-9fb2-2368325a9195", new DateTime(2024, 5, 4, 22, 0, 0, 0, DateTimeKind.Utc), "Finish writing the quarterly report for the management team.", 3f, 1, "f61321ff-c641-44bb-8f22-65b7c0f7151c", "Complete Report", new DateTime(2024, 4, 30, 9, 55, 57, 422, DateTimeKind.Utc).AddTicks(9861) },
                    { "3a299af2-13d8-414b-bfa0-0e885868bcb4", "ec52561d-6e4b-414c-bb51-85e9a2de219f", new DateTime(2024, 4, 30, 9, 55, 57, 422, DateTimeKind.Utc).AddTicks(9890), "995dedc8-1872-4244-880e-d191fb126117", new DateTime(2024, 5, 1, 22, 0, 0, 0, DateTimeKind.Utc), "Follow up with the client regarding their recent inquiries and provide necessary assistance.", 1f, 2, "1487c99c-e1d7-4af4-8a01-7e5bc425e95c", "Call Client", new DateTime(2024, 4, 30, 9, 55, 57, 422, DateTimeKind.Utc).AddTicks(9891) },
                    { "5abf1e04-7a51-428e-8313-64a501edc91c", "ec52561d-6e4b-414c-bb51-85e9a2de219f", new DateTime(2024, 4, 30, 9, 55, 57, 422, DateTimeKind.Utc).AddTicks(9915), "995dedc8-1872-4244-880e-d191fb126117", new DateTime(2024, 5, 3, 22, 0, 0, 0, DateTimeKind.Utc), "Coordinate a meeting with the project team to discuss the upcoming milestones and action items.", 2f, 2, "1487c99c-e1d7-4af4-8a01-7e5bc425e95c", "Schedule Meeting", new DateTime(2024, 4, 30, 9, 55, 57, 422, DateTimeKind.Utc).AddTicks(9916) },
                    { "60b06716-fbbf-4603-8f3f-23c4a479415e", "995dedc8-1872-4244-880e-d191fb126117", new DateTime(2024, 4, 30, 9, 55, 57, 422, DateTimeKind.Utc).AddTicks(9925), "995dedc8-1872-4244-880e-d191fb126117", new DateTime(2024, 5, 9, 22, 0, 0, 0, DateTimeKind.Utc), "Research current market trends and gather insights to inform strategic decisions for the next quarter.", 20f, 0, "1487c99c-e1d7-4af4-8a01-7e5bc425e95c", "Research Market Trends", new DateTime(2024, 4, 30, 9, 55, 57, 422, DateTimeKind.Utc).AddTicks(9926) },
                    { "61c8f6cf-4eae-4916-b125-96832c915164", "073b8b41-492d-4071-818d-b31342988f80", new DateTime(2024, 4, 30, 9, 55, 57, 422, DateTimeKind.Utc).AddTicks(9878), "8372e5a4-9518-442b-9fb2-2368325a9195", new DateTime(2024, 4, 30, 22, 0, 0, 0, DateTimeKind.Utc), "Conduct a thorough review of the recent code changes in the development branch and provide feedback.", 6f, 2, "f61321ff-c641-44bb-8f22-65b7c0f7151c", "Review Code Changes", new DateTime(2024, 4, 30, 9, 55, 57, 422, DateTimeKind.Utc).AddTicks(9878) }
                });

            migrationBuilder.InsertData(
                table: "UserTaskLists",
                columns: new[] { "AppUserId", "TaskListId" },
                values: new object[,]
                {
                    { "073b8b41-492d-4071-818d-b31342988f80", "f61321ff-c641-44bb-8f22-65b7c0f7151c" },
                    { "8372e5a4-9518-442b-9fb2-2368325a9195", "1487c99c-e1d7-4af4-8a01-7e5bc425e95c" },
                    { "8372e5a4-9518-442b-9fb2-2368325a9195", "f61321ff-c641-44bb-8f22-65b7c0f7151c" },
                    { "995dedc8-1872-4244-880e-d191fb126117", "1487c99c-e1d7-4af4-8a01-7e5bc425e95c" },
                    { "995dedc8-1872-4244-880e-d191fb126117", "f61321ff-c641-44bb-8f22-65b7c0f7151c" },
                    { "ec52561d-6e4b-414c-bb51-85e9a2de219f", "1487c99c-e1d7-4af4-8a01-7e5bc425e95c" }
                });

            migrationBuilder.InsertData(
                table: "UserWorkLogs",
                columns: new[] { "Id", "AppUserId", "LogDate", "TaskItemId", "WorkTime" },
                values: new object[,]
                {
                    { "526401b5-8d96-4ee6-99d0-52526c410fe3", "073b8b41-492d-4071-818d-b31342988f80", new DateTime(2024, 4, 30, 9, 55, 57, 423, DateTimeKind.Utc).AddTicks(69), "61c8f6cf-4eae-4916-b125-96832c915164", 72000000000L },
                    { "59044778-b5ed-468e-b91e-eee65dfb879e", "8372e5a4-9518-442b-9fb2-2368325a9195", new DateTime(2024, 4, 30, 9, 55, 57, 423, DateTimeKind.Utc).AddTicks(58), "0c04fb22-ea80-4157-827d-cb564d011034", 36000000000L }
                });

            migrationBuilder.InsertData(
                table: "WorkflowItems",
                columns: new[] { "Id", "IsActive", "IsDeletable", "Name", "Order", "TaskItemId" },
                values: new object[,]
                {
                    { "2b615adf-cb07-417d-9da9-3f738454c363", true, false, "To Do", 0, "3a299af2-13d8-414b-bfa0-0e885868bcb4" },
                    { "52bb6584-d3a4-413f-98ae-c81cdc082db2", false, false, "Done", 100, "60b06716-fbbf-4603-8f3f-23c4a479415e" },
                    { "5ad33c97-6441-4f63-baaa-4cfaba922a22", false, false, "Done", 100, "5abf1e04-7a51-428e-8313-64a501edc91c" },
                    { "61849373-e1ac-4906-8416-c1b2ea9ce7cc", false, false, "Done", 100, "61c8f6cf-4eae-4916-b125-96832c915164" },
                    { "8023a82c-9267-4236-bb1f-9a0883be164e", false, false, "Done", 100, "0c04fb22-ea80-4157-827d-cb564d011034" },
                    { "ba0619c5-6894-48ef-b675-368f8a3fd61e", true, false, "To Do", 0, "60b06716-fbbf-4603-8f3f-23c4a479415e" },
                    { "ccc9411e-73d5-4fcc-bb05-779a3912e0ee", true, false, "To Do", 0, "5abf1e04-7a51-428e-8313-64a501edc91c" },
                    { "e9c29d7f-fcb7-4d92-ad87-2f8c677e3dfb", true, false, "To Do", 0, "61c8f6cf-4eae-4916-b125-96832c915164" },
                    { "ed327d9b-155d-41d2-85c2-1556b2ed86d4", true, false, "To Do", 0, "0c04fb22-ea80-4157-827d-cb564d011034" },
                    { "f280826a-b731-4361-841c-2a5eeaaf2092", false, false, "Done", 100, "3a299af2-13d8-414b-bfa0-0e885868bcb4" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserTaskLists",
                keyColumns: new[] { "AppUserId", "TaskListId" },
                keyValues: new object[] { "073b8b41-492d-4071-818d-b31342988f80", "f61321ff-c641-44bb-8f22-65b7c0f7151c" });

            migrationBuilder.DeleteData(
                table: "UserTaskLists",
                keyColumns: new[] { "AppUserId", "TaskListId" },
                keyValues: new object[] { "8372e5a4-9518-442b-9fb2-2368325a9195", "1487c99c-e1d7-4af4-8a01-7e5bc425e95c" });

            migrationBuilder.DeleteData(
                table: "UserTaskLists",
                keyColumns: new[] { "AppUserId", "TaskListId" },
                keyValues: new object[] { "8372e5a4-9518-442b-9fb2-2368325a9195", "f61321ff-c641-44bb-8f22-65b7c0f7151c" });

            migrationBuilder.DeleteData(
                table: "UserTaskLists",
                keyColumns: new[] { "AppUserId", "TaskListId" },
                keyValues: new object[] { "995dedc8-1872-4244-880e-d191fb126117", "1487c99c-e1d7-4af4-8a01-7e5bc425e95c" });

            migrationBuilder.DeleteData(
                table: "UserTaskLists",
                keyColumns: new[] { "AppUserId", "TaskListId" },
                keyValues: new object[] { "995dedc8-1872-4244-880e-d191fb126117", "f61321ff-c641-44bb-8f22-65b7c0f7151c" });

            migrationBuilder.DeleteData(
                table: "UserTaskLists",
                keyColumns: new[] { "AppUserId", "TaskListId" },
                keyValues: new object[] { "ec52561d-6e4b-414c-bb51-85e9a2de219f", "1487c99c-e1d7-4af4-8a01-7e5bc425e95c" });

            migrationBuilder.DeleteData(
                table: "UserWorkLogs",
                keyColumn: "Id",
                keyValue: "526401b5-8d96-4ee6-99d0-52526c410fe3");

            migrationBuilder.DeleteData(
                table: "UserWorkLogs",
                keyColumn: "Id",
                keyValue: "59044778-b5ed-468e-b91e-eee65dfb879e");

            migrationBuilder.DeleteData(
                table: "WorkflowItems",
                keyColumn: "Id",
                keyValue: "2b615adf-cb07-417d-9da9-3f738454c363");

            migrationBuilder.DeleteData(
                table: "WorkflowItems",
                keyColumn: "Id",
                keyValue: "52bb6584-d3a4-413f-98ae-c81cdc082db2");

            migrationBuilder.DeleteData(
                table: "WorkflowItems",
                keyColumn: "Id",
                keyValue: "5ad33c97-6441-4f63-baaa-4cfaba922a22");

            migrationBuilder.DeleteData(
                table: "WorkflowItems",
                keyColumn: "Id",
                keyValue: "61849373-e1ac-4906-8416-c1b2ea9ce7cc");

            migrationBuilder.DeleteData(
                table: "WorkflowItems",
                keyColumn: "Id",
                keyValue: "8023a82c-9267-4236-bb1f-9a0883be164e");

            migrationBuilder.DeleteData(
                table: "WorkflowItems",
                keyColumn: "Id",
                keyValue: "ba0619c5-6894-48ef-b675-368f8a3fd61e");

            migrationBuilder.DeleteData(
                table: "WorkflowItems",
                keyColumn: "Id",
                keyValue: "ccc9411e-73d5-4fcc-bb05-779a3912e0ee");

            migrationBuilder.DeleteData(
                table: "WorkflowItems",
                keyColumn: "Id",
                keyValue: "e9c29d7f-fcb7-4d92-ad87-2f8c677e3dfb");

            migrationBuilder.DeleteData(
                table: "WorkflowItems",
                keyColumn: "Id",
                keyValue: "ed327d9b-155d-41d2-85c2-1556b2ed86d4");

            migrationBuilder.DeleteData(
                table: "WorkflowItems",
                keyColumn: "Id",
                keyValue: "f280826a-b731-4361-841c-2a5eeaaf2092");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "073b8b41-492d-4071-818d-b31342988f80");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8372e5a4-9518-442b-9fb2-2368325a9195");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "995dedc8-1872-4244-880e-d191fb126117");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ec52561d-6e4b-414c-bb51-85e9a2de219f");

            migrationBuilder.DeleteData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: "0c04fb22-ea80-4157-827d-cb564d011034");

            migrationBuilder.DeleteData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: "3a299af2-13d8-414b-bfa0-0e885868bcb4");

            migrationBuilder.DeleteData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: "5abf1e04-7a51-428e-8313-64a501edc91c");

            migrationBuilder.DeleteData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: "60b06716-fbbf-4603-8f3f-23c4a479415e");

            migrationBuilder.DeleteData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: "61c8f6cf-4eae-4916-b125-96832c915164");

            migrationBuilder.DeleteData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: "1487c99c-e1d7-4af4-8a01-7e5bc425e95c");

            migrationBuilder.DeleteData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: "f61321ff-c641-44bb-8f22-65b7c0f7151c");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "FirstName", "Image", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { "30b5ba9d-7faf-4658-a0c6-d7fc6c4f3168", 0, "dd54baed-d120-4621-b0b3-52f3c32368fe", "AppUser", "sarah.smith@example.com", true, "Sarah", "https://fastly.picsum.photos/id/408/200/200.jpg?hmac=VJjKULX_XeyV5C9mbWyv6XTsG5EV-ZBsqbiQIi6xTeg", "Smith", false, null, "SARAH.SMITH@EXAMPLE.COM", "SARAH.SMITH", "AQAAAAEAACcQAAAAEFW3DaCY8Uw/kBDx5fZGLmdU8ALHheb6iNGsGPYqqej7+JIIl7/QQYVbNXMywS1RQA==", null, false, "ce8ca5a5-14b3-4cd1-b088-9f457adeda65", false, "sarah.smith" },
                    { "41e26ad0-472e-4e2a-ac44-74fee9837fa7", 0, "9dd94ba0-04d9-4f3e-9581-9992743d3f26", "AppUser", "john.doe@example.com", true, "John", "https://fastly.picsum.photos/id/237/200/200.jpg?hmac=zHUGikXUDyLCCmvyww1izLK3R3k8oRYBRiTizZEdyfI", "Doe", false, null, "JOHN.DOE@EXAMPLE.COM", "JOHN.DOE", "AQAAAAEAACcQAAAAEFNNa/wO/qmDWrNqJPLsqFgzAXxO0OcU7Zljrt4ObhceKmV2IIKogx8cevw/9xBiGQ==", null, false, "81e2a773-4f36-4318-812f-486d174f359e", false, "john.doe" },
                    { "91978fde-3e25-4fac-bff7-85b3d778fdbb", 0, "3550f689-3bfc-4d6c-9110-4ca6835cf90f", "AppUser", "mike.jones@example.com", true, "Mike", "https://fastly.picsum.photos/id/256/200/200.jpg?hmac=MX3r8Dktr5b26lQqb5JB6sgLnCxSgt1KRm0F1eNDHCk", "Jones", false, null, "MIKE.JONES@EXAMPLE.COM", "MIKE.JONES", "AQAAAAEAACcQAAAAEDxcWla205USYGPzYTXzEW8HiTZxIO63sSU1Ae30OEDmv34thsiKzj63AZtTfrclIA==", null, false, "1ca737ea-115c-4c54-bb11-4551f526b9a5", false, "mike.jones" },
                    { "d7f4dd75-92a0-42c6-b608-442a73060ff2", 0, "1ec9a55a-d2ab-4962-b2ab-c35fe6d36537", "AppUser", "emily.williams@example.com", true, "Emily", "https://fastly.picsum.photos/id/916/200/200.jpg?hmac=hEUrLG-ayFdIoyHKUwazT8SMEsVxWH9xGz4tx-e0cN0", "Williams", false, null, "EMILY.WILLIAMS@EXAMPLE.COM", "EMILY.WILLIAMS", "AQAAAAEAACcQAAAAEFWaUfrxe/sLfzfn0ABhHYl03f4eJ8x1jjWDY90ncZ8Pk4v1uogTGvCAYhEv11IrxA==", null, false, "604a0167-c5d0-419a-89b4-0dfc64eef478", false, "emily.williams" }
                });

            migrationBuilder.InsertData(
                table: "TaskLists",
                columns: new[] { "Id", "CreatorId", "Description", "Name" },
                values: new object[,]
                {
                    { "400759d2-60b2-42ed-a026-2bd318c859f3", "41e26ad0-472e-4e2a-ac44-74fee9837fa7", "This list will contain programming tasks.", "Programming tasks" },
                    { "c06f8470-72f5-4280-be60-771812d853e1", "30b5ba9d-7faf-4658-a0c6-d7fc6c4f3168", "This list will contain management type tasks.", "Management tasks" }
                });

            migrationBuilder.InsertData(
                table: "TaskItems",
                columns: new[] { "Id", "AssigneeId", "CreatedAt", "CreatorId", "Deadline", "Details", "Estimated", "Priority", "TaskListId", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { "29ab1000-1808-47b0-b87d-fc7705e63dfb", "d7f4dd75-92a0-42c6-b608-442a73060ff2", new DateTime(2024, 4, 30, 9, 54, 30, 181, DateTimeKind.Utc).AddTicks(8303), "30b5ba9d-7faf-4658-a0c6-d7fc6c4f3168", new DateTime(2024, 5, 3, 22, 0, 0, 0, DateTimeKind.Utc), "Coordinate a meeting with the project team to discuss the upcoming milestones and action items.", 2f, 2, "c06f8470-72f5-4280-be60-771812d853e1", "Schedule Meeting", new DateTime(2024, 4, 30, 9, 54, 30, 181, DateTimeKind.Utc).AddTicks(8304) },
                    { "45b7476a-78cd-440b-9b8e-c70af4fe5518", "41e26ad0-472e-4e2a-ac44-74fee9837fa7", new DateTime(2024, 4, 30, 9, 54, 30, 181, DateTimeKind.Utc).AddTicks(8201), "41e26ad0-472e-4e2a-ac44-74fee9837fa7", new DateTime(2024, 5, 5, 0, 0, 0, 0, DateTimeKind.Utc), "Finish writing the quarterly report for the management team.", 3f, 1, "400759d2-60b2-42ed-a026-2bd318c859f3", "Complete Report", new DateTime(2024, 4, 30, 9, 54, 30, 181, DateTimeKind.Utc).AddTicks(8202) },
                    { "4bcd9bdb-5b1c-4f2a-add8-be3aaf35b259", "91978fde-3e25-4fac-bff7-85b3d778fdbb", new DateTime(2024, 4, 30, 9, 54, 30, 181, DateTimeKind.Utc).AddTicks(8209), "41e26ad0-472e-4e2a-ac44-74fee9837fa7", new DateTime(2024, 5, 1, 0, 0, 0, 0, DateTimeKind.Utc), "Conduct a thorough review of the recent code changes in the development branch and provide feedback.", 6f, 2, "400759d2-60b2-42ed-a026-2bd318c859f3", "Review Code Changes", new DateTime(2024, 4, 30, 9, 54, 30, 181, DateTimeKind.Utc).AddTicks(8210) },
                    { "5f14132c-1492-4df4-97c7-2651503e6e67", "30b5ba9d-7faf-4658-a0c6-d7fc6c4f3168", new DateTime(2024, 4, 30, 9, 54, 30, 181, DateTimeKind.Utc).AddTicks(8309), "30b5ba9d-7faf-4658-a0c6-d7fc6c4f3168", new DateTime(2024, 5, 10, 0, 0, 0, 0, DateTimeKind.Utc), "Research current market trends and gather insights to inform strategic decisions for the next quarter.", 20f, 0, "c06f8470-72f5-4280-be60-771812d853e1", "Research Market Trends", new DateTime(2024, 4, 30, 9, 54, 30, 181, DateTimeKind.Utc).AddTicks(8309) },
                    { "ffd952c2-ab75-4ade-88c1-d50b9606a772", "d7f4dd75-92a0-42c6-b608-442a73060ff2", new DateTime(2024, 4, 30, 9, 54, 30, 181, DateTimeKind.Utc).AddTicks(8215), "30b5ba9d-7faf-4658-a0c6-d7fc6c4f3168", new DateTime(2024, 5, 2, 0, 0, 0, 0, DateTimeKind.Utc), "Follow up with the client regarding their recent inquiries and provide necessary assistance.", 1f, 2, "c06f8470-72f5-4280-be60-771812d853e1", "Call Client", new DateTime(2024, 4, 30, 9, 54, 30, 181, DateTimeKind.Utc).AddTicks(8216) }
                });

            migrationBuilder.InsertData(
                table: "UserTaskLists",
                columns: new[] { "AppUserId", "TaskListId" },
                values: new object[,]
                {
                    { "30b5ba9d-7faf-4658-a0c6-d7fc6c4f3168", "400759d2-60b2-42ed-a026-2bd318c859f3" },
                    { "30b5ba9d-7faf-4658-a0c6-d7fc6c4f3168", "c06f8470-72f5-4280-be60-771812d853e1" },
                    { "41e26ad0-472e-4e2a-ac44-74fee9837fa7", "400759d2-60b2-42ed-a026-2bd318c859f3" },
                    { "41e26ad0-472e-4e2a-ac44-74fee9837fa7", "c06f8470-72f5-4280-be60-771812d853e1" },
                    { "91978fde-3e25-4fac-bff7-85b3d778fdbb", "400759d2-60b2-42ed-a026-2bd318c859f3" },
                    { "d7f4dd75-92a0-42c6-b608-442a73060ff2", "c06f8470-72f5-4280-be60-771812d853e1" }
                });

            migrationBuilder.InsertData(
                table: "UserWorkLogs",
                columns: new[] { "Id", "AppUserId", "LogDate", "TaskItemId", "WorkTime" },
                values: new object[,]
                {
                    { "331fa9b4-e7c2-4b4b-beec-49f8320d85b1", "41e26ad0-472e-4e2a-ac44-74fee9837fa7", new DateTime(2024, 4, 30, 9, 54, 30, 181, DateTimeKind.Utc).AddTicks(8476), "45b7476a-78cd-440b-9b8e-c70af4fe5518", 36000000000L },
                    { "d1368840-e0ff-4d0f-9b34-52190d93eea0", "91978fde-3e25-4fac-bff7-85b3d778fdbb", new DateTime(2024, 4, 30, 9, 54, 30, 181, DateTimeKind.Utc).AddTicks(8482), "4bcd9bdb-5b1c-4f2a-add8-be3aaf35b259", 72000000000L }
                });

            migrationBuilder.InsertData(
                table: "WorkflowItems",
                columns: new[] { "Id", "IsActive", "IsDeletable", "Name", "Order", "TaskItemId" },
                values: new object[,]
                {
                    { "1df56c23-d9b0-4fd4-b598-3d02a202d4ee", false, false, "Done", 100, "5f14132c-1492-4df4-97c7-2651503e6e67" },
                    { "3ef06ad5-5a2b-47bf-878f-add45ab6e43a", true, false, "To Do", 0, "ffd952c2-ab75-4ade-88c1-d50b9606a772" },
                    { "49a6c827-aacb-44c5-85ca-3a04441e144e", true, false, "To Do", 0, "4bcd9bdb-5b1c-4f2a-add8-be3aaf35b259" },
                    { "99a21b35-73d8-4852-8c06-99d2a2f26a1d", true, false, "To Do", 0, "29ab1000-1808-47b0-b87d-fc7705e63dfb" },
                    { "bde566ce-7225-4b10-abef-bb84f8497642", true, false, "To Do", 0, "45b7476a-78cd-440b-9b8e-c70af4fe5518" },
                    { "c7e953da-b66e-4c72-86bd-af498af4e718", false, false, "Done", 100, "45b7476a-78cd-440b-9b8e-c70af4fe5518" },
                    { "d2c9acbe-f2cb-4846-83ae-bc421cc3811d", false, false, "Done", 100, "ffd952c2-ab75-4ade-88c1-d50b9606a772" },
                    { "e3a1d385-86bd-4a4c-b325-66da658d9d4f", false, false, "Done", 100, "4bcd9bdb-5b1c-4f2a-add8-be3aaf35b259" },
                    { "ec84d927-3038-4b5a-bfe7-a97f341d1fb5", true, false, "To Do", 0, "5f14132c-1492-4df4-97c7-2651503e6e67" },
                    { "f118a162-2ab2-48b0-800b-4fd2de4c645d", false, false, "Done", 100, "29ab1000-1808-47b0-b87d-fc7705e63dfb" }
                });
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    public partial class dbreseedupdate4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "1b4e5e8e-9a5a-45c8-b3d7-26a06aa64df6", 0, "de24979c-07b8-4db5-9da7-4727d2d3df40", "AppUser", "emily.williams@example.com", true, "Emily", "https://fastly.picsum.photos/id/916/200/200.jpg?hmac=hEUrLG-ayFdIoyHKUwazT8SMEsVxWH9xGz4tx-e0cN0", "Williams", false, null, "EMILY.WILLIAMS@EXAMPLE.COM", "EMILY.WILLIAMS", "AQAAAAEAACcQAAAAEMxzAjtIpYIqaEHEjhlqJW23NUMMlwtD1QZHpyktxeKABnAYAl6AM83zkuONHkEwvA==", null, false, "c260b5ed-b4ee-441c-b7d4-2a9282fa1683", false, "emily.williams" },
                    { "41cb914a-6181-4ed4-9c13-e1127f23649b", 0, "15bc58df-2bca-4114-9aab-0ab0073d4a6f", "AppUser", "john.doe@example.com", true, "John", "https://fastly.picsum.photos/id/237/200/200.jpg?hmac=zHUGikXUDyLCCmvyww1izLK3R3k8oRYBRiTizZEdyfI", "Doe", false, null, "JOHN.DOE@EXAMPLE.COM", "JOHN.DOE", "AQAAAAEAACcQAAAAEN9yHa97d5a1rlnW6psPtIBor7vldgYv70fIpqVKRjfKWq2WdO8se7/TsXjlS8BkSA==", null, false, "44458690-c32a-4727-a86b-98d4fc37f795", false, "john.doe" },
                    { "8014824c-2c7d-4fb4-8f8e-ccb98dc32175", 0, "0094a5e1-83ad-4542-b595-f981344e7234", "AppUser", "mike.jones@example.com", true, "Mike", "https://fastly.picsum.photos/id/256/200/200.jpg?hmac=MX3r8Dktr5b26lQqb5JB6sgLnCxSgt1KRm0F1eNDHCk", "Jones", false, null, "MIKE.JONES@EXAMPLE.COM", "MIKE.JONES", "AQAAAAEAACcQAAAAEAo6jDwztzJMfOf5BfQoHj+ECl51H2jmCywZ3g88yoS9ew9/AUSb7OQ/dR3kHDHRnA==", null, false, "f76b2db0-5032-4f5e-b399-0eafeb3099f9", false, "mike.jones" },
                    { "c7564854-eae4-41bc-b4bc-d9ed0758ba92", 0, "9cb36b07-0c13-4608-8548-eef3f823fd45", "AppUser", "sarah.smith@example.com", true, "Sarah", "https://fastly.picsum.photos/id/408/200/200.jpg?hmac=VJjKULX_XeyV5C9mbWyv6XTsG5EV-ZBsqbiQIi6xTeg", "Smith", false, null, "SARAH.SMITH@EXAMPLE.COM", "SARAH.SMITH", "AQAAAAEAACcQAAAAEAkxl8W68SJs8QS8isa1BeJZtCqVSOB5tlsB/rA8J1w4e0Lp3i5td7c3j0Em+bZCeQ==", null, false, "f54afd03-6441-4023-9e89-d145881f3918", false, "sarah.smith" }
                });

            migrationBuilder.InsertData(
                table: "TaskLists",
                columns: new[] { "Id", "CreatorId", "Description", "Name" },
                values: new object[,]
                {
                    { "3d4c6254-b3bc-4026-b39d-15f7ecc26c0d", "41cb914a-6181-4ed4-9c13-e1127f23649b", "This list will contain programming tasks.", "Programming tasks" },
                    { "b97beeee-4450-4348-afd7-c327ac086e6d", "c7564854-eae4-41bc-b4bc-d9ed0758ba92", "This list will contain management type tasks.", "Management tasks" }
                });

            migrationBuilder.InsertData(
                table: "TaskItems",
                columns: new[] { "Id", "AssigneeId", "CreatedAt", "CreatorId", "Deadline", "Details", "Estimated", "Priority", "TaskListId", "Title", "UpdatedAt" },
                values: new object[,]
                {
                    { "09a508e7-e6f5-4276-ad14-632de29ab5cf", "c7564854-eae4-41bc-b4bc-d9ed0758ba92", new DateTime(2024, 4, 30, 10, 6, 27, 962, DateTimeKind.Utc).AddTicks(5445), "c7564854-eae4-41bc-b4bc-d9ed0758ba92", new DateTime(2024, 5, 9, 22, 0, 0, 0, DateTimeKind.Utc), "Research current market trends and gather insights to inform strategic decisions for the next quarter.", 20f, 0, "b97beeee-4450-4348-afd7-c327ac086e6d", "Research Market Trends", new DateTime(2024, 4, 30, 10, 6, 27, 962, DateTimeKind.Utc).AddTicks(5446) },
                    { "6d384a1c-93e1-47c6-b1e7-6da3bb3acfdd", "8014824c-2c7d-4fb4-8f8e-ccb98dc32175", new DateTime(2024, 4, 30, 10, 6, 27, 962, DateTimeKind.Utc).AddTicks(5422), "41cb914a-6181-4ed4-9c13-e1127f23649b", new DateTime(2024, 4, 30, 22, 0, 0, 0, DateTimeKind.Utc), "Conduct a thorough review of the recent code changes in the development branch and provide feedback.", 6f, 2, "3d4c6254-b3bc-4026-b39d-15f7ecc26c0d", "Review Code Changes", new DateTime(2024, 4, 30, 10, 6, 27, 962, DateTimeKind.Utc).AddTicks(5422) },
                    { "7c0e3772-7de1-4ca3-a2c1-6dd6f19c8532", "1b4e5e8e-9a5a-45c8-b3d7-26a06aa64df6", new DateTime(2024, 4, 30, 10, 6, 27, 962, DateTimeKind.Utc).AddTicks(5438), "c7564854-eae4-41bc-b4bc-d9ed0758ba92", new DateTime(2024, 5, 3, 22, 0, 0, 0, DateTimeKind.Utc), "Coordinate a meeting with the project team to discuss the upcoming milestones and action items.", 2f, 2, "b97beeee-4450-4348-afd7-c327ac086e6d", "Schedule Meeting", new DateTime(2024, 4, 30, 10, 6, 27, 962, DateTimeKind.Utc).AddTicks(5438) },
                    { "7d62e7e9-fb02-43e4-bda6-a63df8a3d356", "41cb914a-6181-4ed4-9c13-e1127f23649b", new DateTime(2024, 4, 30, 10, 6, 27, 962, DateTimeKind.Utc).AddTicks(5408), "41cb914a-6181-4ed4-9c13-e1127f23649b", new DateTime(2024, 5, 4, 22, 0, 0, 0, DateTimeKind.Utc), "Finish writing the quarterly report for the management team.", 3f, 1, "3d4c6254-b3bc-4026-b39d-15f7ecc26c0d", "Complete Report", new DateTime(2024, 4, 30, 10, 6, 27, 962, DateTimeKind.Utc).AddTicks(5409) },
                    { "fe40ba57-2f09-4958-b380-9d68998aa9b2", "1b4e5e8e-9a5a-45c8-b3d7-26a06aa64df6", new DateTime(2024, 4, 30, 10, 6, 27, 962, DateTimeKind.Utc).AddTicks(5430), "c7564854-eae4-41bc-b4bc-d9ed0758ba92", new DateTime(2024, 5, 1, 22, 0, 0, 0, DateTimeKind.Utc), "Follow up with the client regarding their recent inquiries and provide necessary assistance.", 1f, 2, "b97beeee-4450-4348-afd7-c327ac086e6d", "Call Client", new DateTime(2024, 4, 30, 10, 6, 27, 962, DateTimeKind.Utc).AddTicks(5430) }
                });

            migrationBuilder.InsertData(
                table: "UserTaskLists",
                columns: new[] { "AppUserId", "TaskListId" },
                values: new object[,]
                {
                    { "1b4e5e8e-9a5a-45c8-b3d7-26a06aa64df6", "b97beeee-4450-4348-afd7-c327ac086e6d" },
                    { "41cb914a-6181-4ed4-9c13-e1127f23649b", "3d4c6254-b3bc-4026-b39d-15f7ecc26c0d" },
                    { "41cb914a-6181-4ed4-9c13-e1127f23649b", "b97beeee-4450-4348-afd7-c327ac086e6d" },
                    { "8014824c-2c7d-4fb4-8f8e-ccb98dc32175", "3d4c6254-b3bc-4026-b39d-15f7ecc26c0d" },
                    { "c7564854-eae4-41bc-b4bc-d9ed0758ba92", "3d4c6254-b3bc-4026-b39d-15f7ecc26c0d" },
                    { "c7564854-eae4-41bc-b4bc-d9ed0758ba92", "b97beeee-4450-4348-afd7-c327ac086e6d" }
                });

            migrationBuilder.InsertData(
                table: "UserWorkLogs",
                columns: new[] { "Id", "AppUserId", "LogDate", "TaskItemId", "WorkTime" },
                values: new object[,]
                {
                    { "455b36fb-15c2-48f4-9e0e-e05f23b9050e", "41cb914a-6181-4ed4-9c13-e1127f23649b", new DateTime(2024, 4, 30, 10, 6, 27, 962, DateTimeKind.Utc).AddTicks(5526), "7d62e7e9-fb02-43e4-bda6-a63df8a3d356", 36000000000L },
                    { "8186e32b-d96c-4b0f-a6e3-2d171616b79c", "8014824c-2c7d-4fb4-8f8e-ccb98dc32175", new DateTime(2024, 4, 30, 10, 6, 27, 962, DateTimeKind.Utc).AddTicks(5531), "6d384a1c-93e1-47c6-b1e7-6da3bb3acfdd", 72000000000L },
                    { "fd9ff94c-22e8-4799-bfa7-7c9f0558cf0f", "41cb914a-6181-4ed4-9c13-e1127f23649b", new DateTime(2024, 4, 22, 10, 6, 27, 962, DateTimeKind.Utc).AddTicks(5564), "7d62e7e9-fb02-43e4-bda6-a63df8a3d356", 180000000000L }
                });

            migrationBuilder.InsertData(
                table: "WorkflowItems",
                columns: new[] { "Id", "IsActive", "IsDeletable", "Name", "Order", "TaskItemId" },
                values: new object[,]
                {
                    { "028ee1f6-b542-4faf-8496-1edefb5c6642", true, false, "To Do", 0, "6d384a1c-93e1-47c6-b1e7-6da3bb3acfdd" },
                    { "2d74c080-6f2d-429b-999c-56885ea8afa8", true, false, "To Do", 0, "fe40ba57-2f09-4958-b380-9d68998aa9b2" },
                    { "32095be3-f765-4984-8f17-ab1d7310956c", false, false, "Done", 100, "09a508e7-e6f5-4276-ad14-632de29ab5cf" },
                    { "41de2c77-619b-4796-9f61-5188f8c0f5e9", false, false, "Done", 100, "7d62e7e9-fb02-43e4-bda6-a63df8a3d356" },
                    { "62996b8d-7e40-41bc-8ab6-2232505941fb", true, false, "To Do", 0, "7c0e3772-7de1-4ca3-a2c1-6dd6f19c8532" },
                    { "899a12b2-2312-4bfc-827c-6fa7588d0b07", false, false, "Done", 100, "6d384a1c-93e1-47c6-b1e7-6da3bb3acfdd" },
                    { "af85af69-94cc-4324-8377-202d91bbc7b1", true, false, "To Do", 0, "09a508e7-e6f5-4276-ad14-632de29ab5cf" },
                    { "c4c69cbf-db55-4202-9321-e70f94cee9c4", false, false, "Done", 100, "fe40ba57-2f09-4958-b380-9d68998aa9b2" },
                    { "cb597947-b9eb-4295-9f1b-815d6b960fb6", false, false, "Done", 100, "7c0e3772-7de1-4ca3-a2c1-6dd6f19c8532" },
                    { "f5d81bc2-847b-4771-9a94-34ba9f32aa44", true, false, "To Do", 0, "7d62e7e9-fb02-43e4-bda6-a63df8a3d356" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserTaskLists",
                keyColumns: new[] { "AppUserId", "TaskListId" },
                keyValues: new object[] { "1b4e5e8e-9a5a-45c8-b3d7-26a06aa64df6", "b97beeee-4450-4348-afd7-c327ac086e6d" });

            migrationBuilder.DeleteData(
                table: "UserTaskLists",
                keyColumns: new[] { "AppUserId", "TaskListId" },
                keyValues: new object[] { "41cb914a-6181-4ed4-9c13-e1127f23649b", "3d4c6254-b3bc-4026-b39d-15f7ecc26c0d" });

            migrationBuilder.DeleteData(
                table: "UserTaskLists",
                keyColumns: new[] { "AppUserId", "TaskListId" },
                keyValues: new object[] { "41cb914a-6181-4ed4-9c13-e1127f23649b", "b97beeee-4450-4348-afd7-c327ac086e6d" });

            migrationBuilder.DeleteData(
                table: "UserTaskLists",
                keyColumns: new[] { "AppUserId", "TaskListId" },
                keyValues: new object[] { "8014824c-2c7d-4fb4-8f8e-ccb98dc32175", "3d4c6254-b3bc-4026-b39d-15f7ecc26c0d" });

            migrationBuilder.DeleteData(
                table: "UserTaskLists",
                keyColumns: new[] { "AppUserId", "TaskListId" },
                keyValues: new object[] { "c7564854-eae4-41bc-b4bc-d9ed0758ba92", "3d4c6254-b3bc-4026-b39d-15f7ecc26c0d" });

            migrationBuilder.DeleteData(
                table: "UserTaskLists",
                keyColumns: new[] { "AppUserId", "TaskListId" },
                keyValues: new object[] { "c7564854-eae4-41bc-b4bc-d9ed0758ba92", "b97beeee-4450-4348-afd7-c327ac086e6d" });

            migrationBuilder.DeleteData(
                table: "UserWorkLogs",
                keyColumn: "Id",
                keyValue: "455b36fb-15c2-48f4-9e0e-e05f23b9050e");

            migrationBuilder.DeleteData(
                table: "UserWorkLogs",
                keyColumn: "Id",
                keyValue: "8186e32b-d96c-4b0f-a6e3-2d171616b79c");

            migrationBuilder.DeleteData(
                table: "UserWorkLogs",
                keyColumn: "Id",
                keyValue: "fd9ff94c-22e8-4799-bfa7-7c9f0558cf0f");

            migrationBuilder.DeleteData(
                table: "WorkflowItems",
                keyColumn: "Id",
                keyValue: "028ee1f6-b542-4faf-8496-1edefb5c6642");

            migrationBuilder.DeleteData(
                table: "WorkflowItems",
                keyColumn: "Id",
                keyValue: "2d74c080-6f2d-429b-999c-56885ea8afa8");

            migrationBuilder.DeleteData(
                table: "WorkflowItems",
                keyColumn: "Id",
                keyValue: "32095be3-f765-4984-8f17-ab1d7310956c");

            migrationBuilder.DeleteData(
                table: "WorkflowItems",
                keyColumn: "Id",
                keyValue: "41de2c77-619b-4796-9f61-5188f8c0f5e9");

            migrationBuilder.DeleteData(
                table: "WorkflowItems",
                keyColumn: "Id",
                keyValue: "62996b8d-7e40-41bc-8ab6-2232505941fb");

            migrationBuilder.DeleteData(
                table: "WorkflowItems",
                keyColumn: "Id",
                keyValue: "899a12b2-2312-4bfc-827c-6fa7588d0b07");

            migrationBuilder.DeleteData(
                table: "WorkflowItems",
                keyColumn: "Id",
                keyValue: "af85af69-94cc-4324-8377-202d91bbc7b1");

            migrationBuilder.DeleteData(
                table: "WorkflowItems",
                keyColumn: "Id",
                keyValue: "c4c69cbf-db55-4202-9321-e70f94cee9c4");

            migrationBuilder.DeleteData(
                table: "WorkflowItems",
                keyColumn: "Id",
                keyValue: "cb597947-b9eb-4295-9f1b-815d6b960fb6");

            migrationBuilder.DeleteData(
                table: "WorkflowItems",
                keyColumn: "Id",
                keyValue: "f5d81bc2-847b-4771-9a94-34ba9f32aa44");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1b4e5e8e-9a5a-45c8-b3d7-26a06aa64df6");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "41cb914a-6181-4ed4-9c13-e1127f23649b");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8014824c-2c7d-4fb4-8f8e-ccb98dc32175");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c7564854-eae4-41bc-b4bc-d9ed0758ba92");

            migrationBuilder.DeleteData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: "09a508e7-e6f5-4276-ad14-632de29ab5cf");

            migrationBuilder.DeleteData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: "6d384a1c-93e1-47c6-b1e7-6da3bb3acfdd");

            migrationBuilder.DeleteData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: "7c0e3772-7de1-4ca3-a2c1-6dd6f19c8532");

            migrationBuilder.DeleteData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: "7d62e7e9-fb02-43e4-bda6-a63df8a3d356");

            migrationBuilder.DeleteData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: "fe40ba57-2f09-4958-b380-9d68998aa9b2");

            migrationBuilder.DeleteData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: "3d4c6254-b3bc-4026-b39d-15f7ecc26c0d");

            migrationBuilder.DeleteData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: "b97beeee-4450-4348-afd7-c327ac086e6d");

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
    }
}

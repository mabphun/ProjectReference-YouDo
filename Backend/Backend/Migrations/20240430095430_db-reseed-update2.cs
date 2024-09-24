using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    public partial class dbreseedupdate2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserTaskLists",
                keyColumns: new[] { "AppUserId", "TaskListId" },
                keyValues: new object[] { "6007eeb4-4568-487f-8efb-8543290591ed", "b7b9375f-143c-4403-b8bf-efe753fd98ee" });

            migrationBuilder.DeleteData(
                table: "UserTaskLists",
                keyColumns: new[] { "AppUserId", "TaskListId" },
                keyValues: new object[] { "7aa6b375-c7e4-4229-8edd-abaf8b1e1bd3", "0cb29329-e2c4-4ede-ad95-8e52a86a9f42" });

            migrationBuilder.DeleteData(
                table: "UserTaskLists",
                keyColumns: new[] { "AppUserId", "TaskListId" },
                keyValues: new object[] { "7aa6b375-c7e4-4229-8edd-abaf8b1e1bd3", "b7b9375f-143c-4403-b8bf-efe753fd98ee" });

            migrationBuilder.DeleteData(
                table: "UserTaskLists",
                keyColumns: new[] { "AppUserId", "TaskListId" },
                keyValues: new object[] { "a142e4bc-e727-4e31-90ee-099c53851b70", "0cb29329-e2c4-4ede-ad95-8e52a86a9f42" });

            migrationBuilder.DeleteData(
                table: "UserTaskLists",
                keyColumns: new[] { "AppUserId", "TaskListId" },
                keyValues: new object[] { "ba09fe5b-d803-4b28-a18f-bf61b3fad4f1", "0cb29329-e2c4-4ede-ad95-8e52a86a9f42" });

            migrationBuilder.DeleteData(
                table: "UserTaskLists",
                keyColumns: new[] { "AppUserId", "TaskListId" },
                keyValues: new object[] { "ba09fe5b-d803-4b28-a18f-bf61b3fad4f1", "b7b9375f-143c-4403-b8bf-efe753fd98ee" });

            migrationBuilder.DeleteData(
                table: "UserWorkLogs",
                keyColumn: "Id",
                keyValue: "09ff9b61-5665-4f8d-adcd-20adba1e7bab");

            migrationBuilder.DeleteData(
                table: "UserWorkLogs",
                keyColumn: "Id",
                keyValue: "b5a8a977-809b-4d60-9899-97afbe0b064f");

            migrationBuilder.DeleteData(
                table: "WorkflowItems",
                keyColumn: "Id",
                keyValue: "22dbe941-682d-49c3-bc8b-f765dfa41769");

            migrationBuilder.DeleteData(
                table: "WorkflowItems",
                keyColumn: "Id",
                keyValue: "282213fb-5fad-4473-8392-04ba79d2eb01");

            migrationBuilder.DeleteData(
                table: "WorkflowItems",
                keyColumn: "Id",
                keyValue: "4446a567-690f-4c8a-80b4-19db3c3ef522");

            migrationBuilder.DeleteData(
                table: "WorkflowItems",
                keyColumn: "Id",
                keyValue: "4b695506-757a-406a-bd21-38f4efc9068a");

            migrationBuilder.DeleteData(
                table: "WorkflowItems",
                keyColumn: "Id",
                keyValue: "74f085f5-9017-4bbe-a976-2f67924e66f8");

            migrationBuilder.DeleteData(
                table: "WorkflowItems",
                keyColumn: "Id",
                keyValue: "83adcd97-b112-4a25-a304-195f350fc191");

            migrationBuilder.DeleteData(
                table: "WorkflowItems",
                keyColumn: "Id",
                keyValue: "923fa8ae-c245-411a-9ab2-7c17d58fc722");

            migrationBuilder.DeleteData(
                table: "WorkflowItems",
                keyColumn: "Id",
                keyValue: "a7c281b4-f9fc-4f80-b85a-82366cb9cb5e");

            migrationBuilder.DeleteData(
                table: "WorkflowItems",
                keyColumn: "Id",
                keyValue: "c1eb92c5-36c7-4f34-a8cd-6790f3366486");

            migrationBuilder.DeleteData(
                table: "WorkflowItems",
                keyColumn: "Id",
                keyValue: "e4fadc1b-5dc6-4c85-b496-9c2240036a11");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6007eeb4-4568-487f-8efb-8543290591ed");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7aa6b375-c7e4-4229-8edd-abaf8b1e1bd3");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a142e4bc-e727-4e31-90ee-099c53851b70");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ba09fe5b-d803-4b28-a18f-bf61b3fad4f1");

            migrationBuilder.DeleteData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: "0c429c0a-c498-428e-ad7a-13a0dcf25395");

            migrationBuilder.DeleteData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: "7410025a-0b45-4e29-98b2-49c8f39d7bfb");

            migrationBuilder.DeleteData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: "773b26c7-544e-4ca3-b0b5-f2096e87a491");

            migrationBuilder.DeleteData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: "79bbcea0-e6ce-4d6a-a9f3-c7db24bf4dcd");

            migrationBuilder.DeleteData(
                table: "TaskItems",
                keyColumn: "Id",
                keyValue: "d2fd8100-c959-4562-b0f6-590044a82e7d");

            migrationBuilder.DeleteData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: "0cb29329-e2c4-4ede-ad95-8e52a86a9f42");

            migrationBuilder.DeleteData(
                table: "TaskLists",
                keyColumn: "Id",
                keyValue: "b7b9375f-143c-4403-b8bf-efe753fd98ee");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
        }
    }
}

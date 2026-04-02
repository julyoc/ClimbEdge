using System;
using System.Net;
using ClimbEdge.Domain.Shared;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClimbEdge.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class add_all_models : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserProfile_Country",
                table: "UserProfile");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "UserProfile",
                newName: "Address_Country");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "UserProfile",
                newName: "Address_Reference");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:postgis", ",,");

            migrationBuilder.AddColumn<string>(
                name: "Address_City",
                table: "UserProfile",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_State",
                table: "UserProfile",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string[]>(
                name: "Address_Street",
                table: "UserProfile",
                type: "text[]",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_ZipCode",
                table: "UserProfile",
                type: "character varying(20)",
                maxLength: 20,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AIModel",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Version = table.Column<string>(type: "text", nullable: false),
                    Parameters = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    ModelSize = table.Column<long>(type: "bigint", nullable: true),
                    TrainingDataSize = table.Column<long>(type: "bigint", nullable: true),
                    AccuracyScore = table.Column<decimal>(type: "numeric", nullable: true),
                    LastTrainedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeployedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ResourceRequirements = table.Column<string>(type: "text", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AIModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AuditTrail",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EntityName = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    EntityId = table.Column<Guid>(type: "uuid", nullable: false),
                    AuditActionType = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<Guid>(type: "uuid", nullable: true),
                    SessionId = table.Column<string>(type: "text", nullable: true),
                    IpAddress = table.Column<IPAddress>(type: "inet", nullable: true),
                    UserAgent = table.Column<string>(type: "character varying(99)", maxLength: 99, nullable: true),
                    OldValues = table.Column<string>(type: "jsonb", nullable: true),
                    NewValues = table.Column<string>(type: "jsonb", nullable: true),
                    ChangesSummary = table.Column<string>(type: "text", nullable: true),
                    ReasonForChange = table.Column<string>(type: "text", nullable: true),
                    AffectedColumns = table.Column<string[]>(type: "varchar(99)[]", nullable: true),
                    CorrelationId = table.Column<string>(type: "text", nullable: true),
                    RiskLevel = table.Column<int>(type: "integer", nullable: true),
                    IsSystemAction = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    Duration = table.Column<int>(type: "integer", nullable: true),
                    ResultStatus = table.Column<int>(type: "integer", nullable: true),
                    ErrorMessage = table.Column<string>(type: "text", nullable: true),
                    AdditionalContext = table.Column<string>(type: "jsonb", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuditTrail", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BoardAngle",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Angle = table.Column<int>(type: "integer", nullable: false),
                    Unit = table.Column<int>(type: "integer", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardAngle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BoardConfig",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Version = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    PreviousVersionId = table.Column<long>(type: "bigint", nullable: true),
                    Content = table.Column<string>(type: "TEXT", nullable: false),
                    Cols = table.Column<int>(type: "integer", nullable: false),
                    Rows = table.Column<int>(type: "integer", nullable: false),
                    Width = table.Column<float>(type: "real", nullable: false),
                    Height = table.Column<float>(type: "real", nullable: false),
                    InterItemSpacingVertical = table.Column<float>(type: "real", nullable: false),
                    InterItemSpacingHorizontal = table.Column<float>(type: "real", nullable: false),
                    IsStaggeredGrid = table.Column<bool>(type: "boolean", nullable: false),
                    StaggeredGridOffset = table.Column<float>(type: "real", nullable: false),
                    Difficulty = table.Column<int>(type: "integer", nullable: true),
                    CreatedByUserId = table.Column<long>(type: "bigint", nullable: false),
                    ApprovedByUserId = table.Column<long>(type: "bigint", nullable: true),
                    ApprovedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ChangeNotes = table.Column<string>(type: "TEXT", nullable: true),
                    IsBackwardCompatible = table.Column<bool>(type: "boolean", nullable: false),
                    MigrationScript = table.Column<string>(type: "TEXT", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardConfig", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BoardConfig_BoardConfig_PreviousVersionId",
                        column: x => x.PreviousVersionId,
                        principalTable: "BoardConfig",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BoardConfig_UserProfile_ApprovedByUserId",
                        column: x => x.ApprovedByUserId,
                        principalTable: "UserProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BoardConfig_UserProfile_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "UserProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BoardItemTexture",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    ThumbnailUrl = table.Column<string>(type: "text", nullable: true),
                    Difficulty = table.Column<int>(type: "integer", nullable: false),
                    Properties = table.Column<string>(type: "JSONB", nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardItemTexture", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BoardItemTextureMaterial",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    ThumbnailUrl = table.Column<string>(type: "text", nullable: true),
                    Difficulty = table.Column<int>(type: "integer", nullable: false),
                    Properties = table.Column<string>(type: "JSONB", nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardItemTextureMaterial", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BoardItemType",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Difficulty = table.Column<int>(type: "integer", nullable: false),
                    Icon = table.Column<string>(type: "TEXT", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardItemType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BoardItemVolume",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    VolumeType = table.Column<string>(type: "text", nullable: false),
                    Width = table.Column<float>(type: "real", nullable: false),
                    Height = table.Column<float>(type: "real", nullable: false),
                    Depth = table.Column<float>(type: "real", nullable: false),
                    ModelUrl = table.Column<string>(type: "text", nullable: true),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    ThumbnailUrl = table.Column<string>(type: "text", nullable: true),
                    Difficulty = table.Column<int>(type: "integer", nullable: false),
                    Properties = table.Column<string>(type: "JSONB", nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardItemVolume", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BoardProblemTag",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardProblemTag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClimbTag",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClimbTag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Color",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    DisplayName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    ColorHex_HexCode = table.Column<string>(type: "text", nullable: false),
                    ColorRgb_RgbRed = table.Column<short>(type: "smallint", nullable: false),
                    ColorRgb_RgbGreen = table.Column<short>(type: "smallint", nullable: false),
                    ColorRgb_RgbBlue = table.Column<short>(type: "smallint", nullable: false),
                    ColorHsl_HslHue = table.Column<int>(type: "integer", nullable: false),
                    ColorHsl_HslSaturation = table.Column<int>(type: "integer", nullable: false),
                    ColorHsl_HslLightness = table.Column<int>(type: "integer", nullable: false),
                    IsStandard = table.Column<bool>(type: "boolean", nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Color", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AuthorId = table.Column<long>(type: "bigint", nullable: false),
                    EntityType = table.Column<string>(type: "text", nullable: false),
                    EntityId = table.Column<long>(type: "bigint", nullable: false),
                    ParentCommentId = table.Column<long>(type: "bigint", nullable: true),
                    Content = table.Column<string>(type: "text", nullable: false),
                    IsEdited = table.Column<bool>(type: "boolean", nullable: false),
                    EditedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsPinned = table.Column<bool>(type: "boolean", nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Comment_Comment_ParentCommentId",
                        column: x => x.ParentCommentId,
                        principalTable: "Comment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Configuration",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Key = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Value = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    IsSensitive = table.Column<bool>(type: "boolean", nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configuration", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConfigurationVersion",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EntityType = table.Column<string>(type: "text", nullable: false),
                    EntityId = table.Column<long>(type: "bigint", nullable: false),
                    VersionNumber = table.Column<int>(type: "integer", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    ChangeDescription = table.Column<string>(type: "text", nullable: true),
                    ChangedByUserId = table.Column<long>(type: "bigint", nullable: false),
                    IsCurrentVersion = table.Column<bool>(type: "boolean", nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigurationVersion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DifficultyGroup",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Level = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DifficultyGroup", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DifficultyScaleType",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Icon = table.Column<string>(type: "text", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DifficultyScaleType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentCategory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Icon = table.Column<string>(type: "text", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EscalationRule",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Category = table.Column<int>(type: "integer", nullable: true),
                    Priority = table.Column<int>(type: "integer", nullable: true),
                    TimeThreshold = table.Column<int>(type: "integer", nullable: false),
                    EscalateToUserId = table.Column<long>(type: "bigint", nullable: true),
                    EscalateToLevel = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Conditions = table.Column<string>(type: "text", nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EscalationRule", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FitnessTest",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    TestDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Test300mTime = table.Column<int>(type: "integer", nullable: true),
                    Test300mLevel = table.Column<int>(type: "integer", nullable: true),
                    ParallelDips60s = table.Column<int>(type: "integer", nullable: true),
                    ParallelDips60sLevel = table.Column<int>(type: "integer", nullable: true),
                    Crunches60s = table.Column<int>(type: "integer", nullable: true),
                    Crunches60sLevel = table.Column<int>(type: "integer", nullable: true),
                    Squats60s = table.Column<int>(type: "integer", nullable: true),
                    Squats60sLevel = table.Column<int>(type: "integer", nullable: true),
                    PullUps60s = table.Column<int>(type: "integer", nullable: true),
                    PullUps60sLevel = table.Column<int>(type: "integer", nullable: true),
                    BoxJumps60s = table.Column<int>(type: "integer", nullable: true),
                    BoxJumps60sLevel = table.Column<int>(type: "integer", nullable: true),
                    PushUps60s = table.Column<int>(type: "integer", nullable: true),
                    PushUps60sLevel = table.Column<int>(type: "integer", nullable: true),
                    OverallLevel = table.Column<int>(type: "integer", nullable: true),
                    TotalScore = table.Column<decimal>(type: "numeric", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FitnessTest", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FootRule",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FootRule", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HelpCategory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Icon = table.Column<string>(type: "text", nullable: true),
                    ParentCategoryId = table.Column<long>(type: "bigint", nullable: true),
                    SortOrder = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    ArticleCount = table.Column<int>(type: "integer", nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HelpCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HelpCategory_HelpCategory_ParentCategoryId",
                        column: x => x.ParentCategoryId,
                        principalTable: "HelpCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HelpFeedback",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    EntityType = table.Column<string>(type: "text", nullable: false),
                    EntityId = table.Column<long>(type: "bigint", nullable: false),
                    FeedbackType = table.Column<string>(type: "text", nullable: false),
                    Rating = table.Column<int>(type: "integer", nullable: true),
                    Comment = table.Column<string>(type: "text", nullable: true),
                    IsAnonymous = table.Column<bool>(type: "boolean", nullable: false),
                    IpAddress = table.Column<string>(type: "text", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HelpFeedback", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HelpSearchLog",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    SearchQuery = table.Column<string>(type: "text", nullable: false),
                    ResultCount = table.Column<int>(type: "integer", nullable: false),
                    ClickedArticleId = table.Column<long>(type: "bigint", nullable: true),
                    SessionId = table.Column<string>(type: "text", nullable: true),
                    IpAddress = table.Column<string>(type: "text", nullable: true),
                    UserAgent = table.Column<string>(type: "text", nullable: true),
                    SearchDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    WasHelpful = table.Column<bool>(type: "boolean", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HelpSearchLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Invoice",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InvoiceNumber = table.Column<string>(type: "text", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DueDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    Currency = table.Column<string>(type: "text", nullable: false),
                    TaxAmount = table.Column<decimal>(type: "numeric", nullable: true),
                    DiscountAmount = table.Column<decimal>(type: "numeric", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: false),
                    PdfUrl = table.Column<string>(type: "text", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoice", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LiveChatSession",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SessionId = table.Column<string>(type: "text", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    AgentId = table.Column<long>(type: "bigint", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: false),
                    StartedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    WaitTime = table.Column<int>(type: "integer", nullable: true),
                    Duration = table.Column<int>(type: "integer", nullable: true),
                    SatisfactionRating = table.Column<int>(type: "integer", nullable: true),
                    Tags = table.Column<string>(type: "text", nullable: true),
                    TranscriptUrl = table.Column<string>(type: "text", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LiveChatSession", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mountain",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Elevation = table.Column<int>(type: "integer", nullable: false),
                    Location = table.Column<Point>(type: "geography(POINTZ,4326)", nullable: false),
                    Country = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Region = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    State = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    FirstAscentDate = table.Column<DateOnly>(type: "date", nullable: true),
                    FirstAscentBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false, defaultValue: true),
                    DifficultyRating = table.Column<short>(type: "smallint", nullable: false, defaultValue: (short)1),
                    ImageUrls = table.Column<string[]>(type: "text[]", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mountain", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NotificationPreference",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Category = table.Column<string>(type: "text", nullable: false),
                    EmailEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    PushEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    InAppEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    SMSEnabled = table.Column<bool>(type: "boolean", nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationPreference", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "NotificationTemplate",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Subject = table.Column<string>(type: "text", nullable: true),
                    Body = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Language = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Variables = table.Column<string>(type: "text", nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationTemplate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Organization",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    DisplayName = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: true),
                    Phone = table.Column<string>(type: "text", nullable: true),
                    Website = table.Column<string>(type: "text", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    City = table.Column<string>(type: "text", nullable: true),
                    State = table.Column<string>(type: "text", nullable: true),
                    Country = table.Column<string>(type: "text", nullable: false),
                    PostalCode = table.Column<string>(type: "text", nullable: true),
                    Location = table.Column<Point>(type: "geography(POINTZ,4326)", nullable: true),
                    TimeZone = table.Column<string>(type: "text", nullable: true),
                    IsVerified = table.Column<bool>(type: "boolean", nullable: false),
                    IsPublic = table.Column<bool>(type: "boolean", nullable: false),
                    LogoUrl = table.Column<string>(type: "text", nullable: true),
                    BannerUrl = table.Column<string>(type: "text", nullable: true),
                    FoundedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LicenseNumber = table.Column<string>(type: "text", nullable: true),
                    TaxId = table.Column<string>(type: "text", nullable: true),
                    BusinessHours = table.Column<string>(type: "jsonb", nullable: true),
                    SocialMedia = table.Column<string>(type: "jsonb", nullable: true),
                    Amenities = table.Column<string>(type: "jsonb", nullable: true),
                    SafetyCertifications = table.Column<string>(type: "jsonb", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Organization", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethod",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Provider = table.Column<string>(type: "text", nullable: false),
                    Token = table.Column<string>(type: "text", nullable: false),
                    LastFourDigits = table.Column<string>(type: "text", nullable: true),
                    ExpiryDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsDefault = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethod", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PayPerUse",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    ServiceType = table.Column<string>(type: "text", nullable: false),
                    ServiceId = table.Column<long>(type: "bigint", nullable: true),
                    UnitPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "numeric", nullable: false),
                    Currency = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    ConsumedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    PaidAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PayPerUse", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhysiologicalData",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    MeasurementDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MaxHeartRate = table.Column<int>(type: "integer", nullable: true),
                    RestingHeartRate = table.Column<int>(type: "integer", nullable: true),
                    VO2Max = table.Column<decimal>(type: "numeric", nullable: true),
                    VO2MaxFraction = table.Column<decimal>(type: "numeric", nullable: true),
                    BodyWeight = table.Column<decimal>(type: "numeric", nullable: true),
                    BodyFat = table.Column<decimal>(type: "numeric", nullable: true),
                    MuscleComposition = table.Column<decimal>(type: "numeric", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    MeasuredBy = table.Column<string>(type: "text", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhysiologicalData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Plan",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    Currency = table.Column<string>(type: "text", nullable: false),
                    BillingPeriod = table.Column<string>(type: "text", nullable: false),
                    Features = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    MaxBoards = table.Column<int>(type: "integer", nullable: true),
                    MaxMembers = table.Column<int>(type: "integer", nullable: true),
                    AIGenerationsPerMonth = table.Column<int>(type: "integer", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plan", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SupportAgent",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    AgentLevel = table.Column<string>(type: "text", nullable: false),
                    Specializations = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    IsAvailable = table.Column<bool>(type: "boolean", nullable: false),
                    MaxConcurrentChats = table.Column<int>(type: "integer", nullable: false),
                    CurrentActiveChats = table.Column<int>(type: "integer", nullable: false),
                    TotalTicketsResolved = table.Column<int>(type: "integer", nullable: false),
                    AverageResolutionTime = table.Column<decimal>(type: "numeric", nullable: true),
                    AverageRating = table.Column<decimal>(type: "numeric", nullable: true),
                    LastActiveAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportAgent", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SupportMetrics",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MetricDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TicketsCreated = table.Column<int>(type: "integer", nullable: false),
                    TicketsResolved = table.Column<int>(type: "integer", nullable: false),
                    TicketsClosed = table.Column<int>(type: "integer", nullable: false),
                    AverageFirstResponseTime = table.Column<decimal>(type: "numeric", nullable: false),
                    AverageResolutionTime = table.Column<decimal>(type: "numeric", nullable: false),
                    CustomerSatisfactionScore = table.Column<decimal>(type: "numeric", nullable: false),
                    ChatSessionsStarted = table.Column<int>(type: "integer", nullable: false),
                    ChatSessionsCompleted = table.Column<int>(type: "integer", nullable: false),
                    AverageChatWaitTime = table.Column<decimal>(type: "numeric", nullable: false),
                    KnowledgeBaseViews = table.Column<int>(type: "integer", nullable: false),
                    FAQViews = table.Column<int>(type: "integer", nullable: false),
                    SearchQueries = table.Column<int>(type: "integer", nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportMetrics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SupportTicket",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TicketNumber = table.Column<string>(type: "text", nullable: false),
                    Subject = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Category = table.Column<int>(type: "integer", nullable: false),
                    Priority = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "bigint", nullable: false),
                    AssignedToUserId = table.Column<long>(type: "bigint", nullable: true),
                    ResolvedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    FirstResponseAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastActivityAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EstimatedResolutionTime = table.Column<int>(type: "integer", nullable: true),
                    ActualResolutionTime = table.Column<int>(type: "integer", nullable: true),
                    CustomerSatisfactionRating = table.Column<int>(type: "integer", nullable: true),
                    ResolutionNotes = table.Column<string>(type: "text", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportTicket", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrainingExercise",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Category = table.Column<int>(type: "integer", nullable: false),
                    SubCategory = table.Column<int>(type: "integer", nullable: false),
                    MuscleGroups = table.Column<string>(type: "text", nullable: true),
                    Equipment = table.Column<string>(type: "text", nullable: true),
                    Instructions = table.Column<string>(type: "text", nullable: true),
                    VideoUrl = table.Column<string>(type: "text", nullable: true),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    DifficultyLevel = table.Column<int>(type: "integer", nullable: false),
                    EstimatedCalories = table.Column<decimal>(type: "numeric", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingExercise", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TrainingTemplate",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    PeriodType = table.Column<int>(type: "integer", nullable: false),
                    DurationWeeks = table.Column<int>(type: "integer", nullable: false),
                    TargetGoal = table.Column<string>(type: "text", nullable: false),
                    Zone1Percentage = table.Column<decimal>(type: "numeric", nullable: false),
                    Zone2Percentage = table.Column<decimal>(type: "numeric", nullable: false),
                    Zone3Percentage = table.Column<decimal>(type: "numeric", nullable: false),
                    Zone4Percentage = table.Column<decimal>(type: "numeric", nullable: false),
                    StrengthPercentage = table.Column<decimal>(type: "numeric", nullable: false),
                    IsPublic = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "bigint", nullable: false),
                    UsageCount = table.Column<int>(type: "integer", nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingTemplate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserHelpActivity",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    ActivityType = table.Column<string>(type: "text", nullable: false),
                    EntityType = table.Column<string>(type: "text", nullable: false),
                    EntityId = table.Column<long>(type: "bigint", nullable: false),
                    Details = table.Column<string>(type: "text", nullable: true),
                    Duration = table.Column<int>(type: "integer", nullable: true),
                    IpAddress = table.Column<string>(type: "text", nullable: true),
                    UserAgent = table.Column<string>(type: "text", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserHelpActivity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WaypointType",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Icon = table.Column<string>(type: "text", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WaypointType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AIGenerationTemplate",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    AIModelId = table.Column<long>(type: "bigint", nullable: false),
                    TemplateParameters = table.Column<string>(type: "text", nullable: false),
                    DifficultyRange = table.Column<string>(type: "text", nullable: false),
                    ProblemStyle = table.Column<string>(type: "text", nullable: true),
                    IsPublic = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "bigint", nullable: false),
                    UsageCount = table.Column<int>(type: "integer", nullable: false),
                    SuccessRate = table.Column<decimal>(type: "numeric", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AIGenerationTemplate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AIGenerationTemplate_AIModel_AIModelId",
                        column: x => x.AIModelId,
                        principalTable: "AIModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AIModelConfiguration",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AIModelId = table.Column<long>(type: "bigint", nullable: false),
                    ConfigKey = table.Column<string>(type: "text", nullable: false),
                    ConfigValue = table.Column<string>(type: "text", nullable: false),
                    DataType = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    IsRequired = table.Column<bool>(type: "boolean", nullable: false),
                    DefaultValue = table.Column<string>(type: "text", nullable: true),
                    ValidationRules = table.Column<string>(type: "text", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AIModelConfiguration", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AIModelConfiguration_AIModel_AIModelId",
                        column: x => x.AIModelId,
                        principalTable: "AIModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AIModelLog",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AIModelId = table.Column<long>(type: "bigint", nullable: false),
                    Action = table.Column<string>(type: "text", nullable: false),
                    InputData = table.Column<string>(type: "text", nullable: false),
                    OutputData = table.Column<string>(type: "text", nullable: false),
                    Duration = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    ErrorMessage = table.Column<string>(type: "text", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AIModelLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AIModelLog_AIModel_AIModelId",
                        column: x => x.AIModelId,
                        principalTable: "AIModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AIModelVersion",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AIModelId = table.Column<long>(type: "bigint", nullable: false),
                    VersionNumber = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    TrainingDataVersion = table.Column<string>(type: "text", nullable: true),
                    ModelFile = table.Column<string>(type: "text", nullable: true),
                    Metrics = table.Column<string>(type: "text", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeprecated = table.Column<bool>(type: "boolean", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TrainingStartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    TrainingEndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AIModelVersion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AIModelVersion_AIModel_AIModelId",
                        column: x => x.AIModelId,
                        principalTable: "AIModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AITrainingData",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BoardProblemId = table.Column<long>(type: "bigint", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    UsedByModelId = table.Column<long>(type: "bigint", nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AITrainingData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AITrainingData_AIModel_UsedByModelId",
                        column: x => x.UsedByModelId,
                        principalTable: "AIModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BoardProblem",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BoardConfigId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    IsPublic = table.Column<bool>(type: "boolean", nullable: false),
                    IsFeatured = table.Column<bool>(type: "boolean", nullable: false),
                    IsArchived = table.Column<bool>(type: "boolean", nullable: false),
                    IsDryTooling = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedByUserId = table.Column<long>(type: "bigint", nullable: true),
                    GeneratedByAI = table.Column<bool>(type: "boolean", nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardProblem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BoardProblem_BoardConfig_BoardConfigId",
                        column: x => x.BoardConfigId,
                        principalTable: "BoardConfig",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BoardProblem_UserProfile_CreatedByUserId",
                        column: x => x.CreatedByUserId,
                        principalTable: "UserProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "BoardItem",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BoardConfigId = table.Column<long>(type: "bigint", nullable: false),
                    PositionX = table.Column<int>(type: "integer", nullable: false),
                    PositionY = table.Column<int>(type: "integer", nullable: false),
                    Orientation = table.Column<int>(type: "integer", nullable: false),
                    AllowedUsage = table.Column<int>(type: "integer", nullable: false),
                    Difficulty = table.Column<int>(type: "integer", nullable: false),
                    BoardItemTypeId = table.Column<long>(type: "bigint", nullable: false),
                    BoardItemVolumeId = table.Column<long>(type: "bigint", nullable: true),
                    IsDryTooling = table.Column<bool>(type: "boolean", nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BoardItem_BoardConfig_BoardConfigId",
                        column: x => x.BoardConfigId,
                        principalTable: "BoardConfig",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BoardItem_BoardItemType_BoardItemTypeId",
                        column: x => x.BoardItemTypeId,
                        principalTable: "BoardItemType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BoardItem_BoardItemVolume_BoardItemVolumeId",
                        column: x => x.BoardItemVolumeId,
                        principalTable: "BoardItemVolume",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BoardProblemItemType",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ColorId = table.Column<long>(type: "bigint", nullable: false),
                    Usage = table.Column<int>(type: "integer", nullable: false),
                    IsStart = table.Column<bool>(type: "boolean", nullable: false),
                    IsEnd = table.Column<bool>(type: "boolean", nullable: false),
                    IsZone = table.Column<bool>(type: "boolean", nullable: false),
                    IsMandatory = table.Column<bool>(type: "boolean", nullable: false),
                    IsTouchOnly = table.Column<bool>(type: "boolean", nullable: false),
                    Difficulty = table.Column<int>(type: "integer", nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardProblemItemType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BoardProblemItemType_Color_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Color",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommentAttachment",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CommentId = table.Column<long>(type: "bigint", nullable: false),
                    FileName = table.Column<string>(type: "text", nullable: false),
                    FileUrl = table.Column<string>(type: "text", nullable: false),
                    FileSize = table.Column<long>(type: "bigint", nullable: false),
                    ContentType = table.Column<string>(type: "text", nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentAttachment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentAttachment_Comment_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CommentMention",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CommentId = table.Column<long>(type: "bigint", nullable: false),
                    MentionedUserId = table.Column<long>(type: "bigint", nullable: false),
                    IsNotified = table.Column<bool>(type: "boolean", nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentMention", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentMention_Comment_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CommentReaction",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CommentId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    ReactionType = table.Column<string>(type: "text", nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentReaction", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentReaction_Comment_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CommentReport",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CommentId = table.Column<long>(type: "bigint", nullable: false),
                    ReportedByUserId = table.Column<long>(type: "bigint", nullable: false),
                    Reason = table.Column<string>(type: "text", nullable: false),
                    Details = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: false),
                    ReviewedByUserId = table.Column<long>(type: "bigint", nullable: true),
                    ReviewedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ReviewNotes = table.Column<string>(type: "text", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentReport", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommentReport_Comment_CommentId",
                        column: x => x.CommentId,
                        principalTable: "Comment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "VersionDependency",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ConfigurationVersionId = table.Column<long>(type: "bigint", nullable: false),
                    DependencyEntityType = table.Column<string>(type: "text", nullable: false),
                    DependencyEntityId = table.Column<long>(type: "bigint", nullable: false),
                    RequiredVersionNumber = table.Column<int>(type: "integer", nullable: true),
                    DependencyType = table.Column<string>(type: "text", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VersionDependency", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VersionDependency_ConfigurationVersion_ConfigurationVersion~",
                        column: x => x.ConfigurationVersionId,
                        principalTable: "ConfigurationVersion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DifficultyScaleName",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    DifficultyScaleTypeId = table.Column<long>(type: "bigint", nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DifficultyScaleName", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DifficultyScaleName_DifficultyScaleType_DifficultyScaleType~",
                        column: x => x.DifficultyScaleTypeId,
                        principalTable: "DifficultyScaleType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Equipment",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    EquipmentCategoryId = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    IsPersonal = table.Column<bool>(type: "boolean", nullable: false),
                    IsMandatory = table.Column<bool>(type: "boolean", nullable: false),
                    Weight = table.Column<decimal>(type: "numeric", nullable: true),
                    Brand = table.Column<string>(type: "text", nullable: true),
                    Model = table.Column<string>(type: "text", nullable: true),
                    Specifications = table.Column<string>(type: "text", nullable: true),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    EquipmentCategoryId1 = table.Column<long>(type: "bigint", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Equipment_EquipmentCategory_EquipmentCategoryId",
                        column: x => x.EquipmentCategoryId,
                        principalTable: "EquipmentCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Equipment_EquipmentCategory_EquipmentCategoryId1",
                        column: x => x.EquipmentCategoryId1,
                        principalTable: "EquipmentCategory",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FAQ",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Question = table.Column<string>(type: "text", nullable: false),
                    Answer = table.Column<string>(type: "text", nullable: false),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    ViewCount = table.Column<int>(type: "integer", nullable: false),
                    HelpfulCount = table.Column<int>(type: "integer", nullable: false),
                    NotHelpfulCount = table.Column<int>(type: "integer", nullable: false),
                    SortOrder = table.Column<int>(type: "integer", nullable: false),
                    SearchKeywords = table.Column<string>(type: "text", nullable: true),
                    LastUpdatedBy = table.Column<long>(type: "bigint", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FAQ", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FAQ_HelpCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "HelpCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HelpArticle",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    Summary = table.Column<string>(type: "text", nullable: true),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false),
                    AuthorId = table.Column<long>(type: "bigint", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    IsPublic = table.Column<bool>(type: "boolean", nullable: false),
                    IsFeatured = table.Column<bool>(type: "boolean", nullable: false),
                    ViewCount = table.Column<int>(type: "integer", nullable: false),
                    LikeCount = table.Column<int>(type: "integer", nullable: false),
                    DislikeCount = table.Column<int>(type: "integer", nullable: false),
                    SearchKeywords = table.Column<string>(type: "text", nullable: true),
                    LastReviewedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastReviewedBy = table.Column<long>(type: "bigint", nullable: true),
                    PublishedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EstimatedReadTime = table.Column<int>(type: "integer", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HelpArticle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HelpArticle_HelpCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "HelpCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "KnowledgeBase",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    Tags = table.Column<string>(type: "text", nullable: true),
                    CategoryId = table.Column<long>(type: "bigint", nullable: false),
                    IsInternal = table.Column<bool>(type: "boolean", nullable: false),
                    AccessLevel = table.Column<string>(type: "text", nullable: false),
                    LastUpdatedBy = table.Column<long>(type: "bigint", nullable: false),
                    ViewCount = table.Column<int>(type: "integer", nullable: false),
                    UseCount = table.Column<int>(type: "integer", nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KnowledgeBase", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KnowledgeBase_HelpCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "HelpCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ChatMessage",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SessionId = table.Column<long>(type: "bigint", nullable: false),
                    SenderId = table.Column<long>(type: "bigint", nullable: false),
                    Message = table.Column<string>(type: "text", nullable: false),
                    MessageType = table.Column<string>(type: "text", nullable: false),
                    IsFromAgent = table.Column<bool>(type: "boolean", nullable: false),
                    IsSystemMessage = table.Column<bool>(type: "boolean", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsRead = table.Column<bool>(type: "boolean", nullable: false),
                    AttachmentUrl = table.Column<string>(type: "text", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatMessage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChatMessage_LiveChatSession_SessionId",
                        column: x => x.SessionId,
                        principalTable: "LiveChatSession",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MountainFile",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MountainId = table.Column<long>(type: "bigint", nullable: false),
                    FileType = table.Column<int>(type: "integer", nullable: false),
                    FileName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    FileSize = table.Column<string>(type: "text", nullable: false),
                    FileUrl = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: false),
                    ThumbnailUrl = table.Column<string>(type: "text", nullable: true),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    TakenAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    TakenBy = table.Column<string>(type: "text", nullable: true),
                    Location = table.Column<Point>(type: "geography(POINTZ,4326)", nullable: true),
                    Elevation = table.Column<int>(type: "integer", nullable: true),
                    IsPublic = table.Column<bool>(type: "boolean", nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MountainFile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MountainFile_Mountain_MountainId",
                        column: x => x.MountainId,
                        principalTable: "Mountain",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WeatherCondition",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MountainId = table.Column<long>(type: "bigint", nullable: false),
                    RecordedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Temperature = table.Column<float>(type: "real", nullable: true),
                    WindSpeed = table.Column<float>(type: "real", nullable: true),
                    WindDirection = table.Column<float>(type: "real", nullable: true),
                    Humidity = table.Column<float>(type: "real", nullable: true),
                    Pressure = table.Column<float>(type: "real", nullable: true),
                    Visibility = table.Column<float>(type: "real", nullable: true),
                    Condition = table.Column<string>(type: "text", nullable: true),
                    SnowDepth = table.Column<float>(type: "real", nullable: true),
                    DataSource = table.Column<string>(type: "text", nullable: true),
                    RainFall = table.Column<float>(type: "real", nullable: true),
                    SnowFall = table.Column<float>(type: "real", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherCondition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WeatherCondition_Mountain_MountainId",
                        column: x => x.MountainId,
                        principalTable: "Mountain",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    TemplateId = table.Column<long>(type: "bigint", nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    Subject = table.Column<string>(type: "text", nullable: true),
                    Message = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    SentAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeliveredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ReadAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    FailureReason = table.Column<string>(type: "text", nullable: true),
                    ExternalId = table.Column<string>(type: "text", nullable: true),
                    NotificationMetadata = table.Column<string>(type: "text", nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notification_NotificationTemplate_TemplateId",
                        column: x => x.TemplateId,
                        principalTable: "NotificationTemplate",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Board",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: true),
                    Visibility = table.Column<int>(type: "integer", nullable: false, defaultValue: 1),
                    BoardConfigId = table.Column<long>(type: "bigint", nullable: false),
                    OrganizationId = table.Column<long>(type: "bigint", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Board", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Board_BoardConfig_BoardConfigId",
                        column: x => x.BoardConfigId,
                        principalTable: "BoardConfig",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Board_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organization",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ClimbZone",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Location = table.Column<Point>(type: "geography(POINTZ,4326)", nullable: true),
                    IsPublic = table.Column<bool>(type: "boolean", nullable: false),
                    IsIndoor = table.Column<bool>(type: "boolean", nullable: false),
                    ImageUrl = table.Column<string>(type: "text", nullable: true),
                    OrganizationId = table.Column<long>(type: "bigint", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClimbZone", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClimbZone_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organization",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "OrganizationCertification",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrganizationId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    CertificationType = table.Column<string>(type: "text", nullable: false),
                    CertificationName = table.Column<string>(type: "text", nullable: false),
                    Level = table.Column<string>(type: "text", nullable: true),
                    IssuedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CertificateNumber = table.Column<string>(type: "text", nullable: false),
                    IssuedBy = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    RenewalRequired = table.Column<bool>(type: "boolean", nullable: false),
                    CertificateUrl = table.Column<string>(type: "text", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationCertification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizationCertification_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrganizationCertification_UserProfile_UserId",
                        column: x => x.UserId,
                        principalTable: "UserProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationFacility",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrganizationId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    FacilityType = table.Column<string>(type: "text", nullable: false),
                    Capacity = table.Column<int>(type: "integer", nullable: true),
                    Area = table.Column<decimal>(type: "numeric", nullable: true),
                    Height = table.Column<decimal>(type: "numeric", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    RequiresReservation = table.Column<bool>(type: "boolean", nullable: false),
                    Equipment = table.Column<string>(type: "jsonb", nullable: true),
                    SafetyFeatures = table.Column<string>(type: "jsonb", nullable: true),
                    AccessLevel = table.Column<string>(type: "text", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationFacility", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizationFacility_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationFile",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrganizationId = table.Column<long>(type: "bigint", nullable: false),
                    FileType = table.Column<int>(type: "integer", nullable: false),
                    FileName = table.Column<string>(type: "text", nullable: false),
                    FileSize = table.Column<int>(type: "integer", nullable: false),
                    FileUrl = table.Column<string>(type: "text", nullable: false),
                    ThumbnailUrl = table.Column<string>(type: "text", nullable: true),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    IsPublic = table.Column<bool>(type: "boolean", nullable: false),
                    UploadedBy = table.Column<long>(type: "bigint", nullable: true),
                    Category = table.Column<string>(type: "text", nullable: true),
                    RequiresLogin = table.Column<bool>(type: "boolean", nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationFile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizationFile_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationInstructor",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrganizationId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    InstructorLevel = table.Column<string>(type: "text", nullable: false),
                    Specialties = table.Column<string>(type: "jsonb", nullable: false),
                    YearsExperience = table.Column<int>(type: "integer", nullable: true),
                    CertificationNumber = table.Column<string>(type: "text", nullable: true),
                    CertificationExpiry = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    HourlyRate = table.Column<decimal>(type: "numeric", nullable: true),
                    Currency = table.Column<string>(type: "text", nullable: true),
                    Bio = table.Column<string>(type: "text", nullable: true),
                    Languages = table.Column<string>(type: "jsonb", nullable: true),
                    AvailabilitySchedule = table.Column<string>(type: "jsonb", nullable: true),
                    EmergencyTraining = table.Column<bool>(type: "boolean", nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationInstructor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizationInstructor_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrganizationInstructor_UserProfile_UserId",
                        column: x => x.UserId,
                        principalTable: "UserProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationMember",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrganizationId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    MembershipType = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Role = table.Column<string>(type: "text", nullable: true),
                    JoinedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LastPaymentAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    MembershipNumber = table.Column<string>(type: "text", nullable: true),
                    EmergencyContact = table.Column<string>(type: "text", nullable: true),
                    EmergencyPhone = table.Column<string>(type: "text", nullable: true),
                    MedicalNotes = table.Column<string>(type: "text", nullable: true),
                    WaiverSigned = table.Column<bool>(type: "boolean", nullable: false),
                    WaiverSignedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationMember", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizationMember_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrganizationMember_UserProfile_UserId",
                        column: x => x.UserId,
                        principalTable: "UserProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainingPlan",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    LongTermGoal = table.Column<string[]>(type: "text[]", nullable: true),
                    ShortTermGoal = table.Column<string[]>(type: "text[]", nullable: true),
                    BaselinePhysiologicalDataId = table.Column<long>(type: "bigint", nullable: true),
                    CreatedByUserId = table.Column<long>(type: "bigint", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingPlan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingPlan_PhysiologicalData_BaselinePhysiologicalDataId",
                        column: x => x.BaselinePhysiologicalDataId,
                        principalTable: "PhysiologicalData",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TrainingPlan_UserProfile_UserId",
                        column: x => x.UserId,
                        principalTable: "UserProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Subscription",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    PlanId = table.Column<long>(type: "bigint", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    NextBillingDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    AutoRenew = table.Column<bool>(type: "boolean", nullable: false),
                    CancelledAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CancellationReason = table.Column<string>(type: "text", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Subscription_Plan_PlanId",
                        column: x => x.PlanId,
                        principalTable: "Plan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TicketMessage",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TicketId = table.Column<long>(type: "bigint", nullable: false),
                    SenderId = table.Column<long>(type: "bigint", nullable: false),
                    Message = table.Column<string>(type: "text", nullable: false),
                    IsInternalNote = table.Column<bool>(type: "boolean", nullable: false),
                    IsSystemMessage = table.Column<bool>(type: "boolean", nullable: false),
                    MessageType = table.Column<string>(type: "text", nullable: false),
                    Attachments = table.Column<string>(type: "text", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketMessage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketMessage_SupportTicket_TicketId",
                        column: x => x.TicketId,
                        principalTable: "SupportTicket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AIGenerationRequest",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RequestedByUserId = table.Column<long>(type: "bigint", nullable: false),
                    AIModelId = table.Column<long>(type: "bigint", nullable: false),
                    AIModelVersionId = table.Column<long>(type: "bigint", nullable: true),
                    Difficulty = table.Column<int>(type: "integer", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    GeneratedBoardProblemId = table.Column<long>(type: "bigint", nullable: true),
                    Cost = table.Column<decimal>(type: "numeric", nullable: true),
                    Currency = table.Column<string>(type: "text", nullable: true),
                    IsPaid = table.Column<bool>(type: "boolean", nullable: false),
                    ErrorMessage = table.Column<string>(type: "text", nullable: true),
                    GenerationTimeMs = table.Column<int>(type: "integer", nullable: true),
                    QualityScore = table.Column<decimal>(type: "numeric", nullable: true),
                    InputParameters = table.Column<string>(type: "text", nullable: true),
                    OutputMetadata = table.Column<string>(type: "text", nullable: true),
                    CompletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AIGenerationRequest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AIGenerationRequest_AIModelVersion_AIModelVersionId",
                        column: x => x.AIModelVersionId,
                        principalTable: "AIModelVersion",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AIGenerationRequest_AIModel_AIModelId",
                        column: x => x.AIModelId,
                        principalTable: "AIModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AIModelBenchmark",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AIModelId = table.Column<long>(type: "bigint", nullable: false),
                    AIModelVersionId = table.Column<long>(type: "bigint", nullable: false),
                    BenchmarkName = table.Column<string>(type: "text", nullable: false),
                    TestDataset = table.Column<string>(type: "text", nullable: false),
                    TestCount = table.Column<int>(type: "integer", nullable: false),
                    SuccessCount = table.Column<int>(type: "integer", nullable: false),
                    FailureCount = table.Column<int>(type: "integer", nullable: false),
                    AverageGenerationTime = table.Column<decimal>(type: "numeric", nullable: false),
                    AccuracyScore = table.Column<decimal>(type: "numeric", nullable: false),
                    PrecisionScore = table.Column<decimal>(type: "numeric", nullable: false),
                    RecallScore = table.Column<decimal>(type: "numeric", nullable: false),
                    F1Score = table.Column<decimal>(type: "numeric", nullable: false),
                    CustomMetrics = table.Column<string>(type: "text", nullable: false),
                    TestDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AIModelBenchmark", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AIModelBenchmark_AIModelVersion_AIModelVersionId",
                        column: x => x.AIModelVersionId,
                        principalTable: "AIModelVersion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AIModelBenchmark_AIModel_AIModelId",
                        column: x => x.AIModelId,
                        principalTable: "AIModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AITrainingSession",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AIModelId = table.Column<long>(type: "bigint", nullable: false),
                    AIModelVersionId = table.Column<long>(type: "bigint", nullable: true),
                    SessionName = table.Column<string>(type: "text", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: false),
                    TrainingDataCount = table.Column<int>(type: "integer", nullable: false),
                    ValidationDataCount = table.Column<int>(type: "integer", nullable: false),
                    TestDataCount = table.Column<int>(type: "integer", nullable: false),
                    Epochs = table.Column<int>(type: "integer", nullable: true),
                    BatchSize = table.Column<int>(type: "integer", nullable: true),
                    LearningRate = table.Column<decimal>(type: "numeric", nullable: true),
                    TrainingMetrics = table.Column<string>(type: "text", nullable: false),
                    ValidationMetrics = table.Column<string>(type: "text", nullable: false),
                    FinalMetrics = table.Column<string>(type: "text", nullable: false),
                    LogFile = table.Column<string>(type: "text", nullable: true),
                    ConfigSnapshot = table.Column<string>(type: "text", nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AITrainingSession", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AITrainingSession_AIModelVersion_AIModelVersionId",
                        column: x => x.AIModelVersionId,
                        principalTable: "AIModelVersion",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AITrainingSession_AIModel_AIModelId",
                        column: x => x.AIModelId,
                        principalTable: "AIModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BoardProblemBoardProblemTag",
                columns: table => new
                {
                    BoardProblemTagsId = table.Column<long>(type: "bigint", nullable: false),
                    BoardProblemsId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardProblemBoardProblemTag", x => new { x.BoardProblemTagsId, x.BoardProblemsId });
                    table.ForeignKey(
                        name: "FK_BoardProblemBoardProblemTag_BoardProblemTag_BoardProblemTag~",
                        column: x => x.BoardProblemTagsId,
                        principalTable: "BoardProblemTag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BoardProblemBoardProblemTag_BoardProblem_BoardProblemsId",
                        column: x => x.BoardProblemsId,
                        principalTable: "BoardProblem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BoardProblemFootRule",
                columns: table => new
                {
                    BoardProblemsId = table.Column<long>(type: "bigint", nullable: false),
                    FootRulesId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardProblemFootRule", x => new { x.BoardProblemsId, x.FootRulesId });
                    table.ForeignKey(
                        name: "FK_BoardProblemFootRule_BoardProblem_BoardProblemsId",
                        column: x => x.BoardProblemsId,
                        principalTable: "BoardProblem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BoardProblemFootRule_FootRule_FootRulesId",
                        column: x => x.FootRulesId,
                        principalTable: "FootRule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BoardItemTextureCombination",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BoardItemId = table.Column<long>(type: "bigint", nullable: false),
                    BoardItemTextureId = table.Column<long>(type: "bigint", nullable: false),
                    BoardItemTextureMaterialId = table.Column<long>(type: "bigint", nullable: false),
                    Percentage = table.Column<float>(type: "real", nullable: false),
                    Order = table.Column<int>(type: "integer", nullable: false),
                    IsPrimary = table.Column<bool>(type: "boolean", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardItemTextureCombination", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BoardItemTextureCombination_BoardItemTextureMaterial_BoardI~",
                        column: x => x.BoardItemTextureMaterialId,
                        principalTable: "BoardItemTextureMaterial",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BoardItemTextureCombination_BoardItemTexture_BoardItemTextu~",
                        column: x => x.BoardItemTextureId,
                        principalTable: "BoardItemTexture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BoardItemTextureCombination_BoardItem_BoardItemId",
                        column: x => x.BoardItemId,
                        principalTable: "BoardItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BoardProblemItem",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Sequence = table.Column<int>(type: "integer", nullable: true),
                    BoardProblemId = table.Column<long>(type: "bigint", nullable: false),
                    BoardItemId = table.Column<long>(type: "bigint", nullable: false),
                    BoardProblemItemTypeId = table.Column<long>(type: "bigint", nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardProblemItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BoardProblemItem_BoardItem_BoardItemId",
                        column: x => x.BoardItemId,
                        principalTable: "BoardItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BoardProblemItem_BoardProblemItemType_BoardProblemItemTypeId",
                        column: x => x.BoardProblemItemTypeId,
                        principalTable: "BoardProblemItemType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BoardProblemItem_BoardProblem_BoardProblemId",
                        column: x => x.BoardProblemId,
                        principalTable: "BoardProblem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DifficultyScale",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DifficultyScaleNameId = table.Column<long>(type: "bigint", nullable: false),
                    Value = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    IRCRA = table.Column<int>(type: "integer", nullable: false),
                    DifficultyGroupId = table.Column<long>(type: "bigint", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DifficultyScale", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DifficultyScale_DifficultyGroup_DifficultyGroupId",
                        column: x => x.DifficultyGroupId,
                        principalTable: "DifficultyGroup",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DifficultyScale_DifficultyScaleName_DifficultyScaleNameId",
                        column: x => x.DifficultyScaleNameId,
                        principalTable: "DifficultyScaleName",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HelpArticleAttachment",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ArticleId = table.Column<long>(type: "bigint", nullable: false),
                    FileName = table.Column<string>(type: "text", nullable: false),
                    FileType = table.Column<int>(type: "integer", nullable: false),
                    FileSize = table.Column<int>(type: "integer", nullable: false),
                    FileUrl = table.Column<string>(type: "text", nullable: false),
                    ThumbnailUrl = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    UploadedBy = table.Column<long>(type: "bigint", nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HelpArticleAttachment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HelpArticleAttachment_HelpArticle_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "HelpArticle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HelpArticleVersion",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ArticleId = table.Column<long>(type: "bigint", nullable: false),
                    VersionNumber = table.Column<string>(type: "text", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    ChangeLog = table.Column<string>(type: "text", nullable: true),
                    EditedBy = table.Column<long>(type: "bigint", nullable: false),
                    EditDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsCurrentVersion = table.Column<bool>(type: "boolean", nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HelpArticleVersion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HelpArticleVersion_HelpArticle_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "HelpArticle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NotificationLog",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NotificationId = table.Column<long>(type: "bigint", nullable: false),
                    Action = table.Column<string>(type: "text", nullable: false),
                    Details = table.Column<string>(type: "text", nullable: true),
                    OccurredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IpAddress = table.Column<string>(type: "text", nullable: true),
                    UserAgent = table.Column<string>(type: "text", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotificationLog_Notification_NotificationId",
                        column: x => x.NotificationId,
                        principalTable: "Notification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "NotificationQueue",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NotificationId = table.Column<long>(type: "bigint", nullable: false),
                    Priority = table.Column<int>(type: "integer", nullable: false),
                    ScheduledAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    RetryCount = table.Column<int>(type: "integer", nullable: false),
                    MaxRetries = table.Column<int>(type: "integer", nullable: false),
                    LastAttemptAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    NextRetryAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationQueue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotificationQueue_Notification_NotificationId",
                        column: x => x.NotificationId,
                        principalTable: "Notification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BoardMember",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BoardId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    IsPropertyOwner = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    Role = table.Column<int>(type: "integer", nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardMember", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BoardMember_Board_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Board",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BoardMember_UserProfile_UserId",
                        column: x => x.UserId,
                        principalTable: "UserProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BoardSessionSummary",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BoardId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    TotalSessions = table.Column<int>(type: "integer", nullable: false),
                    TotalProblemsCompleted = table.Column<int>(type: "integer", nullable: false),
                    TotalAttempts = table.Column<int>(type: "integer", nullable: false),
                    AttemptNumber = table.Column<int>(type: "integer", nullable: true),
                    SentOnAttempt = table.Column<int>(type: "integer", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardSessionSummary", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BoardSessionSummary_Board_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Board",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BoardSessionSummary_UserProfile_UserId",
                        column: x => x.UserId,
                        principalTable: "UserProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClimbZoneFile",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClimbZoneId = table.Column<long>(type: "bigint", nullable: false),
                    IsSketch = table.Column<bool>(type: "boolean", nullable: false),
                    FileName = table.Column<string>(type: "text", nullable: false),
                    FileType = table.Column<int>(type: "integer", nullable: false),
                    FileSize = table.Column<int>(type: "integer", nullable: false),
                    FileUrl = table.Column<string>(type: "text", nullable: false),
                    FileResourceUrl = table.Column<string[]>(type: "text[]", nullable: true),
                    ThumbnailUrl = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClimbZoneFile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClimbZoneFile_ClimbZone_ClimbZoneId",
                        column: x => x.ClimbZoneId,
                        principalTable: "ClimbZone",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationEvent",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrganizationId = table.Column<long>(type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    EventType = table.Column<string>(type: "text", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: true),
                    FacilityId = table.Column<long>(type: "bigint", nullable: true),
                    MaxParticipants = table.Column<int>(type: "integer", nullable: true),
                    CurrentParticipants = table.Column<int>(type: "integer", nullable: false),
                    RegistrationDeadline = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Cost = table.Column<decimal>(type: "numeric", nullable: true),
                    Currency = table.Column<string>(type: "text", nullable: true),
                    RequiresRegistration = table.Column<bool>(type: "boolean", nullable: false),
                    IsPublic = table.Column<bool>(type: "boolean", nullable: false),
                    SkillLevelRequired = table.Column<string>(type: "text", nullable: true),
                    Equipment = table.Column<string>(type: "text", nullable: true),
                    Instructor = table.Column<string>(type: "text", nullable: true),
                    ContactEmail = table.Column<string>(type: "text", nullable: true),
                    ContactPhone = table.Column<string>(type: "text", nullable: true),
                    CancellationPolicy = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "text", nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationEvent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizationEvent_OrganizationFacility_FacilityId",
                        column: x => x.FacilityId,
                        principalTable: "OrganizationFacility",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OrganizationEvent_Organization_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrainingGoal",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    TrainingPlanId = table.Column<long>(type: "bigint", nullable: true),
                    GoalType = table.Column<string>(type: "text", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    TargetDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    TargetValue = table.Column<decimal>(type: "numeric", nullable: true),
                    TargetUnit = table.Column<string>(type: "text", nullable: true),
                    CurrentValue = table.Column<decimal>(type: "numeric", nullable: true),
                    IsAchieved = table.Column<bool>(type: "boolean", nullable: false),
                    AchievedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Priority = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingGoal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingGoal_TrainingPlan_TrainingPlanId",
                        column: x => x.TrainingPlanId,
                        principalTable: "TrainingPlan",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TrainingPeriod",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TrainingPlanId = table.Column<long>(type: "bigint", nullable: false),
                    PeriodType = table.Column<int>(type: "integer", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    WeekNumber = table.Column<int>(type: "integer", nullable: false),
                    VolumePercentage = table.Column<decimal>(type: "numeric", nullable: true),
                    IsCompleted = table.Column<bool>(type: "boolean", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingPeriod", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingPeriod_TrainingPlan_TrainingPlanId",
                        column: x => x.TrainingPlanId,
                        principalTable: "TrainingPlan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrainingProgress",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    TrainingPlanId = table.Column<long>(type: "bigint", nullable: false),
                    MeasurementDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    MetricType = table.Column<string>(type: "text", nullable: false),
                    MetricName = table.Column<string>(type: "text", nullable: false),
                    Value = table.Column<decimal>(type: "numeric", nullable: false),
                    Unit = table.Column<string>(type: "text", nullable: false),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    MeasuredBy = table.Column<string>(type: "text", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingProgress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingProgress_TrainingPlan_TrainingPlanId",
                        column: x => x.TrainingPlanId,
                        principalTable: "TrainingPlan",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Payment",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    SubscriptionId = table.Column<long>(type: "bigint", nullable: true),
                    PayPerUseId = table.Column<long>(type: "bigint", nullable: true),
                    PaymentMethodId = table.Column<long>(type: "bigint", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    Currency = table.Column<string>(type: "text", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    TransactionId = table.Column<string>(type: "text", nullable: false),
                    ProcessedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    FailureReason = table.Column<string>(type: "text", nullable: true),
                    RefundedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RefundAmount = table.Column<decimal>(type: "numeric", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Payment_PayPerUse_PayPerUseId",
                        column: x => x.PayPerUseId,
                        principalTable: "PayPerUse",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Payment_PaymentMethod_PaymentMethodId",
                        column: x => x.PaymentMethodId,
                        principalTable: "PaymentMethod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Payment_Subscription_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalTable: "Subscription",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "TicketAttachment",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TicketId = table.Column<long>(type: "bigint", nullable: false),
                    TicketMessageId = table.Column<long>(type: "bigint", nullable: true),
                    FileName = table.Column<string>(type: "text", nullable: false),
                    FileType = table.Column<int>(type: "integer", nullable: false),
                    FileSize = table.Column<int>(type: "integer", nullable: false),
                    FileUrl = table.Column<string>(type: "text", nullable: false),
                    UploadedBy = table.Column<long>(type: "bigint", nullable: false),
                    IsPublic = table.Column<bool>(type: "boolean", nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketAttachment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketAttachment_SupportTicket_TicketId",
                        column: x => x.TicketId,
                        principalTable: "SupportTicket",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TicketAttachment_TicketMessage_TicketMessageId",
                        column: x => x.TicketMessageId,
                        principalTable: "TicketMessage",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AIGenerationFeedback",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AIGenerationRequestId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Rating = table.Column<int>(type: "integer", nullable: false),
                    Comment = table.Column<string>(type: "text", nullable: true),
                    IsUseful = table.Column<bool>(type: "boolean", nullable: false),
                    ImprovementSuggestions = table.Column<string>(type: "text", nullable: true),
                    ProblemQuality = table.Column<int>(type: "integer", nullable: true),
                    DifficultyAccuracy = table.Column<int>(type: "integer", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AIGenerationFeedback", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AIGenerationFeedback_AIGenerationRequest_AIGenerationReques~",
                        column: x => x.AIGenerationRequestId,
                        principalTable: "AIGenerationRequest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AIGenerationHistory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AIGenerationRequestId = table.Column<long>(type: "bigint", nullable: false),
                    AIModelVersionId = table.Column<long>(type: "bigint", nullable: false),
                    Step = table.Column<string>(type: "text", nullable: false),
                    StepData = table.Column<string>(type: "text", nullable: false),
                    Duration = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    Message = table.Column<string>(type: "text", nullable: true),
                    Timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AIGenerationHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AIGenerationHistory_AIGenerationRequest_AIGenerationRequest~",
                        column: x => x.AIGenerationRequestId,
                        principalTable: "AIGenerationRequest",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AIGenerationHistory_AIModelVersion_AIModelVersionId",
                        column: x => x.AIModelVersionId,
                        principalTable: "AIModelVersion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BoardProblemAngle",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BoardProblemId = table.Column<long>(type: "bigint", nullable: false),
                    BoardAngleId = table.Column<long>(type: "bigint", nullable: false),
                    DifficultyScaleId = table.Column<long>(type: "bigint", nullable: false),
                    Rating = table.Column<float>(type: "real", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardProblemAngle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BoardProblemAngle_BoardAngle_BoardAngleId",
                        column: x => x.BoardAngleId,
                        principalTable: "BoardAngle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BoardProblemAngle_BoardProblem_BoardProblemId",
                        column: x => x.BoardProblemId,
                        principalTable: "BoardProblem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BoardProblemAngle_DifficultyScale_DifficultyScaleId",
                        column: x => x.DifficultyScaleId,
                        principalTable: "DifficultyScale",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClimbRoute",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    DifficultyScaleId = table.Column<long>(type: "bigint", nullable: false),
                    DifficultyScaleNameId = table.Column<long>(type: "bigint", nullable: false),
                    ClimbTagId = table.Column<long>(type: "bigint", nullable: true),
                    PitchCount = table.Column<int>(type: "integer", nullable: true),
                    FirstAscentDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ClimbZoneId = table.Column<long>(type: "bigint", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClimbRoute", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClimbRoute_ClimbTag_ClimbTagId",
                        column: x => x.ClimbTagId,
                        principalTable: "ClimbTag",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ClimbRoute_ClimbZone_ClimbZoneId",
                        column: x => x.ClimbZoneId,
                        principalTable: "ClimbZone",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ClimbRoute_DifficultyScaleName_DifficultyScaleNameId",
                        column: x => x.DifficultyScaleNameId,
                        principalTable: "DifficultyScaleName",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClimbRoute_DifficultyScale_DifficultyScaleId",
                        column: x => x.DifficultyScaleId,
                        principalTable: "DifficultyScale",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MountainRoute",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MountainId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    DifficultyScaleId = table.Column<long>(type: "bigint", nullable: false),
                    Distance = table.Column<float>(type: "real", nullable: false),
                    ElevationGain = table.Column<int>(type: "integer", nullable: true),
                    ElevationLoss = table.Column<int>(type: "integer", nullable: true),
                    EstimatedDuration = table.Column<int>(type: "integer", nullable: false),
                    BestSeason = table.Column<int>(type: "integer", nullable: false),
                    RequiresPermit = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    MaxParticipants = table.Column<int>(type: "integer", nullable: true),
                    IsGuided = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false),
                    DangerLevel = table.Column<int>(type: "integer", nullable: false, defaultValue: 5),
                    FirstAscentDate = table.Column<DateOnly>(type: "date", nullable: true),
                    FirstAscentBy = table.Column<string>(type: "text", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MountainRoute", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MountainRoute_DifficultyScale_DifficultyScaleId",
                        column: x => x.DifficultyScaleId,
                        principalTable: "DifficultyScale",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MountainRoute_Mountain_MountainId",
                        column: x => x.MountainId,
                        principalTable: "Mountain",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserExperienceLevelScale",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    DifficultyScaleId = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserExperienceLevelScale", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserExperienceLevelScale_DifficultyScale_DifficultyScaleId",
                        column: x => x.DifficultyScaleId,
                        principalTable: "DifficultyScale",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserExperienceLevelScale_UserProfile_UserId",
                        column: x => x.UserId,
                        principalTable: "UserProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrganizationEventParticipant",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    EventId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    RegistrationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<string>(type: "text", nullable: false),
                    PaymentStatus = table.Column<string>(type: "text", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    CheckInTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CheckOutTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrganizationEventParticipant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrganizationEventParticipant_OrganizationEvent_EventId",
                        column: x => x.EventId,
                        principalTable: "OrganizationEvent",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrganizationEventParticipant_UserProfile_UserId",
                        column: x => x.UserId,
                        principalTable: "UserProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainingWeek",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TrainingPeriodId = table.Column<long>(type: "bigint", nullable: false),
                    WeekNumber = table.Column<int>(type: "integer", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    TrainingObjective = table.Column<string>(type: "text", nullable: true),
                    ClimbingObjective = table.Column<string>(type: "text", nullable: true),
                    NutritionObjective = table.Column<string>(type: "text", nullable: true),
                    PlannedHours = table.Column<decimal>(type: "numeric", nullable: false),
                    CompletedHours = table.Column<decimal>(type: "numeric", nullable: true),
                    Zone1Hours = table.Column<decimal>(type: "numeric", nullable: true),
                    Zone2Hours = table.Column<decimal>(type: "numeric", nullable: true),
                    Zone3Hours = table.Column<decimal>(type: "numeric", nullable: true),
                    StrengthHours = table.Column<decimal>(type: "numeric", nullable: true),
                    AlpineClimbingHours = table.Column<decimal>(type: "numeric", nullable: true),
                    SchoolClimbingHours = table.Column<decimal>(type: "numeric", nullable: true),
                    ElevationGained = table.Column<int>(type: "integer", nullable: true),
                    WeeklyEvaluation = table.Column<string>(type: "text", nullable: true),
                    IsCompleted = table.Column<bool>(type: "boolean", nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingWeek", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingWeek_TrainingPeriod_TrainingPeriodId",
                        column: x => x.TrainingPeriodId,
                        principalTable: "TrainingPeriod",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "InvoiceItem",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    InvoiceId = table.Column<long>(type: "bigint", nullable: false),
                    PaymentId = table.Column<long>(type: "bigint", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    UnitPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    TotalPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InvoiceItem_Invoice_InvoiceId",
                        column: x => x.InvoiceId,
                        principalTable: "Invoice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InvoiceItem_Payment_PaymentId",
                        column: x => x.PaymentId,
                        principalTable: "Payment",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ClimbRouteDescription",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClimbRouteId = table.Column<long>(type: "bigint", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClimbRouteDescription", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClimbRouteDescription_ClimbRoute_ClimbRouteId",
                        column: x => x.ClimbRouteId,
                        principalTable: "ClimbRoute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ClimbRouteFile",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClimbRouteId = table.Column<long>(type: "bigint", nullable: false),
                    IsSketch = table.Column<bool>(type: "boolean", nullable: false),
                    FileName = table.Column<string>(type: "text", nullable: false),
                    FileType = table.Column<int>(type: "integer", nullable: false),
                    FileSize = table.Column<int>(type: "integer", nullable: false),
                    FileUrl = table.Column<string>(type: "text", nullable: false),
                    FileResourceUrl = table.Column<string[]>(type: "text[]", nullable: true),
                    ThumbnailUrl = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClimbRouteFile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ClimbRouteFile_ClimbRoute_ClimbRouteId",
                        column: x => x.ClimbRouteId,
                        principalTable: "ClimbRoute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RockFeatures",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Description = table.Column<string>(type: "text", nullable: true),
                    ClimbRouteId = table.Column<long>(type: "bigint", nullable: false),
                    RockType = table.Column<string>(type: "text", nullable: true),
                    ClimbRouteId1 = table.Column<long>(type: "bigint", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RockFeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RockFeatures_ClimbRoute_ClimbRouteId",
                        column: x => x.ClimbRouteId,
                        principalTable: "ClimbRoute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RockFeatures_ClimbRoute_ClimbRouteId1",
                        column: x => x.ClimbRouteId1,
                        principalTable: "ClimbRoute",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Expedition",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MountainId = table.Column<long>(type: "bigint", nullable: false),
                    MountainRouteId = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    StartDate = table.Column<DateOnly>(type: "date", nullable: false),
                    EndDate = table.Column<DateOnly>(type: "date", nullable: false),
                    PlannedDurationDays = table.Column<int>(type: "integer", nullable: false),
                    ActualDurationDays = table.Column<int>(type: "integer", nullable: true),
                    MinParticipants = table.Column<int>(type: "integer", nullable: false),
                    MaxParticipants = table.Column<int>(type: "integer", nullable: false),
                    RequiredExperienceLevel = table.Column<string>(type: "text", nullable: true),
                    Cost = table.Column<decimal>(type: "numeric", nullable: true),
                    Currency = table.Column<string>(type: "text", nullable: true),
                    RequiresPermit = table.Column<bool>(type: "boolean", nullable: false),
                    PermitNumber = table.Column<string>(type: "text", nullable: true),
                    InsuranceRequired = table.Column<bool>(type: "boolean", nullable: false),
                    EmergencyContactInfo = table.Column<string[]>(type: "text[]", nullable: true),
                    BaseCampLocation = table.Column<Point>(type: "geography(POINTZ,4326)", nullable: true),
                    BaseCampInfo = table.Column<string>(type: "jsonb", nullable: true),
                    OrganizedBy = table.Column<long>(type: "bigint", nullable: false),
                    OrganizedByOrganizationId = table.Column<long>(type: "bigint", nullable: true),
                    IsPublic = table.Column<bool>(type: "boolean", nullable: false),
                    IsDraft = table.Column<bool>(type: "boolean", nullable: false),
                    RegistrationDeadline = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expedition", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Expedition_MountainRoute_MountainRouteId",
                        column: x => x.MountainRouteId,
                        principalTable: "MountainRoute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Expedition_Mountain_MountainId",
                        column: x => x.MountainId,
                        principalTable: "Mountain",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Expedition_Organization_OrganizedByOrganizationId",
                        column: x => x.OrganizedByOrganizationId,
                        principalTable: "Organization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Expedition_UserProfile_OrganizedBy",
                        column: x => x.OrganizedBy,
                        principalTable: "UserProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RouteFile",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MountainRouteId = table.Column<long>(type: "bigint", nullable: false),
                    FileType = table.Column<int>(type: "integer", nullable: false),
                    FileName = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    FileSize = table.Column<string>(type: "text", nullable: false),
                    FileUrl = table.Column<string>(type: "character varying(2048)", maxLength: 2048, nullable: false),
                    ThumbnailUrl = table.Column<string>(type: "text", nullable: true),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    IsOfficial = table.Column<bool>(type: "boolean", nullable: false),
                    UploadedBy = table.Column<long>(type: "bigint", nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RouteFile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RouteFile_MountainRoute_MountainRouteId",
                        column: x => x.MountainRouteId,
                        principalTable: "MountainRoute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RouteFile_UserProfile_UploadedBy",
                        column: x => x.UploadedBy,
                        principalTable: "UserProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RouteTrack",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MountainRouteId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    TrackData = table.Column<LineString>(type: "geography(LINESTRINGZ,4326)", nullable: false),
                    TotalDistance = table.Column<float>(type: "real", nullable: false),
                    MinElevation = table.Column<int>(type: "integer", nullable: false),
                    MaxElevation = table.Column<int>(type: "integer", nullable: false),
                    RecordedBy = table.Column<string>(type: "text", nullable: true),
                    RecordedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    GpsDevice = table.Column<string>(type: "text", nullable: true),
                    Accuracy = table.Column<float>(type: "real", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RouteTrack", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RouteTrack_MountainRoute_MountainRouteId",
                        column: x => x.MountainRouteId,
                        principalTable: "MountainRoute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RouteWaypoint",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MountainRouteId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Description = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Location = table.Column<Point>(type: "geography(POINTZ,4326)", nullable: false),
                    Sequence = table.Column<int>(type: "integer", nullable: false),
                    WaypointTypeId = table.Column<long>(type: "bigint", nullable: false),
                    EstimatedTimeFromPrevious = table.Column<int>(type: "integer", nullable: false),
                    Notes = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    ImageUrl = table.Column<string[]>(type: "text[]", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RouteWaypoint", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RouteWaypoint_MountainRoute_MountainRouteId",
                        column: x => x.MountainRouteId,
                        principalTable: "MountainRoute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RouteWaypoint_WaypointType_WaypointTypeId",
                        column: x => x.WaypointTypeId,
                        principalTable: "WaypointType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserSession",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    BoardId = table.Column<long>(type: "bigint", nullable: true),
                    ClimbZoneId = table.Column<long>(type: "bigint", nullable: true),
                    MountainRouteId = table.Column<long>(type: "bigint", nullable: true),
                    StartedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSession", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSession_Board_BoardId",
                        column: x => x.BoardId,
                        principalTable: "Board",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserSession_ClimbZone_ClimbZoneId",
                        column: x => x.ClimbZoneId,
                        principalTable: "ClimbZone",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserSession_MountainRoute_MountainRouteId",
                        column: x => x.MountainRouteId,
                        principalTable: "MountainRoute",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserSession_UserProfile_UserId",
                        column: x => x.UserId,
                        principalTable: "UserProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TrainingSession",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TrainingWeekId = table.Column<long>(type: "bigint", nullable: false),
                    Date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ActivityType = table.Column<int>(type: "integer", nullable: false),
                    PlannedDuration = table.Column<int>(type: "integer", nullable: false),
                    ActualDuration = table.Column<int>(type: "integer", nullable: true),
                    TrainingZone = table.Column<int>(type: "integer", nullable: true),
                    ElevationGained = table.Column<int>(type: "integer", nullable: true),
                    WeightCarried = table.Column<decimal>(type: "numeric", nullable: true),
                    Distance = table.Column<decimal>(type: "numeric", nullable: true),
                    HeartRateAvg = table.Column<int>(type: "integer", nullable: true),
                    HeartRateMax = table.Column<int>(type: "integer", nullable: true),
                    Rating = table.Column<int>(type: "integer", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    IsCompleted = table.Column<bool>(type: "boolean", nullable: false),
                    Location = table.Column<string>(type: "text", nullable: true),
                    UserSessionId = table.Column<long>(type: "bigint", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingSession", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingSession_TrainingWeek_TrainingWeekId",
                        column: x => x.TrainingWeekId,
                        principalTable: "TrainingWeek",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrainingVolume",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TrainingWeekId = table.Column<long>(type: "bigint", nullable: false),
                    Zone1Hours = table.Column<decimal>(type: "numeric", nullable: false),
                    Zone34Hours = table.Column<decimal>(type: "numeric", nullable: false),
                    StrengthHours = table.Column<decimal>(type: "numeric", nullable: false),
                    WeeklyTotal = table.Column<decimal>(type: "numeric", nullable: false),
                    AccumulatedTotal = table.Column<decimal>(type: "numeric", nullable: false),
                    PlannedVsActual = table.Column<decimal>(type: "numeric", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingVolume", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingVolume_TrainingWeek_TrainingWeekId",
                        column: x => x.TrainingWeekId,
                        principalTable: "TrainingWeek",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExpeditionBudgetCategory",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ExpeditionId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    IsMandatory = table.Column<bool>(type: "boolean", nullable: false),
                    BudgetLimit = table.Column<decimal>(type: "numeric", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpeditionBudgetCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpeditionBudgetCategory_Expedition_ExpeditionId",
                        column: x => x.ExpeditionId,
                        principalTable: "Expedition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExpeditionEquipment",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ExpeditionId = table.Column<long>(type: "bigint", nullable: false),
                    EquipmentId = table.Column<long>(type: "bigint", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    IsMandatory = table.Column<bool>(type: "boolean", nullable: false),
                    IsProvided = table.Column<bool>(type: "boolean", nullable: false),
                    ResponsibleParticipant = table.Column<long>(type: "bigint", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpeditionEquipment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpeditionEquipment_Equipment_EquipmentId",
                        column: x => x.EquipmentId,
                        principalTable: "Equipment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExpeditionEquipment_Expedition_ExpeditionId",
                        column: x => x.ExpeditionId,
                        principalTable: "Expedition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExpeditionLevelScales",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ExpeditionId = table.Column<long>(type: "bigint", nullable: false),
                    DifficultyScaleId = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpeditionLevelScales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpeditionLevelScales_DifficultyScale_DifficultyScaleId",
                        column: x => x.DifficultyScaleId,
                        principalTable: "DifficultyScale",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExpeditionLevelScales_Expedition_ExpeditionId",
                        column: x => x.ExpeditionId,
                        principalTable: "Expedition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ExpeditionParticipant",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ExpeditionId = table.Column<long>(type: "bigint", nullable: false),
                    UserId = table.Column<long>(type: "bigint", nullable: false),
                    Role = table.Column<int>(type: "integer", nullable: false),
                    InvitedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    JoinedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    StatusChangedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    MedicalClearance = table.Column<bool>(type: "boolean", nullable: false),
                    EmergencyContact = table.Column<string>(type: "text", nullable: true),
                    SpecialRequirements = table.Column<string>(type: "text", nullable: true),
                    PaymentStatus = table.Column<int>(type: "integer", nullable: true),
                    Notes = table.Column<string[]>(type: "text[]", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpeditionParticipant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpeditionParticipant_Expedition_ExpeditionId",
                        column: x => x.ExpeditionId,
                        principalTable: "Expedition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExpeditionParticipant_UserProfile_UserId",
                        column: x => x.UserId,
                        principalTable: "UserProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItineraryDay",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ExpeditionId = table.Column<long>(type: "bigint", nullable: false),
                    DayNumber = table.Column<int>(type: "integer", nullable: false),
                    Date = table.Column<DateOnly>(type: "date", nullable: false),
                    ActivityType = table.Column<int>(type: "integer", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    StartLocation = table.Column<Point>(type: "geography(POINTZ,4326)", nullable: true),
                    EndLocation = table.Column<Point>(type: "geography(POINTZ,4326)", nullable: true),
                    StartElevation = table.Column<int>(type: "integer", nullable: true),
                    EndElevation = table.Column<int>(type: "integer", nullable: true),
                    Distance = table.Column<float>(type: "real", nullable: true),
                    ElevationGain = table.Column<int>(type: "integer", nullable: true),
                    ElevationLoss = table.Column<int>(type: "integer", nullable: true),
                    EstimatedDuration = table.Column<int>(type: "integer", nullable: true),
                    DifficultyRating = table.Column<int>(type: "integer", nullable: false),
                    WeatherDependency = table.Column<bool>(type: "boolean", nullable: false),
                    Notes = table.Column<string[]>(type: "text[]", nullable: true),
                    ExpeditionId1 = table.Column<long>(type: "bigint", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItineraryDay", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItineraryDay_Expedition_ExpeditionId",
                        column: x => x.ExpeditionId,
                        principalTable: "Expedition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItineraryDay_Expedition_ExpeditionId1",
                        column: x => x.ExpeditionId1,
                        principalTable: "Expedition",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ItineraryFile",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ExpeditionId = table.Column<long>(type: "bigint", nullable: false),
                    FileType = table.Column<int>(type: "integer", nullable: false),
                    FileName = table.Column<string>(type: "text", nullable: false),
                    FileSize = table.Column<int>(type: "integer", nullable: false),
                    FileUrl = table.Column<string>(type: "text", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    IsOfficial = table.Column<bool>(type: "boolean", nullable: false),
                    UploadedBy = table.Column<long>(type: "bigint", nullable: true),
                    RequiresSignature = table.Column<bool>(type: "boolean", nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItineraryFile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItineraryFile_Expedition_ExpeditionId",
                        column: x => x.ExpeditionId,
                        principalTable: "Expedition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItineraryTrack",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ExpeditionId = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    TrackType = table.Column<int>(type: "integer", nullable: false),
                    StartDayNumber = table.Column<int>(type: "integer", nullable: false),
                    EndDayNumber = table.Column<int>(type: "integer", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    PlannedRoute = table.Column<LineString>(type: "geography(LINESTRINGZ,4326)", nullable: true),
                    ActualRoute = table.Column<LineString>(type: "geography(LINESTRINGZ,4326)", nullable: true),
                    PlannedDistance = table.Column<decimal>(type: "numeric", nullable: true),
                    ActualDistance = table.Column<decimal>(type: "numeric", nullable: true),
                    PlannedDuration = table.Column<int>(type: "integer", nullable: true),
                    ActualDuration = table.Column<int>(type: "integer", nullable: true),
                    MinElevation = table.Column<int>(type: "integer", nullable: true),
                    MaxElevation = table.Column<int>(type: "integer", nullable: true),
                    CumulativeElevationGain = table.Column<int>(type: "integer", nullable: true),
                    CumulativeElevationLoss = table.Column<int>(type: "integer", nullable: true),
                    RecordedBy = table.Column<long>(type: "bigint", nullable: true),
                    GpsDevice = table.Column<string>(type: "text", nullable: true),
                    Accuracy = table.Column<decimal>(type: "numeric", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    IsOfficial = table.Column<bool>(type: "boolean", nullable: false),
                    BasedOnRouteTrackId = table.Column<long>(type: "bigint", nullable: true),
                    RouteDeviation = table.Column<decimal>(type: "numeric", nullable: true),
                    CompletionPercentage = table.Column<decimal>(type: "numeric", nullable: true),
                    WeatherSummary = table.Column<string>(type: "text", nullable: true),
                    DifficultySummary = table.Column<string>(type: "text", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItineraryTrack", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItineraryTrack_Expedition_ExpeditionId",
                        column: x => x.ExpeditionId,
                        principalTable: "Expedition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SafetyPlan",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ExpeditionId = table.Column<long>(type: "bigint", nullable: false),
                    EmergencyContactName = table.Column<string>(type: "text", nullable: false),
                    EmergencyContactPhone = table.Column<string>(type: "text", nullable: false),
                    EmergencyContactRelation = table.Column<string>(type: "text", nullable: false),
                    LocalRescueService = table.Column<string>(type: "text", nullable: true),
                    NearestHospital = table.Column<string>(type: "text", nullable: true),
                    EvacuationPlan = table.Column<string>(type: "text", nullable: true),
                    CommunicationPlan = table.Column<string>(type: "text", nullable: true),
                    RiskAssessment = table.Column<string>(type: "text", nullable: true),
                    ContingencyPlans = table.Column<string>(type: "text", nullable: true),
                    MedicalSupplies = table.Column<string>(type: "text", nullable: true),
                    LastUpdated = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SafetyPlan", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SafetyPlan_Expedition_ExpeditionId",
                        column: x => x.ExpeditionId,
                        principalTable: "Expedition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserSessionProgress",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserSessionId = table.Column<long>(type: "bigint", nullable: false),
                    ClimbRouteId = table.Column<long>(type: "bigint", nullable: true),
                    BoardProblemId = table.Column<long>(type: "bigint", nullable: true),
                    BoardAngleId = table.Column<long>(type: "bigint", nullable: true),
                    FootRuleId = table.Column<long>(type: "bigint", nullable: true),
                    MountainRouteId = table.Column<long>(type: "bigint", nullable: true),
                    ClimbTickType = table.Column<int>(type: "integer", nullable: true),
                    MountaineerTickType = table.Column<int>(type: "integer", nullable: true),
                    IsCompleted = table.Column<bool>(type: "boolean", nullable: false),
                    Duration = table.Column<int>(type: "integer", nullable: true),
                    TryAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    MaxElevationReached = table.Column<int>(type: "integer", nullable: true),
                    WeatherConditions = table.Column<string>(type: "text", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSessionProgress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSessionProgress_BoardAngle_BoardAngleId",
                        column: x => x.BoardAngleId,
                        principalTable: "BoardAngle",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserSessionProgress_BoardProblem_BoardProblemId",
                        column: x => x.BoardProblemId,
                        principalTable: "BoardProblem",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserSessionProgress_ClimbRoute_ClimbRouteId",
                        column: x => x.ClimbRouteId,
                        principalTable: "ClimbRoute",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserSessionProgress_FootRule_FootRuleId",
                        column: x => x.FootRuleId,
                        principalTable: "FootRule",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserSessionProgress_MountainRoute_MountainRouteId",
                        column: x => x.MountainRouteId,
                        principalTable: "MountainRoute",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserSessionProgress_UserSession_UserSessionId",
                        column: x => x.UserSessionId,
                        principalTable: "UserSession",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SessionExercise",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TrainingSessionId = table.Column<long>(type: "bigint", nullable: false),
                    TrainingExerciseId = table.Column<long>(type: "bigint", nullable: false),
                    Sets = table.Column<int>(type: "integer", nullable: true),
                    Reps = table.Column<int>(type: "integer", nullable: true),
                    Weight = table.Column<decimal>(type: "numeric", nullable: true),
                    Duration = table.Column<int>(type: "integer", nullable: true),
                    Distance = table.Column<decimal>(type: "numeric", nullable: true),
                    RestTime = table.Column<int>(type: "integer", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    Sequence = table.Column<int>(type: "integer", nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SessionExercise", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SessionExercise_TrainingExercise_TrainingExerciseId",
                        column: x => x.TrainingExerciseId,
                        principalTable: "TrainingExercise",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SessionExercise_TrainingSession_TrainingSessionId",
                        column: x => x.TrainingSessionId,
                        principalTable: "TrainingSession",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TrainingSessionClimbing",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TrainingSessionId = table.Column<long>(type: "bigint", nullable: false),
                    UserSessionId = table.Column<long>(type: "bigint", nullable: false),
                    PlannedObjective = table.Column<string>(type: "text", nullable: true),
                    ActualPerformance = table.Column<string>(type: "text", nullable: true),
                    TechnicalFocus = table.Column<string>(type: "text", nullable: true),
                    IntensityLevel = table.Column<int>(type: "integer", nullable: true),
                    RestTimesBetweenProblems = table.Column<int>(type: "integer", nullable: true),
                    WarmUpDuration = table.Column<int>(type: "integer", nullable: true),
                    CoolDownDuration = table.Column<int>(type: "integer", nullable: true),
                    TrainingNotes = table.Column<string>(type: "text", nullable: true),
                    CoachFeedback = table.Column<string>(type: "text", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainingSessionClimbing", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TrainingSessionClimbing_TrainingSession_TrainingSessionId",
                        column: x => x.TrainingSessionId,
                        principalTable: "TrainingSession",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TrainingSessionClimbing_UserSession_UserSessionId",
                        column: x => x.UserSessionId,
                        principalTable: "UserSession",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExpeditionBudget",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ExpeditionId = table.Column<long>(type: "bigint", nullable: false),
                    ExpeditionBudgetCategoryId = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    PlannedCost = table.Column<decimal>(type: "numeric", nullable: false),
                    ActualCost = table.Column<decimal>(type: "numeric", nullable: true),
                    Currency = table.Column<string>(type: "text", nullable: false),
                    IsPaid = table.Column<bool>(type: "boolean", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Vendor = table.Column<string>(type: "text", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    ExpeditionBudgetCategoryId1 = table.Column<long>(type: "bigint", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExpeditionBudget", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExpeditionBudget_ExpeditionBudgetCategory_ExpeditionBudgetC~",
                        column: x => x.ExpeditionBudgetCategoryId,
                        principalTable: "ExpeditionBudgetCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ExpeditionBudget_ExpeditionBudgetCategory_ExpeditionBudget~1",
                        column: x => x.ExpeditionBudgetCategoryId1,
                        principalTable: "ExpeditionBudgetCategory",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ExpeditionBudget_Expedition_ExpeditionId",
                        column: x => x.ExpeditionId,
                        principalTable: "Expedition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Accommodation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ExpeditionId = table.Column<long>(type: "bigint", nullable: false),
                    ItineraryDayId = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Location = table.Column<Point>(type: "geography(POINTZ,4326)", nullable: true),
                    Address = table.Column<string>(type: "text", nullable: true),
                    Elevation = table.Column<int>(type: "integer", nullable: true),
                    Capacity = table.Column<int>(type: "integer", nullable: true),
                    Cost = table.Column<decimal>(type: "numeric", nullable: true),
                    Currency = table.Column<string>(type: "text", nullable: true),
                    ContactInfo = table.Column<string>(type: "text", nullable: true),
                    BookingReference = table.Column<string>(type: "text", nullable: true),
                    CheckIn = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    CheckOut = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Amenities = table.Column<string>(type: "text", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accommodation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accommodation_Expedition_ExpeditionId",
                        column: x => x.ExpeditionId,
                        principalTable: "Expedition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Accommodation_ItineraryDay_ItineraryDayId",
                        column: x => x.ItineraryDayId,
                        principalTable: "ItineraryDay",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DayActivity",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ItineraryDayId = table.Column<long>(type: "bigint", nullable: false),
                    Sequence = table.Column<int>(type: "integer", nullable: false),
                    StartTime = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    EndTime = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    ActivityName = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Location = table.Column<Point>(type: "geography(POINTZ,4326)", nullable: true),
                    Elevation = table.Column<int>(type: "integer", nullable: true),
                    EstimatedDuration = table.Column<int>(type: "integer", nullable: true),
                    IsOptional = table.Column<bool>(type: "boolean", nullable: false),
                    RequiredEquipment = table.Column<string>(type: "text", nullable: true),
                    SafetyNotes = table.Column<string>(type: "text", nullable: true),
                    AlternativePlan = table.Column<string>(type: "text", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayActivity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DayActivity_ItineraryDay_ItineraryDayId",
                        column: x => x.ItineraryDayId,
                        principalTable: "ItineraryDay",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Meal",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ExpeditionId = table.Column<long>(type: "bigint", nullable: false),
                    ItineraryDayId = table.Column<long>(type: "bigint", nullable: true),
                    MealType = table.Column<string>(type: "text", nullable: false),
                    Time = table.Column<TimeOnly>(type: "time without time zone", nullable: true),
                    Location = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Calories = table.Column<int>(type: "integer", nullable: true),
                    IsVegetarian = table.Column<bool>(type: "boolean", nullable: false),
                    IsVegan = table.Column<bool>(type: "boolean", nullable: false),
                    Allergens = table.Column<string>(type: "text", nullable: true),
                    PreparedBy = table.Column<string>(type: "text", nullable: true),
                    Cost = table.Column<decimal>(type: "numeric", nullable: true),
                    Currency = table.Column<string>(type: "text", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Meal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Meal_Expedition_ExpeditionId",
                        column: x => x.ExpeditionId,
                        principalTable: "Expedition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Meal_ItineraryDay_ItineraryDayId",
                        column: x => x.ItineraryDayId,
                        principalTable: "ItineraryDay",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Transportation",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ExpeditionId = table.Column<long>(type: "bigint", nullable: false),
                    ItineraryDayId = table.Column<long>(type: "bigint", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: false),
                    Provider = table.Column<string>(type: "text", nullable: true),
                    Departure = table.Column<Point>(type: "geography(POINTZ,4326)", nullable: true),
                    Arrival = table.Column<Point>(type: "geography(POINTZ,4326)", nullable: true),
                    DepartureLocation = table.Column<string>(type: "text", nullable: false),
                    ArrivalLocation = table.Column<string>(type: "text", nullable: false),
                    DepartureTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ArrivalTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Duration = table.Column<int>(type: "integer", nullable: true),
                    Cost = table.Column<decimal>(type: "numeric", nullable: true),
                    Currency = table.Column<string>(type: "text", nullable: true),
                    BookingReference = table.Column<string>(type: "text", nullable: true),
                    ContactInfo = table.Column<string>(type: "text", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transportation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Transportation_Expedition_ExpeditionId",
                        column: x => x.ExpeditionId,
                        principalTable: "Expedition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transportation_ItineraryDay_ItineraryDayId",
                        column: x => x.ItineraryDayId,
                        principalTable: "ItineraryDay",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ItineraryDayTrack",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ItineraryDayId = table.Column<long>(type: "bigint", nullable: false),
                    ItineraryTrackId = table.Column<long>(type: "bigint", nullable: true),
                    ParticipantId = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: true),
                    TrackData = table.Column<LineString>(type: "geography(LINESTRINGZ,4326)", nullable: false),
                    PlannedRoute = table.Column<LineString>(type: "geography(LINESTRINGZ,4326)", nullable: true),
                    TotalDistance = table.Column<decimal>(type: "numeric", nullable: false),
                    MovingTime = table.Column<int>(type: "integer", nullable: false),
                    TotalTime = table.Column<int>(type: "integer", nullable: false),
                    MinElevation = table.Column<int>(type: "integer", nullable: false),
                    MaxElevation = table.Column<int>(type: "integer", nullable: false),
                    ElevationGain = table.Column<int>(type: "integer", nullable: false),
                    ElevationLoss = table.Column<int>(type: "integer", nullable: false),
                    StartTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    EndTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RecordedBy = table.Column<string>(type: "text", nullable: true),
                    GpsDevice = table.Column<string>(type: "text", nullable: true),
                    Accuracy = table.Column<decimal>(type: "numeric", nullable: true),
                    WeatherConditions = table.Column<string>(type: "text", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    IsOfficial = table.Column<bool>(type: "boolean", nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItineraryDayTrack", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItineraryDayTrack_ItineraryDay_ItineraryDayId",
                        column: x => x.ItineraryDayId,
                        principalTable: "ItineraryDay",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItineraryDayTrack_ItineraryTrack_ItineraryTrackId",
                        column: x => x.ItineraryTrackId,
                        principalTable: "ItineraryTrack",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItineraryTrackFile",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ItineraryTrackId = table.Column<long>(type: "bigint", nullable: false),
                    FileType = table.Column<int>(type: "integer", nullable: false),
                    FileName = table.Column<string>(type: "text", nullable: false),
                    FileSize = table.Column<int>(type: "integer", nullable: false),
                    FileUrl = table.Column<string>(type: "text", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    IsPrimary = table.Column<bool>(type: "boolean", nullable: false),
                    UploadedBy = table.Column<long>(type: "bigint", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItineraryTrackFile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItineraryTrackFile_ItineraryTrack_ItineraryTrackId",
                        column: x => x.ItineraryTrackId,
                        principalTable: "ItineraryTrack",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MountainExpeditionLog",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ExpeditionId = table.Column<long>(type: "bigint", nullable: true),
                    UserId = table.Column<long>(type: "bigint", nullable: true),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Duration = table.Column<int>(type: "integer", nullable: true),
                    MaxElevationReached = table.Column<int>(type: "integer", nullable: true),
                    MinElevationReached = table.Column<int>(type: "integer", nullable: true),
                    WeatherConditions = table.Column<string>(type: "text", nullable: true),
                    Notes = table.Column<string[]>(type: "text[]", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Content = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    RouteTaken = table.Column<LineString>(type: "geography(LINESTRINGZ,4326)", nullable: true),
                    Photos = table.Column<string>(type: "jsonb", nullable: true),
                    ChallengesFaced = table.Column<string[]>(type: "text[]", nullable: true),
                    EquipmentUsed = table.Column<string[]>(type: "text[]", nullable: true),
                    WeatherAtSummit = table.Column<string>(type: "text", nullable: true),
                    IsSuccessfull = table.Column<bool>(type: "boolean", nullable: false),
                    TickType = table.Column<int>(type: "integer", nullable: false),
                    GroupSize = table.Column<int>(type: "integer", nullable: true),
                    GuideId = table.Column<long>(type: "bigint", nullable: true),
                    SafetyIncidents = table.Column<string>(type: "jsonb", nullable: true),
                    MountainRouteId = table.Column<long>(type: "bigint", nullable: true),
                    ItineraryTrackId = table.Column<long>(type: "bigint", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MountainExpeditionLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MountainExpeditionLog_Expedition_ExpeditionId",
                        column: x => x.ExpeditionId,
                        principalTable: "Expedition",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MountainExpeditionLog_ItineraryTrack_ItineraryTrackId",
                        column: x => x.ItineraryTrackId,
                        principalTable: "ItineraryTrack",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MountainExpeditionLog_MountainRoute_MountainRouteId",
                        column: x => x.MountainRouteId,
                        principalTable: "MountainRoute",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MountainExpeditionLog_UserProfile_GuideId",
                        column: x => x.GuideId,
                        principalTable: "UserProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MountainExpeditionLog_UserProfile_UserId",
                        column: x => x.UserId,
                        principalTable: "UserProfile",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DayActivityDifficultyScale",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DayActivityId = table.Column<long>(type: "bigint", nullable: false),
                    DifficultyScaleId = table.Column<long>(type: "bigint", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayActivityDifficultyScale", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DayActivityDifficultyScale_DayActivity_DayActivityId",
                        column: x => x.DayActivityId,
                        principalTable: "DayActivity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DayActivityDifficultyScale_DifficultyScale_DifficultyScaleId",
                        column: x => x.DifficultyScaleId,
                        principalTable: "DifficultyScale",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItineraryDayTrackFile",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ItineraryDayTrackId = table.Column<long>(type: "bigint", nullable: false),
                    FileType = table.Column<int>(type: "integer", nullable: false),
                    FileName = table.Column<string>(type: "text", nullable: false),
                    FileSize = table.Column<int>(type: "integer", nullable: false),
                    FileUrl = table.Column<string>(type: "text", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    IsPrimary = table.Column<bool>(type: "boolean", nullable: false),
                    UploadedBy = table.Column<long>(type: "bigint", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItineraryDayTrackFile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItineraryDayTrackFile_ItineraryDayTrack_ItineraryDayTrackId",
                        column: x => x.ItineraryDayTrackId,
                        principalTable: "ItineraryDayTrack",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItineraryDayWaypoint",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ItineraryDayId = table.Column<long>(type: "bigint", nullable: false),
                    ItineraryDayTrackId = table.Column<long>(type: "bigint", nullable: true),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Location = table.Column<Point>(type: "geography(POINTZ,4326)", nullable: false),
                    Elevation = table.Column<int>(type: "integer", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    WaypointTypeId = table.Column<long>(type: "bigint", nullable: false),
                    Duration = table.Column<int>(type: "integer", nullable: true),
                    Photo = table.Column<string>(type: "text", nullable: true),
                    Notes = table.Column<string>(type: "text", nullable: true),
                    RecordedBy = table.Column<long>(type: "bigint", nullable: true),
                    WeatherConditions = table.Column<string>(type: "text", nullable: true),
                    Temperature = table.Column<decimal>(type: "numeric", nullable: true),
                    IsPlanned = table.Column<bool>(type: "boolean", nullable: false),
                    IsEmergency = table.Column<bool>(type: "boolean", nullable: false),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItineraryDayWaypoint", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItineraryDayWaypoint_ItineraryDayTrack_ItineraryDayTrackId",
                        column: x => x.ItineraryDayTrackId,
                        principalTable: "ItineraryDayTrack",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ItineraryDayWaypoint_ItineraryDay_ItineraryDayId",
                        column: x => x.ItineraryDayId,
                        principalTable: "ItineraryDay",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItineraryDayWaypoint_WaypointType_WaypointTypeId",
                        column: x => x.WaypointTypeId,
                        principalTable: "WaypointType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ItineraryDayWaypointFile",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ItineraryDayWaypointId = table.Column<long>(type: "bigint", nullable: false),
                    FileType = table.Column<int>(type: "integer", nullable: false),
                    FileName = table.Column<string>(type: "text", nullable: false),
                    FileSize = table.Column<int>(type: "integer", nullable: false),
                    FileUrl = table.Column<string>(type: "text", nullable: false),
                    Title = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    IsPrimary = table.Column<bool>(type: "boolean", nullable: false),
                    UploadedBy = table.Column<long>(type: "bigint", nullable: true),
                    Uid = table.Column<Guid>(type: "uuid", nullable: false),
                    Slug = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: false),
                    MetaData = table.Column<Metadata>(type: "jsonb", nullable: true),
                    RowVersion = table.Column<byte[]>(type: "bytea", rowVersion: true, nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    RestoredAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    LockedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItineraryDayWaypointFile", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItineraryDayWaypointFile_ItineraryDayWaypoint_ItineraryDayW~",
                        column: x => x.ItineraryDayWaypointId,
                        principalTable: "ItineraryDayWaypoint",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "DifficultyGroup",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Description", "Level", "LockedAt", "MetaData", "Name", "RestoredAt", "Slug", "Uid", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, new DateTime(2026, 4, 2, 20, 1, 41, 512, DateTimeKind.Utc).AddTicks(1189), null, "Suitable for beginners.", 1, null, null, "Beginner", null, "DifficultyGroup/beginner", new Guid("d9ea3890-3371-426e-b72d-9a3db4d5ed51"), null },
                    { 2L, new DateTime(2026, 4, 2, 20, 1, 41, 512, DateTimeKind.Utc).AddTicks(1220), null, "Suitable for intermediate climbers.", 2, null, null, "Intermediate", null, "DifficultyGroup/intermediate", new Guid("02a4d121-95e9-4758-b526-90913222b930"), null },
                    { 3L, new DateTime(2026, 4, 2, 20, 1, 41, 512, DateTimeKind.Utc).AddTicks(1224), null, "Suitable for advanced climbers.", 3, null, null, "Advanced", null, "DifficultyGroup/advanced", new Guid("bf4c6a68-6338-4811-9531-3092979947a9"), null },
                    { 4L, new DateTime(2026, 4, 2, 20, 1, 41, 512, DateTimeKind.Utc).AddTicks(1227), null, "Suitable for expert climbers.", 4, null, null, "Expert", null, "DifficultyGroup/expert", new Guid("975b7859-ca45-4c9e-b620-7e459e2e7d39"), null },
                    { 5L, new DateTime(2026, 4, 2, 20, 1, 41, 512, DateTimeKind.Utc).AddTicks(1230), null, "Suitable for elite climbers.", 5, null, null, "Elite", null, "DifficultyGroup/elite", new Guid("0387a12f-f424-4862-86c5-42c11592e623"), null }
                });

            migrationBuilder.InsertData(
                table: "DifficultyScaleType",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Description", "Icon", "LockedAt", "MetaData", "Name", "RestoredAt", "Slug", "Uid", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, new DateTime(2026, 4, 2, 20, 1, 41, 518, DateTimeKind.Utc).AddTicks(2718), null, "Rock climbing using rope and protection. Sport climbing relies on fixed bolts, while traditional climbing requires placing and removing gear such as cams and nuts.", "<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n<!-- Uploaded to: SVG Repo, www.svgrepo.com, Generator: SVG Repo Mixer Tools -->\r\n<svg fill=\"#000000\" height=\"800px\" width=\"800px\" version=\"1.2\" baseProfile=\"tiny\" id=\"Layer_1\" xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\"\r\n	  viewBox=\"0 0 256 256\" xml:space=\"preserve\">\r\n<g id=\"XMLID_2_\">\r\n	<path id=\"XMLID_7_\" d=\"M131.9,169.1c-2.3,0.9-5,1.4-7.7,1.4c-2.9,0-5.7-0.3-8.4-1.1l-29.7,68.3c-2.7,6.3-10.2,8.4-16.7,4.8\r\n		c-6.5-3.7-9.6-11.7-6.8-18l36.4-83.6h46.5v-7.8l23.5-10.9c6.2-3,14.2,2.1,15.8,8.6l11.5,46.2c1.6,6.6-2.4,13.2-8.9,14.8\r\n		c-6.6,1.6-13.2-2.4-14.9-8.9l-7.3-29.5L131.9,169.1z\"/>\r\n	<path id=\"XMLID_6_\" d=\"M153.3,121.2C204.2,95.9,223.9,9.5,223.9,2.3h-7c-2.6,18-24.5,90.2-63.6,111.1V121.2z\"/>\r\n	<path id=\"XMLID_5_\" d=\"M59.4,102.3c2.7,4.2,8,6,12.8,4l26.9-10.5v37.3h46.5V89.9l41.7-66.6c3.1-4.9,1.6-11.3-3.3-14.4\r\n		c-4.9-3.1-11.3-1.6-14,3.1l-35.4,56.6l-21.3,0.1c-1.4,0-2.7,0.2-4.1,0.8L72.3,83.8l-19-28.8c-3.1-4.8-9.6-6.2-14.4-3.1\r\n		c-4.9,3.1-6.3,9.6-3.2,14.5L59.4,102.3z\"/>\r\n	<path id=\"XMLID_4_\" d=\"M119.1,64.8c10.2,0,18.5-8.3,18.5-18.5s-8.3-18.5-18.5-18.5c-10.2,0-18.5,8.3-18.5,18.5\r\n		S108.9,64.8,119.1,64.8z\"/>\r\n	<polygon id=\"XMLID_3_\" points=\"145.5,253.8 145.5,170.5 137.7,174.1 137.7,253.8 	\"/>\r\n</g>\r\n</svg>", null, null, "Sport and Traditional Climbing", null, "DifficultyScaleType/sport-and-traditional-climbing", new Guid("dbbe06f1-fb76-4798-ac4c-2478a4e3b8ae"), null },
                    { 2L, new DateTime(2026, 4, 2, 20, 1, 41, 518, DateTimeKind.Utc).AddTicks(2740), null, "Progression on a wall by relying mainly on technical equipment (aider ladders, hooks, pitons, nuts, rivets, etc.) to advance where free climbing is not possible.", "<?xml version='1.0' encoding='iso-8859-1'?>\r\n<!-- Uploaded to: SVG Repo, www.svgrepo.com, Generator: SVG Repo Mixer Tools -->\r\n<svg fill=\"#000000\" height=\"800px\" width=\"800px\" version=\"1.1\" xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 304.515 304.515\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" enable-background=\"new 0 0 304.515 304.515\">\r\n  <g>\r\n    <g>\r\n      <path d=\"m148.078,256.816l-25.964-18.122-10.657-1.392 15.756,56.255c2.236,7.983 10.519,12.631 18.49,10.398 7.977-2.234 12.633-10.513 10.399-18.49l-8.024-28.649z\"/>\r\n      <circle cx=\"62.034\" cy=\"61.041\" r=\"25.907\"/>\r\n      <path d=\"m187.079,232.819l-46.337-32.342c-1.975-1.379-4.253-2.261-6.642-2.574l-59.266-7.744c2.483,5.066 10.024,17.088 0.728,30.351l51.015,6.665 43.33,30.244c6.808,4.751 16.154,3.064 20.886-3.715 4.742-6.793 3.079-16.143-3.714-20.885z\"/>\r\n      <path d=\"m277.617,0h-179.556c-1.313,0-2.467,0.867-2.833,2.128s0.145,2.611 1.254,3.314l8.584,5.441-.975,56.237-23.316,25.842-30.97,3.172c-9.615,0.985-16.611,9.578-15.627,19.193l.912,8.902 13.95-14.214-26.716,44.352c-2.114,3.622-2.269,8.053-0.43,11.805l22.403,45.75c3.08,6.285 10.641,8.706 16.726,5.722 6.228-3.052 8.749-10.552 5.722-16.726l-19.031-38.825 23.973-41.053-10.414,37.143-.768,2.741 12.829,26.172 34.443-3.016-7.701-75.191 25.73-28.517c2.033-2.254 3.178-5.17 3.219-8.204l.612-45.104c3.917,3.635 6.836,8.259 8.415,13.433l10.505,34.42c1.42,4.654 3.935,8.9 7.333,12.382l36.043,36.93c5.928,6.074 9.052,14.346 8.62,22.822l-2.874,56.391c-0.293,5.751 1.05,11.467 3.874,16.486l25.059,44.532c3.008,5.345 7.56,9.658 13.06,12.373l35.164,17.359c1.947,0.961 4.252,0.849 6.095-0.297 1.844-1.146 2.965-3.163 2.965-5.334v-282.281c0.001-3.468-2.811-6.28-6.279-6.28z\"/>\r\n    </g>\r\n  </g>\r\n</svg>", null, null, "Aid Climbing", null, "DifficultyScaleType/aid-climbing", new Guid("1d359729-f5a3-4cd6-bc32-e1fb6762b855"), null },
                    { 3L, new DateTime(2026, 4, 2, 20, 1, 41, 518, DateTimeKind.Utc).AddTicks(2746), null, "Climbing short walls or boulders without a rope, focused on powerful and dynamic movements, protected with crash pads and spotters.", "<?xml version='1.0' encoding='iso-8859-1'?>\r\n<!-- Uploaded to: SVG Repo, www.svgrepo.com, Generator: SVG Repo Mixer Tools -->\r\n<svg fill=\"#000000\" height=\"800px\" width=\"800px\" version=\"1.1\" xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 312.021 312.021\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" enable-background=\"new 0 0 312.021 312.021\">\r\n  <g>\r\n    <g>\r\n      <path d=\"m302.15,120.556c-68.011-0.884-123.443-11.77-165.517-24.544l3.38,21.826c48.269,13.719 103.141,21.953 161.878,22.717 0.045,0.001 0.088,0.001 0.133,0.001 5.462,0 9.925-4.393 9.996-9.87 0.071-5.524-4.348-10.059-9.87-10.13z\"/>\r\n      <path d=\"m220.833,203.895l-6.919,2.255-19.293,19.648 7.214,1.408 48.721,45.66c6.04,5.663 15.533,5.36 21.201-0.687 5.665-6.045 5.357-15.537-0.686-21.202l-50.238-47.082z\"/>\r\n      <circle cx=\"35.91\" cy=\"147.114\" r=\"25.907\"/>\r\n      <path d=\"m257.646,179.275c7.892-2.573 12.176-11.049 9.614-18.91-2.568-7.877-11.033-12.181-18.91-9.614l-53.726,17.511c-2.29,0.746-4.367,2.034-6.055,3.752l-52.218,53.178 25.33-40.49-32.148-19.459-40.696,22.738 38.763-35.404c3.091-2.824 4.564-7.006 3.923-11.143l-7.642-49.353c-1.058-6.835-7.471-11.493-14.266-10.44-6.814,1.055-11.498,7.434-10.44,14.266l6.616,42.729-35.103,32.061c7.644-11.783 14.368-22.147 22.544-34.75-5.674-36.645-5.519-35.642-5.916-38.204-1.19-7.683 1.35-15.152 6.355-20.499-2.346-5.925-8.856-9.202-15.098-7.394-1.645,0.477-3.115,1.264-4.369,2.277-37.932-17.938-57.275-34.261-57.676-34.603-4.182-3.605-10.49-3.137-14.096,1.04-3.61,4.18-3.148,10.495 1.033,14.105 0.984,0.849 23.679,20.209 68.9,40.641l10.409,35.869c0,0-8.836,18.045-26.215,48.833-5.005,8.269-2.359,19.029 5.909,24.034 8.474,5.129 68.705,41.586 77.332,46.808l-.005-.036c5.89,3.263 13.221,2.223 17.962-2.605l49.649-50.563 50.24-16.375z\"/>\r\n    </g>\r\n  </g>\r\n</svg>", null, null, "Bouldering", null, "DifficultyScaleType/bouldering", new Guid("9b9412bf-6675-44b6-a028-bb0cd9c9b80b"), null },
                    { 4L, new DateTime(2026, 4, 2, 20, 1, 41, 518, DateTimeKind.Utc).AddTicks(2749), null, "Climbing frozen waterfalls, seracs, or steep icy slopes using technical ice axes and crampons, protected with ice screws.", "<?xml version=\"1.0\" encoding=\"iso-8859-1\"?>\r\n<!-- Uploaded to: SVG Repo, www.svgrepo.com, Generator: SVG Repo Mixer Tools -->\r\n<svg fill=\"#000000\" height=\"800px\" width=\"800px\" version=\"1.1\" id=\"Layer_1\" xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" \r\n	 viewBox=\"0 0 512 512\" xml:space=\"preserve\">\r\n<g>\r\n	<g>\r\n		<path d=\"M475.131,155.978L348.794,42.275C344.737,18.312,323.846,0,298.746,0H170.479c-4.427,0-8.017,3.588-8.017,8.017\r\n			c0,4.428,3.589,8.017,8.017,8.017h128.267c19.155,0,34.739,15.583,34.739,34.739S317.9,85.511,298.746,85.511h-75.224\r\n			l-11.869-5.395c4.623-2.83,9.151-5.597,13.563-8.288c3.938,2.565,8.631,4.063,13.672,4.063c13.851,0,25.119-11.268,25.119-25.119\r\n			s-11.268-25.119-25.119-25.119c-13.851,0-25.119,11.268-25.119,25.119c0,2.938,0.512,5.757,1.443,8.38\r\n			c-5.615,3.428-12.851,7.852-21.169,12.959l-63.002-28.638c-1.99-0.905-4.265-0.956-6.295-0.145L63.2,67.947l34.609-51.914h39.198\r\n			c4.427,0,8.017-3.588,8.017-8.017c0-4.428-3.589-8.017-8.017-8.017H93.518c-2.681,0-5.184,1.339-6.67,3.57L35.542,80.53\r\n			c-1.958,2.937-1.731,6.923,0.547,9.619c2.203,2.608,5.929,3.535,9.101,2.271l82.333-32.934l50.055,22.753\r\n			c-49.892,30.76-120.328,74.827-129.549,84.047c-7.974,7.975-12.366,18.577-12.366,29.855s4.392,21.88,12.366,29.854\r\n			c7.974,7.975,18.577,12.367,29.855,12.367s21.88-4.392,29.855-12.366c9.109-9.109,60.502-74.238,103.079-128.648l0.99,0.45\r\n			c-17.62,51.101-28.468,104.093-32.223,157.64c-5.967,85.055,5.691,169.579,34.646,251.223c1.135,3.199,4.161,5.337,7.556,5.337\r\n			h119.716c3.481,0,6.639-2.334,7.661-5.661c1.055-3.432-0.367-7.25-3.412-9.154l-61.362-38.351\r\n			c-18.294-66.404-25.16-134.443-20.401-202.273c1.461-20.832,4.054-41.833,7.708-62.418c0.774-4.359-2.134-8.521-6.492-9.294\r\n			c-4.36-0.766-8.521,2.134-9.294,6.492c-3.751,21.138-6.413,42.704-7.914,64.098c-1.826,26.023-1.98,52.074-0.484,78.055h-17.173\r\n			c-4.427,0-8.017,3.588-8.017,8.017c0,4.428,3.589,8.017,8.017,8.017h18.306c0.269,3.208,0.565,6.414,0.885,9.62h-19.192\r\n			c-4.427,0-8.017,3.588-8.017,8.017c0,4.428,3.589,8.017,8.017,8.017h20.997c0.405,3.209,0.841,6.416,1.298,9.62h-22.295\r\n			c-4.427,0-8.017,3.588-8.017,8.017c0,4.428,3.589,8.017,8.017,8.017h24.781c0.542,3.209,1.119,6.415,1.712,9.62h-17.942\r\n			c-4.427,0-8.017,3.588-8.017,8.017c0,4.428,3.589,8.017,8.017,8.017h21.122c2.819,13.276,6.075,26.501,9.771,39.661\r\n			c0.54,1.922,1.776,3.572,3.47,4.63l40.297,25.186h-86.074c-26.847-77.899-37.578-158.412-31.897-239.406\r\n			c3.694-52.662,14.416-104.786,31.88-155.015h51.462c-6.5,19.257-12.083,38.914-16.635,58.586\r\n			c-0.998,4.313,1.689,8.619,6.003,9.617c4.312,0.999,8.619-1.689,9.618-6.003c4.839-20.912,10.889-41.805,17.978-62.199h0.487\r\n			l28.564,18.567v16.172c0,4.428,3.589,8.017,8.017,8.017c4.427,0,8.017-3.588,8.017-8.017v-5.751l9.62,6.253v16.6\r\n			c0,4.428,3.589,8.017,8.017,8.017s8.017-3.588,8.017-8.017v-6.178l9.62,6.253v17.028c0,4.428,3.589,8.017,8.017,8.017\r\n			s8.017-3.588,8.017-8.017v-6.606l9.637,6.265c-0.005,0.114-0.017,0.227-0.017,0.342v17.102c0,4.428,3.589,8.017,8.017,8.017\r\n			s8.017-3.588,8.017-8.017v-7.033l9.659,6.278c-0.023,0.249-0.039,0.5-0.039,0.756v17.102c0,4.428,3.589,8.017,8.017,8.017\r\n			s8.017-3.588,8.017-8.017v-7.461l21.819,14.182c5.243,3.409,12.385-0.494,12.385-6.721V161.94\r\n			C477.786,159.665,476.821,157.499,475.131,155.978z M238.888,41.687c5.01,0,9.086,4.076,9.086,9.086\r\n			c0,5.01-4.076,9.086-9.086,9.086c-0.187,0-0.37-0.017-0.555-0.028c0.102-1.583-0.259-3.212-1.146-4.671\r\n			c-1.601-2.635-4.479-4.013-7.357-3.833c-0.011-0.184-0.028-0.367-0.028-0.554C229.802,45.763,233.878,41.687,238.888,41.687z\r\n			 M96.401,214.659c-10.096,10.095-26.94,10.095-37.035-0.001c-10.096-10.095-10.094-26.939,0-37.034\r\n			c7.569-7.569,75.549-50.329,135.8-87.39l0.634,0.289C139.044,163.021,102.918,208.142,96.401,214.659z M461.752,189.921\r\n			l-142.584-92.68c14.184-6.258,24.984-18.818,28.824-34.117l113.76,102.383V189.921z\"/>\r\n	</g>\r\n</g>\r\n<g>\r\n	<g>\r\n		<path d=\"M299.815,42.756h-1.069c-4.427,0-8.017,3.588-8.017,8.017c0,4.428,3.589,8.017,8.017,8.017h1.069\r\n			c4.427,0,8.017-3.588,8.017-8.017C307.831,46.344,304.242,42.756,299.815,42.756z\"/>\r\n	</g>\r\n</g>\r\n</svg>", null, null, "Ice Climbing", null, "DifficultyScaleType/ice-climbing", new Guid("0a23a5e5-7e23-4f31-a4cd-e70c07df44de"), null },
                    { 5L, new DateTime(2026, 4, 2, 20, 1, 41, 518, DateTimeKind.Utc).AddTicks(2753), null, "Combination of rock, snow, and ice climbing using ice tools and crampons. Dry tooling consists mainly of climbing on dry rock with ice tools, simulating technical mixed terrain.", "<?xml version=\"1.0\" encoding=\"iso-8859-1\"?>\r\n<!-- Uploaded to: SVG Repo, www.svgrepo.com, Generator: SVG Repo Mixer Tools -->\r\n<svg fill=\"#000000\" height=\"800px\" width=\"800px\" version=\"1.1\" id=\"Layer_1\" xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" \r\n	 viewBox=\"0 0 512 512\" xml:space=\"preserve\">\r\n<g>\r\n	<g>\r\n		<path d=\"M475.131,155.978L348.794,42.275C344.737,18.312,323.846,0,298.746,0H170.479c-4.427,0-8.017,3.588-8.017,8.017\r\n			c0,4.428,3.589,8.017,8.017,8.017h128.267c19.155,0,34.739,15.583,34.739,34.739S317.9,85.511,298.746,85.511h-75.224\r\n			l-11.869-5.395c4.623-2.83,9.151-5.597,13.563-8.288c3.938,2.565,8.631,4.063,13.672,4.063c13.851,0,25.119-11.268,25.119-25.119\r\n			s-11.268-25.119-25.119-25.119c-13.851,0-25.119,11.268-25.119,25.119c0,2.938,0.512,5.757,1.443,8.38\r\n			c-5.615,3.428-12.851,7.852-21.169,12.959l-63.002-28.638c-1.99-0.905-4.265-0.956-6.295-0.145L63.2,67.947l34.609-51.914h39.198\r\n			c4.427,0,8.017-3.588,8.017-8.017c0-4.428-3.589-8.017-8.017-8.017H93.518c-2.681,0-5.184,1.339-6.67,3.57L35.542,80.53\r\n			c-1.958,2.937-1.731,6.923,0.547,9.619c2.203,2.608,5.929,3.535,9.101,2.271l82.333-32.934l50.055,22.753\r\n			c-49.892,30.76-120.328,74.827-129.549,84.047c-7.974,7.975-12.366,18.577-12.366,29.855s4.392,21.88,12.366,29.854\r\n			c7.974,7.975,18.577,12.367,29.855,12.367s21.88-4.392,29.855-12.366c9.109-9.109,60.502-74.238,103.079-128.648l0.99,0.45\r\n			c-17.62,51.101-28.468,104.093-32.223,157.64c-5.967,85.055,5.691,169.579,34.646,251.223c1.135,3.199,4.161,5.337,7.556,5.337\r\n			h119.716c3.481,0,6.639-2.334,7.661-5.661c1.055-3.432-0.367-7.25-3.412-9.154l-61.362-38.351\r\n			c-18.294-66.404-25.16-134.443-20.401-202.273c1.461-20.832,4.054-41.833,7.708-62.418c0.774-4.359-2.134-8.521-6.492-9.294\r\n			c-4.36-0.766-8.521,2.134-9.294,6.492c-3.751,21.138-6.413,42.704-7.914,64.098c-1.826,26.023-1.98,52.074-0.484,78.055h-17.173\r\n			c-4.427,0-8.017,3.588-8.017,8.017c0,4.428,3.589,8.017,8.017,8.017h18.306c0.269,3.208,0.565,6.414,0.885,9.62h-19.192\r\n			c-4.427,0-8.017,3.588-8.017,8.017c0,4.428,3.589,8.017,8.017,8.017h20.997c0.405,3.209,0.841,6.416,1.298,9.62h-22.295\r\n			c-4.427,0-8.017,3.588-8.017,8.017c0,4.428,3.589,8.017,8.017,8.017h24.781c0.542,3.209,1.119,6.415,1.712,9.62h-17.942\r\n			c-4.427,0-8.017,3.588-8.017,8.017c0,4.428,3.589,8.017,8.017,8.017h21.122c2.819,13.276,6.075,26.501,9.771,39.661\r\n			c0.54,1.922,1.776,3.572,3.47,4.63l40.297,25.186h-86.074c-26.847-77.899-37.578-158.412-31.897-239.406\r\n			c3.694-52.662,14.416-104.786,31.88-155.015h51.462c-6.5,19.257-12.083,38.914-16.635,58.586\r\n			c-0.998,4.313,1.689,8.619,6.003,9.617c4.312,0.999,8.619-1.689,9.618-6.003c4.839-20.912,10.889-41.805,17.978-62.199h0.487\r\n			l28.564,18.567v16.172c0,4.428,3.589,8.017,8.017,8.017c4.427,0,8.017-3.588,8.017-8.017v-5.751l9.62,6.253v16.6\r\n			c0,4.428,3.589,8.017,8.017,8.017s8.017-3.588,8.017-8.017v-6.178l9.62,6.253v17.028c0,4.428,3.589,8.017,8.017,8.017\r\n			s8.017-3.588,8.017-8.017v-6.606l9.637,6.265c-0.005,0.114-0.017,0.227-0.017,0.342v17.102c0,4.428,3.589,8.017,8.017,8.017\r\n			s8.017-3.588,8.017-8.017v-7.033l9.659,6.278c-0.023,0.249-0.039,0.5-0.039,0.756v17.102c0,4.428,3.589,8.017,8.017,8.017\r\n			s8.017-3.588,8.017-8.017v-7.461l21.819,14.182c5.243,3.409,12.385-0.494,12.385-6.721V161.94\r\n			C477.786,159.665,476.821,157.499,475.131,155.978z M238.888,41.687c5.01,0,9.086,4.076,9.086,9.086\r\n			c0,5.01-4.076,9.086-9.086,9.086c-0.187,0-0.37-0.017-0.555-0.028c0.102-1.583-0.259-3.212-1.146-4.671\r\n			c-1.601-2.635-4.479-4.013-7.357-3.833c-0.011-0.184-0.028-0.367-0.028-0.554C229.802,45.763,233.878,41.687,238.888,41.687z\r\n			 M96.401,214.659c-10.096,10.095-26.94,10.095-37.035-0.001c-10.096-10.095-10.094-26.939,0-37.034\r\n			c7.569-7.569,75.549-50.329,135.8-87.39l0.634,0.289C139.044,163.021,102.918,208.142,96.401,214.659z M461.752,189.921\r\n			l-142.584-92.68c14.184-6.258,24.984-18.818,28.824-34.117l113.76,102.383V189.921z\"/>\r\n	</g>\r\n</g>\r\n<g>\r\n	<g>\r\n		<path d=\"M299.815,42.756h-1.069c-4.427,0-8.017,3.588-8.017,8.017c0,4.428,3.589,8.017,8.017,8.017h1.069\r\n			c4.427,0,8.017-3.588,8.017-8.017C307.831,46.344,304.242,42.756,299.815,42.756z\"/>\r\n	</g>\r\n</g>\r\n</svg>", null, null, "Mixed Climbing and Dry Tooling", null, "DifficultyScaleType/mixed-climbing-and-dry-tooling", new Guid("9d90feac-b87a-492d-9215-98878bfd2c8b"), null },
                    { 6L, new DateTime(2026, 4, 2, 20, 1, 41, 518, DateTimeKind.Utc).AddTicks(2757), null, "Fixed routes equipped with metal rungs, ladders, bridges, and a steel cable to clip into using a dedicated via ferrata lanyard with energy absorber.", "<?xml version=\"1.0\" encoding=\"iso-8859-1\"?>\r\n<!-- Uploaded to: SVG Repo, www.svgrepo.com, Generator: SVG Repo Mixer Tools -->\r\n<!DOCTYPE svg PUBLIC \"-//W3C//DTD SVG 1.1//EN\" \"http://www.w3.org/Graphics/SVG/1.1/DTD/svg11.dtd\">\r\n<svg fill=\"#000000\" version=\"1.1\" id=\"Capa_1\" xmlns=\"http://www.w3.org/2000/svg\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" \r\n	 width=\"800px\" height=\"800px\" viewBox=\"0 0 450.265 450.266\"\r\n	 xml:space=\"preserve\">\r\n<g>\r\n	<g>\r\n		<path d=\"M25.311,449.953c10.882,1.722,21.209-3.814,26.173-12.947l43.232-92.584c0.927-2.123,1.74-4.38,2.018-6.866\r\n			c0.114-1.1,0.239-2.381,0.239-3.471l-0.297-70.323l66.393,28.994l10.758,68.716c2.132,10.041,10.347,18.083,21.075,19.747\r\n			c13.98,2.027,26.995-7.574,29.138-21.43c0.344-2.372,0.344-4.743,0.105-6.99l-13.102-82.974\r\n			c-1.577-7.976-6.885-14.908-14.353-18.38l-59.336-26.411l37.811-65.819l18.704,23.811c1.912,2.132,4.398,3.988,7.229,5.078\r\n			l71.413,20.913c9.543,2.027,19.268-2.926,22.931-12.058c4.169-10.423-0.804-22.138-11.017-26.364l-1.052-0.287l-62.051-18.302\r\n			l-34.502-41.435c-6.761-8.119-19.976-18.379-29.51-22.912l-15.635-7.449c-3.538-1.683-7.459-2.238-11.283-1.826\r\n			c-9.744-0.564-57.127-1.215-77.83,37.791c-23.131,43.566-8.262,95.864-8.262,95.864c-0.029,0.641-0.153,1.262-0.153,1.912\r\n			l1.855,113.765L6.712,412.363c-1.396,2.496-2.372,5.432-2.831,8.501C1.74,434.873,11.331,447.793,25.311,449.953z\"/>\r\n		<path d=\"M293.655,338.11l-21.382,12.23c-10.117,3.051-19.326,13.148-20.56,22.539c-1.243,9.391-10.566,19.039-20.837,21.544\r\n			l-85.747,20.875c-10.261,2.506-18.312,9.257-17.968,15.08c0.335,5.824,9.17,10.558,19.728,10.558h280.573\r\n			c10.644,0,19.221-8.568,19.221-19.202L446.33,36.844c-0.01-10.557-8.358-21.066-18.638-23.476l-3.825-0.89\r\n			c-10.279-2.4-20.482,4.007-22.768,14.315l-15.301,68.869c-2.285,10.308-12.039,21.994-21.773,26.096l-4.141,1.741\r\n			c-9.744,4.102-20.521,15.481-24.068,25.436l-22.138,61.937c-3.548,9.954-2.964,25.838,1.319,35.496l-1.405,39.971\r\n			c4.274,9.658,5.651,23.926,3.069,31.862C314.071,326.139,303.772,335.061,293.655,338.11z\"/>\r\n		<path d=\"M170.518,76.557c21.085,0,38.25-17.165,38.25-38.327c0-21.076-17.165-38.23-38.25-38.23\r\n			c-21.095,0-38.25,17.155-38.25,38.23C132.268,59.393,149.423,76.557,170.518,76.557z\"/>\r\n	</g>\r\n</g>\r\n</svg>", null, null, "Via Ferrata", null, "DifficultyScaleType/via-ferrata", new Guid("0696b264-4ac2-4bdd-a88d-b1fcc5417d85"), null },
                    { 7L, new DateTime(2026, 4, 2, 20, 1, 41, 518, DateTimeKind.Utc).AddTicks(2760), null, "High-mountain routes combining glacier approach, rock, snow, or ice sections in a committing environment, where length, altitude, exposure, and team autonomy are critical factors.", "<?xml version='1.0' encoding='iso-8859-1'?>\r\n<!-- Uploaded to: SVG Repo, www.svgrepo.com, Generator: SVG Repo Mixer Tools -->\r\n<svg fill=\"#000000\" height=\"800px\" width=\"800px\" version=\"1.1\" xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 301.193 301.193\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" enable-background=\"new 0 0 301.193 301.193\">\r\n  <g>\r\n    <g>\r\n      <path d=\"m86.597,177.25l41.639,21.484 11.467-27.841-14.003-7.225 1.144-3.805-5.026-.909c-10.946-1.981-17.841-10.969-18.927-17.043l-8.994-50.31 20.807,48.198c1.66,3.843 5.131,6.601 9.251,7.346l49.143,8.891c6.776,1.227 13.294-3.267 14.526-10.075 1.229-6.793-3.281-13.296-10.075-14.526l-42.548-7.698-18.842-43.647 25.032,32.074 6.614-21.99c2.965-9.857-2.623-20.251-12.48-23.216l-31.828-9.573c-3.823-1.15-7.721-1-11.24,0.173l.629-1.657c4.177-11.002-1.355-23.308-12.358-27.485l-6.753-2.564-15.393,42.635c-1.131,3.135-4.599,4.743-7.725,3.591l-22.133-8.186-3.392,8.935-4.956-1.882c-2.634-1-5.581,0.325-6.581,2.959l-6.354,16.738c-1,2.634 0.325,5.581 2.959,6.581l4.956,1.882-2.563,6.75c-4.177,11.002 1.355,23.308 12.358,27.485l13.758,5.223c7.916,3.006 16.507,0.984 22.26-4.485l-6.331,21.049c-1.981,3.3-2.7,7.357-1.684,11.384l13.915,55.205-6.354,62.594c-0.896,8.823 6.021,16.516 14.941,16.516 7.603,0 14.12-5.76 14.904-13.486l6.62-65.217c0.177-1.735 0.049-3.489-0.378-5.181l-10.005-39.692z\"/>\r\n      <path d=\"m168.021,217.676l-18.62,45.208c3.292,5.732 10.109,8.788 16.804,7.033 8.014-2.1 12.808-10.299 10.707-18.313l-8.891-33.928z\"/>\r\n      <circle cx=\"134.805\" cy=\"27.59\" r=\"27.59\"/>\r\n      <path d=\"m192.637,126.402l9.8-23.792c2.104-5.106-0.331-10.951-5.438-13.055-5.107-2.104-10.952,0.332-13.055,5.438l-9.739,23.645 5.481,.992c4.979,0.9 9.452,3.263 12.951,6.772z\"/>\r\n      <path d=\"m175.336,168.239c-2.878,0-2.952-0.136-20.218-3.26l-50.415,122.402c-2.104,5.107 0.331,10.951 5.438,13.055 5.107,2.105 10.952-0.332 13.055-5.438l52.211-126.762c-0.025-5.68434e-14-0.048,0.003-0.071,0.003z\"/>\r\n      <path d=\"m291.981,175.518c-1.374-0.44-2.874,0.058-3.712,1.232l-14.042,19.669c-3.942,5.521-8.625,10.473-13.918,14.716l-24.467,19.612c-6.342,5.084-11.979,10.99-16.762,17.562l-2.972,4.085c-4.796,6.591-11.015,12.017-18.196,15.875l-17.626,9.472-39.399,16.826c-1.449,0.619-2.263,2.172-1.947,3.716s1.674,2.652 3.25,2.652h132.499c10.823,0 19.597-8.774 19.597-19.597v-102.66c0-1.443-0.932-2.72-2.305-3.16z\"/>\r\n      <path d=\"m62.391,22.046c-9.714-1.478-19.477,3.948-23.106,13.506l-6.5,17.12 16.365,6.053 13.241-36.679z\"/>\r\n    </g>\r\n  </g>\r\n</svg>", null, null, "Alpine Ascent", null, "DifficultyScaleType/alpine-ascent", new Guid("83d166f0-da30-499d-ae07-3289b81a9868"), null },
                    { 8L, new DateTime(2026, 4, 2, 20, 1, 41, 518, DateTimeKind.Utc).AddTicks(2764), null, "The Exposure Rating evaluates how serious a fall would be.", "<?xml version='1.0' encoding='iso-8859-1'?>\r\n<!-- Uploaded to: SVG Repo, www.svgrepo.com, Generator: SVG Repo Mixer Tools -->\r\n<svg fill=\"#000000\" height=\"800px\" width=\"800px\" version=\"1.1\" xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 301.193 301.193\" xmlns:xlink=\"http://www.w3.org/1999/xlink\" enable-background=\"new 0 0 301.193 301.193\">\r\n  <g>\r\n    <g>\r\n      <path d=\"m86.597,177.25l41.639,21.484 11.467-27.841-14.003-7.225 1.144-3.805-5.026-.909c-10.946-1.981-17.841-10.969-18.927-17.043l-8.994-50.31 20.807,48.198c1.66,3.843 5.131,6.601 9.251,7.346l49.143,8.891c6.776,1.227 13.294-3.267 14.526-10.075 1.229-6.793-3.281-13.296-10.075-14.526l-42.548-7.698-18.842-43.647 25.032,32.074 6.614-21.99c2.965-9.857-2.623-20.251-12.48-23.216l-31.828-9.573c-3.823-1.15-7.721-1-11.24,0.173l.629-1.657c4.177-11.002-1.355-23.308-12.358-27.485l-6.753-2.564-15.393,42.635c-1.131,3.135-4.599,4.743-7.725,3.591l-22.133-8.186-3.392,8.935-4.956-1.882c-2.634-1-5.581,0.325-6.581,2.959l-6.354,16.738c-1,2.634 0.325,5.581 2.959,6.581l4.956,1.882-2.563,6.75c-4.177,11.002 1.355,23.308 12.358,27.485l13.758,5.223c7.916,3.006 16.507,0.984 22.26-4.485l-6.331,21.049c-1.981,3.3-2.7,7.357-1.684,11.384l13.915,55.205-6.354,62.594c-0.896,8.823 6.021,16.516 14.941,16.516 7.603,0 14.12-5.76 14.904-13.486l6.62-65.217c0.177-1.735 0.049-3.489-0.378-5.181l-10.005-39.692z\"/>\r\n      <path d=\"m168.021,217.676l-18.62,45.208c3.292,5.732 10.109,8.788 16.804,7.033 8.014-2.1 12.808-10.299 10.707-18.313l-8.891-33.928z\"/>\r\n      <circle cx=\"134.805\" cy=\"27.59\" r=\"27.59\"/>\r\n      <path d=\"m192.637,126.402l9.8-23.792c2.104-5.106-0.331-10.951-5.438-13.055-5.107-2.104-10.952,0.332-13.055,5.438l-9.739,23.645 5.481,.992c4.979,0.9 9.452,3.263 12.951,6.772z\"/>\r\n      <path d=\"m175.336,168.239c-2.878,0-2.952-0.136-20.218-3.26l-50.415,122.402c-2.104,5.107 0.331,10.951 5.438,13.055 5.107,2.105 10.952-0.332 13.055-5.438l52.211-126.762c-0.025-5.68434e-14-0.048,0.003-0.071,0.003z\"/>\r\n      <path d=\"m291.981,175.518c-1.374-0.44-2.874,0.058-3.712,1.232l-14.042,19.669c-3.942,5.521-8.625,10.473-13.918,14.716l-24.467,19.612c-6.342,5.084-11.979,10.99-16.762,17.562l-2.972,4.085c-4.796,6.591-11.015,12.017-18.196,15.875l-17.626,9.472-39.399,16.826c-1.449,0.619-2.263,2.172-1.947,3.716s1.674,2.652 3.25,2.652h132.499c10.823,0 19.597-8.774 19.597-19.597v-102.66c0-1.443-0.932-2.72-2.305-3.16z\"/>\r\n      <path d=\"m62.391,22.046c-9.714-1.478-19.477,3.948-23.106,13.506l-6.5,17.12 16.365,6.053 13.241-36.679z\"/>\r\n    </g>\r\n  </g>\r\n</svg>", null, null, "Exposure", null, "DifficultyScaleType/exposure", new Guid("fe0937c8-ef97-4aaf-a36e-bda5a5a7d95d"), null }
                });

            migrationBuilder.InsertData(
                table: "DifficultyScaleName",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Description", "DifficultyScaleTypeId", "LockedAt", "MetaData", "Name", "RestoredAt", "Slug", "Uid", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, new DateTime(2026, 4, 2, 20, 1, 41, 517, DateTimeKind.Utc).AddTicks(2986), null, "The Yosemite Decimal System (YDS) is a climbing grade scale used in North America to rate the difficulty of roped climbs, from Class 1 (walking) to Class 5 (technical rock climbing).\r\nWithin Class 5, it ranges from 5.0 to 5.15, describing technical difficulty, endurance, and exposure.", 1L, null, null, "YDS", null, "DifficultyScaleName/yds", new Guid("d8794ddd-a9c5-4167-a65c-002bf572af5a"), null },
                    { 2L, new DateTime(2026, 4, 2, 20, 1, 41, 517, DateTimeKind.Utc).AddTicks(3024), null, "The French Scale is an internationally used grading system for sport climbing that rates the technical difficulty and sustained effort of a route.", 1L, null, null, "French Scale", null, "DifficultyScaleName/french-scale", new Guid("d3f0afc7-4fb9-42c3-b7fb-e445d43852c8"), null },
                    { 3L, new DateTime(2026, 4, 2, 20, 1, 41, 517, DateTimeKind.Utc).AddTicks(3035), null, "The UIAA Scale is a traditional climbing grading system developed by the International Climbing and Mountaineering Federation to rate the technical difficulty of rock climbs.", 1L, null, null, "UIAA", null, "DifficultyScaleName/uiaa", new Guid("7efa282b-87e7-4ddf-9064-93a113fecc19"), null },
                    { 4L, new DateTime(2026, 4, 2, 20, 1, 41, 517, DateTimeKind.Utc).AddTicks(3039), null, "Traditional aid (A-Scale) climbing uses pitons, hooks, heads, and hammered gear to ascend, with difficulty rated from A0 to A5 based on protection quality and fall risk.\r\nIt focuses on gear strength, placement reliability, and the seriousness of potential falls.", 2L, null, null, "A-Scale", null, "DifficultyScaleName/a-scale", new Guid("69b3d486-083a-4a5f-ae22-ca1bd0f3bb53"), null },
                    { 5L, new DateTime(2026, 4, 2, 20, 1, 41, 517, DateTimeKind.Utc).AddTicks(3043), null, "Clean aid (C-Scale) climbing avoids hammered gear and relies only on passive or camming protection, graded C0 to C5 according to placement difficulty and danger.\r\nIt emphasizes using removable gear to protect the rock while maintaining the same commitment as traditional aid.", 2L, null, null, "C-Scale", null, "DifficultyScaleName/c-scale", new Guid("315e15ee-2b8b-45f0-a43a-e19c945edb0b"), null },
                    { 6L, new DateTime(2026, 4, 2, 20, 1, 41, 517, DateTimeKind.Utc).AddTicks(3046), null, "The Vermin Scale (V-Scale) is a bouldering grading system created by John “Vermin” Sherman to rate the physical and technical difficulty of boulder problems.", 3L, null, null, "V-Scale", null, "DifficultyScaleName/v-scale", new Guid("f9714181-b01f-4224-b35b-6605b75a268d"), null },
                    { 7L, new DateTime(2026, 4, 2, 20, 1, 41, 517, DateTimeKind.Utc).AddTicks(3049), null, "The Fontainebleau Scale (Font Scale) is a bouldering grading system originating in the Fontainebleau forest in France, rating both the technical difficulty and complexity of movements.", 3L, null, null, "Font Scale", null, "DifficultyScaleName/font-scale", new Guid("d8fcd736-9b00-4620-83d5-6865719e2838"), null },
                    { 8L, new DateTime(2026, 4, 2, 20, 1, 41, 517, DateTimeKind.Utc).AddTicks(3054), null, "The Water Ice (WI) scale grades the difficulty of frozen waterfall climbing, from WI1 to WI7+, based on steepness, continuity, and ice quality.\r\nIt focuses on sustained angle, protection quality, and technical tool/footwork demands.", 4L, null, null, "WI", null, "DifficultyScaleName/wi", new Guid("137827c9-7a2a-43c8-b878-d695e6950ebd"), null },
                    { 9L, new DateTime(2026, 4, 2, 20, 1, 41, 517, DateTimeKind.Utc).AddTicks(3057), null, "The Alpine Ice (AI) scale rates ice climbing found on high-mountain faces and couloirs, from AI1 to AI6, emphasizing altitude, exposure, and commitment.\r\nIt reflects overall seriousness more than pure steepness, including weather and terrain hazards.", 4L, null, null, "AI", null, "DifficultyScaleName/ai", new Guid("050a4239-70ab-466c-b168-b30a266eb1e3"), null },
                    { 10L, new DateTime(2026, 4, 2, 20, 1, 41, 517, DateTimeKind.Utc).AddTicks(3063), null, "The French Ice scale grades technical difficulty in ice climbing using mixed-style notation like 3, 4, 5, 6, 7 with +/− refinements.\r\nIt evaluates technical moves, steepness, and sustained sections similar to rock grade style but adapted to ice.", 4L, null, null, "French Ice", null, "DifficultyScaleName/french-ice", new Guid("77ca35c0-8700-4011-a26c-8321ad4d484e"), null },
                    { 11L, new DateTime(2026, 4, 2, 20, 1, 41, 517, DateTimeKind.Utc).AddTicks(3066), null, "The M Scale grades modern mixed climbing from M1 to M13+, evaluating difficulty on terrain that combines rock and ice using ice tools and crampons.\r\nIt focuses on steepness, technical tool placements, and athletic moves on rock features.", 5L, null, null, "M-Scale", null, "DifficultyScaleName/m-scale", new Guid("96d8a8ee-3749-4a22-9b61-715f4d76aeb3"), null },
                    { 12L, new DateTime(2026, 4, 2, 20, 1, 41, 517, DateTimeKind.Utc).AddTicks(3069), null, "The D Scale rates pure drytooling climbs from D4 to D14+, where climbers use tools on rock without ice.\r\nIt emphasizes overhangs, precision hooking, and sustained strength-based movement.", 5L, null, null, "D-Scale", null, "DifficultyScaleName/d-scale", new Guid("a342962e-40fa-41ab-8ff6-b57e969b51aa"), null },
                    { 13L, new DateTime(2026, 4, 2, 20, 1, 41, 517, DateTimeKind.Utc).AddTicks(3072), null, "The French via ferrata scale rates routes from F (easy) to ED (extremely difficult), based on physical effort, exposure, and technical movement.\r\nIt emphasizes overall seriousness, including sustained sections, overhangs, and psychological commitment.", 6L, null, null, "French Via Ferrata Scale", null, "DifficultyScaleName/french-via-ferrata-scale", new Guid("9e97feeb-c86d-4cfb-a77f-3af94fc1a16c"), null },
                    { 14L, new DateTime(2026, 4, 2, 20, 1, 41, 517, DateTimeKind.Utc).AddTicks(3077), null, "The German K-Scale grades via ferratas from K1 to K6, focusing on steepness, required strength, and the difficulty of metal rungs, ladders, and cable sections.\r\nHigher grades indicate more overhangs, athletic moves, and increased exposure.", 6L, null, null, "K-Scale", null, "DifficultyScaleName/k-scale", new Guid("5e58e5aa-e77e-406f-844d-fb2ba82097ef"), null },
                    { 15L, new DateTime(2026, 4, 2, 20, 1, 41, 517, DateTimeKind.Utc).AddTicks(3080), null, "The Swiss Scale classifies individual sections of a via ferrata from A (easy) to E (extreme), evaluating technical moves and spacing of artificial holds.\r\nIt highlights precise difficulty in short segments, especially where protection or holds are minimal.", 6L, null, null, "Swiss Scale", null, "DifficultyScaleName/swiss-scale", new Guid("e1c52a23-005f-4706-b6aa-cce44ae050e4"), null },
                    { 16L, new DateTime(2026, 4, 2, 20, 1, 41, 517, DateTimeKind.Utc).AddTicks(3084), null, "The French Alpine Grade rates the overall difficulty of alpine routes from F to ABO, combining technical challenges with exposure, altitude, commitment, and terrain complexity.\r\nIt provides a global assessment of long, multi-discipline ascents, integrating rock, snow, ice, and mixed sections into a single grade.", 7L, null, null, "French Alpine Grade", null, "DifficultyScaleName/french-alpine-grade", new Guid("b0450fe5-1df7-4d9f-9408-ad72c35f7836"), null },
                    { 17L, new DateTime(2026, 4, 2, 20, 1, 41, 517, DateTimeKind.Utc).AddTicks(3088), null, "The Exposure Rating evaluates how serious a fall would be, from PG (low risk) to R (serious) and X (potentially fatal), based on terrain, fall consequences, and protection availability.\r\nIt reflects the overall danger level of a route section where a mistake may result in long or unprotectable falls.", 8L, null, null, "Exposure Rating", null, "DifficultyScaleName/exposure-rating", new Guid("140debeb-be20-4066-afb1-9b95e8ac4beb"), null }
                });

            migrationBuilder.InsertData(
                table: "DifficultyScale",
                columns: new[] { "Id", "CreatedAt", "DeletedAt", "Description", "DifficultyGroupId", "DifficultyScaleNameId", "IRCRA", "LockedAt", "MetaData", "RestoredAt", "Slug", "Uid", "UpdatedAt", "Value" },
                values: new object[,]
                {
                    { 1L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4320), null, null, 1L, 1L, 1, null, null, null, "DifficultyScale/5.0-1-1", new Guid("c1d48fd9-1727-41c1-ab6f-194cfd7f24a1"), null, "5.0" },
                    { 2L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4340), null, null, 1L, 1L, 2, null, null, null, "DifficultyScale/5.1-2-1", new Guid("4a7cf757-710d-47ea-8fca-e63d8aa9d0a3"), null, "5.1" },
                    { 3L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4344), null, null, 1L, 1L, 3, null, null, null, "DifficultyScale/5.2-3-1", new Guid("48abee41-5e9c-4198-aa69-83c8b573e898"), null, "5.2" },
                    { 4L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4352), null, null, 1L, 1L, 4, null, null, null, "DifficultyScale/5.3-4-1", new Guid("7e139548-a837-4acd-8a91-fa8d497af702"), null, "5.3" },
                    { 5L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4355), null, null, 1L, 1L, 5, null, null, null, "DifficultyScale/5.4-5-1", new Guid("22fbcf90-2c83-4eb9-9d30-7c18501c49e4"), null, "5.4" },
                    { 6L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4357), null, null, 1L, 1L, 6, null, null, null, "DifficultyScale/5.5-6-1", new Guid("8ed655bb-5841-44ec-b31a-6fd5dda06646"), null, "5.5" },
                    { 7L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4360), null, null, 1L, 1L, 7, null, null, null, "DifficultyScale/5.6-7-1", new Guid("b4ce1bd2-42e8-4fa7-9d04-606117b6ae60"), null, "5.6" },
                    { 8L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4362), null, null, 1L, 1L, 8, null, null, null, "DifficultyScale/5.7-8-1", new Guid("086df1c0-d1c8-43ea-9dc8-e8673d2f7197"), null, "5.7" },
                    { 9L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4365), null, null, 1L, 1L, 9, null, null, null, "DifficultyScale/5.8-9-1", new Guid("1a3dd456-fc7d-4451-a13e-a099de3651b2"), null, "5.8" },
                    { 10L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4368), null, null, 1L, 1L, 10, null, null, null, "DifficultyScale/5.9-10-1", new Guid("a0e47085-4e22-4e6e-b2cb-39517c6809b6"), null, "5.9" },
                    { 11L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4379), null, null, 1L, 1L, 11, null, null, null, "DifficultyScale/5.10a-11-1", new Guid("02cf3931-bf42-46db-9256-8881ea8ed006"), null, "5.10a" },
                    { 12L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4384), null, null, 2L, 1L, 12, null, null, null, "DifficultyScale/5.10b-12-1", new Guid("9f52baea-a1fe-453d-9d01-125b6f25fcd3"), null, "5.10b" },
                    { 13L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4387), null, null, 2L, 1L, 13, null, null, null, "DifficultyScale/5.10c-13-1", new Guid("c2545e1d-5628-4f7c-aa46-e15ffede2095"), null, "5.10c" },
                    { 14L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4390), null, null, 2L, 1L, 14, null, null, null, "DifficultyScale/5.10d-14-1", new Guid("c463623e-1252-45d8-8b37-228054b7bb70"), null, "5.10d" },
                    { 15L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4394), null, null, 2L, 1L, 15, null, null, null, "DifficultyScale/5.11a-15-1", new Guid("b77b7421-aacc-410d-a4aa-ecab2ad015d1"), null, "5.11a" },
                    { 16L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4397), null, null, 2L, 1L, 16, null, null, null, "DifficultyScale/5.11b-16-1", new Guid("028f44cf-9335-48ac-930f-800d1d068ffb"), null, "5.11b" },
                    { 17L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4400), null, null, 2L, 1L, 17, null, null, null, "DifficultyScale/5.11c-17-1", new Guid("103e9824-131d-486f-8363-4ac47ed8716b"), null, "5.11c" },
                    { 18L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4403), null, null, 2L, 1L, 18, null, null, null, "DifficultyScale/5.11d-18-1", new Guid("aa488f04-7580-4e82-bb2d-efce70e70735"), null, "5.11d" },
                    { 19L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4408), null, null, 3L, 1L, 19, null, null, null, "DifficultyScale/5.12a-19-1", new Guid("77cbefe2-58b4-48bd-a3d2-6e43969d6d01"), null, "5.12a" },
                    { 20L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4414), null, null, 3L, 1L, 20, null, null, null, "DifficultyScale/5.12b-20-1", new Guid("0d2cffed-f22d-4e8a-a7dc-0a9373414deb"), null, "5.12b" },
                    { 21L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4417), null, null, 3L, 1L, 21, null, null, null, "DifficultyScale/5.12c-21-1", new Guid("5cb70c8b-2316-4b84-bc45-04090ffc98d2"), null, "5.12c" },
                    { 22L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4419), null, null, 3L, 1L, 22, null, null, null, "DifficultyScale/5.12d-22-1", new Guid("cb2eaeb6-f138-4e7a-8ff5-0da699aba1fc"), null, "5.12d" },
                    { 23L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4422), null, null, 4L, 1L, 23, null, null, null, "DifficultyScale/5.13a-23-1", new Guid("891dbaf3-a6cc-44b4-afe3-544f3ea70d8e"), null, "5.13a" },
                    { 24L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4425), null, null, 4L, 1L, 24, null, null, null, "DifficultyScale/5.13b-24-1", new Guid("612631d4-22de-4f58-9802-f7220119bdf1"), null, "5.13b" },
                    { 25L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4428), null, null, 4L, 1L, 25, null, null, null, "DifficultyScale/5.13c-25-1", new Guid("e4c577d6-fb02-4d22-bad3-f4c32ce70934"), null, "5.13c" },
                    { 26L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4432), null, null, 4L, 1L, 26, null, null, null, "DifficultyScale/5.13d-26-1", new Guid("36fef2db-9a2d-4bb6-bafb-814444e3d455"), null, "5.13d" },
                    { 27L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4434), null, null, 4L, 1L, 27, null, null, null, "DifficultyScale/5.14a-27-1", new Guid("e54c97be-2f71-4b3a-a2f7-274e65ac0234"), null, "5.14a" },
                    { 28L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4439), null, null, 5L, 1L, 28, null, null, null, "DifficultyScale/5.14b-28-1", new Guid("a9d1df68-df08-4115-b299-980b6c34a98a"), null, "5.14b" },
                    { 29L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4441), null, null, 5L, 1L, 29, null, null, null, "DifficultyScale/5.14c-29-1", new Guid("f5d2d1e0-4d63-4373-a997-19cae868aeb3"), null, "5.14c" },
                    { 30L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4444), null, null, 5L, 1L, 30, null, null, null, "DifficultyScale/5.14d-30-1", new Guid("7bfe0ed1-402e-4d82-b03c-15176ecfb8e1"), null, "5.14d" },
                    { 31L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4447), null, null, 5L, 1L, 31, null, null, null, "DifficultyScale/5.15a-31-1", new Guid("7865d1d3-9633-47a0-83cb-f2f0876c91ef"), null, "5.15a" },
                    { 32L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4449), null, null, 5L, 1L, 32, null, null, null, "DifficultyScale/5.15b-d-32-1", new Guid("1bb1bac4-f947-40c2-b334-d173c97f69cc"), null, "5.15b-d" },
                    { 33L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4460), null, null, 1L, 2L, 1, null, null, null, "DifficultyScale/3-1-2", new Guid("73bb8650-778d-4626-83c4-2e0044ec1746"), null, "3" },
                    { 34L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4464), null, null, 1L, 2L, 2, null, null, null, "DifficultyScale/3+-2-2", new Guid("9a33d7c6-4eaa-4253-bd5c-036a89804f2a"), null, "3+" },
                    { 35L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4467), null, null, 1L, 2L, 3, null, null, null, "DifficultyScale/4a-3-2", new Guid("d41cacd7-fa89-4555-8a5f-532ef27d7bb8"), null, "4a" },
                    { 36L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4472), null, null, 1L, 2L, 4, null, null, null, "DifficultyScale/4b-4-2", new Guid("05bc2e84-5e56-457b-922a-4c134e32569d"), null, "4b" },
                    { 37L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4476), null, null, 1L, 2L, 5, null, null, null, "DifficultyScale/4c-5-2", new Guid("60738bc2-f603-4eb9-8b55-199fd513ee02"), null, "4c" },
                    { 38L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4478), null, null, 1L, 2L, 6, null, null, null, "DifficultyScale/5a-6-2", new Guid("a4512b00-29ce-4731-8da0-486085c8aca4"), null, "5a" },
                    { 39L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4481), null, null, 1L, 2L, 7, null, null, null, "DifficultyScale/5b-7-2", new Guid("ab44511d-8d04-44e0-88f2-e1ea96879c34"), null, "5b" },
                    { 40L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4487), null, null, 1L, 2L, 8, null, null, null, "DifficultyScale/5c-8-2", new Guid("3b402f16-da89-4dde-9fbf-1083760fd1ef"), null, "5c" },
                    { 41L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4491), null, null, 1L, 2L, 9, null, null, null, "DifficultyScale/6a-9-2", new Guid("22eedcd2-0933-4865-b46f-12c16840dc92"), null, "6a" },
                    { 42L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4495), null, null, 2L, 2L, 10, null, null, null, "DifficultyScale/6a+-10-2", new Guid("549adb80-7507-4f59-bfeb-d4d9684ec968"), null, "6a+" },
                    { 43L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4498), null, null, 2L, 2L, 11, null, null, null, "DifficultyScale/6b-11-2", new Guid("2f065fe8-186f-4c78-a40f-8254e68fbc40"), null, "6b" },
                    { 44L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4503), null, null, 2L, 2L, 12, null, null, null, "DifficultyScale/6b+-12-2", new Guid("b0b73354-997a-472b-8d4d-ff877a6e3ad6"), null, "6b+" },
                    { 45L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4507), null, null, 2L, 2L, 13, null, null, null, "DifficultyScale/6c-13-2", new Guid("b9b5d766-79e9-4839-8c41-4716a90caedf"), null, "6c" },
                    { 46L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4510), null, null, 2L, 2L, 14, null, null, null, "DifficultyScale/6c+-14-2", new Guid("367fb547-8c0d-4f81-a952-d65663b55e76"), null, "6c+" },
                    { 47L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4514), null, null, 2L, 2L, 15, null, null, null, "DifficultyScale/7a-15-2", new Guid("c1a6c27c-2271-494f-bda0-2a4d538328b6"), null, "7a" },
                    { 48L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4518), null, null, 2L, 2L, 16, null, null, null, "DifficultyScale/7a+-16-2", new Guid("90653f0c-a5d2-4a86-98a7-25c66de7c9f1"), null, "7a+" },
                    { 49L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4521), null, null, 2L, 2L, 17, null, null, null, "DifficultyScale/7b-17-2", new Guid("7b30fe38-8fbb-4d30-83a3-de5a5c702b7e"), null, "7b" },
                    { 50L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4524), null, null, 2L, 2L, 18, null, null, null, "DifficultyScale/7b+-18-2", new Guid("a9a968a1-0652-4860-8d03-64cc74a2bff9"), null, "7b+" },
                    { 51L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4527), null, null, 3L, 2L, 19, null, null, null, "DifficultyScale/7c-19-2", new Guid("d2df9631-9ab5-44a2-abe0-c73b9efba287"), null, "7c" },
                    { 52L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4533), null, null, 3L, 2L, 20, null, null, null, "DifficultyScale/7c+-20-2", new Guid("9851d731-08eb-4084-bd92-1d39d5d004f1"), null, "7c+" },
                    { 53L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4536), null, null, 3L, 2L, 21, null, null, null, "DifficultyScale/8a-21-2", new Guid("82b8c98b-6430-47eb-a1dd-8aa7d738c916"), null, "8a" },
                    { 54L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4539), null, null, 3L, 2L, 22, null, null, null, "DifficultyScale/8a+-22-2", new Guid("983561cd-abc0-4cc7-a989-d40b3672b15c"), null, "8a+" },
                    { 55L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4542), null, null, 4L, 2L, 23, null, null, null, "DifficultyScale/8b-23-2", new Guid("9ea5b746-01c4-428f-b318-5ac01839930d"), null, "8b" },
                    { 56L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4550), null, null, 4L, 2L, 24, null, null, null, "DifficultyScale/8b+-24-2", new Guid("02dfd043-866b-4a12-8ab6-bc2e5fe21cfe"), null, "8b+" },
                    { 57L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4555), null, null, 4L, 2L, 25, null, null, null, "DifficultyScale/8c-25-2", new Guid("aea6e7fa-1e0b-45b0-9da9-3ba7e3892d3c"), null, "8c" },
                    { 58L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4558), null, null, 4L, 2L, 26, null, null, null, "DifficultyScale/8c+-26-2", new Guid("7b64509d-48df-49b0-8826-397520448222"), null, "8c+" },
                    { 59L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4561), null, null, 4L, 2L, 27, null, null, null, "DifficultyScale/9a-27-2", new Guid("79718948-4e69-4f03-86ed-1696ac84ace5"), null, "9a" },
                    { 60L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4567), null, null, 5L, 2L, 28, null, null, null, "DifficultyScale/9a+-28-2", new Guid("02989fa5-0ad3-471f-b8bb-a94fa0f788cb"), null, "9a+" },
                    { 61L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4572), null, null, 5L, 2L, 29, null, null, null, "DifficultyScale/9b-29-2", new Guid("16f01a54-c756-4368-be08-719560cb08fe"), null, "9b" },
                    { 62L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4574), null, null, 5L, 2L, 30, null, null, null, "DifficultyScale/9b+-30-2", new Guid("f3734ca3-eb3f-4454-9f0f-0f685d076892"), null, "9b+" },
                    { 63L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4576), null, null, 5L, 2L, 31, null, null, null, "DifficultyScale/9c-31-2", new Guid("9d18a5ee-d46a-439c-b463-3f937f3216d5"), null, "9c" },
                    { 64L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4579), null, null, 5L, 2L, 32, null, null, null, "DifficultyScale/9c+-32-2", new Guid("2f90852b-e637-4490-a315-a0265e64fe09"), null, "9c+" },
                    { 65L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4582), null, null, 1L, 3L, 1, null, null, null, "DifficultyScale/i-1-3", new Guid("aeae50b2-7ae5-4862-8ebe-83f617043866"), null, "I" },
                    { 66L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4591), null, null, 1L, 3L, 2, null, null, null, "DifficultyScale/i-ii-2-3", new Guid("88993ff9-dd6a-48cb-b78c-ee3b18e8faaf"), null, "I-II" },
                    { 67L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4596), null, null, 1L, 3L, 3, null, null, null, "DifficultyScale/ii-3-3", new Guid("157df1e8-d5b9-4a40-9fa8-8219ce4e80fe"), null, "II" },
                    { 68L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4602), null, null, 1L, 3L, 4, null, null, null, "DifficultyScale/ii-iii-4-3", new Guid("8d15561a-501a-44c1-909a-f3b3346f4b35"), null, "II-III" },
                    { 69L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4606), null, null, 1L, 3L, 5, null, null, null, "DifficultyScale/iii-5-3", new Guid("2672e194-186b-4310-8ee8-7ffed2c6fbdd"), null, "III" },
                    { 70L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4610), null, null, 1L, 3L, 6, null, null, null, "DifficultyScale/iii+-6-3", new Guid("fc9ba6f3-d675-434e-afa4-96d561ed59ae"), null, "III+" },
                    { 71L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4614), null, null, 1L, 3L, 7, null, null, null, "DifficultyScale/iv-7-3", new Guid("82c5169c-5be6-46a3-9077-ecf4d52362b4"), null, "IV" },
                    { 72L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4618), null, null, 1L, 3L, 8, null, null, null, "DifficultyScale/iv+-8-3", new Guid("ae26fc72-d670-41d6-aa05-4d3ff8e70781"), null, "IV+" },
                    { 73L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4625), null, null, 1L, 3L, 9, null, null, null, "DifficultyScale/v--9-3", new Guid("ff189d62-3864-492d-a532-7360b69372f1"), null, "V-" },
                    { 74L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4628), null, null, 2L, 3L, 10, null, null, null, "DifficultyScale/v-10-3", new Guid("c41e3f02-ad19-4951-a87b-24e11545fc69"), null, "V" },
                    { 75L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4632), null, null, 2L, 3L, 11, null, null, null, "DifficultyScale/v+-11-3", new Guid("4cdbb31e-5ccf-4c1c-b6b6-94a033d97743"), null, "V+" },
                    { 76L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4637), null, null, 2L, 3L, 12, null, null, null, "DifficultyScale/vi--12-3", new Guid("58a4d786-d250-4fc3-8249-aae4fef9cde6"), null, "VI-" },
                    { 77L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4647), null, null, 2L, 3L, 13, null, null, null, "DifficultyScale/vi-13-3", new Guid("54460227-d406-45ff-be98-80acd6079a0d"), null, "VI" },
                    { 78L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4653), null, null, 2L, 3L, 14, null, null, null, "DifficultyScale/vi+-14-3", new Guid("4454aa16-8a69-45d0-8d7d-c695f4ff047e"), null, "VI+" },
                    { 79L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4656), null, null, 2L, 3L, 15, null, null, null, "DifficultyScale/vii--15-3", new Guid("538dddb0-5220-4d8f-8a78-8f4261b58850"), null, "VII-" },
                    { 80L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4660), null, null, 2L, 3L, 16, null, null, null, "DifficultyScale/vii-16-3", new Guid("86d55da4-7ff6-498d-a36c-480c78938c19"), null, "VII" },
                    { 81L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4664), null, null, 2L, 3L, 17, null, null, null, "DifficultyScale/vii+-17-3", new Guid("69f2b018-5fee-47ed-abe6-662883a07d98"), null, "VII+" },
                    { 82L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4668), null, null, 2L, 3L, 18, null, null, null, "DifficultyScale/viii--18-3", new Guid("9f30a29e-12cc-458c-a5e4-7ccbe79faf1a"), null, "VIII-" },
                    { 83L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4671), null, null, 3L, 3L, 19, null, null, null, "DifficultyScale/viii-19-3", new Guid("c6d97e8b-77cf-491d-93f3-704c1b092a1d"), null, "VIII" },
                    { 84L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4677), null, null, 3L, 3L, 20, null, null, null, "DifficultyScale/viii+-20-3", new Guid("057a4edf-6514-4cce-bebd-f0132bf2770d"), null, "VIII+" },
                    { 85L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4681), null, null, 3L, 3L, 21, null, null, null, "DifficultyScale/ix--21-3", new Guid("ecaa0374-9a77-461a-a401-0229a00e8e7b"), null, "IX-" },
                    { 86L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4684), null, null, 3L, 3L, 22, null, null, null, "DifficultyScale/ix-22-3", new Guid("9888976f-61d5-4224-b721-ad383df94dc1"), null, "IX" },
                    { 87L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4688), null, null, 4L, 3L, 23, null, null, null, "DifficultyScale/ix+-23-3", new Guid("0a9bcf69-eb0c-4641-8fdd-00046e6e35dd"), null, "IX+" },
                    { 88L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4692), null, null, 4L, 3L, 24, null, null, null, "DifficultyScale/x--24-3", new Guid("2ab75766-1333-4086-a322-b795d28c477e"), null, "X-" },
                    { 89L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4696), null, null, 4L, 3L, 25, null, null, null, "DifficultyScale/x-25-3", new Guid("47334833-7342-4492-b9e7-fb26df7217ce"), null, "X" },
                    { 90L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4699), null, null, 4L, 3L, 26, null, null, null, "DifficultyScale/x+-26-3", new Guid("6d7a920e-e002-4288-ada2-34a14128c269"), null, "X+" },
                    { 91L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4702), null, null, 4L, 3L, 27, null, null, null, "DifficultyScale/xi--27-3", new Guid("da020064-cb9d-49ca-b244-d301d60b7886"), null, "XI-" },
                    { 92L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4708), null, null, 5L, 3L, 28, null, null, null, "DifficultyScale/xi-28-3", new Guid("c172f873-3cf6-421a-bea6-0ae6f04cad1b"), null, "XI" },
                    { 93L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4712), null, null, 5L, 3L, 29, null, null, null, "DifficultyScale/xi+-29-3", new Guid("ab652e1e-1c71-4d7e-a232-4b87d75316bc"), null, "XI+" },
                    { 94L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4715), null, null, 5L, 3L, 30, null, null, null, "DifficultyScale/xii--30-3", new Guid("c78af906-4724-459d-809e-ca751ba88b19"), null, "XII-" },
                    { 95L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4718), null, null, 5L, 3L, 31, null, null, null, "DifficultyScale/xii-31-3", new Guid("d94ace4c-9670-4c8f-b871-11c2de18bc76"), null, "XII" },
                    { 96L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4721), null, null, 5L, 3L, 32, null, null, null, "DifficultyScale/xii+-32-3", new Guid("88b8d744-cb31-4741-afe8-8bdca521e24a"), null, "XII+" },
                    { 97L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4725), null, null, 1L, 6L, 6, null, null, null, "DifficultyScale/vb-6-6", new Guid("de3657a8-0265-4de4-a1c0-7d0affb1f03c"), null, "VB" },
                    { 98L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4737), null, null, 1L, 6L, 7, null, null, null, "DifficultyScale/v0--7-6", new Guid("9d3b0484-bc05-4924-9ce3-58d0fe3eac0f"), null, "V0-" },
                    { 99L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4740), null, null, 1L, 6L, 8, null, null, null, "DifficultyScale/v0-8-6", new Guid("c32a34dc-bf0e-457e-94cf-c262cbd56ff2"), null, "V0" },
                    { 100L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4745), null, null, 1L, 6L, 9, null, null, null, "DifficultyScale/v0+-9-6", new Guid("46746321-b87b-4b29-8a8d-6ccce5139101"), null, "V0+" },
                    { 101L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4748), null, null, 1L, 6L, 10, null, null, null, "DifficultyScale/v1-10-6", new Guid("53752aa7-6872-4232-b407-1f73063ed89b"), null, "V1" },
                    { 102L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4751), null, null, 1L, 6L, 11, null, null, null, "DifficultyScale/v2-11-6", new Guid("1c9689b9-9461-4e10-9549-9b8e670597d8"), null, "V2" },
                    { 103L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4755), null, null, 1L, 6L, 12, null, null, null, "DifficultyScale/v3-12-6", new Guid("dd2b3704-7773-4d53-9ad7-0469c68026b3"), null, "V3" },
                    { 104L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4759), null, null, 2L, 6L, 13, null, null, null, "DifficultyScale/v4-13-6", new Guid("d2804379-2d47-455d-b6cb-0ba6cbc8636b"), null, "V4" },
                    { 105L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4764), null, null, 2L, 6L, 14, null, null, null, "DifficultyScale/v5-14-6", new Guid("835ff387-2f8e-4e4f-bebf-365c781b8391"), null, "V5" },
                    { 106L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4768), null, null, 2L, 6L, 15, null, null, null, "DifficultyScale/v6-15-6", new Guid("e6e7fe27-d6ec-4ce2-8153-77343524ee90"), null, "V6" },
                    { 107L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4771), null, null, 2L, 6L, 16, null, null, null, "DifficultyScale/v7-16-6", new Guid("c2554d82-6efe-4fb5-b53a-3a5e0eb9829b"), null, "V7" },
                    { 108L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4777), null, null, 2L, 6L, 17, null, null, null, "DifficultyScale/v8-17-6", new Guid("004e7343-162c-4443-a95e-243aa4f1bd5d"), null, "V8" },
                    { 109L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4781), null, null, 2L, 6L, 18, null, null, null, "DifficultyScale/v9-18-6", new Guid("7a511ba5-3a77-4cf2-9fda-ce42d4924ade"), null, "V9" },
                    { 110L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4784), null, null, 3L, 6L, 19, null, null, null, "DifficultyScale/v10-19-6", new Guid("431de418-3c0d-4cd6-bad7-6d35ff923c1d"), null, "V10" },
                    { 111L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4789), null, null, 3L, 6L, 20, null, null, null, "DifficultyScale/v11-20-6", new Guid("6a478840-dbfb-42f8-a5d8-c0ae43829316"), null, "V11" },
                    { 112L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4792), null, null, 3L, 6L, 21, null, null, null, "DifficultyScale/v12-21-6", new Guid("c367528c-8c43-4cad-b204-ccfb85fbd698"), null, "V12" },
                    { 113L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4795), null, null, 3L, 6L, 22, null, null, null, "DifficultyScale/v13-22-6", new Guid("7eb0147b-e0c1-4530-9e32-84cc2902f223"), null, "V13" },
                    { 114L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4798), null, null, 4L, 6L, 23, null, null, null, "DifficultyScale/v14-23-6", new Guid("87863753-f0c8-4eb6-8cd7-d89c95b30a2b"), null, "V14" },
                    { 115L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4801), null, null, 4L, 6L, 24, null, null, null, "DifficultyScale/v15-24-6", new Guid("2c788d57-1c3b-4771-8e98-5a1915c84426"), null, "V15" },
                    { 116L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4806), null, null, 4L, 6L, 25, null, null, null, "DifficultyScale/v16-25-6", new Guid("cb9810cd-ad80-4b35-b1f7-bd8fbe571507"), null, "V16" },
                    { 117L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4809), null, null, 5L, 6L, 26, null, null, null, "DifficultyScale/v17-26-6", new Guid("8b1da065-6c0d-4266-87ea-025f1a2b63d5"), null, "V17" },
                    { 118L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4818), null, null, 1L, 7L, 6, null, null, null, "DifficultyScale/3-6-7", new Guid("d7a1bda8-4c6a-40ed-9b85-480dd71e2f11"), null, "3" },
                    { 119L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4820), null, null, 1L, 7L, 7, null, null, null, "DifficultyScale/3+-7-7", new Guid("958afa5e-daa0-4a94-ae6a-f8ee3f5d9509"), null, "3+" },
                    { 120L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4823), null, null, 1L, 7L, 8, null, null, null, "DifficultyScale/4-8-7", new Guid("cc8e07ad-e81d-4756-98d2-c545f7311a05"), null, "4" },
                    { 121L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4826), null, null, 1L, 7L, 9, null, null, null, "DifficultyScale/4+-9-7", new Guid("c8de65bb-343f-4d14-9962-b63d74158d47"), null, "4+" },
                    { 122L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4829), null, null, 1L, 7L, 10, null, null, null, "DifficultyScale/5-10-7", new Guid("5fef395d-ace6-43dc-bd47-63a5b09d151d"), null, "5" },
                    { 123L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4832), null, null, 1L, 7L, 11, null, null, null, "DifficultyScale/5+-11-7", new Guid("8d5bffb0-f869-4b98-b328-5ab01d629c82"), null, "5+" },
                    { 124L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4838), null, null, 1L, 7L, 12, null, null, null, "DifficultyScale/6a-12-7", new Guid("fadfc0eb-53fb-4d70-88fa-26ac0a5abca9"), null, "6A" },
                    { 125L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4841), null, null, 2L, 7L, 13, null, null, null, "DifficultyScale/6a+-13-7", new Guid("e21bc8cd-9c2f-4cfb-a4ca-741f170b4b68"), null, "6A+" },
                    { 126L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4844), null, null, 2L, 7L, 14, null, null, null, "DifficultyScale/6b-14-7", new Guid("09d1d98e-f9dc-47c7-8d28-4752f10fe3f5"), null, "6B" },
                    { 127L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4847), null, null, 2L, 7L, 15, null, null, null, "DifficultyScale/6b+-15-7", new Guid("4e69e2ce-e1d9-4bcf-9c1b-f14939a1874a"), null, "6B+" },
                    { 128L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4850), null, null, 2L, 7L, 16, null, null, null, "DifficultyScale/6c-16-7", new Guid("71609e2a-a3b5-4d29-a791-23650f884e11"), null, "6C" },
                    { 129L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4853), null, null, 2L, 7L, 17, null, null, null, "DifficultyScale/6c+-17-7", new Guid("aaed8a43-6300-4339-89a5-9eb9b0bd507f"), null, "6C+" },
                    { 130L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4856), null, null, 2L, 7L, 18, null, null, null, "DifficultyScale/7a-18-7", new Guid("22016a7c-4d88-43d6-8562-38965f5a4097"), null, "7A" },
                    { 131L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4859), null, null, 3L, 7L, 19, null, null, null, "DifficultyScale/7a+-19-7", new Guid("2b1033d1-b422-466c-9c28-88231c9be583"), null, "7A+" },
                    { 132L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4864), null, null, 3L, 7L, 20, null, null, null, "DifficultyScale/7b-20-7", new Guid("bf254c6e-982b-404d-8468-263a0e702573"), null, "7B" },
                    { 133L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4868), null, null, 3L, 7L, 21, null, null, null, "DifficultyScale/7b+-21-7", new Guid("c23eccbf-f12f-4136-8f58-ea6885dd232a"), null, "7B+" },
                    { 134L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4872), null, null, 3L, 7L, 22, null, null, null, "DifficultyScale/7c-22-7", new Guid("dcd9ea15-e825-4c66-a6e8-34c89bb058bf"), null, "7C" },
                    { 135L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4876), null, null, 4L, 7L, 23, null, null, null, "DifficultyScale/7c+-23-7", new Guid("43bba1a7-94f4-4bb2-843d-d6d130964c8e"), null, "7C+" },
                    { 136L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4879), null, null, 4L, 7L, 24, null, null, null, "DifficultyScale/8a-24-7", new Guid("505369ce-39eb-477e-833c-043ac409a9fe"), null, "8A" },
                    { 137L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4882), null, null, 4L, 7L, 25, null, null, null, "DifficultyScale/8a+-25-7", new Guid("1a551efe-5761-47de-aad0-12a228194816"), null, "8A+" },
                    { 138L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4885), null, null, 4L, 7L, 26, null, null, null, "DifficultyScale/8b-26-7", new Guid("c90d0bf7-8fe1-4bfa-99e9-9626693615a7"), null, "8B" },
                    { 139L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4895), null, null, 5L, 7L, 27, null, null, null, "DifficultyScale/8b+-27-7", new Guid("2ef73a5d-8ef4-4e77-9e3e-2d3b4cbdaff8"), null, "8B+" },
                    { 140L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4900), null, null, 5L, 7L, 28, null, null, null, "DifficultyScale/8c-28-7", new Guid("2f5f695d-be1d-4b8e-ae08-a300404ac12a"), null, "8C" },
                    { 141L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4904), null, null, 5L, 7L, 29, null, null, null, "DifficultyScale/8c+-29-7", new Guid("efd6100e-785f-4ffb-a0a1-5bb321b44e6e"), null, "8C+" },
                    { 142L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4906), null, null, 5L, 7L, 30, null, null, null, "DifficultyScale/9a-30-7", new Guid("e35f2063-d76d-4590-8451-43c1c2dd4ecb"), null, "9A" },
                    { 143L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4909), null, null, 5L, 7L, 31, null, null, null, "DifficultyScale/9a+-31-7", new Guid("111362b6-fc16-4468-8f19-3c8bddb9c0c3"), null, "9A+" },
                    { 144L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4912), null, null, 5L, 7L, 32, null, null, null, "DifficultyScale/9a+-32-7", new Guid("78449112-8392-46dc-90dc-f1654bd87ced"), null, "9A+" },
                    { 145L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4915), null, "Simple pull or clip; minimal aid, very secure.", 1L, 4L, 1, null, null, null, "DifficultyScale/a0-1-4", new Guid("1edd5e3c-fba8-4e9f-9d6a-ac92c8d75c0d"), null, "A0" },
                    { 146L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4920), null, "Solid gear placements; short safe falls.", 2L, 4L, 2, null, null, null, "DifficultyScale/a1-2-4", new Guid("0fa94f8f-1a17-4c2a-bc7e-f3b53c6d5645"), null, "A1" },
                    { 147L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4923), null, "Mostly solid gear with some marginal pieces; long but safe falls.", 3L, 4L, 3, null, null, null, "DifficultyScale/a2-3-4", new Guid("ec7c2674-8901-4762-be57-6822c162b378"), null, "A2" },
                    { 148L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4929), null, "Multiple marginal placements; long falls possible.", 4L, 4L, 4, null, null, null, "DifficultyScale/a3-4-4", new Guid("cb6adf16-5a2c-4ac6-9482-7e35eae7f992"), null, "A3" },
                    { 149L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4933), null, "Series of very poor placements; extremely long, dangerous falls.", 5L, 4L, 5, null, null, null, "DifficultyScale/a4-5-4", new Guid("88897696-d35e-4de5-b3d9-7a5cc70cca9a"), null, "A4" },
                    { 150L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4937), null, "All placements likely to fail in a fall; fall would be fatal.", 5L, 4L, 6, null, null, null, "DifficultyScale/a5-6-4", new Guid("2b3fa4c5-c08b-4cb0-8a1f-4219382ebf7a"), null, "A5" },
                    { 151L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4940), null, "Pulling on gear or bolts without hammering; very secure.", 1L, 5L, 1, null, null, null, "DifficultyScale/c0-1-5", new Guid("23db0399-2e68-416e-8d9f-a97222f986ae"), null, "C0" },
                    { 152L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4944), null, "All placements solid and clean; safe falls.", 2L, 5L, 2, null, null, null, "DifficultyScale/c1-2-5", new Guid("61b1aa31-31d3-4c0d-b081-385ac34ee052"), null, "C1" },
                    { 153L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4947), null, "Some marginal pieces but generally safe; long falls possible.", 3L, 5L, 3, null, null, null, "DifficultyScale/c2-3-5", new Guid("932205de-4ad4-4326-8872-2ed96273efb5"), null, "C2" },
                    { 154L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4951), null, "Multiple unreliable placements; long potentially dangerous falls.", 4L, 5L, 4, null, null, null, "DifficultyScale/c3-4-5", new Guid("cfdc011e-9651-42e6-b8f0-e5cc2c3328ba"), null, "C3" },
                    { 155L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4957), null, "Sustained sequences of marginal gear; serious, very long falls.", 4L, 5L, 5, null, null, null, "DifficultyScale/c4-5-5", new Guid("599c6add-ec87-4268-b065-06d936227eb7"), null, "C4" },
                    { 156L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4963), null, "Fall likely to rip all clean gear; fall could be fatal.", 5L, 5L, 6, null, null, null, "DifficultyScale/c5-6-5", new Guid("5c645bf9-3a65-49f7-b5a6-9e7b61fe8879"), null, "C5" },
                    { 157L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4967), null, "Low-angle ice, easy movement, secure tool placements.", 1L, 8L, 1, null, null, null, "DifficultyScale/wi1-1-8", new Guid("ddb59993-7a0c-4157-bee7-55558f48041e"), null, "WI1" },
                    { 158L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4970), null, "Consistent 60° ice with occasional steeper steps; good protection.", 2L, 8L, 2, null, null, null, "DifficultyScale/wi2-2-8", new Guid("c5573e29-8540-430d-8865-ac7c24303cda"), null, "WI2" },
                    { 159L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4974), null, "Sustained 70° ice; short vertical steps; reliable protection.", 3L, 8L, 3, null, null, null, "DifficultyScale/wi3-3-8", new Guid("d520c9e6-c63b-468e-a76c-6d4090721309"), null, "WI3" },
                    { 160L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4985), null, "Continuous 80° ice with vertical sections; pumpy and technical.", 3L, 8L, 4, null, null, null, "DifficultyScale/wi4-4-8", new Guid("1d3781e4-8e08-4de7-a62f-9f121ec117c2"), null, "WI4" },
                    { 161L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4988), null, "Long vertical pitches with fewer rests; demanding protection.", 4L, 8L, 5, null, null, null, "DifficultyScale/wi5-5-8", new Guid("25b816b2-8582-4119-8b83-394e51790093"), null, "WI5" },
                    { 162L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4991), null, "Sustained vertical or overhanging ice; very technical and serious.", 4L, 8L, 6, null, null, null, "DifficultyScale/wi6-6-8", new Guid("414b44a3-bffb-4a10-87b7-cbdbcc7b34dc"), null, "WI6" },
                    { 163L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(4995), null, "Overhanging ice with poor protection; elite difficulty, dangerous.", 5L, 8L, 7, null, null, null, "DifficultyScale/wi7-7-8", new Guid("a4bdf286-1c38-4433-97bc-31aee4e6f157"), null, "WI7" },
                    { 164L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5002), null, "Low-angle alpine ice; simple movement; minimal exposure.", 1L, 9L, 1, null, null, null, "DifficultyScale/ai1-1-9", new Guid("4a7ce1c7-dad7-44a4-b44a-9fd5be1b55b6"), null, "AI1" },
                    { 165L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5006), null, "Consistent 50–60° ice; easy protection; moderate commitment.", 2L, 9L, 2, null, null, null, "DifficultyScale/ai2-2-9", new Guid("4f667cdb-7a9d-4c93-8232-82190a75dbb5"), null, "AI2" },
                    { 166L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5009), null, "Sustained steep ice with short vertical steps; increasing exposure.", 3L, 9L, 3, null, null, null, "DifficultyScale/ai3-3-9", new Guid("6b3b43e7-5e97-4e8d-836e-280a3195b694"), null, "AI3" },
                    { 167L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5016), null, "Long steep sections, complex protection, high-altitude seriousness.", 4L, 9L, 4, null, null, null, "DifficultyScale/ai4-4-9", new Guid("c6607c3b-3bae-4939-947c-6ec984ffe728"), null, "AI4" },
                    { 168L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5018), null, "Near-vertical alpine ice; very sustained; protection challenging.", 4L, 9L, 5, null, null, null, "DifficultyScale/ai5-5-9", new Guid("cecb3500-1e1c-4159-859e-c113661e8939"), null, "AI5" },
                    { 169L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5022), null, "Vertical or overhanging ice in high exposure terrain; extreme commitment.", 5L, 9L, 6, null, null, null, "DifficultyScale/ai6-6-9", new Guid("0e7d09c9-6c1c-4a35-b04d-503c84dddae3"), null, "AI6" },
                    { 170L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5025), null, "Moderate-angle ice; simple placements; suitable for beginners.", 1L, 10L, 1, null, null, null, "DifficultyScale/3-1-10", new Guid("8f02a9c7-64b6-4c05-98b5-bb293d250900"), null, "3" },
                    { 171L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5028), null, "Steeper ice with short vertical moves; moderate technicality.", 2L, 10L, 2, null, null, null, "DifficultyScale/4-2-10", new Guid("daf9dfb4-2feb-4bc6-b9ee-186177d4acc4"), null, "4" },
                    { 172L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5033), null, "Pumpy vertical climbing; sustained technical sequences.", 3L, 10L, 3, null, null, null, "DifficultyScale/5-3-10", new Guid("fa333147-c349-450c-b752-152ad1c73d77"), null, "5" },
                    { 173L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5037), null, "Long sustained sections with difficult protection; advanced skill required.", 4L, 10L, 4, null, null, null, "DifficultyScale/5+-4-10", new Guid("2244f616-7158-4f24-9aef-4fc8c3dcda96"), null, "5+" },
                    { 174L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5040), null, "Very steep or slightly overhanging ice; highly demanding climbing.", 4L, 10L, 5, null, null, null, "DifficultyScale/6-5-10", new Guid("c2eb173f-710f-468f-82fe-345ef7f02621"), null, "6" },
                    { 175L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5042), null, "Extreme difficulty; fragile or overhanging features; expert-only terrain.", 5L, 10L, 6, null, null, null, "DifficultyScale/7-6-10", new Guid("d2b442aa-52dd-4a9c-8255-8e74ed45c429"), null, "7" },
                    { 176L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5045), null, "Easy mixed terrain with low angle and secure holds.", 1L, 11L, 1, null, null, null, "DifficultyScale/m1-1-11", new Guid("7a4cde2a-bae9-4a73-89e2-fa484839af4d"), null, "M1" },
                    { 177L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5048), null, "Moderate mixed climbing; some technical tool placements.", 1L, 11L, 2, null, null, null, "DifficultyScale/m2-2-11", new Guid("c107d78f-cdd1-4c66-a895-caffa3d0439e"), null, "M2" },
                    { 178L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5051), null, "Steeper sections; balance moves and secure tool hooks.", 2L, 11L, 3, null, null, null, "DifficultyScale/m3-3-11", new Guid("ba1f5285-3c92-4b95-83ed-dde18f29bbe8"), null, "M3" },
                    { 179L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5054), null, "Vertical or near-vertical mixed terrain; technical movement.", 2L, 11L, 4, null, null, null, "DifficultyScale/m4-4-11", new Guid("eb2a48c2-afc4-4642-9051-63749aa1aa28"), null, "M4" },
                    { 180L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5059), null, "Sustained vertical moves with delicate placements.", 2L, 11L, 5, null, null, null, "DifficultyScale/m5-5-11", new Guid("7b34f41b-eeeb-43e7-b082-00734f5c113d"), null, "M5" },
                    { 181L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5070), null, "Difficult mixed climbing; powerful and technical hooking.", 3L, 11L, 6, null, null, null, "DifficultyScale/m6-6-11", new Guid("3b121632-2530-4a64-a42d-bec5e7244a57"), null, "M6" },
                    { 182L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5073), null, "Steep climbing with overhanging sequences; pumpy.", 3L, 11L, 7, null, null, null, "DifficultyScale/m7-7-11", new Guid("6216edaa-e29f-42ac-b20a-e56054d3f192"), null, "M7" },
                    { 183L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5077), null, "Long overhangs and challenging technical hooks.", 3L, 11L, 8, null, null, null, "DifficultyScale/m8-8-11", new Guid("ffba8f14-c593-4cc9-bffc-5ec14425260b"), null, "M8" },
                    { 184L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5080), null, "Significant overhangs, endurance-based sequences.", 4L, 11L, 9, null, null, null, "DifficultyScale/m9-9-11", new Guid("a0a05d50-7ad4-455a-b703-a801199690ed"), null, "M9" },
                    { 185L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5084), null, "Extreme overhangs with continuous powerful moves.", 4L, 11L, 10, null, null, null, "DifficultyScale/m10-10-11", new Guid("7e4ff666-73eb-47d5-97c4-1d669da0871c"), null, "M10" },
                    { 186L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5089), null, "Competition-level difficulty; massive roofs.", 4L, 11L, 11, null, null, null, "DifficultyScale/m11-11-11", new Guid("6d17fb09-5f32-4c55-a552-3f5dc907bcc7"), null, "M11" },
                    { 187L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5092), null, "Highly athletic movements on long overhangs.", 5L, 11L, 12, null, null, null, "DifficultyScale/m12-12-11", new Guid("222cdd17-ad14-4e33-ab4d-5ff7dc7b80c0"), null, "M12" },
                    { 188L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5097), null, "Elite mixed climbing with extreme overhanging terrain.", 5L, 11L, 13, null, null, null, "DifficultyScale/m13-13-11", new Guid("ecbca8d0-c92e-4d9a-af98-db191f7a19c5"), null, "M13" },
                    { 189L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5101), null, "Moderate drytool terrain; secure hooks and holds.", 1L, 12L, 1, null, null, null, "DifficultyScale/d4-1-12", new Guid("2ead306a-5dfa-4216-9f26-45e08d439d0e"), null, "D4" },
                    { 190L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5104), null, "Steeper terrain with precise tool placements.", 1L, 12L, 2, null, null, null, "DifficultyScale/d5-2-12", new Guid("ae47e425-3b54-433e-8d5e-767ad2b5a521"), null, "D5" },
                    { 191L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5108), null, "Vertical drytooling requiring technical accuracy.", 2L, 12L, 4, null, null, null, "DifficultyScale/d6-4-12", new Guid("9edb773d-6bc1-4632-9710-cc4a6d3623e1"), null, "D6" },
                    { 192L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5111), null, "Sustained steep sections; powerful hooking.", 2L, 12L, 5, null, null, null, "DifficultyScale/d7-5-12", new Guid("20d92531-97fe-451f-979b-7c691d1202ed"), null, "D7" },
                    { 193L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5114), null, "Long overhangs requiring endurance and technique.", 3L, 12L, 7, null, null, null, "DifficultyScale/d8-7-12", new Guid("92d09308-e33c-46dd-976b-0723acb1b3a6"), null, "D8" },
                    { 194L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5117), null, "Overhanging terrain with complex hook sequences.", 3L, 12L, 8, null, null, null, "DifficultyScale/d9-8-12", new Guid("0a7081a3-4c30-49eb-ae7a-59c73d7bca62"), null, "D9" },
                    { 195L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5120), null, "Massive overhangs; advanced drytooling skill required.", 4L, 12L, 9, null, null, null, "DifficultyScale/d10-9-12", new Guid("77475fb2-71f3-4a71-8105-22148ee8e576"), null, "D10" },
                    { 196L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5125), null, "Competition-level difficulty on long roofs.", 4L, 12L, 11, null, null, null, "DifficultyScale/d11-11-12", new Guid("f0390e9d-7a79-4dfe-8e01-7026f481d61a"), null, "D11" },
                    { 197L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5128), null, "Very powerful sequences on extreme overhangs.", 5L, 12L, 12, null, null, null, "DifficultyScale/d12-12-12", new Guid("4e9cb227-ce85-4c42-b9e5-9f855c5465bb"), null, "D12" },
                    { 198L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5131), null, "Elite-level difficulty; long, pumpy roofs.", 5L, 12L, 13, null, null, null, "DifficultyScale/d13-13-12", new Guid("dd9e8e3b-6978-478a-8cf7-f59855f8103b"), null, "D13" },
                    { 199L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5134), null, "World-class difficulty; sustained extreme movements.", 5L, 12L, 13, null, null, null, "DifficultyScale/d14-13-12", new Guid("65934439-0d22-42e2-85a8-e5e004ff831d"), null, "D14" },
                    { 200L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5138), null, "Easy; simple steps and minimal exposure.", 1L, 13L, 1, null, null, null, "DifficultyScale/f-1-13", new Guid("727983dd-038b-4cb5-996b-2490d5080dab"), null, "F" },
                    { 201L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5141), null, "Slightly difficult; moderate steepness and exposure.", 2L, 13L, 2, null, null, null, "DifficultyScale/pd-2-13", new Guid("ca81316e-2a22-4fd7-8e10-aba63679f6f7"), null, "PD" },
                    { 202L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5152), null, "Fairly difficult; steeper sections requiring strength.", 3L, 13L, 3, null, null, null, "DifficultyScale/ad-3-13", new Guid("07fa2e69-d342-426d-8ca3-c1d808d80e8b"), null, "AD" },
                    { 203L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5155), null, "Difficult; vertical sections and significant exposure.", 3L, 13L, 4, null, null, null, "DifficultyScale/d-4-13", new Guid("c622d586-b3b7-4117-bd3b-4b59740a0bd5"), null, "D" },
                    { 204L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5160), null, "Very difficult; strenuous, with continuous demanding moves.", 4L, 13L, 5, null, null, null, "DifficultyScale/td-5-13", new Guid("79146856-c999-44f6-af98-b3401eb99552"), null, "TD" },
                    { 205L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5164), null, "Extremely difficult; overhangs and high exposure.", 5L, 13L, 6, null, null, null, "DifficultyScale/ed-6-13", new Guid("ba22b9e7-b605-4de3-bc54-65a5a5254bb8"), null, "ED" },
                    { 206L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5167), null, "Very easy; minimal steepness and exposure.", 1L, 14L, 1, null, null, null, "DifficultyScale/k1-1-14", new Guid("9909baad-e77f-46ce-8647-63973b0545a2"), null, "K1" },
                    { 207L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5171), null, "Easy; moderate ladders and metal holds.", 2L, 14L, 2, null, null, null, "DifficultyScale/k2-2-14", new Guid("bac49943-b1b7-4769-859d-7dba5a9ad26f"), null, "K2" },
                    { 208L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5174), null, "Moderate; steeper sections and continuous effort.", 3L, 14L, 3, null, null, null, "DifficultyScale/k3-3-14", new Guid("ed716d8d-39dc-4cde-b39e-91d6cdf5ff68"), null, "K3" },
                    { 209L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5177), null, "Difficult; vertical terrain and strong exposure.", 3L, 14L, 4, null, null, null, "DifficultyScale/k4-4-14", new Guid("c56e4d3b-e24d-4450-8ad0-735ddc204009"), null, "K4" },
                    { 210L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5180), null, "Very difficult; overhanging sections requiring strength.", 4L, 14L, 5, null, null, null, "DifficultyScale/k5-5-14", new Guid("9061ae72-f556-441a-80f0-03b31d4d5af6"), null, "K5" },
                    { 211L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5182), null, "Extremely difficult; technical and highly exposed climbing.", 5L, 14L, 6, null, null, null, "DifficultyScale/k6-6-14", new Guid("3dfe2724-b136-4807-a81e-d823fdb923a1"), null, "K6" },
                    { 212L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5188), null, "Easy; well-secured sections with minimal difficulty.", 1L, 15L, 1, null, null, null, "DifficultyScale/a-1-15", new Guid("da7d7948-5f8f-4e18-9f83-20161caffc64"), null, "A" },
                    { 213L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5191), null, "Moderately difficult; steeper segments requiring effort.", 2L, 15L, 2, null, null, null, "DifficultyScale/b-2-15", new Guid("cfe26a83-0885-4c51-ad58-6f47d2edc11a"), null, "B" },
                    { 214L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5195), null, "Difficult; steep and exposed climbing.", 3L, 15L, 3, null, null, null, "DifficultyScale/c-3-15", new Guid("eecbd73f-f7cc-4791-8f7c-27aa85703299"), null, "C" },
                    { 215L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5198), null, "Very difficult; overhangs and minimal artificial holds.", 4L, 15L, 4, null, null, null, "DifficultyScale/d-4-15", new Guid("7c708c2f-5874-411a-a764-954a230e2675"), null, "D" },
                    { 216L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5201), null, "Extremely difficult; serious exposure and sustained difficulty.", 5L, 15L, 5, null, null, null, "DifficultyScale/e-5-15", new Guid("91d5ce3e-a3dc-431e-a150-8a5b2b963f0b"), null, "E" },
                    { 217L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5204), null, "Easy alpine route; minimal technical difficulty.", 1L, 16L, 1, null, null, null, "DifficultyScale/f-1-16", new Guid("e6ed7a69-dd8f-44ab-ba68-ead9974b58f0"), null, "F" },
                    { 218L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5206), null, "Slightly difficult; some technical sections or exposure.", 2L, 16L, 2, null, null, null, "DifficultyScale/pd-2-16", new Guid("f29588ca-1001-4edc-b0ee-2c042fc2f551"), null, "PD" },
                    { 219L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5210), null, "Fairly difficult; mixed terrain and moderate exposure.", 2L, 16L, 3, null, null, null, "DifficultyScale/ad-3-16", new Guid("78234f14-3973-4733-b7d4-500d70a97401"), null, "AD" },
                    { 220L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5215), null, "Difficult; sustained technical sections with serious exposure.", 3L, 16L, 4, null, null, null, "DifficultyScale/d-4-16", new Guid("8f1da2cc-5c2d-48db-ad71-c0268d03a758"), null, "D" },
                    { 221L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5218), null, "Very difficult; long and committing technical terrain.", 4L, 16L, 5, null, null, null, "DifficultyScale/td/md-5-16", new Guid("b468905e-286e-48a2-869e-786f9d9193d9"), null, "TD/MD" },
                    { 222L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5227), null, "Extremely difficult; highly technical and exposed alpine climbing.", 4L, 16L, 6, null, null, null, "DifficultyScale/ed-6-16", new Guid("d6108a30-3070-4086-8b2f-86bf4a9b2e22"), null, "ED" },
                    { 223L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5231), null, "Abominably difficult; extreme commitment and danger.", 5L, 16L, 7, null, null, null, "DifficultyScale/abo-7-16", new Guid("10107424-6883-4a97-a4f5-409299b34412"), null, "ABO" },
                    { 224L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5234), null, "Low exposure; short falls with minimal consequence.", null, 17L, 1, null, null, null, "DifficultyScale/pg-1-17", new Guid("a9e27be0-fb38-4d8b-99a2-c082d7f7ed40"), null, "PG" },
                    { 225L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5237), null, "Serious exposure; long falls or poor protection.", null, 17L, 2, null, null, null, "DifficultyScale/r-2-17", new Guid("1700f253-bf6b-4151-81f5-0016b9160621"), null, "R" },
                    { 226L, new DateTime(2026, 4, 2, 20, 1, 41, 515, DateTimeKind.Utc).AddTicks(5240), null, "Extreme exposure; falls likely fatal or unprotectable.", null, 17L, 3, null, null, null, "DifficultyScale/x-3-17", new Guid("7b5cacfa-f355-4499-9783-a506a79c4f00"), null, "X" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accommodation_ExpeditionId",
                table: "Accommodation",
                column: "ExpeditionId");

            migrationBuilder.CreateIndex(
                name: "IX_Accommodation_ItineraryDayId",
                table: "Accommodation",
                column: "ItineraryDayId");

            migrationBuilder.CreateIndex(
                name: "IX_Accommodation_Slug",
                table: "Accommodation",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accommodation_Uid",
                table: "Accommodation",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AIGenerationFeedback_AIGenerationRequestId",
                table: "AIGenerationFeedback",
                column: "AIGenerationRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_AIGenerationFeedback_Slug",
                table: "AIGenerationFeedback",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AIGenerationFeedback_Uid",
                table: "AIGenerationFeedback",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AIGenerationHistory_AIGenerationRequestId",
                table: "AIGenerationHistory",
                column: "AIGenerationRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_AIGenerationHistory_AIModelVersionId",
                table: "AIGenerationHistory",
                column: "AIModelVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_AIGenerationHistory_Slug",
                table: "AIGenerationHistory",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AIGenerationHistory_Uid",
                table: "AIGenerationHistory",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AIGenerationRequest_AIModelId",
                table: "AIGenerationRequest",
                column: "AIModelId");

            migrationBuilder.CreateIndex(
                name: "IX_AIGenerationRequest_AIModelVersionId",
                table: "AIGenerationRequest",
                column: "AIModelVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_AIGenerationRequest_Slug",
                table: "AIGenerationRequest",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AIGenerationRequest_Uid",
                table: "AIGenerationRequest",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AIGenerationTemplate_AIModelId",
                table: "AIGenerationTemplate",
                column: "AIModelId");

            migrationBuilder.CreateIndex(
                name: "IX_AIGenerationTemplate_Name",
                table: "AIGenerationTemplate",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AIGenerationTemplate_Slug",
                table: "AIGenerationTemplate",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AIGenerationTemplate_Uid",
                table: "AIGenerationTemplate",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AIModel_Name",
                table: "AIModel",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AIModel_Slug",
                table: "AIModel",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AIModel_Uid",
                table: "AIModel",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AIModelBenchmark_AIModelId",
                table: "AIModelBenchmark",
                column: "AIModelId");

            migrationBuilder.CreateIndex(
                name: "IX_AIModelBenchmark_AIModelVersionId",
                table: "AIModelBenchmark",
                column: "AIModelVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_AIModelBenchmark_Slug",
                table: "AIModelBenchmark",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AIModelBenchmark_Uid",
                table: "AIModelBenchmark",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AIModelConfiguration_AIModelId",
                table: "AIModelConfiguration",
                column: "AIModelId");

            migrationBuilder.CreateIndex(
                name: "IX_AIModelConfiguration_Slug",
                table: "AIModelConfiguration",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AIModelConfiguration_Uid",
                table: "AIModelConfiguration",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AIModelLog_AIModelId",
                table: "AIModelLog",
                column: "AIModelId");

            migrationBuilder.CreateIndex(
                name: "IX_AIModelLog_Slug",
                table: "AIModelLog",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AIModelLog_Uid",
                table: "AIModelLog",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AIModelVersion_AIModelId",
                table: "AIModelVersion",
                column: "AIModelId");

            migrationBuilder.CreateIndex(
                name: "IX_AIModelVersion_Slug",
                table: "AIModelVersion",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AIModelVersion_Uid",
                table: "AIModelVersion",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AITrainingData_Slug",
                table: "AITrainingData",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AITrainingData_Uid",
                table: "AITrainingData",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AITrainingData_UsedByModelId",
                table: "AITrainingData",
                column: "UsedByModelId");

            migrationBuilder.CreateIndex(
                name: "IX_AITrainingSession_AIModelId",
                table: "AITrainingSession",
                column: "AIModelId");

            migrationBuilder.CreateIndex(
                name: "IX_AITrainingSession_AIModelVersionId",
                table: "AITrainingSession",
                column: "AIModelVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_AITrainingSession_Slug",
                table: "AITrainingSession",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AITrainingSession_Uid",
                table: "AITrainingSession",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AuditTrail_CorrelationId",
                table: "AuditTrail",
                column: "CorrelationId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditTrail_EntityId",
                table: "AuditTrail",
                column: "EntityId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditTrail_EntityName",
                table: "AuditTrail",
                column: "EntityName");

            migrationBuilder.CreateIndex(
                name: "IX_AuditTrail_IpAddress",
                table: "AuditTrail",
                column: "IpAddress");

            migrationBuilder.CreateIndex(
                name: "IX_AuditTrail_SessionId",
                table: "AuditTrail",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_AuditTrail_Slug",
                table: "AuditTrail",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AuditTrail_Uid",
                table: "AuditTrail",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AuditTrail_UserId",
                table: "AuditTrail",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Board_BoardConfigId",
                table: "Board",
                column: "BoardConfigId");

            migrationBuilder.CreateIndex(
                name: "IX_Board_Name",
                table: "Board",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Board_OrganizationId",
                table: "Board",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Board_Slug",
                table: "Board",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Board_Uid",
                table: "Board",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BoardAngle_Angle_Unit",
                table: "BoardAngle",
                columns: new[] { "Angle", "Unit" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BoardAngle_Slug",
                table: "BoardAngle",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BoardAngle_Uid",
                table: "BoardAngle",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BoardConfig_ApprovedByUserId",
                table: "BoardConfig",
                column: "ApprovedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BoardConfig_CreatedByUserId_IsActive",
                table: "BoardConfig",
                columns: new[] { "CreatedByUserId", "IsActive" });

            migrationBuilder.CreateIndex(
                name: "IX_BoardConfig_Name",
                table: "BoardConfig",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BoardConfig_PreviousVersionId",
                table: "BoardConfig",
                column: "PreviousVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_BoardConfig_Slug",
                table: "BoardConfig",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BoardConfig_Uid",
                table: "BoardConfig",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BoardItem_BoardConfigId_PositionX_PositionY",
                table: "BoardItem",
                columns: new[] { "BoardConfigId", "PositionX", "PositionY" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BoardItem_BoardItemTypeId",
                table: "BoardItem",
                column: "BoardItemTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BoardItem_BoardItemVolumeId",
                table: "BoardItem",
                column: "BoardItemVolumeId");

            migrationBuilder.CreateIndex(
                name: "IX_BoardItem_Slug",
                table: "BoardItem",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BoardItem_Uid",
                table: "BoardItem",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BoardItemTexture_Name",
                table: "BoardItemTexture",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BoardItemTexture_Slug",
                table: "BoardItemTexture",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BoardItemTexture_Uid",
                table: "BoardItemTexture",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BoardItemTextureCombination_BoardItemId_BoardItemTextureId_~",
                table: "BoardItemTextureCombination",
                columns: new[] { "BoardItemId", "BoardItemTextureId", "BoardItemTextureMaterialId", "Percentage", "Order" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BoardItemTextureCombination_BoardItemTextureId",
                table: "BoardItemTextureCombination",
                column: "BoardItemTextureId");

            migrationBuilder.CreateIndex(
                name: "IX_BoardItemTextureCombination_BoardItemTextureMaterialId",
                table: "BoardItemTextureCombination",
                column: "BoardItemTextureMaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_BoardItemTextureCombination_Slug",
                table: "BoardItemTextureCombination",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BoardItemTextureCombination_Uid",
                table: "BoardItemTextureCombination",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BoardItemTextureMaterial_Name",
                table: "BoardItemTextureMaterial",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BoardItemTextureMaterial_Slug",
                table: "BoardItemTextureMaterial",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BoardItemTextureMaterial_Uid",
                table: "BoardItemTextureMaterial",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BoardItemType_Name",
                table: "BoardItemType",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BoardItemType_Slug",
                table: "BoardItemType",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BoardItemType_Uid",
                table: "BoardItemType",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BoardItemVolume_Name",
                table: "BoardItemVolume",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BoardItemVolume_Slug",
                table: "BoardItemVolume",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BoardItemVolume_Uid",
                table: "BoardItemVolume",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BoardMember_BoardId_UserId",
                table: "BoardMember",
                columns: new[] { "BoardId", "UserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BoardMember_Slug",
                table: "BoardMember",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BoardMember_Uid",
                table: "BoardMember",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BoardMember_UserId",
                table: "BoardMember",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BoardProblem_BoardConfigId_Name",
                table: "BoardProblem",
                columns: new[] { "BoardConfigId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BoardProblem_CreatedByUserId",
                table: "BoardProblem",
                column: "CreatedByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BoardProblem_Name",
                table: "BoardProblem",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_BoardProblem_Slug",
                table: "BoardProblem",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BoardProblem_Uid",
                table: "BoardProblem",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BoardProblemAngle_BoardAngleId_BoardProblemId_DifficultySca~",
                table: "BoardProblemAngle",
                columns: new[] { "BoardAngleId", "BoardProblemId", "DifficultyScaleId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BoardProblemAngle_BoardProblemId",
                table: "BoardProblemAngle",
                column: "BoardProblemId");

            migrationBuilder.CreateIndex(
                name: "IX_BoardProblemAngle_DifficultyScaleId",
                table: "BoardProblemAngle",
                column: "DifficultyScaleId");

            migrationBuilder.CreateIndex(
                name: "IX_BoardProblemAngle_Slug",
                table: "BoardProblemAngle",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BoardProblemAngle_Uid",
                table: "BoardProblemAngle",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BoardProblemBoardProblemTag_BoardProblemsId",
                table: "BoardProblemBoardProblemTag",
                column: "BoardProblemsId");

            migrationBuilder.CreateIndex(
                name: "IX_BoardProblemFootRule_FootRulesId",
                table: "BoardProblemFootRule",
                column: "FootRulesId");

            migrationBuilder.CreateIndex(
                name: "IX_BoardProblemItem_BoardItemId",
                table: "BoardProblemItem",
                column: "BoardItemId");

            migrationBuilder.CreateIndex(
                name: "IX_BoardProblemItem_BoardProblemId_BoardItemId_BoardProblemIte~",
                table: "BoardProblemItem",
                columns: new[] { "BoardProblemId", "BoardItemId", "BoardProblemItemTypeId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BoardProblemItem_BoardProblemItemTypeId",
                table: "BoardProblemItem",
                column: "BoardProblemItemTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BoardProblemItem_Slug",
                table: "BoardProblemItem",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BoardProblemItem_Uid",
                table: "BoardProblemItem",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BoardProblemItemType_ColorId",
                table: "BoardProblemItemType",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_BoardProblemItemType_Slug",
                table: "BoardProblemItemType",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BoardProblemItemType_Uid",
                table: "BoardProblemItemType",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BoardProblemTag_Name",
                table: "BoardProblemTag",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BoardProblemTag_Slug",
                table: "BoardProblemTag",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BoardProblemTag_Uid",
                table: "BoardProblemTag",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BoardSessionSummary_BoardId",
                table: "BoardSessionSummary",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_BoardSessionSummary_Slug",
                table: "BoardSessionSummary",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BoardSessionSummary_Uid",
                table: "BoardSessionSummary",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BoardSessionSummary_UserId",
                table: "BoardSessionSummary",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessage_SessionId",
                table: "ChatMessage",
                column: "SessionId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessage_Slug",
                table: "ChatMessage",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessage_Uid",
                table: "ChatMessage",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClimbRoute_ClimbTagId",
                table: "ClimbRoute",
                column: "ClimbTagId");

            migrationBuilder.CreateIndex(
                name: "IX_ClimbRoute_ClimbZoneId",
                table: "ClimbRoute",
                column: "ClimbZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_ClimbRoute_DifficultyScaleId",
                table: "ClimbRoute",
                column: "DifficultyScaleId");

            migrationBuilder.CreateIndex(
                name: "IX_ClimbRoute_DifficultyScaleNameId",
                table: "ClimbRoute",
                column: "DifficultyScaleNameId");

            migrationBuilder.CreateIndex(
                name: "IX_ClimbRoute_Slug",
                table: "ClimbRoute",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClimbRoute_Uid",
                table: "ClimbRoute",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClimbRouteDescription_ClimbRouteId",
                table: "ClimbRouteDescription",
                column: "ClimbRouteId");

            migrationBuilder.CreateIndex(
                name: "IX_ClimbRouteDescription_Slug",
                table: "ClimbRouteDescription",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClimbRouteDescription_Uid",
                table: "ClimbRouteDescription",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClimbRouteFile_ClimbRouteId",
                table: "ClimbRouteFile",
                column: "ClimbRouteId");

            migrationBuilder.CreateIndex(
                name: "IX_ClimbRouteFile_Slug",
                table: "ClimbRouteFile",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClimbRouteFile_Uid",
                table: "ClimbRouteFile",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClimbTag_Name",
                table: "ClimbTag",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClimbTag_Slug",
                table: "ClimbTag",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClimbTag_Uid",
                table: "ClimbTag",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClimbZone_OrganizationId",
                table: "ClimbZone",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_ClimbZone_Slug",
                table: "ClimbZone",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClimbZone_Uid",
                table: "ClimbZone",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClimbZoneFile_ClimbZoneId",
                table: "ClimbZoneFile",
                column: "ClimbZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_ClimbZoneFile_Slug",
                table: "ClimbZoneFile",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ClimbZoneFile_Uid",
                table: "ClimbZoneFile",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Color_ColorHex_HexCode",
                table: "Color",
                column: "ColorHex_HexCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Color_ColorHsl_HslHue_ColorHsl_HslSaturation_ColorHsl_HslLi~",
                table: "Color",
                columns: new[] { "ColorHsl_HslHue", "ColorHsl_HslSaturation", "ColorHsl_HslLightness" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Color_ColorRgb_RgbRed_ColorRgb_RgbGreen_ColorRgb_RgbBlue",
                table: "Color",
                columns: new[] { "ColorRgb_RgbRed", "ColorRgb_RgbGreen", "ColorRgb_RgbBlue" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Color_DisplayName",
                table: "Color",
                column: "DisplayName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Color_Name",
                table: "Color",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Color_Slug",
                table: "Color",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Color_Uid",
                table: "Color",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comment_ParentCommentId",
                table: "Comment",
                column: "ParentCommentId");

            migrationBuilder.CreateIndex(
                name: "IX_Comment_Slug",
                table: "Comment",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comment_Uid",
                table: "Comment",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CommentAttachment_CommentId",
                table: "CommentAttachment",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentAttachment_Slug",
                table: "CommentAttachment",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CommentAttachment_Uid",
                table: "CommentAttachment",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CommentMention_CommentId_MentionedUserId",
                table: "CommentMention",
                columns: new[] { "CommentId", "MentionedUserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CommentMention_Slug",
                table: "CommentMention",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CommentMention_Uid",
                table: "CommentMention",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CommentReaction_CommentId_UserId_ReactionType",
                table: "CommentReaction",
                columns: new[] { "CommentId", "UserId", "ReactionType" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CommentReaction_Slug",
                table: "CommentReaction",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CommentReaction_Uid",
                table: "CommentReaction",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CommentReport_CommentId",
                table: "CommentReport",
                column: "CommentId");

            migrationBuilder.CreateIndex(
                name: "IX_CommentReport_Slug",
                table: "CommentReport",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CommentReport_Uid",
                table: "CommentReport",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Configuration_Key_UserId",
                table: "Configuration",
                columns: new[] { "Key", "UserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Configuration_Slug",
                table: "Configuration",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Configuration_Uid",
                table: "Configuration",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ConfigurationVersion_EntityType_EntityId_VersionNumber",
                table: "ConfigurationVersion",
                columns: new[] { "EntityType", "EntityId", "VersionNumber" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ConfigurationVersion_Slug",
                table: "ConfigurationVersion",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ConfigurationVersion_Uid",
                table: "ConfigurationVersion",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DayActivity_ItineraryDayId",
                table: "DayActivity",
                column: "ItineraryDayId");

            migrationBuilder.CreateIndex(
                name: "IX_DayActivity_Slug",
                table: "DayActivity",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DayActivity_Uid",
                table: "DayActivity",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DayActivityDifficultyScale_DayActivityId",
                table: "DayActivityDifficultyScale",
                column: "DayActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_DayActivityDifficultyScale_DifficultyScaleId",
                table: "DayActivityDifficultyScale",
                column: "DifficultyScaleId");

            migrationBuilder.CreateIndex(
                name: "IX_DayActivityDifficultyScale_Slug",
                table: "DayActivityDifficultyScale",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DayActivityDifficultyScale_Uid",
                table: "DayActivityDifficultyScale",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DifficultyGroup_Level",
                table: "DifficultyGroup",
                column: "Level",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DifficultyGroup_Name",
                table: "DifficultyGroup",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DifficultyGroup_Slug",
                table: "DifficultyGroup",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DifficultyGroup_Uid",
                table: "DifficultyGroup",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DifficultyScale_DifficultyGroupId",
                table: "DifficultyScale",
                column: "DifficultyGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_DifficultyScale_DifficultyScaleNameId",
                table: "DifficultyScale",
                column: "DifficultyScaleNameId");

            migrationBuilder.CreateIndex(
                name: "IX_DifficultyScale_Slug",
                table: "DifficultyScale",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DifficultyScale_Uid",
                table: "DifficultyScale",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DifficultyScaleName_DifficultyScaleTypeId",
                table: "DifficultyScaleName",
                column: "DifficultyScaleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_DifficultyScaleName_Name",
                table: "DifficultyScaleName",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DifficultyScaleName_Slug",
                table: "DifficultyScaleName",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DifficultyScaleName_Uid",
                table: "DifficultyScaleName",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DifficultyScaleType_Name",
                table: "DifficultyScaleType",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DifficultyScaleType_Slug",
                table: "DifficultyScaleType",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_DifficultyScaleType_Uid",
                table: "DifficultyScaleType",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_EquipmentCategoryId",
                table: "Equipment",
                column: "EquipmentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_EquipmentCategoryId1",
                table: "Equipment",
                column: "EquipmentCategoryId1");

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_Slug",
                table: "Equipment",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Equipment_Uid",
                table: "Equipment",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentCategory_Name",
                table: "EquipmentCategory",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentCategory_Slug",
                table: "EquipmentCategory",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentCategory_Uid",
                table: "EquipmentCategory",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EscalationRule_Slug",
                table: "EscalationRule",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EscalationRule_Uid",
                table: "EscalationRule",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Expedition_BaseCampLocation",
                table: "Expedition",
                column: "BaseCampLocation")
                .Annotation("Npgsql:IndexMethod", "GIST");

            migrationBuilder.CreateIndex(
                name: "IX_Expedition_MountainId",
                table: "Expedition",
                column: "MountainId");

            migrationBuilder.CreateIndex(
                name: "IX_Expedition_MountainRouteId",
                table: "Expedition",
                column: "MountainRouteId");

            migrationBuilder.CreateIndex(
                name: "IX_Expedition_Name",
                table: "Expedition",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Expedition_OrganizedBy",
                table: "Expedition",
                column: "OrganizedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Expedition_OrganizedByOrganizationId",
                table: "Expedition",
                column: "OrganizedByOrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_Expedition_Slug",
                table: "Expedition",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Expedition_Uid",
                table: "Expedition",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExpeditionBudget_ExpeditionBudgetCategoryId",
                table: "ExpeditionBudget",
                column: "ExpeditionBudgetCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpeditionBudget_ExpeditionBudgetCategoryId1",
                table: "ExpeditionBudget",
                column: "ExpeditionBudgetCategoryId1");

            migrationBuilder.CreateIndex(
                name: "IX_ExpeditionBudget_ExpeditionId",
                table: "ExpeditionBudget",
                column: "ExpeditionId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpeditionBudget_Slug",
                table: "ExpeditionBudget",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExpeditionBudget_Uid",
                table: "ExpeditionBudget",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExpeditionBudgetCategory_ExpeditionId",
                table: "ExpeditionBudgetCategory",
                column: "ExpeditionId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpeditionBudgetCategory_Name",
                table: "ExpeditionBudgetCategory",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExpeditionBudgetCategory_Slug",
                table: "ExpeditionBudgetCategory",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExpeditionBudgetCategory_Uid",
                table: "ExpeditionBudgetCategory",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExpeditionEquipment_EquipmentId",
                table: "ExpeditionEquipment",
                column: "EquipmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpeditionEquipment_ExpeditionId",
                table: "ExpeditionEquipment",
                column: "ExpeditionId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpeditionEquipment_Slug",
                table: "ExpeditionEquipment",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExpeditionEquipment_Uid",
                table: "ExpeditionEquipment",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExpeditionLevelScales_DifficultyScaleId",
                table: "ExpeditionLevelScales",
                column: "DifficultyScaleId");

            migrationBuilder.CreateIndex(
                name: "IX_ExpeditionLevelScales_ExpeditionId_DifficultyScaleId",
                table: "ExpeditionLevelScales",
                columns: new[] { "ExpeditionId", "DifficultyScaleId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExpeditionLevelScales_Slug",
                table: "ExpeditionLevelScales",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExpeditionLevelScales_Uid",
                table: "ExpeditionLevelScales",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExpeditionParticipant_ExpeditionId_UserId",
                table: "ExpeditionParticipant",
                columns: new[] { "ExpeditionId", "UserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExpeditionParticipant_Slug",
                table: "ExpeditionParticipant",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExpeditionParticipant_Uid",
                table: "ExpeditionParticipant",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ExpeditionParticipant_UserId",
                table: "ExpeditionParticipant",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_FAQ_CategoryId",
                table: "FAQ",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FAQ_Slug",
                table: "FAQ",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FAQ_Uid",
                table: "FAQ",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FitnessTest_Slug",
                table: "FitnessTest",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FitnessTest_Uid",
                table: "FitnessTest",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FootRule_Code",
                table: "FootRule",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FootRule_Name",
                table: "FootRule",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_FootRule_Slug",
                table: "FootRule",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FootRule_Uid",
                table: "FootRule",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HelpArticle_CategoryId",
                table: "HelpArticle",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_HelpArticle_Slug",
                table: "HelpArticle",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HelpArticle_Uid",
                table: "HelpArticle",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HelpArticleAttachment_ArticleId",
                table: "HelpArticleAttachment",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_HelpArticleAttachment_Slug",
                table: "HelpArticleAttachment",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HelpArticleAttachment_Uid",
                table: "HelpArticleAttachment",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HelpArticleVersion_ArticleId",
                table: "HelpArticleVersion",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_HelpArticleVersion_Slug",
                table: "HelpArticleVersion",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HelpArticleVersion_Uid",
                table: "HelpArticleVersion",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HelpCategory_Name",
                table: "HelpCategory",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HelpCategory_ParentCategoryId",
                table: "HelpCategory",
                column: "ParentCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_HelpCategory_Slug",
                table: "HelpCategory",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HelpCategory_Uid",
                table: "HelpCategory",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HelpFeedback_Slug",
                table: "HelpFeedback",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HelpFeedback_Uid",
                table: "HelpFeedback",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HelpSearchLog_Slug",
                table: "HelpSearchLog",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_HelpSearchLog_Uid",
                table: "HelpSearchLog",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_InvoiceNumber",
                table: "Invoice",
                column: "InvoiceNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_Slug",
                table: "Invoice",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Invoice_Uid",
                table: "Invoice",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceItem_InvoiceId",
                table: "InvoiceItem",
                column: "InvoiceId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceItem_PaymentId",
                table: "InvoiceItem",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceItem_Slug",
                table: "InvoiceItem",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_InvoiceItem_Uid",
                table: "InvoiceItem",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItineraryDay_ExpeditionId",
                table: "ItineraryDay",
                column: "ExpeditionId");

            migrationBuilder.CreateIndex(
                name: "IX_ItineraryDay_ExpeditionId1",
                table: "ItineraryDay",
                column: "ExpeditionId1");

            migrationBuilder.CreateIndex(
                name: "IX_ItineraryDay_Slug",
                table: "ItineraryDay",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItineraryDay_Uid",
                table: "ItineraryDay",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItineraryDayTrack_ItineraryDayId",
                table: "ItineraryDayTrack",
                column: "ItineraryDayId");

            migrationBuilder.CreateIndex(
                name: "IX_ItineraryDayTrack_ItineraryTrackId",
                table: "ItineraryDayTrack",
                column: "ItineraryTrackId");

            migrationBuilder.CreateIndex(
                name: "IX_ItineraryDayTrack_Slug",
                table: "ItineraryDayTrack",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItineraryDayTrack_Uid",
                table: "ItineraryDayTrack",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItineraryDayTrackFile_ItineraryDayTrackId",
                table: "ItineraryDayTrackFile",
                column: "ItineraryDayTrackId");

            migrationBuilder.CreateIndex(
                name: "IX_ItineraryDayTrackFile_Slug",
                table: "ItineraryDayTrackFile",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItineraryDayTrackFile_Uid",
                table: "ItineraryDayTrackFile",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItineraryDayWaypoint_ItineraryDayId",
                table: "ItineraryDayWaypoint",
                column: "ItineraryDayId");

            migrationBuilder.CreateIndex(
                name: "IX_ItineraryDayWaypoint_ItineraryDayTrackId",
                table: "ItineraryDayWaypoint",
                column: "ItineraryDayTrackId");

            migrationBuilder.CreateIndex(
                name: "IX_ItineraryDayWaypoint_Slug",
                table: "ItineraryDayWaypoint",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItineraryDayWaypoint_Uid",
                table: "ItineraryDayWaypoint",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItineraryDayWaypoint_WaypointTypeId",
                table: "ItineraryDayWaypoint",
                column: "WaypointTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ItineraryDayWaypointFile_ItineraryDayWaypointId",
                table: "ItineraryDayWaypointFile",
                column: "ItineraryDayWaypointId");

            migrationBuilder.CreateIndex(
                name: "IX_ItineraryDayWaypointFile_Slug",
                table: "ItineraryDayWaypointFile",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItineraryDayWaypointFile_Uid",
                table: "ItineraryDayWaypointFile",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItineraryFile_ExpeditionId",
                table: "ItineraryFile",
                column: "ExpeditionId");

            migrationBuilder.CreateIndex(
                name: "IX_ItineraryFile_Slug",
                table: "ItineraryFile",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItineraryFile_Uid",
                table: "ItineraryFile",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItineraryTrack_ExpeditionId",
                table: "ItineraryTrack",
                column: "ExpeditionId");

            migrationBuilder.CreateIndex(
                name: "IX_ItineraryTrack_Slug",
                table: "ItineraryTrack",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItineraryTrack_Uid",
                table: "ItineraryTrack",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItineraryTrackFile_ItineraryTrackId",
                table: "ItineraryTrackFile",
                column: "ItineraryTrackId");

            migrationBuilder.CreateIndex(
                name: "IX_ItineraryTrackFile_Slug",
                table: "ItineraryTrackFile",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ItineraryTrackFile_Uid",
                table: "ItineraryTrackFile",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_KnowledgeBase_CategoryId",
                table: "KnowledgeBase",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_KnowledgeBase_Slug",
                table: "KnowledgeBase",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_KnowledgeBase_Uid",
                table: "KnowledgeBase",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LiveChatSession_SessionId",
                table: "LiveChatSession",
                column: "SessionId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LiveChatSession_Slug",
                table: "LiveChatSession",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LiveChatSession_Uid",
                table: "LiveChatSession",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Meal_ExpeditionId",
                table: "Meal",
                column: "ExpeditionId");

            migrationBuilder.CreateIndex(
                name: "IX_Meal_ItineraryDayId",
                table: "Meal",
                column: "ItineraryDayId");

            migrationBuilder.CreateIndex(
                name: "IX_Meal_Slug",
                table: "Meal",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Meal_Uid",
                table: "Meal",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mountain_Location",
                table: "Mountain",
                column: "Location")
                .Annotation("Npgsql:IndexMethod", "GIST");

            migrationBuilder.CreateIndex(
                name: "IX_Mountain_Name",
                table: "Mountain",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mountain_Slug",
                table: "Mountain",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mountain_Uid",
                table: "Mountain",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MountainExpeditionLog_ExpeditionId",
                table: "MountainExpeditionLog",
                column: "ExpeditionId");

            migrationBuilder.CreateIndex(
                name: "IX_MountainExpeditionLog_GuideId",
                table: "MountainExpeditionLog",
                column: "GuideId");

            migrationBuilder.CreateIndex(
                name: "IX_MountainExpeditionLog_ItineraryTrackId",
                table: "MountainExpeditionLog",
                column: "ItineraryTrackId");

            migrationBuilder.CreateIndex(
                name: "IX_MountainExpeditionLog_MountainRouteId",
                table: "MountainExpeditionLog",
                column: "MountainRouteId");

            migrationBuilder.CreateIndex(
                name: "IX_MountainExpeditionLog_Name",
                table: "MountainExpeditionLog",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_MountainExpeditionLog_RouteTaken",
                table: "MountainExpeditionLog",
                column: "RouteTaken")
                .Annotation("Npgsql:IndexMethod", "GIST");

            migrationBuilder.CreateIndex(
                name: "IX_MountainExpeditionLog_Slug",
                table: "MountainExpeditionLog",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MountainExpeditionLog_Uid",
                table: "MountainExpeditionLog",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MountainExpeditionLog_UserId",
                table: "MountainExpeditionLog",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MountainFile_Location",
                table: "MountainFile",
                column: "Location")
                .Annotation("Npgsql:IndexMethod", "GIST");

            migrationBuilder.CreateIndex(
                name: "IX_MountainFile_MountainId",
                table: "MountainFile",
                column: "MountainId");

            migrationBuilder.CreateIndex(
                name: "IX_MountainFile_Slug",
                table: "MountainFile",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MountainFile_Uid",
                table: "MountainFile",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MountainRoute_DifficultyScaleId",
                table: "MountainRoute",
                column: "DifficultyScaleId");

            migrationBuilder.CreateIndex(
                name: "IX_MountainRoute_MountainId",
                table: "MountainRoute",
                column: "MountainId");

            migrationBuilder.CreateIndex(
                name: "IX_MountainRoute_Slug",
                table: "MountainRoute",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MountainRoute_Uid",
                table: "MountainRoute",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notification_Slug",
                table: "Notification",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Notification_TemplateId",
                table: "Notification",
                column: "TemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_Uid",
                table: "Notification",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NotificationLog_NotificationId",
                table: "NotificationLog",
                column: "NotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationLog_Slug",
                table: "NotificationLog",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NotificationLog_Uid",
                table: "NotificationLog",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NotificationPreference_Slug",
                table: "NotificationPreference",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NotificationPreference_Uid",
                table: "NotificationPreference",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NotificationPreference_UserId_Category",
                table: "NotificationPreference",
                columns: new[] { "UserId", "Category" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NotificationQueue_NotificationId",
                table: "NotificationQueue",
                column: "NotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationQueue_Slug",
                table: "NotificationQueue",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NotificationQueue_Uid",
                table: "NotificationQueue",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NotificationTemplate_Name",
                table: "NotificationTemplate",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NotificationTemplate_Slug",
                table: "NotificationTemplate",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_NotificationTemplate_Uid",
                table: "NotificationTemplate",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Organization_Slug",
                table: "Organization",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Organization_Uid",
                table: "Organization",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationCertification_OrganizationId",
                table: "OrganizationCertification",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationCertification_Slug",
                table: "OrganizationCertification",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationCertification_Uid",
                table: "OrganizationCertification",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationCertification_UserId",
                table: "OrganizationCertification",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationEvent_FacilityId",
                table: "OrganizationEvent",
                column: "FacilityId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationEvent_OrganizationId",
                table: "OrganizationEvent",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationEvent_Slug",
                table: "OrganizationEvent",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationEvent_Uid",
                table: "OrganizationEvent",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationEventParticipant_EventId_UserId",
                table: "OrganizationEventParticipant",
                columns: new[] { "EventId", "UserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationEventParticipant_Slug",
                table: "OrganizationEventParticipant",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationEventParticipant_Uid",
                table: "OrganizationEventParticipant",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationEventParticipant_UserId",
                table: "OrganizationEventParticipant",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationFacility_OrganizationId",
                table: "OrganizationFacility",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationFacility_Slug",
                table: "OrganizationFacility",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationFacility_Uid",
                table: "OrganizationFacility",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationFile_OrganizationId",
                table: "OrganizationFile",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationFile_Slug",
                table: "OrganizationFile",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationFile_Uid",
                table: "OrganizationFile",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationInstructor_OrganizationId_UserId",
                table: "OrganizationInstructor",
                columns: new[] { "OrganizationId", "UserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationInstructor_Slug",
                table: "OrganizationInstructor",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationInstructor_Uid",
                table: "OrganizationInstructor",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationInstructor_UserId",
                table: "OrganizationInstructor",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationMember_OrganizationId_UserId",
                table: "OrganizationMember",
                columns: new[] { "OrganizationId", "UserId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationMember_Slug",
                table: "OrganizationMember",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationMember_Uid",
                table: "OrganizationMember",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrganizationMember_UserId",
                table: "OrganizationMember",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_PaymentMethodId",
                table: "Payment",
                column: "PaymentMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_PayPerUseId",
                table: "Payment",
                column: "PayPerUseId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_Slug",
                table: "Payment",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Payment_SubscriptionId",
                table: "Payment",
                column: "SubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Payment_Uid",
                table: "Payment",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethod_Slug",
                table: "PaymentMethod",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentMethod_Uid",
                table: "PaymentMethod",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PayPerUse_Slug",
                table: "PayPerUse",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PayPerUse_Uid",
                table: "PayPerUse",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhysiologicalData_Slug",
                table: "PhysiologicalData",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PhysiologicalData_Uid",
                table: "PhysiologicalData",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Plan_Name",
                table: "Plan",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Plan_Slug",
                table: "Plan",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Plan_Uid",
                table: "Plan",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RockFeatures_ClimbRouteId",
                table: "RockFeatures",
                column: "ClimbRouteId");

            migrationBuilder.CreateIndex(
                name: "IX_RockFeatures_ClimbRouteId1",
                table: "RockFeatures",
                column: "ClimbRouteId1");

            migrationBuilder.CreateIndex(
                name: "IX_RockFeatures_Slug",
                table: "RockFeatures",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RockFeatures_Uid",
                table: "RockFeatures",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RouteFile_MountainRouteId",
                table: "RouteFile",
                column: "MountainRouteId");

            migrationBuilder.CreateIndex(
                name: "IX_RouteFile_Slug",
                table: "RouteFile",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RouteFile_Uid",
                table: "RouteFile",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RouteFile_UploadedBy",
                table: "RouteFile",
                column: "UploadedBy");

            migrationBuilder.CreateIndex(
                name: "IX_RouteTrack_MountainRouteId_Name",
                table: "RouteTrack",
                columns: new[] { "MountainRouteId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RouteTrack_Slug",
                table: "RouteTrack",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RouteTrack_TrackData",
                table: "RouteTrack",
                column: "TrackData")
                .Annotation("Npgsql:IndexMethod", "GIST");

            migrationBuilder.CreateIndex(
                name: "IX_RouteTrack_Uid",
                table: "RouteTrack",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RouteWaypoint_Location",
                table: "RouteWaypoint",
                column: "Location");

            migrationBuilder.CreateIndex(
                name: "IX_RouteWaypoint_MountainRouteId",
                table: "RouteWaypoint",
                column: "MountainRouteId");

            migrationBuilder.CreateIndex(
                name: "IX_RouteWaypoint_Name",
                table: "RouteWaypoint",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_RouteWaypoint_Slug",
                table: "RouteWaypoint",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RouteWaypoint_Uid",
                table: "RouteWaypoint",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RouteWaypoint_WaypointTypeId",
                table: "RouteWaypoint",
                column: "WaypointTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SafetyPlan_ExpeditionId",
                table: "SafetyPlan",
                column: "ExpeditionId");

            migrationBuilder.CreateIndex(
                name: "IX_SafetyPlan_Slug",
                table: "SafetyPlan",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SafetyPlan_Uid",
                table: "SafetyPlan",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SessionExercise_Slug",
                table: "SessionExercise",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SessionExercise_TrainingExerciseId",
                table: "SessionExercise",
                column: "TrainingExerciseId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionExercise_TrainingSessionId",
                table: "SessionExercise",
                column: "TrainingSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_SessionExercise_Uid",
                table: "SessionExercise",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subscription_PlanId",
                table: "Subscription",
                column: "PlanId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscription_Slug",
                table: "Subscription",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subscription_Uid",
                table: "Subscription",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SupportAgent_Slug",
                table: "SupportAgent",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SupportAgent_Uid",
                table: "SupportAgent",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SupportMetrics_Slug",
                table: "SupportMetrics",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SupportMetrics_Uid",
                table: "SupportMetrics",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SupportTicket_Slug",
                table: "SupportTicket",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SupportTicket_TicketNumber",
                table: "SupportTicket",
                column: "TicketNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SupportTicket_Uid",
                table: "SupportTicket",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TicketAttachment_Slug",
                table: "TicketAttachment",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TicketAttachment_TicketId",
                table: "TicketAttachment",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketAttachment_TicketMessageId",
                table: "TicketAttachment",
                column: "TicketMessageId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketAttachment_Uid",
                table: "TicketAttachment",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TicketMessage_Slug",
                table: "TicketMessage",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TicketMessage_TicketId",
                table: "TicketMessage",
                column: "TicketId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketMessage_Uid",
                table: "TicketMessage",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrainingExercise_Slug",
                table: "TrainingExercise",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrainingExercise_Uid",
                table: "TrainingExercise",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrainingGoal_Slug",
                table: "TrainingGoal",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrainingGoal_TrainingPlanId",
                table: "TrainingGoal",
                column: "TrainingPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingGoal_Uid",
                table: "TrainingGoal",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrainingPeriod_Slug",
                table: "TrainingPeriod",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrainingPeriod_TrainingPlanId",
                table: "TrainingPeriod",
                column: "TrainingPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingPeriod_Uid",
                table: "TrainingPeriod",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrainingPlan_BaselinePhysiologicalDataId",
                table: "TrainingPlan",
                column: "BaselinePhysiologicalDataId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingPlan_Slug",
                table: "TrainingPlan",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrainingPlan_Uid",
                table: "TrainingPlan",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrainingPlan_UserId",
                table: "TrainingPlan",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingProgress_Slug",
                table: "TrainingProgress",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrainingProgress_TrainingPlanId",
                table: "TrainingProgress",
                column: "TrainingPlanId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingProgress_Uid",
                table: "TrainingProgress",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrainingSession_Slug",
                table: "TrainingSession",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrainingSession_TrainingWeekId",
                table: "TrainingSession",
                column: "TrainingWeekId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingSession_Uid",
                table: "TrainingSession",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrainingSessionClimbing_Slug",
                table: "TrainingSessionClimbing",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrainingSessionClimbing_TrainingSessionId_UserSessionId",
                table: "TrainingSessionClimbing",
                columns: new[] { "TrainingSessionId", "UserSessionId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrainingSessionClimbing_Uid",
                table: "TrainingSessionClimbing",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrainingSessionClimbing_UserSessionId",
                table: "TrainingSessionClimbing",
                column: "UserSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingTemplate_Name",
                table: "TrainingTemplate",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrainingTemplate_Slug",
                table: "TrainingTemplate",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrainingTemplate_Uid",
                table: "TrainingTemplate",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrainingVolume_Slug",
                table: "TrainingVolume",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrainingVolume_TrainingWeekId",
                table: "TrainingVolume",
                column: "TrainingWeekId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrainingVolume_Uid",
                table: "TrainingVolume",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrainingWeek_Slug",
                table: "TrainingWeek",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TrainingWeek_TrainingPeriodId",
                table: "TrainingWeek",
                column: "TrainingPeriodId");

            migrationBuilder.CreateIndex(
                name: "IX_TrainingWeek_Uid",
                table: "TrainingWeek",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transportation_ExpeditionId",
                table: "Transportation",
                column: "ExpeditionId");

            migrationBuilder.CreateIndex(
                name: "IX_Transportation_ItineraryDayId",
                table: "Transportation",
                column: "ItineraryDayId");

            migrationBuilder.CreateIndex(
                name: "IX_Transportation_Slug",
                table: "Transportation",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Transportation_Uid",
                table: "Transportation",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserExperienceLevelScale_DifficultyScaleId",
                table: "UserExperienceLevelScale",
                column: "DifficultyScaleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserExperienceLevelScale_Slug",
                table: "UserExperienceLevelScale",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserExperienceLevelScale_Uid",
                table: "UserExperienceLevelScale",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserExperienceLevelScale_UserId_DifficultyScaleId",
                table: "UserExperienceLevelScale",
                columns: new[] { "UserId", "DifficultyScaleId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserHelpActivity_Slug",
                table: "UserHelpActivity",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserHelpActivity_Uid",
                table: "UserHelpActivity",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserSession_BoardId",
                table: "UserSession",
                column: "BoardId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSession_ClimbZoneId",
                table: "UserSession",
                column: "ClimbZoneId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSession_MountainRouteId",
                table: "UserSession",
                column: "MountainRouteId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSession_Slug",
                table: "UserSession",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserSession_Uid",
                table: "UserSession",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserSession_UserId",
                table: "UserSession",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSessionProgress_BoardAngleId",
                table: "UserSessionProgress",
                column: "BoardAngleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSessionProgress_BoardProblemId",
                table: "UserSessionProgress",
                column: "BoardProblemId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSessionProgress_ClimbRouteId",
                table: "UserSessionProgress",
                column: "ClimbRouteId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSessionProgress_FootRuleId",
                table: "UserSessionProgress",
                column: "FootRuleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSessionProgress_MountainRouteId",
                table: "UserSessionProgress",
                column: "MountainRouteId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSessionProgress_Slug",
                table: "UserSessionProgress",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserSessionProgress_Uid",
                table: "UserSessionProgress",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserSessionProgress_UserSessionId",
                table: "UserSessionProgress",
                column: "UserSessionId");

            migrationBuilder.CreateIndex(
                name: "IX_VersionDependency_ConfigurationVersionId",
                table: "VersionDependency",
                column: "ConfigurationVersionId");

            migrationBuilder.CreateIndex(
                name: "IX_VersionDependency_Slug",
                table: "VersionDependency",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VersionDependency_Uid",
                table: "VersionDependency",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WaypointType_Name",
                table: "WaypointType",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WaypointType_Slug",
                table: "WaypointType",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WaypointType_Uid",
                table: "WaypointType",
                column: "Uid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WeatherCondition_MountainId",
                table: "WeatherCondition",
                column: "MountainId");

            migrationBuilder.CreateIndex(
                name: "IX_WeatherCondition_Slug",
                table: "WeatherCondition",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_WeatherCondition_Uid",
                table: "WeatherCondition",
                column: "Uid",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accommodation");

            migrationBuilder.DropTable(
                name: "AIGenerationFeedback");

            migrationBuilder.DropTable(
                name: "AIGenerationHistory");

            migrationBuilder.DropTable(
                name: "AIGenerationTemplate");

            migrationBuilder.DropTable(
                name: "AIModelBenchmark");

            migrationBuilder.DropTable(
                name: "AIModelConfiguration");

            migrationBuilder.DropTable(
                name: "AIModelLog");

            migrationBuilder.DropTable(
                name: "AITrainingData");

            migrationBuilder.DropTable(
                name: "AITrainingSession");

            migrationBuilder.DropTable(
                name: "AuditTrail");

            migrationBuilder.DropTable(
                name: "BoardItemTextureCombination");

            migrationBuilder.DropTable(
                name: "BoardMember");

            migrationBuilder.DropTable(
                name: "BoardProblemAngle");

            migrationBuilder.DropTable(
                name: "BoardProblemBoardProblemTag");

            migrationBuilder.DropTable(
                name: "BoardProblemFootRule");

            migrationBuilder.DropTable(
                name: "BoardProblemItem");

            migrationBuilder.DropTable(
                name: "BoardSessionSummary");

            migrationBuilder.DropTable(
                name: "ChatMessage");

            migrationBuilder.DropTable(
                name: "ClimbRouteDescription");

            migrationBuilder.DropTable(
                name: "ClimbRouteFile");

            migrationBuilder.DropTable(
                name: "ClimbZoneFile");

            migrationBuilder.DropTable(
                name: "CommentAttachment");

            migrationBuilder.DropTable(
                name: "CommentMention");

            migrationBuilder.DropTable(
                name: "CommentReaction");

            migrationBuilder.DropTable(
                name: "CommentReport");

            migrationBuilder.DropTable(
                name: "Configuration");

            migrationBuilder.DropTable(
                name: "DayActivityDifficultyScale");

            migrationBuilder.DropTable(
                name: "EscalationRule");

            migrationBuilder.DropTable(
                name: "ExpeditionBudget");

            migrationBuilder.DropTable(
                name: "ExpeditionEquipment");

            migrationBuilder.DropTable(
                name: "ExpeditionLevelScales");

            migrationBuilder.DropTable(
                name: "ExpeditionParticipant");

            migrationBuilder.DropTable(
                name: "FAQ");

            migrationBuilder.DropTable(
                name: "FitnessTest");

            migrationBuilder.DropTable(
                name: "HelpArticleAttachment");

            migrationBuilder.DropTable(
                name: "HelpArticleVersion");

            migrationBuilder.DropTable(
                name: "HelpFeedback");

            migrationBuilder.DropTable(
                name: "HelpSearchLog");

            migrationBuilder.DropTable(
                name: "InvoiceItem");

            migrationBuilder.DropTable(
                name: "ItineraryDayTrackFile");

            migrationBuilder.DropTable(
                name: "ItineraryDayWaypointFile");

            migrationBuilder.DropTable(
                name: "ItineraryFile");

            migrationBuilder.DropTable(
                name: "ItineraryTrackFile");

            migrationBuilder.DropTable(
                name: "KnowledgeBase");

            migrationBuilder.DropTable(
                name: "Meal");

            migrationBuilder.DropTable(
                name: "MountainExpeditionLog");

            migrationBuilder.DropTable(
                name: "MountainFile");

            migrationBuilder.DropTable(
                name: "NotificationLog");

            migrationBuilder.DropTable(
                name: "NotificationPreference");

            migrationBuilder.DropTable(
                name: "NotificationQueue");

            migrationBuilder.DropTable(
                name: "OrganizationCertification");

            migrationBuilder.DropTable(
                name: "OrganizationEventParticipant");

            migrationBuilder.DropTable(
                name: "OrganizationFile");

            migrationBuilder.DropTable(
                name: "OrganizationInstructor");

            migrationBuilder.DropTable(
                name: "OrganizationMember");

            migrationBuilder.DropTable(
                name: "RockFeatures");

            migrationBuilder.DropTable(
                name: "RouteFile");

            migrationBuilder.DropTable(
                name: "RouteTrack");

            migrationBuilder.DropTable(
                name: "RouteWaypoint");

            migrationBuilder.DropTable(
                name: "SafetyPlan");

            migrationBuilder.DropTable(
                name: "SessionExercise");

            migrationBuilder.DropTable(
                name: "SupportAgent");

            migrationBuilder.DropTable(
                name: "SupportMetrics");

            migrationBuilder.DropTable(
                name: "TicketAttachment");

            migrationBuilder.DropTable(
                name: "TrainingGoal");

            migrationBuilder.DropTable(
                name: "TrainingProgress");

            migrationBuilder.DropTable(
                name: "TrainingSessionClimbing");

            migrationBuilder.DropTable(
                name: "TrainingTemplate");

            migrationBuilder.DropTable(
                name: "TrainingVolume");

            migrationBuilder.DropTable(
                name: "Transportation");

            migrationBuilder.DropTable(
                name: "UserExperienceLevelScale");

            migrationBuilder.DropTable(
                name: "UserHelpActivity");

            migrationBuilder.DropTable(
                name: "UserSessionProgress");

            migrationBuilder.DropTable(
                name: "VersionDependency");

            migrationBuilder.DropTable(
                name: "WeatherCondition");

            migrationBuilder.DropTable(
                name: "AIGenerationRequest");

            migrationBuilder.DropTable(
                name: "BoardItemTextureMaterial");

            migrationBuilder.DropTable(
                name: "BoardItemTexture");

            migrationBuilder.DropTable(
                name: "BoardProblemTag");

            migrationBuilder.DropTable(
                name: "BoardItem");

            migrationBuilder.DropTable(
                name: "BoardProblemItemType");

            migrationBuilder.DropTable(
                name: "LiveChatSession");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "DayActivity");

            migrationBuilder.DropTable(
                name: "ExpeditionBudgetCategory");

            migrationBuilder.DropTable(
                name: "Equipment");

            migrationBuilder.DropTable(
                name: "HelpArticle");

            migrationBuilder.DropTable(
                name: "Invoice");

            migrationBuilder.DropTable(
                name: "Payment");

            migrationBuilder.DropTable(
                name: "ItineraryDayWaypoint");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DropTable(
                name: "OrganizationEvent");

            migrationBuilder.DropTable(
                name: "TrainingExercise");

            migrationBuilder.DropTable(
                name: "TicketMessage");

            migrationBuilder.DropTable(
                name: "TrainingSession");

            migrationBuilder.DropTable(
                name: "BoardAngle");

            migrationBuilder.DropTable(
                name: "BoardProblem");

            migrationBuilder.DropTable(
                name: "ClimbRoute");

            migrationBuilder.DropTable(
                name: "FootRule");

            migrationBuilder.DropTable(
                name: "UserSession");

            migrationBuilder.DropTable(
                name: "ConfigurationVersion");

            migrationBuilder.DropTable(
                name: "AIModelVersion");

            migrationBuilder.DropTable(
                name: "BoardItemType");

            migrationBuilder.DropTable(
                name: "BoardItemVolume");

            migrationBuilder.DropTable(
                name: "Color");

            migrationBuilder.DropTable(
                name: "EquipmentCategory");

            migrationBuilder.DropTable(
                name: "HelpCategory");

            migrationBuilder.DropTable(
                name: "PayPerUse");

            migrationBuilder.DropTable(
                name: "PaymentMethod");

            migrationBuilder.DropTable(
                name: "Subscription");

            migrationBuilder.DropTable(
                name: "ItineraryDayTrack");

            migrationBuilder.DropTable(
                name: "WaypointType");

            migrationBuilder.DropTable(
                name: "NotificationTemplate");

            migrationBuilder.DropTable(
                name: "OrganizationFacility");

            migrationBuilder.DropTable(
                name: "SupportTicket");

            migrationBuilder.DropTable(
                name: "TrainingWeek");

            migrationBuilder.DropTable(
                name: "ClimbTag");

            migrationBuilder.DropTable(
                name: "Board");

            migrationBuilder.DropTable(
                name: "ClimbZone");

            migrationBuilder.DropTable(
                name: "AIModel");

            migrationBuilder.DropTable(
                name: "Plan");

            migrationBuilder.DropTable(
                name: "ItineraryDay");

            migrationBuilder.DropTable(
                name: "ItineraryTrack");

            migrationBuilder.DropTable(
                name: "TrainingPeriod");

            migrationBuilder.DropTable(
                name: "BoardConfig");

            migrationBuilder.DropTable(
                name: "Expedition");

            migrationBuilder.DropTable(
                name: "TrainingPlan");

            migrationBuilder.DropTable(
                name: "MountainRoute");

            migrationBuilder.DropTable(
                name: "Organization");

            migrationBuilder.DropTable(
                name: "PhysiologicalData");

            migrationBuilder.DropTable(
                name: "DifficultyScale");

            migrationBuilder.DropTable(
                name: "Mountain");

            migrationBuilder.DropTable(
                name: "DifficultyGroup");

            migrationBuilder.DropTable(
                name: "DifficultyScaleName");

            migrationBuilder.DropTable(
                name: "DifficultyScaleType");

            migrationBuilder.DropColumn(
                name: "Address_City",
                table: "UserProfile");

            migrationBuilder.DropColumn(
                name: "Address_State",
                table: "UserProfile");

            migrationBuilder.DropColumn(
                name: "Address_Street",
                table: "UserProfile");

            migrationBuilder.DropColumn(
                name: "Address_ZipCode",
                table: "UserProfile");

            migrationBuilder.RenameColumn(
                name: "Address_Country",
                table: "UserProfile",
                newName: "Country");

            migrationBuilder.RenameColumn(
                name: "Address_Reference",
                table: "UserProfile",
                newName: "Location");

            migrationBuilder.AlterDatabase()
                .OldAnnotation("Npgsql:PostgresExtension:postgis", ",,");

            migrationBuilder.CreateIndex(
                name: "IX_UserProfile_Country",
                table: "UserProfile",
                column: "Country");
        }
    }
}

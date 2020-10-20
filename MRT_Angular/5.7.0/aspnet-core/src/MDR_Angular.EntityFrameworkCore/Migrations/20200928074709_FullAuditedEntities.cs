using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace MDR_Angular.Migrations
{
    public partial class FullAuditedEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "WrittenOffStock",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "WrittenOffStock",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "WrittenOffStock",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "WrittenOffStock",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "WrittenOffStock",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "WrittenOffStock",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "WrittenOffStock",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "WriteOffReason",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "WriteOffReason",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "WriteOffReason",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "WriteOffReason",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "WriteOffReason",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "WriteOffReason",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "WriteOffReason",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "UserComment",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "UserComment",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "UserComment",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "UserComment",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "UserComment",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "UserComment",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "UserComment",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "SupplierOrderLine",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "SupplierOrderLine",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "SupplierOrderLine",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "SupplierOrderLine",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "SupplierOrderLine",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "SupplierOrderLine",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "SupplierOrderLine",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "SupplierOrder",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "SupplierOrder",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "SupplierOrder",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "SupplierOrder",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "SupplierOrder",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "SupplierOrder",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "SupplierOrder",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "Supplier",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "Supplier",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "Supplier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "Supplier",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Supplier",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "Supplier",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "Supplier",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "StockTake",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "StockTake",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "StockTake",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "StockTake",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "StockTake",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "StockTake",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "StockTake",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "StarRating",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "StarRating",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "StarRating",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "StarRating",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "StarRating",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "StarRating",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "StarRating",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "SpecialPrice",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "SpecialPrice",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "SpecialPrice",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "SpecialPrice",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "SpecialPrice",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "SpecialPrice",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "SpecialPrice",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "Special",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "Special",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "Special",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "Special",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Special",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "Special",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "Special",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "SocialMediaType",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "SocialMediaType",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "SocialMediaType",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "SocialMediaType",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "SocialMediaType",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "SocialMediaType",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "SocialMediaType",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "SocialMedia",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "SocialMedia",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "SocialMedia",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "SocialMedia",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "SocialMedia",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "SocialMedia",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "SocialMedia",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "ShiftStatus",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "ShiftStatus",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "ShiftStatus",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "ShiftStatus",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ShiftStatus",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "ShiftStatus",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "ShiftStatus",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "Shift",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "Shift",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "Shift",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "Shift",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Shift",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "Shift",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "Shift",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "SeatingLayout",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "SeatingLayout",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "SeatingLayout",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "SeatingLayout",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "SeatingLayout",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "SeatingLayout",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "SeatingLayout",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "Seating",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "Seating",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "Seating",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "Seating",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Seating",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "Seating",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "Seating",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "RestaurantTypeRef",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "RestaurantTypeRef",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "RestaurantTypeRef",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "RestaurantTypeRef",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "RestaurantTypeRef",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "RestaurantTypeRef",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "RestaurantTypeRef",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "RestaurantType",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "RestaurantType",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "RestaurantType",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "RestaurantType",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "RestaurantType",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "RestaurantType",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "RestaurantType",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "RestaurantStatus",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "RestaurantStatus",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "RestaurantStatus",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "RestaurantStatus",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "RestaurantStatus",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "RestaurantStatus",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "RestaurantStatus",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "RestaurantRestaurantImage",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "RestaurantRestaurantImage",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "RestaurantRestaurantImage",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "RestaurantRestaurantImage",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "RestaurantRestaurantImage",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "RestaurantRestaurantImage",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "RestaurantRestaurantImage",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "RestaurantImage",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "RestaurantImage",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "RestaurantImage",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "RestaurantImage",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "RestaurantImage",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "RestaurantImage",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "RestaurantImage",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "RestaurantFacilityRef",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "RestaurantFacilityRef",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "RestaurantFacilityRef",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "RestaurantFacilityRef",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "RestaurantFacilityRef",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "RestaurantFacilityRef",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "RestaurantFacilityRef",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "RestaurantFacility",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "RestaurantFacility",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "RestaurantFacility",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "RestaurantFacility",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "RestaurantFacility",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "RestaurantFacility",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "RestaurantFacility",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "RestaurantAdvertisement",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "RestaurantAdvertisement",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "RestaurantAdvertisement",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "RestaurantAdvertisement",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "RestaurantAdvertisement",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "RestaurantAdvertisement",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "RestaurantAdvertisement",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "Restaurant",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "Restaurant",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "Restaurant",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "Restaurant",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Restaurant",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "Restaurant",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "Restaurant",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "ReservationStatus",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "ReservationStatus",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "ReservationStatus",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "ReservationStatus",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ReservationStatus",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "ReservationStatus",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "ReservationStatus",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "ReservationRestaurant",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "ReservationRestaurant",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "ReservationRestaurant",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "ReservationRestaurant",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ReservationRestaurant",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "ReservationRestaurant",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "ReservationRestaurant",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "Reservation",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "Reservation",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "Reservation",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "Reservation",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Reservation",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "Reservation",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "Reservation",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "QrCodeSeating",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "QrCodeSeating",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "QrCodeSeating",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "QrCodeSeating",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "QrCodeSeating",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "QrCodeSeating",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "QrCodeSeating",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "QrCode",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "QrCode",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "QrCode",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "QrCode",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "QrCode",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "QrCode",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "QrCode",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "ProductWrittenOff",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "ProductWrittenOff",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "ProductWrittenOff",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "ProductWrittenOff",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ProductWrittenOff",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "ProductWrittenOff",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "ProductWrittenOff",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "ProductType",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "ProductType",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "ProductType",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "ProductType",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ProductType",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "ProductType",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "ProductType",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "ProductStockTake",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "ProductStockTake",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "ProductStockTake",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "ProductStockTake",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ProductStockTake",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "ProductStockTake",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "ProductStockTake",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "ProductReorderFreq",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "ProductReorderFreq",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "ProductReorderFreq",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "ProductReorderFreq",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ProductReorderFreq",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "ProductReorderFreq",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "ProductReorderFreq",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "ProductCategory",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "ProductCategory",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "ProductCategory",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "ProductCategory",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ProductCategory",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "ProductCategory",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "ProductCategory",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "Product",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "Product",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "Product",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "Product",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Product",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "Product",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "Product",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "OrderStatus",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "OrderStatus",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "OrderStatus",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "OrderStatus",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "OrderStatus",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "OrderStatus",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "OrderStatus",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "OrderLine",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "OrderLine",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "OrderLine",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "OrderLine",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "OrderLine",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "OrderLine",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "OrderLine",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "Order",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "Order",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "Order",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "Order",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Order",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "Order",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "Order",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "MenuRestaurant",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "MenuRestaurant",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "MenuRestaurant",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "MenuRestaurant",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "MenuRestaurant",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "MenuRestaurant",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "MenuRestaurant",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "MenuItemType",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "MenuItemType",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "MenuItemType",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "MenuItemType",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "MenuItemType",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "MenuItemType",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "MenuItemType",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "MenuItemSpecial",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "MenuItemSpecial",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "MenuItemSpecial",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "MenuItemSpecial",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "MenuItemSpecial",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "MenuItemSpecial",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "MenuItemSpecial",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "MenuItemPrice",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "MenuItemPrice",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "MenuItemPrice",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "MenuItemPrice",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "MenuItemPrice",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "MenuItemPrice",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "MenuItemPrice",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "MenuItemCategory",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "MenuItemCategory",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "MenuItemCategory",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "MenuItemCategory",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "MenuItemCategory",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "MenuItemCategory",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "MenuItemCategory",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "MenuItemAllergy",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "MenuItemAllergy",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "MenuItemAllergy",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "MenuItemAllergy",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "MenuItemAllergy",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "MenuItemAllergy",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "MenuItemAllergy",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "MenuItem",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "MenuItem",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "MenuItem",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "MenuItem",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "MenuItem",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "MenuItem",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "MenuItem",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "Menu",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "Menu",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "Menu",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "Menu",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Menu",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "Menu",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "Menu",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "LayoutType",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "LayoutType",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "LayoutType",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "LayoutType",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "LayoutType",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "LayoutType",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "LayoutType",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "ItemTypeMenuItem",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "ItemTypeMenuItem",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "ItemTypeMenuItem",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "ItemTypeMenuItem",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "ItemTypeMenuItem",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "ItemTypeMenuItem",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "ItemTypeMenuItem",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "EmployeeShift",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "EmployeeShift",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "EmployeeShift",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "EmployeeShift",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "EmployeeShift",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "EmployeeShift",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "EmployeeShift",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "Employee",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "Employee",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "Employee",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "Employee",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Employee",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "Employee",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "Employee",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "AttendanceSheet",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "AttendanceSheet",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "AttendanceSheet",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "AttendanceSheet",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AttendanceSheet",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "AttendanceSheet",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "AttendanceSheet",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "Allergy",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "Allergy",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "Allergy",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "Allergy",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Allergy",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "Allergy",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "Allergy",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "AdvertisementPrice",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "AdvertisementPrice",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "AdvertisementPrice",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "AdvertisementPrice",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AdvertisementPrice",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "AdvertisementPrice",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "AdvertisementPrice",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "AdvertisementDate",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "AdvertisementDate",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "AdvertisementDate",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "AdvertisementDate",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "AdvertisementDate",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "AdvertisementDate",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "AdvertisementDate",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreationTime",
                table: "Advertisement",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "CreatorUserId",
                table: "Advertisement",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "DeleterUserId",
                table: "Advertisement",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletionTime",
                table: "Advertisement",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Advertisement",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModificationTime",
                table: "Advertisement",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "LastModifierUserId",
                table: "Advertisement",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "WrittenOffStock");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "WrittenOffStock");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "WrittenOffStock");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "WrittenOffStock");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "WrittenOffStock");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "WrittenOffStock");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "WrittenOffStock");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "WriteOffReason");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "WriteOffReason");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "WriteOffReason");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "WriteOffReason");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "WriteOffReason");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "WriteOffReason");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "WriteOffReason");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "UserComment");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "UserComment");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "UserComment");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "UserComment");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "UserComment");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "UserComment");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "UserComment");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "SupplierOrderLine");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "SupplierOrderLine");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "SupplierOrderLine");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "SupplierOrderLine");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "SupplierOrderLine");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "SupplierOrderLine");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "SupplierOrderLine");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "SupplierOrder");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "SupplierOrder");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "SupplierOrder");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "SupplierOrder");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "SupplierOrder");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "SupplierOrder");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "SupplierOrder");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "Supplier");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "StockTake");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "StockTake");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "StockTake");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "StockTake");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "StockTake");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "StockTake");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "StockTake");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "StarRating");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "StarRating");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "StarRating");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "StarRating");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "StarRating");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "StarRating");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "StarRating");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "SpecialPrice");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "SpecialPrice");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "SpecialPrice");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "SpecialPrice");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "SpecialPrice");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "SpecialPrice");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "SpecialPrice");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "Special");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "Special");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "Special");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "Special");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Special");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "Special");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "Special");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "SocialMediaType");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "SocialMediaType");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "SocialMediaType");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "SocialMediaType");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "SocialMediaType");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "SocialMediaType");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "SocialMediaType");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "SocialMedia");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "SocialMedia");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "SocialMedia");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "SocialMedia");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "SocialMedia");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "SocialMedia");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "SocialMedia");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "ShiftStatus");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "ShiftStatus");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "ShiftStatus");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "ShiftStatus");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ShiftStatus");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "ShiftStatus");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "ShiftStatus");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "Shift");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "Shift");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "Shift");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "Shift");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Shift");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "Shift");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "Shift");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "SeatingLayout");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "SeatingLayout");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "SeatingLayout");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "SeatingLayout");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "SeatingLayout");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "SeatingLayout");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "SeatingLayout");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "Seating");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "Seating");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "Seating");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "Seating");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Seating");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "Seating");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "Seating");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "RestaurantTypeRef");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "RestaurantTypeRef");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "RestaurantTypeRef");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "RestaurantTypeRef");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "RestaurantTypeRef");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "RestaurantTypeRef");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "RestaurantTypeRef");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "RestaurantType");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "RestaurantType");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "RestaurantType");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "RestaurantType");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "RestaurantType");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "RestaurantType");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "RestaurantType");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "RestaurantStatus");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "RestaurantStatus");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "RestaurantStatus");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "RestaurantStatus");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "RestaurantStatus");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "RestaurantStatus");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "RestaurantStatus");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "RestaurantRestaurantImage");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "RestaurantRestaurantImage");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "RestaurantRestaurantImage");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "RestaurantRestaurantImage");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "RestaurantRestaurantImage");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "RestaurantRestaurantImage");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "RestaurantRestaurantImage");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "RestaurantImage");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "RestaurantImage");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "RestaurantImage");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "RestaurantImage");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "RestaurantImage");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "RestaurantImage");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "RestaurantImage");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "RestaurantFacilityRef");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "RestaurantFacilityRef");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "RestaurantFacilityRef");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "RestaurantFacilityRef");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "RestaurantFacilityRef");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "RestaurantFacilityRef");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "RestaurantFacilityRef");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "RestaurantFacility");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "RestaurantFacility");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "RestaurantFacility");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "RestaurantFacility");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "RestaurantFacility");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "RestaurantFacility");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "RestaurantFacility");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "RestaurantAdvertisement");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "RestaurantAdvertisement");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "RestaurantAdvertisement");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "RestaurantAdvertisement");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "RestaurantAdvertisement");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "RestaurantAdvertisement");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "RestaurantAdvertisement");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "Restaurant");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "Restaurant");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "Restaurant");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "Restaurant");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Restaurant");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "Restaurant");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "Restaurant");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "ReservationStatus");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "ReservationStatus");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "ReservationStatus");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "ReservationStatus");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ReservationStatus");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "ReservationStatus");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "ReservationStatus");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "ReservationRestaurant");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "ReservationRestaurant");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "ReservationRestaurant");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "ReservationRestaurant");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ReservationRestaurant");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "ReservationRestaurant");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "ReservationRestaurant");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "Reservation");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "QrCodeSeating");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "QrCodeSeating");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "QrCodeSeating");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "QrCodeSeating");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "QrCodeSeating");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "QrCodeSeating");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "QrCodeSeating");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "QrCode");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "QrCode");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "QrCode");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "QrCode");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "QrCode");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "QrCode");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "QrCode");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "ProductWrittenOff");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "ProductWrittenOff");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "ProductWrittenOff");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "ProductWrittenOff");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ProductWrittenOff");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "ProductWrittenOff");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "ProductWrittenOff");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "ProductType");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "ProductType");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "ProductType");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "ProductType");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ProductType");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "ProductType");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "ProductType");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "ProductStockTake");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "ProductStockTake");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "ProductStockTake");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "ProductStockTake");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ProductStockTake");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "ProductStockTake");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "ProductStockTake");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "ProductReorderFreq");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "ProductReorderFreq");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "ProductReorderFreq");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "ProductReorderFreq");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ProductReorderFreq");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "ProductReorderFreq");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "ProductReorderFreq");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "ProductCategory");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "ProductCategory");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "ProductCategory");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "ProductCategory");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ProductCategory");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "ProductCategory");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "ProductCategory");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "OrderStatus");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "OrderStatus");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "OrderStatus");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "OrderStatus");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "OrderStatus");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "OrderStatus");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "OrderStatus");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "OrderLine");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "OrderLine");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "OrderLine");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "OrderLine");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "OrderLine");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "OrderLine");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "OrderLine");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "MenuRestaurant");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "MenuRestaurant");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "MenuRestaurant");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "MenuRestaurant");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "MenuRestaurant");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "MenuRestaurant");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "MenuRestaurant");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "MenuItemType");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "MenuItemType");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "MenuItemType");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "MenuItemType");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "MenuItemType");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "MenuItemType");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "MenuItemType");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "MenuItemSpecial");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "MenuItemSpecial");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "MenuItemSpecial");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "MenuItemSpecial");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "MenuItemSpecial");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "MenuItemSpecial");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "MenuItemSpecial");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "MenuItemPrice");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "MenuItemPrice");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "MenuItemPrice");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "MenuItemPrice");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "MenuItemPrice");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "MenuItemPrice");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "MenuItemPrice");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "MenuItemCategory");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "MenuItemCategory");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "MenuItemCategory");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "MenuItemCategory");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "MenuItemCategory");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "MenuItemCategory");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "MenuItemCategory");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "MenuItemAllergy");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "MenuItemAllergy");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "MenuItemAllergy");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "MenuItemAllergy");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "MenuItemAllergy");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "MenuItemAllergy");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "MenuItemAllergy");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "MenuItem");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "MenuItem");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "MenuItem");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "MenuItem");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "MenuItem");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "MenuItem");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "MenuItem");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "Menu");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "LayoutType");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "LayoutType");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "LayoutType");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "LayoutType");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "LayoutType");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "LayoutType");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "LayoutType");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "ItemTypeMenuItem");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "ItemTypeMenuItem");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "ItemTypeMenuItem");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "ItemTypeMenuItem");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "ItemTypeMenuItem");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "ItemTypeMenuItem");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "ItemTypeMenuItem");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "EmployeeShift");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "EmployeeShift");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "EmployeeShift");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "EmployeeShift");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "EmployeeShift");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "EmployeeShift");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "EmployeeShift");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "Employee");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "AttendanceSheet");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "AttendanceSheet");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "AttendanceSheet");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "AttendanceSheet");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AttendanceSheet");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "AttendanceSheet");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "AttendanceSheet");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "Allergy");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "Allergy");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "Allergy");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "Allergy");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Allergy");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "Allergy");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "Allergy");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "AdvertisementPrice");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "AdvertisementPrice");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "AdvertisementPrice");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "AdvertisementPrice");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AdvertisementPrice");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "AdvertisementPrice");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "AdvertisementPrice");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "AdvertisementDate");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "AdvertisementDate");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "AdvertisementDate");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "AdvertisementDate");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "AdvertisementDate");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "AdvertisementDate");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "AdvertisementDate");

            migrationBuilder.DropColumn(
                name: "CreationTime",
                table: "Advertisement");

            migrationBuilder.DropColumn(
                name: "CreatorUserId",
                table: "Advertisement");

            migrationBuilder.DropColumn(
                name: "DeleterUserId",
                table: "Advertisement");

            migrationBuilder.DropColumn(
                name: "DeletionTime",
                table: "Advertisement");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Advertisement");

            migrationBuilder.DropColumn(
                name: "LastModificationTime",
                table: "Advertisement");

            migrationBuilder.DropColumn(
                name: "LastModifierUserId",
                table: "Advertisement");
        }
    }
}

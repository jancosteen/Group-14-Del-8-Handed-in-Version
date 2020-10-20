using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace MDR_Angular.Migrations
{
    public partial class OrderMateEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdvertisementDate",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdvertisementDateAcvtiveFrom = table.Column<DateTime>(nullable: false),
                    AdvertisementDateActiveTo = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvertisementDate", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AdvertisementPrice",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdvertismentPrice = table.Column<double>(nullable: false),
                    AdvertisementPriceDateUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvertisementPrice", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Allergy",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Allergy1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Allergy", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LayoutType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LayoutType1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LayoutType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menu",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuName = table.Column<string>(nullable: true),
                    MenuDescription = table.Column<string>(nullable: true),
                    MenuDateCreated = table.Column<DateTime>(nullable: false),
                    MenuTimeActiveFrom = table.Column<TimeSpan>(nullable: true),
                    MenuTimeActiveTo = table.Column<TimeSpan>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menu", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MenuItemCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuItemCategory1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItemCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MenuItemPrice",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuItemPrice1 = table.Column<double>(nullable: false),
                    MenuItemDateUpdated = table.Column<DateTime>(nullable: false),
                    MenuItemPriceStatus = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItemPrice", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MenuItemType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuItemType1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItemType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderStatus1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductCategory",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductCategory1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductReorderFreq",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductReorderFreq1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductReorderFreq", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductType1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ReservationStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservationStatus1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantFacility",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RestaurantFacility1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantFacility", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RestaurantStatus1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RestaurantType1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShiftStatus",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShiftStatus1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShiftStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SocialMediaType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SocialMediaType1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialMediaType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Special",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecialStartDate = table.Column<DateTime>(nullable: false),
                    SpecialEndDate = table.Column<DateTime>(nullable: false),
                    SpecialName = table.Column<string>(nullable: true),
                    SpecialDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Special", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StarRating",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StarRatingValue = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StarRating", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StockTake",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StockTakeDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockTake", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Supplier",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierName = table.Column<string>(nullable: true),
                    SupplierDescription = table.Column<string>(nullable: true),
                    SupplierEmail = table.Column<string>(nullable: true),
                    SupplierContactNumber = table.Column<string>(nullable: true),
                    SupplierAddressLine1 = table.Column<string>(nullable: true),
                    SupplierAddressLine2 = table.Column<string>(nullable: true),
                    SupplierAddressLine3 = table.Column<string>(nullable: true),
                    SupplierCity = table.Column<string>(nullable: true),
                    SupplierPostalCode = table.Column<string>(nullable: true),
                    SupplierCountry = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supplier", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WrittenOffStock",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WrittenOfStockDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WrittenOffStock", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Advertisement",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdvertisementName = table.Column<string>(nullable: true),
                    AdvertisementDescription = table.Column<string>(nullable: true),
                    AdvertisementFile = table.Column<byte[]>(nullable: true),
                    AdvertisementDateIdFk = table.Column<int>(nullable: true),
                    AdvertisementPriceIdFk = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Advertisement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Advertisement_AdvertisementDate_AdvertisementDateIdFk",
                        column: x => x.AdvertisementDateIdFk,
                        principalTable: "AdvertisementDate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Advertisement_AdvertisementPrice_AdvertisementPriceIdFk",
                        column: x => x.AdvertisementPriceIdFk,
                        principalTable: "AdvertisementPrice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MenuItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuItemName = table.Column<string>(nullable: true),
                    MenuItemDescription = table.Column<string>(nullable: true),
                    MenuItemCategoryIdFk = table.Column<int>(nullable: true),
                    MenuItemPriceIdFk = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuItem_MenuItemCategory_MenuItemCategoryIdFk",
                        column: x => x.MenuItemCategoryIdFk,
                        principalTable: "MenuItemCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MenuItem_MenuItemPrice_MenuItemPriceIdFk",
                        column: x => x.MenuItemPriceIdFk,
                        principalTable: "MenuItemPrice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(nullable: true),
                    ProductDescription = table.Column<string>(nullable: true),
                    ProductReorderLevel = table.Column<int>(nullable: false),
                    ProductOnHand = table.Column<int>(nullable: false),
                    ProductTypeIdFk = table.Column<int>(nullable: true),
                    ProductCategoryIdFk = table.Column<int>(nullable: true),
                    ProductReorderFreqIdFk = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Product_ProductCategory_ProductCategoryIdFk",
                        column: x => x.ProductCategoryIdFk,
                        principalTable: "ProductCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_ProductReorderFreq_ProductReorderFreqIdFk",
                        column: x => x.ProductReorderFreqIdFk,
                        principalTable: "ProductReorderFreq",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Product_ProductType_ProductTypeIdFk",
                        column: x => x.ProductTypeIdFk,
                        principalTable: "ProductType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reservation",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservationDateCreated = table.Column<DateTime>(nullable: false),
                    ReservationDateReserved = table.Column<DateTime>(nullable: false),
                    ReservationPartyQty = table.Column<int>(nullable: false),
                    UserIdFk = table.Column<long>(nullable: false),
                    ReservationStatusIdFk = table.Column<int>(nullable: true),
                    ReservationNumberOfBills = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservation_ReservationStatus_ReservationStatusIdFk",
                        column: x => x.ReservationStatusIdFk,
                        principalTable: "ReservationStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservation_AbpUsers_UserIdFk",
                        column: x => x.UserIdFk,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Restaurant",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RestaurantName = table.Column<string>(nullable: true),
                    RestaurantUrl = table.Column<string>(nullable: true),
                    RestaurantDescription = table.Column<string>(nullable: true),
                    RestaurantDateCreated = table.Column<DateTime>(nullable: true),
                    RestaurantAddressLine1 = table.Column<string>(nullable: true),
                    ResaturantAddressLine2 = table.Column<string>(nullable: true),
                    RestaurantCity = table.Column<string>(nullable: true),
                    RestaurantPostalCode = table.Column<string>(nullable: true),
                    RestaurantProvince = table.Column<string>(nullable: true),
                    RestaurantCountry = table.Column<string>(nullable: true),
                    RestaurantStatusIdFk = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Restaurant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Restaurant_RestaurantStatus_RestaurantStatusIdFk",
                        column: x => x.RestaurantStatusIdFk,
                        principalTable: "RestaurantStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Shift",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShiftStartDateTime = table.Column<DateTime>(nullable: false),
                    ShiftEndDateTime = table.Column<DateTime>(nullable: false),
                    ShiftCapacity = table.Column<int>(nullable: false),
                    ShiftName = table.Column<string>(nullable: true),
                    ShiftStatusIdFk = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shift", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Shift_ShiftStatus_ShiftStatusIdFk",
                        column: x => x.ShiftStatusIdFk,
                        principalTable: "ShiftStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SocialMedia",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SocialMediaTypeIdFk = table.Column<int>(nullable: false),
                    SocialMediaAddress = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialMedia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SocialMedia_SocialMediaType_SocialMediaTypeIdFk",
                        column: x => x.SocialMediaTypeIdFk,
                        principalTable: "SocialMediaType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpecialPrice",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecialPrice1 = table.Column<double>(nullable: false),
                    SpecialPriceDateUpdated = table.Column<DateTime>(nullable: false),
                    SpecialIdFk = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialPrice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecialPrice_Special_SpecialIdFk",
                        column: x => x.SpecialIdFk,
                        principalTable: "Special",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SupplierOrder",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupplierOrderDate = table.Column<DateTime>(nullable: false),
                    SupplierIdFk = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupplierOrder_Supplier_SupplierIdFk",
                        column: x => x.SupplierIdFk,
                        principalTable: "Supplier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ItemTypeMenuItem",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuItemIdFk = table.Column<int>(nullable: false),
                    MenuItemTypeIdFk = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ItemTypeMenuItem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ItemTypeMenuItem_MenuItem_MenuItemIdFk",
                        column: x => x.MenuItemIdFk,
                        principalTable: "MenuItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ItemTypeMenuItem_MenuItemType_MenuItemTypeIdFk",
                        column: x => x.MenuItemTypeIdFk,
                        principalTable: "MenuItemType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuItemAllergy",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuItemIdFk = table.Column<int>(nullable: false),
                    AllergyIdFk = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItemAllergy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuItemAllergy_Allergy_AllergyIdFk",
                        column: x => x.AllergyIdFk,
                        principalTable: "Allergy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuItemAllergy_MenuItem_MenuItemIdFk",
                        column: x => x.MenuItemIdFk,
                        principalTable: "MenuItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuItemSpecial",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecialIdFk = table.Column<int>(nullable: false),
                    MenuItemIdFk = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuItemSpecial", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuItemSpecial_MenuItem_MenuItemIdFk",
                        column: x => x.MenuItemIdFk,
                        principalTable: "MenuItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuItemSpecial_Special_SpecialIdFk",
                        column: x => x.SpecialIdFk,
                        principalTable: "Special",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seating",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeatingDate = table.Column<DateTime>(nullable: false),
                    SeatingTime = table.Column<TimeSpan>(nullable: false),
                    ReservationIdFk = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seating", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seating_Reservation_ReservationIdFk",
                        column: x => x.ReservationIdFk,
                        principalTable: "Reservation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeIdNumber = table.Column<string>(nullable: true),
                    RestaurantIdFk = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_Restaurant_RestaurantIdFk",
                        column: x => x.RestaurantIdFk,
                        principalTable: "Restaurant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MenuRestaurant",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MenuIdFk = table.Column<int>(nullable: false),
                    RestaurantIdFk = table.Column<int>(nullable: false),
                    MenuItemIdFk = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuRestaurant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuRestaurant_Menu_MenuIdFk",
                        column: x => x.MenuIdFk,
                        principalTable: "Menu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuRestaurant_MenuItem_MenuItemIdFk",
                        column: x => x.MenuItemIdFk,
                        principalTable: "MenuItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MenuRestaurant_Restaurant_RestaurantIdFk",
                        column: x => x.RestaurantIdFk,
                        principalTable: "Restaurant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QrCode",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RestaurantIdFk = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QrCode", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QrCode_Restaurant_RestaurantIdFk",
                        column: x => x.RestaurantIdFk,
                        principalTable: "Restaurant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ReservationRestaurant",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReservationIdFk = table.Column<int>(nullable: false),
                    RestaurantIdFk = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationRestaurant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReservationRestaurant_Reservation_ReservationIdFk",
                        column: x => x.ReservationIdFk,
                        principalTable: "Reservation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ReservationRestaurant_Restaurant_RestaurantIdFk",
                        column: x => x.RestaurantIdFk,
                        principalTable: "Restaurant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantAdvertisement",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RestaurantIdFk = table.Column<int>(nullable: false),
                    AdvertisementIdFk = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantAdvertisement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RestaurantAdvertisement_Advertisement_AdvertisementIdFk",
                        column: x => x.AdvertisementIdFk,
                        principalTable: "Advertisement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RestaurantAdvertisement_Restaurant_RestaurantIdFk",
                        column: x => x.RestaurantIdFk,
                        principalTable: "Restaurant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantFacilityRef",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RestaurantFacilityIdFk = table.Column<int>(nullable: false),
                    RestaurantIdFk = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantFacilityRef", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RestaurantFacilityRef_RestaurantFacility_RestaurantFacilityIdFk",
                        column: x => x.RestaurantFacilityIdFk,
                        principalTable: "RestaurantFacility",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RestaurantFacilityRef_Restaurant_RestaurantIdFk",
                        column: x => x.RestaurantIdFk,
                        principalTable: "Restaurant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantImage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageDescription = table.Column<string>(nullable: true),
                    ImageFile = table.Column<byte[]>(nullable: true),
                    RestaurantIdFk = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RestaurantImage_Restaurant_RestaurantIdFk",
                        column: x => x.RestaurantIdFk,
                        principalTable: "Restaurant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantTypeRef",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RestaurantTypeIdFk = table.Column<int>(nullable: false),
                    RestaurantIdFk = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantTypeRef", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RestaurantTypeRef_Restaurant_RestaurantIdFk",
                        column: x => x.RestaurantIdFk,
                        principalTable: "Restaurant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RestaurantTypeRef_RestaurantType_RestaurantTypeIdFk",
                        column: x => x.RestaurantTypeIdFk,
                        principalTable: "RestaurantType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SeatingLayout",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RestaurantIdFk = table.Column<int>(nullable: false),
                    LayoutTypeIdFk = table.Column<int>(nullable: false),
                    SeatingLayoutQty = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeatingLayout", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SeatingLayout_LayoutType_LayoutTypeIdFk",
                        column: x => x.LayoutTypeIdFk,
                        principalTable: "LayoutType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SeatingLayout_Restaurant_RestaurantIdFk",
                        column: x => x.RestaurantIdFk,
                        principalTable: "Restaurant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserComment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserComment1 = table.Column<string>(nullable: true),
                    UserCommentDateCreated = table.Column<DateTime>(nullable: false),
                    RestaurantIdFk = table.Column<int>(nullable: true),
                    StarRatingIdFk = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserComment_Restaurant_RestaurantIdFk",
                        column: x => x.RestaurantIdFk,
                        principalTable: "Restaurant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserComment_StarRating_StarRatingIdFk",
                        column: x => x.StarRatingIdFk,
                        principalTable: "StarRating",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SupplierOrderLine",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductIdFk = table.Column<int>(nullable: false),
                    SupplierOrderIdFk = table.Column<int>(nullable: false),
                    DeliveryLeadTime = table.Column<int>(nullable: false),
                    ProductStandardPrice = table.Column<double>(nullable: false),
                    DiscountAgreement = table.Column<double>(nullable: false),
                    OrderedQty = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupplierOrderLine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupplierOrderLine_Product_ProductIdFk",
                        column: x => x.ProductIdFk,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SupplierOrderLine_SupplierOrder_SupplierOrderIdFk",
                        column: x => x.SupplierOrderIdFk,
                        principalTable: "SupplierOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AttendanceSheet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClockInDateTime = table.Column<DateTime>(nullable: false),
                    ClockOutDateTime = table.Column<DateTime>(nullable: false),
                    EmployeeIdFk = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AttendanceSheet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AttendanceSheet_Employee_EmployeeIdFk",
                        column: x => x.EmployeeIdFk,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeShift",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ShiftIdFk = table.Column<int>(nullable: false),
                    EmployeeIdFk = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeShift", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeShift_Employee_EmployeeIdFk",
                        column: x => x.EmployeeIdFk,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeShift_Shift_ShiftIdFk",
                        column: x => x.ShiftIdFk,
                        principalTable: "Shift",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductStockTake",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeIdFk = table.Column<int>(nullable: true),
                    ProductIdFk = table.Column<int>(nullable: false),
                    ProductStockTakeQty = table.Column<int>(nullable: false),
                    StockTakeIdFk = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductStockTake", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductStockTake_Employee_EmployeeIdFk",
                        column: x => x.EmployeeIdFk,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductStockTake_Product_ProductIdFk",
                        column: x => x.ProductIdFk,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductStockTake_StockTake_StockTakeIdFk",
                        column: x => x.StockTakeIdFk,
                        principalTable: "StockTake",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductWrittenOff",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductIdFk = table.Column<int>(nullable: false),
                    WrittenOffQty = table.Column<int>(nullable: false),
                    EmployeeIdFk = table.Column<int>(nullable: true),
                    WrittenOffStockIdFk = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductWrittenOff", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductWrittenOff_Employee_EmployeeIdFk",
                        column: x => x.EmployeeIdFk,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductWrittenOff_Product_ProductIdFk",
                        column: x => x.ProductIdFk,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductWrittenOff_WrittenOffStock_WrittenOffStockIdFk",
                        column: x => x.WrittenOffStockIdFk,
                        principalTable: "WrittenOffStock",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RestaurantRestaurantImage",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RestaurantIdFk = table.Column<int>(nullable: false),
                    RestaurantImageIdFk = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RestaurantRestaurantImage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RestaurantRestaurantImage_Restaurant_RestaurantIdFk",
                        column: x => x.RestaurantIdFk,
                        principalTable: "Restaurant",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RestaurantRestaurantImage_RestaurantImage_RestaurantImageIdFk",
                        column: x => x.RestaurantImageIdFk,
                        principalTable: "RestaurantImage",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WriteOffReason",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WrittenOffStockIdFkFk = table.Column<int>(nullable: false),
                    ProductIdFkFk = table.Column<int>(nullable: false),
                    WriteOffReason1 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WriteOffReason", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WriteOffReason_ProductWrittenOff_WrittenOffStockIdFkFk",
                        column: x => x.WrittenOffStockIdFkFk,
                        principalTable: "ProductWrittenOff",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderLine",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ItemQty = table.Column<int>(nullable: false),
                    ItemComments = table.Column<string>(nullable: true),
                    SpecialIdFk = table.Column<int>(nullable: true),
                    MenuItemIdFk = table.Column<int>(nullable: true),
                    OrderIdFk = table.Column<int>(nullable: true),
                    UserIdFk = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderLine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderLine_MenuItem_MenuItemIdFk",
                        column: x => x.MenuItemIdFk,
                        principalTable: "MenuItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderLine_Special_SpecialIdFk",
                        column: x => x.SpecialIdFk,
                        principalTable: "Special",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrderLine_AbpUsers_UserIdFk",
                        column: x => x.UserIdFk,
                        principalTable: "AbpUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QrCodeSeating",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NrOfPeople = table.Column<int>(nullable: false),
                    QrCodeIdFk = table.Column<int>(nullable: false),
                    SeatingIdFk = table.Column<int>(nullable: false),
                    OrderIdFk = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QrCodeSeating", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QrCodeSeating_QrCode_QrCodeIdFk",
                        column: x => x.QrCodeIdFk,
                        principalTable: "QrCode",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QrCodeSeating_Seating_SeatingIdFk",
                        column: x => x.SeatingIdFk,
                        principalTable: "Seating",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderDateCreated = table.Column<DateTime>(nullable: false),
                    OrderDateCompleted = table.Column<DateTime>(nullable: true),
                    QrCodeSeatingIdFk = table.Column<int>(nullable: true),
                    OrderStatusIdFk = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_OrderStatus_OrderStatusIdFk",
                        column: x => x.OrderStatusIdFk,
                        principalTable: "OrderStatus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Order_QrCodeSeating_QrCodeSeatingIdFk",
                        column: x => x.QrCodeSeatingIdFk,
                        principalTable: "QrCodeSeating",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Advertisement_AdvertisementDateIdFk",
                table: "Advertisement",
                column: "AdvertisementDateIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_Advertisement_AdvertisementPriceIdFk",
                table: "Advertisement",
                column: "AdvertisementPriceIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_AttendanceSheet_EmployeeIdFk",
                table: "AttendanceSheet",
                column: "EmployeeIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_RestaurantIdFk",
                table: "Employee",
                column: "RestaurantIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeShift_EmployeeIdFk",
                table: "EmployeeShift",
                column: "EmployeeIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeShift_ShiftIdFk",
                table: "EmployeeShift",
                column: "ShiftIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_ItemTypeMenuItem_MenuItemIdFk",
                table: "ItemTypeMenuItem",
                column: "MenuItemIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_ItemTypeMenuItem_MenuItemTypeIdFk",
                table: "ItemTypeMenuItem",
                column: "MenuItemTypeIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItem_MenuItemCategoryIdFk",
                table: "MenuItem",
                column: "MenuItemCategoryIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItem_MenuItemPriceIdFk",
                table: "MenuItem",
                column: "MenuItemPriceIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemAllergy_AllergyIdFk",
                table: "MenuItemAllergy",
                column: "AllergyIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemAllergy_MenuItemIdFk",
                table: "MenuItemAllergy",
                column: "MenuItemIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemSpecial_MenuItemIdFk",
                table: "MenuItemSpecial",
                column: "MenuItemIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_MenuItemSpecial_SpecialIdFk",
                table: "MenuItemSpecial",
                column: "SpecialIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_MenuRestaurant_MenuIdFk",
                table: "MenuRestaurant",
                column: "MenuIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_MenuRestaurant_MenuItemIdFk",
                table: "MenuRestaurant",
                column: "MenuItemIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_MenuRestaurant_RestaurantIdFk",
                table: "MenuRestaurant",
                column: "RestaurantIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_Order_OrderStatusIdFk",
                table: "Order",
                column: "OrderStatusIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_Order_QrCodeSeatingIdFk",
                table: "Order",
                column: "QrCodeSeatingIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLine_MenuItemIdFk",
                table: "OrderLine",
                column: "MenuItemIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLine_OrderIdFk",
                table: "OrderLine",
                column: "OrderIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLine_SpecialIdFk",
                table: "OrderLine",
                column: "SpecialIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_OrderLine_UserIdFk",
                table: "OrderLine",
                column: "UserIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductCategoryIdFk",
                table: "Product",
                column: "ProductCategoryIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductReorderFreqIdFk",
                table: "Product",
                column: "ProductReorderFreqIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ProductTypeIdFk",
                table: "Product",
                column: "ProductTypeIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_ProductStockTake_EmployeeIdFk",
                table: "ProductStockTake",
                column: "EmployeeIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_ProductStockTake_ProductIdFk",
                table: "ProductStockTake",
                column: "ProductIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_ProductStockTake_StockTakeIdFk",
                table: "ProductStockTake",
                column: "StockTakeIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_ProductWrittenOff_EmployeeIdFk",
                table: "ProductWrittenOff",
                column: "EmployeeIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_ProductWrittenOff_ProductIdFk",
                table: "ProductWrittenOff",
                column: "ProductIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_ProductWrittenOff_WrittenOffStockIdFk",
                table: "ProductWrittenOff",
                column: "WrittenOffStockIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_QrCode_RestaurantIdFk",
                table: "QrCode",
                column: "RestaurantIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_QrCodeSeating_OrderIdFk",
                table: "QrCodeSeating",
                column: "OrderIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_QrCodeSeating_QrCodeIdFk",
                table: "QrCodeSeating",
                column: "QrCodeIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_QrCodeSeating_SeatingIdFk",
                table: "QrCodeSeating",
                column: "SeatingIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_ReservationStatusIdFk",
                table: "Reservation",
                column: "ReservationStatusIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_Reservation_UserIdFk",
                table: "Reservation",
                column: "UserIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationRestaurant_ReservationIdFk",
                table: "ReservationRestaurant",
                column: "ReservationIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_ReservationRestaurant_RestaurantIdFk",
                table: "ReservationRestaurant",
                column: "RestaurantIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_Restaurant_RestaurantStatusIdFk",
                table: "Restaurant",
                column: "RestaurantStatusIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantAdvertisement_AdvertisementIdFk",
                table: "RestaurantAdvertisement",
                column: "AdvertisementIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantAdvertisement_RestaurantIdFk",
                table: "RestaurantAdvertisement",
                column: "RestaurantIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantFacilityRef_RestaurantFacilityIdFk",
                table: "RestaurantFacilityRef",
                column: "RestaurantFacilityIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantFacilityRef_RestaurantIdFk",
                table: "RestaurantFacilityRef",
                column: "RestaurantIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantImage_RestaurantIdFk",
                table: "RestaurantImage",
                column: "RestaurantIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantRestaurantImage_RestaurantIdFk",
                table: "RestaurantRestaurantImage",
                column: "RestaurantIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantRestaurantImage_RestaurantImageIdFk",
                table: "RestaurantRestaurantImage",
                column: "RestaurantImageIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantTypeRef_RestaurantIdFk",
                table: "RestaurantTypeRef",
                column: "RestaurantIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_RestaurantTypeRef_RestaurantTypeIdFk",
                table: "RestaurantTypeRef",
                column: "RestaurantTypeIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_Seating_ReservationIdFk",
                table: "Seating",
                column: "ReservationIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_SeatingLayout_LayoutTypeIdFk",
                table: "SeatingLayout",
                column: "LayoutTypeIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_SeatingLayout_RestaurantIdFk",
                table: "SeatingLayout",
                column: "RestaurantIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_Shift_ShiftStatusIdFk",
                table: "Shift",
                column: "ShiftStatusIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_SocialMedia_SocialMediaTypeIdFk",
                table: "SocialMedia",
                column: "SocialMediaTypeIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialPrice_SpecialIdFk",
                table: "SpecialPrice",
                column: "SpecialIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierOrder_SupplierIdFk",
                table: "SupplierOrder",
                column: "SupplierIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierOrderLine_ProductIdFk",
                table: "SupplierOrderLine",
                column: "ProductIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_SupplierOrderLine_SupplierOrderIdFk",
                table: "SupplierOrderLine",
                column: "SupplierOrderIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_UserComment_RestaurantIdFk",
                table: "UserComment",
                column: "RestaurantIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_UserComment_StarRatingIdFk",
                table: "UserComment",
                column: "StarRatingIdFk");

            migrationBuilder.CreateIndex(
                name: "IX_WriteOffReason_WrittenOffStockIdFkFk",
                table: "WriteOffReason",
                column: "WrittenOffStockIdFkFk");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderLine_Order_OrderIdFk",
                table: "OrderLine",
                column: "OrderIdFk",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_QrCodeSeating_Order_OrderIdFk",
                table: "QrCodeSeating",
                column: "OrderIdFk",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QrCode_Restaurant_RestaurantIdFk",
                table: "QrCode");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_OrderStatus_OrderStatusIdFk",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_QrCodeSeating_QrCodeSeatingIdFk",
                table: "Order");

            migrationBuilder.DropTable(
                name: "AttendanceSheet");

            migrationBuilder.DropTable(
                name: "EmployeeShift");

            migrationBuilder.DropTable(
                name: "ItemTypeMenuItem");

            migrationBuilder.DropTable(
                name: "MenuItemAllergy");

            migrationBuilder.DropTable(
                name: "MenuItemSpecial");

            migrationBuilder.DropTable(
                name: "MenuRestaurant");

            migrationBuilder.DropTable(
                name: "OrderLine");

            migrationBuilder.DropTable(
                name: "ProductStockTake");

            migrationBuilder.DropTable(
                name: "ReservationRestaurant");

            migrationBuilder.DropTable(
                name: "RestaurantAdvertisement");

            migrationBuilder.DropTable(
                name: "RestaurantFacilityRef");

            migrationBuilder.DropTable(
                name: "RestaurantRestaurantImage");

            migrationBuilder.DropTable(
                name: "RestaurantTypeRef");

            migrationBuilder.DropTable(
                name: "SeatingLayout");

            migrationBuilder.DropTable(
                name: "SocialMedia");

            migrationBuilder.DropTable(
                name: "SpecialPrice");

            migrationBuilder.DropTable(
                name: "SupplierOrderLine");

            migrationBuilder.DropTable(
                name: "UserComment");

            migrationBuilder.DropTable(
                name: "WriteOffReason");

            migrationBuilder.DropTable(
                name: "Shift");

            migrationBuilder.DropTable(
                name: "MenuItemType");

            migrationBuilder.DropTable(
                name: "Allergy");

            migrationBuilder.DropTable(
                name: "Menu");

            migrationBuilder.DropTable(
                name: "MenuItem");

            migrationBuilder.DropTable(
                name: "StockTake");

            migrationBuilder.DropTable(
                name: "Advertisement");

            migrationBuilder.DropTable(
                name: "RestaurantFacility");

            migrationBuilder.DropTable(
                name: "RestaurantImage");

            migrationBuilder.DropTable(
                name: "RestaurantType");

            migrationBuilder.DropTable(
                name: "LayoutType");

            migrationBuilder.DropTable(
                name: "SocialMediaType");

            migrationBuilder.DropTable(
                name: "Special");

            migrationBuilder.DropTable(
                name: "SupplierOrder");

            migrationBuilder.DropTable(
                name: "StarRating");

            migrationBuilder.DropTable(
                name: "ProductWrittenOff");

            migrationBuilder.DropTable(
                name: "ShiftStatus");

            migrationBuilder.DropTable(
                name: "MenuItemCategory");

            migrationBuilder.DropTable(
                name: "MenuItemPrice");

            migrationBuilder.DropTable(
                name: "AdvertisementDate");

            migrationBuilder.DropTable(
                name: "AdvertisementPrice");

            migrationBuilder.DropTable(
                name: "Supplier");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "WrittenOffStock");

            migrationBuilder.DropTable(
                name: "ProductCategory");

            migrationBuilder.DropTable(
                name: "ProductReorderFreq");

            migrationBuilder.DropTable(
                name: "ProductType");

            migrationBuilder.DropTable(
                name: "Restaurant");

            migrationBuilder.DropTable(
                name: "RestaurantStatus");

            migrationBuilder.DropTable(
                name: "OrderStatus");

            migrationBuilder.DropTable(
                name: "QrCodeSeating");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "QrCode");

            migrationBuilder.DropTable(
                name: "Seating");

            migrationBuilder.DropTable(
                name: "Reservation");

            migrationBuilder.DropTable(
                name: "ReservationStatus");
        }
    }
}

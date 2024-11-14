# Gemstone Store (TANZANITE WEBSITE)

## Overview

Here we presents the Entity Relationship Diagram (ERD) for the Gemstone Store website, Showing the Tables and their relationships.

## Entity Relationship Diagram (ERD)

![Gemstone](\sda-3-online-Backend_Teamwork\Screenshots\Gemstone Store ERD.png)

## Tables and Their Attributes

### 1. User Table

- **UserId** (PK): identifier for each user.
- **Name**: User's name.
- **PhoneNumber**: User's phone number.
- **Email**: User's email.
- **Password**: User's password (hashed).
- **Roles**: User's role in the system (admin, customer).

### 2. Address Table

- **AddressId** (PK): identifier for each address.
- **Street**: Street name.
- **City**: City name.
- **Country**: Country name.
- **ZipCode**: Postal code.
- **UserID** (FK): References the User table (user with their address).

### 3. Category Table

- **CategoryId** (PK): identifier for each category.
- **CategoryName**: Name of the category (Ruby, Sapphire, Emerald, etc.).

### 4. Gemstone Table

- **GemstoneId** (PK): identifier for each gemstone.
- **GemstoneType**: Type of gemstone (Burma Ruby, Kashmir Sapphire, Pink Rubies, etc.).
- **GemstoneColor**: Color of the gemstone.
- **GemstoneImage**: Image of the gemstone.
- **GemstoneDescription**: Description of the gemstone.
- **GemstonePrice**: Price of the gemstone.
- **CategoryId** (FK): References the Category table.

### 5. Jewelry Table

- **JewelryId** (PK): identifier for each jewelry item.
- **JewelryName**: Name of the jewelry (ring, necklace, etc).
- **JewelryType**: Type of jewelry (Gold, Rose Gold, etc).
- **JewelryImage**: Image of the jewelry.
- **Description**: Description of the jewelry.
- **Price**: Price of the Jewelry.

### 6. Order Table

- **OrderId**: (PK): identifier for each order.
- **UserId**: (FK): References the User table (indicates who placed the order).
- **CreatedAt**: When the order was created.
- **AddressId**: (FK): References the Address table (indicates where the order is to be shipped).
- **OrderProductId**: (FK): References the OrderGemstones table (indicates the products in the order).
- **CartId**: (FK): References the Cart table (links to the user's cart).
- **PaymentId**: (FK): References the Payment table (indicates Payment Details).

### 7. OrderGemstones Table

- **OrderProductId** (PK): identifier for the order product entry.
- **OrderID** (FK): References the Order table.
- **JewelryId** (FK): References the Jewelry table.
- **GemstoneId** (FK): References the Gemstone table.
- **Quantity**: Number of pieces for the item.

### 8. Payment Table

- **PaymentID** (PK): identifier for each payment.
- **OrderId**: (FK): References the Order table.
- **PaymentDate**: Date the payment was made.
- **Amount**: Total amount paid.

### 9. Cart Table

- **CartID**: (PK): identifier for each cart.
- **UserID**: (FK): References the User table -(indicates which user owns the cart).
- **OrderProductId**: (FK): References the OrderGemstones table.
- **CartQuantity**: Quantity of items in the cart.
- **CartPrice**: Total price of items in the cart.
- **OrderId**: (FK): References the Order table.

### 10. Review Table

- **ReviewId**: (PK): identifier for each review.
- **UserID**: (FK): References the User table.
- **OrderID**: (FK): References the Order table.
- **Rating**: Rating given by the user (0-5 scale).
- **ReviewDate**: Date the review was written.
- **Comment**: User's comments on the order.

### 11.GemstoneShape

- **GemstoneShapeId**: (PK): identifier for each Gemstone Shape.
- **ShapeName**: Gemstone Shape Name .
- **Gemstone Color**: Gemstone Color .
- **GemstoneImage**: the url of the Image .
- **Weight**: number of the weight .
- **GemstoneDescription**: Description of the Gemstone.
- **GemstonePrice**: the price of the Gemstone.
- **GemstoneId** : (Fk):References the Gemstone table.

## Relationships

- **User ↔ Address**: One-to-Many between User and Address. Each User can have Multiple Addresses.

- **Category ↔ Gemstone**: One-to-Many between Category and Gemstone. Each category can have multiple gemstones.

- **OrderGemstones ↔ Jewelry**: One-to-Many between OrderGemstones and Jewelry. Each OrderGemstones piece has multiple jewelry.

- **OrderGemstones ↔ Gemstones**: One-to-Many between OrderGemstones and Gemstone. Each OrderGemstones piece has multiple Gemstone.

- **Order ↔ OrderGemstones**: One-to-Many between Order and OrderGemstones. An order can contain multiple gemstones/jewelries.

- **Order ↔ Payment**: One-to-One between Payment and Order. Each order has one payment associated with it.

- **Cart ↔ User**: One-to-One between Cart and User. Each user has one cart.

- **Cart ↔ Order**: One-to-Many between Cart and Order, as a cart can have multiple orders.

- **User ↔ Review**: One-to-Many between User and Review. Each user can write multiple reviews.

- **Order ↔ Review**: One-to-One between Review and Order. Each order can have one review associated with it.

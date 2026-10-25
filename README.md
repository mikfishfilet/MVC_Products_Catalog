## ProductCatalog

## Description

ProductCatalog is an ASP.NET Core MVC web application that allows users to view products, see product details, and add new products. Product information is stored in a JSON file.

## Features

- View a list of products.
- View details for an individual product.
- Add new products with a name and price.
- Validate product names and prices.
- Save product information in a JSON file.

##Technologies Used
- C#
- ASP.NET Core MVC
- Razor Views
- JSON
- HTML

## How to Run

- Clone or download this repository.
- Open a terminal in the project directory.
- Run the following command to restore dependencies:
- dotnet restore
- Start the application:
- dotnet run
- Open the local URL displayed in the terminal in your web browser.

## Data Storage
- Product information is stored in data/products.json. The file is created automatically when the application runs if it does not already exist.
- Validation
- Product names are required.
- Product prices must be between $0.01 and $1,000.

  ## Screenshots
  <img width="310" height="307" alt="image" src="https://github.com/user-attachments/assets/b992268f-4533-431a-a279-a4ccb0d3671c" />

  <img width="254" height="283" alt="image" src="https://github.com/user-attachments/assets/9b050a60-bf71-45c8-9f06-6788ce4aa6c4" />

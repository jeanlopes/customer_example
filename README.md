# Customer Example

This is a sample application that demonstrates a customer management system using ASP.NET Core with a DDD (Domain-Driven Design) approach.

## Prerequisites

- .NET Core SDK 7.0 or later
- SQL Server 2016 or later

## Getting Started

1. Clone the repository:

   ```bash
   git clone https://github.com/your-repository-url.git
   ```

2. Navigate to the Project directory

   ```bash
   cd CustomerExample
   ```

3. Configure the database connection string:

   - Open the `appsettings.json` file
   - Modify the `ConnectionStrings.DefaultConnection` value with your SQL Server connection string.

4. Apply the database migrations:

   ```bash
   dotnet ef database update
   ```

5. Run the application:

   ```bash
   dotnet run
   ```

6. Open your web browser and access the application at `http://localhost:7288`.


7. To authenticate, open the swagger UI at `http://localhost:7288/swagger` and make a POST in /api/auth

	- User: admin
	- Password: Password1

8. (Optional) In order to make new migrations navegate to the Infrastructure directory and run the command:

	```
	dotnet ef --startup-project ../CustomerExample migrations add My_Migration_Name
	```

## API Endpoints

- Customers:
  - `GET /api/customers` - Get all customers
  - `GET /api/customers/{id}` - Get a customer by ID
  - `POST /api/customers` - Create a new customer
  - `PUT /api/customers/{id}` - Update an existing customer
  - `DELETE /api/customers/{id}` - Delete a customer by ID
- Addresses:

  - `GET /api/customers/{customerId}/addresses` - Get all addresses for a customer
  - `POST /api/customers/{customerId}/addresses` - Create a new address for a customer
  - `DELETE /api/customers/{customerId}/addresses/{addressId}` - Delete an address by ID

## Technologies Used

- ASP.NET Core 7.0
- Entity Framework Core 6.0
- SQL Server
- AutoMapper
- Swagger

## Contributing

Contributions are welcome! If you find any issues or would like to add new features, please feel free to submit a pull request.

## License

This project is licensed under the MIT License.

## Description

This application provides a service that returns the final invoice amount after all discounts.

The following discounts apply:

1. If the user is an employee of the store, he gets a 30% discount
2. If the user is an affiliate of the store, he gets a 10% discount
3. If the user has been a customer for over 2 years, he gets a 5% discount.
4. For every `$`100 on the bill, there would be a `$` 5 discount (e.g. for `$` 990, you get `$` 45 as a discount).
5. The percentage based discounts do not apply on groceries.
6. A user can get only one of the percentage based discounts on a bill.

## Prerequisites

* .NET SDK 6
* .NET Runtime 6
* ASP.NET Core Runtime 6

## Running

Run the following command in terminal:

```ps
dotnet run
```

Customer types: 
* 0: Employee
* 1: Affiliate
* 2: Standard

InvoiceItem types: 
* 0: Grocery 
* 1: Other

Post a JSON data in the following format

```json
{
  "customer": {
    "type": 0,
    "registrationDate": "2015-01-11T11:02:59.076Z"
  },
  "invoiceItems": [
    {
      "type": 0,
      "cost": 100
    },
    {
      "type": 1,
      "cost": 100
    }
  ]
}
```

## Running the Tests

Run the following command in a terminal:

```ps
dotnet test
```

## Analyzing Code

To see code analysis warnings, run the following commands in a terminal:

```ps
dotnet clean
dotnet build
```

## Generating Coverage Report

To generate a coverage report file, run the following command in a terminal:

```ps
dotnet test --collect:"XPlat Code Coverage"
```

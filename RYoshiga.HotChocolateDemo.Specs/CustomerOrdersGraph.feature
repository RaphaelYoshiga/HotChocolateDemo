Feature: CustomerOrdersGraph
	Simple calculator for adding two numbers

@mytag
Scenario: Customer with 1 order
	Given I am logged in as:
		| Id | FirstName | LastName |
		| 99 | John      | Bond     |
		And the customer with id 99 has placed this order
		| Id | Total | Date       |
		| 1  | 150   | 2021-01-01 |
		And the order with id 1 has the following items
		| ProductId | Quantity | UnitCost | OrderId |
		| 1         | 2        | 75       | 1       |
		And the products repository contains those products
		| Id | Name  |
		| 1  | Watch |
	When I request the graph query with the orders for the current user

	Then I should have no errors
	
		And I should receive this customer
		| Id | FirstName | LastName |
		| 99 | John      | Bond     |
		And I should receive those orders
		| Id | Total | Date       |
		| 1  | 150   | 2021-01-01 |
		And the order with Id 1 should contain those Items
		| ProductId | ProductName | Quantity | UnitCost |
		| 1         | Watch       | 2        | 75       |

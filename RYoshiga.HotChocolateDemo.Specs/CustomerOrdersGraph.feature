Feature: CustomerOrdersGraph
	Simple calculator for adding two numbers

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
		And we should have called the products query only once


Scenario: Customer with 2 order
	Given I am logged in as:
		| Id | FirstName | LastName |
		| 99 | John      | Bond     |
		And the customer with id 99 has placed this order
		| Id | Total | Date       |
		| 1  | 150   | 2021-01-01 |
		And the order with id 1 has the following items
		| ProductId | Quantity | UnitCost | OrderId |
		| 1         | 2        | 75       | 1       |

		And the customer with id 99 has placed this order
		| Id | Total | Date       |
		| 2  | 250   | 2021-03-01 |
		And the order with id 2 has the following items
		| ProductId | Quantity | UnitCost | OrderId |
		| 2         | 1        | 225      | 2       |
		| 3         | 1        | 25       | 2       |

		And the products repository contains those products
		| Id | Name        |
		| 1  | Watch       |
		| 2  | Monitor LCD |
		| 3  | HDMI Cable  |
	When I request the graph query with the orders for the current user
	Then I should have no errors
		And I should receive this customer
		| Id | FirstName | LastName |
		| 99 | John      | Bond     |
		And I should receive those orders
		| Id | Total | Date       |
		| 1  | 150   | 2021-01-01 |
		| 2  | 250   | 2021-03-01 |
		And the order with Id 1 should contain those Items
		| ProductId | ProductName | Quantity | UnitCost |
		| 1         | Watch       | 2        | 75       |
		And the order with Id 2 should contain those Items
		| ProductId | ProductName | Quantity | UnitCost |
		| 2         | Monitor LCD | 1        | 225      |
		| 3         | HDMI Cable  | 1        | 25       |
		And we should have called the products query only once
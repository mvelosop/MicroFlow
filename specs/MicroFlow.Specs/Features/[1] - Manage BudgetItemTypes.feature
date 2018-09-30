Feature: [1] - Manage BudgetItemTypes
	As a budget owner,
	I need to manage budget item types,
	to structure my budget


Scenario: [1.1] - Add budget item types
	When I add the following budget item types:
		| Order | Name            | BudgetClass |
		| 1     | Income type     | Income      |
		| 2     | Expense type    | Expense     |
		| 3     | Debt type       | Debt        |
		| 4     | Savings type    | Savings     |
		| 5     | Investment type | Investment  |
		| 6     | Tax type        | Tax         |

	Then I get these budget item types when I query:
		| Order | Name            | BudgetClass |
		| 1     | Income type     | Income      |
		| 2     | Expense type    | Expense     |
		| 3     | Debt type       | Debt        |
		| 4     | Savings type    | Savings     |
		| 5     | Investment type | Investment  |
		| 6     | Tax type        | Tax         |

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

	Then I should get these budget item types when I query:
		| Order | Name            | BudgetClass |
		| 1     | Income type     | Income      |
		| 2     | Expense type    | Expense     |
		| 3     | Debt type       | Debt        |
		| 4     | Savings type    | Savings     |
		| 5     | Investment type | Investment  |
		| 6     | Tax type        | Tax         |


Scenario: [1.2] - Modify budget item types
	Given I have the following budget item types:
		| Order | Name            | BudgetClass |
		| 1     | Income type     | Income      |
		| 2     | Expense type    | Expense     |

	When I modify the following budget item types:
		| FindByName  | Order | Name                  | BudgetClass |
		| Income type | 3     | Income type (updated) | Investment  |

	Then I should get these budget item types when I query:
		| Order | Name                  | BudgetClass |
		| 3     | Income type (updated) | Investment  |
		| 2     | Expense type          | Expense     |


Scenario: [1.3] - Remove budget item types
	Given I have the following budget item types:
		| Order | Name            | BudgetClass |
		| 1     | Income type     | Income      |
		| 2     | Expense type    | Expense     |
		| 3     | Debt type       | Debt        |

	When I remove the following budget item types:
		| FindByName  |
		| Income type |

	Then I should get these budget item types when I query:
		| Order | Name         | BudgetClass |
		| 2     | Expense type | Expense     |
		| 3     | Debt type    | Debt        |

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


Scenario: [1.2] - Update budget item types
	Given I have the following budget item types:
		| Order | Name            | BudgetClass |
		| 1     | Income type     | Income      |
		| 2     | Expense type    | Expense     |

	When I update the following budget item types:
		| FindByName  | Order | Name                  | BudgetClass |
		| Income type | 3     | Income type (updated) | Investment  |

	Then I should get these budget item types when I query:
		| Order | Name                  | BudgetClass |
		| 2     | Expense type          | Expense     |
		| 3     | Income type (updated) | Investment  |


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

Scenario: [1.4] - Validate budget item types on add
	Given I have the following budget item types:
		| Order | Name            | BudgetClass |
		| 1     | Income type     | Income      |
		| 2     | Expense type    | Expense     |
		| 3     | Debt type       | Debt        |

	When I try to add these budget item types I should get validation errors:
		| Order | Name         | BudgetClass | ValidationErrors                  |
		| 3     |              | Debt        | BudgetItemTypeErrors-NameRequired |
		| 2     | Expense type | Expense     | BudgetItemTypeErrors-NameExists   |

Scenario: [1.5] - Validate budget item types on update
	Given I have the following budget item types:
		| Order | Name            | BudgetClass |
		| 1     | Income type     | Income      |
		| 2     | Expense type    | Expense     |
		| 3     | Debt type       | Debt        |

	When I try to update these budget item types I should get validation errors:
		| FindByName  | Order | Name         | BudgetClass | ValidationErrors                  |
		| Debt type   | 3     |              | Debt        | BudgetItemTypeErrors-NameRequired |
		| Income type | 1     | Expense type | Income      | BudgetItemTypeErrors-NameExists   |

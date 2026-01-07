# Use Case: Digital Petty Cash Ledger System

## 1. Introduction
A **Petty Cash system** is used by businesses to manage small, incidental expenditures (such as tea, stationery, or taxi fares) using a "float" or "imprest" fund. 

This use case requires the development of a **Digital Petty Cash Ledger** that allows a cashier to record income (replenishments) and expenses. The system must be built using C# and must demonstrate type-safe data handling without the use of an external database.

## 2. Objective
The objective of this project is to verify proficiency in the following areas:

* **Encapsulation & Abstraction:** Defining clear data models for financial transactions.
* **Inheritance:** Differentiating between transaction types (Income vs. Expense).
* **Generics:** Creating a reusable Ledger or Repository to handle various transaction types while maintaining type safety.
* **Collections:** Efficiently storing, retrieving, and filtering transaction records using `List<T>` or `Dictionary<K, V>`.

---

## 3. Requirements

### A. The Data Model (OOP)

* **Abstract Class:** `Transaction` (Properties: `Id`, `Date`, `Amount`, `Description`).
* **Derived Classes:**
    * `ExpenseTransaction`: Adds a `Category` property (e.g., Office, Travel, Food).
    * `IncomeTransaction`: Adds a `Source` property (e.g., Main Cash, Bank Transfer).
* **Interface:** `IReportable` with a method `GetSummary()` to be implemented by all transaction types.

### B. The Ledger Logic (Generics & Collections)
* **Generic Class:** `Ledger<T>` where `T : Transaction`.
* **Storage:** Internal `List<T>` to hold the transaction history.
* **Methods:**
    * `AddEntry(T entry)`: Adds a transaction.
    * `GetTransactionsByDate(DateTime date)`: Returns a filtered list.
    * `CalculateTotal()`: Uses LINQ or a loop to calculate the sum of the `Amount` property.

### C. Technical Restrictions
* **Storage:** In-memory only (no SQL or File I/O).
* **Type Safety:** The generic Ledger must ensure that only `Transaction` objects can be processed.

---

## 4. Use Case Definition: Record and Balance Petty Cash

| Attribute | Details |
| :--- | :--- |
| **Use Case ID** | UC-FIN-01 |
| **Actor** | Petty Cash Custodian |
| **Pre-condition** | The application is running; ledgers for Expenses and Income are initialized. |

### Main Success Scenario
1.  **Initialize Income Ledger:** The user creates a `Ledger<IncomeTransaction>` to track funds received from the main office.
2.  **Record Replenishment:** The user records a **$500** replenishment from "Main Cash".
3.  **Initialize Expense Ledger:** The user creates a `Ledger<ExpenseTransaction>` to track daily spending.
4.  **Record Expenses:** The user records an expense of **$20** for "Stationery" and **$15** for "Team Snacks".
5.  **Summarize:** The system uses a generic method to display the total from both ledgers.
6.  **Calculate Net Balance:** The user calculates the final balance: **Total Income - Total Expenses**.

---

## 5. Expected Results
The final implementation should demonstrate the following:

1.  **Compile-time Safety:** If a developer attempts to add an `IncomeTransaction` into a `Ledger<ExpenseTransaction>`, the code must fail to compile.
2.  **Correct Calculations:** The console must accurately display the total spent (**$35**) and the total received (**$500**).
3.  **Polymorphic Output:** A loop iterating through a `List<Transaction>` must be able to call `GetSummary()` and display the unique details specific to both Income and Expenses.

## 6. Conclusion
By completing this use case, the developer demonstrates a professional understanding of software architecture. Moving beyond simple variables to a Generic-based Ledger system ensures the application is scalable, less prone to runtime errors, and easy to maintain as business requirements grow.
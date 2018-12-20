Feature: Back-end API for user-mgmt

@ignore
Scenario: S_1
Given an Employee with valid credentials
When I login as this Employee
Then I can access the application according to my access rights

@ignore
Scenario: S_2
Given an Employee list
When I bulk insert this list
Then all employees are created or updated

@ignore
Scenario: S_3
Given an Employee
And an authenticated external application
When that external application requests for personal data of this Employee
Then it can read personal data of this Employee

@ignore
Scenario: S_4
Given an Employee
And an authenticated external application
When this employee is updated
Then that external application is notified of the update

Feature: Back-end API for user-mgmt

Scenario: U_1
Given an Employee
When I am logged in as this Employee 
Then I can view my profile and personal data

Scenario: U_2
Given an Employee
When I am logged in as this Employee 
Then I can edit my personal data

Scenario: U_3
Given a Human resource manager
And an Employee
When I am logged in as this Human resource manager 
Then I can view that Employee's personal data

Scenario: U_4
Given a Human resource manager
And an Employee
When I am logged in as this Human resource manager 
Then I can edit that Employee's personal data

Scenario: U_5
Given a Human resource manager
When I am logged in as this Human resource manager 
Then I can create a new Employee

Scenario: U_6
Given a Human resource manager
And an Employee (former or actual)
When I am logged in as this Human resource manager 
Then I can delete personal data of this Employee 


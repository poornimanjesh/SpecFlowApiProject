Feature: To test get request

A short summary of the feature

@tag1
Scenario: Get request testing
	Given the user sends a get request with url "https://reqres.in/api/users/2"
	Then request should be a sucess with 200s code

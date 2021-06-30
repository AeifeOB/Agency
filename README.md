# Agency
This is a PoC framework for autonomous, plan-making agents.

## About
Agency provides a .NET 5 framework for autonomous agents (referred to as actors in agency) who can form their own plans. 
They are able to do this by chaining a number of actions together until they are able to execute their plan.

Each action contains a set of inputs and a set of outputs. These sets are made up of assets that are required for the action (inputs), or that are gained by doing the action (outputs). 
Actors try to form plans by looking at a goal they have and seeing what inputs are required. 
The actor will then look through all available actions to find one that provides at least one of those inputs as an output. This action is then appended to the plan, and the search continues.
Actions previously selected have their inputs added to search until the actor's available assets are able to meet those inputs.

## Road Map
This section details planned releases for the Agency framework

### Initial Release - [Rational Agent](https://github.com/Manny-coffee-dev/Agency/milestone/1) - v1.0.0
An intial release containing a basic framework to allow the development of agents which can form and execute rational plans based on their internal goals.

### Update 1 - [Behavioural Agent](https://github.com/Manny-coffee-dev/Agency/milestone/3) - v1.1.0
This update brings traits which allow recording of data about an agent or asset. These traits also allow for the change of an agent/asset's behaviour.

### Update 2 - [Needy Agent](https://github.com/Manny-coffee-dev/Agency/milestone/2) - v1.2.0
An expanded modelling of an agent's internal state. This update adds needs that drive internal goal selection in response to changes in an agent's state.

### Update 3 - [Eventful Agent](https://github.com/Manny-coffee-dev/Agency/milestone/4) - v1.3.0
Expansion of the plan execution engine allowing integration into thrid-party systems when an action in executed.
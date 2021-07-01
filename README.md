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
This section details planned releases for the Agency framework. Agency uses [Semantic Versioning 2.0.0](https://semver.org/) for tracking codebase versions. Until the framework stablises, 
Agency will use 0.X.Y versions. Once the PoC is complete, a stable 1.0.0 release will be created.

### Initial Pre-Alpha Release - [Rational Agent](https://github.com/Manny-coffee-dev/Agency/milestone/1) - v0.1.0 - In Progress
An intial release containing a basic framework to allow the development of agents which can form and execute rational plans based on their internal goals.

### Update 1 - [Behavioural Agent](https://github.com/Manny-coffee-dev/Agency/milestone/3) - v0.2.0 
This update brings traits which allow recording of data about an agent or asset. These traits also allow for the change of an agent/asset's behaviour.

### Update 2 - [Needy Agent](https://github.com/Manny-coffee-dev/Agency/milestone/2) - v0.3.0 
An expanded modelling of an agent's internal state. This update adds needs that drive internal goal selection in response to changes in an agent's state.

### Update 3 - [Eventful Agent](https://github.com/Manny-coffee-dev/Agency/milestone/4) - v0.4.0 
Expansion of the plan execution engine allowing integration into thrid-party systems when an action in executed.

## Support This Project
You can support this project by using it and raising any issues using our [Issues tracker](https://github.com/Manny-coffee-dev/Agency/issues) or contribute directly
by raising pull requests with bug fixes and new features.

You can also support us by buying some merchandise from our eco-sustainable partners at [TeeMill](https://coffeebreakdev.teemill.com/).
We receive a proportion of the cost of each item you purchase. If merchandise isn't your thing, consider [buying us a coffee](buymeacoffee.com/coffeebreakdevs) to support our
work.
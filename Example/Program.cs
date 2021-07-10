using Agency;
using Example.Actions;
using Example.Assets;
using Example.Traits;
using System;
using System.Reflection;

namespace Example
{
    class Program
    {
        /// <summary>
        /// Example use of the Agency framework where an Actor (agent) has a goal to retire (requiring Money)
        /// and plans to rob a bank to fund their retirement. In order to rob the bank, the agent needs to 
        /// aquire a Team, and thus plans to hire a Team in order to rob the bank.
        /// </summary>
        static void Main()
        {
            Console.WriteLine("Agency v{0}\n", Assembly.GetExecutingAssembly().GetName().Version.ToString());

            // Create a new Actor
            Actor agent = new();

            agent.AvailableAssets.Add(new Money(100));
            agent.Traits.Add(new Location("House"));

            // Create a Retire Action and assign it as the agent's goal
            Retire retire = new(new Location("Paradise Island"));
            retire.InputAssets.Add(new Money(1000));
            agent.Goals.Add(retire);

            // Populate the agent's available actions
            AddActionsToActor(agent);

            // Allow the agent to create a plan
            agent.Think();

            // Display the agent's plan
            Console.WriteLine("Agent's Plan:");
            foreach (Agency.Action action in agent.CurrentPlan.Actions)
            {
                Console.WriteLine(action);
            }
            agent.CurrentPlan.Execute(agent);
            foreach (Agency.Trait trait in agent.Traits)
            {
                Console.WriteLine(trait.GetType());
            }
        }

        /// <summary>
        /// Method to populate an Actor with example Actions.
        /// </summary>
        /// <param name="actor"></param>
        static void AddActionsToActor(Actor actor)
        {
            RobBank robBank = new();
            robBank.InputAssets.Add(new Team(3));
            robBank.OutputAssets.Add(new Money(1000));
            actor.AvailableActions.Add(robBank);

            HireTeam hireTeam = new();
            hireTeam.InputAssets.Add(new Money(100));
            hireTeam.OutputAssets.Add(new Team(3));
            actor.AvailableActions.Add(hireTeam);

            GoTo goToBank = new(new Location("Bank"));
            actor.AvailableActions.Add(goToBank);

            GoTo goToClub = new(new Location("Club"));
            actor.AvailableActions.Add(goToClub);

            GoTo goToHouse = new(new Location("House"));
            actor.AvailableActions.Add(goToHouse);
        }
    }
}

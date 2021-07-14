using Agency;
using Example.Actions;
using Example.Assets;
using Example.Needs;
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

            // Populate the agent's needs
            AddNeedsToActor(agent);

            // Populate the agent's available actions
            AddActionsToActor(agent);

            // Allow the agent to select goals
            agent.SelectGoal();

            // Allow the agent to create a plan
            agent.Think();

            // Display the agent's goal
            Console.WriteLine("Agent's Goal: {0}", agent.Goals[0].GetType());

            // Display the agent's plan
            Console.WriteLine("\nAgent's Plan:");
            foreach (Agency.Action action in agent.CurrentPlan.Actions)
            {
                Console.WriteLine(action);
            }

            // Display the agent's execution of the plan
            Console.WriteLine("\nAgent's Execution:");
            agent.CurrentPlan.Execute(agent);

            // Display the agent's state after executing the plan
            Console.WriteLine("\nAgent's Final State:");
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
            Retire retire = new(new Location("Paradise Island"));
            retire.InputAssets.Add(new Money(1000));
            retire.OutputTraits.Add(new Retired());
            actor.AvailableActions.Add(retire);

            RobBank robBank = new();
            robBank.InputAssets.Add(new Team(3));
            robBank.OutputAssets.Add(new Money(1000));
            robBank.OutputTraits.Add(new Work());
            actor.AvailableActions.Add(robBank);

            HireTeam hireTeam = new();
            hireTeam.InputAssets.Add(new Money(100));
            hireTeam.OutputAssets.Add(new Team(3));
            hireTeam.OutputTraits.Add(new Work());
            actor.AvailableActions.Add(hireTeam);

            GoTo goToBank = new(new Location("Bank"));
            goToBank.OutputTraits.Add(new Work());
            actor.AvailableActions.Add(goToBank);

            GoTo goToClub = new(new Location("Club"));
            goToClub.OutputTraits.Add(new Work());
            actor.AvailableActions.Add(goToClub);

            GoTo goToHouse = new(new Location("House"));
            goToHouse.OutputTraits.Add(new Work());
            actor.AvailableActions.Add(goToHouse);
        }

        /// <summary>
        /// Method to populate an Actor with example Needs.
        /// </summary>
        /// <param name="actor"></param>
        static void AddNeedsToActor(Actor actor)
        {
            Rest rest = new Rest(1.0);
            rest.PositiveTraits.Add(new Retired());
            rest.NegativeTraits.Add(new Work());
            actor.Needs.Add(rest);

            Power power = new Power(0.1);
            power.PositiveTraits.Add(new Cash());
            actor.Needs.Add(power);
        }
    }
}

using System;
using System.Reflection;

namespace Agency
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args is null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            Console.WriteLine("Agency v{0}", Assembly.GetExecutingAssembly().GetName().Version.ToString());

            Actor agent = new();

            Retire retire = new();
            retire.Inputs.Add(new Money(1000));
            agent.Goals.Add(retire);

            AddActionsToActor(agent);

            agent.Think();

            foreach (Action action in agent.CurrentPlan.Actions)
            {
                Console.WriteLine(action);
            }
        }

        static void AddActionsToActor(Actor actor)
        {
            RobBank robBank = new();
            robBank.Inputs.Add(new Team(3));
            robBank.Outputs.Add(new Money(1000));
            actor.AvailableActions.Add(robBank);

            HireTeam hireTeam = new();
            hireTeam.Inputs.Add(new Money(100));
            hireTeam.Outputs.Add(new Team(3));
            actor.AvailableActions.Add(hireTeam);
        }
    }
}

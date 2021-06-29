using System;
using System.Reflection;

namespace Agency
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Agency v{0}", Assembly.GetExecutingAssembly().GetName().Version.ToString());

            Actor agent = new Actor();

            Retire retire = new Retire();
            retire.Inputs.Add(new Money(1000));
            agent.goals.Add(retire);

            AddActionsToActor(agent);

            agent.Think();

            foreach(Action action in agent.currentPlan.actions)
            {
                Console.WriteLine(action);
            }
        }

        static void AddActionsToActor(Actor actor)
        {
            RobBank robBank = new RobBank();
            robBank.Inputs.Add(new Team(3));
            robBank.Outputs.Add(new Money(1000));
            actor.availableActions.Add(robBank);

            HireTeam hireTeam = new HireTeam();
            hireTeam.Inputs.Add(new Money(100));
            hireTeam.Outputs.Add(new Team(3));
            actor.availableActions.Add(hireTeam);
        }
    }
}

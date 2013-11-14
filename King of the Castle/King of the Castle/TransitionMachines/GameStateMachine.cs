using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace King_of_the_Castle.TransitionMachines
{
    public class GameStateMachine
    {
        private static GameStateMachine instance;

        public GameStateMachine()
        {
        }

        public static GameStateMachine Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameStateMachine();
                }
                return instance;
            }
        }
    }
}

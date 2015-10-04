using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XNATutorialGame
{
    class GameWideMethods
    {
        //class full of methods which will be available game wide
        static Random numberGen = new Random();//this num gen is used called upon instantiasation of object

        public int randomNumer(int maxValue)//running number gen for 1,2 for the letter from the die.1 = dead. 2 = alive
        {
            int roll;//contains the initial roll of the number gen
            int dieRollUpdate;//contains the updated value
            roll = numberGen.Next(1, maxValue);//uses the global Random generator of numberGen. Produces either 1, 2 or 3
            dieRollUpdate = roll;
            return dieRollUpdate;//returns this value. this is the value that is evaluated, then re-rolled if needed.
        }
    }
}

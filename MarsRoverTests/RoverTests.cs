using System;
using System.Collections.Generic;
using MarsRover;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRoverTests
{
    [TestClass]
    public class RoverTests
    {
        Command[] newCommand = { new Command("MODE_CHANGE", "LOW_POWER") };

        [TestMethod]
        public void ConstructorSetsDefaultPosition()
        {
            Rover newRover = new Rover(15);
            Assert.IsTrue(newRover.Position == 15);
        }
        [TestMethod]
        public void ConstructorSetsDefaultMode()
        {
            Rover newRover = new Rover(15);
            Assert.IsTrue(newRover.Mode == "NORMAL");
        }
        [TestMethod]
        public void ConstructorSertsDefaultGeneratorWatts()
        {
            Rover newRover = new Rover(15);
            Assert.IsTrue(newRover.GeneratorWatts == 110);
        }
        [TestMethod]
        public void RespondsCorrectlyToModeChangeCommand()
        {
            Rover newRover = new Rover(15);
            Command[] newCommand = { new Command("MODE_CHANGE", "LOW_POWER") };
            newRover.ReceiveMessage(new Message("NEW MESSAGE", newCommand));
            Assert.AreEqual("LOW_POWER", newRover.Mode);
        }
        [TestMethod]
        public void DoesNotMoveInLowPower()
        {
            Rover newRover = new Rover(0);
            Command[] newCommand = {new Command("MODE_CHANGE","LOW_POWER"), new Command("MOVE", 20) };
            newRover.ReceiveMessage(new Message("NEW COMMANDS", newCommand));
            Assert.AreEqual(20, newRover.Position);

        }
    }
}

using System;
using System.Collections.Generic;
using MarsRover;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRoverTests
{
    [TestClass]
    public class RoverTests
    {
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
            Command[] newCommands = { new Command("MODE_CHANGE", "LOW_POWER"), new Command("MOVE", 20) };
            newRover.ReceiveMessage(new Message("NEW COMMANDS", newCommands));
            Assert.AreEqual(0, newRover.Position);
        }
        [TestMethod]
        public void PositionChangesFromMoveCommand()
        {
            Rover newRover = new Rover(10);
            Command[] newCommands = { new Command("MOVE", 20) };
            newRover.ReceiveMessage(new Message("NEW COMMANDS", newCommands));
            Assert.IsTrue(newRover.Position == 30);
        }
        [TestMethod]
        public void RoverReturnsAMessageForAnUnkownComman()
        {
            try
            {
                new Command("SHUTDOWN");
            }
            catch (ArgumentException ex)
            {
                Assert.AreEqual("COMMAND TYPE NOT RECOGNIZED.", ex.Message);
            }
        }
    }
}

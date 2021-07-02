using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarsRover;

namespace MarsRoverTests
{
    [TestClass]
    public class MessageTests
    {
        Command[] commands = { new Command("MOVE", 0), new Command("MOVE", 20) };

        [TestMethod]
        public void ArgumentNullExceptionThrownIfNameNotPassedToConstructor()
        {
            try
            {
                new Message("", commands);
            }
            catch (ArgumentNullException ex)
            {
                Assert.AreEqual("Message Name required.", ex.Message);
            } 
        }
        [TestMethod]
        public void ConstructorSetsName()
        {
            Message newMessage = new Message("Name of Message", commands);
            Assert.AreEqual(newMessage.Name, "Name of Message");
        }
        [TestMethod]
        public void ConstructorSetsCommandsField()
        {
            Message newMessage = new Message("Name of Message", commands);
            Assert.AreEqual(commands[0].CommandType, "MOVE");
            Assert.AreEqual(commands[1].NewPostion, 20);
        }
    }
}

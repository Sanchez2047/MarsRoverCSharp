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
            Assert.AreEqual("Name of Message", newMessage.Name);
        }
        [TestMethod]
        public void ConstructorSetsCommandsField()
        {
            Message newMessage = new Message("Name of Message", commands);
            Assert.AreEqual("MOVE", commands[0].CommandType);
            Assert.AreEqual(20, commands[1].NewPostion);
        }
    }
}

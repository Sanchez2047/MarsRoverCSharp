using System;
namespace MarsRover
{
    public class Command
    {
        public string CommandType { get; set; }
        public int NewPostion { get; set; }
        public string NewMode { get; set; }


        public Command() { }

        public Command(string commandType)
        {
            if (String.IsNullOrEmpty(commandType))
            {
                throw new ArgumentNullException(commandType, "Command type required.");
            }
            else if (commandType == "MOVE" || commandType == "MODE_CHANGE")
            {
                CommandType = commandType;
            }
            else
            {
                throw new ArgumentException("COMMAND TYPE NOT RECOGNIZED.");
            }
        }
        public Command(string commandType, int value)
        {
            if (String.IsNullOrEmpty(commandType))
            {
                throw new ArgumentNullException(commandType, "Command type required.");
            }
            else if (commandType == "MOVE" || commandType == "MODE_CHANGE")
            {
                CommandType = commandType;  
                NewPostion = value;
            }
            else
            {
                throw new ArgumentException("COMMAND TYPE NOT RECOGNIZED.");
            }
        }
        public Command(string commandType, string newMode)
        {
            if (String.IsNullOrEmpty(commandType))
            {
                throw new ArgumentNullException(commandType, "Command type required.");
            }
            else if (commandType == "MOVE" || commandType == "MODE_CHANGE")
            {
                CommandType = commandType;
                NewMode = newMode;  
            }
            else
            {
                throw new ArgumentException("COMMAND TYPE NOT RECOGNIZED.");
            }
        }
    }
}

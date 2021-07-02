using System;
namespace MarsRover
{
    public class Rover
    {
        public string Mode { get; set; }
        public int Position { get; set; }
        public int GeneratorWatts { get; set; }

        public Rover(int position)
        {
            Position = position;
            Mode = "NORMAL";
            GeneratorWatts = 110;
        }
        public void ReceiveMessage(Message message)
        {
            foreach (Command command in message.Commands)
            {
                if (command.NewMode != null)
                {
                    Mode = command.NewMode;

                }
                if (Mode != "LOW_POWER")
                {
                    Position += command.NewPostion;
                }
            }
        }

        public override string ToString()
        {
            return "Position: " + Position + " - Mode: " + Mode + " - GeneratorWatts: " + GeneratorWatts; 
        }

    }
}

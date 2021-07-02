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
            foreach (var command in message.Commands)
            {
                Mode = command.NewMode;
                while (Mode != "LOW_POWER")
                {
                    Position = command.NewPostion;
                }
            }
            Mode = message.Commands[0].NewMode;
        }

        public override string ToString()
        {
            return "Position: " + Position + " - Mode: " + Mode + " - GeneratorWatts: " + GeneratorWatts; 
        }

    }
}

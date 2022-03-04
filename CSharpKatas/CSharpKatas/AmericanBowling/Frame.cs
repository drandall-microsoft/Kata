using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpKatas.AmericanBowling
{
    public class Frame
    {
        public const uint MaxPins = 10;

        public Frame()
        {

        }

        public Frame Strike()
        {
            this.FramePieces.Add(new Strike());
            return this;
        }

        public Frame Spare()
        {
            this.FramePieces.Add(new Spare());
            return this;
        }

        public Frame WithPins(uint pins)
        {
            this.FramePieces.Add(new PinCount(pins));
            return this;
        }

        public List<FramePiece> FramePieces { get; } = new List<FramePiece>();
    }

    public abstract class FramePiece
    {
        public abstract uint Pins { get; }
    }

    public class Strike : FramePiece
    {
        public override uint Pins => Frame.MaxPins;
    }

    public class Spare : FramePiece
    {
        public override uint Pins => Frame.MaxPins;
    }

    public class PinCount : FramePiece
    {
        private uint pins;
        public PinCount(uint pins)
        {
            this.pins = pins;
        }

        public override uint Pins => pins;
    }

    //FramePiece
    //Number, Strike, Spare
    //Frame contains List<FramePieces>

    //Number(3), Spare
    //Number(3), Number(2), Strike
    
    //Number(3), Spare, Strike
    //Strike, Number(3), Spare
}

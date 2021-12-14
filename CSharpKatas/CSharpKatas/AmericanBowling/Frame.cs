using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpKatas.AmericanBowling
{
    public class Frame
    {
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

        public Frame WithPins(int pins)
        {
            this.FramePieces.Add(new PinCount(pins));
            return this;
        }

        public List<FramePiece> FramePieces { get; } = new List<FramePiece>();
    }

    public abstract class FramePiece
    {
        public abstract int Score { get; }
    }

    public class Strike : FramePiece
    {
        public override int Score => 10;
    }

    public class Spare : FramePiece
    {
        public override int Score => 10;
    }

    public class PinCount : FramePiece
    {
        private int pins;
        public PinCount(int pins)
        {
            this.pins = pins;
        }

        public override int Score => pins;
    }

    //FramePiece
    //Number, Strike, Spare
    //Frame contains List<FramePieces>

    //Number(3), Spare
    //Number(3), Number(2), Strike
    
    //Number(3), Spare, Strike
    //Strike, Number(3), Spare
}

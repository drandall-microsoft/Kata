using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

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
            //[X] [3/]
            //|20| |30|
            //[3/X]
            //[X3/]
            var remainingPins = MaxPins - this.FramePieces.Last().Pins;
            this.FramePieces.Add(new Spare(remainingPins));
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
        private uint pins;
        public Spare(uint pins)
        {
            this.pins = pins;
        }
        public override uint Pins => pins;
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
}

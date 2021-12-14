using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CSharpKatas.Collatz
{
    public class CollatzPrinter
    {
        private Stream outStream;
        public CollatzPrinter(Stream outStream)
        {
            this.outStream = outStream;
        }

        public void PrintCollatz(uint input)
        {
            using StreamWriter writer = new StreamWriter(outStream, leaveOpen: true);
            writer.AutoFlush = true;

            if(input == 0)
            {
                throw new Exception($"Input must be >= 1, but was {input}");
            }

            writer.Write(string.Join(", ", GetSeries(input)));
            outStream.Position = 0;
        }

        private IEnumerable<uint> GetSeries(uint input)
        {
            var seen = new HashSet<uint>();

            yield return input;
            while (input != 1)
            {
                if(input % 2 == 0)
                {
                    input /= 2;
                }
                else
                {
                    input = (input * 3) + 1;
                }
                if(!seen.Add(input))
                {
                    throw new Exception($"Cycle detected with {input}");
                }

                yield return input;
            }
        }
    }
}

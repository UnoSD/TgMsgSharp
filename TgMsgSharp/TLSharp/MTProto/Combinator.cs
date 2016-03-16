using System;
using System.Diagnostics;

namespace TLSharp.Core.MTProto
{
    /*
        Combinator number or combinator name is a 32-bit number (i.e., an element of A) that uniquely identifies a combinator.
        Most often, it is CRC32 of the string containing the combinator description without the final semicolon, and with one
        space between contiguous lexemes. This always falls in the range from 0x01000000 to 0xffffff00. The highest 256 values
        are reserved for the so-called temporal-logic combinators used to transmit functions. We frequently denote as combinator 
        the combinator name with single quotes: ‘*combinator*’.

        Combinator description is a string of format combinator_name type_arg_1 ... type_arg_N = type_res; where N stands for 
        the arity of the combinator, type_arg_i is the type of the i-th argument (or rather, a string with the combinator name),
        and type_res is the combinator value type.
    */

    [DebuggerDisplay("{" + nameof(ToHex) + "}")]
    public struct Combinator
    {
        public uint Name { get; set; }

        // Test you get no exceptions by testing all uint critical values.
        public string ToHex => Name.ToString("X");

        public Type ToType => Tl.GetCombinatorType(Name);

        public Combinator(uint name)
        {
            Name = name;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magic
{
    // NB: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/arrays

    public static class MagicSquare
    {

        public static UInt32 MagicSum(UInt32 n)
        {
            return n * (n * n + 1) / 2;
        }

        // TODO: unit test:
        // n=1 => 1
        // n=3 => 15
        // n=4 => 34
        // n=5 => 65

        public static bool AreMagicRows(UInt32[,] square)
        {
            return false;
        }

        public static bool AreMagicColumns(UInt32[,] square)
        {
            return false;
        }

        public static bool AreMagicDiagonals(UInt32[,] square)
        {
            return false;
        }

        public static bool AreAllMagicPresent(UInt32[,] square)
        {
            return false;
        }

        public static bool IsMagic(UInt32[,] square) {
            // compute magic sum
            // verify rows
            // verify columns
            // verify 'diagonals'
            // verify all numbers are present (only once)
            return false;
        }

        // + unit test

        public static UInt32[,] Generate(UInt32 n)
        {
            // TODO: fill array with number in range [1,n^2]
            return new UInt32[n,n];
        }

        // + integration test

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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


        public static bool AreMagicRows(UInt32[,] square, UInt32 n, UInt32 magicSum) =>
            AreEnumerablesMagic(
                Enumerable.Range(0, (Int32)n)
                    .Select(i => RowEnumerator(square, n, (UInt32)i)),
                magicSum
            );  
          

        public static bool AreMagicColumns(UInt32[,] square, UInt32 n, UInt32 magicSum) =>
            AreEnumerablesMagic(
                Enumerable.Range(0, (Int32)n)
                    .Select(j => ColumnEnumerator(square, n, (UInt32)j)),
                magicSum
            ); 
        
        public static bool AreMagicDiagonals(UInt32[,] square, UInt32 n, UInt32 magicSum) =>
            AreEnumerablesMagic(
                new List<IEnumerable<UInt32>>()
                {
                    MainDiagonalEnumerator(square, n),
                    SymetricDiagonalEnumerator(square, n)
                },
                magicSum
            );  

        public static bool AreAllMagicPresent(UInt32[,] square, UInt32 n)
        {
            return false;
        }

        public static bool IsMagic(UInt32[,] square) {
            // compute magic sum
            var n = (UInt32) square.GetLength(0);
            var ms = MagicSum(n);
            return AreMagicRows(square, n, ms)
                && AreMagicColumns(square, n, ms)
                && AreMagicDiagonals(square, n, ms)
                && AreAllMagicPresent(square, n);
        }

        // + unit test

        public static UInt32[,] Generate(UInt32 n)
        {
            // TODO: fill array with number in range [1,n^2]
            return new UInt32[n,n];
        }

        // + integration test

        // private methods
        private static bool AreEnumerablesMagic(
            IEnumerable<IEnumerable<UInt32>> valueSeries, 
            UInt32 magicSum
        )
        {
            var signedMagicSum = (Int64)magicSum;
            return valueSeries.All(serie => serie.Sum(x => (Int64)x) == signedMagicSum);
        }

        private static IEnumerable<UInt32> RowEnumerator(UInt32[,] square, UInt32 n, UInt32 rowNumber)
        {
            for (UInt32 j = 0; j < n; j++) yield return square[rowNumber, j];
        }

        private static IEnumerable<UInt32> ColumnEnumerator(UInt32[,] square, UInt32 n, UInt32 columnNumber)
        {
            for (UInt32 i = 0; i < n; i++) yield return square[i, columnNumber];
        }

        private static IEnumerable<UInt32> MainDiagonalEnumerator(UInt32[,] square, UInt32 n)
        {
            for (UInt32 i = 0; i < n; i++) yield return square[i, i];
        }

        private static IEnumerable<UInt32> SymetricDiagonalEnumerator(UInt32[,] square, UInt32 n)
        {
            for (UInt32 i = 0; i < n; i++) yield return square[i, n - i - 1];
        }

    }
}

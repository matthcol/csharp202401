using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace MagicSquareTests
{
    public static class SquareFixture
    {
        public static readonly UInt32[,] SQUARE_3_OK = {
            { 8, 1, 6 },
            { 3, 5, 7 },
            { 4, 9, 2 }
        };

        public static readonly UInt32[,] SQUARE_3_KO_ROWS = {
            { 8,9,6 },
            { 3,5,7 },
            { 4,1,2 }
        };

        public static readonly UInt32[,] SQUARE_3_KO_COLUMNS = {
            { 8,1,6 },
            { 7,5,3 },
            { 4,9,2 }
        };

        public static readonly UInt32[,] SQUARE_3_KO_2_DIAGS = {
            {8,1,6},
            {4,9,2},
            {3,5,7}
        };

        public static readonly UInt32[,] SQUARE_5_OK = {
            {1, 24, 3, 25, 12},
            {16, 7, 21, 6, 15},
            {23, 14, 18, 8, 2},
            {5, 9, 10, 22, 19},
            {20, 11, 13, 4, 17}
        };

        public static readonly UInt32[,] SQUARE_4_OK_ALBRECHT_DURER = {
            {16, 3, 2, 13},
            {5, 10, 11, 8},
            {9, 6, 7, 12},
            {4, 15, 14, 1}
        };

        public static readonly UInt32[,] SQUARE_3_KO_DIAG1 = {
            {8, 1, 6},
            {3, 5, 7},
            {4, 9, 3}
        };

        public static readonly UInt32[,] SQUARE_3_KO_DIAG2 = {
            {8, 1, 5},
            {3, 5, 7},
            {4, 9, 2}
        };

        public static readonly UInt32[,] SQUARE_3_KO_OUT_OF_RANGE_ABOVE = {
            {8, 1, 6},
            {7, 5, 13},
            {4, 9, 2}
        };

        public static readonly UInt32[,] SQUARE_3_KO_OUT_OF_RANGE_UNDER = {
            {8, 1, 6},
            {0, 5, 7},
            {4, 9, 2}
        };

        public static readonly UInt32[,] SQUARE_3_KO_REPEATED_VALUE = {
            {8, 1, 6},
            {6, 5, 7},
            {4, 9, 2}
        };

        public static readonly UInt32[,] SQUARE_12_OK_WILLEM_BARINK = {
            { 138, 8, 17, 127, 114, 32, 41, 103, 90, 56, 65, 79
            },
            { 19, 125, 140, 6, 43, 101, 116, 30, 67, 77, 92, 54
            },
            { 128, 18, 7, 137, 104, 42, 31, 113, 80, 66, 55, 89
            },
            { 5, 139, 126, 20, 29, 115, 102, 44, 53, 91, 78, 68
            },
            { 136, 10, 15, 129, 112, 34, 39, 105, 88, 58, 63, 81
            },
            { 21, 123, 142, 4, 45, 99, 118, 28, 69, 75, 94, 52
            },
            { 130, 16, 9, 135, 106, 40, 33, 111, 82, 64, 57, 87
            },
            { 3, 141, 124, 22, 27, 117, 100, 46, 51, 93, 76, 70
            },
            { 134, 12, 13, 131, 110, 36, 37, 107, 86, 60, 61, 83
            },
            { 23, 121, 144, 2, 47, 97, 120, 26, 71, 73, 96, 50
            },
            { 132, 14, 11, 133, 108, 38, 35, 109, 84, 62, 59, 85
            },
            { 1, 143, 122, 24, 25, 119, 98, 48, 49, 95, 74, 72
            }
        };
    }
}

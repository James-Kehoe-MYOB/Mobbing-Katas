using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.Intrinsics.X86;

namespace Bowling {
    class Program {
        private static Dictionary<char, int> Points = new Dictionary<char, int>();
        
        static void Main(string[] args) {
            
            Points.Add('1', 1);
            Points.Add('2', 2);
            Points.Add('3', 3);
            Points.Add('4', 4);
            Points.Add('5', 5);
            Points.Add('6', 6);
            Points.Add('7', 7);
            Points.Add('8', 8);
            Points.Add('9', 9);
            Points.Add('X', 10);

            Console.WriteLine(BowlingScore("11 11 11 11 11 X 11 11 11 11"));
            //Console.WriteLine(BowlingScore("X X X X X X X X X XXX"));

        }
        
        public static int BowlingScore(string frames)
        {
            // code here
            var turns = frames.Split(' ');
            var total = 0;
            var placeholderCount = 0;

            foreach (var turn in turns) {
                
                foreach (var character in turn) {
                    if (character == '/') 
                    {
                        total += 10 - turn[0]; // edge case turn 10, up to 3 attempts not 2
                        if (placeholderCount > 0) {
                            total += 10 - turn[0];
                            placeholderCount--;
                        }

                        placeholderCount++;
                    } 
                    else if (character == 'X') {
                        total += 10; 
                        if (placeholderCount > 0) {
                            total += 10;
                            placeholderCount--;
                        }

                        placeholderCount += 2;
                    }
                    else 
                    {
                        int value = Int32.Parse(character.ToString());
                        total += value;
                        if (placeholderCount > 0) {
                            total += value;
                            placeholderCount--;
                        }
                    }
                }
                
            }

            return total;

        }
        
        

        
    }
}

// string[] turns = frames.Split(' ');
// Console.WriteLine(string.Join(", ", turns));
// var currentTurn = "";
// var nextTurn = "";
// var nextNextTurn = "";
// int i = 1;
// int totalpoints = 0;
// while (i < 9) {
// currentTurn = turns[i];
// nextTurn = turns[i + 1];
// nextNextTurn = turns[i + 2];
//
// foreach (char character in currentTurn) {
//     switch (character) {
//         case 'X':
//                             
//             totalpoints += GetFaceValue();
//             if (nextTurn.Length == 1) {
//                 totalpoints += 10;
//                 totalpoints += 
//             }
//             break;
//     }
// }
//                 
// i++;
// }
// return 0;
﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.ParkingSystem
{
    public class Cell
    {
        public int Row { get; set; }

        public int Column { get; set; }
    }

    public class Program
    {
        public static void Main()
        {
            var parkingDimensionsRolCol = InitializeParking();
            var usedCells = new HashSet<Cell>();

            var input = Console.ReadLine().Split();

            while (input[0] != "stop")
            {
                var carEntranceRow = int.Parse(input[0]);
                var carParkingAim = new Cell
                {
                    Row = int.Parse(input[1]),
                    Column = int.Parse(input[2])
                };

                // Process car
                if (IsCarParked(carParkingAim, usedCells, parkingDimensionsRolCol))
                {
                    // Print distance travelled to the park
                    Console.WriteLine(Math.Abs((carEntranceRow + 1) - (carParkingAim.Row + 1)) + carParkingAim.Column + 1);
                    usedCells.Add(carParkingAim);
                }
                else
                {
                    Console.WriteLine($"Row {carParkingAim.Row} full");
                }

                input = Console.ReadLine().Split();
            }
        }

        private static bool IsCarParked(Cell carParkingAim, HashSet<Cell> usedCells, int[] parkingDimensions)
        {
            // Try park
            if (usedCells
                    .Where(c => c.Row == carParkingAim.Row && c.Column == carParkingAim.Column)
                    .FirstOrDefault() == null)
            {
                return true;
            }

            var testCol = 1;

            // Loop around the row to find free cell to park
            while (true)
            {
                var leftCol = carParkingAim.Column - testCol;
                var rightCol = carParkingAim.Column + testCol;

                if (leftCol <= 0 && rightCol >= parkingDimensions[1])
                {
                    break;
                }

                // Try park left
                if (leftCol > 0 &&
                    usedCells.Where(c => c.Row == carParkingAim.Row && c.Column == leftCol)
                        .FirstOrDefault() == null)
                {
                    carParkingAim.Column = leftCol;
                    return true;
                }

                // Try park right
                if (rightCol < parkingDimensions[1] &&
                    usedCells.Where(c => c.Row == carParkingAim.Row && c.Column == rightCol)
                        .FirstOrDefault() == null)
                {
                    carParkingAim.Column = rightCol;
                    return true;
                }

                testCol++;
            }

            return false;
        }

        private static int[] InitializeParking()
        {
            var dimmensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            return new int[] { dimmensions[0], dimmensions[1] };
        }
    }
}
using System;

// ASCII 48 = DEC 0

//Console.WriteLine("-|---|---|---|-");
//Console.WriteLine("-| 0 | 1 | 2 |-");
//Console.WriteLine("-|---|---|---|-");
//Console.WriteLine("-| 3 | 4 | 5 |-");
//Console.WriteLine("-|---|---|---|-");
//Console.WriteLine("-| 6 | 7 | 8 |-");
//Console.WriteLine("-|---|---|---|-");

namespace Tic_Tac_Toe_Local_Multiplayer
{
    class Program
    {
        // Variables
        private static string[,] fields = new string[3, 3];
        private static bool[] availableFields = new bool[9];
        private static bool player = true;

        static void Main(string[] args)
        {
            ResetFields();
            DrawStartBoard();

            // Gameloop
            while (!TestGameOver())
            {
                SetInput();
                DrawGameBoard();
                Console.WriteLine("\nThe current places are " + availableFields.ToString() + " \n");
                ChangePlayer();
            }

            Console.WriteLine("The game is over!");
            Console.ReadLine();
        }

        private static void ResetFields()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    fields[i, j] = " ";
                    availableFields[(j + 1) + (i * 3) - 1] = true;
                }
            }
        }

        private static void DrawStartBoard()
        {
            Console.WriteLine("Welcome to 'Tic Tac Toe' otherwise known as 'Naughts and Crosses'! \nThese are the fields: \n");
            Console.WriteLine("-|---|---|---|-");
            Console.WriteLine("-| 0 | 1 | 2 |-");
            Console.WriteLine("-|---|---|---|-");
            Console.WriteLine("-| 3 | 4 | 5 |-");
            Console.WriteLine("-|---|---|---|-");
            Console.WriteLine("-| 6 | 7 | 8 |-");
            Console.WriteLine("-|---|---|---|-");
            Console.WriteLine("\nNow let's start the game, shall we?");
        }

        private static bool TestGameOver()
        {
            if (AllFieldsUsed() || HorizontalWin() || VerticalWin() || CrossWin())
            {
                return true;
            }

            return false;
        }

        private static bool AllFieldsUsed()
        {
            for (int i = 0; i < 9; i++)
            {
                if (availableFields[i])
                {
                    return false;
                }
            }

            return true;
        }

        private static bool HorizontalWin()
        {
            for (int i = 0; i < 3; i++)
            {
                if (fields[i, 0] == fields[i, 1] && fields[i, 1] == fields[i, 2] && fields[i, 0] != " ")
                {
                    return true;
                }
            }

            return false;
        }

        private static bool VerticalWin()
        {
            for (int i = 0; i < 3; i++)
            {
                if (fields[0, i] == fields[1, i] && fields[1, i] == fields[2, i] && fields[0, i] != " ")
                {
                    return true;
                }
            }

            return false;
        }

        private static bool CrossWin()
        {
            if (((fields[0, 0] == fields[1, 1] && fields[1, 1] == fields[2, 2]) || (fields[2, 0] == fields[1, 1] && fields[1, 1] == fields[0, 2])) && fields[1, 1] != " ")
            {
                return true;
            }

            return false;
        }

        private static void SetInput()
        {
            if (player)
            {
                int playerField = GetPlayerInput();
                while (!IsAvailable(playerField))
                {
                    playerField = GetPlayerInput();
                }

                WriteInput(playerField);
            }
            else
            {
                GetComputerInput();
            }
        }

        private static int GetPlayerInput()
        {
            Console.Write("Choose your field: ");
            int playerInput = Int32.Parse(Console.ReadLine());
            return playerInput;
        }

        private static void GetComputerInput()
        {
            Random computerFieldRandomizer = new Random();
            int computerField = computerFieldRandomizer.Next(0, 9);
            while (!IsAvailable(computerField))
            {
                computerField = computerFieldRandomizer.Next(0, 9);
            }
            WriteInput(computerField);
        }

        private static void WriteInput(int field)
        {
            Console.WriteLine("\nThe currently selected field is " + field + " \n");
            availableFields[field] = false;

            if (field == 0 || field == 1 || field == 2)
            {
                fields[0, field] = WriteInField();
            }
            else
            {
                switch (field)
                {
                    case 3:
                        fields[1, 0] = WriteInField();
                        break;
                    case 4:
                        fields[1, 1] = WriteInField();
                        break;
                    case 5:
                        fields[1, 2] = WriteInField();
                        break;
                    case 6:
                        fields[2, 0] = WriteInField();
                        break;
                    case 7:
                        fields[2, 1] = WriteInField();
                        break;
                    case 8:
                        fields[2, 2] = WriteInField();
                        break;
                    default:
                        Console.WriteLine("Error. Impossible number entered.");
                        break;
                }
            }
        }

        private static string WriteInField()
        {
            return player ? "X" : "O";
        }

        private static bool IsAvailable(int field)
        {
            return availableFields[field];
        }

        private static void DrawGameBoard()
        {
            Console.WriteLine("");
            Console.WriteLine("Player: " + GetPlayerName());
            Console.WriteLine("\n Gameboard:");
            Console.WriteLine("-|---|---|---|-");
            Console.WriteLine("-| " + fields[0, 0] + " | " + fields[0, 1] + " | " + fields[0, 2] + " |-");
            Console.WriteLine("-|---|---|---|-");
            Console.WriteLine("-| " + fields[1, 0] + " | " + fields[1, 1] + " | " + fields[1, 2] + " |-");
            Console.WriteLine("-|---|---|---|-");
            Console.WriteLine("-| " + fields[2, 0] + " | " + fields[2, 1] + " | " + fields[2, 2] + " |-");
            Console.WriteLine("-|---|---|---|-");
            Console.WriteLine("\n");
        }

        private static string GetPlayerName()
        {
            return player ? "Player" : "Computer";
        }

        private static void ChangePlayer()
        {
            player = !player;
        }
    }
}

using System;

// ASCII 48 = DEC 0

namespace Tic_Tac_Toe_Local_Multiplayer
{
    class Program
    {
        // Variables
        private static char[,] fields = new char[3, 3];
        private static bool[] availableFields = new bool[9];
        private static bool player = true;
        private static int usedFields = 0;

        static void Main()
        {
            ResetFields();
            DrawStartBoard();

            // Gameloop
            while (!IsGameOver())
            {
                Console.WriteLine("______________________________\n");
                DrawGameBoard();
                SetInput();
                ChangePlayer();
            }

            DrawGameBoard();
            ChangePlayer();
            Console.WriteLine("The game is over! " + GetPlayerName() + " won!");
            Console.ReadLine();
        }

        private static void ResetFields()
        {
            for (int i = 0; i < 9; i++)
            {
                fields[i / 3, i % 3] = '\0';
                availableFields[i] = true;
            }
            usedFields = 0;
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

        private static char WriteInField() => player ? 'X' : 'O';
        private static string GetPlayerName() => player ? "Player 1" : "Player 2";
        private static bool AllFieldsUsed() => usedFields == 8;
        private static bool IsGameOver() => AllFieldsUsed() || HasWon();
        private static bool IsAvailable(int field) => availableFields[field];
        private static void ChangePlayer() => player = !player;

        private static bool HasWon()
        {
            if ((fields[0, 0] == fields[1, 1] && fields[1, 1] == fields[2, 2] && fields[1, 1] != '\0') /* First Cross */ ||
                    (fields[2, 0] == fields[1, 1] && fields[1, 1] == fields[0, 2] && fields[1, 1] != '\0') /* Second Cross */ ) return true;

            for (int i = 0; i < 3; i++)
            {
                if ((fields[i, 0] == fields[i, 1] && fields[i, 1] == fields[i, 2] && fields[i, 0] != '\0') /* Horizontal */ || 
                    (fields[0, i] == fields[1, i] && fields[1, i] == fields[2, i] && fields[0, i] != '\0') /* Vertical */ ) return true;
            }

            return false;
        }

        private static void SetInput()
        {
            int playerField = GetPlayerInput();
            while (!IsAvailable(playerField) || playerField < 0 || playerField > 8)
            {
                Console.WriteLine("You chose a field, that is not available.");
                playerField = GetPlayerInput();
            }

            WriteInput(playerField);
        }

        private static int GetPlayerInput()
        {     
            Console.Write(GetPlayerName() + ", choose your field: ");
            int playerInput = Int32.Parse(Console.ReadLine());
            return playerInput;
        }
        
        private static void WriteInput(int field)
        {
            availableFields[field] = false;
            fields[field / 3, field % 3] = WriteInField();
            usedFields++;
        }

        private static void DrawGameBoard()
        {
            Console.WriteLine("\nGameboard:");
            Console.WriteLine("-|---|---|---|-");
            Console.WriteLine("-| " + fields[0, 0] + " | " + fields[0, 1] + " | " + fields[0, 2] + " |-");
            Console.WriteLine("-|---|---|---|-");
            Console.WriteLine("-| " + fields[1, 0] + " | " + fields[1, 1] + " | " + fields[1, 2] + " |-");
            Console.WriteLine("-|---|---|---|-");
            Console.WriteLine("-| " + fields[2, 0] + " | " + fields[2, 1] + " | " + fields[2, 2] + " |-");
            Console.WriteLine("-|---|---|---|-");
            Console.WriteLine("");
        }
    }
}

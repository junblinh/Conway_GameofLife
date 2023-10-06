using System;
using System.Collections.Generic;
using System.Text;

namespace Life
{
    class CommandLineArguments
    {
        /// <summary>
        /// Check if the setting of parameter fits the criteria
        /// </summary>
        /// <param name="args">The arguments from the setting</param>
        /// <param name="i">length of the argmument</param>
        /// <param name="setting">type of setting of the game</param>
        /// <param name="numberParam">number of parameters</param>
        private static void ValidateParameter(string[] args, int i, string setting, int numberParam)
        {
            if (i > args.Length - numberParam)
            {
                throw new ArgumentException($"Insufficient parameters for \'--{setting}\' option " +
                    $"(provided {args.Length - i - 1}, expected {numberParam})");
            }
        }

        /// <summary>
        /// Processing the command line arguments
        /// </summary>
        /// <param name="args"></param>
        /// <returns>Parse the argument into the settings of the game</returns>
        public static GameSettings GetSetttings(string[] args)
        {
            GameSettings settings = new GameSettings();

            try
            {
                for (int ii = 0; ii < args.Length; ii++)
                {
                    switch (args[ii])
                    {
                        case "--dimensions":
                            GetDimension(args, ii, settings);
                            break;

                        case "--generations":
                            GetGenerations(args, ii, settings);
                            break;

                        case "--max-update":
                            GetUpdateRate(args, ii, settings);
                            break;

                        case "--random":
                            GetRandomFactor(args, ii, settings);
                            break;

                        case "--periodic":
                            settings.PeriodicMode = true;
                            break;

                        case "--step":
                            settings.StepMode = true;
                            break;

                        case "--seed":
                            GetInputFile(args, ii, settings);
                            break;

                        case "--ghost":
                            settings.GhostMode = true;
                            break;

                        case "--memory":
                            GetMemory(args, ii, settings);
                            break;

                        case "--survival":
                            GetSurvival(args, ii, settings);
                            break;

                        case "--birth":
                            GetBirth(args, ii, settings);
                            break;
                    }
                }

                Notifications.Success($"Command line arguments processed without issues.");
            }

            catch (FormatException exeption)
            {
                Notifications.Error(exeption.Message);
                Notifications.Changing("Get the values back to its valid type.");
            }

            catch (ArgumentException exeption)
            {
                Notifications.Error(exeption.Message);
                Notifications.Changing("Set up the values for not crashing.");
            }

            finally
            {
                Notifications.NotificationType("The following settings will be used:");
                Console.WriteLine(settings);
            }
            
            return settings;
        }

        private static void GetNeighbourType(string[] args, int ii, GameSettings setting)
        {
            ValidateParameter(args, ii, "neighbour", 3);

            bool success1 = Int32.TryParse(args[ii + 1], out int num1);
            bool success2 = Int32.TryParse(args[ii + 2], out int num2);
        }

        /// <summary>
        /// Getting values for the birth value setting
        /// </summary>
        /// <param name="args">The argument from command line</param>
        /// <param name="ii">Length of the argument</param>
        /// <param name="setting">Setting of the birth rule</param>
        private static void GetBirth(string[] args, int ii, GameSettings setting)
        {
            ValidateParameter(args, ii, "birth", 1);

            bool success = Int32.TryParse(args[ii + 1], out int numBirth);

            if (!success)
            {
                throw new FormatException($"Birth value should be an integer.");
            }

            setting.GameBirth = numBirth;
        }

        /// <summary>
        /// Getting values for the survival rule setting
        /// </summary>
        /// <param name="args">The argument from command line</param>
        /// <param name="ii">Length of the argument</param>
        /// <param name="setting">Setting of the survival rule</param>
        private static void GetSurvival(string[] args, int ii, GameSettings setting)
        {
            ValidateParameter(args, ii, "survival", 2);

            bool min = Int32.TryParse(args[ii + 1], out int numMin);
            bool max = Int32.TryParse(args[ii + 2], out int numMax);

            if (!min)
            {
                throw new FormatException("The value should be an integer.");
            }

            if (!max)
            {
                throw new FormatException("The value should be an integer.");
            }

            setting.FirstGameSurvival = numMin;
            setting.SecondGameSurvival = numMax;

        }

        /// <summary>
        /// Getting values for the dimensions of the game
        /// </summary>
        /// <param name="args">The argument from command line</param>
        /// <param name="ii">Length of the argument</param>
        /// <param name="setting">Settings of row and column values</param>
        private static void GetDimension(string[] args, int ii, GameSettings setting)
        {
            ValidateParameter(args, ii, "dimensions", 2);

            bool RowSuccess = Int32.TryParse(args[ii + 1], out int numRow);
            bool ColumnSuccess = Int32.TryParse(args[ii + 2], out int numColumn);

            if (!RowSuccess)
            {
                throw new FormatException($"Row value should be an integer.");
            }

            if (!ColumnSuccess)
            {
                throw new FormatException($"Column value should be an integer.");
            }

            setting.GameRow = numRow;
            setting.GameColumn = numColumn;         
        }

        /// <summary>
        /// Getting the value for generations
        /// </summary>
        /// <param name="args">The argument from command line</param>
        /// <param name="ii">Length of the argument</param>
        /// <param name="setting">Settings of number of generations</param>
        private static void GetGenerations(string[] args, int ii, GameSettings setting)
        {
            ValidateParameter(args, ii, "generations", 1);

            bool Success = Int32.TryParse(args[ii + 1], out int numGeneration);

            if (!Success)
            {
                throw new FormatException($"Generation value should be an integer.");
            }

            setting.GameGenerations = numGeneration;
        }

        /// <summary>
        /// Getting the value for random factor
        /// </summary>
        /// <param name="args">The argument from command line</param>
        /// <param name="ii">Length of the argument</param>
        /// <param name="setting">Settings of random factor value</param>
        private static void GetRandomFactor(string[] args, int ii, GameSettings setting)
        {
            ValidateParameter(args, ii, "random", 1);

            bool Success = float.TryParse(args[ii + 1], out float numRandom);

            if (!Success)
            {
                throw new FormatException($"Random factor should be a floating point.");
            }

            setting.GameRandomFactor = numRandom;
        }

        /// <summary>
        /// Getting the value for update rate
        /// </summary>
        /// <param name="args">The argument from command line</param>
        /// <param name="ii">Length of the argument</param>
        /// <param name="setting">Settings of update rate value</param>
        private static void GetUpdateRate(string[] args, int ii, GameSettings setting)
        {
            ValidateParameter(args, ii, "max-update", 1);

            bool Success = float.TryParse(args[ii + 1], out float numUpdateRate);

            if (!Success)
            {
                throw new FormatException($"Update rate should be a floating point.");
            }

            setting.GameUpdateRate = numUpdateRate;
        }

        /// <summary>
        /// Getting the input file 
        /// </summary>
        /// <param name="args">The argument from commmand line</param>
        /// <param name="ii">Length of the argument</param>
        /// <param name="setting">Settings from the input file</param>
        private static void GetInputFile(string[] args, int ii, GameSettings setting)
        {
            ValidateParameter(args, ii, "seed", 1);

            setting.InputFile = args[ii + 1];
        }

        /// <summary>
        /// Getting the memory of the game
        /// </summary>
        /// <param name="args">The argument from command line</param>
        /// <param name="ii">Length of the argument</param>
        /// <param name="setting">Settings from the input file</param>
        private static void GetMemory(string[] args, int ii, GameSettings setting)
        {
            ValidateParameter(args, ii, "memory", 1);

            bool Success = Int32.TryParse(args[ii + 1], out int numMemory);

            if (!Success)
            {
                throw new FormatException($"Memory should be an integer.");
            }

            setting.GameMemory = numMemory;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.IO;
using System.Text;

namespace Life
{
    // This GameSettings class is inspired by the Solution of Part 1
    // This GameSettings still uses all the values obtained from my work for Part 1
    // The reason is that I feel more comfortable using the variables in my way
    class GameSettings
    {
        private int gameRow = 16;
        private int gameColumn = 16;
        private const int MAXDIMENSION = 48;
        private const int MINDIMENSION = 4;

        private int numberGenerations = 50;
        private const int MINGENERATIONS = 1;
        
        private float randomFactor = 0.5f;
        private const float MAX_RANDOMFACTOR = 0f;
        private const float MIN_RANDOMFACTOR = 1f;

        private float updateRate= 5f;
        private const float MAX_UPDATERATE = 30f;
        private const float MIN_UPDATERATE = 1f;

        private string inputFile = null;

        private int gameMemory = 16;
        private const int MAX_MEMORY = 512;
        private const int MIN_MEMORY = 4;

        private int minGameSurvival = 2;
        private int maxGameSurvival = 3;
        private const int MINSURVIVAL = 0;

        private int gameBirth = 3;
        private const int MINBIRTH = 0;

        private string neighbourTypeDefault = "Moore";
        private string neighbourTypeVon = "Von Neumann";
        private int neighbourOrder = 1;
        private const int MINORDER = 1;
        private const int MAXORDER = 10;

        private string countCentre = null;
        private const string neighbourCountCentre = "ON";
        private const string neighbourNoCountCentre = "OFF";

        /// <summary>
        /// Setting the counting centre of the game
        /// </summary>
        public string GameCountCentre
        {
            get
            {
                countCentre = neighbourNoCountCentre;
                return countCentre;
            }
            set
            {
                if (value != "true" || value != "false")
                {
                    throw new ArgumentException($"Argument for counting centre should be true or false");
                }

                else if (value == "true")
                {
                    countCentre = neighbourCountCentre;
                }

                else if (value == "false")
                {
                    countCentre = neighbourNoCountCentre;
                }
            }
        }

        /// <summary>
        /// Setting the number of order in the game
        /// </summary>
        public int GameNeighbourOrder
        {
            get => neighbourOrder;
            set
            {
                // Remember to add the values for "less than half
                // of the smallest dimensions"
                if (value < MINORDER || value > MAXORDER)
                {
                    if (value < MINORDER)
                    {
                        neighbourOrder = MINORDER;
                        throw new ArgumentException($"The value will change to minimum value.");
                    }

                    else if (value > MAXORDER)
                    {
                        neighbourOrder = MAXORDER;
                        throw new ArgumentException($"The value will change to maximum value.");
                    }
                }

                neighbourOrder = value;
            }
        }
        

        /// <summary>
        /// Setting the type of neighbour for the game
        /// </summary>
        public string GameNeighbourType
        {
            get => neighbourTypeDefault;
            set
            {
                if (value != neighbourTypeVon)
                {
                    throw new ArgumentException($"The type should be either Moore or Von Neumann");
                }

                neighbourTypeDefault = value;
            }
        }

        /// <summary>
        /// Setting the first value for the survival rule
        /// </summary>
        public int FirstGameSurvival
        {
            get => minGameSurvival;
            set 
            {
                if (value < MINSURVIVAL)
                {
                    minGameSurvival = MINSURVIVAL;
                    throw new ArgumentException($"The value will change to minimum value");
                }

                minGameSurvival = value;
            }
        }

        /// <summary>
        /// Setting the second value for the survival rule
        /// </summary>
        public int SecondGameSurvival
        {
            get => maxGameSurvival;
            set
            {
                if (value < MINSURVIVAL)
                {
                    maxGameSurvival = MINSURVIVAL;
                    throw new ArgumentException($"The value will change to minimum value");
                }

                maxGameSurvival = value;
            }
        }

        /// <summary>
        /// Setting the value for the game's birth rule
        /// </summary>
        public int GameBirth
        { 
            get => gameBirth;
            set
            {
                if (value < MINBIRTH)
                {
                    gameBirth = MINBIRTH;
                    throw new ArgumentException($"The value will change to minimum value");
                }

                gameBirth = value;
            }
        }

        /// <summary>
        /// Setting the value for the game's row value
        /// </summary>
        public int GameRow
        {
            get => gameRow;
            set
            {
                if (value < MINDIMENSION || value > MAXDIMENSION)
                {
                    if (value < MINDIMENSION)
                    {
                        gameRow =  MINDIMENSION;
                        throw new ArgumentException($"The value will change to minimum value.");
                    }
                    
                    else if (value > MAXDIMENSION)
                    {
                        gameRow = MAXDIMENSION;
                        throw new ArgumentException($"The value will change to maximum value.");
                    }

                    //throw new ArgumentException($"The dimension of the game " +
                        //$"should be between 4 and 48 inclusively.");
                }

                gameRow = value;
            }
        
        }

        /// <summary>
        /// Setting the value for the game's column value
        /// </summary>
        public int GameColumn
        {
            get => gameColumn;
            set
            {
                if (value < MINDIMENSION || value > MAXDIMENSION)
                {
                    if (value < MINDIMENSION)
                    {
                        gameColumn = MINDIMENSION;
                        throw new ArgumentException($"The value will change to minimum value.");
                    }
                    
                    else if (value > MAXDIMENSION)
                    {
                        gameColumn = MAXDIMENSION;
                        throw new ArgumentException($"The value will change to maximum value.");
                    }

                    //throw new ArgumentException($"The dimension of the game " +
                        //$"should be between 4 and 48 inclusively.");
                }

                gameColumn = value;
            }

        }

        /// <summary>
        /// Setting the value of iteration in generations of the game
        /// </summary>
        public int GameGenerations
        {
            get => numberGenerations;
            set
            {
                if (value < MINGENERATIONS)
                {
                    numberGenerations = MINGENERATIONS;
                    throw new ArgumentException($"The minimum value for generations is 4.");
                }

                numberGenerations = value;
            }
        }

        /// <summary>
        /// Setting the random factor value for the game
        /// </summary>
        public float GameRandomFactor
        {
            get => randomFactor;
            set
            {
                if (value < MIN_RANDOMFACTOR || value > MAX_RANDOMFACTOR)
                {
                    if (value < MIN_RANDOMFACTOR)
                    {
                        randomFactor = MIN_RANDOMFACTOR;
                        throw new ArgumentException($"The value will change to minimum value.");
                    }

                    else if (value > MAX_RANDOMFACTOR)
                    {
                        randomFactor = MAX_RANDOMFACTOR;
                        throw new ArgumentException($"The value will change to maximum value.");
                    }

                    //throw new ArgumentException($"The value of random factor" +
                        //$" should be between 0 and 1 inclusively.");
                }

                randomFactor = value;
            }
        }

        /// <summary>
        /// Setting the update rate value for the game
        /// </summary>
        public float GameUpdateRate
        {
            get => updateRate;
            set
            {
                if (value < MIN_UPDATERATE || value > MAX_RANDOMFACTOR)
                {
                    if (value < MIN_UPDATERATE)
                    {
                        updateRate = MIN_UPDATERATE;
                        throw new ArgumentException($"The value will change to minimum value.");
                    }

                    else if (value > MAX_UPDATERATE)
                    {
                        updateRate = MAX_UPDATERATE;
                        throw new ArgumentException($"The value will change to maximum value.");
                    }

                    //throw new ArgumentException($"The value for update rate " +
                        //$"should be between 1 and 30 inclusively.");
                }

                updateRate = value;
            }
        }

        /// <summary>
        /// Setting the input file for the game
        /// </summary>
        public string InputFile
        {
            get => inputFile;
            set
            {
                if (!File.Exists(value))
                {
                    throw new ArgumentException($"File does not exist.");
                }
                
                if (!Path.GetExtension(value).Equals(".seed"))
                {
                    throw new ArgumentException($"Incompatible file extension \'{Path.GetExtension(value)}\'");
                }
                
                inputFile = value;
            }
        }

        public int GameMemory
        {
            get => gameMemory;
            set 
            {
                if (value < MIN_MEMORY || value > MAX_MEMORY)
                {
                    if (value < MIN_MEMORY)
                    {
                        gameMemory = MIN_MEMORY;
                        throw new ArgumentException($"The value will change to minimum value.");
                    }

                    else if (value > MAX_MEMORY)
                    {
                        gameMemory = MAX_MEMORY;
                        throw new ArgumentException($"The value will change to maximum value.");
                    }
                }

                gameMemory = value;
            }
        }

        /// <summary>
        /// Setting the periodic mode for the game
        /// </summary>
        public bool PeriodicMode { get; set; } = false;

        /// <summary>
        /// Setting the step mode for the game
        /// </summary>
        public bool StepMode { get; set; } = false;

        /// <summary>
        /// Setting the ghost mode for the game
        /// </summary>
        public bool GhostMode { get; set; } = false;

        /// <summary>
        /// Print out the settings of the game
        /// </summary>
        /// <returns>All settings for the game</returns>
        public override string ToString()
        {
            const int Formatting = 35;

            string output = "\n";

            output += "Input File: ".PadLeft(Formatting) + (InputFile != null ? InputFile : "N/A") + "\n";
            output += "Output File: ".PadLeft(Formatting) + "N/A\n";
            output += "Generations: ".PadLeft(Formatting) + $"{GameGenerations}\n";
            output += "Memory: ".PadLeft(Formatting) + $"{GameMemory}\n";
            output += "Update Rate: ".PadLeft(Formatting) + $"{GameUpdateRate} updates/s\n";
            output += "Rules: ".PadLeft(Formatting) + $"S({FirstGameSurvival}...{SecondGameSurvival})" +
                        " " + $"B( {GameBirth} )\n";
            output += "Neighbourhood: ".PadLeft(Formatting) + $"{GameNeighbourType} ({GameNeighbourOrder}) " +
                        $"Centre Count: {GameCountCentre}\n";
            output += "Periodic: ".PadLeft(Formatting) + (PeriodicMode ? "Yes" : "No") + "\n";
            output += "Rows: ".PadLeft(Formatting) + $"{GameRow}\n";
            output += "Columns: ".PadLeft(Formatting) + $"{GameColumn}\n";
            output += "Random Factor: ".PadLeft(Formatting) + $"{100 * GameRandomFactor:F2}%\n";
            output += "Step Mode: ".PadLeft(Formatting) + (StepMode ? "Yes" : "No") + "\n";
            output += "Ghost Mode: ".PadLeft(Formatting) + (GhostMode ? "Yes" : "No") + "\n";
            

            return output;
        }
    }
}

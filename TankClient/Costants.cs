using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TankClient
{
    public class Constants
    {
        public static string JOIN = "JOIN#";
        public static string UP = "UP#";
        public static string DOWN = "DOWN#";
        public static string LEFT = "LEFT#";
        public static string RIGHT = "RIGHT#";
        public static string SHOOT = "SHOOT#";

       

        public static string GAMESTARTED = "GAME_ALREADY_STARTED#";
        public static string NOTSTARTED = "GAME_NOT_STARTED_YET#";
        public static string GAMEOVER = "GAME_HAS_FINISHED#";
        public static string GAMEJUSTFINISHED = "GAME_FINISHED#";

        public static  string PLAYERSFULL = "PLAYERS_FULL#";
        public static  string ALREADYADDED = "ALREADY_ADDED#";

        public static  string INVALIDCELL = "INVALID_CELL#";
        public static  string NOTACONTESTANT = "NOT_A_VALID_CONTESTANT#";
        public static  string TOOEARLY = "TOO_QUICK#";
        public static  string CELLOCCUPIED = "CELL_OCCUPIED#";
        public static  string HITONOBSTACLE = "OBSTACLE#";
        public static  string FALLENTOPIT = "PITFALL#";

        public static string NOTALIVE = "DEAD#";

        public static string REQUESTERROR = "REQUEST_ERROR#";
        public static string SERVERERROR = "SERVER_ERROR#";

        public static int NORTH = 0;
        public static int EAST = 1;
        public static int SOUTH = 2;
        public static int WEST = 3;
    }
}

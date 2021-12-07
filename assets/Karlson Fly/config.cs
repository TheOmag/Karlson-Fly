using System.IO;

namespace config
{
    public class code
    {
        //Mod info
        public static string modVersion = "1.0.0";
        public static string modtitle = "Karlson Fly";

        //public vars

        public static bool InstantStop = false;
        public static bool InstantSlow = false;
        public static bool spaceBar = true;

        //file stuff
        public static string fileDirectory = "BepInEx\\config\\karlson Fly Config.txt";
        public static string[] fileRead = { "" };
        private static string[] fileWrite = new string[] { modtitle + " " + modVersion, "", "", "", "Speed", "50000", "", "Mult speed(when you press Shift+F)", "2", "", "Instant stop(When you stop flying)", "true", "", "For more check out my discord server(https://discord.com/invite/MyU9mBR352)" };
        public static void run()
        {
            if (!File.Exists(fileDirectory)) Create();
            readSet();
            if (File.Exists(fileDirectory))
            {
                if (fileRead[0] == modtitle + " " + modVersion)
                { }
                else
                {
                    DeleteFile(true, fileDirectory);
                }
            }
        }
        private static float x = 4000f;
        private static float y = 50000f;
        public static void configSetValues()
        {
            if (fileRead[0] == "")
            {
                readSet();
            }
            else
            {
                //speeds
                float.TryParse(fileRead[5], out x);
                float.TryParse(fileRead[8], out y);
                main.code.speed = x;
                main.code.MultSpeed = y;
                //other
                //spcaebar stop
                /*f (fileRead[17] == "false" || fileRead[17] == "false " || fileRead[17] == " false" || fileRead[17] == "false  " || fileRead[17] == " false " || fileRead[17] == "   false" || fileRead[17] == "False" || fileRead[17] == "False " || fileRead[17] == " False" || fileRead[17] == "False  " || fileRead[17] == " False " || fileRead[17] == "   False")
                {
                    spaceBar = false;
                }
                else if (fileRead[17] == "true" || fileRead[17] == "true " || fileRead[17] == " true" || fileRead[17] == "true  " || fileRead[17] == " true " || fileRead[17] == "   true" || fileRead[17] == "True" || fileRead[17] == "True " || fileRead[17] == " True" || fileRead[17] == "True  " || fileRead[17] == " True " || fileRead[17] == "   True")
                {
                    spaceBar = true;
                }
                instant slow*/
                if (fileRead[11] == "false" || fileRead[11] == "false " || fileRead[11] == " false" || fileRead[11] == "false  " || fileRead[11] == " false " || fileRead[11] == "   false" || fileRead[11] == "False" || fileRead[11] == "False " || fileRead[11] == " False" || fileRead[11] == "False  " || fileRead[11] == " False " || fileRead[11] == "   False")
                {
                    InstantStop = false;
                }
                else if (fileRead[11] == "true" || fileRead[11] == "true " || fileRead[11] == " true" || fileRead[11] == "true  " || fileRead[11] == " true " || fileRead[11] == "   true" || fileRead[11] == "True" || fileRead[11] == "True " || fileRead[11] == " True" || fileRead[11] == "True  " || fileRead[11] == " True " || fileRead[11] == "   True")
                {
                    InstantStop = true;
                }
                /*instant stop
                if (fileRead[11] == "false" || fileRead[14] == "false " || fileRead[14] == " false" || fileRead[14] == "false  " || fileRead[14] == " false " || fileRead[14] == "   false" || fileRead[14] == "False" || fileRead[14] == "False " || fileRead[14] == " False" || fileRead[14] == "False  " || fileRead[14] == " False " || fileRead[14] == "   False")
                {
                    InstantStop = false;
                }
                else if (fileRead[14] == "true" || fileRead[14] == "true " || fileRead[14] == " true" || fileRead[14] == "true  " || fileRead[14] == " true " || fileRead[14] == "   true" || fileRead[14] == "True" || fileRead[14] == "True " || fileRead[14] == " True" || fileRead[14] == "True  " || fileRead[14] == " True " || fileRead[14] == "   True")
                {
                    InstantStop = true;
                }*/
            }
        }
        public static void readSet()
        {
            fileRead = File.ReadAllLines(fileDirectory);
        }
        public static void Create()
        {
            File.WriteAllLines(fileDirectory, fileWrite);
            readSet();
        }
        public static void DeleteFile(bool remakeFile, string fileDirect)
        {
            File.Delete(fileDirect);
            if (remakeFile) Create();
        }
    }
}
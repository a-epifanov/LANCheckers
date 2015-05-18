using System;
using System.IO;
using System.Drawing;
using Checkers;
using Checkers_3D;


namespace Shared
{
    public class PlayerData
    {
        public string Name;
        public Image UserImage;
    }

    public class SharedCode
    {

        public static readonly Guid ApplicationGuid = new Guid
(0xa1cacd73, 0xc43a, 0x403e, 0xba, 0xec, 0x3, 0x5, 0x66, 0x59, 0x4a, 0xe7);
        public const int DataPort = 9797;


        public static PlayerData CurrentPlayer = new PlayerData();


        public static PlayerData EnemyPlayer = new PlayerData();
        

        public enum NetworkMessages
        {
            Image,
            MainPlayer,
            LeftMouseDown,
            LeftMouseUp
        }
    }
}

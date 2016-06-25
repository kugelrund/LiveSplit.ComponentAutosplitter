using System;
using System.Diagnostics;

namespace LiveSplit.ComponentAutosplitter
{
    abstract class Game
    {
        public abstract Type[] EventTypes { get; }

        public abstract string Name { get; }
        public abstract string ProcessName { get; }

        public virtual GameEvent ReadLegacyEvent(string id)
        {
            return new EmptyEvent();
        }
    }

    partial class GameInfo
    {
        private Process gameProcess;
        private IntPtr baseAddress;

        public Process GameProcess => gameProcess;
        public bool InGame { get; protected set; }

        public GameInfo(Process gameProcess)
        {
            this.gameProcess = gameProcess;
            baseAddress = gameProcess.MainModule.BaseAddress;
        }

        public void Update()
        {
            UpdateInfo();
        }

        partial void UpdateInfo();
    }

    abstract class GameEvent
    {
        public abstract string[] AttributeNames { get; }
        public abstract string[] AttributeValues { get; protected set; }
        public abstract string Description { get; }

        public abstract bool HasOccured(GameInfo info);
    }

    abstract class MapEvent : GameEvent
    {
        private static readonly string[] attributeNames = { "Map" };

        public override string[] AttributeNames => attributeNames;
        public override string[] AttributeValues { get; protected set; }

        protected readonly string map;

        public MapEvent()
        {
            map = "";
            AttributeValues = new string[] { "" };
        }

        public MapEvent(string map)
        {
            if (map.EndsWith(".bsp"))
            {
                this.map = map;
            }
            else
            {
                this.map = map + ".bsp";
            }

            AttributeValues = new string[] { this.map };
        }
    }

    class EmptyEvent : GameEvent
    {
        private static readonly string[] attributeNames = new string[0] { };
        private static string[] attributeValues = new string[0] { };

        public override string[] AttributeNames => attributeNames;
        public override string[] AttributeValues
        {
            get { return attributeValues; }
            protected set { attributeValues = value; }
        }
        public override string Description => "No event";

        public override bool HasOccured(GameInfo info)
        {
            return false;
        }

        public override string ToString()
        {
            return "";
        }
    }
}

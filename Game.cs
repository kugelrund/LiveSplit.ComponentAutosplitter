using System;
using System.Diagnostics;

namespace LiveSplit.ComponentAutosplitter
{
    public abstract class Game
    {
        public abstract Type[] EventTypes { get; }
        public abstract Type InfoType { get; }
        public abstract string Name { get; }
        public abstract string ProcessName { get; }
    }

    public abstract class GameInfo
    {
        private Process gameProcess;

        public Process GameProcess => gameProcess;
        public bool PauseGameTime { get; private set; }

        public GameInfo(Process gameProcess)
        {
            this.gameProcess = gameProcess;
        }

        public abstract void Update();
    }

    public abstract class GameEvent
    {
        public abstract string[] AttributeNames { get; }
        public abstract string[] AttributeValues { get; protected set; }
        
        public abstract bool HasOccured(GameInfo info);
    }

    public class EmptyEvent : GameEvent
    {
        private static readonly string[] attributeNames = new string[0] { };
        private static string[] attributeValues = new string[0] { };

        public override string[] AttributeNames => attributeNames;
        public override string[] AttributeValues
        {
            get { return attributeValues; }
            protected set { attributeValues = value; }
        }

        public override bool HasOccured(GameInfo info)
        {
            return false;
        }
    }
}

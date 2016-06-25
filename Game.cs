using System;
using System.Diagnostics;

namespace LiveSplit.ComponentAutosplitter
{
    abstract class Game
    {
        public abstract Type[] EventTypes { get; }

        public abstract string Name { get; }
        public abstract string ProcessName { get; }
    }

    partial class GameInfo
    {
        private Process gameProcess;

        public Process GameProcess => gameProcess;
        public bool InGame { get; protected set; }
    }

    abstract class GameEvent
    {
        public abstract string[] AttributeNames { get; }
        public abstract string[] AttributeValues { get; protected set; }
        public abstract string Description { get; }

        public abstract bool HasOccured(GameInfo info);
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

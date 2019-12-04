using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

namespace Messages
{
    public enum MessageType
    {
        Hello,
        Movement,
        Entity_Create,
        Entity_Destroy
    }

    public class EntityCreate : MessageBase
    {
        public Guid id;

        public EntityCreate() { }
        public EntityCreate(Guid id)
        {
            this.id = id;
        }

        public override void Serialize(NetworkWriter writer)
        {
            base.Serialize(writer);
            writer.Write(id.ToString());
        }

        public override void Deserialize(NetworkReader reader)
        {
            base.Deserialize(reader);
            id = Guid.Parse(reader.ReadString());
        }
    }

    public class EntityDestroy : MessageBase
    {
        public Guid id;

        public EntityDestroy() { }
        public EntityDestroy(Guid id)
        {
            this.id = id;
        }

        public override void Serialize(NetworkWriter writer)
        {
            base.Serialize(writer);
            writer.Write(id.ToString());
        }

        public override void Deserialize(NetworkReader reader)
        {
            base.Deserialize(reader);
            id = Guid.Parse(reader.ReadString());
        }
    }

    public class Hello : MessageBase
    {
        public string message;
        public Hello()
        {

        }
        public Hello(string message)
        {
            this.message = message;
        }

        public override void Deserialize(NetworkReader reader)
        {
            base.Deserialize(reader);
            message = reader.ReadString();
        }

        public override void Serialize(NetworkWriter writer)
        {
            base.Serialize(writer);
            writer.Write(message);
        }
    }

    public class HelloFromServer : MessageBase
    {
        public int id;

        public HelloFromServer()
        {

        }

        public HelloFromServer(int id)
        {
            this.id = id;
        }

        public override void Deserialize(NetworkReader reader)
        {
            base.Deserialize(reader);
            id = reader.ReadInt32();
        }

        public override void Serialize(NetworkWriter writer)
        {
            base.Serialize(writer);
            writer.Write(id);
        }
    }

    public class MovementInput : MessageBase
    {
        public Vector3 input;

        public MovementInput()
        {

        }

        public MovementInput(Vector3 input)
        {
            this.input = input;
        }

        public override void Serialize(NetworkWriter writer)
        {
            base.Serialize(writer);
            writer.Write(input);
        }

        public override void Deserialize(NetworkReader reader)
        {
            base.Deserialize(reader);
            this.input = reader.ReadVector3();
        }
    }

    public class Positions : MessageBase
    {
        public List<int> ids;
        public List<Vector3> positions;

        public Positions()
        {
            ids = new List<int>();
            positions = new List<Vector3>();
        }

        public override void Serialize(NetworkWriter writer)
        {
            base.Serialize(writer);
            writer.Write(ids.Count);
            ids.ForEach(id => writer.Write(id));
            positions.ForEach(position => writer.Write(position));
        }

        public override void Deserialize(NetworkReader reader)
        {
            base.Deserialize(reader);
            var idc = reader.ReadInt32();
            for (int i = 0; i < idc; i++)
                ids.Add(reader.ReadInt32());
            for (int i = 0; i < idc; i++)
                positions.Add(reader.ReadVector3());
        }
    }
}
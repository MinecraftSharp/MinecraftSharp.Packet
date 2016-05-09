//
// All data is from http://wiki.vg/Protocol
// Thank you #mcdevs
//
using System;

namespace MinecraftSharp.Packet
{
    public enum PacketID
    {
        /// <summary>
        /// Causes server to switch into target state
        /// </summary>
        [PacketData(PacketDirection.Serverbound, PacketState.Handshaking)]
        Handshaking = 0x00,

        /// <summary>
        /// Legacy clients may send this packet to initiate Server List Ping
        /// Should be handled correctly
        /// </summary>
        [Obsolete]
        [PacketData(PacketDirection.Serverbound, PacketState.Handshaking, true)]
        LegacyServerListPing = 0xFE,

        /// <summary>
        /// Sent by server when a vehicle or other object is created
        /// </summary>
        [PacketData(PacketDirection.Clientbound, PacketState.Play)]
        SpawnObject = 0x00,

        /// <summary>
        /// Spawns one or more experience orbs
        /// </summary>
        [PacketData(PacketDirection.Clientbound, PacketState.Play)]
        SpawnExperienceOrb = 0x01,

        /// <summary>
        /// Server notifies the client of thunderbolts striking within a 512 block radius around the player
        /// The coordinates specify where exactly the thunderbolt strikes
        /// </summary>
        [PacketData(PacketDirection.Clientbound, PacketState.Play)]
        SpawnGlobalEntity = 0x02,

        /// <summary>
        /// Sent when a mob entity is spawned
        /// </summary>
        [PacketData(PacketDirection.Clientbound, PacketState.Play)]
        SpawnMob = 0x03,

        /// <summary>
        /// Shows location, name and type of painting
        /// </summary>
        [PacketData(PacketDirection.Clientbound, PacketState.Play)]
        SpawnPainting = 0x04,

        /// <summary>
        /// Send when a player is in visiable range
        /// </summary>
        [PacketData(PacketDirection.Clientbound, PacketState.Play)]
        SpawnPlayer = 0x05,

        /// <summary>
        /// Sent when an entity should change animation
        /// </summary>
        [PacketData(PacketDirection.Clientbound, PacketState.Play)]
        Animation = 0x06,
    }

    public enum Animations
    {
        SwingMainArm = 0,
        TakeDamage = 1,
        LeaveBed = 2,
        SwingOffhand = 3,
        CriticalEffect = 4,
        MagicCriticalEffect = 5
    }

    public enum PacketState
    {
        Handshaking,
        Play
    }

    public enum PacketDirection
    {
        Serverbound = 0,
        Clientbound = 1
    }


    public class PacketData : Attribute
    {
        public PacketDirection PacketDirection { get; }
        public PacketState PacketState { get; }
        public bool ObsoletePacket { get; }

        public PacketData(PacketDirection direction, PacketState state, bool obsolete = false)
        {
            PacketDirection = direction;
            PacketState = state;
            ObsoletePacket = obsolete;
        }
    }
}

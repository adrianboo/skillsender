using System;

namespace Enhance
{
  internal class Client
  {
    private const int RBA = 13067820;
    private IntPtr pHandle;
    private Memory Mem;
    private PacketSender pSender;
    private Packet skillPkt;
    private Packet cskillPkt;
    private Packet finishPkt;

    private int GamePtr
    {
      get
      {
        return this.Mem.ReadInt32(this.Mem.ReadInt32(13085644) + 44);
      }
    }

    private int CharPtr
    {
      get
      {
        return this.Mem.ReadInt32(this.GamePtr + 48);
      }
    }

    private int ActionPtr
    {
      get
      {
        return this.Mem.ReadInt32(this.CharPtr + 5040);
      }
    }

    public uint UID
    {
      get
      {
        return this.Mem.ReadUInt32(this.CharPtr + 1172);
      }
    }

    public string Name
    {
      get
      {
        return this.Mem.ReadUnicode(this.Mem.ReadInt32(this.CharPtr + 1712));
      }
    }

    public int QueuePtr
    {
      get
      {
        return this.Mem.ReadInt32(this.ActionPtr + 48);
      }
    }

    public int QueueType
    {
      get
      {
        return this.Mem.ReadInt32(this.QueuePtr + 12);
      }
    }

    public uint QueueTarget
    {
      get
      {
        return this.Mem.ReadUInt32(this.Mem.ReadInt32(this.QueuePtr + 1868) + 8);
      }
    }

    public int QueueSkillPtr
    {
      get
      {
        return this.Mem.ReadInt32(this.QueuePtr + 52);
      }
    }

    public int QueueSkillID
    {
      get
      {
        return this.Mem.ReadInt32(this.QueueSkillPtr + 8);
      }
    }

    public byte QueueSkillType
    {
      get
      {
        return (byte) this.Mem.ReadInt32(this.Mem.ReadInt32(this.Mem.ReadInt32(this.QueueSkillPtr + 4) + 4) + 28);
      }
    }

    public byte QueueSkillCType
    {
      get
      {
        return (byte) this.Mem.ReadInt32(this.Mem.ReadInt32(this.Mem.ReadInt32(this.QueueSkillPtr + 4) + 4) + 87);
      }
    }

    public int SkillPtr
    {
      get
      {
        return this.Mem.ReadInt32(this.CharPtr + 5020);
      }
    }

    public bool Charging
    {
      get
      {
        return (int) this.Mem.ReadByte(this.SkillPtr + 36) == 1;
      }
    }

    public bool CurrentSkillCooldown
    {
      get
      {
        return this.Mem.ReadInt32(this.SkillPtr + 16) > 0;
      }
    }

    public int CurrentSkillCastTime
    {
      get
      {
        return this.Mem.ReadInt32(this.Mem.ReadInt32(this.Mem.ReadInt32(this.Mem.ReadInt32(this.Mem.ReadInt32(this.SkillPtr + 4) + 4)) + 36) + 1);
      }
    }

    public int LatestPing
    {
      get
      {
        return this.Mem.ReadInt32(this.GamePtr + 376);
      }
    }

    private byte ProtectionSettings
    {
      get
      {
        int num1 = this.Mem.ReadInt32(this.Mem.ReadInt32(13085644) + 24);
        if ((int) (byte) this.Mem.ReadInt32(num1 + 642) == 0)
          return 0;
        byte num2 = 1;
        if ((int) (byte) this.Mem.ReadInt32(num1 + 643) != 0)
          num2 = (byte) 3;
        if ((int) (byte) this.Mem.ReadInt32(num1 + 644) != 0)
          num2 |= (byte) 4;
        if ((int) (byte) this.Mem.ReadInt32(num1 + 651) != 0)
          num2 |= (byte) 8;
        if ((int) (byte) this.Mem.ReadInt32(num1 + 654) != 0)
          num2 |= (byte) 16;
        return num2;
      }
    }

    public Client(IntPtr pHandle)
    {
      this.pHandle = pHandle;
      this.Mem = new Memory(pHandle);
      this.pSender = new PacketSender(this.Mem);
    }

    public void FinishTakeAim()
    {
      this.Mem.Write(this.SkillPtr + 36, (object) (byte) 0);
      this.SendPacket(this.FinishPkt());
    }

    public Packet SkillPkt(int ID, uint target)
    {
      if (this.skillPkt == null)
        this.skillPkt = new Packet((short) 41, 12);
      if (this.skillPkt.Address == 0)
        this.skillPkt.Address = this.Mem.Allocate(4);
      if (this.Mem.ReadInt32(this.skillPkt.Address) == 0)
        this.Mem.Write(this.skillPkt.Address, (object) this.skillPkt.Pkt);
      this.Mem.Write(this.skillPkt.Address + 2, (object) ID, true);
      this.Mem.Write(this.skillPkt.Address + 6, (object) this.ProtectionSettings);
      this.Mem.Write(this.skillPkt.Address + 7, (object) (byte) 1);
      this.Mem.Write(this.skillPkt.Address + 8, (object) target, true);
      return this.skillPkt;
    }

    public Packet cSkillPkt(int ID, uint target)
    {
      if (this.cskillPkt == null)
        this.cskillPkt = new Packet((short) 80, 12);
      if (this.cskillPkt.Address == 0)
        this.cskillPkt.Address = this.Mem.Allocate(4);
      if (this.Mem.ReadInt32(this.cskillPkt.Address) == 0)
        this.Mem.Write(this.cskillPkt.Address, (object) this.cskillPkt.Pkt);
      this.Mem.Write(this.cskillPkt.Address + 2, (object) ID, true);
      this.Mem.Write(this.cskillPkt.Address + 6, (object) this.ProtectionSettings);
      this.Mem.Write(this.cskillPkt.Address + 7, (object) (byte) 1);
      this.Mem.Write(this.cskillPkt.Address + 8, (object) target, true);
      return this.cskillPkt;
    }

    public Packet FinishPkt()
    {
      if (this.finishPkt == null)
        this.finishPkt = new Packet((short) 51, 2);
      if (this.finishPkt.Address == 0)
        this.finishPkt.Address = this.Mem.Allocate((int) this.finishPkt.Size);
      if (this.Mem.ReadInt32(this.finishPkt.Address) == 0)
        this.Mem.Write(this.finishPkt.Address, (object) this.finishPkt.Pkt);
      return this.finishPkt;
    }

    public void SendPacket(Packet packet)
    {
      this.pSender.SendPacket(packet);
    }
  }
}

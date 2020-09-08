// Decompiled with JetBrains decompiler
// Type: Enhance.Packet
// Assembly: Enhance, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DC90F2AF-9765-4FB8-9E9D-C598AA50E670
// Assembly location: C:\Users\Vand\AppData\Roaming\Skype\My Skype Received Files\Enhance.exe

using System;
using System.Collections.Generic;
using System.Linq;

namespace Enhance
{
  public class Packet
  {
    internal byte[] Pkt;
    internal int Address;

    internal byte Size
    {
      get
      {
        return (byte) this.Pkt.Length;
      }
    }

    public Packet(short header, int size)
    {
      this.Pkt = new byte[size];
      byte[] bytes = BitConverter.GetBytes(header);
      ((IEnumerable<byte>) bytes).Reverse<byte>();
      Buffer.BlockCopy((Array) bytes, 0, (Array) this.Pkt, 0, 2);
    }
  }
}

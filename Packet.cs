
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

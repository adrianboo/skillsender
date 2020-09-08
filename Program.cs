// Decompiled with JetBrains decompiler
// Type: Enhance.Program
// Assembly: Enhance, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: DC90F2AF-9765-4FB8-9E9D-C598AA50E670
// Assembly location: C:\Users\Vand\AppData\Roaming\Skype\My Skype Received Files\Enhance.exe

using System;
using System.Windows.Forms;

namespace Enhance
{
  internal static class Program
  {
    [STAThread]
    private static void Main()
    {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      using (Window window = new Window())
        Application.Run((Form) window);
    }
  }
}

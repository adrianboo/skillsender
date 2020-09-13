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

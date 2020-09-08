using System;

namespace Enhance
{
  public class ClientEventArgs : EventArgs
  {
    public string Name;
    public string Class;

    public ClientEventArgs(string name, int _class, int level)
    {
      this.Name = name;
      string str = "";
      switch (_class)
      {
        case 0:
          str = "Blademaster";
          break;
        case 1:
          str = "Wizard";
          break;
        case 2:
          str = "Psychic";
          break;
        case 3:
          str = "Venomancer";
          break;
        case 4:
          str = "Barbarian";
          break;
        case 5:
          str = "Assassin";
          break;
        case 6:
          str = "Archer";
          break;
        case 7:
          str = "Cleric";
          break;
        case 8:
          str = "Seeker";
          break;
        case 9:
          str = "Mystic";
          break;
         case 10:
           str = "Duskblade";
           break;
         case 11:
            str = "Stormbringer";
            break;
            }
      this.Class = str + " Lv. " + (object) level;
    }
  }
}

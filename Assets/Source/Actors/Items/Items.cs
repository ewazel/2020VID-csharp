using Assets.Source.Core;
using DungeonCrawl;
using DungeonCrawl.Actors.Characters;
using Source.Actors.Static;
using Source.Core;
using UnityEngine;

namespace Source.Actors.Items
{
  public class Mask : Item
  {
    private string wearingMessage;
    private string usedMessage;
    private const int StepMax = 50;
    private int _stepCounter;


    public Mask()
    {
      wearingMessage = $"Your mask will protect you for {_stepCounter} steps.";
      usedMessage = "Your mask is already used!";
      _stepCounter = StepMax;
    }

    public override void PickUp()
    {
      base.PickUp();
      Player.Singleton.WearingMask = true;
    }

    public override void Use()
    {
      _stepCounter--;
      wearingMessage = $"Your mask will protect you\nfor {_stepCounter} steps.";
      UserInterface.Singleton.SetText(wearingMessage, UserInterface.TextPosition.BottomRight);
      if (_stepCounter == 0)
      {
        ThrowAway();
      }
    }

    private void ThrowAway()
    {
      Player.Singleton.WearingMask = false;
      //UserInterface.Singleton.SetText("", UserInterface.TextPosition.MiddleLeft);
      UserInterface.Singleton.SetText(usedMessage, UserInterface.TextPosition.BottomRight);
      Player.inventory.Remove(this);
      Player.Singleton.PrintInventory();
    }


    public override int DefaultSpriteId => 181;
    public override string DefaultName => "Mask";
  }

  public class DirtyMask : Item
  {
    private string Message;

    public DirtyMask()
    {
      Message = " ";
    }
    
    public override void Use()
    {
      // Michał do użycia kiedy walczy
    }
    
    public override int DefaultSpriteId => 180;
    public override string DefaultName => "DirtyMask";
  }

public class ChipVaccine : Item
  {
    private string Message;

    public ChipVaccine()
    {
      Message = "YOU WON THE GAME!";
    }

    public override void Use()
    {
      UserInterface.Singleton.SetText(Message, UserInterface.TextPosition.MiddleCenter);
      Application.Quit();
    }

    public override int DefaultSpriteId => 993;
    public override string DefaultName => "ChipVaccine";
  }

  public class AntibacterialGel : Item
  {
    private int Value;
    private string Message;
    public AntibacterialGel()
    {
      Value = -20;
      Message = "You're disinfected!";
    }
    
    public override void Use()
    {
      Heal(Value, Message);
    }
    public override int DefaultSpriteId => 944;
    public override string DefaultName => "AntibacterialGel";
  }
    
  public class Vaccine: Item
  {
    private int Value;
    private string Message;
    protected Vaccine()
    {
      Value = -50;
      Message = "Vaccinated successfully!";
    }
    
    public override void Use()
    {
      Heal(Value, Message);
    }
  
    public override int DefaultSpriteId => 993;
    public override string DefaultName => "Vaccine";
  }
  
  public class Key: Item
  {
    private string Message;
    protected Key()
    {
      Message = "The gate is open!";
    }
    
    public override void Use()
    {
      var doorAtPosition = ActorManager.Singleton.GetActorAt<Door>(Player.Singleton.Position);
      
      Player.inventory.Remove(this);
      UserInterface.Singleton.SetText(Message, UserInterface.TextPosition.MiddleLeft);
      Player.Singleton.PrintInventory();
      doorAtPosition.Open();
    }
  
    public override int DefaultSpriteId => 561;
    public override string DefaultName => "Key";
  }
}
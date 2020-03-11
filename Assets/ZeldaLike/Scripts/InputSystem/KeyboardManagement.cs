using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardManagement : MonoBehaviour
{
    private Command[] buttons;
    Stack<Command> commandHistory;
    
    void Awake()
    {
        buttons = new Command[10];
        for (int i = 0; i < buttons.Length; i++){
            buttons[i] = new EmptyCommand();    
        }
        commandHistory = new Stack<Command>();
    }
    
    public void setCommand(int number, Command command){
        buttons[number] = command;
    }

    public void Execute(int number){
        buttons[number].Execute();
        commandHistory.Push(buttons[number]);
    }
    public void Undo(int number){
       if (commandHistory.Count > 0){
           Command command = commandHistory.Pop();
           command.Undo();
       }
    }
    
}

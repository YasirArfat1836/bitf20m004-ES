using System;

// Command interface
interface ICommand
{
    void Execute();
}

// Concrete Commands
class LightOnCommand : ICommand
{
    private readonly Light light;

    public LightOnCommand(Light light)
    {
        this.light = light;
    }

    public void Execute()
    {
        light.TurnOn();
    }
}

class LightOffCommand : ICommand
{
    private readonly Light light;

    public LightOffCommand(Light light)
    {
        this.light = light;
    }

    public void Execute()
    {
        light.TurnOff();
    }
}

// Receiver
class Light
{
    public void TurnOn()
    {
        Console.WriteLine("Light is ON");
    }

    public void TurnOff()
    {
        Console.WriteLine("Light is OFF");
    }
}

// Invoker
class RemoteControl
{
    private ICommand command;

    public void SetCommand(ICommand command)
    {
        this.command = command;
    }

    public void PressButton()
    {
        command.Execute();
    }
}



// Command interface
interface ITextCommand
{
    void Execute();
}

// Concrete Commands
class InsertCommand : ITextCommand
{
    private readonly TextEditor textEditor;
    private readonly string text;

    public InsertCommand(TextEditor textEditor, string text)
    {
        this.textEditor = textEditor;
        this.text = text;
    }

    public void Execute()
    {
        textEditor.InsertText(text);
    }
}

class DeleteCommand : ITextCommand
{
    private readonly TextEditor textEditor;
    private readonly int length;

    public DeleteCommand(TextEditor textEditor, int length)
    {
        this.textEditor = textEditor;
        this.length = length;
    }

    public void Execute()
    {
        textEditor.DeleteText(length);
    }
}

// Receiver
class TextEditor
{
    private string content = "";

    public void InsertText(string text)
    {
        content += text;
        Console.WriteLine($"Inserted: '{text}'");
    }

    public void DeleteText(int length)
    {
        if (length <= content.Length)
        {
            string deletedText = content.Substring(content.Length - length);
            content = content.Substring(0, content.Length - length);
            Console.WriteLine($"Deleted: '{deletedText}'");
        }
        else
        {
            Console.WriteLine("Cannot delete more characters than available.");
        }
    }

    public void PrintContent()
    {
        Console.WriteLine($"Current Content: '{content}'");
    }
}

// Invoker
class TextEditorInvoker
{
    private List<ITextCommand> commandHistory = new List<ITextCommand>();

    public void ExecuteCommand(ITextCommand command)
    {
        command.Execute();
        commandHistory.Add(command);
    }

    public void UndoLastCommand()
    {
        if (commandHistory.Count > 0)
        {
            var lastCommand = commandHistory[commandHistory.Count - 1];
            lastCommand.Execute(); // Implementing undo logic depends on the specific command
            commandHistory.RemoveAt(commandHistory.Count - 1);
        }
        else
        {
            Console.WriteLine("No command to undo.");
        }
    }
}



//class Program
//{
//    static void Main()
//    {
//        // Example 1: Simple Remote Control

//        Light livingRoomLight = new Light();

//        ICommand livingRoomLightOn = new LightOnCommand(livingRoomLight);
//        ICommand livingRoomLightOff = new LightOffCommand(livingRoomLight);

//        RemoteControl remote = new RemoteControl();

//        remote.SetCommand(livingRoomLightOn);
//        remote.PressButton();

//        remote.SetCommand(livingRoomLightOff);
//        remote.PressButton();

//        Console.WriteLine("\n----------------\n");

//        // Example 2: Text Editor Commands

//        TextEditor textEditor = new TextEditor();
//        TextEditorInvoker editorInvoker = new TextEditorInvoker();

//        ITextCommand insertCommand = new InsertCommand(textEditor, "Hello, ");
//        ITextCommand deleteCommand = new DeleteCommand(textEditor, 3);

//        editorInvoker.ExecuteCommand(insertCommand);
//        editorInvoker.ExecuteCommand(deleteCommand);

//        textEditor.PrintContent(); // Output: 'Hello'

//        editorInvoker.UndoLastCommand();
//        textEditor.PrintContent(); // Output: ''
//    }
//}

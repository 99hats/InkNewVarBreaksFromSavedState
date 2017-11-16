using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ink.Runtime;

namespace InkNewVarBreaksFromSavedState
{
  class Program
  {
    const string stateFileName = "state.json";
    private const string storyFileName = "story.json";

    static void Main(string[] args)
    {

      // init ink
      string storyJson = File.ReadAllText(storyFileName, Encoding.UTF8);
      var _inkStory = new Story(storyJson);

      
      // access global variable
      //var foo = _inkStory.variablesState["Foo"];

      // read state
      if (File.Exists(stateFileName))
      {
        string stateJson = File.ReadAllText(stateFileName, Encoding.UTF8);
        _inkStory.state.LoadJson(stateJson);
      }

      // run ink
      Console.WriteLine(_inkStory.ContinueMaximally());
      Console.WriteLine();
      Console.WriteLine("Now uncomment line 25 of Program.cs and uncomment the global variable on line 1 of story.ink. Don't forget to export story.json");

      // user presses key
      Console.ReadLine();
      
      // save state
      using (var fileStream = File.CreateText(stateFileName))
      {
        // write to just created file
        fileStream.Write(_inkStory.state.ToJson());
      }

    }
  }
}

// Program.cs

using System;
using System.Collections.Generic;
using System.Reflection;

class Program
{
    static void Main(string[] args)
    {
        // Ai helped me format the scripture to make it look good when displayed in the terminal
        List<Scripture> scriptures = new List<Scripture> 
{
    new Scripture(
        "Alma", 
        5, 
        27, 
        @"Have ye walked, keeping yourselves blameless before God? 
Could ye say, if ye were called to die at this time, within yourselves, 
that ye have been sufficiently humble? That your garments have been cleansed 
and made white through the blood of Christ, who will come to redeem his people 
from their sins?"),

    new Scripture(
        "Jacob", 
        9, 
        21, 
        @"O then, my beloved brethren, come unto the Lord, the Holy One. 
Remember that his paths are righteous. Behold, the way for man is narrow, 
but it lieth in a straight course before him, and the keeper of the gate 
is the Holy One of Israel; and he employeth no servant there; and there 
is none other way save it be by the gate; for he cannot be deceived, 
for the Lord God is his name."),

    new Scripture(
        "3 Nephi", 
        11, 
        10, 
        11, 
        @"Behold, I am Jesus Christ, whom the prophets testified shall come into the world. 
And behold, I am the light and the life of the world; and I have drunk out of that 
bitter cup which the Father hath given me, and have glorified the Father in taking 
upon me the sins of the world, in the which I have suffered the will of the Father 
in all things from the beginning.")
};


        while (true)
        {
            Console.Clear();
            Console.WriteLine("Select a scripture to practice:");

            for (int i = 0; i < scriptures.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {scriptures[i].GetScriptureReference()}");
            }

            Console.WriteLine("Type the number of the scripture that you want to memorize or type 'quit' to exit:");
            string userInput = Console.ReadLine();

            if (userInput.ToLower() == "quit")
            {
                break;
            }

            if (int.TryParse(userInput, out int scriptureIndex) && scriptureIndex > 0 && scriptureIndex <= scriptures.Count)
            {
                PracticeScripture(scriptures[scriptureIndex - 1]);
            }
        }
    }

    static void PracticeScripture(Scripture scripture)
    {
        int enterCount = 0;

        while (true)
        {
            Console.Clear();
            scripture.ShowScripture();
            int wordsRemaining = CountVisibleWords(scripture);
            Console.WriteLine($"\nNumber of times you pressed enter: {enterCount}");
            Console.WriteLine($"Number of words not hidden: {wordsRemaining}");
            Console.WriteLine("\nPress Enter to hide more words or type 'quit' to exit.");
            string userInput = Console.ReadLine();

            if (userInput.ToLower() == "quit")
            {
                break;
            }

            bool allHidden = scripture.HideSomeWords(); // Ai helped me with here
            enterCount++;

            if (allHidden)
            {
                Console.Clear();
                scripture.ShowScripture();
                Console.WriteLine($"\nAll words are hidden! You pressed Enter {enterCount} times. Press Enter to exit."); // Ai helped me with here as well
                Console.ReadLine();
                break;
            }
        }
    }

    static int CountVisibleWords(Scripture scripture)
    {
        FieldInfo wordsField = typeof(Scripture).GetField("_words", BindingFlags.NonPublic | BindingFlags.Instance); // Ai helped me with this line
        List<Word> words = (List<Word>)wordsField.GetValue(scripture);

        int count = 0;
        foreach (Word word in words)
        {
            if (!word.IsHidden())
            {
                count++;
            }
        }
        return count;
    }
}

public class Scripture
{
    public Reference Ref { get; private set; }
    public string Text { get; private set; }
    private HashSet<int> hiddenWords;

    public Scripture(Reference reference, string text)
    {
        Ref = reference;
        Text = text;
        hiddenWords = new HashSet<int>();
    }

    public void HideRandomWord()
    {
        string[] words = Text.Split(' ');
        Random random = new Random();

        // Keep trying to hide a word until a new one is found
        int index;
        do
        {
            index = random.Next(words.Length);
        } while (hiddenWords.Contains(index));

        hiddenWords.Add(index);
    }

    public string GetDisplayedText()
    {
        string[] words = Text.Split(' ');
        for (int i = 0; i < words.Length; i++)
        {
            if (hiddenWords.Contains(i))
                words[i] = new string('_', words[i].Length); // Replace with underscores matching the word length
        }
        return string.Join(" ", words);
    }

    public bool AllWordsHidden() => hiddenWords.Count == Text.Split(' ').Length;
}
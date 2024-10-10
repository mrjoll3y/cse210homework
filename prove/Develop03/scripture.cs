using System;
public class Scripture
{
    public Reference Ref { get; private set; }
    private List<Word> Words;

    
    public Scripture(Reference reference, string text)
    {
        Ref = reference;
        Words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

        public void HideRandomWords(int numberOfWordsToHide = 3)
    {
        Random random = new Random();
        var wordsToHide = Words.Where(w => !w.IsHidden).OrderBy(_ => random.Next()).Take(numberOfWordsToHide).ToList();

        foreach (var word in wordsToHide)
        {
            word.Hide();
        }
    }

    
    public string GetDisplayedText()
    {
        return string.Join(" ", Words.Select(word => word.ToString()));
    }

    
    public bool AllWordsHidden() => Words.All(word => word.IsHidden);
}

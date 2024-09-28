public class Entry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public string Date { get; set; }

    public Entry(string prompt, string response)
    {
        Prompt = prompt;
        Response = response;
        Date = DateTime.Now.ToString("MM/dd/yyyy HH:mm");
    }

    // Returns the formatted entry string for display
    public override string ToString()
    {
        return $"[{Date}] {Prompt}\nResponse: {Response}\n";
    }
}

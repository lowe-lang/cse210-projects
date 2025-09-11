using System;

class Entry
{
    public string _date;
    public string _prompt;
    public string _response;

    public Entry(string prompt, string response, string date = null)
    {
        _prompt = prompt;
        _response = response;
        _date = date ?? DateTime.Now.ToShortDateString();
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_prompt}");
        Console.WriteLine($"Response: {_response}");
        Console.WriteLine();
    }
}


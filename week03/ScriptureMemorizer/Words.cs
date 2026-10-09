public class Word
{
    private readonly string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public bool IsHidden()
    {
        return _isHidden;
    }

    public void Hide()
    {
        _isHidden = true;

    }

    public string GetDisplayText()
    {
        return _isHidden
            ? string.Concat(_text.Select(character =>
                char.IsLetter(character) ? "_" : character.ToString()))
            : _text;
    }
}
public class Reference
{
    private readonly string _book;
    private readonly int _chapter;
    private readonly int _verseStart;
    private readonly int? _verseEnd;

    public Reference(string book, int chapter, int verse)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(book);
        if (chapter < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(chapter));
        }

        if (verse < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(verse));
        }

        _book = book;
        _chapter = chapter;
        _verseStart = verse;
        _verseEnd = null;
    }

    public Reference(string book, int chapter, int verseStart, int verseEnd)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(book);
        if (chapter < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(chapter));
        }

        if (verseStart < 1)
        {
            throw new ArgumentOutOfRangeException(nameof(verseStart));
        }

        if (verseEnd < verseStart)
        {
            throw new ArgumentOutOfRangeException(nameof(verseEnd));
        }

        _book = book;
        _chapter = chapter;
        _verseStart = verseStart;
        _verseEnd = verseEnd;
    }

    public string GetDisplayText()
    {
        return _verseEnd.HasValue
            ? $"{_book} {_chapter}:{_verseStart}-{_verseEnd.Value}"
            : $"{_book} {_chapter}:{_verseStart}";
    }
}
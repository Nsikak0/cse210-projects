using System;
using System.Collections.Generic;

public sealed class PromptGenerator
{
    private readonly List<string> _options;
    private readonly List<string> _remainingOptions;

    public PromptGenerator(IReadOnlyList<string> options)
    {
        if (options == null)
        {
            throw new ArgumentNullException(nameof(options));
        }

        if (options.Count == 0)
        {
            throw new ArgumentException("At least one option is required.", nameof(options));
        }

        _options = new List<string>(options);
        _remainingOptions = new List<string>(_options);
    }

    public string GetRandomOption()
    {
        if (_remainingOptions.Count == 0)
        {
            _remainingOptions.AddRange(_options);
        }

        int index = Random.Shared.Next(_remainingOptions.Count);
        string option = _remainingOptions[index];
        _remainingOptions.RemoveAt(index);
        return option;
    }
}

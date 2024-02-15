namespace LongestNonRepeatingSubstringApp
{
	internal class Program
	{
		static void Main(string[] _args)
		{
			Console.WriteLine(FindLongestSubstring("abcabcbb"));
			Console.WriteLine(FindLongestSubstring("This is a statement"));
		}

		static int FindLongestSubstring(string _input)
		{
			if (string.IsNullOrEmpty(_input) || string.IsNullOrWhiteSpace(_input) || _input.Length > 1000)
			{
				return -1;
			}

			var _checkString = new string(_input.Where(x => x != ' ').ToArray());

			int _currentLongestSequence = 0;

			int _currentSequenceLength = 0;
			int _index = 0;

			var _pastChars = new HashSet<char>();

			while (_index < _checkString.Length)
			{
				var _char = _checkString[_index];

				if (!_pastChars.Add(_char))
				{
					_currentLongestSequence = _currentSequenceLength > _currentLongestSequence
						? _currentSequenceLength
						: _currentLongestSequence;

					_currentSequenceLength = 0;
					_pastChars = new HashSet<char>();
					continue;
				}
				++_currentSequenceLength;
				++_index;
			}

			return _currentLongestSequence;
		}
	}
}

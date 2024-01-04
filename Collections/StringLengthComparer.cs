
internal class StringLengthComparer : IComparer<string>
{
    public int Compare(string? x, string? y)
    {
        return x.Length - y.Length;
    }
}
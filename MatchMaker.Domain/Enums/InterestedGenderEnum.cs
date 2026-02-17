namespace MatchMaker.Domain.Enums
{
    [Flags]
    public enum InterestedGenderEnum
    {
        None = 0,
        Male = 1 << 0, // 1
        Female = 1 << 1, // 2
        NonBinary = 1 << 2, // 4
    }
}

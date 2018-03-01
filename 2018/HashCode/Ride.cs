namespace HashCode
{
    public class Ride
    {
        public int StartingRow { get; set; }
        public int StartingColumn { get; set; }
        public int FinishingRow { get; set; }
        public int FinishingColumn { get; set; }
        public int EarliestStart { get; set; }
        public int LatestFinish { get; set; }

        public override string ToString()
        {
            return string.Format
            (
                "{0} {1} {2} {3} {4} {5}",
                StartingRow,
                StartingColumn,
                FinishingRow,
                FinishingColumn,
                EarliestStart,
                LatestFinish
            );
        }
    }
}
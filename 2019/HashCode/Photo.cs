using System.Collections.Generic;

namespace HashCode
{
    public class Photo
    {
        public bool IsHorizontal { get; set; }
        public bool IsVertical { get; set; }
        public int TagCount { get; set; }
        public IList<string> Tags { get; set; }

        public Photo()
        {
            Tags = new List<string>();
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", IsHorizontal ? "H" : "V", TagCount, string.Join(" ", Tags));
        }
    }
}
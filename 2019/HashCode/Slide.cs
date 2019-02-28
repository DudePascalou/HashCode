using System.Collections.Generic;

namespace HashCode
{
    public class Slide
    {
        public int PhotoId { get; set; }

        public int PhotoId2 { get; set; }
        public IList<string> Tags { get; set; }
        public Slide()
        {
            Tags = new List<string>();
            PhotoId = -1;
            PhotoId2 = -1;
        }

        public override string ToString()
        {
            return string.Format("{0}{1}", PhotoId, (PhotoId2 > -1) ? " " + PhotoId2.ToString() : string.Empty);
        }
    }
}
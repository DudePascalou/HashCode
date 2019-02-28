using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace HashCode
{
    public partial class Solver
    {
        public int PhotoCount { get; set; }
        public IList<Photo> Photos { get; set; }
        public IList<Slide> Slideshow { get; set; }


        public Solver()
        {
            Photos = new List<Photo>();
            Slideshow = new List<Slide>();
        }

        public IEnumerable<string> Solve()
        {

            // TODO : construction du slideshow


            yield return Slideshow.Count.ToString();
            foreach (var slide in Slideshow)
            {
                yield return slide.ToString();
            }
        }

    }
}

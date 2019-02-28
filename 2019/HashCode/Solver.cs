using CoperAlgoLib.Geometry;
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
            foreach (var photo in Photos.Where(p => p.IsHorizontal))
            {
                var slide = new Slide
                {
                    PhotoId = photo.Id
                };
                Slideshow.Add(slide);
            }

            yield return Slideshow.Count.ToString();
            foreach (var slide in Slideshow)
            {
                yield return slide.ToString();
            }
        }


        private IList<string> MatchingTags(IList<string> tags1, IList<string> tags2)
        {
            return tags1.Intersect(tags2).ToList();
        }

    }
}

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
        public IList<Slide> SlideList { get; set; }
        public IList<Slide> Slideshow { get; set; }


        public Solver()
        {
            Photos = new List<Photo>();
            Slideshow = new List<Slide>();
            SlideList = new List<Slide>();

        }

        public IEnumerable<string> Solve()
        {
            IEnumerable<Photo> horizontals = Photos.Where(p => p.IsHorizontal);
            foreach (var photo in horizontals)
            {
                var slide = new Slide
                {
                    PhotoId = photo.Id,
                    Tags = photo.Tags
                };
                SlideList.Add(slide);
            }

            
            Random rd = new Random();
            int starting = rd.Next(0, horizontals.Count());
            Slideshow.Add(SlideList[starting]);
            SlideList.Remove(SlideList[starting]);

            Slide nextSlide = new Slide();
            while (SlideList.Count != 0 && nextSlide!=null ) {
             nextSlide = FindNextSlide(Slideshow.Last(), SlideList);
                if (nextSlide != null)
                {
                    Slideshow.Add(nextSlide);
                    SlideList.Remove(nextSlide);
                }
                //Console.WriteLine(SlideList.Count);
            }

            yield return Slideshow.Count.ToString();
            foreach (var slide in Slideshow)
            {
                yield return slide.ToString();
            }
        }


        private Slide FindNextSlide(Slide s, IList<Slide> slideList)
        {
            //IList<Slide> SOI = new List<Slide>();
            int nbMaxTags = (int)Math.Floor(s.Tags.Count / 2d);
            Slide sli = null;
            int nbTagsInterest = 0;
            foreach (var slide in SlideList)
            {
        
                var nbCommonTags = MatchingTags(slide.Tags, s.Tags).Count;
                if (nbCommonTags > nbTagsInterest)
                {
                    sli = slide;
                    nbTagsInterest = nbCommonTags;
                }

                //if (nbCommonTags > 0 && nbCommonTags < nbMaxTags)
                //{
                //    SOI.Add(slide);
                //}
            }
            return sli;
            //var query = from s1 in slideList
            //            where MatchingTags(s1.Tags, s.Tags).Count <= nbMaxTags && MatchingTags(s1.Tags, s.Tags).Count > 0
            //            select s;
        }


        private IList<string> MatchingTags(IList<string> tags1, IList<string> tags2)
        {
            return tags1.Intersect(tags2).ToList();
        }

    }
}

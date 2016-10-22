using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Facebook;
using Gudbelldon.Facebook;

namespace FbTest
{
    class Program
    {
        static void Main(string[] args)
        {

            var fb = new PhotoProvider();
            var links = fb.GetPhotoLinks().Result;

            foreach (var link in links)
            {
                Console.WriteLine(link);
            }

            Console.ReadLine();
        }
    }
}

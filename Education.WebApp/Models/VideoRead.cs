using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Diagnostics;
using System.Threading;

namespace Education.WebApp.Models
{
    public class VideoReadCls
    {
        public void extractVideo(string input, string output)
        {
            var ffMp = new NReco.VideoConverter.FFMpegConverter();
            ffMp.GetVideoThumbnail(input,output,10);
        }
    }
    
}
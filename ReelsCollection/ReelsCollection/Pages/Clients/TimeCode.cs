using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ReelsCollection.Pages.Clients
{
    public static class TimeCode
    {
        public static string ConvertToTimeCode(double timeDuration)
        {
            

            //in this variable we will save the desired duration string, i.e. 3:23:11.234
            string formattedDuration;

            //create a TimeSpan object using a in-built function to convert from
            //a duration in milliseconds
            TimeSpan duration = TimeSpan.FromSeconds(timeDuration);

            //use the TimeSpan objects ToString method to output its value as a nicely
            //formatted duration string
            formattedDuration = duration.ToString(@"hh\:mm\:ss\:ff");

            
         
            return  formattedDuration;

        }

        // to sum up the timecodesof the reels
        public static string CalculateTotalSeconds(List<ReelInfo> reels, ReelInfo reelInfo)
        {
           

            var filteredReels = reels.FindAll(v =>( v.standard == reelInfo.standard) && (v.definition == reelInfo.definition));
            double sum = 0;

            foreach (var reel in filteredReels)
            {
                TimeSpan ts = new TimeSpan();

               
                    DateTime formattedDate = new DateTime();
                    formattedDate = DateTime.ParseExact(reel.end_timecode, "hh:mm:ss:ff", CultureInfo.InvariantCulture);
                    sum = sum + (formattedDate.TimeOfDay.TotalSeconds);
                

            }
            string result = ConvertToTimeCode(sum);


            return result;
        }



    }
}

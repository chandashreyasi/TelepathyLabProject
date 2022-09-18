using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace ReelsCollection.Pages.Clients
{
    public class IndexModel : PageModel
    {
        public List<ReelInfo> reelList = new List<ReelInfo>();
        public void OnGet()
        {
            try
            {
                string connectionString = "Data Source=IE4LLTFG648C3;Initial Catalog=myReels;Integrated Security=true;TrustServerCertificate=True";
            
            
                using (SqlConnection conn= new SqlConnection(connectionString))
                {
                    conn.Open();
                    string sql = "select * from Reels";

                    using (SqlCommand command = new SqlCommand(sql, conn))
                    {
                        using (SqlDataReader reader= command.ExecuteReader())
                        {
                            while(reader.Read())
                            {
                                ReelInfo reel = new ReelInfo();
                                reel.id = reader.GetGuid(0);
                                reel.name= reader.GetString(1);
                                reel.description = reader.GetString(2);
                                reel.standard = reader.GetString(3);
                                reel.definition = reader.GetString(4);
                                reel.start_timecode = reader.GetString(5);
                                reel.end_timecode = reader.GetString(6);

                                reelList.Add(reel);
                            }

                        }
                    }
                }
            }
            catch(Exception ex)
            {

            }
           
            

        }
    }

    public class ReelInfo
    {

        public Guid id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string standard { get; set; }
        public string definition { get; set; }
        public string start_timecode { get; set; }
        public string end_timecode { get; set; }

       


    }

}

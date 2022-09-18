using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;


namespace ReelsCollection.Pages.Clients
{
    public class CreateModel : PageModel
    {
        public ReelInfo reelInfo = new ReelInfo();
        public string errorMessage = string.Empty;
        public string successMessage = string.Empty;
        public void OnGet()
        {
        }

        public void OnPost()
        {
            try
            {

                reelInfo.id = Guid.NewGuid();
                reelInfo.name = Request.Form["name"];
                reelInfo.description = Request.Form["description"];
                reelInfo.standard = Request.Form["standard"];
                reelInfo.definition = Request.Form["definition"];
                reelInfo.end_timecode = Request.Form["end_timecode"];



                // SAVE reel to db
                string connectionString = "Data Source=IE4LLTFG648C3;Initial Catalog=myReels;Integrated Security=true;TrustServerCertificate=True";


                
                TimeSpan ts = new TimeSpan();
                if (TimeSpan.TryParse(reelInfo.end_timecode, out ts))
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string sql = "INSERT INTO Reels VALUES" +
        "(@id, @name,@description, @standard, @definition, '00:00:00:00',@end_timecode )";

                        using (SqlCommand command = new SqlCommand(sql, conn))
                        {
                            command.Parameters.AddWithValue("@id", reelInfo.id);
                            command.Parameters.AddWithValue("@name", reelInfo.name);
                            command.Parameters.AddWithValue("@description", reelInfo.description);
                            command.Parameters.AddWithValue("@standard", reelInfo.standard);
                            command.Parameters.AddWithValue("@definition", reelInfo.definition);
                            command.Parameters.AddWithValue("@end_timecode", reelInfo.end_timecode);
                            command.ExecuteNonQuery();
                        }
                    }
                    TempData["ID"] = reelInfo.id;
                }
            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;

            }
            TempData["ID"] = reelInfo.id;
            Response.Redirect("/Clients/Index");
            
        }
    }
}

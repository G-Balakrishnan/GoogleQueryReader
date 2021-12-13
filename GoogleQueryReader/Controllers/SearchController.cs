using GoogleQueryReader.Common;
using GoogleQueryReader.Context;
using GoogleQueryReader.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GoogleQueryReader.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchController : ControllerBase
    {
        private readonly IConfiguration configuration;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public SearchController(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            this.configuration = configuration;
            _webHostEnvironment = webHostEnvironment;
        }


        [HttpGet]
        public List<NewsFeedModel> SearchNews(string searchQuery)
        {
            //  List<string> placeHolders = DataStore.PlaceHolders.Select(g => g.DirtKeyword).ToList();
            List<NewsFeedModel> Details = new List<NewsFeedModel>();
            foreach (var ph in DataStore.PlaceHolders)
            {
                ph.SearchQuery = searchQuery;
                var data = GetCompanyNewsDetrarils(ph).Result;
                Details.AddRange(data);
            }

            return Details;
        }

        [HttpPost("ExportPDF")]
        public FileResult ExportPDF(List<NewsFeedModel> model,string searchkey)
        {
            DataTable dt = model.ToDataTable<NewsFeedModel>();

            if (dt.Rows.Count > 0)
            {
                int pdfRowIndex = 1;

                string filename = searchkey.Replace(" ","") + DateTime.Now.ToString("dd-MM-yyyy hh_mm_s_tt");
                string filepath = Path.Combine(_webHostEnvironment.ContentRootPath, filename + ".pdf");
                Document document = new Document(PageSize.A4, 5f, 5f, 10f, 10f);
                FileStream fs = new FileStream(filepath, FileMode.Create);
                PdfWriter writer = PdfWriter.GetInstance(document, fs);
                document.Open();

                Font font1 = FontFactory.GetFont(FontFactory.COURIER_BOLD, 10);
                Font font2 = FontFactory.GetFont(FontFactory.COURIER, 8);

                float[] columnDefinitionSize = { 2F, 5F, 2F, 5F };
                PdfPTable table;
                PdfPCell cell;

                table = new PdfPTable(columnDefinitionSize)
                {
                    WidthPercentage = 100
                };

                cell = new PdfPCell
                {
                    BackgroundColor = new BaseColor(0xC0, 0xC0, 0xC0)
                };

                //table.AddCell(new Phrase("ProductId", font1));
                table.AddCell(new Phrase("Title", font1));
                table.AddCell(new Phrase("Date", font1));
                table.AddCell(new Phrase("Description", font1));
                table.HeaderRows = 1;

                foreach (DataRow data in dt.Rows)
                {
                    table.AddCell(new Phrase(data["Title"].ToString(), font2));
                    table.AddCell(new Phrase(data["PubDate"].ToString(), font2));
                    table.AddCell(new Phrase(data["Description"].ToString(), font2));

                    pdfRowIndex++;
                }

                document.Add(table);
                document.Close();
                document.CloseDocument();
                document.Dispose();
                writer.Close();
                writer.Dispose();
                fs.Close();
                fs.Dispose();

                FileStream sourceFile = new FileStream(filepath, FileMode.Open);
                float fileSize = 0;
                fileSize = sourceFile.Length;
                byte[] getContent = new byte[Convert.ToInt32(Math.Truncate(fileSize))];
                sourceFile.Read(getContent, 0, Convert.ToInt32(sourceFile.Length));
                sourceFile.Close();
                var bytes = System.IO.File.ReadAllBytes(filepath);
                System.IO.File.Delete(filepath);
                //var result = new HttpResponseMessage(HttpStatusCode.OK)
                //{
                //    Content = new ByteArrayContent(bytes)
                //};
        
                //result.Content.Headers.ContentDisposition =
                //    new System.Net.Http.Headers.ContentDispositionHeaderValue("attachment")
                //    {
                //        FileName =filename
                //    };
                //result.Content.Headers.ContentType =
                //    new MediaTypeHeaderValue("application/octet-stream");
                return File(bytes, "application/pdf", Path.GetFileName(filename));
            }
            return null;
        }


        private async Task<List<NewsFeedModel>> GetCompanyNewsDetrarils(SearchModel model)
        {
            List<NewsFeedModel> Details = new List<NewsFeedModel>();
            for (int i = 1; i <= 2; i++)
            {
                string url = getAPIUrl(model, i);
                HttpClient client = new HttpClient();
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                Details.AddRange(Newtonsoft.Json.JsonConvert.DeserializeObject<GoogleResponseModel>(responseBody).items.Select(g => new NewsFeedModel() { Title = g.title, Link = g.link, Description = string.Join(".", g.pagemap.metatags.Select(g => g.OgDescription)), PubDate = g.snippet.Substring(0, 11).ToDate()}));
            }
            if (model.SortMode=="a")
            {
                Details = Details.OrderBy(g => g.PubDate).ToList();
            }
            else if(model.SortMode == "d")
            {
                Details = Details.OrderByDescending(g => g.PubDate).ToList();
            }
            return Details.Where(s => s.PubDate > DateTime.Now.AddDays(model.DaysRestricted * (-1)) || s.PubDate.Date==DateTime.MinValue.Date).ToList();
        }

        private string getAPIUrl(SearchModel model, int start)
        {

            string url = "https://customsearch.googleapis.com/customsearch/v1?q=" + model.SearchQuery + "&start=" + start+"&key="+configuration.GetSection("ge_appid").Value+"&cx=" + configuration.GetSection("ge_cx").Value;
            if (model.ResultCount != 0)
            {
                url += "&num=" + model.ResultCount;
            }
            if (model.CountryCode != null)
            {
                url += "&gl=" + model.CountryCode;
            }
            if (model.SortMode != null)
            {
                //url += " &sort=date-sdate:" + model.SortMode;

            }
            //start = 10&num=10 &
            return url;
        }


        //private List<ItemNews> GetCompanyNewsDetrarils(object pc)
        //{
        //    List<ItemNews> Details = new List<ItemNews>();
        //    // httpWebRequest with API URL
        //    HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://news.google.com/news?q=" + pc + "&output=rss");

        //    //Method GET
        //    request.Method = "GET";

        //    //HttpWebResponse for result
        //    HttpWebResponse response = (HttpWebResponse)request.GetResponse();


        //    //Mapping of status code
        //    if (response.StatusCode == HttpStatusCode.OK)
        //    {
        //        Stream receiveStream = response.GetResponseStream();
        //        StreamReader readStream = null;

        //        if (response.CharacterSet == "")
        //            readStream = new StreamReader(receiveStream);
        //        else
        //            readStream = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));

        //        //Get news data in json string

        //        string data = readStream.ReadToEnd();

        //        //Declare DataSet for putting data in it.
        //        DataSet ds = new DataSet();
        //        StringReader reader = new StringReader(data);
        //        ds.ReadXml(reader);
        //        DataTable dtGetNews = new DataTable();

        //        if (ds.Tables.Count > 3)
        //        {
        //            dtGetNews = ds.Tables["item"];

        //            foreach (DataRow dtRow in dtGetNews.Rows)
        //            {
        //                ItemNews DataObj = new ItemNews();
        //                DataObj.title = dtRow["title"].ToString();
        //                DataObj.link = dtRow["link"].ToString();
        //                DataObj.item_id = dtRow["item_id"].ToString();
        //                DataObj.PubDate = dtRow["pubDate"].ToString();
        //                DataObj.Description = dtRow["description"].ToString();
        //                Details.Add(DataObj);
        //            }
        //        }
        //    }
        //    return Details;
        //}



    }

    //public class ItemNews
    //{
    //    public string title { get; set; }
    //    public string link { get; set; }
    //    public string item_id { get; set; }
    //    public string PubDate { get; set; }
    //    public string Description { get; set; }
    //}
}

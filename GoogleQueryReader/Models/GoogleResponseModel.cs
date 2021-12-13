using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GoogleQueryReader.Models
{
    public class Url
    {
        public string type { get; set; }
        public string template { get; set; }
    }

    public class PreviousPage
    {
        public string title { get; set; }
        public string totalResults { get; set; }
        public string searchTerms { get; set; }
        public int count { get; set; }
        public string inputEncoding { get; set; }
        public string outputEncoding { get; set; }
        public string safe { get; set; }
        public string cx { get; set; }
    }

    public class Request
    {
        public string title { get; set; }
        public string totalResults { get; set; }
        public string searchTerms { get; set; }
        public int count { get; set; }
        public int startIndex { get; set; }
        public string inputEncoding { get; set; }
        public string outputEncoding { get; set; }
        public string safe { get; set; }
        public string cx { get; set; }
    }

    public class NextPage
    {
        public string title { get; set; }
        public string totalResults { get; set; }
        public string searchTerms { get; set; }
        public int count { get; set; }
        public int startIndex { get; set; }
        public string inputEncoding { get; set; }
        public string outputEncoding { get; set; }
        public string safe { get; set; }
        public string cx { get; set; }
    }

    public class Queries
    {
        public List<PreviousPage> previousPage { get; set; }
        public List<Request> request { get; set; }
        public List<NextPage> nextPage { get; set; }
    }

    public class Context
    {
        public string title { get; set; }
    }

    public class SearchInformation
    {
        public double searchTime { get; set; }
        public string formattedSearchTime { get; set; }
        public string totalResults { get; set; }
        public string formattedTotalResults { get; set; }
    }

    public class CseThumbnail
    {
        public string src { get; set; }
        public string width { get; set; }
        public string height { get; set; }
    }

    public class Metatag
    {
        [JsonProperty("og:image")]
        public string OgImage { get; set; }

        [JsonProperty("twitter:card")]
        public string TwitterCard { get; set; }

        [JsonProperty("og:image:width")]
        public string OgImageWidth { get; set; }

        [JsonProperty("article:published_time")]
        public string ArticlePublishedTime { get; set; }

        [JsonProperty("og:site_name")]
        public string OgSiteName { get; set; }

        [JsonProperty("apple-mobile-web-app-title")]
        public string AppleMobileWebAppTitle { get; set; }
        public string title { get; set; }

        [JsonProperty("og:description")]
        public string OgDescription { get; set; }

        [JsonProperty("twitter:image")]
        public string TwitterImage { get; set; }

        [JsonProperty("twitter:site")]
        public string TwitterSite { get; set; }

        [JsonProperty("article:modified_time")]
        public string ArticleModifiedTime { get; set; }
        public string news_keywords { get; set; }

        [JsonProperty("og:type")]
        public string OgType { get; set; }

        [JsonProperty("twitter:title")]
        public string TwitterTitle { get; set; }

        [JsonProperty("twitter:domain")]
        public string TwitterDomain { get; set; }
        public string author { get; set; }

        [JsonProperty("og:title")]
        public string OgTitle { get; set; }

        [JsonProperty("og:image:height")]
        public string OgImageHeight { get; set; }

        [JsonProperty("fb:app_id")]
        public string FbAppId { get; set; }

        [JsonProperty("apple-mobile-web-app-status-bar-style")]
        public string AppleMobileWebAppStatusBarStyle { get; set; }
        public string viewport { get; set; }

        [JsonProperty("twitter:description")]
        public string TwitterDescription { get; set; }

        [JsonProperty("apple-mobile-web-app-capable")]
        public string AppleMobileWebAppCapable { get; set; }

        [JsonProperty("og:url")]
        public string OgUrl { get; set; }

        [JsonProperty("apple-touch-fullscreen")]
        public string AppleTouchFullscreen { get; set; }

        [JsonProperty("theme-color")]
        public string ThemeColor { get; set; }

        [JsonProperty("twitter:url")]
        public string TwitterUrl { get; set; }

        [JsonProperty("twitter:app:id:googleplay")]
        public string TwitterAppIdGoogleplay { get; set; }

        [JsonProperty("apple-itunes-app")]
        public string AppleItunesApp { get; set; }

        [JsonProperty("al:android:package")]
        public string AlAndroidPackage { get; set; }

        [JsonProperty("twitter:app:name:googleplay")]
        public string TwitterAppNameGoogleplay { get; set; }

        [JsonProperty("og:image:type")]
        public string OgImageType { get; set; }

        [JsonProperty("twitter:app:id:iphone")]
        public string TwitterAppIdIphone { get; set; }

        [JsonProperty("twitter:creator")]
        public string TwitterCreator { get; set; }

        [JsonProperty("publish-date")]
        public string? PublishDate { get; set; }

        [JsonProperty("ahrefs-site-verification")]
        public string AhrefsSiteVerification { get; set; }

        [JsonProperty("article:section")]
        public string ArticleSection { get; set; }

        [JsonProperty("msvalidate.01")]
        public string Msvalidate01 { get; set; }

        [JsonProperty("yandex-verification")]
        public string YandexVerification { get; set; }

        [JsonProperty("fb:pages")]
        public string FbPages { get; set; }

        [JsonProperty("created-date")]
        public string? CreatedDate { get; set; }

        [JsonProperty("article:author")]
        public string ArticleAuthor { get; set; }

        [JsonProperty("article:tag")]
        public string ArticleTag { get; set; }

        [JsonProperty("al:android:url")]
        public string AlAndroidUrl { get; set; }

        [JsonProperty("twitter:app:name:ipad")]
        public string TwitterAppNameIpad { get; set; }

        [JsonProperty("modified-date")]
        public string? ModifiedDate { get; set; }
        public string atdlayout { get; set; }

        [JsonProperty("google-play-app")]
        public string GooglePlayApp { get; set; }

        [JsonProperty("twitter:app:name:iphone")]
        public string TwitterAppNameIphone { get; set; }

        [JsonProperty("al:android:app_name")]
        public string AlAndroidAppName { get; set; }

        [JsonProperty("google-signin-client_id")]
        public string GoogleSigninClientId { get; set; }

        [JsonProperty("meta-section")]
        public string MetaSection { get; set; }
        public string type { get; set; }

        [JsonProperty("article:publisher")]
        public string ArticlePublisher { get; set; }
        public string template_type { get; set; }
        public string theme { get; set; }
        public string language { get; set; }

        [JsonProperty("twitter:site_name")]
        public string TwitterSiteName { get; set; }

        [JsonProperty("csrf-token")]
        public string CsrfToken { get; set; }

        [JsonProperty("dc.language")]
        public string DcLanguage { get; set; }

        [JsonProperty("branch:deeplink:url_id")]
        public string BranchDeeplinkUrlId { get; set; }

        [JsonProperty("og:updated_time")]
        public string? OgUpdatedTime { get; set; }

        [JsonProperty("twitter:label1")]
        public string TwitterLabel1 { get; set; }

        [JsonProperty("twitter:label2")]
        public string TwitterLabel2 { get; set; }

        [JsonProperty("msapplication-tileimage")]
        public string MsapplicationTileimage { get; set; }

        [JsonProperty("twitter:data1")]
        public string TwitterData1 { get; set; }

        [JsonProperty("twitter:data2")]
        public string TwitterData2 { get; set; }

        [JsonProperty("og:locale")]
        public string OgLocale { get; set; }

        [JsonProperty("dcterms.language")]
        public string DctermsLanguage { get; set; }

        [JsonProperty("dcterms.title")]
        public string DctermsTitle { get; set; }

        [JsonProperty("dcterms.subject")]
        public string DctermsSubject { get; set; }

        [JsonProperty("dcterms.publisher")]
        public string DctermsPublisher { get; set; }

        [JsonProperty("dcterms.available")]
        public string? DctermsAvailable { get; set; }

        [JsonProperty("twitter:site:id")]
        public string TwitterSiteId { get; set; }

        [JsonProperty("dcterms.type")]
        public string DctermsType { get; set; }

        [JsonProperty("dcterms.creator")]
        public string DctermsCreator { get; set; }

        [JsonProperty("dcterms.description")]
        public string DctermsDescription { get; set; }

        [JsonProperty("dcterms.created")]
        public string? DctermsCreated { get; set; }

        [JsonProperty("twitter:image:src")]
        public string TwitterImageSrc { get; set; }

        [JsonProperty("dcterms.format")]
        public string DctermsFormat { get; set; }

        [JsonProperty("dcterms.identifier")]
        public string DctermsIdentifier { get; set; }
    }

    public class CseImage
    {
        public string src { get; set; }
    }

    public class Hcard
    {
        public string fn { get; set; }
        public string photo { get; set; }
        public string url { get; set; }
    }

    public class Imageobject
    {
        public string image { get; set; }
        public string width { get; set; }
        public string url { get; set; }
        public string height { get; set; }
        public string contenturl { get; set; }
        public string representativeofpage { get; set; }
        public string description { get; set; }
    }

    public class Person
    {
        public string name { get; set; }
        public string url { get; set; }
        public string image { get; set; }
        public string description { get; set; }
    }

    public class Organization
    {
        public string name { get; set; }
        public string sameas { get; set; }
    }

    public class Place
    {
        public string name { get; set; }
    }

    public class Creativework
    {
        public string keywords { get; set; }
    }

    public class Newsarticle
    {
        public string image { get; set; }
        public string articlebody { get; set; }
        public string datemodified { get; set; }
        public string keywords { get; set; }
        public string name { get; set; }
        public string headline { get; set; }
        public string datepublished { get; set; }
        public string thumbnailurl { get; set; }
        public string mainentityofpage { get; set; }
        public string articlesection { get; set; }
        public string description { get; set; }
        public string url { get; set; }
    }

    public class Sitenavigationelement
    {
        public string name { get; set; }
        public string url { get; set; }
    }

    public class Listitem
    {
        public string item { get; set; }
        public string name { get; set; }
        public string position { get; set; }
    }

    public class Pagemap
    {
        public List<CseThumbnail> cse_thumbnail { get; set; }
        public List<Metatag> metatags { get; set; }
        public List<CseImage> cse_image { get; set; }
        public List<Hcard> hcard { get; set; }
        public List<Imageobject> imageobject { get; set; }
        public List<Person> person { get; set; }
        public List<Organization> organization { get; set; }
        public List<Place> place { get; set; }
        public List<Creativework> creativework { get; set; }
        public List<Newsarticle> newsarticle { get; set; }
        public List<Sitenavigationelement> sitenavigationelement { get; set; }
        public List<Listitem> listitem { get; set; }
    }

    public class Item
    {
        public string kind { get; set; }
        public string title { get; set; }
        public string htmlTitle { get; set; }
        public string link { get; set; }
        public string displayLink { get; set; }
        public string snippet { get; set; }
        public string htmlSnippet { get; set; }
        public string cacheId { get; set; }
        public string formattedUrl { get; set; }
        public string htmlFormattedUrl { get; set; }
        public Pagemap pagemap { get; set; }
    }

    public class GoogleResponseModel
    {
        public string kind { get; set; }
        public Url url { get; set; }
        public Queries queries { get; set; }
        public Context context { get; set; }
        public SearchInformation searchInformation { get; set; }
        public List<Item> items { get; set; }
    }
}

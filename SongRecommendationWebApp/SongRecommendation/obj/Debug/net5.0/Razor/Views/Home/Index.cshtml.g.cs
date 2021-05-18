#pragma checksum "E:\SongRecommendation\SongRecommendation\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ef69d6f5f983d7620cbdd6dd05651e9c2f79140d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "E:\SongRecommendation\SongRecommendation\Views\_ViewImports.cshtml"
using SongRecommendation;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\SongRecommendation\SongRecommendation\Views\_ViewImports.cshtml"
using SongRecommendation.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"ef69d6f5f983d7620cbdd6dd05651e9c2f79140d", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a2d32ddebc5df7cd87cc2f0f7f6caa16207528eb", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SongRecommendation.Model.Song>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<!-- Header -->
<header class=""w3-container w3-pale-blue w3-center"" style=""padding:128px 16px"">
    <h1 class=""w3-margin w3-jumbo"">REKOMENDACJA MUZYKI WEDŁUG GUSTU UŻYTKOWNIKA</h1>
    <p class=""w3-xlarge"">Wstępna Implentacja Pracy Licencjackiej</p>
    <a href=""#tabela""><button class=""w3-button w3-black w3-padding-large w3-large w3-margin-top"">Zacznij</button></a>
</header>

<!-- First Grid -->
<div class=""w3-row-padding w3-padding-64 w3-container"">
    <div class=""w3-content"">
        <div class=""w3-twothird"">
            <h1>Cel aplikacji</h1>
            <h5 class=""w3-padding-32"">Celem aplikacji jest zaproponowanie użytkownikowi listy utowrów na podstawie utworów wybranych z listy poniżej</h5>
        </div>
    </div>
</div>
<div  id=""tabela"" class=""container p-3"">
    <div class=""row pt-4"">
        <div class=""col-6"">
            <h2 class=""text-lg-center w3-center"">Utwory do wyboru</h2>
        </div>
    </div>
    <br />

");
#nullable restore
#line 26 "E:\SongRecommendation\SongRecommendation\Views\Home\Index.cshtml"
     if (Model.Count() > 0)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"        <table class=""table table-bordered"" style=""width:100%"">
            <thead>
                <tr>
                    <th>
                        Autor
                    </th>
                    <th>
                        Nazwa
                    </th>
                    <th>
                        Gatunek
                    </th>
                    <th>
                        Nastrój
                    </th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 46 "E:\SongRecommendation\SongRecommendation\Views\Home\Index.cshtml"
                 foreach (var song in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <tr>\r\n                    <td >");
#nullable restore
#line 49 "E:\SongRecommendation\SongRecommendation\Views\Home\Index.cshtml"
                    Write(song.Author);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 50 "E:\SongRecommendation\SongRecommendation\Views\Home\Index.cshtml"
                   Write(song.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 51 "E:\SongRecommendation\SongRecommendation\Views\Home\Index.cshtml"
                   Write(song.Genre);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                    <td>");
#nullable restore
#line 52 "E:\SongRecommendation\SongRecommendation\Views\Home\Index.cshtml"
                   Write(song.Mood);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                </tr>\r\n");
#nullable restore
#line 54 "E:\SongRecommendation\SongRecommendation\Views\Home\Index.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n");
#nullable restore
#line 57 "E:\SongRecommendation\SongRecommendation\Views\Home\Index.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <p>Brak utworów do wyboru</p>\r\n");
#nullable restore
#line 61 "E:\SongRecommendation\SongRecommendation\Views\Home\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n\r\n");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SongRecommendation.Model.Song>> Html { get; private set; }
    }
}
#pragma warning restore 1591

#pragma checksum "E:\GIT docs\song-recommendation\SongRecommendationWebApp\SongRecommendation\Views\Home\Recommend_Classification.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c6b767b52d7ad39759b2c130b7d204b5b87a4c1e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Recommend_Classification), @"mvc.1.0.view", @"/Views/Home/Recommend_Classification.cshtml")]
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
#line 1 "E:\GIT docs\song-recommendation\SongRecommendationWebApp\SongRecommendation\Views\_ViewImports.cshtml"
using SongRecommendation;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\GIT docs\song-recommendation\SongRecommendationWebApp\SongRecommendation\Views\_ViewImports.cshtml"
using SongRecommendation.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c6b767b52d7ad39759b2c130b7d204b5b87a4c1e", @"/Views/Home/Recommend_Classification.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a2d32ddebc5df7cd87cc2f0f7f6caa16207528eb", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Recommend_Classification : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<SongRecommendation.Model.SongsDb>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n\r\n<!-- First Grid -->\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c6b767b52d7ad39759b2c130b7d204b5b87a4c1e4049", async() => {
                WriteLiteral("\r\n    <div class=\"container p-3\">\r\n        <div class=\"row pt-4\">\r\n            <div class=\"col-6\">\r\n                <h2 class=\"text-primary\">Top 10 proponowanych utworów</h2>\r\n            </div>\r\n        </div>\r\n        <br />\r\n\r\n");
#nullable restore
#line 14 "E:\GIT docs\song-recommendation\SongRecommendationWebApp\SongRecommendation\Views\Home\Recommend_Classification.cshtml"
         if (Model.Count() > 0)
        {

#line default
#line hidden
#nullable disable
                WriteLiteral(@"            <table class=""table table-bordered table-striped"" style=""width:100%"">
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
                    </tr>
                </thead>
                <tbody>
");
#nullable restore
#line 31 "E:\GIT docs\song-recommendation\SongRecommendationWebApp\SongRecommendation\Views\Home\Recommend_Classification.cshtml"
                     foreach (var song in Model)
                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                        <tr>\r\n                            <td width=\"33%\">");
#nullable restore
#line 34 "E:\GIT docs\song-recommendation\SongRecommendationWebApp\SongRecommendation\Views\Home\Recommend_Classification.cshtml"
                                       Write(song.ArtistName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                            <td width=\"33%\">");
#nullable restore
#line 35 "E:\GIT docs\song-recommendation\SongRecommendationWebApp\SongRecommendation\Views\Home\Recommend_Classification.cshtml"
                                       Write(song.ReleaseName);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                            <td width=\"33%\">");
#nullable restore
#line 36 "E:\GIT docs\song-recommendation\SongRecommendationWebApp\SongRecommendation\Views\Home\Recommend_Classification.cshtml"
                                       Write(song.Terms);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\r\n                        </tr>\r\n");
#nullable restore
#line 38 "E:\GIT docs\song-recommendation\SongRecommendationWebApp\SongRecommendation\Views\Home\Recommend_Classification.cshtml"
                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                </tbody>\r\n            </table>\r\n");
#nullable restore
#line 41 "E:\GIT docs\song-recommendation\SongRecommendationWebApp\SongRecommendation\Views\Home\Recommend_Classification.cshtml"
        }
        else
        {

#line default
#line hidden
#nullable disable
                WriteLiteral("            <p>Brak utworów do zrekomendowania</p>\r\n");
#nullable restore
#line 45 "E:\GIT docs\song-recommendation\SongRecommendationWebApp\SongRecommendation\Views\Home\Recommend_Classification.cshtml"
        }

#line default
#line hidden
#nullable disable
                WriteLiteral("\r\n    </div>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<SongRecommendation.Model.SongsDb>> Html { get; private set; }
    }
}
#pragma warning restore 1591
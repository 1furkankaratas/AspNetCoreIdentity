#pragma checksum "C:\AaProject\DotNetCore\AspNetCoreIdentity\AspNetCoreIdentity\Views\Member\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5ac2b9f1b2870dad6aa0c7678bcb7a10fd0e11fe"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Member_Index), @"mvc.1.0.view", @"/Views/Member/Index.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Member/Index.cshtml", typeof(AspNetCore.Views_Member_Index))]
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
#line 4 "C:\AaProject\DotNetCore\AspNetCoreIdentity\AspNetCoreIdentity\Views\_ViewImports.cshtml"
using AspNetCoreIdentity.Models;

#line default
#line hidden
#line 5 "C:\AaProject\DotNetCore\AspNetCoreIdentity\AspNetCoreIdentity\Views\_ViewImports.cshtml"
using AspNetCoreIdentity.ViewModels;

#line default
#line hidden
#line 6 "C:\AaProject\DotNetCore\AspNetCoreIdentity\AspNetCoreIdentity\Views\_ViewImports.cshtml"
using Microsoft.EntityFrameworkCore.Internal;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5ac2b9f1b2870dad6aa0c7678bcb7a10fd0e11fe", @"/Views/Member/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7851529809c3599caa36327a5a9d5b2b3ef5088d", @"/Views/_ViewImports.cshtml")]
    public class Views_Member_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<UserViewModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#line 2 "C:\AaProject\DotNetCore\AspNetCoreIdentity\AspNetCoreIdentity\Views\Member\Index.cshtml"
  
    ViewData["Title"] = "Member Index";
    Layout = "MemberLayout";

#line default
#line hidden
            BeginContext(100, 139, true);
            WriteLiteral("\r\n\r\n<h3 class=\"text-center\">Kullanıcı Bilgileri</h3>\r\n<div class=\"row\">\r\n    <div class=\"col-md-3\">\r\n        <img class=\"img-fluid rounded\"");
            EndContext();
            BeginWriteAttribute("src", " src=\"", 239, "\"", 259, 1);
#line 11 "C:\AaProject\DotNetCore\AspNetCoreIdentity\AspNetCoreIdentity\Views\Member\Index.cshtml"
WriteAttributeValue("", 245, Model.Picture, 245, 14, false);

#line default
#line hidden
            EndWriteAttribute();
            BeginContext(260, 183, true);
            WriteLiteral(" />\r\n    </div>\r\n    <div class=\"col-md-9\">\r\n        <table class=\"table table-bordered table-striped\">\r\n            <tr>\r\n                <th>Kallanıcı Adı</th>\r\n                <td>");
            EndContext();
            BeginContext(444, 14, false);
#line 17 "C:\AaProject\DotNetCore\AspNetCoreIdentity\AspNetCoreIdentity\Views\Member\Index.cshtml"
               Write(Model.UserName);

#line default
#line hidden
            EndContext();
            BeginContext(458, 98, true);
            WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <th>E-Posta</th>\r\n                <td>");
            EndContext();
            BeginContext(557, 11, false);
#line 21 "C:\AaProject\DotNetCore\AspNetCoreIdentity\AspNetCoreIdentity\Views\Member\Index.cshtml"
               Write(Model.Email);

#line default
#line hidden
            EndContext();
            BeginContext(568, 98, true);
            WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <th>Telefon</th>\r\n                <td>");
            EndContext();
            BeginContext(667, 17, false);
#line 25 "C:\AaProject\DotNetCore\AspNetCoreIdentity\AspNetCoreIdentity\Views\Member\Index.cshtml"
               Write(Model.PhoneNumber);

#line default
#line hidden
            EndContext();
            BeginContext(684, 96, true);
            WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <th>Şehir</th>\r\n                <td>");
            EndContext();
            BeginContext(781, 10, false);
#line 29 "C:\AaProject\DotNetCore\AspNetCoreIdentity\AspNetCoreIdentity\Views\Member\Index.cshtml"
               Write(Model.City);

#line default
#line hidden
            EndContext();
            BeginContext(791, 99, true);
            WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <th>Cinsiyet</th>\r\n                <td>");
            EndContext();
            BeginContext(891, 12, false);
#line 33 "C:\AaProject\DotNetCore\AspNetCoreIdentity\AspNetCoreIdentity\Views\Member\Index.cshtml"
               Write(Model.Gender);

#line default
#line hidden
            EndContext();
            BeginContext(903, 96, true);
            WriteLiteral("</td>\r\n            </tr>\r\n            <tr>\r\n                <th>Şehir</th>\r\n                <td>");
            EndContext();
            BeginContext(1000, 34, false);
#line 37 "C:\AaProject\DotNetCore\AspNetCoreIdentity\AspNetCoreIdentity\Views\Member\Index.cshtml"
               Write(Model.BirthDay.ToShortDateString());

#line default
#line hidden
            EndContext();
            BeginContext(1034, 465, true);
            WriteLiteral(@"</td>
            </tr>
        </table>
    </div>
</div>
<div class=""row"">
    <div class=""col-md-12"">
        <table class=""table table-hover table-bordered table-responsive"">
            <thead>
            <tr>
 
                <th scope=""col"">Kim</th>
                <th scope=""col"">Dağıtıcı</th>
                <th scope=""col"">Ad</th>
                <th scope=""col"">Değer</th>
            </tr>
            </thead>
            <tbody>
");
            EndContext();
#line 55 "C:\AaProject\DotNetCore\AspNetCoreIdentity\AspNetCoreIdentity\Views\Member\Index.cshtml"
             foreach (var item in Model.claims)
            {

#line default
#line hidden
            BeginContext(1563, 46, true);
            WriteLiteral("                <tr>\r\n                    <td>");
            EndContext();
            BeginContext(1610, 17, false);
#line 58 "C:\AaProject\DotNetCore\AspNetCoreIdentity\AspNetCoreIdentity\Views\Member\Index.cshtml"
                   Write(item.Subject.Name);

#line default
#line hidden
            EndContext();
            BeginContext(1627, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(1659, 11, false);
#line 59 "C:\AaProject\DotNetCore\AspNetCoreIdentity\AspNetCoreIdentity\Views\Member\Index.cshtml"
                   Write(item.Issuer);

#line default
#line hidden
            EndContext();
            BeginContext(1670, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(1702, 9, false);
#line 60 "C:\AaProject\DotNetCore\AspNetCoreIdentity\AspNetCoreIdentity\Views\Member\Index.cshtml"
                   Write(item.Type);

#line default
#line hidden
            EndContext();
            BeginContext(1711, 31, true);
            WriteLiteral("</td>\r\n                    <td>");
            EndContext();
            BeginContext(1743, 10, false);
#line 61 "C:\AaProject\DotNetCore\AspNetCoreIdentity\AspNetCoreIdentity\Views\Member\Index.cshtml"
                   Write(item.Value);

#line default
#line hidden
            EndContext();
            BeginContext(1753, 30, true);
            WriteLiteral("</td>\r\n                </tr>\r\n");
            EndContext();
#line 63 "C:\AaProject\DotNetCore\AspNetCoreIdentity\AspNetCoreIdentity\Views\Member\Index.cshtml"
            }

#line default
#line hidden
            BeginContext(1798, 60, true);
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n</div>\r\n");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<UserViewModel> Html { get; private set; }
    }
}
#pragma warning restore 1591
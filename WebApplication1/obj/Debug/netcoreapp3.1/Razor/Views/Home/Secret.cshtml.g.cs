#pragma checksum "D:\FIELD\WebApplication1\WebApplication1\Views\Home\Secret.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5f2eacabe8dc909dff0dd16977c538e77eddbe4e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Secret), @"mvc.1.0.view", @"/Views/Home/Secret.cshtml")]
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
#line 1 "D:\FIELD\WebApplication1\WebApplication1\Views\_ViewImports.cshtml"
using WebApplication1;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\FIELD\WebApplication1\WebApplication1\Views\_ViewImports.cshtml"
using WebApplication1.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5f2eacabe8dc909dff0dd16977c538e77eddbe4e", @"/Views/Home/Secret.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"729efaa87342638aecfe1a972ce9f9f8dff55b4c", @"/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Views_Home_Secret : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<System.Security.Claims.Claim>>
    #nullable disable
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<h1>Área Secreta</h1>\r\n\r\n<p>Olá, ");
#nullable restore
#line 5 "D:\FIELD\WebApplication1\WebApplication1\Views\Home\Secret.cshtml"
   Write(User.Identity.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("!</p>\r\n\r\n<p>Perfil:</p>\r\n<ul>\r\n    <li>Tipo: ");
#nullable restore
#line 9 "D:\FIELD\WebApplication1\WebApplication1\Views\Home\Secret.cshtml"
         Write(ViewData["Type"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n    <li>Opções de Menu:</li>\r\n    <ul>\r\n");
#nullable restore
#line 12 "D:\FIELD\WebApplication1\WebApplication1\Views\Home\Secret.cshtml"
         foreach (var option in (List<Menus>)ViewData["MenuOptions"])
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li>");
#nullable restore
#line 14 "D:\FIELD\WebApplication1\WebApplication1\Views\Home\Secret.cshtml"
           Write(option.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</li>\r\n");
#nullable restore
#line 15 "D:\FIELD\WebApplication1\WebApplication1\Views\Home\Secret.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </ul>\r\n</ul>");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<System.Security.Claims.Claim>> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591

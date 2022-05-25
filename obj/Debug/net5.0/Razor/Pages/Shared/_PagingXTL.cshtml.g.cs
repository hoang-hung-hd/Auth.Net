#pragma checksum "C:\WorkSpace\Git_Clone\Auth.Net\Pages\Shared\_PagingXTL.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e21f4496837b20edc150f728d1f44fa72e442a78"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Pages_Shared__PagingXTL), @"mvc.1.0.view", @"/Pages/Shared/_PagingXTL.cshtml")]
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
#line 1 "C:\WorkSpace\Git_Clone\Auth.Net\Pages\Shared\_ViewImports.cshtml"
using App;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\WorkSpace\Git_Clone\Auth.Net\Pages\Shared\_ViewImports.cshtml"
using App.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e21f4496837b20edc150f728d1f44fa72e442a78", @"/Pages/Shared/_PagingXTL.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"12334568134fabec32ff1911f23453426e7f6405", @"/Pages/Shared/_ViewImports.cshtml")]
    public class Pages_Shared__PagingXTL : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<XTL.Helpers.PagingModel>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 9 "C:\WorkSpace\Git_Clone\Auth.Net\Pages\Shared\_PagingXTL.cshtml"
  
    int currentPage  = Model.currentpage;
    int countPages   = Model.countpages;
    var generateUrl  = Model.generateUrl;


    
    if (currentPage > countPages) 
      currentPage = countPages;

    if (countPages <= 1) return;
    

    int? preview = null;
    int? next = null;

    if (currentPage > 1)
        preview = currentPage - 1;

    if (currentPage < countPages)
        next = currentPage + 1;

    // Các trang hiện thị trong điều hướng
    List<int> pagesRanges = new List<int>();    

        
    int delta      = 5;             // Số trang mở rộng về mỗi bên trang hiện tại     
    int remain     = delta * 2;     // Số trang hai bên trang hiện tại

    pagesRanges.Add(currentPage);
    // Các trang phát triển về hai bên trang hiện tại
    for (int i = 1; i <= delta; i++)
    {
        if (currentPage + i  <= countPages) {
            pagesRanges.Add(currentPage + i); 
            remain --;
        }
               
        if (currentPage - i >= 1) {
            pagesRanges.Insert(0, currentPage - i);
            remain --;
        }
            
    }    
    // Xử lý thêm vào các trang cho đủ remain 
    //(xảy ra ở đầu mút của khoảng trang không đủ trang chèn  vào)
    if (remain > 0) {
        if (pagesRanges[0] == 1) {
            for (int i = 1; i <= remain; i++)
            {
                if (pagesRanges.Last() + 1 <= countPages) {
                    pagesRanges.Add(pagesRanges.Last() + 1);
                }
            }
        }
        else {
            for (int i = 1; i <= remain; i++)
            {
                if (pagesRanges.First() - 1 > 1) {
                    pagesRanges.Insert(0, pagesRanges.First() - 1);
                }
            }
        }
    }


#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("\r\n<ul class=\"pagination\">\r\n    <!-- Previous page link -->\r\n");
#nullable restore
#line 80 "C:\WorkSpace\Git_Clone\Auth.Net\Pages\Shared\_PagingXTL.cshtml"
     if (preview != null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li class=\"page-item\">\r\n            <a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 2213, "\"", 2241, 1);
#nullable restore
#line 83 "C:\WorkSpace\Git_Clone\Auth.Net\Pages\Shared\_PagingXTL.cshtml"
WriteAttributeValue("", 2220, generateUrl(preview), 2220, 21, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Trang trước</a>\r\n        </li>\r\n");
#nullable restore
#line 85 "C:\WorkSpace\Git_Clone\Auth.Net\Pages\Shared\_PagingXTL.cshtml"
    }
    else
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li class=\"page-item disabled\">\r\n            <a class=\"page-link\" href=\"#\" tabindex=\"-1\" aria-disabled=\"true\">Trang trước</a>\r\n        </li>\r\n");
#nullable restore
#line 91 "C:\WorkSpace\Git_Clone\Auth.Net\Pages\Shared\_PagingXTL.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("      \r\n    <!-- Numbered page links -->\r\n");
#nullable restore
#line 94 "C:\WorkSpace\Git_Clone\Auth.Net\Pages\Shared\_PagingXTL.cshtml"
     foreach (var pageitem in pagesRanges)
    {
        if (pageitem != currentPage) {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li class=\"page-item\">\r\n                <a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 2661, "\"", 2690, 1);
#nullable restore
#line 98 "C:\WorkSpace\Git_Clone\Auth.Net\Pages\Shared\_PagingXTL.cshtml"
WriteAttributeValue("", 2668, generateUrl(pageitem), 2668, 22, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                    ");
#nullable restore
#line 99 "C:\WorkSpace\Git_Clone\Auth.Net\Pages\Shared\_PagingXTL.cshtml"
               Write(pageitem);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </a>\r\n            </li>\r\n");
#nullable restore
#line 102 "C:\WorkSpace\Git_Clone\Auth.Net\Pages\Shared\_PagingXTL.cshtml"
        }   
        else 
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <li class=\"page-item active\" aria-current=\"page\">\r\n                <a class=\"page-link\" href=\"#\">");
#nullable restore
#line 106 "C:\WorkSpace\Git_Clone\Auth.Net\Pages\Shared\_PagingXTL.cshtml"
                                         Write(pageitem);

#line default
#line hidden
#nullable disable
            WriteLiteral(" <span class=\"sr-only\">(current)</span></a>\r\n            </li>\r\n");
#nullable restore
#line 108 "C:\WorkSpace\Git_Clone\Auth.Net\Pages\Shared\_PagingXTL.cshtml"
        }
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n    <!-- Next page link -->\r\n");
#nullable restore
#line 113 "C:\WorkSpace\Git_Clone\Auth.Net\Pages\Shared\_PagingXTL.cshtml"
     if (next != null)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li class=\"page-item\">\r\n            <a class=\"page-link\"");
            BeginWriteAttribute("href", " href=\"", 3134, "\"", 3159, 1);
#nullable restore
#line 116 "C:\WorkSpace\Git_Clone\Auth.Net\Pages\Shared\_PagingXTL.cshtml"
WriteAttributeValue("", 3141, generateUrl(next), 3141, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Trang sau</a>\r\n        </li>\r\n");
#nullable restore
#line 118 "C:\WorkSpace\Git_Clone\Auth.Net\Pages\Shared\_PagingXTL.cshtml"
    }
    else 
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li class=\"page-item disabled\">\r\n            <a class=\"page-link\" href=\"#\" tabindex=\"-1\" aria-disabled=\"true\">Trang sau</a>\r\n        </li>\r\n");
#nullable restore
#line 124 "C:\WorkSpace\Git_Clone\Auth.Net\Pages\Shared\_PagingXTL.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</ul>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<XTL.Helpers.PagingModel> Html { get; private set; }
    }
}
#pragma warning restore 1591

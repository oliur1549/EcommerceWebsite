#pragma checksum "E:\EcommerceWebsite\EcommerceWebsite\Views\Shared\Components\Category\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "99eb6ddcc99a92c5fcf2b1eab710dfad5dda41db"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Category_Index), @"mvc.1.0.view", @"/Views/Shared/Components/Category/Index.cshtml")]
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
#line 1 "E:\EcommerceWebsite\EcommerceWebsite\Views\_ViewImports.cshtml"
using EcommerceWebsite;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\EcommerceWebsite\EcommerceWebsite\Views\_ViewImports.cshtml"
using EcommerceWebsite.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "E:\EcommerceWebsite\EcommerceWebsite\Views\_ViewImports.cshtml"
using EcommerceWebsite.Areas.Admin;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"99eb6ddcc99a92c5fcf2b1eab710dfad5dda41db", @"/Views/Shared/Components/Category/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f14eb95a65677a275d704b4a21c35d7d43375f00", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_Category_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "product", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "category", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<ul id=\"sideManu\" class=\"nav nav-tabs nav-stacked\">\r\n");
#nullable restore
#line 3 "E:\EcommerceWebsite\EcommerceWebsite\Views\Shared\Components\Category\Index.cshtml"
     foreach (var category in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <li class=\"subMenu\">\r\n            <a>  ");
#nullable restore
#line 6 "E:\EcommerceWebsite\EcommerceWebsite\Views\Shared\Components\Category\Index.cshtml"
            Write(category.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral(" </a>\r\n");
#nullable restore
#line 7 "E:\EcommerceWebsite\EcommerceWebsite\Views\Shared\Components\Category\Index.cshtml"
             if (category.InverseParents != null && category.InverseParents.Count > 0)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <ul style=\"display:none\">\r\n");
#nullable restore
#line 10 "E:\EcommerceWebsite\EcommerceWebsite\Views\Shared\Components\Category\Index.cshtml"
                     foreach (var subcategory in category.InverseParents)
                    {
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "E:\EcommerceWebsite\EcommerceWebsite\Views\Shared\Components\Category\Index.cshtml"
                         if (subcategory.Status)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <li>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "99eb6ddcc99a92c5fcf2b1eab710dfad5dda41db5444", async() => {
                WriteLiteral("<i class=\"icon-chevron-right\"></i>");
#nullable restore
#line 15 "E:\EcommerceWebsite\EcommerceWebsite\Views\Shared\Components\Category\Index.cshtml"
                                                                               Write(subcategory.Name);

#line default
#line hidden
#nullable disable
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 15 "E:\EcommerceWebsite\EcommerceWebsite\Views\Shared\Components\Category\Index.cshtml"
                     WriteLiteral(subcategory.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\r\n");
#nullable restore
#line 16 "E:\EcommerceWebsite\EcommerceWebsite\Views\Shared\Components\Category\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "E:\EcommerceWebsite\EcommerceWebsite\Views\Shared\Components\Category\Index.cshtml"
                         
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </ul>\r\n");
#nullable restore
#line 19 "E:\EcommerceWebsite\EcommerceWebsite\Views\Shared\Components\Category\Index.cshtml"
            }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </li>\r\n");
#nullable restore
#line 21 "E:\EcommerceWebsite\EcommerceWebsite\Views\Shared\Components\Category\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</ul>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591

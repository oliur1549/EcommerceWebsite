#pragma checksum "E:\EcommerceWebsite\EcommerceWebsite\Views\Shared\Components\Search\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "e84209f55304dd907cd6a408b6f13100a3522195"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_Search_Index), @"mvc.1.0.view", @"/Views/Shared/Components/Search/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e84209f55304dd907cd6a408b6f13100a3522195", @"/Views/Shared/Components/Search/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"f14eb95a65677a275d704b4a21c35d7d43375f00", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_Search_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-inline navbar-search"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("action", new global::Microsoft.AspNetCore.Html.HtmlString("products.html"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 2 "E:\EcommerceWebsite\EcommerceWebsite\Views\Shared\Components\Search\Index.cshtml"
  
    Layout = null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e84209f55304dd907cd6a408b6f13100a35221954818", async() => {
                WriteLiteral("\r\n    <input id=\"srchFld\" class=\"srchTxt\" type=\"text\" />\r\n    <select class=\"srchTxt\">\r\n");
#nullable restore
#line 9 "E:\EcommerceWebsite\EcommerceWebsite\Views\Shared\Components\Search\Index.cshtml"
         foreach (var category in Model)
        {
            

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "E:\EcommerceWebsite\EcommerceWebsite\Views\Shared\Components\Search\Index.cshtml"
             if (category.InverseParents != null && category.InverseParents.Count > 0)
            {

#line default
#line hidden
#nullable disable
                WriteLiteral("                <optgroup");
                BeginWriteAttribute("label", " label=\"", 377, "\"", 399, 1);
#nullable restore
#line 13 "E:\EcommerceWebsite\EcommerceWebsite\Views\Shared\Components\Search\Index.cshtml"
WriteAttributeValue("", 385, category.Name, 385, 14, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n");
#nullable restore
#line 14 "E:\EcommerceWebsite\EcommerceWebsite\Views\Shared\Components\Search\Index.cshtml"
                     foreach (var subcategory in category.InverseParents)
                    {
                        

#line default
#line hidden
#nullable disable
#nullable restore
#line 16 "E:\EcommerceWebsite\EcommerceWebsite\Views\Shared\Components\Search\Index.cshtml"
                         if (subcategory.Status)
                        {

#line default
#line hidden
#nullable disable
                WriteLiteral("                            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("option", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "e84209f55304dd907cd6a408b6f13100a35221956696", async() => {
#nullable restore
#line 18 "E:\EcommerceWebsite\EcommerceWebsite\Views\Shared\Components\Search\Index.cshtml"
                                                       Write(subcategory.Name);

#line default
#line hidden
#nullable disable
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.OptionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper);
                BeginWriteTagHelperAttribute();
#nullable restore
#line 18 "E:\EcommerceWebsite\EcommerceWebsite\Views\Shared\Components\Search\Index.cshtml"
                               WriteLiteral(subcategory.Id);

#line default
#line hidden
#nullable disable
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value = __tagHelperStringValueBuffer;
                __tagHelperExecutionContext.AddTagHelperAttribute("value", __Microsoft_AspNetCore_Mvc_TagHelpers_OptionTagHelper.Value, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
#nullable restore
#line 19 "E:\EcommerceWebsite\EcommerceWebsite\Views\Shared\Components\Search\Index.cshtml"
                        }

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "E:\EcommerceWebsite\EcommerceWebsite\Views\Shared\Components\Search\Index.cshtml"
                         

                    }

#line default
#line hidden
#nullable disable
                WriteLiteral("                </optgroup>\r\n");
#nullable restore
#line 23 "E:\EcommerceWebsite\EcommerceWebsite\Views\Shared\Components\Search\Index.cshtml"

            }

#line default
#line hidden
#nullable disable
#nullable restore
#line 24 "E:\EcommerceWebsite\EcommerceWebsite\Views\Shared\Components\Search\Index.cshtml"
             
        }

#line default
#line hidden
#nullable disable
                WriteLiteral("    </select>\r\n    <button type=\"submit\" id=\"submitButton\" class=\"btn btn-primary\">Go</button>\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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

#pragma checksum "F:\GitHub\Hotel Management Application\Views\Booking\_BookingPartial.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "91dbb200397f9b7692f9529428377de86468469a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Booking__BookingPartial), @"mvc.1.0.view", @"/Views/Booking/_BookingPartial.cshtml")]
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
#line 1 "F:\GitHub\Hotel Management Application\Views\_ViewImports.cshtml"
using HotelApp;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\GitHub\Hotel Management Application\Views\_ViewImports.cshtml"
using HotelApp.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"91dbb200397f9b7692f9529428377de86468469a", @"/Views/Booking/_BookingPartial.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"4a233b9cca9704942898401d0bf47e554f69be65", @"/Views/_ViewImports.cshtml")]
    public class Views_Booking__BookingPartial : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<HotelApp.ViewModel.BookingModel>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Delete", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onsubmit", new global::Microsoft.AspNetCore.Html.HtmlString("return jQueryAjaxDelete(this);"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("d-inline"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n");
            WriteLiteral("\r\n<table class=\"table table-striped table-bordered\" id=\"myTable\">\r\n    <thead>\r\n        <tr>\r\n            <th> ");
#nullable restore
#line 7 "F:\GitHub\Hotel Management Application\Views\Booking\_BookingPartial.cshtml"
            Write(Html.DisplayNameFor(model => model.BookingId));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </th>\r\n            <th> ");
#nullable restore
#line 8 "F:\GitHub\Hotel Management Application\Views\Booking\_BookingPartial.cshtml"
            Write(Html.DisplayNameFor(model => model.RoomNum));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </th>\r\n            <th> ");
#nullable restore
#line 9 "F:\GitHub\Hotel Management Application\Views\Booking\_BookingPartial.cshtml"
            Write(Html.DisplayNameFor(model => model.FromDate));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </th>\r\n            <th> ");
#nullable restore
#line 10 "F:\GitHub\Hotel Management Application\Views\Booking\_BookingPartial.cshtml"
            Write(Html.DisplayNameFor(model => model.ToDate));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </th>\r\n            <th> ");
#nullable restore
#line 11 "F:\GitHub\Hotel Management Application\Views\Booking\_BookingPartial.cshtml"
            Write(Html.DisplayNameFor(model => model.CustomerId));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </th>\r\n            <th> ");
#nullable restore
#line 12 "F:\GitHub\Hotel Management Application\Views\Booking\_BookingPartial.cshtml"
            Write(Html.DisplayNameFor(model => model.DailyPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </th>\r\n            <th> ");
#nullable restore
#line 13 "F:\GitHub\Hotel Management Application\Views\Booking\_BookingPartial.cshtml"
            Write(Html.DisplayNameFor(model => model.TotalPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </th>\r\n            <th> ");
#nullable restore
#line 14 "F:\GitHub\Hotel Management Application\Views\Booking\_BookingPartial.cshtml"
            Write(Html.DisplayNameFor(model => model.IsPaid));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </th>\r\n            <th>\r\n                <a");
            BeginWriteAttribute("onclick", " onclick=\"", 747, "\"", 854, 5);
            WriteAttributeValue("", 757, "showInPopup(\'", 757, 13, true);
#nullable restore
#line 16 "F:\GitHub\Hotel Management Application\Views\Booking\_BookingPartial.cshtml"
WriteAttributeValue("", 770, Url.Action("SaveBooking", "Booking", null, Context.Request.Scheme), 770, 67, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 837, "\',", 837, 2, true);
            WriteAttributeValue(" ", 839, "\'New", 840, 5, true);
            WriteAttributeValue(" ", 844, "Booking\')", 845, 10, true);
            EndWriteAttribute();
            WriteLiteral("\r\n                   class=\"btn btn-success text-white\">\r\n                    Create New\r\n                </a>\r\n            </th>\r\n        </tr>\r\n    </thead>\r\n    <tbody>\r\n");
#nullable restore
#line 24 "F:\GitHub\Hotel Management Application\Views\Booking\_BookingPartial.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td> ");
#nullable restore
#line 27 "F:\GitHub\Hotel Management Application\Views\Booking\_BookingPartial.cshtml"
                Write(Html.DisplayFor(modelItem => item.BookingId));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                <td> ");
#nullable restore
#line 28 "F:\GitHub\Hotel Management Application\Views\Booking\_BookingPartial.cshtml"
                Write(Html.DisplayFor(modelItem => item.RoomNum));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                <td> ");
#nullable restore
#line 29 "F:\GitHub\Hotel Management Application\Views\Booking\_BookingPartial.cshtml"
                Write(Html.DisplayFor(modelItem => item.FromDate));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                <td> ");
#nullable restore
#line 30 "F:\GitHub\Hotel Management Application\Views\Booking\_BookingPartial.cshtml"
                Write(Html.DisplayFor(modelItem => item.ToDate));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                <td> ");
#nullable restore
#line 31 "F:\GitHub\Hotel Management Application\Views\Booking\_BookingPartial.cshtml"
                Write(Html.DisplayFor(modelItem => item.CustomerId));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                <td> ");
#nullable restore
#line 32 "F:\GitHub\Hotel Management Application\Views\Booking\_BookingPartial.cshtml"
                Write(Html.DisplayFor(modelItem => item.DailyPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                <td> ");
#nullable restore
#line 33 "F:\GitHub\Hotel Management Application\Views\Booking\_BookingPartial.cshtml"
                Write(Html.DisplayFor(modelItem => item.TotalPrice));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                <td> ");
#nullable restore
#line 34 "F:\GitHub\Hotel Management Application\Views\Booking\_BookingPartial.cshtml"
                Write(Html.DisplayFor(modelItem => item.IsPaid));

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                <td>\r\n                    <a");
            BeginWriteAttribute("onclick", " onclick=\"", 1725, "\"", 1858, 5);
            WriteAttributeValue("", 1735, "showInPopup(\'", 1735, 13, true);
#nullable restore
#line 36 "F:\GitHub\Hotel Management Application\Views\Booking\_BookingPartial.cshtml"
WriteAttributeValue("", 1748, Url.Action("SaveBooking", "Booking", new { id = item.BookingId }, Context.Request.Scheme), 1748, 90, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1838, "\',", 1838, 2, true);
            WriteAttributeValue(" ", 1840, "\'Update", 1841, 8, true);
            WriteAttributeValue(" ", 1848, "Booking\')", 1849, 10, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-info text-white\">\r\n                        Edit\r\n                    </a>\r\n                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "91dbb200397f9b7692f9529428377de86468469a11057", async() => {
                WriteLiteral("\r\n                        <input type=\"submit\" value=\"DELETE\" class=\"btn btn-danger\" />\r\n                    ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 39 "F:\GitHub\Hotel Management Application\Views\Booking\_BookingPartial.cshtml"
                                                WriteLiteral(item.BookingId);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                </td>\r\n            </tr>\r\n");
#nullable restore
#line 44 "F:\GitHub\Hotel Management Application\Views\Booking\_BookingPartial.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<HotelApp.ViewModel.BookingModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591
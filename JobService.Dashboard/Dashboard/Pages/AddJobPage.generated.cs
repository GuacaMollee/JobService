﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JobService.Dashboard.Dashboard.Pages
{
    using System;
    
    #line 2 "..\..\Dashboard\Pages\AddJobPage.cshtml"
    using System.Collections;
    
    #line default
    #line hidden
    
    #line 3 "..\..\Dashboard\Pages\AddJobPage.cshtml"
    using System.Collections.Generic;
    
    #line default
    #line hidden
    using System.Linq;
    using System.Text;
    
    #line 4 "..\..\Dashboard\Pages\AddJobPage.cshtml"
    using Hangfire.Dashboard;
    
    #line default
    #line hidden
    
    #line 5 "..\..\Dashboard\Pages\AddJobPage.cshtml"
    using Hangfire.Dashboard.Pages;
    
    #line default
    #line hidden
    
    #line 6 "..\..\Dashboard\Pages\AddJobPage.cshtml"
    using Hangfire.Dashboard.Resources;
    
    #line default
    #line hidden
    
    #line 7 "..\..\Dashboard\Pages\AddJobPage.cshtml"
    using JobService.Dashboard.Server;
    
    #line default
    #line hidden
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("RazorGenerator", "2.0.0.0")]
    internal partial class AddJobPage : RazorPage
    {
#line hidden

        public override void Execute()
        {


WriteLiteral("\r\n");









            
            #line 9 "..\..\Dashboard\Pages\AddJobPage.cshtml"
  
    Layout = new LayoutPage("Hangfire Add jobs");


            
            #line default
            #line hidden
WriteLiteral("<script src=\"https://ajax.googleapis.com/ajax/libs/jquery/3.3.1/jquery.min.js\"></" +
"script>\r\n\r\n<style>\r\n\r\n    body {\r\n        width: 50%;\r\n        margin: 0 auto;\r\n" +
"        padding-bottom: 20px;\r\n    }\r\n\r\n    input[type=number] {\r\n        height" +
": 25px;\r\n        width: 52px;\r\n    }\r\n\r\n    .search-field input[type=text] {\r\n  " +
"      width: 152px !important;\r\n    }\r\n\r\n    .input-label {\r\n        text-align:" +
" right;\r\n    }\r\n</style>\r\n<div>\r\n    \r\n    <div class=\"container\">\r\n        <div" +
" class=\"row\"><h1>Create HTTP / REST / JSON Job</h1></div>\r\n        <br />\r\n     " +
"   <div class=\"row\">\r\n            <div class=\"col-md-3\"><label>Job type:</label>" +
"</div>\r\n            <div class=\"col-md-6\">\r\n                <select class=\"form-" +
"control\" id=\"httpJobType\">\r\n                    <option value=\"recurring\">Recurr" +
"ing</option>\r\n                    <option value=\"fire-and-forget\" selected>Fire-" +
"and-forget</option>\r\n                    <option value=\"delayed\">Delayed</option" +
">\r\n                </select>\r\n            </div>\r\n        </div>\r\n        <br />" +
"\r\n        <div class=\"row\">\r\n            <div class=\"col-md-3\"><label>Http endpo" +
"int:</label></div>\r\n            <div class=\"col-md-6\"><input class=\"form-control" +
"\" id=\"httpJobEndpoint\" type=\"text\" /></div>\r\n        </div>\r\n        <br />\r\n   " +
"     <div class=\"row\">\r\n            <div class=\"col-md-3\"><label>Http body (JSON" +
"):</label></div>\r\n            <div class=\"col-md-6\"><textarea class=\"form-contro" +
"l\" id=\"httpJobBody\" cols=\"70\" rows=\"15\"></textarea></div>\r\n        </div>\r\n     " +
"   <br />\r\n        <label>Headers:</label><button class=\'btn\' id=\"addHttpHeaders" +
"\">+</button>\r\n        <div class=\"container\" id=\"httpHeaders\">\r\n\r\n            ");



WriteLiteral(@"
        </div>
        <br />
        <div class=""row"">
            <div class=""col-md-3""><label>Job name:</label></div>
            <div class=""col-md-6""><input class=""form-control"" id=""httpJobName"" type=""text"" /></div>
        </div>
        <br />
        <label>Tags:</label><button class='btn' id=""addHttpTags"">+</button>
        <div class=""container"" id=""httpTags"">

            ");



WriteLiteral("\r\n        </div>\r\n        <br />\r\n        <div class=\"row\" id=\"recurring\" style=\"" +
"display: none;\">\r\n            <div class=\"col-md-3\"><label>Job duration (Recurri" +
"ng timing in CRON expression):</label></div>\r\n            <div class=\"col-md-6\">" +
"<input class=\"form-control\" id=\"httpJobDuration\" type=\"text\" /></div>\r\n        <" +
"/div>\r\n        <div class=\"row\" id=\"delayed\" style=\"display: none;\">\r\n          " +
"  <div class=\"col-md-3\"><label>Job delay time in milliseconds:</label></div>\r\n  " +
"          <div class=\"col-md-6\"><input class=\"form-control\" id=\"httpJobDelayed\" " +
"type=\"text\" /></div>\r\n        </div>\r\n        <br />\r\n        <div class=\"row\">\r" +
"\n            <button class=\'btn\' id=\"AddHttpJob\" onclick=\"addHttpJob()\">Add HTTP" +
"/JSON Job</button>\r\n            <button class=\'btn\' onclick=\"clearHttpJob()\">Cle" +
"ar</button>\r\n        </div>\r\n\r\n        <hr />\r\n\r\n        <div class=\"row\"><h1>Cr" +
"eate Stored Procedure Job</h1></div>\r\n        <br />\r\n        <div class=\"row\">\r" +
"\n            <div class=\"col-md-3\"><label>Job type:</label></div>\r\n            <" +
"div class=\"col-md-6\">\r\n                <select class=\"form-control\" id=\"spjobTyp" +
"e\">\r\n                    <option value=\"recurring\">Recurring</option>\r\n         " +
"           <option value=\"fire-and-forget\" selected>Fire-and-forget</option>\r\n  " +
"                  <option value=\"delayed\">Delayed</option>\r\n                </se" +
"lect>\r\n            </div>\r\n        </div>\r\n        <br />\r\n        <div class=\"r" +
"ow\">\r\n            <div class=\"col-md-3\"><label>Stored Procedure name:</label></d" +
"iv>\r\n            <div class=\"col-md-6\"><input class=\"form-control\" id=\"storedPro" +
"cedureName\" type=\"text\" /></div>\r\n        </div>\r\n        <br />\r\n        <label" +
">Parameters:</label><button class=\'btn\' id=\"addSpParameter\">+</button>\r\n        " +
"<div class=\"container\" id=\"spParameters\">\r\n\r\n            ");



WriteLiteral(@"
        </div>
        <br />
        <div class=""row"">
            <div class=""col-md-3""><label>Job name:</label></div>
            <div class=""col-md-6""><input class=""form-control"" id=""storedProcedureJobName"" type=""text"" /></div>
        </div>
        <br />
        <label>Tags:</label><button class='btn' id=""addSpTags"">+</button>
        <div class=""container"" id=""spTags"">

            ");



WriteLiteral("\r\n        </div>\r\n        <br />\r\n        <div class=\"row\" id=\"recurringSp\" style" +
"=\"display: none;\">\r\n            <div class=\"col-md-3\"><label>Job duration (Recur" +
"ring timing in CRON expression):</label></div>\r\n            <div class=\"col-md-6" +
"\"><input class=\"form-control\" id=\"spJobDuration\" type=\"text\" /></div>\r\n        <" +
"/div>\r\n        <div class=\"row\" id=\"delayedSp\" style=\"display: none;\">\r\n        " +
"    <div class=\"col-md-3\"><label>Job delay time in milliseconds:</label></div>\r\n" +
"            <div class=\"col-md-6\"><input class=\"form-control\" id=\"spJobDelayed\" " +
"type=\"text\" /></div>\r\n        </div>\r\n        <br />\r\n        <div class=\"row\">\r" +
"\n            <button class=\'btn\' id=\"AddStoredProcedureJob\" onclick=\"addSPJob()\"" +
">Add Stored Procedure Job</button>\r\n            <button class=\'btn\' onclick=\"cle" +
"arSpJob()\">Clear</button>\r\n        </div>\r\n\r\n        <hr />\r\n\r\n        <div clas" +
"s=\"row\">\r\n            <div class=\"row\"><h1>Cron generator</h1></div>\r\n          " +
"  <div>\r\n                <!-- Nav tabs -->\r\n                <ul class=\"nav nav-t" +
"abs\" role=\"tablist\">\r\n                    <li role=\"presentation\" class=\"active\"" +
">\r\n                        <a href=\"#minute\" aria-controls=\"minute\" role=\"tab\" d" +
"ata-toggle=\"tab\">Minutes</a>\r\n                    </li>\r\n                    <li" +
" role=\"presentation\">\r\n                        <a href=\"#hour\" aria-controls=\"ho" +
"ur\" role=\"tab\" data-toggle=\"tab\">Hours</a>\r\n                    </li>\r\n         " +
"           <li role=\"presentation\">\r\n                        <a href=\"#day\" aria" +
"-controls=\"day\" role=\"tab\" data-toggle=\"tab\">Days</a>\r\n                    </li>" +
"\r\n                    <li role=\"presentation\">\r\n                        <a href=" +
"\"#month\" aria-controls=\"month\" role=\"tab\" data-toggle=\"tab\">Months</a>\r\n        " +
"            </li>\r\n                    <li role=\"presentation\">\r\n               " +
"         <a href=\"#week\" aria-controls=\"week\" role=\"tab\" data-toggle=\"tab\">Weekd" +
"ay</a>\r\n                    </li>\r\n                </ul>\r\n                <!-- T" +
"ab panes -->\r\n                <div class=\"tab-content\">\r\n                    <di" +
"v role=\"tabpanel\" class=\"tab-pane active\" id=\"minute\">\r\n                        " +
"<div class=\"radio\">\r\n                            <label>\r\n                      " +
"          <input type=\"radio\" name=\"minuteType\" value=\"All\" checked=\"checked\">\r\n" +
"                                EveryMinute\r\n                            </label" +
">\r\n                        </div>\r\n                        <div class=\"radio\">\r\n" +
"                            <label>\r\n                                <input type" +
"=\"radio\" name=\"minuteType\" value=\"Cyclic\">\r\n                                Ever" +
"yMinuteBetweenMinute\r\n                                <input type=\"number\" id=\"m" +
"inuteTypeCyclic_1\" value=\"\">\r\n                                -\r\n               " +
"                 <input type=\"number\" id=\"minuteTypeCyclic_2\" value=\"\">\r\n       " +
"                         Minutes\r\n                            </label>\r\n        " +
"                </div>\r\n                        <div class=\"radio\">\r\n           " +
"                 <label>\r\n                                <input type=\"radio\" na" +
"me=\"minuteType\" value=\"Interval\">\r\n                                StartingAtMin" +
"ute\r\n                                <input type=\"number\" id=\"minuteTypeInterval" +
"_1\" value=\"\">\r\n                                StartingAtMinute2\r\n              " +
"                  <input type=\"number\" id=\"minuteTypeInterval_2\" value=\"\">\r\n    " +
"                            Minutess\r\n                            </label>\r\n    " +
"                    </div>\r\n                        <div class=\"radio\">\r\n       " +
"                     <label>\r\n                                <input type=\"radio" +
"\" name=\"minuteType\" value=\"Assigned\">\r\n                                SpecificM" +
"inute\r\n                            </label>\r\n                        </div>\r\n\r\n " +
"                       <div style=\"margin-left: 20px;\">\r\n                       " +
"     <select id=\"minuteTypeAssigned_1\" data-placeholder=\"Choose\"\r\n              " +
"                      style=\"width:350px;\" multiple></select>\r\n                 " +
"       </div>\r\n\r\n                        <div class=\"radio\">\r\n                  " +
"          <label>\r\n                                <input type=\"radio\" name=\"min" +
"uteType\" value=\"NotAssigned\">\r\n                                NoSpecific\r\n     " +
"                       </label>\r\n                        </div>\r\n               " +
"     </div>\r\n\r\n                    <div role=\"tabpanel\" class=\"tab-pane\" id=\"hou" +
"r\">\r\n                        <div class=\"radio\">\r\n                            <l" +
"abel>\r\n                                <input type=\"radio\" name=\"hourType\" value" +
"=\"All\" checked=\"checked\">\r\n                                EveryHour\r\n          " +
"                  </label>\r\n                        </div>\r\n                    " +
"    <div class=\"radio\">\r\n                            <label>\r\n                  " +
"              <input type=\"radio\" name=\"hourType\" value=\"Cyclic\">\r\n             " +
"                   EveryHourBetweenHour\r\n                                <input " +
"type=\"number\" id=\"hourTypeCyclic_1\" value=\"\">\r\n                                -" +
"\r\n                                <input type=\"number\" id=\"hourTypeCyclic_2\" val" +
"ue=\"\">\r\n                                Hours\r\n                            </lab" +
"el>\r\n                        </div>\r\n                        <div class=\"radio\">" +
"\r\n                            <label>\r\n                                <input ty" +
"pe=\"radio\" name=\"hourType\" value=\"Interval\">\r\n                                St" +
"artingAtHour\r\n                                <input type=\"number\" id=\"hourTypeI" +
"nterval_1\" value=\"\">\r\n                                StartingAtHour2\r\n         " +
"                       <input type=\"number\" id=\"hourTypeInterval_2\" value=\"\">\r\n " +
"                               Hourss\r\n                            </label>\r\n   " +
"                     </div>\r\n                        <div class=\"radio\">\r\n      " +
"                      <label>\r\n                                <input type=\"radi" +
"o\" name=\"hourType\" value=\"Assigned\">\r\n                                Specific\r\n" +
"                            </label>\r\n                        </div>\r\n          " +
"              <div style=\"margin-left: 20px;\">\r\n                            <sel" +
"ect id=\"hourTypeAssigned_1\" data-placeholder=\"Choose\"\r\n                         " +
"           style=\"width:350px;\" multiple></select>\r\n                        </di" +
"v>\r\n                        <div class=\"radio\">\r\n                            <la" +
"bel>\r\n                                <input type=\"radio\" name=\"hourType\" value=" +
"\"NotAssigned\">\r\n                                NoSpecific\r\n                    " +
"        </label>\r\n                        </div>\r\n                    </div>\r\n\r\n" +
"                    <div role=\"tabpanel\" class=\"tab-pane\" id=\"day\">\r\n           " +
"             <div class=\"radio\">\r\n                            <label>\r\n         " +
"                       <input type=\"radio\" name=\"dayType\" value=\"All\" checked=\"c" +
"hecked\">\r\n                                EveryDay\r\n                            " +
"</label>\r\n                        </div>\r\n                        <div class=\"ra" +
"dio\">\r\n                            <label>\r\n                                <inp" +
"ut type=\"radio\" name=\"dayType\" value=\"Cyclic\">\r\n                                " +
"EveryDayBetweenDay\r\n                                <input type=\"number\" id=\"day" +
"TypeCyclic_1\" value=\"\">\r\n                                -\r\n                    " +
"            <input type=\"number\" id=\"dayTypeCyclic_2\" value=\"\">\r\n               " +
"                 Days\r\n                            </label>\r\n                   " +
"     </div>\r\n                        <div class=\"radio\">\r\n                      " +
"      <label>\r\n                                <input type=\"radio\" name=\"dayType" +
"\" value=\"Interval\">\r\n                                StartingAtDay\r\n            " +
"                    <input type=\"number\" id=\"dayTypeInterval_1\" value=\"\">\r\n     " +
"                           StartingAtDay2\r\n                                <inpu" +
"t type=\"number\" id=\"dayTypeInterval_2\" value=\"\">\r\n                              " +
"  Dayss\r\n                            </label>\r\n                        </div>\r\n " +
"                       <div class=\"radio\">\r\n                            <label>\r" +
"\n                                <input type=\"radio\" name=\"dayType\" value=\"Assig" +
"ned\">\r\n                                Specific\r\n                            </l" +
"abel>\r\n                        </div>\r\n                        <div style=\"margi" +
"n-left: 20px;\">\r\n                            <select id=\"dayTypeAssigned_1\" data" +
"-placeholder=\"Choose\"\r\n                                    style=\"width:350px;\" " +
"multiple></select>\r\n                        </div>\r\n                        <div" +
" class=\"radio\">\r\n                            <label>\r\n                          " +
"      <input type=\"radio\" name=\"dayType\" value=\"RecentDays\">\r\n                  " +
"              DayA\r\n                                <input type=\"number\" id=\"day" +
"TypeRecentDays_1\" value=\"\">\r\n                                DayB\r\n             " +
"               </label>\r\n                        </div>\r\n                       " +
" <div class=\"radio\">\r\n                            <label>\r\n                     " +
"           <input type=\"radio\" name=\"dayType\" value=\"LastDayOfMonth\">\r\n         " +
"                       LastDayOfMonth\r\n                            </label>\r\n   " +
"                     </div>\r\n                        <div class=\"radio\">\r\n      " +
"                      <label>\r\n                                <input type=\"radi" +
"o\" name=\"dayType\" value=\"LastDayOfMonthRecentDays\">\r\n                           " +
"     LastWeedDayOfMonth\r\n                            </label>\r\n                 " +
"       </div>\r\n                        <div class=\"radio\">\r\n                    " +
"        <label>\r\n                                <input type=\"radio\" name=\"dayTy" +
"pe\" value=\"NotAssigned\">\r\n                                NoSpecific\r\n          " +
"                  </label>\r\n                        </div>\r\n                    " +
"</div>\r\n\r\n                    <div role=\"tabpanel\" class=\"tab-pane\" id=\"month\">\r" +
"\n                        <div class=\"radio\">\r\n                            <label" +
">\r\n                                <input type=\"radio\" name=\"monthType\" value=\"A" +
"ll\" checked=\"checked\">\r\n                                EveryMonth\r\n            " +
"                </label>\r\n                        </div>\r\n                      " +
"  <div class=\"radio\">\r\n                            <label>\r\n                    " +
"            <input type=\"radio\" name=\"monthType\" value=\"Cyclic\">\r\n              " +
"                  EveryMonthBetweenMonth\r\n                                <input" +
" type=\"number\" id=\"monthTypeCyclic_1\" value=\"\">\r\n                               " +
" -\r\n                                <input type=\"number\" id=\"monthTypeCyclic_2\" " +
"value=\"\">\r\n                                Months\r\n                            <" +
"/label>\r\n                        </div>\r\n                        <div class=\"rad" +
"io\">\r\n                            <label>\r\n                                <inpu" +
"t type=\"radio\" name=\"monthType\" value=\"Interval\">\r\n                             " +
"   StartingAtMonth\r\n                                <input type=\"number\" id=\"mon" +
"thTypeInterval_1\" value=\"\">\r\n                                StartingAtMontn2\r\n " +
"                               <input type=\"number\" id=\"monthTypeInterval_2\" val" +
"ue=\"\">\r\n                                Monthss\r\n                            </l" +
"abel>\r\n                        </div>\r\n                        <div class=\"radio" +
"\">\r\n                            <label>\r\n                                <input " +
"type=\"radio\" name=\"monthType\" value=\"Assigned\">\r\n                               " +
" Specific\r\n                            </label>\r\n                        </div>\r" +
"\n                        <div style=\"margin-left: 20px;\">\r\n                     " +
"       <select id=\"monthTypeAssigned_1\" data-placeholder=\"Choose\"\r\n             " +
"                       style=\"width:350px;\" multiple></select>\r\n                " +
"        </div>\r\n                        <div class=\"radio\">\r\n                   " +
"         <label>\r\n                                <input type=\"radio\" name=\"mont" +
"hType\" value=\"NotAssigned\">\r\n                                NoSpecific\r\n       " +
"                     </label>\r\n                        </div>\r\n                 " +
"   </div>\r\n\r\n                    <div role=\"tabpanel\" class=\"tab-pane\" id=\"week\"" +
">\r\n                        <div class=\"radio\">\r\n                            <lab" +
"el>\r\n                                <input type=\"radio\" name=\"weekType\" value=\"" +
"All\" checked=\"checked\">\r\n                                EveryWeekday\r\n         " +
"                   </label>\r\n                        </div>\r\n                   " +
"     <div class=\"radio\">\r\n                            <label>\r\n                 " +
"               <input type=\"radio\" name=\"weekType\" value=\"Cyclic\">\r\n            " +
"                    EveryWeekdayBetweenWeekday\r\n                                " +
"<input type=\"number\" id=\"weekTypeCyclic_1\" value=\"\">\r\n                          " +
"      -\r\n                                <input type=\"number\" id=\"weekTypeCyclic" +
"_2\" value=\"\">\r\n                                Weekday\r\n                        " +
"    </label>\r\n                        </div>\r\n                        <div class" +
"=\"radio\">\r\n                            <label>\r\n                                " +
"<input type=\"radio\" name=\"weekType\" value=\"WeeksOfWeek\">\r\n                      " +
"          WeekDay1\r\n                                <input type=\"number\" id=\"wee" +
"kTypeWeeksOfWeek_1\" value=\"\">\r\n                                WeekDay12\r\n      " +
"                          <input type=\"number\" id=\"weekTypeWeeksOfWeek_2\" value=" +
"\"\">\r\n                            </label>\r\n                        </div>\r\n     " +
"                   <div class=\"radio\">\r\n                            <label>\r\n   " +
"                             <input type=\"radio\" name=\"weekType\" value=\"Assigned" +
"\">\r\n                                Specific\r\n                            </labe" +
"l>\r\n                        </div>\r\n                        <div style=\"margin-l" +
"eft: 20px;\">\r\n                            <select id=\"weekTypeAssigned_1\" data-p" +
"laceholder=\"Choose\"\r\n                                    style=\"width:350px;\" mu" +
"ltiple></select>\r\n                        </div>\r\n                        <div c" +
"lass=\"radio\">\r\n                            <label>\r\n                            " +
"    <input type=\"radio\" name=\"weekType\" value=\"LastWeekOfMonth\">\r\n              " +
"                  LastWeekdayOfMonth\r\n                                <input typ" +
"e=\"number\" id=\"weekTypeLastWeekOfMonth_1\" value=\"1\">\r\n                          " +
"  </label>\r\n                        </div>\r\n\r\n                        <div class" +
"=\"radio\">\r\n                            <label>\r\n                                " +
"<input type=\"radio\" name=\"weekType\" value=\"NotAssigned\">\r\n                      " +
"          NoSpecific\r\n                            </label>\r\n                    " +
"    </div>\r\n                    </div>\r\n                </div>\r\n            </di" +
"v>\r\n            <hr>\r\n            <div class=\"panel panel-info\">\r\n              " +
"  <div class=\"panel-heading\">\r\n                    <h3 class=\"panel-title\">CronR" +
"esult</h3>\r\n                </div>\r\n                <div class=\"panel-body\">\r\n  " +
"                  <form class=\"form-inline\">\r\n                        <div class" +
"=\"form-group\">\r\n                            <label for=\"result\" class=\"sr-only\">" +
"Password</label>\r\n                            <input type=\"text\" class=\"form-con" +
"trol\" style=\"width: 500px;\" id=\"result\" placeholder=\"CronResult\">\r\n             " +
"           </div>\r\n                        <button type=\"button\" id=\"analysis\" c" +
"lass=\"btn btn-default\">DESCRIBE EXPRESSION</button>\r\n                    </form>" +
"\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>" +
"\r\n");


        }
    }
}
#pragma warning restore 1591

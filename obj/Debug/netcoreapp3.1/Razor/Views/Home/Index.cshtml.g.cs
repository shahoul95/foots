#pragma checksum "/Users/Shahoul/Projects/foots/foots/Views/Home/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "61933659fb095dced42daa73b65803b4326e9d19"
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
#line 1 "/Users/Shahoul/Projects/foots/foots/Views/_ViewImports.cshtml"
using foots;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/Users/Shahoul/Projects/foots/foots/Views/_ViewImports.cshtml"
using foots.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"61933659fb095dced42daa73b65803b4326e9d19", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"90f90817af19dc9c5d52aa57d7087ca0d198fbbe", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("bg-danger"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n<html>\n\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "61933659fb095dced42daa73b65803b4326e9d193443", async() => {
                WriteLiteral(@"

    <meta charset=""UTF -8"" />
    <script src=""https://code.jquery.com/jquery-3.1.0.min.js""></script>
    <link rel=""stylesheet"" href=""https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css""
          integrity=""sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T"" crossorigin=""anonymous"">
    <link rel=""stylesheet"" href=""https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/css/bootstrap.min.css""
          integrity=""sha384-ggOyR0iXCbMQv3Xipma34MD+dH/1fQ784/j6cY/iJTQUOhcWr7x9JvoRxT2MZw1T"" crossorigin=""anonymous"">
    <link rel=""stylesheet"" href=""https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css"">
    <script src=""https://code.jquery.com/jquery-3.3.1.slim.min.js""
            integrity=""sha384-q8i/X+965DzO0rT7abK41JStQIAqVgRVzpbzo5smXKp4YfRvH+8abtTE1Pi6jizo""
            crossorigin=""anonymous""></script>
    <script src=""https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.14.7/umd/popper.min.js""
            integrity=""sha384-UO2eT0CpHqdSJQ6hJty");
                WriteLiteral(@"5KVphtPhzWj9WO1clHTMGa3JDZwrnQq4sF86dIHNDz0W1""
            crossorigin=""anonymous""></script>
    <script src=""https://stackpath.bootstrapcdn.com/bootstrap/4.3.1/js/bootstrap.min.js""
            integrity=""sha384-JjSmVgyd0p3pXB1rRibZUAYoIIy6OrQ6VrjIEaFf/nJGzIxFDsf4x0xIM+B07jRM""
            crossorigin=""anonymous""></script>
    <script src=""https://ajax.googleapis.com/ajax/libs/jquery/3.4.1/jquery.min.js""></script>
    <style>
        a:hover {
        background-color: gainsboro;
    }

        .container {
        padding-bottom: 0;
        background-color: whitesmoke;
    }
    </style>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "61933659fb095dced42daa73b65803b4326e9d196091", async() => {
                WriteLiteral(@"
  
    <div class=""container"">


        <div class=""row"">
            <div class=""col-xs-12 col-sm-12 col-md-12  "" style=""text-decoration: underline;"">
                <h1> ASC Garges Djibson futsal</h1>

            </div>
        </div>
        <div class=""row"">
            <div class=""col-xs-12 col-sm-12 col-md-12 mx-auto "">
                <p>

                    L'ASC Garges Djibson futsal est un club français de futsal basé à Garges-lès-Gonesse dans le
                    Val-d'Oise.

                    L'ASC gargeoise Djibson futsal prend la continuité des clubs fusionnés en championnat de France de
                    futsal. Il améliore progressivement ses performances jusqu'au milieu des années 2010, où il devient
                    un des meilleurs clubs français. Double finaliste de la Coupe de France en 2015 puis 2016, perdant
                    aussi en finale de Division 1 2015-2016, Garges Djibson ouvre son palmarès l'année suivante en étant
                    sacré champion de France p");
                WriteLiteral(@"our la première fois au terme de la saison 2016-2017.

                    Le GD futsal dispute ses matchs à domicile au gymnase Allende Neruda, et y évolue en rouge et blanc.
                    Le club est présidé par Moussa Nianghane et entraînée par Joaquim Antun.
                </p>



            </div>
        </div>
        <div class=""row"">
            <div class=""col-xs-12 col-sm-12 col-md-12 mx-auto "" style=""text-decoration: underline;"">
                <h1>HISTOIRE</h1>
                <h4>Genèse (2001-2008)</h4>


            </div>
        </div>
        <div class=""row"">
            <div class=""col-xs-12 col-sm-12 col-md-12 mx-auto "">

                <p>
                    En 2001, le club portant le nom du quartier de Garges-lès-Gonesse, la Muette, est fondé2.

                    En 2003, le Djibson futsal voit le jour notamment grâce à Moussa Nianghane. Il porte le nom d'un des
                    initiateurs, décédé peu avant. En février 2005, le club présidé par Prince Sékyère est co-le");
                WriteLiteral(@"ader du
                    championnat de première série, plus haut niveau des compétitions gérées par la Ligue de Paris
                    Île-de-France. La plupart sont des joueurs de l'effectif évoluent aussi en championnat régional de
                    football sur herbe3.

                    Durant les années 2000, Garges voit éclore Wissam Ben Yedder au futsal, avant qu'il ne devienne
                    footballeur professionnel2. Il évolue notamment à l'ASL Djibson en 2007-2008, puis à l'ASC Union
                    gargeoise en 2009-20104. Il joue d'ailleurs six matchs et marque un but avec l'équipe de France de
                    futsal5.
                </p>
                <h4 style=""text-decoration: underline;"">Fusion et montée en puissance (2008-2015)</h4>
                <p>
                    À l'été 2008, l'Association Garges futsal6 fusionne avec l'ASL Djibson, second club de la ville,
                    pour donner le Garges Djibson futsal2.

                    Pour l'exercice 201");
                WriteLiteral(@"2-2013, le Garges Djibsion futsal termine cinquième de la poule A de Division 1.

                    La saison 2013-2014 est moins réussie avec une huitième place finale de la poule unique à treize
                    clubs.

                    Lors de la saison 2014-2015, Garges Djibson perd en finale de la Coupe de France7.
                </p>
                <h4 style=""text-decoration: underline;"">Club majeur de Division 1 (depuis 2015)</h4>
                <p>
                    Durant l'exercice 2015-2016, l'équipe est finaliste de la Coupe nationale pour la deuxième fois
                    consécutive7. D'abord défaite par le Sporting Paris en demi-finale (7-3), Garges porte réserve sur
                    la qualification de trois joueurs adverses. Djibson obtient gain de cause et est qualifié pour la
                    finale contre le KB United qu'il perd (4-3).

                    Au terme de la saison 2016-2017, Garges Djibson est champion de France4. Première de la phase
                   ");
                WriteLiteral(@" régulière, l'équipe élimine FC béthunois en demi-finale (6-4). En finale, elle l'emporte de peu face
                    au Kremlin-Bicêtre United (5-4) et se qualifie pour la première fois en Coupe d'Europe8.

                    Lors de la Coupe de l'UEFA 2017-2018, Garges Djibson débute la compétition au tour principal.
                    L'équipe termine dernière de son groupe avec deux défaites à domicile et un match nul à l'extérieur,
                    et est éliminée. Dans l’effectif, le club compte sept internationaux français dont trois (Landry
                    N'Gala, Mickael de Sa Andrade et Samba Kebe) ont participé à l’Euro 2018 en Slovénie7. En Division
                    1, Djibson termine troisième de la phase régulière et se qualifie pour les play-offs. Contre le
                    second, Toulon EF, Garges s'incline après prolongation (7-5 ap).
                </p>
            </div>


        </div>

        
    </div>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n\n\n</html>");
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

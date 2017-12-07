using System.Web;
using System.Web.Optimization;

namespace ImgBoard.Web
{
    public class BundleConfig
    {
        // Pour plus d'informations sur le regroupement, visitez https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/vendor/jquery-{version}.js"));
            
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/vendor/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/vendor/bootstrap.js",
                      "~/Scripts/vendor/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/knockout").Include(
                        "~/Scripts/vendor/knockout-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/boardjs").Include(
                        "~/Scripts/vendor/masonry.pkgd.min.js",
                        "~/Scripts/vendor/imagesloaded.pkgd.min.js",
                        "~/Scripts/Framework/Util/Util.js",
                        "~/Scripts/Framework/Models/FrontModels.js",
                        "~/Scripts/Framework/ApiRequests/GetImagesRequest.js",
                        "~/Scripts/Framework/ViewModels/BoardViewModel.js",
                        "~/Scripts/Framework/ViewsCode/Board.js"));

            

            // Utilisez la version de développement de Modernizr pour le développement et l'apprentissage. Puis, une fois
            // prêt pour la production, utilisez l'outil de génération à l'adresse https://modernizr.com pour sélectionner uniquement les tests dont vous avez besoin.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/vendor/modernizr-*"));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/Custom/customNavBar.css"));

            bundles.Add(new StyleBundle("~/Content/boardcss").Include(
                      "~/Content/Custom/imagesGrid.css"));

            bundles.Add(new StyleBundle("~/Content/searchcss").Include(
                      "~/Content/Custom/searchBar.css"));
        }
    }
}
